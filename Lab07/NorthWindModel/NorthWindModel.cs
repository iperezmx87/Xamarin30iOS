using System;
using System.Threading.Tasks;
using NorthWind;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace NorthWindModel
{
    public class NorthwindModel : INorthWindModel
    {
        public NorthwindModel()
        {
        }

        public event ChangeStatusEventHandler ChangeStatus;

        // notificando el estatus
        public StatusOptions statusOpc
        {
            get;
            set;
        }

        public async Task<IProduct> GetProductByIDAsync(int ID)
        {
            //throw new NotImplementedException();

            Product product = new Product();

            using(var Client = new HttpClient()){
				Client.BaseAddress =
				  new Uri("https://ticapacitacion.com/webapi/northwind/");
				Client.DefaultRequestHeaders.Accept.Clear();
				Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                // Notificar aqui que la API Web será invocad
                this.statusOpc = StatusOptions.CallingWebAPI;
                Notify();

				HttpResponseMessage Response =
					await Client.GetAsync($"product/{ID}");
                // Notificar aquí que se va a verificar el resultado de la llamada
                this.statusOpc = StatusOptions.VerifyingResult;
                Notify();

				if (Response.IsSuccessStatusCode)
				{
					var JSONProduct = await Response.Content.ReadAsStringAsync();
					product = JsonConvert.DeserializeObject<Product>(JSONProduct);
                    if (product != null)
					{
                        // Notificar aqui que el produto fue encontrado
                        this.statusOpc = StatusOptions.ProductFound;
                        Notify();
					}
					else
					{
                        // notificar producto no encontrado
                        this.statusOpc = StatusOptions.ProductNotFound;
                        Notify();
					}
				}
            }

            return product;
        }

        private void Notify(){
			ChangeStatus?.Invoke(this, new ChangeStatusEventArgs()
			{
				Status = this.statusOpc
			});
        }
    }
}

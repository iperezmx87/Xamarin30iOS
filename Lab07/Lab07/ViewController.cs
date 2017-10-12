using System;
using NorthWind;
using NorthWindModel;

using UIKit;

namespace Lab07
{
    public partial class ViewController : UIViewController
    {
        NorthwindModel model = new NorthwindModel();

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            // suscribirse al evento
            model.ChangeStatus += (sender, e) => {
                StatusLabel.Text = e.Status.ToString();
            };

            BuscarButton.TouchUpInside += async (sender, e) => {
                IProduct prod = await model.GetProductByIDAsync(int.Parse(IdText.Text));

                NameText.Text = prod.ProductName;
                PriceText.Text = prod.UnitPrice.ToString();
                CountText.Text = prod.UnitsInStock.ToString();
                CategoryText.Text = prod.CategoryID.ToString();
            };

            ValidarButton.TouchUpInside+= (sender, e) => {
				if (this.Storyboard.InstantiateViewController("ValidarActividadController") is ValidarActividadController validarController)
				{
					this.NavigationController.PushViewController(validarController, true);
                    validarController.model = this.model;
				}
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

using Foundation;
using System;
using UIKit;
using NorthWind;

namespace Lab07
{
    public partial class ValidarActividadController : UIViewController
    {
        public INorthWindModel model;

        public ValidarActividadController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ValidarButton.TouchUpInside += async (sender, e) => {
				var Client = new SALLab07.ServiceClient();
				var Result = await Client.ValidateAsync(CorreoText.Text, ContraText.Text, model);

				var Alert = UIAlertController.Create("Resultado", $"{Result.Status}\n{Result.FullName}\n{Result.Token}", UIAlertControllerStyle.Alert);
				Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
				PresentViewController(Alert, true, null);
            };
        }
    }
}
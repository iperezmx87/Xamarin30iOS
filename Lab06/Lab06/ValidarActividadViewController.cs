using Foundation;
using System;
using UIKit;

namespace Lab06
{
    public partial class ValidarActividadViewController : UIViewController
    {

        PhoneTranslator translator = new PhoneTranslator();

        public ValidarActividadViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ValidateButton.TouchUpInside += async (sender, e) => {
                var Client = new SALLab06.ServiceClient();
                var Result = await Client.ValidateAsync(CorreoText.Text, ContraText.Text, this);

                var Alert = UIAlertController.Create("Resultado", $"{Result.Status}\n{Result.FullName}\n{Result.Token}", UIAlertControllerStyle.Alert);
                Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(Alert, true, null);
            };
        }
    }
}
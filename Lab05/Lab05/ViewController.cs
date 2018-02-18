using System;
using UIKit;

namespace Lab05
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var TranslatedNumber = string.Empty;

            TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                var Translator = new PhoneTranslator();

                TranslatedNumber = Translator.ToNumber(PhoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(TranslatedNumber))
                {
                    CallButton.SetTitle("Llamar", UIControlState.Normal);
                    CallButton.Enabled = false;

                }else
                {
                    CallButton.SetTitle($"Llamar al {TranslatedNumber}", UIControlState.Normal);
					CallButton.Enabled = true;
                }
            };

            CallButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                var URL = new Foundation.NSUrl($"tel:{TranslatedNumber}");

                if (!UIApplication.SharedApplication.OpenUrl(URL))
                {
                    var alert = UIAlertController.Create("No Soportado.", "El esquema 'tel:' no es soportado por este dispositivo",
                                                        UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(alert, true, null);
                }
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void VerifyButton_TouchUpInside(UIButton sender)
        {
            Validate();
        }

        async void Validate(){
            var Client = new SALLab05.ServiceClient();
            var Result = await Client.ValidateAsync("israel.perez@cencel.com.mx", "Isra-mx87", this);

            var Alert = UIAlertController.Create("Resultado", 
                                                 $"{Result.Status}\n{Result.FullName}\n{Result.Token}",
                                                 UIAlertControllerStyle.Alert);

            Alert.AddAction(UIAlertAction.Create("Ok", 
                                                 UIAlertActionStyle.Default, null));
            
            PresentViewController(Alert, true, null);
        }
    }
}
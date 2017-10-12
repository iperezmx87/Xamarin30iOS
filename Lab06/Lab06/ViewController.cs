using System;
using System.Collections.Generic;
using UIKit;

namespace Lab06
{
    public partial class ViewController : UIViewController
    {
		string TranslatedNumber = string.Empty;

		List<string> phoneNumbers = new List<string>();

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                var Translator = new PhoneTranslator();

                TranslatedNumber = Translator.ToNumber(PhoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(TranslatedNumber))
                {
                    CallButton.SetTitle("Llamar", UIControlState.Normal);
                    CallButton.Enabled = false;

                }
                else
                {
                    CallButton.SetTitle($"Llamar al {TranslatedNumber}", UIControlState.Normal);
                    CallButton.Enabled = true;
                }
            };

            CallButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                phoneNumbers.Add(TranslatedNumber);

                var URL = new Foundation.NSUrl($"tel:{TranslatedNumber}");

                if (!UIApplication.SharedApplication.OpenUrl(URL))
                {
                    var alert = UIAlertController.Create("No Soportado.", "El esquema 'tel:' no es soportado por este dispositivo",
                                                        UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(alert, true, null);
                }
            };

            CallHistoryButton.TouchUpInside += (sender, e) => {
                if (this.Storyboard.InstantiateViewController("CallHistoryController") is CallHistoryController controller)
                {
                    controller.PhoneNumbers = this.phoneNumbers;

                    this.NavigationController.PushViewController(controller, true);
                }
            };

            VerifyButton.TouchUpInside += (sender, e) => {
                if (this.Storyboard.InstantiateViewController("ValidateController") is ValidarActividadViewController validarController)
                {
                    this.NavigationController.PushViewController(validarController, true);
                }
            };
        }

        //public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
        //{
        //    base.PrepareForSegue(segue, sender);

        //    if (segue.DestinationViewController is CallHistoryController controller)
        //    {
        //        controller.PhoneNumbers = phoneNumbers;
        //    }
        //}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
      
    }
}

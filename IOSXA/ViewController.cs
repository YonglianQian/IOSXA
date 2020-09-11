using Foundation;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Phoneword;
using System;
using System.Collections.Generic;
using UIKit;

namespace IOSXA
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.


            //translatebutton
            string translatedNumber = "";

            TranslateButton.TouchUpInside += (object sender, EventArgs e) => {

                // Convert the phone number with text to a number
                // using PhoneTranslator.cs
                translatedNumber = PhoneTranslator.ToNumber(PhoneNumberText.Text);

                // Dismiss the keyboard if text field was tapped
                PhoneNumberText.ResignFirstResponder();

                if (translatedNumber == "")
                {
                    CallButton.SetTitle("Call", UIControlState.Normal);
                    CallButton.Enabled = false;
                }
                else
                {
                    CallButton.SetTitle("Call " + translatedNumber, UIControlState.Normal);
                    CallButton.Enabled = true;
                }
            };
            //callbutton
            CallButton.TouchUpInside += (object sender, EventArgs e) => {

                //var url = new NSUrl("tel:" + translatedNumber);
                //if (!UIApplication.SharedApplication.OpenUrl(url))
                //{
                //    var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
                //    alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                //    PresentViewController(alert, true, null);
                //}
                
                Crashes.GenerateTestCrash();

            };
          
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
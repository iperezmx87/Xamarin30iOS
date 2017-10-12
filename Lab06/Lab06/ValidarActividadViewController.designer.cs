// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Lab06
{
    [Register ("ValidarActividadViewController")]
    partial class ValidarActividadViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ContraText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField CorreoText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ValidateButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ContraText != null) {
                ContraText.Dispose ();
                ContraText = null;
            }

            if (CorreoText != null) {
                CorreoText.Dispose ();
                CorreoText = null;
            }

            if (ValidateButton != null) {
                ValidateButton.Dispose ();
                ValidateButton = null;
            }
        }
    }
}
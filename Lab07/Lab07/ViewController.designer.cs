// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Lab07
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BuscarButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField CategoryText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField CountText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField IdText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PriceText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel StatusLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ValidarButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BuscarButton != null) {
                BuscarButton.Dispose ();
                BuscarButton = null;
            }

            if (CategoryText != null) {
                CategoryText.Dispose ();
                CategoryText = null;
            }

            if (CountText != null) {
                CountText.Dispose ();
                CountText = null;
            }

            if (IdText != null) {
                IdText.Dispose ();
                IdText = null;
            }

            if (NameText != null) {
                NameText.Dispose ();
                NameText = null;
            }

            if (PriceText != null) {
                PriceText.Dispose ();
                PriceText = null;
            }

            if (StatusLabel != null) {
                StatusLabel.Dispose ();
                StatusLabel = null;
            }

            if (ValidarButton != null) {
                ValidarButton.Dispose ();
                ValidarButton = null;
            }
        }
    }
}
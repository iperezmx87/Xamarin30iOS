using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Lab05
{
    public class PhoneTranslator
    {
        private string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string Numbers = "22233344455566677778889999";

        public string ToNumber(string alfanumericNumber)
        {
            var NumericPhoneNumber = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(alfanumericNumber))
            {
                alfanumericNumber = alfanumericNumber.ToUpper();
                foreach (var c in alfanumericNumber)
                {
                    if ("0123456789".IndexOf(c) >= 0)
                    {
                        NumericPhoneNumber.Append(c);
                    }
                    else
                    {
                        var Index = Letters.IndexOf(c);
                        if (Index >= 0)
                        {
                            NumericPhoneNumber.Append(Numbers[Index]);
                        }
                    }
                }
            }
            return NumericPhoneNumber.ToString();
        }
    }
}
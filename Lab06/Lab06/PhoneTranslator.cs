using System;
using System.Text;

namespace Lab06
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

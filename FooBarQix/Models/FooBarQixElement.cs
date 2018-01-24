using System;
using System.Globalization;

namespace FooBarQix.Models
{
    public abstract class FooBarQixElement
    {
        public string DisplayName { get; protected set; }

        public int ElementNumber { get; protected set; }

        public string ElementNumberString => ElementNumber.ToString(CultureInfo.InvariantCulture) ;     

        protected FooBarQixElement(string displayName, int elementNumber)
        {
            if(elementNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(elementNumber), "Only strictly positive values are allowed.");
            }
            if (string.IsNullOrWhiteSpace(displayName))
            {
                throw new ArgumentNullException(nameof(displayName), "Only not null and not empty strings are allowed.");
            }

            DisplayName = displayName;
            ElementNumber = elementNumber;
        }

        public string DivisibleByElementNumberRule(int number) 
            => number % ElementNumber == 0 ? DisplayName : string.Empty;

        public string ContainsElementNumberRule(string numberAsString, int index)
        {
            if(numberAsString.Length < index + ElementNumberString.Length)
            {
                return string.Empty;
            }
            else
            {
                return numberAsString.Substring(index, ElementNumberString.Length) == ElementNumberString 
                    ? DisplayName : string.Empty;
            }
        }
    }
}

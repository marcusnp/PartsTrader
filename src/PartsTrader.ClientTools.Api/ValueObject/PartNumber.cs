using System;
using System.Collections.Generic;
using PartsTrader.ClientTools.Api.Exceptions;
using System.Text.RegularExpressions;
using PartsTrader.ClientTools.Api.Infrastructure;

namespace PartsTrader.ClientTools.Api.ValueObjects
{
    /// <summary>
    /// Validate the Part Number using the rules in the requirement 1
    /// </summary>
    public class PartNumber : ValueObject
    {
        /*That is a part id comprising of 4 digits, followed by a dash(-), followed by a part code consisting of 4 or more alphanumeric characters.
        So, 1234-abcd, 1234-a1b2c3d4 would be valid, 
        a234-abcd, 123-abcd would be invalid. 
        Where an invalid number is found an invalid part exception should be thrown.*/
        const string PATTERN = @"^\d{4}-[a-zA-Z0-9]{4,}$";

        private PartNumber()
        {
        }
        public static PartNumber For(string partString)
        {
            var partNumber = new PartNumber();

            bool isValid = Regex.IsMatch(partString, PATTERN, RegexOptions.IgnoreCase);
            if(!isValid)
            {
                throw new InvalidPartException(string.Format("{0}: This is not valid PartNumber!", partString));
            }
            var index = partString.IndexOf("-", StringComparison.Ordinal);
            partNumber.PartId = partString.Substring(0, index);
            partNumber.PartCode = partString.Substring(index + 1);

            return partNumber;
        }

        public string PartId { get; private set; }

        public string PartCode { get; private set; }

        public static implicit operator string(PartNumber partNumber)
        {
            return partNumber.ToString();
        }

        public static explicit operator PartNumber(string partString)
        {
            return For(partString);
        }

        public override string ToString()
        {
            return $"{PartId}-{PartCode}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return PartId;
            yield return PartCode;
        }
    }
}
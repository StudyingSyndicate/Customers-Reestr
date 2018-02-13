using System;
using System.Globalization;

namespace CustomersReestr.Components.Utils
{
    class DateHelper
    {
        public static DateTime ParseRusDateTime(string input)
        {
            return DateTime.ParseExact(input, "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}

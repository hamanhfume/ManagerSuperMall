using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controllers
{
    public class Filter : IFilter
    {
        // Input is number Integer: Valid: number > 0
        public bool IsIdItemsValid(string input)
        {
            string pattern = @"^[1-9]\d*$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(input))
            {
                return true;
            }
            return false;
        }
        // Valid: Mì Cay, Phở
        public bool IsNameItemsValid(string input)
        {
            string pattern = @"^[a-zA-Z0-9\s\u00C0-\u1EF9]+$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        public bool IsExistsIdItemsValid(List<Items> listItems, int input)
        {
            for (int i = 0; i < listItems.Count; i++)
            {
                if (listItems[i].IdItem == input)
                {
                    return true;
                }
            }
            return false;
        }

        // Valid: Hà Văn Mạnh
        public bool IsFullNameCustomerValid(string input)
        {
            string pattern = @"^[\p{L} ]{1,}\p{L}(?:[\p{Zs}-][\p{L}]+){1,}$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(input))
            {
                return true;
            }
            return false;
        }
        // Valid: hamanhfume@gmail.com
        public bool IsEmailCustomerValid(string input)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input))
            {
                return true;
            }
            return false;
        }
        // Valid: 0987209593
        public bool IsPhoneCustomerValid(string input)
        {
            string pattern = @"^(02|03|04|05|06|08|09)\d{8}$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(input))
            {
                return true;
            }
            return false;
        }
        // Valid: 0012020355227
        public bool IsCCCDCustomerValid(string input)
        {
            string pattern = @"^[0-9]{12}$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        public bool IsExistsCustomerValid(List<Customers> customers, string input)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].IdPerson == input)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsIdDiscountValid(string input)
        {
            string pattern = @"^[1-9]\d*$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        public bool IsExistsIdDiscountValid(List<Discounts> listDiscounts, int input)
        {
            for (int i = 0; i < listDiscounts.Count; i++)
            {
                if (listDiscounts[i].IdDiscount == input)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

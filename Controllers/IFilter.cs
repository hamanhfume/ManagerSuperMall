using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Controllers
{
    public interface IFilter
    {
        //Filter Items
        bool IsIdItemsValid(string input);
        bool IsNameItemsValid(string input);
        bool IsExistsIdItemsValid(List<Items> listItems, int input);
        //Filter Customer
        bool IsCCCDCustomerValid(string input);
        bool IsFullNameCustomerValid(string input);
        bool IsEmailCustomerValid(string input);
        bool IsPhoneCustomerValid(string input);
        bool IsExistsCustomerValid(List<Customers> customers, string input);
        //Filter Discounts
        bool IsIdDiscountValid(string input);
        bool IsExistsIdDiscountValid(List<Discounts> listDiscounts, int input);

    }
}

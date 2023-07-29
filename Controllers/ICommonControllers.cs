using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{

    //Delegate -> search byContent || -> search byValue || delegate: method item.attribute == content/from - to
    public delegate bool CheckItemsContentInListDeletegate<T,V>(T item, V content);
    public delegate bool CheckItemsToFormInListDeletegate<T,V>(T item, V from, V to);

    public interface ICommonControllers
    {
        int GetItemsById(List<Items> listItems, int id);
        //Method: Hiệu lực Discount -> So sánh với DateTime.Now.
        string GetDiscountNameTimeReal(Discounts discount);

        // Method: Sắp xếp, nhận vào List -> objectList<T>.Sort(Parameter là đối tượng kiểu Delegate)
        void Sort<T>(List<T> listItems, Comparison<T> comparison);
        // Method: So sánh 2 đối tượng -> a > b -> Sort ASC || a < b -> Sort DESC ==> Return: - 0 +
        int CompareByIdASC(Items item1, Items item2);
        int CompareByPriceASC(Items item1, Items item2);
        int CompareByPriceDESC(Items item1, Items item2);
        int CompareByQuantittyDESC(Items item1, Items item2);
        int CompareByNameASC(Items item1, Items item2);
        int CompareByReleaseDateASC(Items item1, Items item2);

        // Method: Search Items List<Items> Overloading.
        List<T> GetListSearch<T, V>(List<T> listItems, CheckItemsContentInListDeletegate<T, V> contentDelegate, V content);
        List<T> GetListSearch<T, V>(List<T> listItems, CheckItemsToFormInListDeletegate<T, V> formtoDelegate, V from, V to);
        bool IsItemNameMatch(Items item, string name);
        bool IsItemTypeMatch(Items item, string type);
        bool IsItemBrandeMatch(Items item, string brand);
        bool IsItemPriceMatch(Items item, long from, long to);
        bool IsItemQuantityMatch(Items item, int from,int to);


        //Customer Common.
        int GetCustomerById(List<Customers> listCustomers, string id);
        int CompareCustomerByIdASC(Customers customer1, Customers customer2);
        int CompareCustomerByNameASC(Customers customer1, Customers customer2);
        int CompareCustomerByPointDESC(Customers customer1, Customers customer2);
        int CompareCustomerByBirthDateASC(Customers customer1, Customers customer2);
        int CompareCustomerByCreateTimeAccountASC(Customers customer1, Customers customer2);
        // Method: Search Customers List<Customer> Overloading.
        bool IsCustomerNameMatch(Customers customer, string fullName);
        bool IsCustomerIdMatch(Customers customer, string id);
        bool IsCustomerTypeMatch(Customers customer, string type);
        bool IsCustomerAddressMatch(Customers customer, string address);
        bool IsCustomerPhoneMatch(Customers customer, string phone);

        //Discount Common
        int GetDiscountById(List<Discounts> listDiscount, int id);
        int CompareDiscountByIdASC(Discounts discount1, Discounts discount2);
        // Method: Search Discounts List<Discounts> Overloading.
        bool IsDiscountNameMatch(Discounts discount, string nameDiscount);
        bool IsStartDiscountMatch(Discounts discount, string timeStartDiscount);
        bool IsEndDiscountMatch(Discounts discount, string timeEndDiscount);

        //Bill Common
        int GetIndexBillDetailById(List<BillDetails> listBillDetails, int id);
        int GetIndexSelectedItemById(List<SelectedItems> listSelectedItems,int id);
        int CompareBillDetailByIdASC(BillDetails billDetail1, BillDetails billDetail2);
        int CompareBillDetailSortByTotalAmountDESC(BillDetails billDetail1, BillDetails billDetail2);
        int CompareBillDetailByItemDESC(BillDetails billDetail1, BillDetails billDetail2);
        int CompareBillDetailByCreateTimeBillASC(BillDetails billDetail1, BillDetails billDetail2);
        int CompareBillDetailByCreateTimeBillDESC(BillDetails billDetail1, BillDetails billDetail2);
        int CompareBillDetailByNameCustomerASC(BillDetails billDetail1, BillDetails billDetail2);
        bool IsBillDetailTimeCreateBillMatch(BillDetails billDetail, string createTimeBill);
        bool IsBillDetailNameCustomerMatch(BillDetails billDetail, string nameCustomer);
        bool IsBillDetailNameStaffMatch(BillDetails billDetail, string nameStaff);
        bool IsBillDetailStatusMatch(BillDetails billDetail, string status);





        bool IsExitsItemInBill(Items itemBillRemove, List<BillDetails> listBillDetail);
    }
}

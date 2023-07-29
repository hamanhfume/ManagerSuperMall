using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Controllers
{
    public class CommonController : ICommonControllers
    {
        public int GetItemsById(List<Items> listItems, int id)
        {
            for (int i = 0; i < listItems.Count; i++)
            {
                if (listItems[i].IdItem.CompareTo(id) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public string GetDiscountNameTimeReal(Discounts discount)
        {
            if (discount == null)
            {
                return "-";
            }
            else
            {
                DateTime currentTime = DateTime.Now;
                if (currentTime >= discount.StartTimeDiscount && currentTime <= discount.EndTimeDiscount)
                {
                    return discount.NameDiscount;
                }
                else
                {
                    return "-";
                }
            }
        }

        // Method: Sắp xếp danh sách Items -> .Sort(Nhận vào đối tượng comparison)
        // -> delegate type Comparison<T> -> Argument == method(2 agruments) -> return int.
        public void Sort<T>(List<T> listItems, Comparison<T> comparison)
        {
            listItems.Sort(comparison);
        }
        // Method: So sánh 2 đối tượng -> a > b -> Sort ASC || a < b -> Sort DESC ==> Return: - 0 +
        public int CompareByIdASC(Items item1, Items item2)
        {
            return item1.IdItem.CompareTo(item2.IdItem);
        }
        public int CompareByNameASC(Items item1, Items item2)
        {
            return item1.FullNameItem.CompareTo(item2.FullNameItem);
        }

        public int CompareByPriceASC(Items item1, Items item2)
        {
            return item1.PriceItem.CompareTo(item2.PriceItem);
        }

        public int CompareByPriceDESC(Items item1, Items item2)
        {
            return item2.PriceItem.CompareTo(item1.PriceItem);
        }

        public int CompareByQuantittyDESC(Items item1, Items item2)
        {
            return item2.QuantityItem.CompareTo(item1.QuantityItem);
        }

        public int CompareByReleaseDateASC(Items item1, Items item2)
        {
            return item1.ReleaseDateItem.CompareTo(item2.ReleaseDateItem);
        }

        //Implement -> ListItemsAfterSearch.  -> compareTo() item.attribute in the ListItems.
        // Search in ListItems -> Show NewListItem -> Reset show ListItems
        public List<T> GetListSearch<T, V>(List<T> listItems, CheckItemsContentInListDeletegate<T, V> contentDelegate, V content)
        {
            List<T> listItemsAfterSearch = new List<T>();
            for (int i = 0; i < listItems.Count; i++)
            {
                if (contentDelegate(listItems[i], content))
                {
                    listItemsAfterSearch.Add(listItems[i]);
                }
            }
            return listItemsAfterSearch;
        }

        public List<T> GetListSearch<T, V>(List<T> listItems, CheckItemsToFormInListDeletegate<T, V> formtoDelegate, V from, V to)
        {
            List<T> listItemsAfterSearch = new List<T>();
            for (int i = 0; i < listItems.Count; i++)
            {
                if (formtoDelegate(listItems[i], from, to))
                {
                    listItemsAfterSearch.Add(listItems[i]);
                }
            }
            return listItemsAfterSearch;
        }

        public bool IsItemNameMatch(Items item, string name)
        {
            //Regular: -> nameItem = content
            string pattern = $".*{name}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(item.FullNameItem))
            {
                return true;
            }
            return false;
        }

        public bool IsItemTypeMatch(Items item, string type)
        {
            string pattern = $".*{type}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(item.TypeItem))
            {
                return true;
            }
            return false;
        }

        public bool IsItemBrandeMatch(Items item, string brand)
        {
            string pattern = $".*{brand}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(item.BrandItem))
            {
                return true;
            }
            return false;
        }

        public bool IsItemPriceMatch(Items item, long from, long to)
        {
            return item.PriceItem >= from && item.PriceItem <= to;
        }

        public bool IsItemQuantityMatch(Items item, int from, int to)
        {
            return item.QuantityItem >= from && item.PriceItem <= to;
        }

        //Implement Common ListCustomer.
        public int GetCustomerById(List<Customers> listCustomers, string id)
        {
            for (int i = 0; i < listCustomers.Count; i++)
            {
                if (listCustomers[i].IdPerson.CompareTo(id) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        public int CompareCustomerByIdASC(Customers customer1, Customers customer2)
        {
            return customer1.IdPerson.CompareTo(customer2.IdPerson);
        }

        public int CompareCustomerByNameASC(Customers customer1, Customers customer2)
        {
            return customer1.FullNamePerson.ToString().CompareTo(customer2.FullNamePerson.ToString());
        }

        public int CompareCustomerByPointDESC(Customers customer1, Customers customer2)
        {
            return customer2.PointCustomer.CompareTo(customer1.PointCustomer);
        }

        public int CompareCustomerByBirthDateASC(Customers customer1, Customers customer2)
        {
            return customer1.BirtDatePerson.CompareTo(customer2.BirtDatePerson);

        }
        public int CompareCustomerByCreateTimeAccountASC(Customers customer1, Customers customer2)
        {
            return customer1.CreateTimeAccountCustomer.CompareTo(customer2.CreateTimeAccountCustomer);
        }

        public bool IsCustomerNameMatch(Customers customer, string fullName)
        {
            string pattern = $".*{fullName}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(customer.FullNamePerson.ToString()))
            {
                return true;
            }
            return false;
        }

        public bool IsCustomerIdMatch(Customers customer, string id)
        {
            string pattern = $".*{id}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(customer.IdPerson))
            {
                return true;
            }
            return false;
        }

        public bool IsCustomerTypeMatch(Customers customer, string type)
        {
            string pattern = $".*{type}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(customer.TypeCustomer))
            {
                return true;
            }
            return false;
        }

        public bool IsCustomerAddressMatch(Customers customer, string address)
        {
            string pattern = $".*{address}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(customer.Address))
            {
                return true;
            }
            return false;
        }

        public bool IsCustomerPhoneMatch(Customers customer, string phone)
        {
            string pattern = $".*{phone}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(customer.PhoneNumber))
            {
                return true;
            }
            return false;
        }

        //Implement Common Discount
        public int GetDiscountById(List<Discounts> listDiscount, int id)
        {
            for (int i = 0; i < listDiscount.Count; i++)
            {
                if (listDiscount[i].IdDiscount.CompareTo(id) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        public int CompareDiscountByIdASC(Discounts discount1, Discounts discount2)
        {
            return discount1.IdDiscount.CompareTo(discount2.IdDiscount);
        }

        public bool IsDiscountNameMatch(Discounts discount, string nameDiscount)
        {
            string pattern = $".*{nameDiscount}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(discount.NameDiscount))
            {
                return true;
            }
            return false;
        }

        public bool IsStartDiscountMatch(Discounts discount, string timeStartDiscount)
        {
            string pattern = $".*{timeStartDiscount}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(discount.StartTimeDiscount.ToString("dd/MM/yyyy HH:mm:ss")))
            {
                return true;
            }
            return false;
        }

        public bool IsEndDiscountMatch(Discounts discount, string timeEndDiscount)
        {
            string pattern = $".*{timeEndDiscount}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(discount.EndTimeDiscount.ToString("dd/MM/yyyy HH:mm:ss")))
            {
                return true;
            }
            return false;
        }
        //Bill Common
        public int GetIndexBillDetailById(List<BillDetails> listBillDetails, int id)
        {
            for (int i = 0; i < listBillDetails.Count; i++)
            {
                if (listBillDetails[i].IdBill == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public int GetIndexSelectedItemById(List<SelectedItems> listSelectedItems, int id)
        {
            for (int i = 0; i < listSelectedItems.Count; i++)
            {
                if (listSelectedItems[i].IdItem == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public int CompareBillDetailByIdASC(BillDetails billDetail1, BillDetails billDetail2)
        {
            return billDetail1.IdBill.CompareTo(billDetail2.IdBill);
        }

        public int CompareBillDetailSortByTotalAmountDESC(BillDetails billDetail1, BillDetails billDetail2)
        {
            return billDetail2.TotalAmountBill.CompareTo(billDetail1.TotalAmountBill);
        }

        public int CompareBillDetailByItemDESC(BillDetails billDetail1, BillDetails billDetail2)
        {
            return billDetail2.TotalItemBill.CompareTo(billDetail1.TotalItemBill);
        }

        public int CompareBillDetailByCreateTimeBillASC(BillDetails billDetail1, BillDetails billDetail2)
        {
            return billDetail1.CreateTimeBill.CompareTo(billDetail2.CreateTimeBill);
        }

        public int CompareBillDetailByCreateTimeBillDESC(BillDetails billDetail1, BillDetails billDetail2)
        {
            return billDetail2.CreateTimeBill.CompareTo(billDetail1.CreateTimeBill);
        }

        public int CompareBillDetailByNameCustomerASC(BillDetails billDetail1, BillDetails billDetail2)
        {
            return billDetail1.CartBill.CustomerCart.FullNamePerson.ToString().CompareTo(billDetail2.CartBill.CustomerCart.FullNamePerson.ToString());
        }

        public bool IsBillDetailTimeCreateBillMatch(BillDetails billDetail, string createTimeBill)
        {
            string pattern = $".*{createTimeBill}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(billDetail.CreateTimeBill.ToString()))
            {
                return true;
            }
            return false;
        }

        public bool IsBillDetailNameCustomerMatch(BillDetails billDetail, string nameCustomer)
        {
            string pattern = $".*{nameCustomer}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(billDetail.CartBill.CustomerCart.FullNamePerson.ToString()))
            {
                return true;
            }
            return false;
        }

        public bool IsBillDetailNameStaffMatch(BillDetails billDetail, string nameStaff)
        {
            string pattern = $".*{nameStaff}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(billDetail.StaffNameBillDetails.ToString()))
            {
                return true;
            }
            return false;
        }

        public bool IsBillDetailStatusMatch(BillDetails billDetail, string status)
        {
            string pattern = $".*{status}.*";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(billDetail.StatusBill.ToString()))
            {
                return true;
            }
            return false;
        }

        public bool IsExitsItemInBill(Items itemBillRemove, List<BillDetails> listBillDetail)
        {
            for (int i = 0; i < listBillDetail.Count; i++)
            {
                if (listBillDetail[i] != null && itemBillRemove != null)
                {
                    for (int j = 0; j < listBillDetail[i].CartBill.SelectedItemCart.Count; j++)
                    {
                        if (itemBillRemove != null && listBillDetail[i].CartBill.SelectedItemCart[j] != null)
                        {
                            if (listBillDetail[i].CartBill.SelectedItemCart[j].IdItem == itemBillRemove.IdItem)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}

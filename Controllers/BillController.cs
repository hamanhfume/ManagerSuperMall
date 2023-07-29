using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class BillController : IBillController
    {
        //Method: Update Bill->BillDetail
        public void UpdateBillBillDetail(BillDetails billDetails, SelectedItems itemSelected)
        {
            int index = billDetails.CartBill.SelectedItemCart.IndexOf(itemSelected);
            if(index >= 0)
            {
                List<SelectedItems> listSelectedItems = billDetails.CartBill.SelectedItemCart;
                billDetails.TotalSubBill = 0;
                billDetails.TotalItemBill = 0;
                billDetails.TotalAmountBill = 0;
                billDetails.TotalDiscountBill = 0;
                foreach(SelectedItems item in listSelectedItems)
                {
                    billDetails.TotalSubBill += itemSelected.PriceItem * itemSelected.NumberOfSelectedItem;
                    billDetails.TotalItemBill += item.NumberOfSelectedItem;
                    billDetails.TotalAmountBill += item.NumberOfSelectedItem * item.PriceAfterDiscounts;
                    // Kiểm tra Discount != Null -> Thì tính và cập nhập giá.
                    if (item.DiscountItem != null)
                    {
                        billDetails.TotalDiscountBill += (int)(item.NumberOfSelectedItem * item.PriceAfterDiscounts
                                                      * (1.0f * item.DiscountItem.PercentDiscount / 100))
                                                      + item.NumberOfSelectedItem * item.DiscountItem.PriceAmountDiscount;
                    }
                }
            }
            else
            {
                billDetails.CartBill.SelectedItemCart.Add(itemSelected);
                billDetails.TotalSubBill += itemSelected.PriceItem * itemSelected.NumberOfSelectedItem;
                billDetails.TotalItemBill += itemSelected.NumberOfSelectedItem;
                billDetails.TotalAmountBill += itemSelected.NumberOfSelectedItem * itemSelected.PriceAfterDiscounts;
                // Kiểm tra Discount != Null -> Thì tính và cập nhập giá.
                if (itemSelected.DiscountItem != null)
                {
                    billDetails.TotalDiscountBill += (int)(itemSelected.NumberOfSelectedItem * itemSelected.PriceAfterDiscounts
                                                  * (1.0f * itemSelected.DiscountItem.PercentDiscount / 100))
                                                  + itemSelected.NumberOfSelectedItem * itemSelected.DiscountItem.PriceAmountDiscount;
                }
            }
        }

        public void RemoveBillBillDetail(BillDetails billDetails, SelectedItems itemSelected)
        {
            billDetails.TotalSubBill -= itemSelected.PriceItem * itemSelected.NumberOfSelectedItem;
            billDetails.TotalItemBill -= itemSelected.NumberOfSelectedItem;
            billDetails.TotalAmountBill -= itemSelected.NumberOfSelectedItem * itemSelected.PriceAfterDiscounts;
            // Kiểm tra Discount != Null -> Thì tính và cập nhập giá.
            if (itemSelected.DiscountItem != null)
            {
                billDetails.TotalDiscountBill -= (int)(itemSelected.NumberOfSelectedItem * itemSelected.PriceAfterDiscounts
                                              * (1.0f * itemSelected.DiscountItem.PercentDiscount / 100))
                                              + itemSelected.NumberOfSelectedItem * itemSelected.DiscountItem.PriceAmountDiscount;
            }
            billDetails.CartBill.SelectedItemCart.Remove(itemSelected);
        }


        public bool IsExistedSelectedItemInBillDetail(BillDetails billDetails, SelectedItems itemSelected)
        {
            for(int i = 0; i< billDetails.CartBill.SelectedItemCart.Count; i++)
            {
                if (billDetails.CartBill.SelectedItemCart[i].IdItem == itemSelected.IdItem)
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateQuantityBillDetailItemsStock(BillDetails billDetail, List<Items> items)
        {
            List<SelectedItems> selectedItems = billDetail.CartBill.SelectedItemCart;
            for(int i = 0; i < selectedItems.Count; i++)
            {
                for(int j = 0; j < items.Count; j++)
                {
                    if (selectedItems[i] != null && items[i] != null &&
                        selectedItems[i].IdItem.CompareTo(items[j].IdItem) == 0)
                    {
                        items[j].QuantityItem += selectedItems[i].NumberOfSelectedItem;
                    }
                }
            }
        }
    }
}

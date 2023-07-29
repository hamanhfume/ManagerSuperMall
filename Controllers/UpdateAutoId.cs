using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class UpdateAutoId : IUpdateAutoId
    {
        public void UpdateBillDetailsAutoId(List<BillDetails> listBillDetails)
        {
            int billId = 0;
            for (int i = 0; i < listBillDetails.Count; i++)
            {
                if (billId < listBillDetails[i].IdBill)
                {
                    billId = listBillDetails[i].IdBill;
                }
            }
            BillDetails.UpdateAutoId(billId + 1);
        }

        public void UpdateDiscountsAutoId(List<Discounts> listDiscount)
        {
            int discountId = 0;
            for (int i = 0; i < listDiscount.Count; i++)
            {
                if (discountId < listDiscount[i].IdDiscount)
                {
                    discountId = listDiscount[i].IdDiscount;
                }
            }
            Discounts.UpdateAutoId(discountId + 1);
        }

        public void UpdateItemsAutoId(List<Items> listItems)
        {
            int itemId = 0;
            for (int i = 0; i < listItems.Count; i++)
            {
                if (itemId < listItems[i].IdItem)
                {
                    itemId = listItems[i].IdItem;
                }
            }
            Items.UpdateAutoId(itemId + 1);
        }
    }
}

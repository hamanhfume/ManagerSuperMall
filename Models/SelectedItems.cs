using Newtonsoft.Json;
using System;

namespace Models
{

    // Thực thể mặt hàng được chọn inheritance mặt hàng.
    // Association: 1  -  1 (Items)
    //              1  -  1 (Carts)
    public class SelectedItems : Items
    {
        [JsonProperty("numberOfSelectedItem")]
        public int NumberOfSelectedItem { get; set; }
        [JsonProperty("priceAfterDiscounts")]
        public long PriceAfterDiscounts { get; set; }

        public SelectedItems() : base()
        {
            CaculatePriceAfterDiscounts();
        }

        public SelectedItems(Items item) : base(item.IdItem,item.FullNameItem,item.TypeItem,item.QuantityItem,item.BrandItem,item.ReleaseDateItem,item.PriceItem,item.DiscountItem)
        {
            CaculatePriceAfterDiscounts();
        }

        public SelectedItems(int numberOfSelectedItem) : base()
        {
            NumberOfSelectedItem = numberOfSelectedItem;
            CaculatePriceAfterDiscounts();
        }

        public SelectedItems(int numberOfSelectedItem, int idItem, string fullNameItem, string typeItem, int quantityItem, string brandItem,
                            DateTime releaseDateItem, long priceItem, Discounts discountItem)
                           : base(idItem, fullNameItem, typeItem, quantityItem, brandItem, releaseDateItem, priceItem, discountItem)
        {
            NumberOfSelectedItem = numberOfSelectedItem;
            CaculatePriceAfterDiscounts();
        }


        // Tính toán lại giá của item sau khi khuyến mãi theo thời gian khuyến mãi và kiểu khuyến mãi.
        private void CaculatePriceAfterDiscounts()
        {
            if (DiscountItem == null)
            {
                PriceAfterDiscounts = PriceItem;
            }
            else
            {
                DateTime currentTime = DateTime.Now;
                if (currentTime >= DiscountItem.StartTimeDiscount && currentTime <= DiscountItem.EndTimeDiscount)
                {
                    if (DiscountItem.PercentDiscount > 0)
                    {
                        PriceAfterDiscounts = (long)(PriceItem * (1 - 1.0f * DiscountItem.PercentDiscount / 100));
                    }

                    if (DiscountItem.PriceAmountDiscount > 0)
                    {
                        PriceAfterDiscounts = PriceItem - DiscountItem.PriceAmountDiscount;
                    }
                }
            }
        }


        public object[] ObjectToArraySelectItem(BillDetails billDetail)
        {
            return new object[] {  billDetail.IdBill, IdItem, FullNameItem, NumberOfSelectedItem, $"{PriceItem:N0}", $"{PriceAfterDiscounts:N0}", $"{NumberOfSelectedItem*PriceAfterDiscounts:N0}"};
        }
    }
}

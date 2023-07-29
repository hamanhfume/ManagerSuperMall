using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Models
{
    // Thực thể mặt hàng.
    // Associtation: 1  -> n (SelectItems)
    //               1  -> 1 (Discounts)

    // Compareto -> Chỉ có ở dataType_string
    // -> Inheritance interface: Icomparable<T>
    // -> Để instance của class có thể gọi ra và sử dụng.
    public class Items : IComparable<Items>
    {
        // coding convention fields static -> s_nameProperties
        [JsonIgnore]
        private static int s_autoId = 100000;
        [JsonProperty("idItem")]
        public int IdItem { get; set; }
        [JsonProperty("nameItem")]
        public string FullNameItem { get; set; }
        [JsonProperty("typeItem")]
        public string TypeItem { get; set; }
        [JsonProperty("quantityItem")]
        public int QuantityItem { get; set; }
        [JsonProperty("brandItem")]
        public string BrandItem { get; set; }
        [JsonProperty("releaseDateItem")]
        public DateTime ReleaseDateItem { get; set; }
        [JsonProperty("priceItem")]
        public long PriceItem { get; set; }
        [JsonProperty("discountItem")]
        public Discounts DiscountItem { get; set; }

        public Items()
        {

        }

        public Items(int id)
        {
            // Nếu không cung cấp id -> Nó sẽ dùng id tự tăng.
            IdItem = id > 0 ? id : s_autoId++;
        }

        public Items(int idItem, string fullNameItem, string typeItem, int quantityItem,
                    string brandItem, DateTime releaseDateItem, long priceItem, Discounts discountItem)
                   : this(idItem)
        {
            FullNameItem = fullNameItem;
            TypeItem = typeItem;
            QuantityItem = quantityItem;
            BrandItem = brandItem;
            ReleaseDateItem = releaseDateItem;
            PriceItem = priceItem;
            DiscountItem = discountItem;
        }

        // Update Id của đối tượng nếu khi đang tạo hóa đơn mà tăng số lượng hoặc kết thúc phiên làm việc
        // Kết thúc ngày làm việc cũ -> update mã id_auto New -> Để không trùng lặp.
        // Bỏ đi đối tượng Item cũ -> Tạo ra đối tượng Item mới với id mới.
        public static void UpdateAutoId(int newValue)
        {
            s_autoId = newValue;
        }

        // So sánh sắp xếp 2 đối tượng
        // Parmeter: Object: Item   -> So sánh theo IdItem.
        public int CompareTo(Items other)
        {
            return IdItem - other.IdItem;
        }

        // Sử dụng Equals và Hashcode -> Để kiểm tra xem mặt hàng đó có tồn tại hay không?
        // Parmeter: Object: Item     -> So sánh theo IdItem.
        public override bool Equals(object obj)
        {
            return obj is Items items &&
                   IdItem == items.IdItem;
        }

        public override int GetHashCode()
        {
            return -2113648141 + IdItem.GetHashCode();
        }

        //Chuyển đổi dữ liệu kiểu đối tượng sang mảng đối tượng mảng.
        public object[] ObjectToArray()
        {
            return new object[] { IdItem, FullNameItem, TypeItem, QuantityItem, BrandItem, ReleaseDateItem.ToString("dd/MM/yyyy"), $"{PriceItem:N0}", DiscountItem == null ? "-" : DateTime.Now >= DiscountItem.StartTimeDiscount && DateTime.Now <= DiscountItem.EndTimeDiscount ? DiscountItem.NameDiscount : $"Promotion-Expires: {DiscountItem.NameDiscount}" };
        }

        public object[] ObjectToArrayAddBill()
        {
            return new object[] { IdItem, FullNameItem, QuantityItem };
        }
    }
}

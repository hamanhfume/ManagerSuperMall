using Newtonsoft.Json;
using System;
namespace Models
{
    // Thực thể Hóa đơn
    // Association: 1 - n (Items) -> n (Discounts)
    //              1 - 1 (Customers)
    //              1 - n (BillsDetail)
    public class Bills : IComparable<Bills>
    {
        [JsonIgnore]
        private static int s_autoId = 1000000;
        [JsonProperty("idBill")]
        public int IdBill { get; set; }
        [JsonProperty("cartBill")]
        public Carts CartBill { get; set; } = new Carts();
        [JsonProperty("createTimeBill")]
        public DateTime CreateTimeBill { get; set; }
        [JsonProperty("totalItemBill")]
        public int TotalItemBill { get; set; } = 0;
        [JsonProperty("totalSubBill")]
        public long TotalSubBill { get; set; } = 0;
        [JsonProperty("totalDiscountBill")]
        public long TotalDiscountBill { get; set; } = 0;
        [JsonProperty("totalAmountBill")]
        public long TotalAmountBill { get; set; } = 0;
        [JsonProperty("statusBill")]
        public string StatusBill { get; set; } = "";
        public Bills()
        {
            
        }

        public Bills(int id)
        {
            IdBill = id > 0 ? id : s_autoId++;
        }

        public Bills(int idBill, Carts cartBill, DateTime createTimeBill, int totalItemBill,
                     long totalSubBill, long totalDiscountBill, long totalAmountBill, string statusBill)
                   : this(idBill)
        {
            CartBill = cartBill;
            CreateTimeBill = createTimeBill;
            TotalItemBill = totalItemBill;
            TotalSubBill = totalSubBill;
            TotalDiscountBill = totalDiscountBill;
            TotalAmountBill = totalAmountBill;
            StatusBill = statusBill;
        }


        // Update Id của đối tượng nếu khi đang tạo hóa đơn mà tăng số lượng hoặc kết thúc phiên làm việc
        // Kết thúc ngày làm việc cũ -> update mã id_auto New -> Để không trùng lặp.
        // Bỏ đi đối tượng Item cũ -> Tạo ra đối tượng Item mới với id mới.
        public static void UpdateAutoId(int newValue)
        {
            s_autoId = newValue;
        }

        // So sánh 2 đối tượng theo Bill
        public int CompareTo(Bills other)
        {
            return IdBill - other.IdBill;
        }

        // Kiểm tra xem đối tượng có tồn tại không ?
        public override bool Equals(object obj)
        {
            return obj is Bills bills &&
                   IdBill == bills.IdBill;
        }

        public override int GetHashCode()
        {
            return 44064933 + IdBill.GetHashCode();
        }
        
    }
}

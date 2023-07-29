using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // Thực thể Khuyến mãi
    // Association: 1 - 1 (Items)
    public class Discounts
    {
        [JsonIgnore]
        private static int s_autoId = 1000000;
        [JsonProperty("idDiscount")]
        public int IdDiscount { get; set; }
        [JsonProperty("nameDiscount")]
        public string NameDiscount { get; set; }
        [JsonProperty("startTimeDiscount")]
        public DateTime StartTimeDiscount { get; set; }
        [JsonProperty("endTimeDiscount")]
        public DateTime EndTimeDiscount { get; set; }
        [JsonProperty("typeDiscount")]
        public string TypeDiscount { get; set; }
        [JsonProperty("percentDiscount")]
        public int PercentDiscount { get; set; }
        [JsonProperty("priceAmountDiscount")]
        public int PriceAmountDiscount { get; set; }

        public Discounts()
        {

        }

        public Discounts(int idDiscount)
        {
            IdDiscount = idDiscount > 0 ? idDiscount : s_autoId++;
        }

        public Discounts(int idDiscount, string nameDiscount, DateTime startTimeDiscount, DateTime endTimeDiscount,
                         string typeDiscount, int percentDiscount, int priceAmountDiscount) : this(idDiscount)
        {
            NameDiscount = nameDiscount;
            StartTimeDiscount = startTimeDiscount;
            EndTimeDiscount = endTimeDiscount;
            TypeDiscount = typeDiscount;
            PercentDiscount = percentDiscount;
            PriceAmountDiscount = priceAmountDiscount;
        }

        // Update Id của đối tượng nếu khi đang tạo hóa đơn mà tăng số lượng hoặc kết thúc phiên làm việc
        // Kết thúc ngày làm việc cũ -> update mã id_auto New -> Để không trùng lặp.
        // Bỏ đi đối tượng Item cũ -> Tạo ra đối tượng Item mới với id mới.
        public static void UpdateAutoId(int newValue)
        {
            s_autoId = newValue;
        }

        // Kiểm tra xem sản phẩm đó có được khuyến mãi hay không ? 
        // Parmeter: Object: Item     -> So sánh theo IdDiscount
        public override bool Equals(object obj)
        {
            return obj is Discounts discounts &&
                   IdDiscount == discounts.IdDiscount;
        }

        public override int GetHashCode()
        {
            return 152972083 + IdDiscount.GetHashCode();
        }

        public object[] ObjectDiscountToArray()
        {
            return new object[] {IdDiscount,NameDiscount,StartTimeDiscount.ToString("dd/MM/yyyy HH:mm:ss"),EndTimeDiscount.ToString("dd/MM/yyyy HH:mm:ss"),TypeDiscount,PercentDiscount.ToString() + "%",$"{PriceAmountDiscount:N0}" };
        }
    }
}

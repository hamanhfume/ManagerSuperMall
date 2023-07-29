using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // Thực thể Giỏ hàng
    // Association: 1 - 1 (Customers)
    //              1 - n (SelectedItem)

    public class Carts : IComparable<Carts>
    {
        [JsonIgnore]
        private static int s_autoId = 10000000;
        [JsonProperty("idCart")]
        public int IdCart { get; set; }
        [JsonProperty("customerCart")]
        public Customers CustomerCart { get; set; }
        [JsonProperty("selectedItemCart")]
        public List<SelectedItems> SelectedItemCart { get; set; } = new List<SelectedItems>();
        [JsonProperty("totalSelectedItemCart")]
        public int TotalSelectedItemCart { get; set; }

        public Carts()
        {

        }

        public Carts(int cartId)
        {
            IdCart = cartId > 0 ? cartId : s_autoId++;
        }

        public Carts(int idCart, Customers customerCart, List<SelectedItems> selectedItemCart)
                     : this(idCart)
        {
            CustomerCart = customerCart;
            SelectedItemCart = selectedItemCart;
        }

        // Update Id của đối tượng nếu khi đang tạo hóa đơn mà tăng số lượng hoặc kết thúc phiên làm việc
        // Kết thúc ngày làm việc cũ -> update mã id_auto New -> Để không trùng lặp.
        // Bỏ đi đối tượng Item cũ -> Tạo ra đối tượng Item mới với id mới.
        public static void UpdateAutoId(int newValue)
        {
            s_autoId = newValue;
        }

        // Kiểm tra xem object Cart  theo id có tồn tại hay không?
        public override bool Equals(object obj)
        {
            return obj is Carts carts &&
                   IdCart == carts.IdCart;
        }

        public override int GetHashCode()
        {
            return 119797758 + IdCart.GetHashCode();
        }

        // So sánh 2 đối tượng Cart theo id
        public int CompareTo(Carts other)
        {
            return IdCart - other.IdCart;
        }
    }
}

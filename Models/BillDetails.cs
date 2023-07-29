using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models
{
    // Thực thể chi tiết hóa đơn
    // Association: 1 - 1 (Bills)
    public class BillDetails : Bills  , IComparable<BillDetails>
    {
        [JsonProperty("paymentMethodBillDetails")]
        public string PaymentMethodBillDetails { get; set; } = "";
        [JsonProperty("staffNameBillDetails")]
        public string StaffNameBillDetails { get; set; } = "";

        public BillDetails()
        {
            
        }

        public BillDetails(int id) : base(id) { }

        public BillDetails(string paymentMethodBillDetails, string staffNameBillDetails)
        {
            PaymentMethodBillDetails = paymentMethodBillDetails;
            StaffNameBillDetails = staffNameBillDetails;
        }

        public BillDetails(string paymentMethodBillDetails, string staffNameBillDetails,int idBill, Carts cartBill, DateTime createTimeBill,
                           int totalItemBill, long totalSubBill, long totalDiscountBill, long totalAmountBill, string statusBill)
                         : base(idBill, cartBill, createTimeBill, totalItemBill, totalSubBill, totalDiscountBill, totalAmountBill, statusBill)
        {
            PaymentMethodBillDetails = paymentMethodBillDetails;
            StaffNameBillDetails = staffNameBillDetails;
        }

        public int CompareTo(BillDetails other)
        {
            return IdBill - other.IdBill;
        }
        public override bool Equals(object obj)
        {
            return obj is BillDetails details &&
                   base.Equals(obj) &&
                   IdBill == details.IdBill;
        }

        public override int GetHashCode()
        {
            int hashCode = 1274942899;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + IdBill.GetHashCode();
            return hashCode;
        }

        public object[] ObjectToArray()
        {
            return new object[] {IdBill,CartBill.CustomerCart.FullNamePerson.ToString(),StaffNameBillDetails,CreateTimeBill.ToString("HH:mm:ss dd/MM/yyyy"),$"{TotalItemBill:N0}",$"{TotalSubBill:N0}",$"{TotalDiscountBill:N0}", $"{TotalAmountBill:N0}",StatusBill};
        }
    }
}

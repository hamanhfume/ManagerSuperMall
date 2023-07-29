using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StatisticCustomer : IComparable<StatisticCustomer>
    {
        private static int s_indexAuto = 1;
        public Customers Customer { get; set; }
        public long TotalAmount { get; set; }
        public StatisticCustomer()
        {
            
        }

        public StatisticCustomer(Customers customer, long totalAmount)
        {
            Customer = customer;
            TotalAmount = totalAmount;
        }

        // So sánh để sắp xếp giảm dần. -> other trước -> Giảm dần. ->  Ngược lại tăng dần this.
        public int CompareTo(StatisticCustomer other)
        {
           return other.TotalAmount.CompareTo(TotalAmount);
        }

        public object[] ArrayToObject()
        {
            return new object[] { s_indexAuto++, Customer?.FullNamePerson, $"{TotalAmount:N0}" };
        }
    }
}

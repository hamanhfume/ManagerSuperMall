using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StatisticRevenue : IComparable<StatisticRevenue>
    {
        private static int s_indexRevenue = 1;
        public long Revenue { get; set; }
        public DateTime Date { get; set; }
        public int TotalItem { get; set; }
        public long TotalDiscount { get; set; }
        public StatisticRevenue()
        {
            
        }

        public StatisticRevenue(long revenue, DateTime dateTime, int totalItem, long totalDiscount)
        {
            Revenue = revenue;
            Date = dateTime;
            TotalItem = totalItem;
            TotalDiscount = totalDiscount;
        }

        public int CompareTo(StatisticRevenue other)
        {
            return other.Revenue.CompareTo(Revenue);
        }

        public object[] ArrayToObjectDayTop()
        {
            return new object[] { s_indexRevenue++, Date.ToString("dddd dd/MM/yyyy"), TotalItem, $"{TotalDiscount:N0}", $"{Revenue:N0}"};
        }
        public object[] ArrayToObjectMonth()
        {
            return new object[] { s_indexRevenue++, Date.ToString("MM/yyyy"), TotalItem, $"{TotalDiscount:N0}", $"{Revenue:N0}" };
        }
        public object[] ArrayToObjectDay()
        {
            return new object[] { s_indexRevenue++, Date.ToString("dd/MM/yyyy"), TotalItem, $"{TotalDiscount:N0}", $"{Revenue:N0}" };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // Thực thể lưu thông tin thống kê.
    public class StatisticModel : IComparable<StatisticModel>
    {
        private static int s_indexAuto = 1;
        public SelectedItems Item { get; set; }
        public int TotalItem { get; set; }
        public long TotalRevenue { get; set; }

        public StatisticModel()
        {

        }

        public StatisticModel(SelectedItems item, int totalItem, long totalRevenue)
        {
            Item = item;
            TotalItem = totalItem;
            TotalRevenue = totalRevenue;
        }

        public int CompareTo(StatisticModel other)
        {
            return other.TotalRevenue.CompareTo(TotalRevenue);
        }

        public object[] ArrayToObject()
        {
            return new object[] { s_indexAuto++, Item.FullNameItem, TotalItem, $"{TotalRevenue:N0}" };
        }
    }
}

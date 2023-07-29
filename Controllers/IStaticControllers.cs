using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Controllers
{
    // Thống kê dữ liệu.
    public interface IStaticControllers
    {
        List<StatisticModel> FindBestSellItem(List<BillDetails> listBillDetail);
        List<StatisticCustomer> FindMostBounghtCustomer(List<BillDetails> listBillDetail, int numberOfCustomer, DateTime startTime, DateTime endTime);
        List<StatisticRevenue> FindBestSellDays(List<BillDetails> listBillDetail, string dateStr);
        List<StatisticRevenue> FindMonthlyRevenue(List<BillDetails> listBillDetail, string dateStr);
        List<StatisticRevenue> FindDaylyRevenue(List<BillDetails> listBillDetail, string dateStr);

    }
}

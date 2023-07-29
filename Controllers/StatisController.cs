using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class StatisController : IStaticControllers
    {
        public List<StatisticModel> FindBestSellDays(List<BillDetails> listBillDetail)
        {
            throw new NotImplementedException();
        }

        public List<StatisticModel> FindBestSellItem(List<BillDetails> listBillDetail)
        {
            List<StatisticModel> listResult = new List<StatisticModel>();
            foreach (BillDetails bill in listBillDetail)
            {
                if (bill.StatusBill.CompareTo("Finish payment") == 0)
                {
                    foreach (SelectedItems item in bill.CartBill.SelectedItemCart)
                    {
                        bool isExisted = false;
                        for (int i = 0; i < listResult.Count; i++)
                        {
                            if (item.Equals(listResult[i].Item))
                            {
                                listResult[i].TotalRevenue += item.NumberOfSelectedItem * item.PriceAfterDiscounts;
                                listResult[i].TotalItem += item.NumberOfSelectedItem;
                                isExisted = true;
                                break;
                            }
                        }
                        if (!isExisted)
                        {
                            var statisticModel = new StatisticModel(item, item.NumberOfSelectedItem,
                                                                    item.NumberOfSelectedItem * item.PriceAfterDiscounts);
                            listResult.Add(statisticModel);
                        }
                    }
                }
            }
            listResult.Sort();
            return listResult;
        }

        public List<StatisticCustomer> FindMostBounghtCustomer(List<BillDetails> listBillDetail, int numberOfCustomer, DateTime startTime, DateTime endTime)
        {
            List<StatisticCustomer> resultListStatisticCustomer = new List<StatisticCustomer>();
            foreach (BillDetails bill in listBillDetail)
            {
                //Nếu hóa đơn lập trong khoảng thời gian đagn xét.
                if (bill.StatusBill.CompareTo("Finish payment") == 0
                    && bill.CreateTimeBill >= startTime.Date
                    && bill.CreateTimeBill <= endTime.Date)
                {
                    bool isExisted = false;
                    //Tìm trong danh sách kết quả xem đã có khách hàng đang xét chưa.
                    for (int i = 0; i < resultListStatisticCustomer.Count; i++)
                    {
                        if (resultListStatisticCustomer[i].Customer.Equals(bill.CartBill?.CustomerCart))
                        {
                            resultListStatisticCustomer[i].TotalAmount += bill.TotalAmountBill;
                            isExisted = true;
                            break;
                        }
                    }
                    if (!isExisted)
                    {
                        resultListStatisticCustomer.Add(new StatisticCustomer(bill.CartBill?.CustomerCart, bill.TotalAmountBill));
                    }
                }
            }
            resultListStatisticCustomer.Sort();
            if (numberOfCustomer > resultListStatisticCustomer.Count)
            {
                numberOfCustomer = resultListStatisticCustomer.Count;
            }
            return resultListStatisticCustomer.GetRange(0, numberOfCustomer);
        }

        public List<StatisticRevenue> FindBestSellDays(List<BillDetails> listBillDetail, string dateStr)
        {
            List<StatisticRevenue> listResultRevenue = new List<StatisticRevenue>();
            string dateFormat = "dd/MM/yyyy";
            foreach (BillDetails bill in listBillDetail)
            {
                if (bill.StatusBill.CompareTo("Finish payment") == 0
                    && bill.CreateTimeBill.ToString("MM/yyyy").CompareTo(dateStr) == 0)
                {
                    bool istExisted = false;
                    for (int i = 0; i < listResultRevenue.Count; i++)
                    {
                        if (listResultRevenue[i].Date.ToString(dateFormat).CompareTo(bill.CreateTimeBill.ToString(dateFormat)) == 0)
                        {
                            listResultRevenue[i].Revenue += bill.TotalAmountBill;
                            listResultRevenue[i].TotalItem += bill.TotalItemBill;
                            listResultRevenue[i].TotalDiscount += bill.TotalDiscountBill;
                            istExisted = true;
                            break;
                        }
                    }
                    if (!istExisted)
                    {
                        listResultRevenue.Add(new StatisticRevenue(bill.TotalAmountBill, bill.CreateTimeBill, bill.TotalItemBill, bill.TotalDiscountBill));
                    }
                }
            }

            listResultRevenue.Sort();
            int k = 10;
            if(k > listResultRevenue.Count)
            {
                k = listResultRevenue.Count;
            }
            return listResultRevenue.GetRange(0,k);
        }

        public List<StatisticRevenue> FindMonthlyRevenue(List<BillDetails> listBillDetail, string dateStr)
        {
            string dateFormat = "MM/yyyy";
            List<StatisticRevenue> listResultRevenue = new List<StatisticRevenue>();
            foreach (BillDetails bill in listBillDetail)
            {
                if (bill.StatusBill.CompareTo("Finish payment") == 0
                    && bill.CreateTimeBill.ToString("yyyy").CompareTo(dateStr) == 0)
                {
                    bool istExisted = false;
                    for (int i = 0; i < listResultRevenue.Count; i++)
                    {
                        if (listResultRevenue[i].Date.ToString(dateFormat).CompareTo(bill.CreateTimeBill.ToString(dateFormat)) == 0)
                        {
                            listResultRevenue[i].Revenue += bill.TotalAmountBill;
                            listResultRevenue[i].TotalItem += bill.TotalItemBill;
                            listResultRevenue[i].TotalDiscount += bill.TotalDiscountBill;
                            istExisted = true;
                            break;
                        }
                    }
                    if (!istExisted)
                    {
                        listResultRevenue.Add(new StatisticRevenue(bill.TotalAmountBill, bill.CreateTimeBill, bill.TotalItemBill, bill.TotalDiscountBill));
                    }
                }
            }

            listResultRevenue.Sort();

            return listResultRevenue;
        }

        public List<StatisticRevenue> FindDaylyRevenue(List<BillDetails> listBillDetail, string dateStr)
        {
            string dateFormat = "dd/MM/yyyy";
            List<StatisticRevenue> listResultRevenue = new List<StatisticRevenue>();
            foreach (BillDetails bill in listBillDetail)
            {
                if (bill.StatusBill.CompareTo("Finish payment") == 0
                    && bill.CreateTimeBill.ToString("MM/yyyy").CompareTo(dateStr) == 0)
                {
                    bool istExisted = false;
                    for (int i = 0; i < listResultRevenue.Count; i++)
                    {
                        if (listResultRevenue[i].Date.ToString(dateFormat).CompareTo(bill.CreateTimeBill.ToString(dateFormat)) == 0)
                        {
                            listResultRevenue[i].Revenue += bill.TotalAmountBill;
                            listResultRevenue[i].TotalItem += bill.TotalItemBill;
                            listResultRevenue[i].TotalDiscount += bill.TotalDiscountBill;
                            istExisted = true;
                            break;
                        }
                    }
                    if (!istExisted)
                    {
                        listResultRevenue.Add(new StatisticRevenue(bill.TotalAmountBill, bill.CreateTimeBill, bill.TotalItemBill, bill.TotalDiscountBill));
                    }
                }
            }

            listResultRevenue.Sort();
            return listResultRevenue;
        }

        
    }
}

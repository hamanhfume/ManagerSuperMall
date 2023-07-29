using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    // Read, Writer Data
    public interface IIOControllers
    {
        void WriteDataJson(object obj, string fileName);
        List<T> ReadDataJson<T>(string fileName, string root);
        void LoadDataListJson(List<Items> listItems, List<Customers> listCustomers, 
                              List<Discounts> listDiscounts, List<BillDetails> listBillDetails);
        bool SaveDataListJson(List<Items> listItems, List<Customers> listCustomers, 
                              List<Discounts> listDiscounts, List<BillDetails> listBillDetails);
    }
}

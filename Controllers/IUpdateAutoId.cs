using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Controllers
{
    public interface IUpdateAutoId 
    {
        void UpdateItemsAutoId(List<Items> listItems);
        void UpdateDiscountsAutoId(List<Discounts> listDiscount);
        void UpdateBillDetailsAutoId(List<BillDetails> listBillDetails);
    }
}

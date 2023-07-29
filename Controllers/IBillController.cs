using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public interface IBillController
    {
        //Method: Update Bill->BillDetail
        void UpdateBillBillDetail(BillDetails billDetails,SelectedItems itemSelected);
        void RemoveBillBillDetail(BillDetails billDetails, SelectedItems itemSelected);
        bool IsExistedSelectedItemInBillDetail(BillDetails billDetails, SelectedItems itemSelected);
        void UpdateQuantityBillDetailItemsStock(BillDetails billDetail, List<Items> item);
    }
}

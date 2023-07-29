using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    // Enum -> Thực hiện theo dõi trạng thái: Data ở dataGridView là Normal or Search
    // Phân quyền với Enum -> Search -> CRUD ListSearch(dataGridView + ListSearch) ListRoot(only ListRoot)
    //                       / Normal -> ListRoot (dataGridView + ListRoot).
    // Theo dõi và phân quyền hành động -> Luồng đi cho từng đối tượng.
    public enum AcctionType
    {
        NORMAL, SEARCH
    }

    public enum AcctionTypeCustomer
    {
        NORMAL, SEARCH
    }

    public enum AcctionTypeDiscount
    {
        NORMAL, SEARCH  
    }

    public enum AcctionTypeBillDetail
    {
        NORMAL, SEARCH
    }
}

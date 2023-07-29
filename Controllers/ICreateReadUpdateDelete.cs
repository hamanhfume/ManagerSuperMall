using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Controllers
{
    public interface ICreateReadUpdateDelete
    {
        void SelectAllItems<T>(List<T> items);
        void CreateItems<T>(T item);
        void UpdateItems<T>(T item);
        void DeleteItems<T>(List<T> listItems,T item);    
    }
}

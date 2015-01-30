using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoCheck.ViewModels
{
    public class DataBaseContext : DataContext
    {
        public DataBaseContext(string connectionString)
            : base(connectionString)
        {

        }

        public Table<ItemViewModel> Item;

    }
}

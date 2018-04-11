using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.ViewModels.jQuery.DataTables
{
    public class DataTableAjaxPostModel
    {
        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<DataTableColumnModel> columns { get; set; }
        public DataTableSearchModel search { get; set; }
        public List<DataTableOrderModel> order { get; set; }
    }
}
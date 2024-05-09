using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemCS.database
{
    public class DataTypesUtils
    {
        public static List<string> DataTableToString(DataTable dt)
        { 
            List<string> list = new List<string>();
            string result = "";
            foreach (DataRow dr in dt.Rows)
            {
                foreach (var value in dr.ItemArray)
                {
                    result += value.ToString() + " "; // You can adjust the separator as needed
                }
                result.Trim();
                list.Add(result.Substring(2));
            }
            return list;
        }
    }
}

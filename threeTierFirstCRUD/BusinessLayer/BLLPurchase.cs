using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BLLPurchase
    {
        public int Purchased( string invoiceno, int productid, int categoryid, int quantity, decimal total)
        {
            string sql = "insert into tbl_Purchase values(@a,@b,@c,@d,@e)";

            SqlParameter[] param = new SqlParameter[] {
            
          
            new SqlParameter("@a", invoiceno),
            new SqlParameter("@b",productid ),
            new SqlParameter("@c", categoryid),
            new SqlParameter("@d", quantity),
            new SqlParameter("@e", total)
            
            
            };

            return DAO.IDU(sql, param, CommandType.Text);
        }
    }
}

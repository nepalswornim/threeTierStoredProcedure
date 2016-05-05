using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BLLInvoice
    {
        public DataTable GetMaxInvoice()
        {
            string sql = "select top 1* from tbl_Invoice order by Invoice_No desc";
            return DAO.SelectUser(sql, null, CommandType.Text);
        }
        public int CreateInvoice(string invoiceno, DateTime date, int customerid, decimal total)
        {
            string sql = "INSERT into tbl_Invoice values(@a,@b,@c,@d)";
            SqlParameter[] param = new SqlParameter[] { 
           new  SqlParameter("@a", invoiceno),

           new  SqlParameter("@b", date),
           new  SqlParameter("@c", customerid),

           new  SqlParameter("@d", total)
           
           };
            return DAO.IDU(sql, param, CommandType.Text);


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BLLCustomer
    {

        public DataTable GetAllCustomer()
        {

            string sql = "select* from tbl_Customer";
            return DAO.SelectUser(sql, null, CommandType.Text);
        }
    }
}

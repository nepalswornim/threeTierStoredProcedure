using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;
using System.Data.SqlClient;


namespace BusinessLayer
{
   public class BLLCategory
    {
       public DataTable GetAllCategory() {
           string sql = "select* from tbl_Category";

           return DAO.SelectUser(sql, null,CommandType.Text);
           
           
       }
       public DataTable SearchCategorybyCategoryId(int catid) {
           string sql = "select* from tbl_Category where CategoryId=@a ";
           SqlParameter[] param = new SqlParameter[] {
           new SqlParameter("@a",catid)
           };

           return DAO.SelectUser(sql, param,CommandType.Text);
       }
    }
    

}

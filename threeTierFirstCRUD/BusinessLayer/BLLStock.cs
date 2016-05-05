using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLayer
{
  public  class BLLStock
    {
      public DataTable GetStockByProductId(int productid) {

          string sql = "select* from tbl_Stock where ProductId=@a";
          SqlParameter[] param = new SqlParameter[] {
          new SqlParameter("@a", productid)
          };
          return DAO.SelectUser(sql, param, CommandType.Text);
      
      
      }
      public int UpdateStockbyProductId(int productid, int quantity) {
          string sql = "update tbl_Stock set Quantity=@a where ProductId=@b";
          SqlParameter[] param = new SqlParameter[] {
              
              new SqlParameter("@a", quantity),
              new SqlParameter("@b", productid)
          };





          return DAO.IDU(sql, param, CommandType.Text);
      }
      public int InsertStock(int productid, int quantity)
      {
          string sql = "insert into tbl_Stock values(@a,@b)";
          SqlParameter[] param = new SqlParameter[] {
              
             new SqlParameter("@a", productid) ,
              new SqlParameter("@b", quantity)
          };





          return DAO.IDU(sql, param, CommandType.Text);
      }
    }
}

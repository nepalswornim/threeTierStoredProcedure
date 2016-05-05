using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
   public class BLLProduct
    {
       public int CreateProduct(int categoryid,string productname,decimal unitprice,int quantity ) {
           string sql = "insert into tbl_Product values( @a,@b,@c,@d)";
           SqlParameter[] param = new SqlParameter[] {
           new SqlParameter("@a",categoryid),
           new SqlParameter("@b", productname),
           new SqlParameter("@c", unitprice),
           new SqlParameter("@d",quantity)
           

           };
           int i = DAO.IDU(sql, param, CommandType.Text);
      return i; 
       
       }
       public DataTable GetAllProduct() {
           string sql = "SELECT        tbl_Product.ProductId, tbl_Category.CategoryId, tbl_Category.CategoryName, tbl_Product.ProductName, tbl_Product.UnitPrice, tbl_Product.Quantity FROM tbl_Category INNER JOIN tbl_Product ON tbl_Category.CategoryId = tbl_Product.CategoryId";
           return DAO.SelectUser(sql, null, CommandType.Text);
       }
       public DataTable GetProductbyProductID(int productid) {
           string sql = "select * from tbl_Product where ProductId=@productid";
           SqlParameter[] param = new SqlParameter[] { 
           new SqlParameter("@productid",productid)
          
           
           
           };
           return DAO.SelectUser(sql, param, CommandType.Text);

       
       }
       public DataTable GetProductbyCategoryID(int categoryid)
       {
           string sql = "select * from tbl_Product where CategoryId=@categoryid";
           SqlParameter[] param = new SqlParameter[] { 
           new SqlParameter("@categoryid",categoryid)
          
           
           
           };
           return DAO.SelectUser(sql, param, CommandType.Text);


       }
      
      
       
       
    }
}

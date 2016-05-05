using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLayer
{
    public class BLLUser
    {
        public int createUser(string name, string email, string usertype)
            {
            string sql = "CreateUser";
            SqlParameter[] param = new SqlParameter[]{
           new SqlParameter("@username",name),
           new SqlParameter("@email",email),
           new SqlParameter("@usertype",usertype)


       };
            int i = DAO.IDU(sql, param, CommandType.StoredProcedure);
            return i;
        }


        public int updateUser(string name, string email, string usertype, int id)
        {
            string sql = "update tbl_User set Name=@a, Email=@b, Usertype=@c where Id=@d ";
            SqlParameter[] param = new SqlParameter[]{
           new SqlParameter("@a",name),
           new SqlParameter("@b",email),
           new SqlParameter("@c",usertype),
           new SqlParameter("@d",id)
           };
            int i = DAO.IDU(sql, param, CommandType.Text);
            return i;
        }
        public int deleteUser(int id)
        {
            string sql = "delete from tbl_User where Id=@id";
            SqlParameter[] param = new SqlParameter[] { 
            new SqlParameter("@id",id)
            
            
            };
            return DAO.IDU(sql, param, CommandType.Text);


        }
        public DataTable GetAllUser() {
            string sql = "SelectUser";
            
            DataTable dt = DAO.SelectUser(sql, null, CommandType.StoredProcedure);
            return dt;


        
        }
        public DataTable CheckAvailability(string name)
        {
            string sql = "select* from tbl_User where Name=@a";
           
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@a",name)
            };
            DataTable dt = DAO.SelectUser(sql, param,CommandType.Text);
          
            return dt;



        }
        public DataTable CheckUserLogin(string name,string email,string usertype)
        {
            string sql = "select* from tbl_User where Name=@a and Email=@b and Usertype=@c";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@a",name),
                new SqlParameter("@b", email),
                new SqlParameter("@c",usertype)
            };
            DataTable dt = DAO.SelectUser(sql, param, CommandType.Text);
            return dt;



        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace threeTierFirstCRUD
{
    public partial class EditUser : Form
    {
        BLLUser bll = new BLLUser();
        Form1 frm = new Form1();
       
        public EditUser()
        {
            InitializeComponent();
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
           
        {
            woo = lblID.Text.ToString();
            int too = Convert.ToInt32(woo);
            
            int i = bll.updateUser(txtName.Text, txtEmail.Text,txtUsertype.Text,too);

            if (i > 0)
            {
               
                MessageBox.Show(" Updated Successfully");
                this.Hide();
                frm.Show();
               frm.Clear();
                frm.LoadGrid();
           
           
           
               

            }

        }

        

        string woo = "";
       
        public void EditUser_Load(object sender, EventArgs e)

        {
           
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            woo = lblID.Text.ToString();
            int too = Convert.ToInt32(woo);
            int i = bll.deleteUser(too);
            if (i>0)
            {
                MessageBox.Show("Deleted Successfully");
                this.Hide();
                frm.Show();
            }
        }

       
    }
}

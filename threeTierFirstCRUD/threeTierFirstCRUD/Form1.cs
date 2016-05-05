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
    
    public partial class Form1 : Form
    {
        BLLUser bll = new BLLUser();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGrid();
            btnDelete.Visible = false;
        }

        public void LoadGrid()
        {
            dataGridView1.DataSource = bll.GetAllUser();

        }


        int id = 0;
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text != "Update")
            {
                DataTable dt = new DataTable();
                dt = bll.CheckAvailability(txtName.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("User already exists");
                    Clear();
                }
                else
                {
                    int i = bll.createUser(txtName.Text, txtEmail.Text, txtUsertype.Text);

                    if (i > 0)
                    {
                       
                        MessageBox.Show(" Inserted Successfully");
                         
                        Clear();
                        LoadGrid();


                    }

                 
                }
            }
            else {

               
                //if (i > 0)
                //{
                //    MessageBox.Show("Updated Successfully");
                //    Clear();
                //    LoadGrid();
                //}
                //else {
                //    MessageBox.Show("Exception occured");
                //}

            
            }
        }

        public void Clear()
        {
            txtUsertype.Clear();
            txtEmail.Clear();
            txtName.Clear();
            LoadGrid();
            btnSubmit.Text = "Submit";
            btnDelete.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
      

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditUser eu = new EditUser();
            eu.Show();
            this.Hide();
            eu.lblID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
           eu.txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            eu.txtEmail.Text=dataGridView1.CurrentRow.Cells[2].Value.ToString();
            eu.txtUsertype.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            LoadGrid();

           
           


        }

        private void btnDelete_Click(object sender, EventArgs e)
            {
            int i = bll.deleteUser(id);
            if (i>0)
            {
                MessageBox.Show("deleted Successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("error occured");
            }
        }
    }
}

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
    public partial class AddProduct : Form
    {
        BLLCategory blc = new BLLCategory();
        BLLProduct blb = new BLLProduct();
        public AddProduct()
        {
            InitializeComponent();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadGrid();
           

        }

        private void LoadGrid()
        {
            DataTable dt = blb.GetAllProduct();
           
            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    
                    dataGridView1.Rows[i].Cells["colProductId"].Value = dt.Rows[i]["ProductId"].ToString();
                    dataGridView1.Rows[i].Cells["ColCategoryID"].Value = dt.Rows[i]["CategoryID"].ToString();
                    dataGridView1.Rows[i].Cells["ColCategoryName"].Value = dt.Rows[i]["CategoryName"].ToString();
                    dataGridView1.Rows[i].Cells["colProductName"].Value = dt.Rows[i]["ProductName"].ToString();
                    dataGridView1.Rows[i].Cells["colUnitPrice"].Value = dt.Rows[i]["UnitPrice"].ToString();
                    dataGridView1.Rows[i].Cells["colQuantity"].Value = dt.Rows[i]["Quantity"].ToString();
                    dataGridView1.Rows[i].Cells["colSN"].Value = i + 1;
                    
                }
            }
        }

        private void LoadCategory()
        {
            DataTable dt = blc.GetAllCategory();
            cboCategory.DataSource = dt;
            cboCategory.ValueMember = "CategoryId";
            cboCategory.DisplayMember = "CategoryName";
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
          int i=   blb.CreateProduct(Convert.ToInt32( cboCategory.SelectedValue.ToString()), txtProductName.Text, Convert.ToDecimal(txtUnitprice.Text), Convert.ToInt32(txtQuantity.Text));
          if (i>0)
          {
              MessageBox.Show("Inserted Successfully");
              LoadGrid();
          }
        }
        int productid = 0;

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int categoryid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colCategoryId"].Value.ToString());
            cboCategory.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells["colCategoryId"].Value.ToString());
            //txtProductName.Text = dataGridView1.CurrentRow.Cells["colProductName"].Value.ToString();
            // txtUnitprice.Text = dataGridView1.CurrentRow.Cells["colUnitPrice"].Value.ToString();
            // txtQuantity.Text = dataGridView1.CurrentRow.Cells["colQuantity"].Value.ToString();

             productid =Convert.ToInt32( dataGridView1.CurrentRow.Cells["colProductId"].Value.ToString());
            DataTable dt = blb.GetProductbyProductID(productid);
            txtProductName.Text = dt.Rows[0]["ProductName"].ToString();
            txtUnitprice.Text = dt.Rows[0]["UnitPrice"].ToString();
            txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();

        }

        private void txtUnitprice_TextChanged(object sender, EventArgs e)
        {
            txtDubli.Text = txtUnitprice.Text;
      
        }

        private void txtDubli_TextChanged(object sender, EventArgs e)
        {
           
      
        }
    }
}

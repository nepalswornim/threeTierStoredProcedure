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
    public partial class AddingRowsToGridview : Form
    {
        BLLProduct blp = new BLLProduct();
        BLLInvoice bli = new BLLInvoice();
        BLLCategory blc = new BLLCategory();
        BLLCustomer blcu = new BLLCustomer();
        BLLPurchase blpur = new BLLPurchase();
        BLLStock blsto = new BLLStock();
        public AddingRowsToGridview()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(txtProductCode.Text);

            }
            catch (Exception)
            {
                if (txtProductCode.Text != "")
                {
                    MessageBox.Show("This is a Number Field");
                    txtProductCode.Clear();

                }
                else
                {

                    txtProductCode.ToString();
                }


            }
            finally
            {

                txtProductCode.ToString();
            }









        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "")
            {

                txtTotal.Text = (Convert.ToDecimal(txtUnitPrice.Text) * Convert.ToDecimal(txtQuantity.Text)).ToString();


            }
            else
            {
                txtTotal.Clear();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        int category = 0;
        private void txtProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtProductCode.Text.Length > 0)
                {

                    DataTable dt = blp.GetProductbyProductID(Convert.ToInt32(txtProductCode.Text));
                    if (dt.Rows.Count != 0)
                    {

                        txtProductName.Text = dt.Rows[0]["ProductName"].ToString();
                        category = Convert.ToInt32(dt.Rows[0]["CategoryId"].ToString());
                        txtUnitPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                        txtQuantity.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Product Id does not exist");
                        txtProductCode.Clear();
                    }

                }

                //int i = Convert.ToInt32(txtProductCode.Text);
                //for ( i = 0; i < 3; i++)
                //{


                //}



            }

        }
        int i = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "")
            {
                if (cboCategory.Text != "Choose Category")
                {


                    // GrandTotal = Convert.ToDecimal(txtTotal.Text);
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["colProductCode"].Value = txtProductCode.Text;
                    dataGridView1.Rows[i].Cells["colCategoryId"].Value = cboCategory.SelectedValue;
                    dataGridView1.Rows[i].Cells["colCategoryName"].Value = cboCategory.Text;
                    dataGridView1.Rows[i].Cells["colProductName"].Value = txtProductName.Text;
                    dataGridView1.Rows[i].Cells["colUnitPrice"].Value = txtUnitPrice.Text;
                    dataGridView1.Rows[i].Cells["colQuantity"].Value = txtQuantity.Text;
                    dataGridView1.Rows[i].Cells["colTotal"].Value = txtTotal.Text;
                    dataGridView1.Rows[i].Cells["colSN"].Value = i + 1;
                    i++;
                    decimal GrandTotal = 0M;
                    for (int k = 0; k < dataGridView1.Rows.Count; k++)
                    {
                        GrandTotal += Convert.ToDecimal(dataGridView1.Rows[k].Cells["colTotal"].Value);
                        txtGrandTotal.Text = GrandTotal.ToString();
                    }

                    Clear();
                    //decimal f = Convert.ToDecimal(txtGrandTotal.Text);
                    //txtGrandTotal.Text = (f + GrandTotal).ToString();
                }
                else
                {
                    DataTable dt = blc.SearchCategorybyCategoryId(category);
                    // GrandTotal = Convert.ToDecimal(txtTotal.Text);
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["colProductCode"].Value = txtProductCode.Text;
                    dataGridView1.Rows[i].Cells["colCategoryId"].Value = dt.Rows[0]["CategoryId"].ToString();
                    dataGridView1.Rows[i].Cells["colCategoryName"].Value = dt.Rows[0]["CategoryName"].ToString();
                    dataGridView1.Rows[i].Cells["colProductName"].Value = txtProductName.Text;
                    dataGridView1.Rows[i].Cells["colUnitPrice"].Value = txtUnitPrice.Text;
                    dataGridView1.Rows[i].Cells["colQuantity"].Value = txtQuantity.Text;
                    dataGridView1.Rows[i].Cells["colTotal"].Value = txtTotal.Text;
                    dataGridView1.Rows[i].Cells["colSN"].Value = i + 1;
                    i++;
                    decimal GrandTotal = 0M;
                    for (int k = 0; k < dataGridView1.Rows.Count; k++)
                    {
                        GrandTotal += Convert.ToDecimal(dataGridView1.Rows[k].Cells["colTotal"].Value);
                        txtGrandTotal.Text = GrandTotal.ToString();
                    }

                    Clear();
                    //decimal f = Convert.ToDecimal(txtGrandTotal.Text);
                    //txtGrandTotal.Text = (f + GrandTotal).ToString();
                }
            }
            else
            {
                MessageBox.Show("Quantity cant be empty");
                Clear();
                txtProductCode.Focus();
            }


        }


        private void Clear()
        {
            txtProductCode.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            txtTotal.Clear();
            txtProductCode.Focus();
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.Select();


            }
        }
        public void LoadCategory()
        {
            DataTable dt = blc.GetAllCategory();
            DataRow dr = dt.NewRow();
            dr["CategoryName"] = "Choose Category";
            dt.Rows.InsertAt(dr, 0);
            cboCategory.DataSource = dt;
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryId";


        }

        public void LoadCustomer()
        {
            DataTable dt = blcu.GetAllCustomer();
            if (dt.Rows.Count > 0)
            {


                DataRow dr = dt.NewRow();
                dr["CustomerName"] = "Choose Customer";
                dt.Rows.InsertAt(dr, 0);
                cboCustomer.DataSource = dt;
                cboCustomer.DisplayMember = "CustomerName";
                cboCustomer.ValueMember = "CustomerID";

            }
        }
        private void AddingRowsToGridview_Load(object sender, EventArgs e)
        {
            LoadCustomer();
            LoadCategory();


            lblUsername.Text = "User: " + Program.Username;
            txtDate.Text = DateTime.Today.ToShortDateString();
            DataTable dt = bli.GetMaxInvoice();
            if (dt.Rows.Count > 0)
            {
                string str = dt.Rows[0]["Invoice_No"].ToString();
                string[] starr = str.Split('-');

                //string sleft = starr[0].ToString();
                string sright = starr[1].ToString();
                int i = Convert.ToInt32(sright);
                i++;

                txtInvoiceNumber.Text = "INV-" + i.ToString();


            }
            else
            {
                txtInvoiceNumber.Text = "INV-1";
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex != 0)
            {
                DataTable dt = blp.GetProductbyCategoryID(Convert.ToInt32(cboCategory.SelectedValue));

                DataRow dr = dt.NewRow();
                dr["ProductName"] = "Choose Product";
                dt.Rows.InsertAt(dr, 0);
                cboProduct.DataSource = dt;
                cboProduct.DisplayMember = "ProductName";
                cboProduct.ValueMember = "ProductId";
                cboProduct.Select();
            }

        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex != 0)
            {
                DataTable dt = blp.GetProductbyProductID(Convert.ToInt32(cboProduct.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    txtProductCode.Text = dt.Rows[0]["ProductId"].ToString();
                    txtProductName.Text = dt.Rows[0]["ProductName"].ToString();
                    txtUnitPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                }

            }
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboCustomer.Text != "Choose Customer")
            {


                int p = bli.CreateInvoice(txtInvoiceNumber.Text, Convert.ToDateTime(txtDate.Text), Convert.ToInt32(cboCustomer.SelectedValue.ToString()), Convert.ToDecimal(txtGrandTotal.Text));

                if (p > 0)
                {


                    int k = 0;
                    try
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {


                            DataTable dt = blsto.GetStockByProductId(Convert.ToInt32(dataGridView1.Rows[i].Cells["colProductCode"].Value));
                            if (dt.Rows.Count > 0)
                            {//update stock

                                int previousquantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                                int newquantity = Convert.ToInt32(dataGridView1.Rows[i].Cells["colQuantity"].Value);
                                blsto.UpdateStockbyProductId(Convert.ToInt32(dataGridView1.Rows[i].Cells["colProductCode"].Value), previousquantity + newquantity);

                            }
                            else
                            {//insert stock
                                blsto.InsertStock(Convert.ToInt32(dataGridView1.Rows[i].Cells["colProductCode"].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells["colQuantity"].Value));

                            }
                            k += blpur.Purchased(txtInvoiceNumber.Text, Convert.ToInt32(dataGridView1.Rows[i].Cells["colProductCode"].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells["colCategoryId"].Value), Convert.ToInt32(dataGridView1.Rows[i].Cells["colQuantity"].Value), Convert.ToDecimal(txtGrandTotal.Text));

                        }

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                    finally
                    {
                        if (k > 0)
                        {
                            MessageBox.Show("Purchased " + k.ToString() + " items successfully.");
                            Clear();
                            Delete();
                        }

                    }

                }
            }
               
            else{ 
 cboCustomer.Focus();
MessageBox.Show("Select a customer"); 
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
           

        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                txtGrandTotal.Text = (Convert.ToDecimal(txtGrandTotal.Text) - Convert.ToDecimal(dr.Cells["colTotal"].Value)).ToString();
                dataGridView1.Rows.Remove(dr);
           
            }
            
        }

        private void Delete()
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                txtGrandTotal.Text = "";
                dataGridView1.Rows.Remove(dr);

            }
        }
    }
}

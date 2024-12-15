using SuperMarket.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket.Screens.Products
{

    public partial class Product : Form
    {
        SupermarketEntities db = new SupermarketEntities();

        public Product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtName.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("برجاء إكمال البيانات المطلوبة");
            }
            else { 
            SuperMarket.DB.Product prd = new SuperMarket.DB.Product();
               prd.Name = txtName.Text;
               prd.Code = txtCode.Text;
               prd.Notes = txtNotes.Text;

                int qty;
                decimal price;

                decimal.TryParse(txtPrice.Text, out price);
                int.TryParse(txtQuantity.Text, out qty);

                prd.Price = price;
                prd.Quantity = qty;

                db.Products.Add(prd);
                db.SaveChanges();
                MessageBox.Show("تم إضافة المنتج بنجاح");
                txtCode.Text = "";
                txtName.Text = "";
                txtNotes.Text = "";
                txtPrice.Text = "";
                txtQuantity.Text = "";
            }
        }
    }
}

using SuperMarket.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket.Screens.Products
{
    public partial class ProductEdit : Form
    {
        SupermarketEntities db = new SupermarketEntities();
        int id;
        public ProductEdit()
        {
            InitializeComponent();
            dGrid.DataSource = db.Products.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dGrid.DataSource = db.Products.Where(x => x.Name.Contains(txtName.Text)).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dGrid.DataSource = db.Products.ToList();
        }

        private void dGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(dGrid.CurrentRow.Cells[0].Value.ToString());
                var result = db.Products.SingleOrDefault(x => x.ID == id);

                txtCode.Text = result.Code;
                txtfName.Text = result.Name;
                txtNotes.Text = result.Notes;
                txtPrice.Text = result.Price.ToString();
                txtQuantity.Text = result.Quantity.ToString();
            }
            catch { }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            var result = db.Products.SingleOrDefault(x => x.ID == id);
            result.Name = txtfName.Text;
            result.Notes = txtNotes.Text;
            result.Code = txtCode.Text;
            result.Price = decimal.Parse(txtPrice.Text);
            result.Quantity = int.Parse(txtQuantity.Text);

            db.SaveChanges();

            MessageBox.Show("تم تعديل المنتج بنجاح");
            dGrid.DataSource = db.Products.ToList();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد حذف هذا المنتج؟", "تأكيد حذف المنتج", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            { 
            var result = db.Products.SingleOrDefault(x => x.ID == id);
            db.Products.Remove(result);
            db.SaveChanges();
            MessageBox.Show("تم حذف المنتج بنجاح");
            dGrid.DataSource = db.Products.ToList();
            }
        }
    }
}

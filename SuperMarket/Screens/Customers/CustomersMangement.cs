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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;

namespace SuperMarket.Screens.Customers
{
    public partial class CustomersMangement : Form
    {
        SupermarketEntities db = new SupermarketEntities();

        public CustomersMangement()
        {
            InitializeComponent();
            dGrid.DataSource = db.Customers.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dGrid.DataSource = db.Customers.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textName.Text == "")
            {
                dGrid.DataSource = db.Customers.Where(x => x.Phone.Contains(txtPhone.Text)).ToList();

            }
            else if (txtPhone.Text == "")
            {
                dGrid.DataSource = db.Customers.Where(x => x.Name.Contains(textName.Text)).ToList();

            }
            else
            {
                dGrid.DataSource = db.Customers.Where(x => x.Phone.Contains(txtPhone.Text) || x.Name.Contains(textName.Text)).ToList();

            }
        }
        private void button6_Click(object sender, EventArgs e)
        {

            if (txtfName.Text == "" || txtfPhone.Text == "")
            {
                MessageBox.Show("برجاء إكمال البيانات المطلوبة");
            }
            else
            {
                SuperMarket.DB.Customer cus = new SuperMarket.DB.Customer();
                cus.Name = txtfName.Text;
                cus.Phone = txtfPhone.Text;
                cus.Notes = txtfNotes.Text;
                cus.Email = txtfEmail.Text;
                cus.Address = txtfADD.Text;



                db.Customers.Add(cus);
                db.SaveChanges();
                MessageBox.Show("تم إضافة العميل بنجاح");
                txtfName.Text = "";
                txtfPhone.Text = "";
                txtfNotes.Text = "";
                txtfEmail.Text = "";
                txtfADD.Text = "";
                dGrid.DataSource = db.Customers.ToList();

            }
        }

        private void dGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dGrid.CurrentRow.Cells[0].Value.ToString());
                var result = db.Customers.SingleOrDefault(x => x.ID == id);

                txtfName.Text = result.Name;
                txtfPhone.Text = result.Phone;
                txtfEmail.Text = result.Email;
                txtfNotes.Text = result.Notes;
                txtfADD.Text = result.Address;
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dGrid.CurrentRow.Cells[0].Value.ToString());
            var result = db.Customers.SingleOrDefault(x => x.ID == id);
            result.Name = txtfName.Text;
            result.Phone = txtfPhone.Text;
            result.Email = txtfEmail.Text;
            result.Notes = txtfNotes.Text;
            result.Address = txtfADD.Text;

            db.SaveChanges();

            MessageBox.Show("تم تعديل العميل بنجاح");
            dGrid.DataSource = db.Customers.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد حذف هذا العميل؟", "تأكيد حذف العميل", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                int id = int.Parse(dGrid.CurrentRow.Cells[0].Value.ToString());
                var result = db.Customers.SingleOrDefault(x => x.ID == id);
                db.Customers.Remove(result);
                db.SaveChanges();
                MessageBox.Show("تم حذف العميل بنجاح");
                dGrid.DataSource = db.Customers.ToList();
            }
        }
    }
}

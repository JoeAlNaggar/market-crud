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

namespace SuperMarket.Screens.Suppliers
{
    public partial class SupplyMangement : Form
    {
        SupermarketEntities db = new SupermarketEntities();
        public SupplyMangement()
        {
            InitializeComponent();
            dGrid.DataSource = db.Suppliers.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dGrid.DataSource = db.Suppliers.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textName.Text == "")
            {
                dGrid.DataSource = db.Suppliers.Where(x => x.Phone.Contains(txtPhone.Text)).ToList();

            }
            else if (txtPhone.Text == "")
            {
                dGrid.DataSource = db.Suppliers.Where(x => x.Name.Contains(textName.Text)).ToList();

            }
            else
            {
                dGrid.DataSource = db.Suppliers.Where(x => x.Phone.Contains(txtPhone.Text) || x.Name.Contains(textName.Text)).ToList();

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
                SuperMarket.DB.Supplier cus = new SuperMarket.DB.Supplier();
                cus.Name = txtfName.Text;
                cus.Phone = txtfPhone.Text;
                cus.Notes = txtfNotes.Text;
                cus.Email = txtfEmail.Text;
                cus.Address = txtfADD.Text;
                cus.Company = txtCompany.Text;



                db.Suppliers.Add(cus);
                db.SaveChanges();
                MessageBox.Show("تم إضافة المورد بنجاح");
                txtfName.Text = "";
                txtfPhone.Text = "";
                txtfNotes.Text = "";
                txtfEmail.Text = "";
                txtfADD.Text = "";
                txtCompany.Text = "";

                dGrid.DataSource = db.Suppliers.ToList();

            }
        }

        private void dGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dGrid.CurrentRow.Cells[0].Value.ToString());
                var result = db.Suppliers.SingleOrDefault(x => x.ID == id);

                txtfName.Text = result.Name;
                txtfPhone.Text = result.Phone;
                txtfEmail.Text = result.Email;
                txtfNotes.Text = result.Notes;
                txtfADD.Text = result.Address;
                txtCompany.Text = result.Company;
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dGrid.CurrentRow.Cells[0].Value.ToString());
            var result = db.Suppliers.SingleOrDefault(x => x.ID == id);
            result.Name = txtfName.Text;
            result.Phone = txtfPhone.Text;
            result.Email = txtfEmail.Text;
            result.Notes = txtfNotes.Text;
            result.Address = txtfADD.Text;
            result.Company = txtCompany.Text;


            db.SaveChanges();

            MessageBox.Show("تم تعديل المورد بنجاح");
            dGrid.DataSource = db.Suppliers.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد حذف هذا المورد؟", "تأكيد حذف المورد", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                int id = int.Parse(dGrid.CurrentRow.Cells[0].Value.ToString());
                var result = db.Suppliers.SingleOrDefault(x => x.ID == id);
                db.Suppliers.Remove(result);
                db.SaveChanges();
                MessageBox.Show("تم حذف المورد بنجاح");
                dGrid.DataSource = db.Suppliers.ToList();
            }
        }
    }
}

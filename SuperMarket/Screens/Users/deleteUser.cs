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

namespace SuperMarket.Screens.Users
{
   
    public partial class deleteUser : Form
    {
        SupermarketEntities db = new SupermarketEntities();
        public deleteUser()
        {
            InitializeComponent();
            dGrid.DataSource = db.Users.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dGrid.DataSource = db.Users.Where(x => x.UserName.Contains(txtName.Text)).ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dGrid.DataSource = db.Users.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dGrid.CurrentRow.Cells[0].Value.ToString());
            var r = MessageBox.Show("هل تريد حذف هذا المستخدم؟", "تأكيد حذف المستخدم", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                var result = db.Users.SingleOrDefault(x => x.ID == id);
                db.Users.Remove(result);
                db.SaveChanges();
                MessageBox.Show("تم حذف المستخدم بنجاح");
                dGrid.DataSource = db.Users.ToList();
            }
        }

        private void dGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dGrid.CurrentRow.Cells[0].Value.ToString());
                var result = db.Products.SingleOrDefault(x => x.ID == id);
            }
            catch { }

            }
    }
}

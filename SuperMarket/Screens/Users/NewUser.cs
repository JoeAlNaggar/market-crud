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
    public partial class NewUser : Form
    {
        SupermarketEntities db = new SupermarketEntities();
        public NewUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User obj = new User();
            obj.UserName = txtUser.Text;
            obj.Password = txtPass.Text;
            db.Users.Add(obj);
            db.SaveChanges();

            MessageBox.Show("تم إضافة المستخدم بنجاح");
        }
    }
}

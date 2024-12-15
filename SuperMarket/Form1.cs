using SuperMarket.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class Form1 : Form
    {
        SupermarketEntities db = new SupermarketEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = db.Users.Where(y => y.UserName == txtUser.Text && y.Password == txtPassword.Text).ToList();

            if (result.Count > 0)
            {
                this.Close();

                Thread th = new Thread(OpenForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("خطأ في اسم المستخدم أو كلمة المرور");
            }
           
        }
        void OpenForm()
        {
            Application.Run(new MainForm());
        }
    }
}

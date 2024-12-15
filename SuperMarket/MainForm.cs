using SuperMarket.Screens.Customers;
using SuperMarket.Screens.Products;
using SuperMarket.Screens.Suppliers;
using SuperMarket.Screens.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void إغلاقالبرنامجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void إضافةمستخدمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser x = new NewUser();
            x.Show();
        }

        private void إضافةمنتججديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Show();
        }

        private void عرضكلالمنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductList g = new ProductList();
            g.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductList g = new ProductList();
            g.Show();
        }

        private void تعديلمنتجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductEdit s = new ProductEdit();
            s.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            deleteUser u = new deleteUser();
            u.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomersMangement cs = new CustomersMangement();
            cs.Show();
        }

        private void العملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomersMangement cs = new CustomersMangement();
            cs.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SupplyMangement sp = new SupplyMangement();
            sp.Show();
        }

        private void الموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplyMangement sp = new SupplyMangement();
            sp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Product cs = new Product();
            cs.Show();
        }
    }
}

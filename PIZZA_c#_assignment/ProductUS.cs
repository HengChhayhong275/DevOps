using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIZZA_c__assignment
{
    public partial class ProductUS : UserControl
    {
        public int count=0;
        Product product;
        public ProductUS(Product product)
        {

            InitializeComponent();
            this.product = product;
            txtProName.Text=product.proName;
            decimal p = Convert.ToDecimal(product.price[0]);
            string price=p.ToString("C2");
            txtProPrice.Text = price;
            for (int i = 0;i<product.size.Count;i++) 
            {
                uiComboBox.Items.Add(product.size[i]);
            }
            picBox.Image=product.img;
            uiComboBox.SelectedIndex = 0;
            if (qty <= 0)
            {
                btnCancel.Visible = false;
                btnAddcash.Text = " Add cash";
            }
        }
        private int qty { get;set;}
        private void uiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index=uiComboBox.SelectedIndex;
            decimal p= Convert.ToDecimal(product.price[index]);
            if (count > 0)
            {
                string price = p.ToString("C2");
                txtProPrice.Text = price;
            }
            count++;
        }

        private void btnAddcash_Click(object sender, EventArgs e)
        {
           
            qty++;
            string qtyy=qty.ToString();
            btnAddcash.Text = $" Add cash({qtyy}) ";
            btnCancel.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            qty--;
            string qtyy = qty.ToString();
            btnAddcash.Text = $" Add cash({qtyy}) ";
            if (qty <= 0)
            {
                btnCancel.Visible = false;
                btnAddcash.Text = " Add cash";
            }
        }
    }
}

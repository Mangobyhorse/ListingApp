using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListProducts();
            ListCategories();
        }

        private void ListProducts()
        {
            using (NortwindContext context = new NortwindContext())
            {
                dgwProduct.DataSource = context.Products.ToList();
            }
        }

        private void ListProductsbyCategory(int categoryId)
        {
            using (NortwindContext context = new NortwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p=>p.CategoryId==categoryId  ).ToList();
            }
        }

        private void ListCategories()
        {
            using (NortwindContext context = new NortwindContext())
            {
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryId";

                cbxCategory.DataSource = context.Categories.ToList();
            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListProductsbyCategory(Convert.ToInt16(cbxCategory.SelectedValue));
        }
    }
}

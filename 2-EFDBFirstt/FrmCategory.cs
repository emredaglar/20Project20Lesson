using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace _2_EFDBFirstt
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        DbProject2Entities db=new DbProject2Entities();

        private void label8_Click(object sender, EventArgs e)
        {

        }
        void CategoryList()
        {

            dataGridView1.DataSource = db.TblCategory.ToList();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblCategory tblCategory = new TblCategory();
            tblCategory.CategoryName=txtName.Text;
            db.TblCategory.Add(tblCategory);
            db.SaveChanges();
        }
    }
}

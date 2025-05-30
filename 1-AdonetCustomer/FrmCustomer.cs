using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_AdonetCustomer
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=DD\\SQLEXPRESS02; initial catalog=DbCustomer; integrated security=true");
        private void btnList_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select CustomerId,CustomerName,CustomarSurname,CustomerBalance,CustomerStatus,CityName from TblCustomer\r\nInner Join TblCity\r\nOn TblCity.CityId=TblCustomer.CustomerCity", sqlConnection);
            //SqlCommand command = new SqlCommand("Execute CustomerListWithCity", sqlConnection);  Prosedür ile çalışma
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlConnection.Close();

        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("Select * From TblCity", sqlConnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            cmbCity.ValueMember = "CityId";
            cmbCity.DisplayMember = "CityName";
            cmbCity.DataSource = dataTable;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Insert Into TblCustomer (CustomerName, CustomerSurname, CustomerCity, CustomerBalance, CustomerStatus) values (@customerName, @customerSurname, @customerCity, @customerBalance, @customerStatus)", sqlConnection);
            command.Parameters.AddWithValue("@customerName",txtName.Text);

        }
    }
}

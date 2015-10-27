using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HomeWork_ADO_NET_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.UserID = textBoxUser.Text;
            builder.Password = textBoxPassword.Text;
            builder.DataSource = @"BOSS\MSSQLENTERPRISE";
            builder.InitialCatalog = "MyDB";
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = builder.ConnectionString;
                con.Open();
                MessageBox.Show("Connection is created.");

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [Table]";
                cmd.Connection = con;

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    MessageBox.Show(rd["LastName"].ToString());
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace EmployeesProject
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListProjects();
        }

        private void ListProjects()
        {

            // Proje bilgilerini listeleyen kod
            try
            {
                // Önceki labelleri temizle
                string ConnectionString = "Data Source=QWERTY;Initial Catalog=Employees;Integrated Security=True";
                flowLayoutPanel1.Controls.Clear();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT ProjectName, StartDate, EndDate FROM Projects", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Verileri Label kontrollerine ekleme
                                Label label = new Label();
                                label.Text = $"Proje Adı: {reader["ProjectName"]}, Başlangıç Tarihi: {reader["StartDate"]}, Bitiş Tarihi: {reader["EndDate"]}";
                                label.AutoSize = true;
                                flowLayoutPanel1.Controls.Add(label);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Projeler listelenirken bir hata oluştu: " + ex.Message);
            }


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

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

namespace EmployeesProject
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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

                    using (SqlCommand command = new SqlCommand("SELECT employeeName, employeeSurname, employeeEmail FROM Employees", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Verileri Label kontrollerine ekleme
                                Label label = new Label();
                                label.Text = $"Çalışan Adı: {reader["employeeName"]}, Çalışan Soyadı: {reader["employeeSurname"]}, Çalışan Emaili: {reader["employeeEmail"]}";
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
    }
   
}

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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public void ClearForm()
        {
            textBoxEmployeeName.Text = "";
            textBoxEmployeeSurname.Text = "";
            textBoxEmployeeEmail.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=QWERTY;Initial Catalog=Employees;Integrated Security=True";
            string employeeName = textBoxEmployeeName.Text;
            string employeeSurname = textBoxEmployeeSurname.Text;
            string employeeEmail = textBoxEmployeeEmail.Text;

            if (string.IsNullOrEmpty(employeeName) || string.IsNullOrEmpty(employeeSurname) || string.IsNullOrEmpty(employeeEmail))
            {
                MessageBox.Show("Çalışan adı, soyadı ve email alanları boş bırakılamaz.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("INSERT INTO Employees (employeeName, employeeSurname, employeeEmail) VALUES (@employeeName, @employeeSurname, @employeeEmail)", connection))
                    {
                        command.Parameters.AddWithValue("@employeeName", employeeName);
                        command.Parameters.AddWithValue("@employeeSurname", employeeSurname);
                        command.Parameters.AddWithValue("@employeeEmail", employeeEmail);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Çalışan başarıyla eklendi.");
                ClearForm();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Çalışan eklenirken bir hata oluştu: " + ex.Message);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

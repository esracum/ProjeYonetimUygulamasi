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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = //Veritabani Baglanti Stringi
            string deleteEmployeeName = textBoxDeleteEmployeeName.Text;
            string deleteEmployeeSurname = textBoxDeleteEmployeeSurname.Text;

            if (string.IsNullOrEmpty(deleteEmployeeName) || string.IsNullOrEmpty(deleteEmployeeSurname))
            {
                MessageBox.Show("Silmek istediğiniz çalışanın adını ve soyadını giriniz.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Çalışanı bulmak için adı ve soyadına göre sorgu yapalım
                    using (SqlCommand findEmployeeCommand = new SqlCommand("SELECT EmployeeID FROM Employees WHERE EmployeeName = @EmployeeName AND EmployeeSurname = @EmployeeSurname", connection))
                    {
                        findEmployeeCommand.Parameters.AddWithValue("@EmployeeName", deleteEmployeeName);
                        findEmployeeCommand.Parameters.AddWithValue("@EmployeeSurname", deleteEmployeeSurname);

                        object result = findEmployeeCommand.ExecuteScalar();

                        if (result != null)
                        {
                            int employeeID = (int)result;

                            // Çalışanı silme işlemi
                            using (SqlCommand deleteEmployeeCommand = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", connection))
                            {
                                deleteEmployeeCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                                deleteEmployeeCommand.ExecuteNonQuery();

                                MessageBox.Show("Çalışan başarıyla silindi.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen ad ve soyada sahip çalışan bulunamadı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Çalışan silinirken bir hata oluştu: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
    }


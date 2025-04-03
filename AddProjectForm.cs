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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ConnectionString = //Veritabanı Baglanti Stringi
            string projectName = textBoxProjectName.Text;
            string startDateText = maskedTextBoxStartDate.Text;
            string endDateText = maskedTextBoxEndDate.Text;

            if (string.IsNullOrEmpty(projectName) || string.IsNullOrEmpty(startDateText) || string.IsNullOrEmpty(endDateText))
            {
                MessageBox.Show("Proje adı, başlangıç tarihi ve bitiş tarihi alanları boş bırakılamaz.");
                return;
            }

            if (DateTime.TryParse(startDateText, out DateTime startDate) && DateTime.TryParse(endDateText, out DateTime endDate))
            {

                try
                {

                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("INSERT INTO Projects (ProjectName, StartDate, EndDate) VALUES (@ProjectName, @StartDate, @EndDate)", connection))
                        {
                            command.Parameters.AddWithValue("@ProjectName", projectName);
                            command.Parameters.AddWithValue("@StartDate", startDate);
                            command.Parameters.AddWithValue("@EndDate", endDate);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Proje başarıyla eklendi.");
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Proje eklenirken bir hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Geçerli tarih formatları kullanınız.");
            }
        }

        private void ClearForm()
        {
            textBoxProjectName.Text = "";
            maskedTextBoxStartDate.Text = "";
            maskedTextBoxEndDate.Text = "";
            this.Close();
        }


        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
    
}

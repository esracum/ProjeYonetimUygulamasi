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
    public partial class Form7 : Form
    {
        private int taskID;
        private int projectID; // projectID'yi burada tanımla
        private int employeeID; // employeeID'yi burada tanımla

        public Form7()
        {
            InitializeComponent();
        }

        public void ClearForm()
        {
            textBoxTaskName.Text = "";
            textBoxEmployeeName.Text = "";
            textBoxEmployeeSurname.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string ConnectionString = "Data Source=QWERTY;Initial Catalog=Employees;Integrated Security=True";
            string taskName = textBoxTaskName.Text;
            string Name = textBoxEmployeeName.Text;
            string Surname = textBoxEmployeeSurname.Text;
            string startDate = maskedTextBox1.Text;
            string endDate = maskedTextBox2.Text;
            string projectName = textBoxProjectName.Text; // Projeyi al

            if (string.IsNullOrEmpty(taskName) || string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate) || string.IsNullOrEmpty(projectName))
            {
                MessageBox.Show("Görev adı, başlangıç tarihi, bitiş tarihi ve proje adı alanları boş bırakılamaz.");
                return;
            }

            if (DateTime.TryParse(startDate, out DateTime StartDate) && DateTime.TryParse(endDate, out DateTime EndDate))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();

                        // ProjectID'yi alalım
                        using (SqlCommand projectCommand = new SqlCommand("SELECT ProjectID FROM Projects WHERE ProjectName = @ProjectName", connection))
                        {
                            projectCommand.Parameters.AddWithValue("@ProjectName", projectName);
                            object result = projectCommand.ExecuteScalar();
                            if (result != null)
                                projectID = (int)result;
                            else
                            {
                                MessageBox.Show("Belirtilen proje bulunamadı.");
                                return;
                            }
                        }

                        // EmployeeID'yi alalım
                        using (SqlCommand employeeCommand = new SqlCommand("SELECT EmployeeID FROM Employees WHERE EmployeeName = @EmployeeName AND EmployeeSurname = @EmployeeSurname", connection))
                        {
                            employeeCommand.Parameters.AddWithValue("@EmployeeName", Name);
                            employeeCommand.Parameters.AddWithValue("@EmployeeSurname", Surname);
                            object result = employeeCommand.ExecuteScalar();
                            if (result != null)
                                employeeID = (int)result;
                            else
                            {
                                MessageBox.Show("Belirtilen çalışan bulunamadı.");
                                return;
                            }
                        }

                        // Task ekleyelim ve ID'sini alalım
                        using (SqlCommand command = new SqlCommand("INSERT INTO Tasks (ProjectID, EmployeeID, TaskName, StartDate, EndDate,employeeName, employeeSurname,projectName) OUTPUT INSERTED.TaskID VALUES (@ProjectID, @EmployeeID, @TaskName, @StartDate, @EndDate,@employeeName, @employeeSurname,@projectName)", connection))
                        {
                            command.Parameters.AddWithValue("@ProjectID", projectID);
                            command.Parameters.AddWithValue("@EmployeeID", employeeID);
                            command.Parameters.AddWithValue("@TaskName", taskName);
                            command.Parameters.AddWithValue("@employeeSurname", Name);
                            command.Parameters.AddWithValue("@Projectname", projectName);
                            command.Parameters.AddWithValue("@employeeName", Surname);
                            command.Parameters.AddWithValue("@StartDate", StartDate);
                            command.Parameters.AddWithValue("@EndDate", EndDate);

                            // Yeni eklenen task'ın ID'sini al
                            taskID = (int)command.ExecuteScalar();
                        }

                        MessageBox.Show("Görev başarıyla eklendi. TaskID: " + taskID);
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Görev eklenirken bir hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Geçerli tarih formatları kullanınız.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Form10 : Form
    {

        public Form10()
        {
            InitializeComponent();
            InitializeFlowLayoutPanel();

            // Butonları göster
            DisplayTasks();
        }
        private void InitializeFlowLayoutPanel()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.Dock = DockStyle.Fill;
            Controls.Add(flowLayoutPanel1);
        }
        private void DisplayTasks()
        {
            flowLayoutPanel1.Controls.Clear(); // Önceki butonları temizle

            DataTable tasksDataTable = GetTasksFromDatabase();

            foreach (DataRow row in tasksDataTable.Rows)
            {
                Button taskButton = new Button();
                taskButton.Text = row["TaskName"].ToString();
                taskButton.Size = new Size(130,50);
                

                DateTime startDate = Convert.ToDateTime(row["StartDate"]);
                DateTime endDate = Convert.ToDateTime(row["EndDate"]);

                string taskStatus = GetTaskStatus(startDate, endDate);

                // Task'ın durumuna göre buton rengini belirle
                switch (taskStatus)
                {
                    case "NotStarted":
                        taskButton.BackColor = Color.Gray;
                        break;
                    case "InProgress":
                        taskButton.BackColor = Color.Green;
                        break;
                    case "Completed":
                        taskButton.BackColor = Color.Red;
                        break;
                }

                taskButton.Click += (sender, e) =>
                {
                    MessageBox.Show($"Task: {row["TaskName"]}\nStatus: {taskStatus}");
                };

                flowLayoutPanel1.Controls.Add(taskButton);
            }
        }

        private DataTable GetTasksFromDatabase()
        {
            DataTable dataTable = new DataTable();

            // TODO: SqlConnection ve SqlDataReader kullanarak veritabanından veri çekme işlemleri
            // Örnek sorgular, bağlantı ve SqlDataReader oluşturulmalıdır.
            using (SqlConnection connection = new SqlConnection("Data Source=QWERTY;Initial Catalog=Employees;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Tasks", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
        private string GetTaskStatus(DateTime startDate, DateTime endDate)
        {
            DateTime today = DateTime.Today;

            if (today < startDate)
                return "NotStarted";
            else if (today >= startDate && today <= endDate)
                return "InProgress";
            else
                return "Completed";
        }
        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DisplayTasks();

        }
    }
}

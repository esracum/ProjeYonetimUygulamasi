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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EmployeesProject
{
    public partial class Form1 : Form
    {
        private readonly DatabaseManager dbManager;
        public Form1()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string email = textBoxEmail.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Kullanıcı adı ve e-posta alanları boş bırakılamaz.");
                return;
            }

            Users newUser = new Users
            {
                UserName = username,
                Email = email
            };

            try
            {
                dbManager.AddUser(newUser);
                MessageBox.Show("Kullanıcı başarıyla eklendi.");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            textBoxUsername.Text = "";
            textBoxEmail.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBoxUsername.Text; // Kullanıcı adını textBox'tan al
                string email = textBoxEmail.Text;
                bool userExists = dbManager.CheckUser(username, email);

                if (userExists)
                {
                    MessageBox.Show("Giriş başarılı!");
                    Form2 secondForm = new Form2();
                    secondForm.Show();

                    // Mevcut formu gizle (isteğe bağlı)
                    this.Hide();
                    // İkinci sayfaya yönlendirme veya diğer işlemleri burada gerçekleştirebilirsiniz.
                    // Örneğin: new SecondForm().Show(); veya başka bir form açılabilir.
                }
                else
                {
                    MessageBox.Show("Giriş bilgileri hatalı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı kontrol edilirken bir hata oluştu: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                //checkBox işaretli ise
                if (checkBox1.Checked)
                {
                    //karakteri göster.
                    textBoxEmail.PasswordChar = '\0';
                }
                //değilse karakterlerin yerine * koy.
                else
                {
                    textBoxEmail.PasswordChar = '*';
                }
            }
        }
    }

    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class DatabaseManager
    {
        private const string ConnectionString = "Data Source=QWERTY;Initial Catalog=Employees;Integrated Security=True";

        public void AddUser(Users user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Users (UserName, Email) VALUES (@UserName, @Email)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@Email", user.Email);

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool CheckUser(string userName, string email)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string selectQuery = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName AND Email = @Email";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Email", email);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}

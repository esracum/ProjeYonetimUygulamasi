using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesProject
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = //Veritabani Baglanti Stringi
            string deleteProjectName = textBoxDeleteProjectName.Text;
            string deleteStartDateText = startdate.Text;
            string deleteEndDateText = enddate.Text;

            if (string.IsNullOrEmpty(deleteProjectName) || string.IsNullOrEmpty(deleteStartDateText) || string.IsNullOrEmpty(deleteEndDateText))
            {
                MessageBox.Show("Silmek istediğiniz proje adını, başlangıç tarihini ve bitiş tarihini giriniz.");
                return;
            }

            if (IsValidDateFormat(deleteStartDateText) && IsValidDateFormat(deleteEndDateText))
            {
                if (DateTime.TryParseExact(deleteStartDateText, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deleteStartDate)
                    && DateTime.TryParseExact(deleteEndDateText, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deleteEndDate))
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(ConnectionString))
                        {
                            connection.Open();

                            // Projeyi bulmak için adı ve tarih aralığına göre sorgu yapalım
                            using (SqlCommand findProjectCommand = new SqlCommand("SELECT ProjectID FROM Projects WHERE ProjectName = @ProjectName AND StartDate = @StartDate AND EndDate = @EndDate", connection))
                            {
                                findProjectCommand.Parameters.AddWithValue("@ProjectName", deleteProjectName);
                                findProjectCommand.Parameters.AddWithValue("@StartDate", deleteStartDate);
                                findProjectCommand.Parameters.AddWithValue("@EndDate", deleteEndDate);

                                object result = findProjectCommand.ExecuteScalar();

                                if (result != null)
                                {
                                    int projectID = (int)result;

                                    // Projeyi silme işlemi
                                    using (SqlCommand deleteProjectCommand = new SqlCommand("DELETE FROM Projects WHERE ProjectID = @ProjectID", connection))
                                    {
                                        deleteProjectCommand.Parameters.AddWithValue("@ProjectID", projectID);
                                        deleteProjectCommand.ExecuteNonQuery();

                                        MessageBox.Show("Proje başarıyla silindi.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Belirtilen ad, başlangıç tarihi ve bitiş tarihine sahip proje bulunamadı.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Proje silinirken bir hata oluştu: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Geçerli tarih formatları kullanınız (örn. 01.01.2022).");
                }
            }
            else
            {
                MessageBox.Show("Geçerli tarih formatları kullanınız (örn. 01.01.2022).");
            }
        }

        private bool IsValidDateFormat(string date)
        {
            // Geçerli bir tarih formatına uygun olup olmadığını kontrol etmek için kullanılacak kod buraya eklenebilir.
            // Örneğin, bir regular expression (Regex) kullanarak kontrol edilebilir.
            // Bu kısımda format kontrolü yapılıp true/false dönmelidir.
            // Bu örnek sadece bir placeholder'dir, gerçek kontrolü uygulamanıza bağlı olarak özelleştirebilirsiniz.
            return true;
        }


        private void enddate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void startdate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}



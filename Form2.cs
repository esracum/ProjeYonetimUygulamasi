using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 seventhForm = new Form7();
            seventhForm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           Form3 thirdForm = new Form3();
           thirdForm.Show();

           
          //  this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 forthForm = new Form4();
            forthForm.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form5 fifthForm = new Form5();
            fifthForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 sixthForm = new Form6();
            sixthForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 eighthForm = new Form8();
            eighthForm.Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form9 ninethForm = new Form9();
            ninethForm.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 tenthForm = new Form10();
            tenthForm.Show();


        }
    }
}

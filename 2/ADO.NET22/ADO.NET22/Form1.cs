using System;
using System.Windows.Forms;

namespace ADO.NET22
{
    /// <summary>
    /// It represents communication form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// It is a constructor.
        /// </summary>
        public Form1()
        {
           InitializeComponent();
        }


        /// <summary>
        /// It shows the regex and a pattern of e-mail. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            textBox1.Text = "test@gmail.com";
        }


        /// <summary>
        /// It handles of button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;

            bool result = str.IsValidEmail();

            if (result)
            {
                MessageBox.Show("Проверка прошла!");
            }
            else
            {
                MessageBox.Show("Проверка не прошла");
            }
        }
    }
}

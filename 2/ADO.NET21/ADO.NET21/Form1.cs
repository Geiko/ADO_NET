using System;
using System.Windows.Forms;

namespace geiko.ADO.NET21
{
    /// <summary>
    /// T representes my form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// It is constructor.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }



        /// <summary>
        /// It is a handler of button's click event.
        /// </summary>
        /// <param name="sender">Sender is a butoon.</param>
        /// <param name="e">Arguments.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            var anonim1 ="a";
            int hCode1 = anonim1.GetHashCode();

            var anonim2 = "a";
            int hCode2 = anonim2.GetHashCode();

            bool result1 = ReferenceEquals(anonim1,anonim2);



            var anonim3 = "bc";
            int hCode3 = anonim3.GetHashCode();

            bool result2 = ReferenceEquals(anonim2, anonim3);   //  http://habrahabr.ru/post/137680/




            label1.Text = string.Format( "1)\n{0} \n{1} \n{2} \n{3} \n{4}   \n\n2)\n{5} \n{6} \n{7} \n{8} \n{9}", 
                anonim1.ToString(), anonim2.ToString(), hCode1, hCode2, result1.ToString(),
                anonim2.ToString(), anonim3.ToString(), hCode2, hCode3, result2.ToString());



            string conclusion1 = "Если хеш-коды разные, то и входные объекты гарантированно разные.";
            string conclusion2 = "\nЕсли хеш - коды равны, то входные объекты не всегда равны.";
            string source = "http://habrahabr.ru/post/168195/";
            string res = string.Format( "{0} \n{1} \n\n{2}", conclusion1, conclusion2, source );
            MessageBox.Show(res);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class WriteParol : Form
    {
        public int a = 3;

        public WriteParol()
        {
            InitializeComponent(); 
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            //string FKey = "";
            MyClass class1 = new MyClass();

            if (File.Exists("password.txt"))
            {
                MyKey f = new MyKey();
                f.Owner = this;
                this.Hide();
                f.Show();
            }
            else
            {
                FileStream fs = new FileStream("password.txt", FileMode.Create, FileAccess.Write);
                fs.Close();
                //FKey = class1.SaveInFile(password);
                ChangeButton fkey = new ChangeButton(class1.SaveInFile(password));
                this.Hide();
                fkey.Show();
            }
        } 
    }   
}

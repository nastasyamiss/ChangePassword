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
    public partial class ChangePass : Form
    {
        private string oldkey;
        int one = 3; // попытки для проверки старого пароля
        private MyClass myclass;
        
        public ChangePass(string mykey)
        {
            InitializeComponent();
            this.oldkey = mykey;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string cresult, newkey = "";
            string oldpass = textBox1.Text;
            string newpass = textBox2.Text;
            myclass = new MyClass();
            
            cresult = myclass.FileMyOpen();
            if (myclass.ComparePass(oldpass, oldkey))
            {
                newkey = myclass.SaveInFile(newpass);
                ChangeButton chmain = new ChangeButton(newkey);
                chmain.Show();
                this.Hide();
            }
            else
            {
                one--;
                MessageBox.Show(String.Format("Неправильный пароль или ключ!\nОсталось попыток: {0}", one));
                if (one == 0)
                    Application.Exit();
            }

            textBox1.Text="";
            textBox2.Text="";
        }

        private void ChangePass_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


    }
}

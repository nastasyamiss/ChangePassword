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
    
    public partial class MyKey : Form
    {
        private MyClass myclass;

        public MyKey()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            string s="";
            WriteParol main = this.Owner as WriteParol;
            myclass = new MyClass();
            if (main != null)
                s = main.textBox1.Text;    //переменной s присваиваем значение textBox1(пароль)

            string KeyF2 = textBox1.Text;        //введенный ключ
            string password = myclass.FileMyOpen();   //зашифрованный пароль из файла
            
            if (myclass.ComparePass(s, KeyF2))       
            {
                KeyF2 = myclass.SaveInFile(s);
                ChangeButton key2 = new ChangeButton(KeyF2);
                key2.Show();
                this.Hide();
            }
            else if (main != null)
            {
                main.a--;
                MessageBox.Show(String.Format("Неправильный пароль или ключ!\nОсталось попыток: {0}", main.a));
                if (main.a == 0) Application.Exit();
                main.Show(); 
                main.textBox1.Text = ""; 
            } 
            this.Hide();  
        }

        private void MyKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
     
    }
}

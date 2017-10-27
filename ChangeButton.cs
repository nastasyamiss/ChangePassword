using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ChangeButton : Form
    {

        public ChangeButton(string keylabel)
        {
            InitializeComponent();
            datakey = keylabel;
            label1.Text = datakey;
        }
        private string datakey;

        private void button1_Click(object sender, EventArgs e)
        {
          ChangePass chpass = new ChangePass(datakey);
          chpass.Show();
          this.Hide();   
        }

        private void ChangeButton_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        } 
    }
}

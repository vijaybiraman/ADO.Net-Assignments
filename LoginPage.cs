using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using ClassLibDemo;
namespace WindowsFormsApp1
{
    public partial class LoginPage : Form
    {
       
        DataStoreForm dataStoreForm = null;
     
        public LoginPage()
        {
            InitializeComponent();
            dataStoreForm = new DataStoreForm(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
           
            List<Login> login = dataStoreForm.ValidateUser();
            bool res = false;
            foreach(var i in login)
            {
                if(i.password==txtPassword.Text && i.username==txtUsername.Text)
                {
                    res = true;
                   WinformDB db=new WinformDB();
                    db.ShowDialog();
                }
            }
            if (res == false)
            {
                MessageBox.Show("Invalid user");
            }
        }
    }
}

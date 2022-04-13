using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data.SqlClient;

namespace Otopark_tez
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection myConnection = new SqlConnection(@"user id=sa;" +
                                       "password=commitment;server=DESKTOP-P3V6QMJ;" +
                                       "Trusted_Connection=yes;" +
                                       "database=CARPARK; " +
                                       "connection timeout=30");

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("Check your user credantial!");
                return;
            }
            
            Main mn = new Main();
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                var sorgu = "select * from login_crd where ='" + txtuser.Text + "' and pasusernamesword='" + txtpassword.Text + "'";
                SqlCommand myCommand = new SqlCommand("select * from login_crd where userName='" + txtuser.Text + "' and password='" + txtpassword.Text + "'", myConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    if (myReader["username"].ToString() == txtuser.Text && myReader["password"].ToString() == txtpassword.Text)
                    {
                        myConnection.Close();
                        this.Hide();
                        mn.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Check your user credantial!", "Car Park");
                    myConnection.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
    }
}

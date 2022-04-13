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
    public partial class RegistrationDetails : Form
    {
        public RegistrationDetails()
        {
            InitializeComponent();
        }
        Button transferbutton = new Button();
        DateTime now = DateTime.Now;
        SqlConnection myConnection = new SqlConnection(@"user id=sa;" +
                               "password=commitment;server=DESKTOP-P3V6QMJ;" +
                               "Trusted_Connection=yes;" +
                               "database=CARPARK; " +
                               "connection timeout=30");
        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection.Open();
                //2021-06-04 23:32:02.000
                //var rcr = DateTime.Now.GetDateTimeFormats
                var TimeNow = DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK");
                var query = "insert into reg_detail (licence_plate,mobileNo,entranceDate,busystatus,location) values ('" + txtLicence.Text + "','" + txtGSM.Text + "','" + DateTime.UtcNow + "','X','" + transferbutton.Name.ToString() + "')";
                SqlCommand myCommand = new SqlCommand("insert into reg_detail (licence_plate,mobileNo,entranceDate,busystatus,location) values ('" + txtLicence.Text + "','" + txtGSM.Text + "'," + TimeNow + ",'X','" + transferbutton.Name.ToString() + "')", myConnection);
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Your car has been registered!");
                myConnection.Close();
                transferbutton.BackColor = Color.Red;
                transferbutton.Text = txtLicence.Text;
                transferbutton.Enabled = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            this.Close();
        }
        public void returnLoc(Button reg)
        {
            transferbutton = reg;
        }
    }
}

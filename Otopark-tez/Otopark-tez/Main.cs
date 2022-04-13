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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        SqlConnection myConnection = new SqlConnection(@"user id=sa;" +
                       "password=commitment;server=DESKTOP-P3V6QMJ;" +
                       "Trusted_Connection=yes;" +
                       "database=CARPARK; " +
                       "connection timeout=30");
        List<Button> lstBtnCall = new List<Button>();
        public void fillListbtn()
        {
            lstBtnCall.Add(button1);
            lstBtnCall.Add(button2);
            lstBtnCall.Add(button3);
            lstBtnCall.Add(button4);
            lstBtnCall.Add(button5);
            lstBtnCall.Add(button6);
            lstBtnCall.Add(button7);
            lstBtnCall.Add(button8);
            lstBtnCall.Add(button9);
            lstBtnCall.Add(button10);
            lstBtnCall.Add(button11);
            lstBtnCall.Add(button12);
            lstBtnCall.Add(button13);
            lstBtnCall.Add(button14);
            lstBtnCall.Add(button15);
            lstBtnCall.Add(button16);
            lstBtnCall.Add(button17);
            lstBtnCall.Add(button18);
            lstBtnCall.Add(button19);
            lstBtnCall.Add(button20);
            lstBtnCall.Add(button21);
            lstBtnCall.Add(button22);
            lstBtnCall.Add(button23);
            lstBtnCall.Add(button24);
            lstBtnCall.Add(button25);
            lstBtnCall.Add(button26);
            lstBtnCall.Add(button27);
            lstBtnCall.Add(button28);
            lstBtnCall.Add(button29);
            lstBtnCall.Add(button30);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            button1.Click += new EventHandler(MyButtonClick);
            button2.Click += new EventHandler(MyButtonClick);
            button3.Click += new EventHandler(MyButtonClick);
            button4.Click += new EventHandler(MyButtonClick);
            button5.Click += new EventHandler(MyButtonClick);
            button6.Click += new EventHandler(MyButtonClick);
            button7.Click += new EventHandler(MyButtonClick);
            button8.Click += new EventHandler(MyButtonClick);
            button9.Click += new EventHandler(MyButtonClick);
            button10.Click += new EventHandler(MyButtonClick);
            button11.Click += new EventHandler(MyButtonClick);
            button12.Click += new EventHandler(MyButtonClick);
            button13.Click += new EventHandler(MyButtonClick);
            button14.Click += new EventHandler(MyButtonClick);
            button15.Click += new EventHandler(MyButtonClick);
            button16.Click += new EventHandler(MyButtonClick);
            button17.Click += new EventHandler(MyButtonClick);
            button18.Click += new EventHandler(MyButtonClick);
            button19.Click += new EventHandler(MyButtonClick);
            button20.Click += new EventHandler(MyButtonClick);
            button21.Click += new EventHandler(MyButtonClick);
            button22.Click += new EventHandler(MyButtonClick);
            button23.Click += new EventHandler(MyButtonClick);
            button24.Click += new EventHandler(MyButtonClick);
            button25.Click += new EventHandler(MyButtonClick);
            button26.Click += new EventHandler(MyButtonClick);
            button27.Click += new EventHandler(MyButtonClick);
            button28.Click += new EventHandler(MyButtonClick);
            button29.Click += new EventHandler(MyButtonClick);
            button30.Click += new EventHandler(MyButtonClick);
            fillListbtn();
            bacgroundBut();
            forwarderbutton();
        }
        public void MyButtonClick(object sender, EventArgs e)
        {
            RegistrationDetails rgrdtl = new RegistrationDetails();
            Button button = sender as Button;
            rgrdtl.returnLoc(button);
            rgrdtl.Show();
        }
        double bill = 0;
        int Id = 0;
        SqlCommand myCommand = new SqlCommand();
        private void btngetdtl_Click(object sender, EventArgs e)
        {
            bill = 0;
            DateTime now = DateTime.Now;
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;

                //textbox'a girilen aracin cikis yaptigii tarhler arasindaki dakika varkini alarak ucret hesaplamasi yapilir(datediff meytdou)


                myCommand = new SqlCommand("select TOP 1 * (SELECT DATEDIFF(minute, entranceDate, '" + now + "')) AS ToplamSure,* from reg_detail where licence_plate='" + txtoutplate.Text + "' and busystatus='X' order by entranceDate desc", myConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    lstbxVhcDetail.Items.Add(myReader["licence_plate"]);
                    lstbxVhcDetail.Items.Add(myReader["mobileNo"]);
                    lstbxVhcDetail.Items.Add(myReader["entranceDate"]);
                    bill = Convert.ToDouble(myReader["DateDiff"]) / 60;
                    bill = bill * 5;
                    lstbxVhcDetail.Items.Add(Convert.ToInt32(bill).ToString() + " $ Unpaid balance.");
                    Id = Convert.ToInt32(myReader["Id"]);
                    myConnection.Close();
                }
                else
                {
                    MessageBox.Show("No information for this licence plate!");
                    myConnection.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void btncaraway_Click(object sender, System.EventArgs e)
        {
            try
            {
                myConnection.Open();
                //islem yapildiktan sonra aracin statusu c yan completed olara update edilir 
                myCommand = new SqlCommand("update reg_detail set busystatus='C' where  Id='" + Id + "'", myConnection);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                txtoutplate.Clear();
                lstbxVhcDetail.Items.Clear();
                MessageBox.Show("Vehicle out of park!", "Car Park");
                forwarderbuttonOut();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
        public void bacgroundBut()
        {
            for (int i = 0; i < 30; i++)
            {
                lstBtnCall[i].BackColor = Color.Green;
                lstBtnCall[i].Text = "";
                lstBtnCall[i].Enabled = true;
            }
        }
        public void forwarderbutton()
        {
            string loca = "";
            try
            {
                //islem statusu x devam ediyor c tamamlanmis
                //islem statusu yani but status x olanlar lisletenir (where busystatus='C)
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from reg_detail where busystatus='X'", myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    loca = myReader["location"].ToString();
                    for (int i = 0; i < 30; i++)
                    {
                        if (lstBtnCall[i].Name.ToString() == loca)
                        {
                            lstBtnCall[i].BackColor = Color.Red;
                            lstBtnCall[i].Text = myReader["licence_plate"].ToString();
                            lstBtnCall[i].Enabled = false;
                        }
                    }
                }
                myConnection.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
        public void forwarderbuttonOut()
        {
            //islem statisi yani but status c olanlar lisletenir (where busystatus='C')
            string loca = "";
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from reg_detail where busystatus='C'", myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    loca = myReader["location"].ToString();
                    for (int i = 0; i < 30; i++)
                    {
                        if (lstBtnCall[i].Name.ToString() == loca)
                        {
                            lstBtnCall[i].BackColor = Color.Green;
                            lstBtnCall[i].Text = "";
                            lstBtnCall[i].Enabled = true;
                        }
                    }
                }
                myConnection.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void button31_Click(object sender, System.EventArgs e)
        {
            Main mn = new Main();
            mn.fillListbtn();
            mn.forwarderbutton();
        }

        private void dtmpDay_ValueChanged(object sender, System.EventArgs e)
        {
            string sql = "";
            try
            {
                //bu kisimda balance reponser talosnda tarihe gore toplam satis miktari hesaplanir ornek olarak SELECT SUM(paidbalance) as BALANCE FRO
                sql = "SELECT licence_plate AS LicencePlate,mobileNo AS MobileNo,entranceDate AS EntranceDate,onthewaydate AS OnTheWayDate,paidbalance AS PaidBalance FROM balance_report where onthewaydate='" + dtmpDay.Value.ToShortDateString() + "'";
                SqlDataAdapter dataadapter = new SqlDataAdapter(sql, myConnection);
                DataSet ds = new DataSet();
                myConnection.Open();
                dataadapter.Fill(ds, "balance_report");
                myConnection.Close();
                dgrBalance.DataSource = ds;
                dgrBalance.DataMember = "balance_report";
                dgrBalance.ReadOnly = true;
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT SUM(paidbalance) as BALANCE FROM balance_report where onthewaydate='" + dtmpDay.Value.ToShortDateString() + "'", myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    lblTotalBalance.Text += myReader["BALANCE"].ToString();
                }
                myConnection.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void button20_Click(object sender, System.EventArgs e)
        {

        }
    }
}

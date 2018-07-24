using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace newerpsystem
{
    public partial class Form4 : Form
    {
        Form2 f2 = new Form2();


        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void Form4_Load(object sender, EventArgs e)
 {

            this.BackColor = Color.White;
                this.button1.BackColor = Color.White;
            this.button2.BackColor = Color.White;
            this.button3.BackColor = Color.White;
            this.button4.BackColor = Color.White;
            this.button5.BackColor = Color.White;
            this.button6.BackColor = Color.White;


            this.BackColor = Color.White;
                this.button5.Visible = false;
            this.button6.Visible = false;
            this.button1.Visible = false;

            this.panel3.Visible = false;

            this.panel2.Visible = false;
            this.button3.Visible = false;
            this.button19.Text=">>    Close";
            this.button19.Visible =false;
            dataGridView1.Visible = false;
            button8.Visible = false;
            button15.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            button18.Text = "Approved";
            button11.Text="DisApproved";
            button17.Text = "Approved";
            button12.Text = "DisApproved";

            this.label1.Text = " VID";
            this.label2.Text = "V Name";
            this.label3.Text = "V Code";
            this.label4.Text = "V City";
            this.label5.Text = "V Address";
            this.label6.Text = "PH1 ";
            this.label7.Text = "PH2";
            this.label8.Text = "CP Name";
            this.label9.Text = "CP Ph";
            this.label10.Text = "Email";
            this.label11.Text = "V Fax";
            this.label12.Text = "V Status";
            this.label13.Text = "V Group";
            this.label26.Text = " VID";
            this.label25.Text = "V Name";
            this.label24.Text = "V Code";
            this.label23.Text = "V City";
            this.label22.Text = "V Address";
            this.label21.Text = "PH1 ";
            this.label20.Text = "PH2";
            this.label9.Text = "CP Name";
            this.label8.Text = "CP Ph";
            this.label17.Text = "Email";
            this.label16.Text = "V Fax";
            this.label15.Text = "V Status";
            this.label14.Text = "V Group";

            button7.Text = "SFA";
            button8.Text = "Add";
            button8.Visible = false;
            button9.Text = "New";
            button10.Text = "Close";
            button16.Text = "SFA";
            button15.Text = "Update";
            button15.Visible = false;
            button14.Text = "New";
            button13.Text = "Close";
            {

                f2.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select VID from Vendor", f2.oleDbConnection1);
                cmd.Parameters.AddWithValue("@VID", this.comboBox7.Text);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox7.Items.Add(dr["VID"].ToString());
                }
                f2.oleDbConnection1.Close();
            }


            string[] city = { "Lahore", "Karachi", "Islamabad", "Multan", };
            comboBox2.Items.AddRange(city);

            string[] ciity = { "Lahore", "Karachi", "Islamabad", "Multan", };
            comboBox6.Items.AddRange(city);



            f2.oleDbConnection1.Open();
            OleDbCommand cmdd = new OleDbCommand("Select VStatus from Vendor", f2.oleDbConnection1);
            OleDbDataReader drd = cmdd.ExecuteReader();
            comboBox3.Items.Clear();
            while (drd.Read())
            {
                this.comboBox3.Items.Add(drd["Vstatus"].ToString());
            }
            f2.oleDbConnection1.Close();



            {
                f2.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select VStatus from Vendor", f2.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                comboBox5.Items.Clear();
                while (dr.Read())
                {
                    this.comboBox5.Items.Add(dr["Vstatus"].ToString());
                }
                f2.oleDbConnection1.Close();
            }


            f2.oleDbConnection1.Open();
            OleDbCommand cmdr = new OleDbCommand("Select deptname from Dept", f2.oleDbConnection1);
            OleDbDataReader drr = cmdr.ExecuteReader();
            comboBox4.Items.Clear();
            while (drr.Read())
            {
                this.comboBox4.Items.Add(drr["deptname"].ToString());
            }
            f2.oleDbConnection1.Close();


            {
                f2.oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("Select deptname from Dept", f2.oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                comboBox1.Items.Clear();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["deptname"].ToString());
                }
                f2.oleDbConnection1.Close();
            }

            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            //button2.Text = "Vender Menu";
            button3.Text = "CREATE NEW";
            button4.Text = "UPDATE";
            button5.Text = "VIEW";
            button6.Text = "DELETE";
            
            this.panel3.Visible = false;
           }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button3.Visible = true;
            this.button4.Visible = true;
            this.button5.Visible = true;
            this.button6.Visible = true;
            this.button1.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.oleDbConnection1.Open();

            OleDbCommand cmd = new OleDbCommand("Select * from Vendor where VID=@VID", f2.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VID", this.comboBox7.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox19.Text = dr["Vname"].ToString();
                textBox18.Text = dr["VAddress"].ToString();
                comboBox6.Text = dr["VCity"].ToString();
                textBox17.Text = dr["VCode"].ToString();
                textBox16.Text = dr["PH1"].ToString();
                 textBox15.Text = dr["PH2"].ToString();
                textBox14.Text = dr["CPName"].ToString();
                textBox13.Text = dr["CPPH"].ToString();
                textBox12.Text = dr["VEmail"].ToString();
                textBox4.Text = dr["VFax"].ToString();

                comboBox5.Text = dr["VStatus"].ToString();
                comboBox1.Text = dr["VGroup"].ToString();
}
            f2.oleDbConnection1.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Data Sending For Approval To The Admin");
            panel4.Visible = true;
            panel5.Visible = false;
                
        }

        private void button16_Click(object sender, EventArgs e)
        {
           

            MessageBox.Show("Data Sending For Approval To The Admin");
            panel4.Visible = false;
            panel5.Visible = true;


        }

        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data Sending For Approval To The Admin");
           panel5.Visible = false;
            button15.Visible = true;
            this.comboBox5.Text = "Approved";
            MessageBox.Show("Approved by Admin...Plz Add it in the Database....");
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
          panel4.Visible = false;
            button8.Visible = true;
            this.comboBox3.Text = "Approved";
            MessageBox.Show("Approved by Admin...Plz Add it in the Database....");
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = false;
           
            this.comboBox3.Text = "DisApproved";
            MessageBox.Show("DisApproved by Admin...Plz Add it in the Database....");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            this.comboBox5.Text = "DisApproved";
            MessageBox.Show("DisApproved by Admin...Plz Add it in the Database....");
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Visible = false;
            f2.oleDbConnection1.Open();
                
            OleDbCommand cmd = new OleDbCommand("Insert into Vendor(VID,VName,VAddress,VCity,VCode,PH1,PH2,CPName,CPPH,VEmail,VFax,VStatus,VGroup)values(@VID,@VName,@VAddress,@VCity,@VCode,@PH1,@PH2,@CPName,@CPPH,@VEmail,@VFax,@VStatus,@VGroup)", f2.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VID", textBox1.Text);
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            cmd.Parameters.AddWithValue("@VAddress", textBox3.Text);
            cmd.Parameters.AddWithValue("@VCity", comboBox2.Text);
            cmd.Parameters.AddWithValue("@VCode", textBox5.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox6.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox7.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox8.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox9.Text);
            cmd.Parameters.AddWithValue("@VEmail", textBox10.Text);
            cmd.Parameters.AddWithValue("@VFax", textBox11.Text);
            cmd.Parameters.AddWithValue("@ VStatus", comboBox3.Text);
            cmd.Parameters.AddWithValue("@ VGroup", comboBox4.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Has been Inserted");
            f2.oleDbConnection1.Close();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            button15.Visible = false;
            f2.oleDbConnection1.Open();

            OleDbCommand cmd = new OleDbCommand("Update Vendor set VName=VName,VAddress=@VAddress,VCity=@VCity,VCode=@VCode,PH1=@PH1,PH2=@PH2,CPName=@CPName,CPPH=@CPPH,VEmail=@VEmail,VFax=@VFax,VStatus=@VStatus,VGroup=@VGroup where VID=@VID", f2.oleDbConnection1);
            cmd.Parameters.AddWithValue("@Vname", textBox19.Text);
            cmd.Parameters.AddWithValue("@VCode", textBox18.Text);

            cmd.Parameters.AddWithValue("@VCity", comboBox6.Text);
            cmd.Parameters.AddWithValue("@VAddress", textBox17.Text);
            
            

            cmd.Parameters.AddWithValue("@PH1", textBox16.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox15.Text);
            cmd.Parameters.AddWithValue("@CPName", textBox14.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox13.Text);
            cmd.Parameters.AddWithValue("@VEmail", textBox12.Text);
            cmd.Parameters.AddWithValue("@VFax", textBox4.Text);
            cmd.Parameters.AddWithValue("@ VStatus", comboBox5.Text);
            cmd.Parameters.AddWithValue("@ VGroup", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Has been Updated");
            f2.oleDbConnection1.Close();















        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.button19.Visible = true;
            this.dataGridView1.Visible = true;
            f2.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Vendor", f2.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            f2.oleDbConnection1.Close();

        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.button19.Visible = false;
            this.dataGridView1.Visible = false;
        }
    }
}

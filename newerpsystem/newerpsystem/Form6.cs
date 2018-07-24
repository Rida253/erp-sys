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
    public partial class Form6 : Form
    {
        Form2 f2 = new Form2();
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            button2.Text = "Create";
            label1.Text = "POID";
            label2.Text = "GRNID";
            label3.Text = "VID";
            label4.Text = "V Name";
            label5.Text = "C.P Name ";
            label6.Text = "Recieving Date";
            label7.Text = "Items";
            label8.Text = "Payment";
            
            f2.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select POID from GRN", f2.oleDbConnection1);
            cmd.Parameters.AddWithValue("@POID", this.comboBox1.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox1.Items.Add(dr["POID"].ToString());
            }
            f2.oleDbConnection1.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.oleDbConnection1.Open();
            OleDbCommand cmdd = new OleDbCommand("Select * from POProducts where POID=@POID", f2.oleDbConnection1);
            cmdd.Parameters.AddWithValue("@POID", this.dataGridView1.Text);
            OleDbDataReader drr = cmdd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(drr);
            dataGridView1.DataSource = dt;
            f2.oleDbConnection1.Close();




            f2.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select VName,TotalAmount,VID,VContectPerson,DDate,Status From PO where POID=@POID ", f2.oleDbConnection1);
            cmd1.Parameters.AddWithValue("@POID", this.comboBox1.Text);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox3.Text = dr1["VName"].ToString();
                textBox5.Text = dr1["TotalAmount"].ToString();
                //textBox5.Text = dr1["TotalAmount"].ToString();

                textBox2.Text = dr1["VID"].ToString();
                textBox4.Text = dr1["VContectPerson"].ToString();
              // dateTimePicker2 =dr1["DDate"].ToString();
                
            }

            f2.oleDbConnection1.Close();

            int c = 0;
            f2.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(GRNID) from GRN where POID='" + comboBox1.Text + "'", f2.oleDbConnection1);

            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); c++;
            }
            {
                textBox1.Text = "GRN-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            f2.oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f2.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into GRN(GRNID,POID,VName,GRDate)values(@GRNID,@POID,@VName,@GRDate)", f2.oleDbConnection1);
            cmd.Parameters.AddWithValue("@POID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@GRNID", textBox1.Text);
            cmd.Parameters.AddWithValue("@VName", textBox2.Text);
            //cmd.Parameters.AddWithValue("@DDate", textBox3.Text);
            // cmd.Parameters.AddWithValue("@GRDate",dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@GRDate", dateTimePicker1);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Has been Inserted");
            f2.oleDbConnection1.Close();
        }
    }
    }
    


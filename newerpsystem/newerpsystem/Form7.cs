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
    public partial class Form7 : Form
    {
        Form2 f2 = new Form2();
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            f2.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select GRNID from GRN", f2.oleDbConnection1);
            cmd.Parameters.AddWithValue("@GRNID", this.comboBox1.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox1.Items.Add(dr["GRNID"].ToString());
            }
            f2.oleDbConnection1.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.oleDbConnection1.Open();
            OleDbCommand cmdd = new OleDbCommand("Select * from POProducts where GRNID=@GRNID", f2.oleDbConnection1);
            cmdd.Parameters.AddWithValue("@GRNID", this.comboBox1.Text);
            OleDbDataReader drr = cmdd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(drr);
            dataGridView1.DataSource = dt;
            f2.oleDbConnection1.Close();

            f2.oleDbConnection1.Open();

            OleDbCommand cmd1 = new OleDbCommand("Select VID,POID From GRN where GRNID=@GRNID ", f2.oleDbConnection1);
            cmd1.Parameters.AddWithValue("@GRN", this.comboBox1.Text);
             OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                //textBox3.Text = dr1["VName"].ToString();
                //textBox5.Text = dr1[""].ToString();
                ///textBox5.Text = dr1["TotalAmount"].ToString();

                textBox2.Text = dr1["VID"].ToString();
                textBox3.Text = dr1["POID"].ToString();
                //dateTimePicker1 =dr1["GRDate"].ToString();

            }
            f2.oleDbConnection1.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

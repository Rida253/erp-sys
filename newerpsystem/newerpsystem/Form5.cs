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
    public partial class Form5 : Form
    {
        string[] prds = new string[50];
        int[] qty = new int[50];
        int[] pprice = new int[50];
        int counter = 0;
        Form2 f2 = new Form2();
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            groupBox2.Text = "Product Info";
            groupBox1.Text = "Vender Info";
            groupBox3.Text = "Purchase Order Info";
            this.label1.Text = "V ID";
            this.label2.Text = "V Name";
            this.label3.Text = "Contact Person";
            this.label4.Text = "PH # ";
            this.label5.Text = "Depart";
            this.label6.Text = "POID";
            this.label7.Text = "PO Date";
            this.label8.Text = "P Model";
            this.label9.Text = "P Name";
            this.label10.Text = "P Price";
            this.label11.Text = "Quantity";
            this.label12.Text = "Total price";
            this.label13.Text = "PO Due Date";
            this.button2.Text = "ADD Value";
            this.button3.Text = "Insert Data";
            this.button4.Text = "Close";
            this.button2.Text = "New PO";





            f2.oleDbConnection1.Open();
            OleDbCommand cmdd = new OleDbCommand("Select Pid from Products", f2.oleDbConnection1);
            cmdd.Parameters.AddWithValue("@Pid", this.comboBox3.Text);
            OleDbDataReader drr = cmdd.ExecuteReader();
            while (drr.Read())
            {
                this.comboBox3.Items.Add(drr["Pid"].ToString());
            }
            f2.oleDbConnection1.Close();



            f2.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Dept", f2.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox2.Items.Add(dr["deptname"].ToString());
            }
            f2.oleDbConnection1.Close();














            f2.oleDbConnection1.Open();
            OleDbCommand cmde = new OleDbCommand("Select VID from Vendor", f2.oleDbConnection1);
            cmde.Parameters.AddWithValue("@VID", this.comboBox1.Text);
            OleDbDataReader dre = cmde.ExecuteReader();
            while (dre.Read())
            {
                this.comboBox1.Items.Add(dre["VID"].ToString());
            }
            f2.oleDbConnection1.Close();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.oleDbConnection1.Open();

            OleDbCommand cmd = new OleDbCommand("Select * from Vendor where VID=@VID", f2.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VID", this.comboBox1.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox1.Text = dr["VName"].ToString();
                textBox2.Text = dr["CPName"].ToString();
                textBox3.Text = dr["CPPH"].ToString();
            }
            f2.oleDbConnection1.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {





            int c = 0;
            f2.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(poid) from po where vdept = '" + comboBox2.Text + "'", f2.oleDbConnection1);

            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]); c++;
            }
            if (comboBox2.Text == "Consumer")
            {
                textBox4.Text = "Con-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            if (comboBox2.Text == "HR")
            {
                textBox4.Text = "HR-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            if (comboBox2.Text == "Sales")
            {
                textBox4.Text = "Sal-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            if (comboBox2.Text == "Marketing")
            {
                textBox4.Text = "Mar-00" + c.ToString() + "-" + System.DateTime.Today.Year;
            }

            f2.oleDbConnection1.Close();

            f2.oleDbConnection1.Open();
            OleDbCommand cmdd = new OleDbCommand("Select * from Vendor where VGroup='" + this.comboBox2.Text + "'", f2.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            comboBox1.Items.Clear();

            while (drr.Read())
            {
                this.comboBox1.Items.Add(drr["VID"].ToString());
            }
            f2.oleDbConnection1.Close();

        }

        //    int c = 0;
        //    f2.oleDbConnection1.Open();
        //    OleDbCommand cmd = new OleDbCommand("select count(poid) from po where deptname = '" + comboBox2.Text + "'",f2.oleDbConnection1);
        //    OleDbDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        c = Convert.ToInt32(dr[0]); c++;
        //    }
        //    if (comboBox2.Text == "Consumer")
        //    {
        //        textBox4.Text = "Con-00" + c.ToString() + "-" + System.DateTime.Today.Year;
        //    }
        //    f2.oleDbConnection1.Close();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            int baseprice = 0;
            int productqty = 0;
            baseprice = Convert.ToInt32(textBox6.Text);
            productqty = Convert.ToInt32(textBox7.Text);
            this.textBox8.Text = Convert.ToString(baseprice * productqty);
            prds[counter] = comboBox3.Text;
            qty[counter] = Convert.ToInt32(textBox7.Text);
            pprice[counter] = Convert.ToInt32(textBox8.Text);
            counter++;
            this.textBox9.Text += "PURCHASE ORDER" + Environment.NewLine;
            this.textBox9.Text += "DEPARTMENT:" + comboBox2.Text + Environment.NewLine;
            this.textBox9.Text += "PO_ID:" + textBox4.Text + Environment.NewLine;
            //this.textBox9.Text += "PO Issue date:"+dateTimePicker1+ Environment.NewLine;
            //this.textBox9.Text += "PO delivery date:"++ Environment.NewLine;
            this.textBox9.Text += "****Vendor detail****" + Environment.NewLine;
            this.textBox9.Text += "vendor id:" + comboBox1.Text + Environment.NewLine;
            this.textBox9.Text += "Vendorname:" + textBox1.Text + Environment.NewLine;
            this.textBox9.Text += "Contact person:" + textBox2.Text + Environment.NewLine;
            this.textBox9.Text += "CP ph#:" + textBox3.Text + Environment.NewLine;
            this.textBox9.Text += "***Product deatai" + Environment.NewLine;
            this.textBox9.Text += "Product id:" + comboBox3.Text + Environment.NewLine;
            this.textBox9.Text += "Product name:" + textBox5.Text + Environment.NewLine;
            this.textBox9.Text += "Product price:" + textBox6.Text + Environment.NewLine;
            this.textBox9.Text += "Product quantity:" + textBox7.Text + Environment.NewLine;
            this.textBox9.Text += "Total Price:" + textBox8.Text + Environment.NewLine;
            MessageBox.Show("Value edited......");

        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.oleDbConnection1.Open();

            OleDbCommand cmd = new OleDbCommand("Select * from  Products where Pid=@Pid ", f2.oleDbConnection1);
            cmd.Parameters.AddWithValue("@Pid", this.comboBox3.Text);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                textBox5.Text = dr["PName"].ToString();
                textBox6.Text = dr["BasePrice"].ToString();

            }
            f2.oleDbConnection1.Close();

        }


        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            }

        private void button5_Click(object sender, EventArgs e)
        {

            int c = 0;
            foreach (int p in pprice)
            {
                c += p + c;
            }
            f2.oleDbConnection1.Open();

            OleDbCommand cmd = new OleDbCommand("Insert into PO(VDept,POID,VID,VName,VContectPerson,VCPPH)values(@VDept,@POID,@VID,@VName,@VContectPerson,@VCPPH)", f2.oleDbConnection1);
            cmd.Parameters.AddWithValue("@VDept", comboBox2.Text);
            cmd.Parameters.AddWithValue("@POID", textBox4.Text);
            cmd.Parameters.AddWithValue("@VID", comboBox1.Text);
            cmd.Parameters.AddWithValue("@VName",textBox1.Text);
            cmd.Parameters.AddWithValue("@VContectPerson", textBox2.Text);
            cmd.Parameters.AddWithValue("@VCPPH", textBox3.Text);
            //cmd.Parameters.AddWithValue("@PPrice",s);


            for (int i = 0; i < counter; i++)
            {

                OleDbCommand cmdd= new OleDbCommand("Insert into POProducts(PModel,POID,PQty)values(@PModel,@POID,@PQty)", f2.oleDbConnection1);

                cmdd.Parameters.AddWithValue("@PModel", comboBox3.Text);
                cmdd.Parameters.AddWithValue("@POID", textBox4.Text);
                cmdd.Parameters.AddWithValue("@PQty", qty[i]);
                cmdd.ExecuteNonQuery();
            }
            MessageBox.Show("Data Has been Inserted");

            f2.oleDbConnection1.Close();
            
        }
    }
}
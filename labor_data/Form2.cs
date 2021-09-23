using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace labor_data
{
    public partial class Form2 : Form
    {

        int input;
        public static int ck, ck2,val;
        public Form2()
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox3.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox4.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
           
        }
        SqlCommand cmd = new SqlCommand();
       public static SqlConnection db_conect = new SqlConnection();
        SqlDataAdapter adopt = new SqlDataAdapter();
        DataTable dt_labor_data = new DataTable();
        //Data Source=DESKTOP-D8I8EQJ;Initial Catalog=rms_db;Integrated Security=True
        //string con_str = "Data Source =DESKTOP-D8I8EQJ;Initial Catalog=rms_db;Integrated Security=True";
        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;

        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Enter || e.KeyChar <= '.') //The  character represents a backspace
            {
                //e.Handled = false; //Do not reject the input
                input = 1;
             

            }
            else
            {
                //e.Handled = true; //Reject the input
                string message = "Please Enter Numeric Values Only";
                string title = "Alert";
                MessageBox.Show(message, title);
                input = 0;
            }
            if(e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txts1, txts4;
            string name = textBox1.Text;
            string str2 = "";
            string result = name.Replace("$", str2);
            result = result.Replace(",", str2);
            //result = result.Replace(".", str2);
            if (result.Contains("."))
            {
                string[] tokens = result.Split('.');
                txts1 = tokens[0];
            }
            else
            {
                txts1 = result;
            }

            string name1 = textBox4.Text;
            string str21 = "";
            string result1 = name1.Replace("$", str21);
            result1 = result1.Replace(",", str21);
            //result = result.Replace(".", str2);
            if (result1.Contains("."))
            {
                string[] tokens1 = result1.Split('.');
                txts4 = tokens1[0];
            }
            else
            {
                txts4 = result1;
            }


            ck = -1;
            ck2 = -1;
            label10.BackColor = System.Drawing.Color.Transparent;
            label11.BackColor = System.Drawing.Color.Transparent;
            label12.BackColor = System.Drawing.Color.Transparent;
            label13.BackColor = System.Drawing.Color.Transparent;
            label14.BackColor = System.Drawing.Color.Transparent;
            String annual_gross_rev = textBox1.Text;
            String annual_op_days = textBox2.Text;
            String daily_op_hours = textBox3.Text;
            String avrage_sale_receipt = textBox4.Text;
            if(input == 1)
            {
                double.TryParse(txts1, out double fagr);
                double.TryParse(textBox2.Text, out double faopd);
                double.TryParse(textBox3.Text, out double fdoph);
                double.TryParse(txts4, out double favg);

                double fdgr = fagr / faopd;
                double fhgr = fdgr / fdoph;
                double fhso = fhgr / favg;
                fhso = Math.Round(fhso, 0, MidpointRounding.AwayFromZero);
                double fdso = fhso * fdoph;
                fdso = Math.Round(fdso, 0, MidpointRounding.AwayFromZero);
                double faso = fdso * faopd;

                double dgr = Math.Round(fdgr, 0, MidpointRounding.AwayFromZero);
                double hgr = Math.Round(fhgr, 0, MidpointRounding.AwayFromZero);
                double hso = Math.Round(fhso, 0, MidpointRounding.AwayFromZero);
                double dso = Math.Round(fdso, 0, MidpointRounding.AwayFromZero);
                double aso = Math.Round(faso, 0, MidpointRounding.AwayFromZero);
               

                //hso= Math.Round(hso, 0, MidpointRounding.AwayFromZero);
                //double dso = hso * d_op_hrs;
                //dso = Math.Round(dso, 0, MidpointRounding.AwayFromZero);
                //double aso = dso * a_op_days ;
                //aso = Math.Round(aso, 0, MidpointRounding.AwayFromZero);

                bool fdgr_is_negative = dgr < 0;
                bool fhgr_is_negative = hgr < 0;
                bool fhso_is_negative = hso < 0;
                bool fdso_is_negative = dso < 0;
                bool faso_is_negative = aso < 0;

                if(fdgr_is_negative == false && fhgr_is_negative == false && fhso_is_negative == false && fdso_is_negative == false && faso_is_negative == false)
                {
                    label14.Text = dgr.ToString();
                    label14.Text = String.Format("{0:C0}", double.Parse(label14.Text));
                    label13.Text = hgr.ToString();
                    label13.Text = String.Format("{0:C0}", double.Parse(label13.Text));
                    label12.Text = hso.ToString();
                    label12.Text = String.Format("{0:N0}", double.Parse(label12.Text));
                    label11.Text = dso.ToString();
                    label11.Text = String.Format("{0:N0}", double.Parse(label11.Text));
                    label10.Text = aso.ToString();
                    label10.Text = String.Format("{0:N0}", double.Parse(label10.Text));
                }
                else
                {

                    label14.Text = dgr.ToString();
                    label13.Text = hgr.ToString();
                    label12.Text = hso.ToString();
                    label11.Text = dso.ToString();
                    label10.Text = aso.ToString();

                    if(fdgr_is_negative == true)
                    {
                        label14.Text = dgr.ToString();
                        label14.Text = String.Format("{0:C0}", double.Parse(label14.Text));
                        label14.BackColor = System.Drawing.Color.Red;
                    }
                    if (fhgr_is_negative == true)
                    {
                        label13.Text = hgr.ToString();
                        label13.Text = String.Format("{0:C0}", double.Parse(label13.Text));
                        label13.BackColor = System.Drawing.Color.Red;
                    }
                    if (fhso_is_negative == true)
                    {
                        label12.Text = hso.ToString();
                        label12.Text = String.Format("{0:N0}", double.Parse(label12.Text));
                        label12.BackColor = System.Drawing.Color.Red;
                    }
                    if (fdso_is_negative == true)
                    {
                        label11.Text = dso.ToString();
                        label11.Text = String.Format("{0:N0}", double.Parse(label11.Text));
                        label11.BackColor = System.Drawing.Color.Red;
                    }
                    if (faso_is_negative == true)
                    {
                        label10.Text = aso.ToString();
                        label10.Text = String.Format("{0:N0}", double.Parse(label10.Text));
                        label10.BackColor = System.Drawing.Color.Red;
                    }
                }

                cmd.Parameters.Clear();
                string qry = "insert into sales_volume_tb (anum_gross_rev,anum_op_days,daily_op_hrs,avg_sale_recpt,daily_gross_rev,hourly_gross_rev,hourly_sale_ord,daily_sale_ord,anum_sale_ord) VALUES (@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord) ";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd.Parameters.AddWithValue("@anum_gross_rev", textBox1.Text);
                cmd.Parameters.AddWithValue("@anum_op_days", textBox2.Text);
                cmd.Parameters.AddWithValue("@daily_op_hrs", textBox3.Text);
                cmd.Parameters.AddWithValue("@avg_sale_recpt", textBox4.Text);

                cmd.Parameters.AddWithValue("@daily_gross_rev", label14.Text);
                cmd.Parameters.AddWithValue("@hourly_gross_rev", label13.Text);
                cmd.Parameters.AddWithValue("@hourly_sale_ord", label12.Text);
                cmd.Parameters.AddWithValue("@daily_sale_ord", label11.Text);
                cmd.Parameters.AddWithValue("@anum_sale_ord", label10.Text);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    ck2 = 1;
                    //MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
                    //sales_volume_report crp = new sales_volume_report();
                    //crp.ShowDialog();
                    this.sales_volume_tbTableAdapter.Fill(this.sales_vol_data.sales_volume_tb);

                    this.reportViewer1.RefreshReport();
                    val = 1;
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                    ck2 = 0;
                }

            }
            else
            {
                string message = "Please Enter Numeric Values Only";
                string title = "Alert";
                MessageBox.Show(message, title);
            }

            //if(Regex.IsMatch(annual_gross_rev, @"^\d+$") && Regex.IsMatch(annual_op_days, @"^\d+$") && Regex.IsMatch(daily_op_hours, @"^\d+$") && Regex.IsMatch(avrage_sale_receipt, @"^\d+$"))
            //{
                //int a_g_rev = Convert.ToInt32(annual_gross_rev);
                //int a_op_days = Convert.ToInt32(annual_op_days);
                //int d_op_hrs = Convert.ToInt32(daily_op_hours);
                //int avg_sale_rec = Convert.ToInt32(avrage_sale_receipt);

                //float.TryParse(textBox1.Text, out float fagr);
                //float.TryParse(textBox2.Text, out float faopd);
               // float.TryParse(textBox3.Text, out float fdoph);
               // float.TryParse(textBox4.Text, out float favg);

                //float fdgr = fagr / faopd;
                //float fhgr = fdgr / fdoph;
                //float fhso = fhgr / favg;
                //float fdso = fhso * fdoph;
                //float faso = fdso * faopd;

                //float dgr = a_g_rev/a_op_days;
                //float hgr = dgr/d_op_hrs;
                //float hso = hgr/avg_sale_rec;
                //float dso = hso*d_op_hrs;
                //float aso = dso*a_op_days;

                //double dgr = a_g_rev / a_op_days;
                //dgr = Math.Round(dgr, 0, MidpointRounding.AwayFromZero);
                //double hgr = dgr / d_op_hrs;
                //hgr = Math.Round(hgr, 0, MidpointRounding.AwayFromZero);
                //double hso = hgr / avg_sale_rec;
                //hso= Math.Round(hso, 0, MidpointRounding.AwayFromZero);
                //double dso = hso * d_op_hrs;
                //dso = Math.Round(dso, 0, MidpointRounding.AwayFromZero);
                //double aso = dso * a_op_days ;
                //aso = Math.Round(aso, 0, MidpointRounding.AwayFromZero);



                //label14.Text = fdgr.ToString();
                //label13.Text = fhgr.ToString();
                //label12.Text = fhso.ToString();
                //label11.Text = fdso.ToString();
                //label10.Text = faso.ToString();

            //}
            //else
           // {
               // string message = "Please Enter Numeric Values Only";
               // string title = "Alert";
                //MessageBox.Show(message, title);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You sure you want to reset all fields? ", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                ck = -1;
                ck2 = -1;
                val = 0;
                label14.Text = "---";
                label13.Text = "---";
                label12.Text = "---";
                label11.Text = "---";
                label10.Text = "---";

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;

                label10.BackColor = System.Drawing.Color.Transparent;
                label11.BackColor = System.Drawing.Color.Transparent;
                label12.BackColor = System.Drawing.Color.Transparent;
                label13.BackColor = System.Drawing.Color.Transparent;
                label14.BackColor = System.Drawing.Color.Transparent;
                this.reportViewer1.Clear();
            }
               
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Wnat to Switch to Tool 1 ?", "Close Tool 2", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                db_conect.Close();
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
           
        }

        public static void contest()
        {
            try
            {
                if (db_conect.State != ConnectionState.Open)
                {
                    db_conect.ConnectionString = con_str;
                    db_conect.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sales_vol_data.sales_volume_tb' table. You can move, or remove it, as needed.
            //this.sales_volume_tbTableAdapter.Fill(this.sales_vol_data.sales_volume_tb);
            button7.Enabled = false;
            //db_conect.ConnectionString = con_str;
            //db_conect.Open();
            contest();
            ck = -1;
            ck2 = -1;
            val = 0;

           // this.reportViewer1.RefreshReport();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Wnat to Switch to Tool 3 ?", "Close Tool 2", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                db_conect.Close();
                Profit_Loss_Calculations f7 = new Profit_Loss_Calculations();
                f7.Show();
                this.Hide();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (ck == 1 || ck2==1)
            //{
            //    MessageBox.Show("Sucessfully Saved Data");

            //}
            //else
            //{
            //    if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
            //    {
            //        MessageBox.Show("Failed to Save Data");
            //    }
            //    else
            //    {
            //        cmd.Parameters.Clear();
            //        string qry = "insert into sales_volume_tb (anum_gross_rev,anum_op_days,daily_op_hrs,avg_sale_recpt,daily_gross_rev,hourly_gross_rev,hourly_sale_ord,daily_sale_ord,anum_sale_ord) VALUES (@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord) ";
            //        cmd.CommandText = qry;
            //        cmd.Connection = db_conect;
            //        //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
            //        cmd.Parameters.AddWithValue("@anum_gross_rev", textBox1.Text);
            //        cmd.Parameters.AddWithValue("@anum_op_days", textBox2.Text);
            //        cmd.Parameters.AddWithValue("@daily_op_hrs", textBox3.Text);
            //        cmd.Parameters.AddWithValue("@avg_sale_recpt", textBox4.Text);

            //        cmd.Parameters.AddWithValue("@daily_gross_rev", label14.Text);
            //        cmd.Parameters.AddWithValue("@hourly_gross_rev", label13.Text);
            //        cmd.Parameters.AddWithValue("@hourly_sale_ord", label12.Text);
            //        cmd.Parameters.AddWithValue("@daily_sale_ord", label11.Text);
            //        cmd.Parameters.AddWithValue("@anum_sale_ord", label10.Text);

            //        int rows = cmd.ExecuteNonQuery();
            //        if (rows > 0)
            //        {
            //            MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
            //            ck = 1;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Failed to Save Data");
            //            ck = 0;
            //        }
            //    }
            //}
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You want to Exit ?", "You are About to Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                db_conect.Close();
                System.Environment.Exit(1);

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                e.Cancel = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text != "")
            {
                string name = textBox1.Text;
                string str2 = "";
                string result = name.Replace("$", str2);
                result = result.Replace(",", str2);
                //result = result.Replace(".", str2);
                if (result.Contains("."))
                {
                    string[] tokens = result.Split('.');
                    textBox1.Text = tokens[0];
                }
                else
                {
                    textBox1.Text = result;
                }

                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
                if (e.KeyChar == (char)13)
                {
                    textBox1.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox1.Text));
                    //SendKeys.Send("{TAB}");
                }
                //if(e.KeyChar == (char)Keys.Tab)
                //{
                //    textBox1.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox1.Text));

                //}
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text != "")
            {
                string name1 = textBox4.Text;
                string str21 = "";
                string result1 = name1.Replace("$", str21);
                result1 = result1.Replace(",", str21);
                //result = result.Replace(".", str2);
                if (result1.Contains("."))
                {
                    string[] tokens1 = result1.Split('.');
                    textBox4.Text = tokens1[0];
                }
                else
                {
                    textBox4.Text = result1;
                }

                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
                if (e.KeyChar == (char)13 || e.KeyChar == (char)Keys.Tab)
                {
                    textBox4.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox4.Text));
                    //SendKeys.Send("{TAB}");
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (val == 1)
            {
                Form6 f6 = new Form6();
                f6.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Run Analysis First Then Press Save", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(this);
            f5.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if(ck==1 || ck2==1)
            //{
            //    sales_volume_report crp = new sales_volume_report();
            //    crp.ShowDialog();
            //}
            //else
            //{
            //    //print and save
            //    if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
            //    {
            //        MessageBox.Show("Failed to Save Data");
            //    }
            //    else
            //    {
            //        cmd.Parameters.Clear();
            //        string qry = "insert into sales_volume_tb (anum_gross_rev,anum_op_days,daily_op_hrs,avg_sale_recpt,daily_gross_rev,hourly_gross_rev,hourly_sale_ord,daily_sale_ord,anum_sale_ord) VALUES (@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord) ";
            //        cmd.CommandText = qry;
            //        cmd.Connection = db_conect;
            //        //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
            //        cmd.Parameters.AddWithValue("@anum_gross_rev", textBox1.Text);
            //        cmd.Parameters.AddWithValue("@anum_op_days", textBox2.Text);
            //        cmd.Parameters.AddWithValue("@daily_op_hrs", textBox3.Text);
            //        cmd.Parameters.AddWithValue("@avg_sale_recpt", textBox4.Text);

            //        cmd.Parameters.AddWithValue("@daily_gross_rev", label14.Text);
            //        cmd.Parameters.AddWithValue("@hourly_gross_rev", label13.Text);
            //        cmd.Parameters.AddWithValue("@hourly_sale_ord", label12.Text);
            //        cmd.Parameters.AddWithValue("@daily_sale_ord", label11.Text);
            //        cmd.Parameters.AddWithValue("@anum_sale_ord", label10.Text);

            //        int rows = cmd.ExecuteNonQuery();
            //        if (rows > 0)
            //        {
            //            ck2 = 1;
            //            //MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
            //            sales_volume_report crp = new sales_volume_report();
            //            crp.ShowDialog();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Failed to Save Data");
            //            ck2 = 0;
            //        }
            //    }
            //}
            
        }
    }
}

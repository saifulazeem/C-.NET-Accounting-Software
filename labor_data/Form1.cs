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
    public partial class Form1 : Form
    {
        public static DataTable table = new DataTable();
        public static DataTable labor_tb = new DataTable();
        public static SqlCommand cmd = new SqlCommand();
        public static SqlConnection db_conect = new SqlConnection();
        public static SqlDataAdapter adopt = new SqlDataAdapter();
        public static DataTable dt_drop = new DataTable();
        public static DataTable dt_drop_7 = new DataTable();
        public static int AOPH, AOD, DOH,input,chk,chk2,validate;
        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
        decimal AM_Anual_Wages, CREW_Anual_Wages, GM_Anual_Wages;
        Form2 f2 = new Form2();
        public static string anum_gross_rev, anum_op_days, daily_op_hrs, anum_op_hrs, am_no_labor, am_daily_hrs_worked, am_anum_days_worked,am_hourly_weg,am_anum_weg,crew_no_labor, crew_daily_hrs_worked, crew_anum_days_worked, crew_hourly_weg, crew_anum_weg,gm_no_labor, gm_daily_hrs_worked, gm_anum_days_worked, gm_hourly_weg, gm_anum_weg,total_anum_weg,txt14,txt15,txt16,txt1;

        private void button4_Click_1(object sender, EventArgs e)
        {
            if(validate==1)
            {
                Form4 f4 = new Form4();
                f4.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Run Analysis First Then Press Save", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(this);
            f3.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
            //DialogResult dialogResult = MessageBox.Show("Do You want to Leave Tool 1 You Might Lost Current Calculations ?", "You are About to Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dialogResult == DialogResult.Yes)
            //{
                //do something
                //Application.Exit();
                //if(e.CloseReason == CloseReason.UserClosing)
                //  {
                //      Application.Exit();
                //  }
                Form8 f8 = new Form8(this);
                f8.ShowDialog();
                //this.Hide();

            //}
           
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox15.Text != "")
            {
 
                string name2 = textBox15.Text;
                string str22 = "";
                string result2 = name2.Replace("$", str22);
                result2 = result2.Replace(",", str22);
                //result = result.Replace(".", str2);
                if (result2.Contains("."))
                {
                    string[] tokens2 = result2.Split('.');
                    textBox15.Text = tokens2[0];
                }
                else
                {
                    textBox15.Text = result2;
                }

                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
                if (e.KeyChar == (char)13)
                {
                    textBox15.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox15.Text));
                }
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox16.Text != "")
            {
                string name3 = textBox16.Text;
                string str23 = "";
                string result3 = name3.Replace("$", str23);
                result3 = result3.Replace(",", str23);
                //result = result.Replace(".", str2);
                if (result3.Contains("."))
                {
                    string[] tokens3 = result3.Split('.');
                    textBox16.Text= tokens3[0];
                }
                else
                {
                    textBox16.Text = result3;
                }

                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
                if (e.KeyChar == (char)13)
                {
                    textBox16.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox16.Text));
                }
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox14.Text != "")
            {
                string name1 = textBox14.Text;
                string str21 = "";
                string result1 = name1.Replace("$", str21);
                result1 = result1.Replace(",", str21);
                //result = result.Replace(".", str2);
                if (result1.Contains("."))
                {
                    string[] tokens1 = result1.Split('.');
                    textBox14.Text = tokens1[0];
                }
                else
                {
                    textBox14.Text = result1;
                }

                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
                if (e.KeyChar == (char)13)
                {
                    textBox14.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox14.Text));
                }
            }
        }

        //private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if(textBox1.Text != "")
        //    {
        //        string name = textBox1.Text;
        //        string str2 = "";
        //        string result = name.Replace("$", str2);
        //        result = result.Replace(",", str2);
        //        //result = result.Replace(".", str2);
        //        if (result.Contains("."))
        //        {
        //            string[] tokens = result.Split('.');
        //            textBox1.Text = tokens[0];
        //        }
        //        else
        //        {
        //            textBox1.Text = result;
        //        }
                  
        //        e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        //        if (e.KeyChar == (char)13)
        //        {
        //            textBox1.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox1.Text));
        //        }
        //    }
   
        //}

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You want to Exit ?", "You are About to Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                //Application.Exit();
                //if(e.CloseReason == CloseReason.UserClosing)
                //  {
                //      Application.Exit();
                //  }
                db_conect.Close();
                System.Environment.Exit(1);

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                e.Cancel = true;
            }

        }

       // SqlCommand cmd = new SqlCommand();
       //public static SqlConnection db_conect = new SqlConnection();
       // SqlDataAdapter adopt = new SqlDataAdapter();
        DataTable dt_labor_data = new DataTable();
        //Data Source=DESKTOP-D8I8EQJ;Initial Catalog=rms_db;Integrated Security=True
        // string con_str = "Data Source =DESKTOP-D8I8EQJ;Initial Catalog=rms_db;Integrated Security=True";
        //public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;
        //string con_str = ConfigurationManager.ConnectionStrings["DESKTOP-D8I8EQJ;Initial Catalog=rms_db;Integrated Security=True"];

        private void button7_Click(object sender, EventArgs e)
        {
            //Form8 f8 = new Form8();
            //f8.Show();
            //this.Hide();
            //database button
            //if(chk==1 || chk2==1)
            //{
            //    report rp = new report();
            //    rp.ShowDialog();

            //}
            //else
            //{
            //    if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox6.Text == "" && textBox7.Text == "" && textBox31.Text == "" && textBox21.Text == "" && textBox9.Text == "" && textBox10.Text == "" && textBox11.Text == "" && textBox12.Text == "" && textBox15.Text == "" && textBox14.Text == "" && textBox16.Text == "")
            //    {
            //        MessageBox.Show("Failed to Save Data and Print");
            //    }
            //    else
            //    {
            //        cmd.Parameters.Clear();
            //        string qry = "insert into labor_data_tb (annual_gross_revenue,annual_operating_days,daily_operating_hrs,annual_operating_hrs,am_no_labor,am_daily_hrs_worked,am_annual_days_worked,am_hourly_wages,am_annual_wages,crew_no_labor,crew_daily_hrs_worked,crew_annual_days_worked,crew_hourly_wages,crew_annual_wages,gm_no_labor,gm_daily_hrs_worked,gm_annual_days_worked,gm_hourly_wages,gm_annual_wages,total_annual_wages) VALUES (@annual_gross_revenue,@annual_operating_days,@daily_operating_hrs,@annual_operating_hrs,@am_no_labor,@am_daily_hrs_worked,@am_annual_days_worked,@am_hourly_wages,@am_annual_wages,@crew_no_labor,@crew_daily_hrs_worked,@crew_annual_days_worked,@crew_hourly_wages,@crew_annual_wages,@gm_no_labor,@gm_daily_hrs_worked,@gm_annual_days_worked,@gm_hourly_wages,@gm_annual_wages,@total_annual_wages) ";
            //        cmd.CommandText = qry;
            //        cmd.Connection = db_conect;
            //        cmd.Parameters.AddWithValue("@annual_gross_revenue", textBox1.Text);
            //        cmd.Parameters.AddWithValue("@annual_operating_days", textBox2.Text);
            //        cmd.Parameters.AddWithValue("@daily_operating_hrs", textBox3.Text);
            //        cmd.Parameters.AddWithValue("@annual_operating_hrs", label17.Text);
            //        //@am_no_labor,@am_daily_hrs_worked,@am_annual_days_worked,@am_hourly_wages,@am_annual_wages
            //        cmd.Parameters.AddWithValue("@am_no_labor", textBox6.Text);
            //        cmd.Parameters.AddWithValue("@am_daily_hrs_worked", textBox10.Text);
            //        cmd.Parameters.AddWithValue("@am_annual_days_worked", textBox11.Text);
            //        cmd.Parameters.AddWithValue("@am_hourly_wages", textBox16.Text);
            //        cmd.Parameters.AddWithValue("@am_annual_wages", label11.Text);

            //        cmd.Parameters.AddWithValue("@crew_no_labor", textBox4.Text);
            //        cmd.Parameters.AddWithValue("@crew_daily_hrs_worked", textBox9.Text);
            //        cmd.Parameters.AddWithValue("@crew_annual_days_worked", textBox12.Text);
            //        cmd.Parameters.AddWithValue("@crew_hourly_wages", textBox15.Text);
            //        cmd.Parameters.AddWithValue("@crew_annual_wages", label10.Text);

            //        cmd.Parameters.AddWithValue("@gm_no_labor", textBox21.Text);
            //        cmd.Parameters.AddWithValue("@gm_daily_hrs_worked", textBox31.Text);
            //        cmd.Parameters.AddWithValue("@gm_annual_days_worked", textBox7.Text);
            //        cmd.Parameters.AddWithValue("@gm_hourly_wages", textBox14.Text);
            //        cmd.Parameters.AddWithValue("@gm_annual_wages", label13.Text);

            //        cmd.Parameters.AddWithValue("@total_annual_wages", label9.Text);

            //        int rows = cmd.ExecuteNonQuery();
            //        if (rows > 0)
            //        {
            //            // MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
            //            chk2 = 1;
            //            report rp = new report();
            //            rp.ShowDialog();

            //        }
            //        else
            //        {
            //            MessageBox.Show("Failed to Save Data");
            //            chk2 = 0;
            //        }


            //    }
            //}
            


        }

        public Form1()
        {
            InitializeComponent();
            //textBox1.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox3.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox4.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox6.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox7.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox21.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox31.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox9.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox10.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox11.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox12.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox14.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox15.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox16.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            comboBox1.KeyDown += new KeyEventHandler(tb_KeyDown);
            comboBox2.KeyDown += new KeyEventHandler(tb_KeyDown);


        }



        static void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                SendKeys.Send("{TAB}");
            }
        }

        //public void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        //    if(e.KeyChar==(char)13)
        //    {
        //        textBox2.Text = string.Format("{0:n0}", double.Parse(textBox2.Text));
        //    }
        //}

        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Enter || e.KeyChar <= '.' ) //The  character represents a backspace
            {
                //e.Handled = false; //Do not reject the input
                input = 1;
                //textBox2.Text = string.Format("{0:n0}", double.Parse(textBox2.Text));
                //textBox2.Text = String.Format("{0:C2}",double.Parse(textBox2.Text));

            }
            else
            {
                //e.Handled = true; //Reject the input
                string message = "Please Enter Numeric Values Only";
                string title = "Alert";
                MessageBox.Show(message, title);
                input = 0;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

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

        public static void fill_listbox()
        {
            string qry = "select * From dropdowns_tb WHERE dropdown6 IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(dt_drop);

            string qrys = "select * From dropdowns_tb WHERE dropdown7 IS NOT NULL";
            cmd.CommandText = qrys;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(dt_drop_7);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'labor_dataset.labor_data_tb' table. You can move, or remove it, as needed.
            //this.labor_data_tbTableAdapter.Fill(this.labor_dataset.labor_data_tb);

            label17.Text = "---";
            label9.Text = "---";
            label10.Text = "---";
            label11.Text = "---";
            label13.Text = "---";
            validate = 0;
            chk = -1;
            chk2 = -1;
            //comboBox1.Items.Clear();
            //comboBox1.Items.Add("A");
            //comboBox1.Items.Add("B");
            //comboBox1.Items.Add("C");
            //comboBox1.Items.Add("D");
            button10.Enabled = false;
            dt_drop.Clear();
            dt_drop_7.Clear();
            contest();
            fill_listbox();
            comboBox1.DataSource = dt_drop;
            comboBox1.DisplayMember = "dropdown6";
            //comboBox1.Text = "Please Select...";
            comboBox1.Text = "Labor Model";
            //this.reportViewer1.RefreshReport();


            comboBox2.DataSource = dt_drop_7;
            comboBox2.DisplayMember = "dropdown7";
            comboBox2.Text = "Please Select";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
       
        }
    

            private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You sure you want to reset all fields? ", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                label17.Text = "---";
                label9.Text = "---";
                label10.Text = "---";
                label11.Text = "---";
                label13.Text = "---";
                validate = 0;
                //textBox1.Text = null;
                textBox2.Text = null;
                comboBox1.Text = "Labor Model";
                textBox3.Text = null;
                textBox4.Text = null;
                textBox21.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;
                textBox31.Text = null;
                textBox9.Text = null;
                textBox10.Text = null;
                textBox11.Text = null;
                textBox12.Text = null;
                textBox16.Text = null;
                textBox14.Text = null;
                textBox15.Text = null;
                comboBox2.Text = "Please Select";
                chk2 = -1;
                chk = -1;

                label13.BackColor = System.Drawing.Color.Transparent;
                label10.BackColor = System.Drawing.Color.Transparent;
                label11.BackColor = System.Drawing.Color.Transparent;
                label9.BackColor = System.Drawing.Color.Transparent;
                label17.BackColor = System.Drawing.Color.Transparent;
                //this.reportViewer1.RefreshReport();
                this.reportViewer1.Clear();
            }
            //else if (dialogResult == DialogResult.No)
            //{
            //    //do something else
            //}
         
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Wnat to Switch to Tool 3 ?", "Close Tool 1", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                db_conect.Close();
                Profit_Loss_Calculations f7 = new Profit_Loss_Calculations();
                f7.Show();
                this.Hide();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //if(chk2==1 || chk==1)
            //{
            //    MessageBox.Show("Sucessfully Saved Data");
            //}
            //else
            //{
            //    //database button
            //    if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox6.Text == "" && textBox7.Text == "" && textBox31.Text == "" && textBox21.Text == "" && textBox9.Text == "" && textBox10.Text == "" && textBox11.Text == "" && textBox12.Text == "" && textBox15.Text == "" && textBox14.Text == "" && textBox16.Text == "")
            //    {
            //        MessageBox.Show("Failed to Save Data");
            //    }
            //    else
            //    {
            //        cmd.Parameters.Clear();
            //        string qry = "insert into labor_data_tb (annual_gross_revenue,annual_operating_days,daily_operating_hrs,annual_operating_hrs,am_no_labor,am_daily_hrs_worked,am_annual_days_worked,am_hourly_wages,am_annual_wages,crew_no_labor,crew_daily_hrs_worked,crew_annual_days_worked,crew_hourly_wages,crew_annual_wages,gm_no_labor,gm_daily_hrs_worked,gm_annual_days_worked,gm_hourly_wages,gm_annual_wages,total_annual_wages) VALUES (@annual_gross_revenue,@annual_operating_days,@daily_operating_hrs,@annual_operating_hrs,@am_no_labor,@am_daily_hrs_worked,@am_annual_days_worked,@am_hourly_wages,@am_annual_wages,@crew_no_labor,@crew_daily_hrs_worked,@crew_annual_days_worked,@crew_hourly_wages,@crew_annual_wages,@gm_no_labor,@gm_daily_hrs_worked,@gm_annual_days_worked,@gm_hourly_wages,@gm_annual_wages,@total_annual_wages) ";
            //        cmd.CommandText = qry;
            //        cmd.Connection = db_conect;
            //        cmd.Parameters.AddWithValue("@annual_gross_revenue", textBox1.Text);
            //        cmd.Parameters.AddWithValue("@annual_operating_days", textBox2.Text);
            //        cmd.Parameters.AddWithValue("@daily_operating_hrs", textBox3.Text);
            //        cmd.Parameters.AddWithValue("@annual_operating_hrs", label17.Text);
            //        //@am_no_labor,@am_daily_hrs_worked,@am_annual_days_worked,@am_hourly_wages,@am_annual_wages
            //        cmd.Parameters.AddWithValue("@am_no_labor", textBox6.Text);
            //        cmd.Parameters.AddWithValue("@am_daily_hrs_worked", textBox10.Text);
            //        cmd.Parameters.AddWithValue("@am_annual_days_worked", textBox11.Text);
            //        cmd.Parameters.AddWithValue("@am_hourly_wages", textBox16.Text);
            //        cmd.Parameters.AddWithValue("@am_annual_wages", label11.Text);

            //        cmd.Parameters.AddWithValue("@crew_no_labor", textBox4.Text);
            //        cmd.Parameters.AddWithValue("@crew_daily_hrs_worked", textBox9.Text);
            //        cmd.Parameters.AddWithValue("@crew_annual_days_worked", textBox12.Text);
            //        cmd.Parameters.AddWithValue("@crew_hourly_wages", textBox15.Text);
            //        cmd.Parameters.AddWithValue("@crew_annual_wages", label10.Text);

            //        cmd.Parameters.AddWithValue("@gm_no_labor", textBox21.Text);
            //        cmd.Parameters.AddWithValue("@gm_daily_hrs_worked", textBox31.Text);
            //        cmd.Parameters.AddWithValue("@gm_annual_days_worked", textBox7.Text);
            //        cmd.Parameters.AddWithValue("@gm_hourly_wages", textBox14.Text);
            //        cmd.Parameters.AddWithValue("@gm_annual_wages", label13.Text);

            //        cmd.Parameters.AddWithValue("@total_annual_wages", label9.Text);



            //        int rows = cmd.ExecuteNonQuery();
            //        if (rows > 0)
            //        {
            //            MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
            //            chk = 1;

            //        }
            //        else
            //        {
            //            MessageBox.Show("Failed to Save Data");
            //            chk = 0;
            //        }


            //    }
            //}
            
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Wnat to Switch to Tool 2 ?", "Close Tool 1", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                db_conect.Close();
                f2.Show();
                this.Hide();
            }
          
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ////button 3
       

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" || comboBox2.Text == "Please Select" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Some Required Feilds Are Missing", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                    int am_is_on, crew_is_on, gm_is_on;

                    //string name = textBox1.Text;
                    //string str2 = "";
                    //string result = name.Replace("$", str2);
                    //result = result.Replace(",", str2);
                    ////result = result.Replace(".", str2);
                    //if (result.Contains("."))
                    //{
                    //    string[] tokens = result.Split('.');
                    //    txt1 = tokens[0];
                    //}
                    //else
                    //{
                    //    txt1 = result;
                    //}

                    string name1 = textBox14.Text;
                    string str21 = "";
                    string result1 = name1.Replace("$", str21);
                    result1 = result1.Replace(",", str21);
                    //result = result.Replace(".", str2);
                    if (result1.Contains("."))
                    {
                        string[] tokens1 = result1.Split('.');
                        txt14 = tokens1[0];
                    }
                    else
                    {
                        txt14 = result1;
                    }

                    string name2 = textBox15.Text;
                    string str22 = "";
                    string result2 = name2.Replace("$", str22);
                    result2 = result2.Replace(",", str22);
                    //result = result.Replace(".", str2);
                    if (result2.Contains("."))
                    {
                        string[] tokens2 = result2.Split('.');
                        txt15 = tokens2[0];
                    }
                    else
                    {
                        txt15 = result2;
                    }

                    string name3 = textBox16.Text;
                    string str23 = "";
                    string result3 = name3.Replace("$", str23);
                    result3 = result3.Replace(",", str23);
                    //result = result.Replace(".", str2);
                    if (result3.Contains("."))
                    {
                        string[] tokens3 = result3.Split('.');
                        txt16 = tokens3[0];
                    }
                    else
                    {
                        txt16 = result3;
                    }


                    chk = -1;
                    chk2 = -1;
                    label13.BackColor = System.Drawing.Color.Transparent;
                    label10.BackColor = System.Drawing.Color.Transparent;
                    label11.BackColor = System.Drawing.Color.Transparent;
                    label9.BackColor = System.Drawing.Color.Transparent;
                    label17.BackColor = System.Drawing.Color.Transparent;
                    String Chek_val1 = textBox2.Text;
                    String Chek_val2 = textBox3.Text;
                    //String Chek_val3 = txt1;

                    //AM
                    label11.Text = "---";
                    String no_of_labours = textBox6.Text;
                    String daily_hrs_worked = textBox10.Text;
                    String annual_days_worked = textBox11.Text;
                    String hourly_wages = txt16;
                    //bool hwisNumber = int.TryParse(hourly_wages, out int hw);
                    //bool wageisFlost = float.TryParse(textBox16.Text, out float wf);

                    if (textBox6.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox16.Text != "")
                    {
                        //int nol = Convert.ToInt32(textBox6.Text);
                        //int dhi = Convert.ToInt32(textBox10.Text);
                        //int adi = Convert.ToInt32(textBox11.Text);

                        decimal.TryParse(textBox6.Text, out decimal nol);
                        decimal.TryParse(textBox10.Text, out decimal dhi);
                        decimal.TryParse(textBox11.Text, out decimal adi);
                        decimal.TryParse(txt16, out decimal hws);

                        AM_Anual_Wages = nol * dhi * adi * hws;
                        am_is_on = 1;

                        bool AM_Anual_wages_is_negative = AM_Anual_Wages < 0;
                        if (AM_Anual_wages_is_negative == false)
                        {
                            //label11.Text = AM_Anual_Wages + "$".ToString();
                            label11.Text = Convert.ToString(AM_Anual_Wages);
                            label11.Text = String.Format("{0:C0}", double.Parse(label11.Text));
                        }
                        else
                        {

                            label11.Text = Convert.ToString(AM_Anual_Wages);
                            label11.Text = String.Format("{0:C0}", double.Parse(label11.Text));
                            label11.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        //string message = "Please Enter Numeric Values Only";
                        //string title = "Alert";
                        //MessageBox.Show(message, title);
                       
                        AM_Anual_Wages = 0;
                        am_is_on = 0;
                    }

                    //crew...
                    label10.Text = "---";
                    String no_of_crw_labours = textBox4.Text;
                    String crw_daily_hrs_worked = textBox9.Text;
                    String crw_annual_days_worked = textBox12.Text;
                    String crw_hourly_wages = txt15;
                    //bool crw_hwisNumber = int.TryParse(crw_hourly_wages, out int crwhw);
                    //bool crw_wageisFlost = float.TryParse(textBox15.Text, out float crwf);

                    if (textBox4.Text != "" && textBox9.Text != "" && textBox12.Text != "" && textBox15.Text != "")
                    {
                        decimal.TryParse(textBox4.Text, out decimal crw_nol);
                        decimal.TryParse(textBox9.Text, out decimal crw_dhi);
                        decimal.TryParse(textBox12.Text, out decimal crw_adi);
                        decimal.TryParse(txt15, out decimal crw_hws);

                        CREW_Anual_Wages = crw_nol * crw_dhi * crw_adi * crw_hws;
                        crew_is_on = 1;
                        bool CREW_Anual_wages_is_negative = CREW_Anual_Wages < 0;
                        if (CREW_Anual_wages_is_negative == false)
                        {
                            // label10.Text = CREW_Anual_Wages + "$".ToString();

                            label10.Text = Convert.ToString(CREW_Anual_Wages);
                            label10.Text = String.Format("{0:C0}", double.Parse(label10.Text));
                        }
                        else
                        {
                            //label10.Text = CREW_Anual_Wages + "$".ToString();
                            label10.Text = Convert.ToString(CREW_Anual_Wages);
                            label10.Text = String.Format("{0:C0}", double.Parse(label10.Text));
                            label10.BackColor = System.Drawing.Color.Red;
                        }

                    }
                    else
                    {
                        //string message = "Please Enter Numeric Values Only";
                        //string title = "Alert";
                        //MessageBox.Show(message, title);
                      
                        CREW_Anual_Wages = 0;
                        crew_is_on = 0;
                    }

                    //GM///
                    label13.Text = "---";
                    String no_of_gm_labours = textBox21.Text;
                    String gm_daily_hrs_worked = textBox31.Text;
                    String gm_annual_days_worked = textBox7.Text;
                    String gm_hourly_wages = txt14;
                    //bool gm_hwisNumber = int.TryParse(gm_hourly_wages, out int gmhw);
                    //bool gm_wageisFlost = float.TryParse(textBox14.Text, out float gmf);

                    if (textBox21.Text != "" && textBox31.Text != "" && textBox7.Text != "" && textBox14.Text != "")
                    {
                        decimal.TryParse(textBox21.Text, out decimal gm_nol);
                        decimal.TryParse(textBox31.Text, out decimal gm_dhi);
                        decimal.TryParse(textBox7.Text, out decimal gm_adi);
                        decimal.TryParse(txt14, out decimal gm_hws);

                        GM_Anual_Wages = gm_nol * gm_dhi * gm_adi * gm_hws;
                        gm_is_on = 1;
                        bool GM_Anual_wages_is_negative = GM_Anual_Wages < 0;
                        if (GM_Anual_wages_is_negative == false)
                        {
                            //label13.Text = GM_Anual_Wages + "$".ToString();
                            label13.Text = Convert.ToString(GM_Anual_Wages);
                            label13.Text = String.Format("{0:C0}", double.Parse(label13.Text));
                        }
                        else
                        {
                            // label13.Text = GM_Anual_Wages + "$".ToString();
                            label13.Text = Convert.ToString(GM_Anual_Wages);
                            label13.Text = String.Format("{0:C0}", double.Parse(label13.Text));
                            label13.BackColor = System.Drawing.Color.Red;
                        }

                    }
                    else
                    {
                        //string message = "Please Enter Numeric Values Only";
                        //string title = "Alert";
                        //MessageBox.Show(message, title);
                       
                        GM_Anual_Wages = 0;
                        gm_is_on = 0;
                    }

                    if (am_is_on == 1 || gm_is_on == 1 || crew_is_on==1)
                    {
                        if(am_is_on==0)
                        {
                            textBox6.Text = null;
                            textBox10.Text = null;
                            textBox11.Text = null;
                            textBox16.Text = null;
                            label11.Text = "---";
                        }
                        if (gm_is_on == 0)
                        {
                            textBox21.Text = null;
                            textBox31.Text = null;
                            textBox7.Text = null;
                            textBox14.Text = null;
                            label13.Text = "---";
                        }
                        if (crew_is_on == 0)
                        {
                            textBox4.Text = null;
                            textBox9.Text = null;
                            textBox12.Text = null;
                            textBox15.Text = null;
                            label10.Text = "---";
                        }

                        //bool isNumber = int.TryParse(Chek_val3, out int ng);
                        //if (isNumber == true)
                        //{
                        //    //label1.Text = "ITs a Number";
                        //    int AGR = Convert.ToInt32(txt1);
                        //    //if (AGR < 100000 || AGR > 300000)
                        //    //{
                        //    //    string message = "Please Enter Annual Gross Revenue Value between Range(100,000 - 300,000) Only";
                        //    //    string title = "Alert";
                        //    //    MessageBox.Show(message, title);
                        //    //}
                        //}
                        //else
                        //{
                        //    bool isFlost = float.TryParse(Chek_val3, out float f);
                        //    if (isFlost == true)
                        //    {
                        //        //label1.Text = "ITs a Float";
                        //    }
                        //    else
                        //    {
                        //        //label1.Text = "ITs not a Number";
                        //    }

                        //}
                        if (Regex.IsMatch(Chek_val1, @"^\d+$") && Regex.IsMatch(Chek_val2, @"^\d+$"))
                        {
                            AOD = Convert.ToInt32(textBox2.Text);
                            DOH = Convert.ToInt32(textBox3.Text);
                            AOPH = AOD * DOH;
                            bool aoph_neg = AOPH < 0;
                            if (aoph_neg == false)
                            {
                                label17.Text = AOPH.ToString();
                                string aophr = String.Format("{0:N0}", double.Parse(label17.Text));
                                label17.Text = aophr + " hrs";
                            }
                            else
                            {
                                label17.Text = AOPH + " hrs".ToString();
                                string aophr = String.Format("{0:N0}", double.Parse(label17.Text));
                                label17.Text = aophr + " hrs";
                                label17.BackColor = System.Drawing.Color.Red;
                            }

                            decimal Total = AM_Anual_Wages + CREW_Anual_Wages + GM_Anual_Wages;

                            bool total_neg = Total < 0;
                            if (total_neg == false)
                            {
                                //label9.Text = Total + "$".ToString();
                                label9.Text = Convert.ToString(Total);
                                label9.Text = String.Format("{0:C0}", double.Parse(label9.Text));
                            }
                            else
                            {
                                //label9.Text = Total + "$".ToString();
                                label9.Text = Convert.ToString(Total);
                                label9.Text = String.Format("{0:C0}", double.Parse(label9.Text));
                                label9.BackColor = System.Drawing.Color.Red;
                            }

                            AOPH = 0;
                            AM_Anual_Wages = 0;
                            CREW_Anual_Wages = 0;
                            GM_Anual_Wages = 0;

                            cmd.Parameters.Clear();
                            string qry = "insert into labor_data_tb (annual_gross_revenue,annual_operating_days,daily_operating_hrs,annual_operating_hrs,am_no_labor,am_daily_hrs_worked,am_annual_days_worked,am_hourly_wages,am_annual_wages,crew_no_labor,crew_daily_hrs_worked,crew_annual_days_worked,crew_hourly_wages,crew_annual_wages,gm_no_labor,gm_daily_hrs_worked,gm_annual_days_worked,gm_hourly_wages,gm_annual_wages,total_annual_wages,dpdw2) VALUES (@annual_gross_revenue,@annual_operating_days,@daily_operating_hrs,@annual_operating_hrs,@am_no_labor,@am_daily_hrs_worked,@am_annual_days_worked,@am_hourly_wages,@am_annual_wages,@crew_no_labor,@crew_daily_hrs_worked,@crew_annual_days_worked,@crew_hourly_wages,@crew_annual_wages,@gm_no_labor,@gm_daily_hrs_worked,@gm_annual_days_worked,@gm_hourly_wages,@gm_annual_wages,@total_annual_wages,@dpdw2) ";
                            cmd.CommandText = qry;
                            cmd.Connection = db_conect;
                            cmd.Parameters.AddWithValue("@annual_gross_revenue", comboBox2.Text);
                            cmd.Parameters.AddWithValue("@annual_operating_days", textBox2.Text);
                            cmd.Parameters.AddWithValue("@daily_operating_hrs", textBox3.Text);
                            cmd.Parameters.AddWithValue("@annual_operating_hrs", label17.Text);
                            //@am_no_labor,@am_daily_hrs_worked,@am_annual_days_worked,@am_hourly_wages,@am_annual_wages
                            cmd.Parameters.AddWithValue("@am_no_labor", textBox6.Text);
                            cmd.Parameters.AddWithValue("@am_daily_hrs_worked", textBox10.Text);
                            cmd.Parameters.AddWithValue("@am_annual_days_worked", textBox11.Text);
                            cmd.Parameters.AddWithValue("@am_hourly_wages", textBox16.Text);
                            cmd.Parameters.AddWithValue("@am_annual_wages", label11.Text);

                            cmd.Parameters.AddWithValue("@crew_no_labor", textBox4.Text);
                            cmd.Parameters.AddWithValue("@crew_daily_hrs_worked", textBox9.Text);
                            cmd.Parameters.AddWithValue("@crew_annual_days_worked", textBox12.Text);
                            cmd.Parameters.AddWithValue("@crew_hourly_wages", textBox15.Text);
                            cmd.Parameters.AddWithValue("@crew_annual_wages", label10.Text);

                            cmd.Parameters.AddWithValue("@gm_no_labor", textBox21.Text);
                            cmd.Parameters.AddWithValue("@gm_daily_hrs_worked", textBox31.Text);
                            cmd.Parameters.AddWithValue("@gm_annual_days_worked", textBox7.Text);
                            cmd.Parameters.AddWithValue("@gm_hourly_wages", textBox14.Text);
                            cmd.Parameters.AddWithValue("@gm_annual_wages", label13.Text);

                            cmd.Parameters.AddWithValue("@total_annual_wages", label9.Text);
                            cmd.Parameters.AddWithValue("@dpdw2", comboBox1.Text);

                        //SqlCommand command = new SqlCommand(qry, db_conect);
                        //command.Parameters.Add("@annual_gross_revenue", "");
                        //command.Parameters.Add("@username", "abc");
                        //command.Parameters.Add("@password", "abc");
                        //command.Parameters.Add("@email", "abc");

                        int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                chk2 = 1;
                                //report rp = new report();
                                //rp.ShowDialog();
                                this.labor_data_tbTableAdapter.Fill(this.labor_dataset.labor_data_tb);
                                this.reportViewer1.RefreshReport();
                                validate = 1;

                            }
                            else
                            {
                                MessageBox.Show("Failed to Save Data");
                                chk2 = 0;
                            }


                        }
                        else
                        {
                            string message = "Please Enter Numberic Valus Only";
                            string title = "Alert";
                            MessageBox.Show(message, title);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Some Required Feilds Are Missing", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }
    }
}

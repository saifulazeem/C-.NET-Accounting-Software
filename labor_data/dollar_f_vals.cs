﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace labor_data
{
    public partial class dollar_f_vals : Form
    {
        int z = 1, input;
        
        public static int pointXX, pointX, pointY, txtno;
        public static int pointYY, point_XX, point_YY;
        public static double g_per, gg_per, dol_ff, f_dols;
        public static String gs,cbxitem,tb1, pgg;

        public static SqlCommand cmd = new SqlCommand();
        public static SqlConnection db_conect = new SqlConnection();
        public static SqlDataAdapter adopt = new SqlDataAdapter();
        public static DataTable cbx_data = new DataTable();
        public static DataTable fg_data_dt = new DataTable();



        //string con_str = "Data Source =DESKTOP-D8I8EQJ;Initial Catalog=rms_db;Integrated Security=True";
        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt1.Text != "")
            {
                string name = txt1.Text;
                string str2 = "";
                string result = name.Replace("$", str2);
                result = result.Replace(",", str2);
                //result = result.Replace(".", str2);
                if (result.Contains("."))
                {
                    string[] tokens = result.Split('.');
                    txt1.Text = tokens[0];
                }
                else
                {
                    txt1.Text = result;
                }

                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
                if (e.KeyChar == (char)13)
                {
                   //tb1 = txt1.Text;
                    txt1.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(txt1.Text));
                    //SendKeys.Send("{TAB}");
                }
            }
        }
        Profit_Loss_Calculations profss;

        private void dollar_f_vals_FormClosing(object sender, FormClosingEventArgs e)
        {
            //database
            //cmd.Parameters.Clear();
            //string qry = "UPDATE reused_values_tb SET key_status='5' WHERE key_status='0'";
            //cmd.CommandText = qry;
            //cmd.Connection = db_conect;
            //int rows = cmd.ExecuteNonQuery();

            //Update
            dol_ff = Math.Round(dol_ff, 0, MidpointRounding.AwayFromZero);
            bool dol_f_negative = dol_ff < 0;
            if (dol_f_negative == false)
            {
                string dfss = dol_ff.ToString();
                string pergss = gg_per.ToString();
                dfss = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(dfss));
                pergss = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(pergss));
                profss.label16.Text = dfss + "   |   " + pergss;
                //profss.label19.Text = dol_ff.ToString();
                profss.label16.BackColor = System.Drawing.Color.Transparent;
                //profss.label19.BackColor = System.Drawing.Color.Transparent;
            }
            else
            {
                string dfss = dol_ff.ToString();
                string pergss = gg_per.ToString();
                dfss = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(dfss));
                pergss = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(pergss));
                profss.label16.Text = dfss + "   |   " + pergss;
                //profss.label19.Text = dol_ff.ToString();
                // profss.label19.Text = dol_ff.ToString();
                profss.label16.BackColor = System.Drawing.Color.Red;
                //profss.label19.BackColor = System.Drawing.Color.Red;
            }
            //profss.textBox4.Enabled = false;

            //database
            cmd.Parameters.Clear();
            string qry = "UPDATE reused_values_tb SET key_status='1' WHERE key_status='0'";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            int rows = cmd.ExecuteNonQuery();
            this.Hide();

        }

        public dollar_f_vals(Profit_Loss_Calculations prof)
        {
            InitializeComponent();
            //textBox1.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            txt1.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            profss = prof;
            button2.Click += new EventHandler(button2_Click_1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dol_ff = Math.Round(dol_ff, 0, MidpointRounding.AwayFromZero);
          
            bool dol_f_negative = dol_ff < 0;
            if (dol_f_negative == false)
            {
                string dfss = dol_ff.ToString();
                string pergss = gg_per.ToString();
                dfss = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(dfss));
                pergss = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(pergss));
                profss.label16.Text = dfss + "   |   " + pergss;
                //profss.label19.Text = dol_ff.ToString();
                profss.label16.BackColor = System.Drawing.Color.Transparent;
                //profss.label19.BackColor = System.Drawing.Color.Transparent;
            }
            else
            {
                string dfss = dol_ff.ToString();
                string pergss = gg_per.ToString();
                dfss = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(dfss));
                pergss = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(pergss));
                profss.label16.Text = dfss + "   |   " + pergss;
                //profss.label19.Text = dol_ff.ToString();
                // profss.label19.Text = dol_ff.ToString();
                profss.label16.BackColor = System.Drawing.Color.Red;
                //profss.label19.BackColor = System.Drawing.Color.Red;
            }
            //profss.textBox4.Enabled = false;

            //database
            cmd.Parameters.Clear();
            string qry = "UPDATE reused_values_tb SET key_status='1' WHERE key_status='0'";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            int rows = cmd.ExecuteNonQuery();
            this.Hide();
            //Update

        }
        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Enter || e.KeyChar == '.' ) //The  character represents a backspace
            {
              
                input = 1;

            }
            else
            {
                //e.Handled = true; //Reject the input
                string message = "Please Enter Numeric Values Only For Gross Sales";
                string title = "Alert";
                MessageBox.Show(message, title);
                input = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                //txtno = int.Parse(txt1.Text);
                
                //panel1.Controls.Clear();
                for (int i = 0; i < 1; i++)
                {
                    TextBox a = new TextBox();
                    Label mylab = new Label();
                    Label cbxlabel = new Label();

                    //a.Text = (i + 1).ToString();



                    //gs = textBox1.Text;
                    cbxitem = comboBox2.Text;
                    if(gs =="" || cbxitem== "Item name" || cbxitem == "" || gs == null)
                    {
                        MessageBox.Show("Missing Item Name OR Gross Sale Value From Sales Revenue ","Alert",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        //mylab.Text = "G% : ----";
                    }
                    else
                    {
                        tb1 = txt1.Text;
                        string str2 = "";
                        tb1 = tb1.Replace("$", str2);
                        tb1 = tb1.Replace(",", str2);
                        tb1 = tb1.Replace(".", str2);
                        a.Text = txt1.Text;
                        a.Enabled = false;
                        cbxlabel.Text = cbxitem;
                        bool gs_isFlost = double.TryParse(gs, out double gs_val);
                        bool textbx_isFlost = double.TryParse(tb1, out  f_dols);
                        g_per = f_dols / gs_val;
                       g_per = g_per*100;
                        //g_per = Math.Round(g_per, 0, MidpointRounding.AwayFromZero);
                        bool percent_g_negative = g_per < 0;

                        if(percent_g_negative == false)
                        {
                            mylab.Text = g_per.ToString();
                            //mylab.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(mylab.Text));
                        }
                        else
                        {
                            mylab.Text = g_per.ToString();
                            //mylab.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(mylab.Text));
                            mylab.BackColor = System.Drawing.Color.Red;
                        }


                        //database
                        cmd.Parameters.Clear();
                        string qry = "INSERT INTO reused_values_tb (dollars_f,percent_g,item_name) VALUES (@dol_f,@percent_g,@itm) ";
                        cmd.CommandText = qry;
                        cmd.Connection = db_conect;
                        //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                        cmd.Parameters.AddWithValue("@dol_f", txt1.Text);
                        cmd.Parameters.AddWithValue("@percent_g", mylab.Text);
                        cmd.Parameters.AddWithValue("@itm", cbxlabel.Text);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            //MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
                        }
                        else
                        {
                            MessageBox.Show("Failed to Save Data");
                        }
                        //save

                        mylab.Location = new Point(point_XX, point_YY);
                        a.Location = new Point(pointXX, pointYY);
                        cbxlabel.Location = new Point(pointX, pointY);
                        //mygval = mylab.Text;
                        panel1.Controls.Add(a);
                        panel1.Controls.Add(mylab);
                        panel1.Controls.Add(cbxlabel);
                        panel1.Show();
                        pointY += 25;
                        pointYY += 25;
                        point_YY += 25;

                        //gg_per = g_per + f_dols;
                        if (z == 1)
                        {
                            dol_ff = f_dols;
                            gg_per = g_per;
                            dol_ff = Math.Round(dol_ff, 0, MidpointRounding.AwayFromZero);
                            bool dol_f_negative = dol_ff < 0;
                            if (dol_f_negative == false)
                            {
                                //label5.Text = dol_ff.ToString();
                                //label6.Text = gg_per.ToString();
                                //label5.BackColor = System.Drawing.Color.Transparent;
                                //label6.BackColor = System.Drawing.Color.Transparent;
                                //label5.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label5.Text));
                                //label6.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label6.Text));

                                string f1 = dol_ff.ToString();
                                string g1 = gg_per.ToString();
                                label5.BackColor = System.Drawing.Color.Transparent;
                                f1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(f1));
                                g1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(g1));
                                label5.Text = f1 + "   |   " + g1;

                            }
                            else
                            {
                                //label5.Text = dol_ff.ToString();
                                //label6.Text = gg_per.ToString();
                                //label5.BackColor = System.Drawing.Color.Red;
                                //label6.BackColor = System.Drawing.Color.Red;
                                //label5.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label5.Text));
                                //label6.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label6.Text));

                                string f1 = dol_ff.ToString();
                                string g1 = gg_per.ToString();
                                label5.BackColor = System.Drawing.Color.Transparent;
                                f1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(f1));
                                g1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(g1));
                                label5.Text = f1 + "   |   " + g1;
                            }

                        }
                        else
                        {
                            dol_ff = f_dols + dol_ff;
                            gg_per = g_per+gg_per;
                            dol_ff = Math.Round(dol_ff, 0, MidpointRounding.AwayFromZero);
                            bool dol_f_negative = dol_ff < 0;
                            if (dol_f_negative == false)
                            {
                                //label5.Text = dol_ff.ToString();
                                //label6.Text = gg_per.ToString();
                                //label5.BackColor = System.Drawing.Color.Transparent;
                                //label6.BackColor = System.Drawing.Color.Transparent;
                                //label5.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label5.Text));
                                //label6.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label6.Text));

                                string f1 = dol_ff.ToString();
                                string g1 = gg_per.ToString();
                                label5.BackColor = System.Drawing.Color.Transparent;
                                f1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(f1));
                                g1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(g1));
                                label5.Text = f1 + "   |   " + g1;
                            }
                            else
                            {
                                //label5.Text = dol_ff.ToString();
                                //label6.Text = gg_per.ToString();
                                //label5.BackColor = System.Drawing.Color.Red;
                                //label6.BackColor = System.Drawing.Color.Red;
                                //label5.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label5.Text));
                                //label6.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label6.Text));

                                string f1 = dol_ff.ToString();
                                string g1 = gg_per.ToString();
                                label5.BackColor = System.Drawing.Color.Transparent;
                                f1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(f1));
                                g1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(g1));
                                label5.Text = f1 + "   |   " + g1;
                            }

                        }
                        z += 1;


                    }


                }

            }
            catch (Exception)
            {
                MessageBox.Show("$A or $F Values Missing OR "+e.ToString());
            }
            

        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (z==1)
            //{
            //    for (int i = 0; i < txtno; i++)
            //    {
            //      string  textbx = "text" + (i + 1);
               //    string gs=Form7.gross_sale;
               //    bool gs_isFlost = double.TryParse(gs, out double gs_val);
               //    bool textbx_isFlost = double.TryParse(, out double f_dol_val);
               //   double g_per = f_dol_val / gs_val;

               //  Label mylab = new Label();
               //    mylab.Location = new Point(pointXX, pointYY);
               //mylab.Text = g_per.ToString();


            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Create TextBox First");
            //}
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

        public static void fill_combox2()
        {
            string qry = "select * From dropdowns_tb WHERE dropdown2 IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(cbx_data);

        }

        private void dollar_f_vals_Load(object sender, EventArgs e)
        {
            cbx_data.Clear();
            fg_data_dt.Clear();
            contest();
            fill_combox2();
            comboBox2.DataSource = cbx_data;
            comboBox2.DisplayMember = "dropdown2";
            comboBox2.Text = "Item name";


            pointX = 60;
            pointY = 48;
            pointXX = 200;
            pointYY = 45;
            point_XX = 379;
            point_YY = 47;
          
            
            gs = profss.textBox1.Text;
            string str2 = "";
            gs = gs.Replace("$", str2);
            gs = gs.Replace(",", str2);
 

            cmd.Parameters.Clear();
            string qqry = "SELECT * FROM reused_values_tb  WHERE key_status='1'";
            cmd.CommandText = qqry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(fg_data_dt);

            foreach (DataRow row in fg_data_dt.Rows)
            {
                string df = row["dollars_f"].ToString();
                string pg = row["percent_g"].ToString();
                string itmz = row["item_name"].ToString();

                TextBox a = new TextBox();
                Label mylab = new Label();
                Label cbxlabel = new Label();

                a.Text = df;
                a.Enabled = false;
                cbxlabel.Text = itmz;

                double.TryParse(pg, out double pg_val);

                bool percent_g_negative = pg_val < 0;

                if (percent_g_negative == false)
                {
                    mylab.Text = pg.ToString();
                }
                else
                {
                    mylab.Text = pg.ToString();
                    mylab.BackColor = System.Drawing.Color.Red;
                }

                mylab.Location = new Point(point_XX, point_YY);
                a.Location = new Point(pointXX, pointYY);
                cbxlabel.Location = new Point(pointX, pointY);
                //mygval = mylab.Text;
                panel1.Controls.Add(a);
                panel1.Controls.Add(mylab);
                panel1.Controls.Add(cbxlabel);
                panel1.Show();

                string dff= profss.label16.Text;
              
                //string str21 = " ";
                //dff = dff.Replace("", str21);
                if (dff.Contains("|"))
                {
                    string[] tokens1 = dff.Split('|');
                    dff = tokens1[0];
                    pgg = tokens1[1];
                }
                string str21 = "";
               dff = dff.Replace("$", str21);
               dff = dff.Replace(",", str21);
               dff = dff.Replace(".", str21);

                //string pgg = profss.label19.Text;
                double.TryParse(dff, out  dol_ff);

                bool dol_f_negative = dol_ff < 0;
                if (dol_f_negative == false)
                {
                    string f1 = dol_ff.ToString();
                    label5.BackColor = System.Drawing.Color.Transparent;
                    f1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(f1));
                    label5.Text = f1 + "   |" + pgg;
                    //label6.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label6.Text));
                }
                 else
                 {
                    string f1 = dol_ff.ToString();
                    label5.BackColor = System.Drawing.Color.Transparent;
                    //label6.BackColor = System.Drawing.Color.Transparent;
                    f1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(f1));
                    label5.Text = f1 + "   |   " + pgg;
                    label5.BackColor = System.Drawing.Color.Red;
                        //label6.BackColor = System.Drawing.Color.Red;
                 }
                pointY += 25;
                pointYY += 25;
                point_YY += 25;
                z = 2;


            }


        }
    }
}

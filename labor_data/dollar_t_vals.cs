using System;
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
    public partial class dollar_t_vals : Form
    {
        int z = 1, input;

        public static int pointXX, pointX, pointY, txtno;
        public static int pointYY, point_XX, point_YY;
        public static double u_per, uu_per, dol_tt, t_dols, dolt_tbx_val, sum_d;
  

        public static String gs, cbxitem, tb1, pu,ncs,pervs,t_t,u_u,t1,u1, uper_str, file_id;

        public static SqlCommand cmd = new SqlCommand();
        public static SqlConnection db_conect = new SqlConnection();
        public static SqlDataAdapter adopt = new SqlDataAdapter();
        public static DataTable cbx_data_tu = new DataTable();
        public static DataTable dgv_dt = new DataTable();
        public static DataTable dgv_dt1 = new DataTable();

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text != "")
            {
                string name = textBox2.Text;
                string str2 = "";
                string result = name.Replace("$", str2);
                result = result.Replace(",", str2);
                result = result.Replace("(", str2);
                result = result.Replace(")", str2);
                //result = result.Replace(".", str2);
                if (result.Contains("."))
                {
                    string[] tokens = result.Split('.');
                    textBox2.Text = tokens[0];
                }
                else
                {
                    textBox2.Text = result;
                }

                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
                if (e.KeyChar == (char)13)
                {
                    //tb1 = txt1.Text;
                    textBox2.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox2.Text));
                    //SendKeys.Send("{TAB}");
                }
            }
        }

        public static DataTable tu_data_dt = new DataTable();

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //string con_str = "Data Source =DESKTOP-D8I8EQJ;Initial Catalog=rms_db;Integrated Security=True";
        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;

        private void dollar_t_vals_FormClosing(object sender, FormClosingEventArgs e)
        {
            //database
            cmd.Parameters.Clear();
            string qry = "UPDATE reused_values_tu SET status_key='5' WHERE status_key='0'";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            int rows = cmd.ExecuteNonQuery();
            //Update
        }

        Profit_Loss_Calculations pls;

        public dollar_t_vals(Profit_Loss_Calculations profs)
        {
            InitializeComponent();
            //textBox1.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            pls = profs;
            button2.Click += new EventHandler(button2_Click);
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Done

            sum_d = Math.Round(sum_d, 0, MidpointRounding.AwayFromZero);
            bool dol_tt_negative = sum_d < 0;
            if (dol_tt_negative == false)
            {
                //pls.label66.Text = dol_tt.ToString();
                //pls.label68.Text = dol_tt.ToString();
                //pls.label66.BackColor = System.Drawing.Color.Transparent;
                //pls.label68.BackColor = System.Drawing.Color.Transparent;
                pls.label8.Text = label1.Text;
                pls.label8.ForeColor = System.Drawing.Color.Black;

                //String perr_x = pls.label63.Text;
                //if (perr_x == "Null")
                //{
                //    //label26.Text = "Null";
                //    //double.TryParse(textBox9.Text, out double new_t_val);
                //    //percent_u = new_t_val / dollar_a_val;
                //    //label57.Text = new_t_val + " $".ToString();
                //    //dollar_t = new_t_val;
                //    pls.textBox9.Text = "0";
                //    pls.label57.Text = "---";
                //    pls.label66.Text = label1.Text;
                //    pls.label66.ForeColor = System.Drawing.Color.Black;
                //}
                //else
                //{
                //    double.TryParse(gs, out double dollar_a_val);
                //    double.TryParse(ncs, out double ncs_val);
                //    double.TryParse(pervs, out double pervs_val);
                //    pervs_val = pervs_val / 100;
                //    dolt_tbx_val = ncs_val * pervs_val;
                //    pls.textBox9.Text= string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(dolt_tbx_val.ToString()));
                //    double uper_val = dolt_tbx_val / dollar_a_val;
                //    uper_str= string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(uper_val.ToString()));
                //    pls.label57.Text = pls.textBox9.Text + "   |   " + uper_str;


                //    t_t = label1.Text;
                //    u_u = "";
                //    if (t_t.Contains("|"))
                //    {
                //        string[] tokens1 = t_t.Split('|');
                //        t_t = tokens1[0];
                //        u_u = tokens1[1];
                //    }
                //    string str21 = "";
                //    t_t = t_t.Replace("$", str21);
                //    t_t = t_t.Replace(",", str21);
                //    t_t = t_t.Replace(".", str21);
                //    t_t = t_t.Replace("(", "-");
                //    t_t = t_t.Replace(")", str21);

                //    u_u = u_u.Replace("%", str21);
                //    u_u = u_u.Trim();
                //    double.TryParse(t_t, out double final_tt_val);
                //    double.TryParse(u_u, out double final_uu_val);

                //    final_tt_val = dolt_tbx_val + final_tt_val;
                //    //uper_val = uu_per;
                //    final_uu_val = (uper_val*100) + final_uu_val;
                //    final_uu_val = final_uu_val / 100;

                //    t_t= string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(final_tt_val.ToString()));
                //    u_u = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(final_uu_val.ToString()));
                //    pls.label66.Text = t_t + "   |   " + u_u;

                //    if(final_tt_val>0)
                //    {
                //        pls.label66.ForeColor = System.Drawing.Color.Black;
                //    }
                //    else
                //    {
                //        pls.label66.ForeColor = System.Drawing.Color.Red;
                //    }

                //}
            }
            else
            {
                //pls.label66.Text = dol_tt.ToString();
                //pls.label68.Text = dol_tt.ToString();
                //pls.label66.BackColor = System.Drawing.Color.Red;
                //pls.label68.BackColor = System.Drawing.Color.Red;
                pls.label8.Text = label1.Text;
                pls.label8.ForeColor = System.Drawing.Color.Red;

                //String perr_x = pls.label63.Text;
                //if (perr_x == "Null")
                //{
                //    //label26.Text = "Null";
                //    //double.TryParse(textBox9.Text, out double new_t_val);
                //    //percent_u = new_t_val / dollar_a_val;
                //    //label57.Text = new_t_val + " $".ToString();
                //    //dollar_t = new_t_val;
                //    pls.textBox9.Text = "0";
                //    pls.label57.Text = "---";
                //    pls.label66.Text = label1.Text;
                //    pls.label66.ForeColor = System.Drawing.Color.Red;
                //}
                //else
                //{
                //    double.TryParse(gs, out double dollar_a_val);
                //    double.TryParse(ncs, out double ncs_val);
                //    double.TryParse(pervs, out double pervs_val);
                //    pervs_val = pervs_val / 100;
                //    double dolt_tbx_val = ncs_val * pervs_val;
                //    pls.textBox9.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(dolt_tbx_val.ToString()));
                //    double uper_val = dolt_tbx_val / dollar_a_val;
                //    string uper_str = "";
                //    uper_str = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(uper_val.ToString()));
                //    pls.label57.Text = pls.textBox9.Text + "   |   " + uper_str;


                //    t_t = label1.Text;
                //    u_u = "";
                //    if (t_t.Contains("|"))
                //    {
                //        string[] tokens1 = t_t.Split('|');
                //        t_t = tokens1[0];
                //        u_u = tokens1[1];
                //    }
                //    string str21 = "";
                //    t_t = t_t.Replace("$", str21);
                //    t_t = t_t.Replace(",", str21);
                //    t_t = t_t.Replace(".", str21);
                //    t_t = t_t.Replace("(", "-");
                //    t_t = t_t.Replace(")", str21);

                //    u_u = u_u.Replace("%", str21);
                //    u_u = u_u.Trim();

                //    double.TryParse(t_t, out double final_tt_val);
                //    double.TryParse(u_u, out double final_uu_val);

                //    final_tt_val = dolt_tbx_val + final_tt_val;
                //    final_uu_val = (uper_val * 100) + final_uu_val;
                //    final_uu_val = final_uu_val / 100;

                //    t_t = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(final_tt_val.ToString()));
                //    u_u = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(final_uu_val.ToString()));
                //    pls.label66.Text = t_t + "   |   " + u_u;

                //    if (final_tt_val > 0)
                //    {
                //        pls.label66.ForeColor = System.Drawing.Color.Black;
                //    }
                //    else
                //    {
                //        pls.label66.ForeColor = System.Drawing.Color.Red;
                //    }

                //}
            }
            //profss.textBox4.Enabled = false;

            //database
            cmd.Parameters.Clear();
            string qry = "UPDATE reused_values_tu SET status_key='1' WHERE status_key='0'";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            int rows = cmd.ExecuteNonQuery();
            //Update

            this.Hide();
        }

        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Enter || e.KeyChar == '.') //The  character represents a backspace
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
            //Add new text

            try
            {
                //txtno = int.Parse(txt1.Text);

                //panel1.Controls.Clear();
                for (int i = 0; i < 1; i++)
                {
                    //TextBox a = new TextBox();
                    Label alab = new Label();
                    Label mylab = new Label();
                    Label cbxlabel = new Label();

                    //gs = textBox1.Text;
                    if (gs == "" || cbxitem == "Item name" || cbxitem == "" || gs == null || textBox2.Text == null || textBox2.Text =="")
                    {
                        MessageBox.Show("Gross Sale Value $A is Missing OR Choose Item Name Missig","Alert",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        //mylab.Text = "U% : ----";
                    }
                    else
                    {
                        tb1 = textBox2.Text;
                        if (tb1.Contains("("))
                        {
                            string str12 = "";
                            tb1 = tb1.Replace("$", str12);
                            tb1 = tb1.Replace(",", str12);
                            tb1 = tb1.Replace(".", str12);
                            tb1 = tb1.Replace("(", str12);
                            tb1 = tb1.Replace(")", str12);
                            tb1 = "-" + tb1;
                            alab.Text = textBox2.Text;
                            alab.Text = alab.Text.Replace(")", str12);
                            alab.Text = alab.Text.Replace("(", str12);
                            alab.Text = "-" + alab.Text;
                        }
                        else
                        {
                            string str2 = "";
                            tb1 = tb1.Replace("$", str2);
                            tb1 = tb1.Replace(",", str2);
                            tb1 = tb1.Replace(".", str2);
                            alab.Text = textBox2.Text;
                        }

                        // a.Text = textBox2.Text;
                        //a.Enabled = false;
                        cbxitem = comboBox5.Text;
                        cbxlabel.Text = cbxitem;
                        bool gs_isFlost = double.TryParse(gs, out double gs_val);
                        bool textbx_isFlost = double.TryParse(tb1, out t_dols);
                        u_per = t_dols / gs_val;
                        
                        mylab.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(u_per.ToString()));
                        //u_per = Math.Round(u_per, 0, MidpointRounding.AwayFromZero);
                        bool percent_u_negative = u_per < 0;

                        cmd.Parameters.Clear();
                        string qry = "INSERT INTO reused_values_tu (dollars_t,percent_u,item_name) VALUES (@dol_t,@percent_u,@itm) ";
                        cmd.CommandText = qry;
                        cmd.Connection = db_conect;
                        //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                        cmd.Parameters.AddWithValue("@dol_t", alab.Text);
                        cmd.Parameters.AddWithValue("@percent_u", mylab.Text);
                        cmd.Parameters.AddWithValue("@itm", cbxlabel.Text);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            // MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
                            dgv_dt1.Clear();
                            dgv_dt.Clear();
                            cmd.Parameters.Clear();
                            string qrys = "SELECT tu_id,item_name,dollars_t,percent_u FROM reused_values_tu  WHERE status_key='0' OR status_key='1'";
                            cmd.CommandText = qrys;
                            cmd.Connection = db_conect;
                            adopt = new SqlDataAdapter(cmd);
                            adopt.Fill(dgv_dt);
                            dataGridView1.DataSource = dgv_dt;
                            dataGridView1.Columns["tu_id"].Visible = false;
                            dataGridView1.Columns[1].HeaderText = "Item name";
                            dataGridView1.Columns[2].HeaderText = "Operating Cost";
                            dataGridView1.Columns[3].HeaderText = "Percentage%";

                            sum_d = 0;
                            double sum_p = 0;
                            for (int j = 0; j < dgv_dt.Rows.Count; j++)
                            {
                                string jval = dgv_dt.Rows[j]["dollars_t"].ToString();
                                string str2 = "";
                                jval = jval.Replace("$", str2);
                                jval = jval.Replace(",", str2);
                                jval = jval.Replace(".", str2);
                                double.TryParse(jval, out double sums);
                                sum_d = sums + sum_d;

                                string pval = dgv_dt.Rows[j]["percent_u"].ToString();
                               
                                pval = pval.Replace("%", str2);
                                pval = pval.Replace(",", str2);
                               // pval = pval.Replace(".", str2);
                                double.TryParse(pval, out double sump);
                                sum_p = sump + sum_p;
                              

                            }
                           textBox2.Text = null;
                           comboBox5.Text = "Item name";
                            sum_p = sum_p / 100;
                            if (sum_d<0)
                            {
                                t1 = sum_d.ToString();
                                
                                u1 = sum_p.ToString();

                                t1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(t1));
                                u1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(u1));
                                if (t1.Contains("("))
                                {
                                    t1 = t1.Replace("(", "-");
                                    t1 = t1.Replace(")", "");
                                }

                                label1.Text = t1 + "   |   " + u1;
                             
                                label1.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                t1 = sum_d.ToString();
                                u1 = sum_p.ToString();

                                t1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(t1));
                                u1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(u1));

                                label1.Text = t1 + "   |   " + u1;
                                label1.ForeColor = System.Drawing.Color.Black;
                            }
                         


                        }
                        else
                        {
                            MessageBox.Show("Failed to Save Data");
                        }

                        //////if (percent_u_negative == false)
                        //////{
                        //////    mylab.Text = u_per.ToString();
                        //////    mylab.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(mylab.Text));
                        //////    mylab.BackColor = System.Drawing.Color.Transparent;
                        //////}
                        //////else
                        //////{
                        //////    mylab.Text = u_per.ToString();
                        //////    mylab.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(mylab.Text));
                        //////    mylab.BackColor = System.Drawing.Color.Red;
                        //////}


                        ////database
                        //cmd.Parameters.Clear();
                        //string qry = "INSERT INTO reused_values_tu (dollars_t,percent_u,item_name) VALUES (@dol_t,@percent_u,@itm) ";
                        //cmd.CommandText = qry;
                        //cmd.Connection = db_conect;
                        ////@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                        //cmd.Parameters.AddWithValue("@dol_t", a.Text);
                        //cmd.Parameters.AddWithValue("@percent_u", mylab.Text);
                        //cmd.Parameters.AddWithValue("@itm", cbxlabel.Text);
                        //int rows = cmd.ExecuteNonQuery();
                        //if (rows > 0)
                        //{
                        //   // MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Failed to Save Data");
                        //}
                        ////save
                    //////    mylab.Location = new Point(point_XX, point_YY);
                    //////    a.Location = new Point(pointXX, pointYY);
                    //////    cbxlabel.Location = new Point(pointX, pointY);
                    //////    //mygval = mylab.Text;
                    //////    panel1.Controls.Add(a);
                    //////    panel1.Controls.Add(mylab);
                    //////    panel1.Controls.Add(cbxlabel);
                    //////    panel1.Show();
                    //////    textBox2.Text = null;
                    //////    comboBox5.Text = "Item name";
                    //////    pointY += 25;
                    //////    pointYY += 25;
                    //////    point_YY += 25;

                    //////    //gg_per = g_per + f_dols;
                    //////    if (z == 1)
                    //////    {
                    //////        dol_tt = t_dols;
                    //////        uu_per = u_per;
                    //////        dol_tt = Math.Round(dol_tt, 0, MidpointRounding.AwayFromZero);
                    //////        bool dol_tt_negative = dol_tt < 0;
                    //////        if (dol_tt_negative == false)
                    //////        {
                    //////            //label1.Text = "$TT: " + dol_tt.ToString();
                    //////            //label2.Text = "UU%: " + dol_tt.ToString();
                    //////            //label1.BackColor = System.Drawing.Color.Transparent;
                    //////            //label2.BackColor = System.Drawing.Color.Transparent;

                    //////            t1 = dol_tt.ToString();
                    //////            u1 = uu_per.ToString();
                    //////            label1.BackColor = System.Drawing.Color.Transparent;
                    //////            t1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(t1));
                    //////            u1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(u1));

                    //////            label1.Text = t1 + "   |   " + u1;
                    //////        }
                    //////        else
                    //////        {
                    //////            //label1.Text = "$TT: " + dol_tt.ToString();
                    //////            //label2.Text = "UU%: " + dol_tt.ToString();
                    //////            //label1.BackColor = System.Drawing.Color.Red;
                    //////            //label2.BackColor = System.Drawing.Color.Red;

                    //////            t1 = dol_tt.ToString();
                    //////            u1 = uu_per.ToString();
                    //////            label1.BackColor = System.Drawing.Color.Red;
                    //////            t1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(t1));
                    //////            u1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(u1));
                    //////            if (t1.Contains("("))
                    //////            {
                    //////                t1 = t1.Replace("(", "-");
                    //////                t1 = t1.Replace(")", "");
                    //////            }
                    //////            label1.Text = t1 + "   |   " + u1;
                    //////        }

                    //////    }
                    //////    else
                    //////    {
                    //////        dol_tt = t_dols + dol_tt;
                    //////        uu_per = u_per + uu_per;
                    //////        dol_tt = Math.Round(dol_tt, 0, MidpointRounding.AwayFromZero);
                    //////        bool dol_tt_negative = dol_tt < 0;
                    //////        if (dol_tt_negative == false)
                    //////        {
                    //////            //label1.Text = "$TT: " + dol_tt.ToString();
                    //////            //label2.Text = "UU%: " + dol_tt.ToString();
                    //////            //label1.BackColor = System.Drawing.Color.Transparent;
                    //////            //label2.BackColor = System.Drawing.Color.Transparent;
                    //////            t1 = dol_tt.ToString();
                    //////            u1 = uu_per.ToString();
                    //////            label1.BackColor = System.Drawing.Color.Transparent;
                    //////            t1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(t1));
                    //////            u1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(u1));

                    //////            label1.Text = t1 + "   |   " + u1;
                    //////        }
                    //////        else
                    //////        {
                    //////            //label1.Text = "$TT: " + dol_tt.ToString();
                    //////            //label2.Text = "UU%: " + dol_tt.ToString();
                    //////            //label1.BackColor = System.Drawing.Color.Red;
                    //////            //label2.BackColor = System.Drawing.Color.Red;
                    //////            t1 = dol_tt.ToString();
                    //////            u1 = uu_per.ToString();
                    //////            label1.BackColor = System.Drawing.Color.Red;
                    //////            t1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(t1));
                    //////            u1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(u1));
                    //////            if (t1.Contains("("))
                    //////            {
                    //////                t1 = t1.Replace("(", "-");
                    //////                t1 = t1.Replace(")", "");
                    //////            }
                    //////            label1.Text = t1 + "   |   " + u1;
                    //////        }

                    //////    }
                    //////    z += 1;

                    }

                   

                }

            }
            catch (Exception)
            {
                MessageBox.Show("$A or $T Values Missing OR " + e.ToString());
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

        public static void fill_combox5()
        {
            string qry = "select * From dropdowns_tb WHERE dropdown5 IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(cbx_data_tu);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Load_Data"].Index && dataGridView1.Rows.Count > 1 && e.RowIndex + 1 != dataGridView1.Rows.Count)
            {
                //Do something with your button.

                //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                file_id = dgv_dt.Rows[e.RowIndex]["tu_id"].ToString();

                cmd.Parameters.Clear();
                //DELETE FROM reused_values_tu WHERE tu_id=@tid;
                string qry = "DELETE FROM reused_values_tu WHERE tu_id=@tid;";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                cmd.Parameters.AddWithValue("@tid", file_id);
                int rows = cmd.ExecuteNonQuery();
                if(rows >0)
                {
                    //del record
                    dgv_dt1.Clear();
                    dgv_dt.Clear();
                    cmd.Parameters.Clear();
                    string qrys = "SELECT tu_id,item_name,dollars_t,percent_u FROM reused_values_tu  WHERE status_key='0' OR status_key='1'";
                    cmd.CommandText = qrys;
                    cmd.Connection = db_conect;
                    adopt = new SqlDataAdapter(cmd);
                    adopt.Fill(dgv_dt);
                    dataGridView1.DataSource = dgv_dt;
                    dataGridView1.Columns["tu_id"].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Item name";
                    dataGridView1.Columns[2].HeaderText = "Operating Cost";
                    dataGridView1.Columns[3].HeaderText = "Percentage%";

                    sum_d = 0;
                    double sum_p = 0;
                    for (int j = 0; j < dgv_dt.Rows.Count; j++)
                    {
                        string jval = dgv_dt.Rows[j]["dollars_t"].ToString();
                        string str2 = "";
                        jval = jval.Replace("$", str2);
                        jval = jval.Replace(",", str2);
                        jval = jval.Replace(".", str2);
                        double.TryParse(jval, out double sums);
                        sum_d = sums + sum_d;

                        string pval = dgv_dt.Rows[j]["percent_u"].ToString();

                        pval = pval.Replace("%", str2);
                        pval = pval.Replace(",", str2);
                        // pval = pval.Replace(".", str2);
                        double.TryParse(pval, out double sump);
                        sum_p = sump + sum_p;
                        
                    }
                    sum_p = sum_p / 100;
                    if (sum_d < 0)
                    {
                        t1 = sum_d.ToString();
                        u1 = sum_p.ToString();

                        t1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(t1));
                        u1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(u1));
                        if (t1.Contains("("))
                        {
                            t1 = t1.Replace("(", "-");
                            t1 = t1.Replace(")", "");
                        }
                        label1.Text = t1 + "   |   " + u1;
                        
                        label1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        t1 = sum_d.ToString();
                        u1 = sum_p.ToString();

                        t1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(t1));
                        u1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(u1));

                        label1.Text = t1 + "   |   " + u1;
                        label1.ForeColor = System.Drawing.Color.Black;
                    }
                }
                else
                {
                    MessageBox.Show("Fials");
                }
                //adopt = new SqlDataAdapter(cmd);
                //adopt.Fill(dgv_dt1);

            }
        }
        public void fill_dgv()
        {
           
            dgv_dt1.Clear();
            dgv_dt.Clear();
            cmd.Parameters.Clear();
            string qry = "SELECT tu_id,item_name,dollars_t,percent_u FROM reused_values_tu  WHERE status_key='1'";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(dgv_dt);
            dataGridView1.DataSource = dgv_dt;
            dataGridView1.Columns["tu_id"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Item name";
            dataGridView1.Columns[2].HeaderText = "Operating Cost";
            dataGridView1.Columns[3].HeaderText = "Percentage%";

            DataGridViewButtonColumn loadButtonColumn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(loadButtonColumn);
            loadButtonColumn.HeaderText = "Actions";
            loadButtonColumn.Name = "Load_Data";
            loadButtonColumn.Text = "Delete";
            loadButtonColumn.UseColumnTextForButtonValue = true;
        }
        private void dollar_t_vals_Load(object sender, EventArgs e)
        {
            cbx_data_tu.Clear();
            tu_data_dt.Clear();

            //form load

            t_t = null;
            u_u = null;
            contest();
            fill_dgv();
            fill_combox5();
            comboBox5.DataSource = cbx_data_tu;
            comboBox5.DisplayMember = "dropdown5";
            comboBox5.Text = "Item name";

            //////pointX = 65;
            //////pointY = 48;
            //////pointXX = 215;
            //////pointYY = 45;
            //////point_XX = 400;
            //////point_YY = 48;
           gs = pls.textBox1.Text;
            string str2 = "";
            gs = gs.Replace("$", str2);
            gs = gs.Replace(",", str2);
            gs = gs.Replace("(", "-");
            gs = gs.Replace(")", str2);


            sum_d = 0;
            double sum_p = 0;
            for (int k = 0; k < dgv_dt.Rows.Count; k++)
            {
                string jval = dgv_dt.Rows[k]["dollars_t"].ToString();
            
                jval = jval.Replace("$", str2);
                jval = jval.Replace(",", str2);
                jval = jval.Replace(".", str2);
                double.TryParse(jval, out double sums);
                sum_d = sums + sum_d;

                string pval = dgv_dt.Rows[k]["percent_u"].ToString();

                pval = pval.Replace("%", str2);
                pval = pval.Replace(",", str2);
                // pval = pval.Replace(".", str2);
                double.TryParse(pval, out double sump);
                sum_p = sump + sum_p;
               
            }
            sum_p = sum_p / 100;
            if (sum_d < 0)
            {
                t1 = sum_d.ToString();
                u1 = sum_p.ToString();

                t1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(t1));
                u1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(u1));
                if (t1.Contains("("))
                {
                    t1 = t1.Replace("(", "-");
                    t1 = t1.Replace(")", "");
                }

                label1.Text = t1 + "   |   " + u1;
               
                label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                t1 = sum_d.ToString();
                u1 = sum_p.ToString();

                t1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(t1));
                u1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P2}", double.Parse(u1));

                label1.Text = t1 + "   |   " + u1;
                label1.ForeColor = System.Drawing.Color.Black;
            }




            //////ncs = pls.textBox3.Text;
            //////ncs = ncs.Replace("$", str2);
            //////ncs = ncs.Replace(",", str2);
            //////ncs = ncs.Replace("(", "-");
            //////ncs = ncs.Replace(")", str2);

            //////pervs = pls.label63.Text;
            //////pervs = pervs.Replace("%", str2);

            //////cmd.Parameters.Clear();
            //////string qqry = "SELECT * FROM reused_values_tu  WHERE status_key='1'";
            //////cmd.CommandText = qqry;
            //////cmd.Connection = db_conect;
            //////adopt = new SqlDataAdapter(cmd);
            //////adopt.Fill(tu_data_dt);

            //////foreach (DataRow row in tu_data_dt.Rows)
            //////{
            //////    string dj = row["dollars_t"].ToString();
            //////    string pk = row["percent_u"].ToString();
            //////    string itz = row["item_name"].ToString();

            //////    TextBox a = new TextBox();
            //////    Label mylab = new Label();
            //////    Label cbxlabel = new Label();

            //////    a.Text = dj;
            //////    a.Enabled = false;
            //////    cbxlabel.Text = itz;

            //////    pk = pk.Replace("%", "");
            //////    double.TryParse(pk, out double pk_val);

            //////    bool percent_k_negative = pk_val < 0;

            //////    if (percent_k_negative == false)
            //////    {
            //////        mylab.Text = row["percent_u"].ToString();
            //////        mylab.BackColor = System.Drawing.Color.Transparent;
            //////    }
            //////    else
            //////    {
            //////        mylab.Text = row["percent_u"].ToString();
            //////        mylab.BackColor = System.Drawing.Color.Red;
            //////    }

            //////    mylab.Location = new Point(point_XX, point_YY);
            //////    a.Location = new Point(pointXX, pointYY);
            //////    cbxlabel.Location = new Point(pointX, pointY);
            //////    //mygval = mylab.Text;
            //////    panel1.Controls.Add(a);
            //////    panel1.Controls.Add(mylab);
            //////    panel1.Controls.Add(cbxlabel);
            //////    panel1.Show();

            //////    string djj = pls.label8.Text;

            //////    if (djj.Contains("|"))
            //////    {
            //////        string[] tokens1 = djj.Split('|');
            //////        djj = tokens1[0];
            //////        u1 = tokens1[1];
            //////    }
            //////    string str21 = "";
            //////    djj = djj.Replace("$", str21);
            //////    djj = djj.Replace(",", str21);
            //////    djj = djj.Replace(".", str21);
            //////    //string pgg = profss.label19.Text;
            //////    double.TryParse(djj, out dol_tt);

            //////    bool dol_l_negative = dol_tt < 0;
            //////    if (dol_l_negative == false)
            //////    {
            //////        //label1.Text = "$TT: " + dol_tt.ToString();
            //////        //label2.Text = "UU%: " + dol_tt.ToString();
            //////        //label1.BackColor = System.Drawing.Color.Transparent;
            //////        //label2.BackColor = System.Drawing.Color.Transparent;

            //////        t1 = dol_tt.ToString();
            //////        label1.BackColor = System.Drawing.Color.Transparent;
            //////        t1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(t1));
            //////        label1.Text = t1 + "   |" + u1;
            //////    }
            //////    else
            //////    {
            //////        //label1.Text = "$TT: " + dol_tt.ToString();
            //////        //label2.Text = "UU%: " + dol_tt.ToString();
            //////        //label1.BackColor = System.Drawing.Color.Red;
            //////        //label2.BackColor = System.Drawing.Color.Red;

            //////        string t1 = dol_tt.ToString();
            //////        label1.BackColor = System.Drawing.Color.Red;
            //////        t1 = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(t1));
            //////        if (t1.Contains("("))
            //////        {
            //////            t1 = t1.Replace("(", "-");
            //////            t1 = t1.Replace(")", "");
            //////        }
            //////        label1.Text = t1 + "   |" + u1;
            //////    }
            //////    pointY += 25;
            //////    pointYY += 25;
            //////    point_YY += 25;
            //////    z = 2;


            //////}
        }
    }
}

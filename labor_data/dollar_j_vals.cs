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


namespace labor_data
{
    public partial class dollar_j_vals : Form
    {
        int z = 1, input;

        public static int pointXX, pointX, pointY, txtno;
        public static int pointYY, point_XX, point_YY;
        public static double k_per, m_per, dol_l, j_dols;

        public static String gs, cbxitem;

        public static SqlCommand cmd = new SqlCommand();
        public static SqlConnection db_conect = new SqlConnection();
        public static SqlDataAdapter adopt = new SqlDataAdapter();
        public static DataTable cbx_data_jk = new DataTable();
        public static DataTable jk_data_dt = new DataTable();



        //string con_str = "Data Source =DESKTOP-D8I8EQJ;Initial Catalog=rms_db;Integrated Security=True";
        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;

        private void dollar_j_vals_FormClosing(object sender, FormClosingEventArgs e)
        {

            //database
            cmd.Parameters.Clear();
            string qry = "UPDATE reused_values_jk SET key_status='5' WHERE key_status='0'";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            int rows = cmd.ExecuteNonQuery();
            //Update
        }

        Profit_Loss_Calculations pls;

        public dollar_j_vals(Profit_Loss_Calculations profs)
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            pls = profs;
            button2.Click += new EventHandler(button2_Click);
        }

        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Enter || e.KeyChar == '.')//The  character represents a backspace
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


        private void button2_Click(object sender, EventArgs e)
        {
            //Done

            dol_l = Math.Round(dol_l, 0, MidpointRounding.AwayFromZero);
            bool dol_l_negative = dol_l < 0;
            if (dol_l_negative == false)
            {
                pls.label21.Text = dol_l.ToString();
                pls.label11.Text = dol_l.ToString();
                pls.label21.BackColor = System.Drawing.Color.Transparent;
                pls.label11.BackColor = System.Drawing.Color.Transparent;
            }
            else
            {
                pls.label21.Text = dol_l.ToString();
                pls.label11.Text = dol_l.ToString();
                pls.label21.BackColor = System.Drawing.Color.Red;
                pls.label11.BackColor = System.Drawing.Color.Red;
            }
            //profss.textBox4.Enabled = false;
            

            //database
            cmd.Parameters.Clear();
            string qry = "UPDATE reused_values_jk SET key_status='1' WHERE key_status='0'";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            int rows = cmd.ExecuteNonQuery();
            //Update

            this.Hide();
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
                    TextBox a = new TextBox();
                    Label mylab = new Label();
                    Label cbxlabel = new Label();

                    //a.Text = (i + 1).ToString();



                    gs = textBox1.Text;
                    if (gs == "" || cbxitem == "Choose Item" || cbxitem == "")
                    {
                        MessageBox.Show("Some Required Field is Missing");
                        //mylab.Text = "K% : ----";
                    }
                    else
                    {
                        a.Text = textBox2.Text;
                        a.Enabled = false;
                        cbxitem = comboBox2.Text;
                        cbxlabel.Text = cbxitem;
                        bool gs_isFlost = double.TryParse(gs, out double gs_val);
                        bool textbx_isFlost = double.TryParse(textBox2.Text, out j_dols);
                        k_per = j_dols / gs_val;
                        k_per = Math.Round(k_per, 0, MidpointRounding.AwayFromZero);
                        bool percent_k_negative = k_per < 0;

                        if (percent_k_negative == false)
                        {
                            mylab.Text = k_per.ToString();
                        }
                        else
                        {
                            mylab.Text = k_per.ToString();
                            mylab.BackColor = System.Drawing.Color.Red;
                        }


                        //database
                        cmd.Parameters.Clear();
                        string qry = "INSERT INTO reused_values_jk (dollars_j,percent_k,item_name) VALUES (@dol_j,@percent_k,@itms) ";
                        cmd.CommandText = qry;
                        cmd.Connection = db_conect;
                        //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                        cmd.Parameters.AddWithValue("@dol_j", textBox2.Text);
                        cmd.Parameters.AddWithValue("@percent_k", mylab.Text);
                        cmd.Parameters.AddWithValue("@itms", cbxlabel.Text);
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
                        mylab.Location = new Point(pointXX, pointYY);
                        a.Location = new Point(pointX, pointY);
                        cbxlabel.Location = new Point(point_XX, point_YY);
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
                            dol_l = k_per + j_dols;
                            dol_l = Math.Round(dol_l, 0, MidpointRounding.AwayFromZero);
                            bool dol_l_negative = dol_l < 0;
                            if (dol_l_negative == false)
                            {
                                label1.Text = "$L: " + dol_l.ToString();
                                label2.Text = "M%: " + dol_l.ToString();
                                label1.BackColor = System.Drawing.Color.Transparent;
                                label2.BackColor = System.Drawing.Color.Transparent;
                            }
                            else
                            {
                                label1.Text = "$L: " + dol_l.ToString();
                                label2.Text = "M%: " + dol_l.ToString();
                                label1.BackColor = System.Drawing.Color.Red;
                                label2.BackColor = System.Drawing.Color.Red;
                            }

                        }
                        else
                        {
                            dol_l = k_per + j_dols + dol_l;
                            dol_l = Math.Round(dol_l, 0, MidpointRounding.AwayFromZero);
                            bool dol_l_negative = dol_l < 0;
                            if (dol_l_negative == false)
                            {
                                label1.Text = "$L: " + dol_l.ToString();
                                label2.Text = "M%: " + dol_l.ToString();
                                label1.BackColor = System.Drawing.Color.Transparent;
                                label2.BackColor = System.Drawing.Color.Transparent;
                            }
                            else
                            {
                                label1.Text = "$L: " + dol_l.ToString();
                                label2.Text = "M%: " + dol_l.ToString();
                                label1.BackColor = System.Drawing.Color.Red;
                                label2.BackColor = System.Drawing.Color.Red;
                            }

                        }
                        z += 1;

                    }

                  

                }

            }
            catch (Exception)
            {
                MessageBox.Show("$A or $J Values Missing OR " + e.ToString());
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

        public static void fill_combox4()
        {
            string qry = "select * From dropdowns_tb WHERE dropdown4 IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(cbx_data_jk);

        }

        private void dollar_j_vals_Load(object sender, EventArgs e)
        {
            //form load
            cbx_data_jk.Clear();
            jk_data_dt.Clear();
            contest();

            fill_combox4();
            comboBox2.DataSource = cbx_data_jk;
            comboBox2.DisplayMember = "dropdown4";
            comboBox2.Text = "Choose Item";

            pointX = 30;
            pointY = 40;
            pointXX = 215;
            pointYY = 45;
            point_XX = 372;
            point_YY = 45;

            textBox1.Text = pls.textBox1.Text;
            //textBox2.Text = pls.textBox5.Text;

            //if (textBox1.Text != "" && textBox2.Text != "")
            //{
            //    TextBox a = new TextBox();
            //    Label mylab = new Label();
            //    a.Text = textBox2.Text;

            //    //gs = textBox1.Text;
            //    if (textBox1.Text == "" || textBox2.Text == "")
            //    {
            //        MessageBox.Show("Gross Sale Value $A OR $J is Missing");
            //        mylab.Text = "K% : ----";
            //    }
            //    else
            //    {
            //        bool gs_isdbl = double.TryParse(textBox1.Text, out double gs_val);
            //        bool textbx_idbl = double.TryParse(textBox2.Text, out j_dols);
            //        k_per = j_dols / gs_val;
            //        k_per = Math.Round(k_per, 0, MidpointRounding.AwayFromZero);
            //        bool percent_k_negative = k_per < 0;

            //        if (percent_k_negative == false)
            //        {
            //            mylab.Text = k_per.ToString();
            //        }
            //        else
            //        {
            //            mylab.Text = k_per.ToString();
            //            mylab.BackColor = System.Drawing.Color.Red;
            //        }
            //        //database
            //        cmd.Parameters.Clear();
            //        string qry = "INSERT INTO reused_values_jk (dollars_j,percent_k) VALUES (@dol_j,@percent_k) ";
            //        cmd.CommandText = qry;
            //        cmd.Connection = db_conect;
            //        //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
            //        cmd.Parameters.Add("@dol_j", textBox2.Text);
            //        cmd.Parameters.Add("@percent_k", mylab.Text);
            //        int rows = cmd.ExecuteNonQuery();
            //        if (rows > 0)
            //        {
            //            //MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Failed to Save Data");
            //        }
            //        //save
            //        mylab.Location = new Point(pointXX, pointYY);
            //        a.Location = new Point(pointX, pointY);
            //        //mygval = mylab.Text;
            //        panel1.Controls.Add(a);
            //        panel1.Controls.Add(mylab);
            //        panel1.Show();

            //        dol_l = k_per + j_dols;
            //        dol_l = Math.Round(dol_l, 0, MidpointRounding.AwayFromZero);
            //        bool dol_l_negative = dol_l < 0;
            //        if (dol_l_negative == false)
            //        {
            //            label1.Text = "$L: " + dol_l.ToString();
            //            label2.Text = "M%: " + dol_l.ToString();
            //            label1.BackColor = System.Drawing.Color.Transparent;
            //            label2.BackColor = System.Drawing.Color.Transparent;
            //        }
            //        else
            //        {
            //            label1.Text = "$L: " + dol_l.ToString();
            //            label2.Text = "M%: " + dol_l.ToString();
            //            label1.BackColor = System.Drawing.Color.Red;
            //            label2.BackColor = System.Drawing.Color.Red;
            //        }
            //    }
            //    pointY += 25;
            //    pointYY += 25;
            //    z = 2;


            //}
            //else
            //{

            //    MessageBox.Show("Gross Sale Value $A OR $J is Missing");
            //}
            cmd.Parameters.Clear();
            string qqry = "SELECT * FROM reused_values_jk  WHERE key_status='1'";
            cmd.CommandText = qqry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(jk_data_dt);

            foreach (DataRow row in jk_data_dt.Rows)
            {
                string dj = row["dollars_j"].ToString();
                string pk = row["percent_k"].ToString();
                string itmz = row["item_name"].ToString();

                TextBox a = new TextBox();
                Label mylab = new Label();
                Label cbxlabel = new Label();

                a.Text = dj;
                a.Enabled = false;
                cbxlabel.Text = itmz;
                double.TryParse(pk, out double pk_val);

                bool percent_k_negative = pk_val < 0;

                if (percent_k_negative == false)
                {
                    mylab.Text = pk.ToString();
                }
                else
                {
                    mylab.Text = pk.ToString();
                    mylab.BackColor = System.Drawing.Color.Red;
                }

                mylab.Location = new Point(pointXX, pointYY);
                a.Location = new Point(pointX, pointY);
                cbxlabel.Location = new Point(point_XX, point_YY);
                //mygval = mylab.Text;
                panel1.Controls.Add(a);
                panel1.Controls.Add(mylab);
                panel1.Controls.Add(cbxlabel);
                panel1.Show();

                string djj = pls.label21.Text;
                //string pgg = profss.label19.Text;
                double.TryParse(djj, out dol_l);

                bool dol_l_negative = dol_l < 0;
                if (dol_l_negative == false)
                {
                    label1.Text = "$L: " + dol_l.ToString();
                    label2.Text = "M%: " + dol_l.ToString();
                    label1.BackColor = System.Drawing.Color.Transparent;
                    label2.BackColor = System.Drawing.Color.Transparent;
                }
                else
                {
                    label1.Text = "$L: " + dol_l.ToString();
                    label2.Text = "M%: " + dol_l.ToString();
                    label5.BackColor = System.Drawing.Color.Red;
                    label6.BackColor = System.Drawing.Color.Red;
                }
                pointY += 25;
                pointYY += 25;
                point_YY += 25;
                z = 2;


            }


        }
    }
}

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
    public partial class Profit_Loss_Calculations : Form
    {
        public static String gross_sale, cash_sale, non_cash_sale,f_val, refskey,tbx1,tbx2,tbx3,tbx6,tbx7;
        public static int ctk, ctk2;
        

        int input;
        //percent_x,percent_xx,percent_v
       double h_dollar, dollar_r,dollar_z;
       public static SqlCommand cmd = new SqlCommand();
       public static SqlConnection db_conect = new SqlConnection();
       public static SqlDataAdapter adopt = new SqlDataAdapter();
       public static DataTable defined_data = new DataTable();
       public static DataTable reused_val_data = new DataTable();
       public static DataTable refkey_dt = new DataTable();
        public static DataTable combox_dt = new DataTable();
        public static DataTable combox_2_dt = new DataTable();
        public static DataTable combox_3_dt = new DataTable();
        public static DataTable combox_4_dt = new DataTable();
        public static DataTable combox_5_dt = new DataTable();
        //string con_str = "Data Source =DESKTOP-D8I8EQJ;Initial Catalog=rms_db;Integrated Security=True";
        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;


        public Profit_Loss_Calculations()
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox3.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            //textBox4.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            //textBox5.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox6.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox7.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            //textBox8.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            textBox9.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            comboBox1.KeyDown += new KeyEventHandler(tb_KeyDown);
            comboBox3.KeyDown += new KeyEventHandler(tb_KeyDown);

        }

        static void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                SendKeys.Send("{TAB}");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Wnat to Switch to Tool 1 ?", "Close Tool 3", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                //database
                cmd.Parameters.Clear();
                string qry = "UPDATE reused_values_tb SET key_status='5' WHERE key_status='1'";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                int rows = cmd.ExecuteNonQuery();

                //database
                cmd.Parameters.Clear();
                string qrsy = "UPDATE reused_values_jk SET key_status='5' WHERE key_status='1'";
                cmd.CommandText = qrsy;
                cmd.Connection = db_conect;
                int rowse = cmd.ExecuteNonQuery();

                //Update

                //database
                //database
                cmd.Parameters.Clear();
                string qryy = "UPDATE reused_values_tu SET status_key='5' WHERE status_key='1'";
                cmd.CommandText = qryy;
                cmd.Connection = db_conect;
                int rrows = cmd.ExecuteNonQuery();
                //Update

                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }


        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Wnat to Switch to Tool 2 ?", "Close Tool 3", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                //database
                cmd.Parameters.Clear();
                string qry = "UPDATE reused_values_tb SET key_status='5' WHERE key_status='1'";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                int rows = cmd.ExecuteNonQuery();

                //database
                cmd.Parameters.Clear();
                string qrsy = "UPDATE reused_values_jk SET key_status='5' WHERE key_status='1'";
                cmd.CommandText = qrsy;
                cmd.Connection = db_conect;
                int rowse = cmd.ExecuteNonQuery();

                //Update
                //database
                cmd.Parameters.Clear();
                string qryy = "UPDATE reused_values_tu SET status_key='5' WHERE status_key='1'";
                cmd.CommandText = qryy;
                cmd.Connection = db_conect;
                int rrows = cmd.ExecuteNonQuery();
                //Update

                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
         
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ctk = -1;
            ctk2 = -1;

            label5.Text = "---";
            label6.Text = "---";
            label7.Text = "---";
            label8.Text = "---";
            label5.BackColor = System.Drawing.Color.Transparent;
            label6.BackColor = System.Drawing.Color.Transparent;
            label7.BackColor = System.Drawing.Color.Transparent;
            label8.BackColor = System.Drawing.Color.Transparent;


            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                string message = "Some Numeric Values is Missing";
                string title = "Alert";
                MessageBox.Show(message, title);
            }
            else
            {
                gross_sale = textBox1.Text;
                cash_sale = textBox2.Text;
                non_cash_sale = textBox3.Text;
                //bool gross_sale_isNumber = int.TryParse(gross_sale, out int g_sale);
                //bool cash_sale_isNumber = int.TryParse(cash_sale, out int c_sale);
                //bool non_cash_sale_isNumber = int.TryParse(non_cash_sale, out int n_c_sale);
                bool grosss_sale_isFlost = double.TryParse(gross_sale, out double g_sale);
                bool cash_sale_isFlost = double.TryParse(cash_sale, out double c_sale);
                bool non_cash_isFlost = double.TryParse(non_cash_sale, out double n_c_sale);


                double csh_sale = c_sale / g_sale;
                double n_csh_sale = n_c_sale / g_sale;
                double grs_sale = c_sale + n_csh_sale;

                 csh_sale = Math.Round(csh_sale, 0, MidpointRounding.AwayFromZero);
                 n_csh_sale = Math.Round(n_csh_sale, 0, MidpointRounding.AwayFromZero);
                 grs_sale = Math.Round(grs_sale, 0, MidpointRounding.AwayFromZero);
                



                bool csh_sale_negative = csh_sale < 0;
                bool n_csh_sale_negative = n_csh_sale < 0;
                bool grs_csh_sale_negative = grs_sale < 0;
                if (csh_sale_negative == false && n_csh_sale_negative == false && grs_csh_sale_negative == false)
                {
                    label5.Text = "B% : " + csh_sale + "%".ToString();
                    label6.Text = "C% : " + n_csh_sale + "%".ToString();
                    label7.Text = "$D : " + grs_sale + "$".ToString();
                    label8.Text = "E% : " + grs_sale + "%".ToString();

                }

                else
                {
                    if (csh_sale_negative == true)
                    {
                        label5.Text = "B% : " + csh_sale + "%".ToString();
                        label5.BackColor = System.Drawing.Color.Red;
                        label6.Text = "C% : " + n_csh_sale + "%".ToString();
                        label7.Text = "$D : " + grs_sale + "$".ToString();
                        label8.Text = "E% : " + grs_sale + "%".ToString();
                    }
                    if (n_csh_sale_negative == true)
                    {
                        label5.Text = "B% : " + csh_sale + "%".ToString();
                        label6.Text = "C% : " + n_csh_sale + "%".ToString();
                        label6.BackColor = System.Drawing.Color.Red;
                        label7.Text = "$D : " + grs_sale + "$".ToString();
                        label8.Text = "E% : " + grs_sale + "%".ToString();
                    }
                    if (grs_csh_sale_negative == true)
                    {
                        label5.Text = "B% : " + csh_sale + "%".ToString();
                        label6.Text = "C% : " + n_csh_sale + "%".ToString();
                        label7.Text = "$D : " + grs_sale + "$".ToString();
                        label8.Text = "E% : " + grs_sale + "%".ToString();
                        label8.BackColor = System.Drawing.Color.Red;
                        label7.BackColor = System.Drawing.Color.Red;
                    }
                }

            }

            //button 2
            //modify
            if (label16.Text == "---" && label19.Text == "---")
            {
                //label16.BackColor = System.Drawing.Color.Transparent;
                //label17.BackColor = System.Drawing.Color.Transparent;
                ////label18.BackColor = System.Drawing.Color.Transparent;
                //label19.BackColor = System.Drawing.Color.Transparent;
                //label20.BackColor = System.Drawing.Color.Transparent;
                //if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                //{
                //    string message = "Numeric Values is Missing";
                //    string title = "Alert";
                //    MessageBox.Show(message, title);
                //}
                //else
                //{
                //    String grosss_sale = textBox1.Text;
                //    String cashh_sale = textBox2.Text;
                //    String non_cashh_sale = textBox3.Text;
                //    f_val = textBox4.Text;
                //    //bool grosss_sale_isNumber = int.TryParse(grosss_sale, out int ga_sale);
                //    // bool cash_sale_isNumber = int.TryParse(cashh_sale, out int cc_sale);
                //    //bool non_cash_sale_isNumber = int.TryParse(non_cashh_sale, out int n_cc_sale);
                //    //bool f_val_isNumber = int.TryParse(f_val, out int f_vaal);
                //    bool grosss_sale_isFlost = double.TryParse(grosss_sale, out double f_ga_sale);
                //    bool cash_sale_isFlost = double.TryParse(cashh_sale, out double f_cc_sale);
                //    bool non_cash_isFlost = double.TryParse(non_cashh_sale, out double f_n_cc_sale);
                //    bool fisFlost = double.TryParse(f_val, out double f_vall);

                //    double g_percent = f_vall / f_ga_sale;


                //    double gg_percent = f_vall + g_percent;
                //    double ff_dollar = f_vall + g_percent;
                //    double n_csh_sale = f_n_cc_sale / f_ga_sale;
                //    double grs_sale = f_cc_sale + n_csh_sale;
                //    h_dollar = grs_sale - ff_dollar;
                //    double i_percent = grs_sale - gg_percent;

                //    g_percent = Math.Round(g_percent, 0, MidpointRounding.AwayFromZero);
                //    gg_percent = Math.Round(gg_percent, 0, MidpointRounding.AwayFromZero);
                //    ff_dollar = Math.Round(ff_dollar, 0, MidpointRounding.AwayFromZero);
                //    h_dollar = Math.Round(h_dollar, 0, MidpointRounding.AwayFromZero);
                //    i_percent = Math.Round(i_percent, 0, MidpointRounding.AwayFromZero);

                //    bool g_percent_negative = g_percent < 0;
                //    bool gg_percent_negative = gg_percent < 0;
                //    bool ff_dollar_negative = ff_dollar < 0;
                //    bool h_dollar_negative = h_dollar < 0;
                //    bool i_percent_negative = i_percent < 0;

                //    if (g_percent_negative == false && gg_percent_negative == false && ff_dollar_negative == false && h_dollar_negative == false && i_percent_negative == false)
                //    {
                //        label18.Text = g_percent + "%";

                //        label19.Text = "GG% : " + gg_percent + "%";

                //        label16.Text = "$FF : " + ff_dollar + "$";

                //        label17.Text = "$H :" + h_dollar + "$";

                //        label20.Text = "I% : " + i_percent + "%";
                //    }
                //    else
                //    {
                //        label18.Text = g_percent + "%";

                //        label19.Text = "GG% : " + gg_percent + "%";

                //        label16.Text = "$FF : " + ff_dollar + "$";

                //        label17.Text = "$H :" + h_dollar + "$";

                //        label20.Text = "I% : " + i_percent + "%";

                //        if (g_percent_negative == true)
                //        {
                //            label18.Text = g_percent + "%";
                //            label18.BackColor = System.Drawing.Color.Red;
                //        }
                //        if (gg_percent_negative == true)
                //        {
                //            label19.BackColor = System.Drawing.Color.Red;
                //            label19.Text = "GG% : " + gg_percent + "%";
                //        }
                //        if (ff_dollar_negative == true)
                //        {
                //            label16.BackColor = System.Drawing.Color.Red;
                //            label16.Text = "$FF : " + ff_dollar + "$";
                //        }
                //        if (h_dollar_negative == true)
                //        {
                //            label17.BackColor = System.Drawing.Color.Red;
                //            label17.Text = "$H :" + h_dollar + "$";
                //        }
                //        if (i_percent_negative == true)
                //        {
                //            label20.BackColor = System.Drawing.Color.Red;
                //            label20.Text = "I% : " + i_percent + "%";
                //        }
                //    }

                //}
                MessageBox.Show("Please Click on + Button to Calculate $FF and %GG", "$FF and %% Not Calculated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //CASE222222
            else
            {
                //label16.BackColor = System.Drawing.Color.Transparent;
                label17.BackColor = System.Drawing.Color.Transparent;
                //label18.BackColor = System.Drawing.Color.Transparent;
                //label19.BackColor = System.Drawing.Color.Transparent;
                label20.BackColor = System.Drawing.Color.Transparent;
                //if (textBox4.Text == "")
                //{
                   // textBox4.Text = "0";
                //}

                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    string message = "Numeric Values is Missing";
                    string title = "Alert";
                    MessageBox.Show(message, title);
                }
                else
                {
                    String grosss_sale = textBox1.Text;
                    String cashh_sale = textBox2.Text;
                    String non_cashh_sale = textBox3.Text;
                    String percent_gg = label19.Text;
                    String dolls_ff = label16.Text;

                    bool grosss_sale_isFlost = double.TryParse(grosss_sale, out double f_ga_sale);
                    bool cash_sale_isFlost = double.TryParse(cashh_sale, out double f_cc_sale);
                    bool non_cash_isFlost = double.TryParse(non_cashh_sale, out double f_n_cc_sale);

                    double.TryParse(percent_gg, out double gg_percent);
                    double.TryParse(dolls_ff, out double ff_dollar);

                    double n_csh_sale = f_n_cc_sale / f_ga_sale;
                    double grs_sale = f_cc_sale + n_csh_sale;
                    h_dollar = grs_sale - ff_dollar;
                    double i_percent = grs_sale - gg_percent;

                    //g_percent = Math.Round(g_percent, 0, MidpointRounding.AwayFromZero);
                    gg_percent = Math.Round(gg_percent, 0, MidpointRounding.AwayFromZero);
                    ff_dollar = Math.Round(ff_dollar, 0, MidpointRounding.AwayFromZero);
                    h_dollar = Math.Round(h_dollar, 0, MidpointRounding.AwayFromZero);
                    i_percent = Math.Round(i_percent, 0, MidpointRounding.AwayFromZero);


                    bool gg_percent_negative = gg_percent < 0;
                    bool ff_dollar_negative = ff_dollar < 0;
                    bool h_dollar_negative = h_dollar < 0;
                    bool i_percent_negative = i_percent < 0;

                    if (h_dollar_negative == false && i_percent_negative == false)
                    {

                        label17.Text = "$H :" + h_dollar + "$";

                        label20.Text = "I% : " + i_percent + "%";
                    }
                    else
                    {

                        label17.Text = "$H :" + h_dollar + "$";

                        label20.Text = "I% : " + i_percent + "%";

                        if (h_dollar_negative == true)
                        {
                            label17.BackColor = System.Drawing.Color.Red;
                            label17.Text = "$H :" + h_dollar + "$";
                        }
                        if (i_percent_negative == true)
                        {
                            label20.BackColor = System.Drawing.Color.Red;
                            label20.Text = "I% : " + i_percent + "%";
                        }
                    }

                }

            }
            //modifysss

            //button3
            //Mofiys J
            if (label21.Text == "---" && label11.Text == "---")
            {
                ////label12.BackColor = System.Drawing.Color.Transparent;
                //label21.BackColor = System.Drawing.Color.Transparent;
                //label11.BackColor = System.Drawing.Color.Transparent;
                //label32.BackColor = System.Drawing.Color.Transparent;
                //label23.BackColor = System.Drawing.Color.Transparent;
                //label40.BackColor = System.Drawing.Color.Transparent;
                //label41.BackColor = System.Drawing.Color.Transparent;

                //if (textBox1.Text == "" || textBox5.Text == "")
                //{
                //    string message = "Numeric Values is Missing For Gross Sale ($A) or $J Value";
                //    string title = "Alert";
                //    MessageBox.Show(message, title);
                //}
                //else
                //{
                //    String grossfs_sale = textBox1.Text;
                //    //String cashh_sale = textBox2.Text;
                //    //String non_cashh_sale = textBox3.Text;
                //    //String f_val = textBox4.Text;
                //    String dollar_j = textBox5.Text;
                //    bool dollar_j_isFlost = double.TryParse(dollar_j, out double j_val);
                //    bool grosfss_sale_isFlost = double.TryParse(grossfs_sale, out double ff_ga_sale);
                //    double k_percent = j_val / ff_ga_sale;
                //    double dollar_L_M_percent = j_val + k_percent;

                //    double percent_o, percent_q;

                //    if (checkBox1.Checked)
                //    {
                //        double.TryParse(textBox6.Text, out double new_n_val);
                //        percent_o = new_n_val / ff_ga_sale;
                //        label31.Text = new_n_val + " $".ToString();
                //    }
                //    else
                //    {


                //        String per_x = label26.Text;
                //        if (per_x == "Null")
                //        {
                //            label26.Text = "Null";
                //            double.TryParse(textBox6.Text, out double new_n_val);
                //            percent_o = new_n_val / ff_ga_sale;
                //            label31.Text = new_n_val + " $".ToString();
                //        }
                //        else
                //        {
                //            bool percent_x_isFlost = double.TryParse(per_x, out double x_val);
                //            double dollar_n = x_val * dollar_L_M_percent;
                //            dollar_n = Math.Round(dollar_n, 0, MidpointRounding.AwayFromZero);
                //            textBox6.Text = dollar_n.ToString();
                //            label31.Text = dollar_n + " $".ToString();
                //            double.TryParse(textBox6.Text, out double new_n_val);
                //            percent_o = new_n_val / ff_ga_sale;

                //        }
                //    }

                //    if (checkBox2.Checked)
                //    {
                //        double.TryParse(textBox7.Text, out double new_p_val);
                //        percent_q = new_p_val / ff_ga_sale;
                //        label22.Text = new_p_val + " $".ToString();
                //    }
                //    else
                //    {


                //        String perr_x = label38.Text;
                //        if (perr_x == "Null")
                //        {
                //            //label38.Text = "Null";
                //            double.TryParse(textBox7.Text, out double new_p_val);
                //            percent_q = new_p_val / ff_ga_sale;
                //            label22.Text = new_p_val + " $".ToString();
                //        }
                //        else
                //        {
                //            bool percent_xx_isFlost = double.TryParse(perr_x, out double xx_val);
                //            double dollar_p = xx_val * dollar_L_M_percent;
                //            dollar_p = Math.Round(dollar_p, 0, MidpointRounding.AwayFromZero);
                //            textBox7.Text = dollar_p.ToString();
                //            label22.Text = dollar_p + " $".ToString();
                //            percent_q = dollar_p / ff_ga_sale;


                //        }
                //    }

                //    double.TryParse(textBox7.Text, out double new_p_val_fr_r);
                //    double.TryParse(textBox6.Text, out double new_n_val_fr_r);
                //    dollar_r = dollar_L_M_percent + new_n_val_fr_r + new_p_val_fr_r;
                //    double percent_s = dollar_r / ff_ga_sale;


                //    percent_o = Math.Round(percent_o, 0, MidpointRounding.AwayFromZero);
                //    percent_q = Math.Round(percent_q, 0, MidpointRounding.AwayFromZero);
                //    k_percent = Math.Round(k_percent, 0, MidpointRounding.AwayFromZero);
                //    dollar_L_M_percent = Math.Round(dollar_L_M_percent, 0, MidpointRounding.AwayFromZero);
                //    dollar_r = Math.Round(dollar_r, 0, MidpointRounding.AwayFromZero);
                //    percent_s = Math.Round(percent_s, 0, MidpointRounding.AwayFromZero);

                //    bool percent_o_negative = percent_o < 0;
                //    bool percent_q_negative = percent_q < 0;
                //    bool k_percent_negative = k_percent < 0;
                //    bool L_dollar_M_negative = dollar_L_M_percent < 0;
                //    bool dollar_r_negative = dollar_r < 0;
                //    bool s_percent_negative = percent_s < 0;

                //    if (s_percent_negative == false && k_percent_negative == false && L_dollar_M_negative == false && percent_o_negative == false && percent_q_negative == false && dollar_r_negative == false)
                //    {
                //        label12.Text = "K% : " + k_percent + "%";
                //        label21.Text = dollar_L_M_percent.ToString();
                //        label11.Text = dollar_L_M_percent.ToString();
                //        label32.Text = percent_o + " %".ToString();
                //        label23.Text = percent_q + " %".ToString();
                //        label40.Text = dollar_r + " $".ToString();
                //        label41.Text = percent_s + " %".ToString();
                //    }
                //    else
                //    {
                //        label12.Text = "K% : " + k_percent + "%";
                //        label21.Text = dollar_L_M_percent.ToString();
                //        label11.Text = dollar_L_M_percent.ToString();
                //        label32.Text = percent_o + " %".ToString();
                //        label23.Text = percent_q + " %".ToString();
                //        label40.Text = dollar_r + " $".ToString();
                //        label41.Text = percent_s + " %".ToString();

                //        if (s_percent_negative == true)
                //        {
                //            label41.Text = percent_s + " %".ToString();
                //            label41.BackColor = System.Drawing.Color.Red;
                //        }
                //        if (dollar_r_negative == true)

                //        {
                //            label40.Text = dollar_r + " $".ToString();
                //            label40.BackColor = System.Drawing.Color.Red;
                //        }
                //        if (percent_q_negative == true)
                //        {
                //            label23.Text = percent_q + " %".ToString();
                //            label23.BackColor = System.Drawing.Color.Red;
                //        }
                //        if (percent_o_negative == true)
                //        {
                //            label32.Text = percent_o + " %".ToString();
                //            label32.BackColor = System.Drawing.Color.Red;
                //        }
                //        if (k_percent_negative == true)
                //        {
                //            label12.Text = "K% : " + k_percent + "%";
                //            label12.BackColor = System.Drawing.Color.Red;
                //        }
                //        if (L_dollar_M_negative == true)
                //        {
                //            label21.Text = dollar_L_M_percent.ToString();
                //            label11.Text = dollar_L_M_percent.ToString();
                //            label11.BackColor = System.Drawing.Color.Red;
                //            label21.BackColor = System.Drawing.Color.Red;
                //        }
                //    }

                //}
                MessageBox.Show("Please Click on + Button to Calculate $L and %M", "$L and %M Not Calculated", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            //case2================
            else
            {
                //label12.BackColor = System.Drawing.Color.Transparent;
                //  label21.BackColor = System.Drawing.Color.Transparent;
                //label11.BackColor = System.Drawing.Color.Transparent;
                label32.BackColor = System.Drawing.Color.Transparent;
                label23.BackColor = System.Drawing.Color.Transparent;
                label40.BackColor = System.Drawing.Color.Transparent;
                label41.BackColor = System.Drawing.Color.Transparent;

                //if (textBox5.Text == "")
                //{
                //    textBox5.Text = "0";
                //}

                if (textBox1.Text == "")
                {
                    string message = "Numeric Values is Missing For Gross Sale ($A) or $J Value";
                    string title = "Alert";
                    MessageBox.Show(message, title);
                }
                else
                {
                    String grossfs_sale = textBox1.Text;
                    //String cashh_sale = textBox2.Text;
                    //String non_cashh_sale = textBox3.Text;
                    //String f_val = textBox4.Text;
                    //String dollar_j = textBox5.Text;

                    //bool dollar_j_isFlost = double.TryParse(dollar_j, out double j_val);
                    bool grosfss_sale_isFlost = double.TryParse(grossfs_sale, out double ff_ga_sale);
                    //double k_percent = j_val / ff_ga_sale;
                    double.TryParse(label21.Text, out double dollar_L_M_percent);
                    //dollar_L_M_percent = j_val + k_percent;

                    double percent_o, percent_q;

                    if (checkBox1.Checked)
                    {
                        double.TryParse(textBox6.Text, out double new_n_val);
                        percent_o = new_n_val / ff_ga_sale;
                        label31.Text = new_n_val + " $".ToString();
                    }
                    else
                    {


                        String per_x = label26.Text;
                        if (per_x == "Null")
                        {
                            label26.Text = "Null";
                            double.TryParse(textBox6.Text, out double new_n_val);
                            percent_o = new_n_val / ff_ga_sale;
                            label31.Text = new_n_val + " $".ToString();
                        }
                        else
                        {
                            bool percent_x_isFlost = double.TryParse(per_x, out double x_val);
                            double dollar_n = x_val * dollar_L_M_percent;
                            dollar_n = Math.Round(dollar_n, 0, MidpointRounding.AwayFromZero);
                            textBox6.Text = dollar_n.ToString();
                            label31.Text = dollar_n + " $".ToString();
                            double.TryParse(textBox6.Text, out double new_n_val);
                            percent_o = new_n_val / ff_ga_sale;

                        }
                    }

                    if (checkBox2.Checked)
                    {
                        double.TryParse(textBox7.Text, out double new_p_val);
                        percent_q = new_p_val / ff_ga_sale;
                        label22.Text = new_p_val + " $".ToString();
                    }
                    else
                    {


                        String perr_x = label38.Text;
                        if (perr_x == "Null")
                        {
                            //label38.Text = "Null";
                            double.TryParse(textBox7.Text, out double new_p_val);
                            percent_q = new_p_val / ff_ga_sale;
                            label22.Text = new_p_val + " $".ToString();
                        }
                        else
                        {
                            bool percent_xx_isFlost = double.TryParse(perr_x, out double xx_val);
                            double dollar_p = xx_val * dollar_L_M_percent;
                            dollar_p = Math.Round(dollar_p, 0, MidpointRounding.AwayFromZero);
                            textBox7.Text = dollar_p.ToString();
                            label22.Text = dollar_p + " $".ToString();
                            percent_q = dollar_p / ff_ga_sale;


                        }
                    }

                    double.TryParse(textBox7.Text, out double new_p_val_fr_r);
                    double.TryParse(textBox6.Text, out double new_n_val_fr_r);
                    dollar_r = dollar_L_M_percent + new_n_val_fr_r + new_p_val_fr_r;
                    double percent_s = dollar_r / ff_ga_sale;


                    percent_o = Math.Round(percent_o, 0, MidpointRounding.AwayFromZero);
                    percent_q = Math.Round(percent_q, 0, MidpointRounding.AwayFromZero);
                    //k_percent = Math.Round(k_percent, 0, MidpointRounding.AwayFromZero);
                    dollar_L_M_percent = Math.Round(dollar_L_M_percent, 0, MidpointRounding.AwayFromZero);
                    dollar_r = Math.Round(dollar_r, 0, MidpointRounding.AwayFromZero);
                    percent_s = Math.Round(percent_s, 0, MidpointRounding.AwayFromZero);

                    bool percent_o_negative = percent_o < 0;
                    bool percent_q_negative = percent_q < 0;
                    //bool k_percent_negative = k_percent < 0;
                    bool L_dollar_M_negative = dollar_L_M_percent < 0;
                    bool dollar_r_negative = dollar_r < 0;
                    bool s_percent_negative = percent_s < 0;

                    if (s_percent_negative == false && L_dollar_M_negative == false && percent_o_negative == false && percent_q_negative == false && dollar_r_negative == false)
                    {
                        //label12.Text = "K% : " + k_percent + "%";
                        label21.Text = dollar_L_M_percent.ToString();
                        label11.Text = dollar_L_M_percent.ToString();
                        label32.Text = percent_o + " %".ToString();
                        label23.Text = percent_q + " %".ToString();
                        label40.Text = dollar_r + " $".ToString();
                        label41.Text = percent_s + " %".ToString();
                    }
                    else
                    {
                        //label12.Text = "K% : " + k_percent + "%";
                        label21.Text = dollar_L_M_percent.ToString();
                        label11.Text = dollar_L_M_percent.ToString();
                        label32.Text = percent_o + " %".ToString();
                        label23.Text = percent_q + " %".ToString();
                        label40.Text = dollar_r + " $".ToString();
                        label41.Text = percent_s + " %".ToString();

                        if (s_percent_negative == true)
                        {
                            label41.Text = percent_s + " %".ToString();
                            label41.BackColor = System.Drawing.Color.Red;
                        }
                        if (dollar_r_negative == true)

                        {
                            label40.Text = dollar_r + " $".ToString();
                            label40.BackColor = System.Drawing.Color.Red;
                        }
                        if (percent_q_negative == true)
                        {
                            label23.Text = percent_q + " %".ToString();
                            label23.BackColor = System.Drawing.Color.Red;
                        }
                        if (percent_o_negative == true)
                        {
                            label32.Text = percent_o + " %".ToString();
                            label32.BackColor = System.Drawing.Color.Red;
                        }
                        //if (k_percent_negative == true)
                        //{
                        //    label12.Text = "K% : " + k_percent + "%";
                        //    label12.BackColor = System.Drawing.Color.Red;
                        //}
                        //if (L_dollar_M_negative == true)
                        //{
                        //    label21.Text = "L$ : " + dollar_L_M_percent + "$";
                        //    label11.Text = "M% : " + dollar_L_M_percent + "%";
                        //    label11.BackColor = System.Drawing.Color.Red;
                        //    label21.BackColor = System.Drawing.Color.Red;
                        //}
                    }

                }
            }
            //Modify?j...

            //button4
            //modify dol t
            if (label66.Text == "---" && label68.Text == "---")
            {
                ////label45.BackColor = System.Drawing.Color.Transparent;
                //label57.BackColor = System.Drawing.Color.Transparent;
                //label58.BackColor = System.Drawing.Color.Transparent;
                //label66.BackColor = System.Drawing.Color.Transparent;
                //label68.BackColor = System.Drawing.Color.Transparent;
                //label71.BackColor = System.Drawing.Color.Transparent;
                //label70.BackColor = System.Drawing.Color.Transparent;
                //label80.BackColor = System.Drawing.Color.Transparent;
                //label81.BackColor = System.Drawing.Color.Transparent;
                //if (textBox1.Text == "" || textBox8.Text == "")
                //{
                //    string message = "Numeric Values is Missing For Gross Sale ($A) or $T Value";
                //    string title = "Alert";
                //    MessageBox.Show(message, title);
                //}
                //else
                //{
                //    String dollar_a = textBox1.Text;
                //    String dollar_ts = textBox8.Text;
                //    bool dollar_a_isFlost = double.TryParse(dollar_a, out double dollar_a_val);
                //    bool dollat_t_isFlost = double.TryParse(dollar_ts, out double dollar_t_val);
                //    double u_percent = dollar_t_val / dollar_a_val;

                //    double percent_u, dollar_t;
                //    if (checkBox3.Checked)
                //    {
                //        double.TryParse(textBox9.Text, out double new_t_val);
                //        percent_u = new_t_val / dollar_a_val;
                //        label57.Text = new_t_val + " $".ToString();
                //        dollar_t = new_t_val;
                //    }
                //    else
                //    {
                //        String perr_x = label63.Text;
                //        if (perr_x == "Null")
                //        {
                //            //label26.Text = "Null";
                //            double.TryParse(textBox9.Text, out double new_t_val);
                //            percent_u = new_t_val / dollar_a_val;
                //            label57.Text = new_t_val + " $".ToString();
                //            dollar_t = new_t_val;
                //        }
                //        else
                //        {
                //            bool percent_x_isFlost = double.TryParse(perr_x, out double v_val);
                //            double dollar_ts_val = v_val * dollar_a_val;
                //            dollar_t = dollar_ts_val;
                //            dollar_t = Math.Round(dollar_t, 0, MidpointRounding.AwayFromZero);
                //            textBox9.Text = dollar_t.ToString();
                //            label57.Text = dollar_t + " $".ToString();
                //            double.TryParse(textBox9.Text, out double new_t_val);
                //            percent_u = new_t_val / dollar_a_val;

                //        }
                //    }
                //    bool percent_u_negative = percent_u < 0;
                //    bool dollar_t_negative = dollar_t < 0;
                //    bool u_percent_negative = u_percent < 0;
                //    double.TryParse(textBox8.Text, out double real_t_val);
                //    bool real_dollar_t_negative = real_t_val < 0;
                //    double dollar_tt_uu_percent = percent_u + dollar_t + u_percent + real_t_val;
                //    bool dollar_tt_uu_percent_negative = dollar_tt_uu_percent < 0;
                //    double dollar_v, percent_w, dollar_vv, ww_percent;
                //    double.TryParse(label79.Text, out dollar_z);

                //    percent_u = Math.Round(percent_u, 0, MidpointRounding.AwayFromZero);
                //    u_percent = Math.Round(u_percent, 0, MidpointRounding.AwayFromZero);
                //    dollar_tt_uu_percent = Math.Round(dollar_tt_uu_percent, 0, MidpointRounding.AwayFromZero);

                //    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && label17.Text != "---" && label40.Text != "---")
                //    {
                //        dollar_v = h_dollar - dollar_r - dollar_tt_uu_percent;
                //        percent_w = dollar_v / dollar_a_val;
                //        dollar_vv = h_dollar - dollar_r - dollar_tt_uu_percent + dollar_z;
                //        ww_percent = dollar_vv / dollar_a_val;
                //    }
                //    else
                //    {
                //        dollar_v = 0;
                //        percent_w = 0;
                //        dollar_vv = 0;
                //        ww_percent = 0;
                //        string message = "$ V, W%, $VV and WW%  Can not be Calculated /n Please Calculate $H, $R and $TT First";
                //        string title = "Alert";
                //        MessageBox.Show(message, title);

                //    }

                //    dollar_v = Math.Round(dollar_v, 0, MidpointRounding.AwayFromZero);
                //    dollar_vv = Math.Round(dollar_vv, 0, MidpointRounding.AwayFromZero);
                //    ww_percent = Math.Round(ww_percent, 0, MidpointRounding.AwayFromZero);
                //    percent_w = Math.Round(percent_w, 0, MidpointRounding.AwayFromZero);

                //    bool dollar_v_negative = dollar_v < 0;
                //    bool dollar_vv_negative = dollar_vv < 0;
                //    bool percent_ww_negative = ww_percent < 0;
                //    bool percent_w_negative = percent_w < 0;

                //    if (percent_ww_negative == false && dollar_vv_negative == false && percent_w_negative == false && dollar_v_negative == false && dollar_tt_uu_percent_negative == false && percent_u_negative == false && dollar_t_negative == false && u_percent_negative == false)
                //    {
                //        label57.Text = dollar_t.ToString();
                //        label58.Text = percent_u.ToString();
                //        label45.Text = "U% : " + u_percent.ToString();
                //        label68.Text = dollar_tt_uu_percent.ToString();
                //        label66.Text = dollar_tt_uu_percent.ToString();
                //        label70.Text = "$V : " + dollar_v.ToString();
                //        label71.Text = "W% : " + percent_w.ToString();
                //        label80.Text = "$VV : " + dollar_vv.ToString();
                //        label81.Text = "WW% : " + ww_percent.ToString();

                //    }
                //    else
                //    {
                //        label57.Text = dollar_t.ToString();
                //        label58.Text = percent_u.ToString();
                //        label45.Text = "U% : " + u_percent.ToString();
                //        label68.Text = dollar_tt_uu_percent.ToString();
                //        label66.Text = dollar_tt_uu_percent.ToString();
                //        label70.Text = "$V : " + dollar_v.ToString();
                //        label71.Text = "W% : " + percent_w.ToString();
                //        label80.Text = "$VV : " + dollar_vv.ToString();
                //        label81.Text = "WW% : " + ww_percent.ToString();
                //        if (percent_ww_negative == true)
                //        {
                //            label81.Text = "WW% : " + ww_percent.ToString();
                //            label81.BackColor = System.Drawing.Color.Red;
                //        }
                //        if (dollar_vv_negative == true)
                //        {
                //            label80.Text = "$VV : " + dollar_vv.ToString();
                //            label80.BackColor = System.Drawing.Color.Red;
                //        }
                //        if (percent_w_negative == true)
                //        {
                //            label71.Text = "W% : " + percent_w.ToString();
                //            label71.BackColor = System.Drawing.Color.Red;
                //        }
                //        if (dollar_v_negative == true)
                //        {
                //            label70.Text = "$V : " + dollar_v.ToString();
                //            label70.BackColor = System.Drawing.Color.Red;
                //        }
                //        if (dollar_tt_uu_percent_negative == true)
                //        {
                //            label68.Text = dollar_tt_uu_percent.ToString();
                //            label68.BackColor = System.Drawing.Color.Red;
                //            label66.Text = dollar_tt_uu_percent.ToString();
                //            label66.BackColor = System.Drawing.Color.Red;

                //        }
                //        if (percent_u_negative == true)
                //        {
                //            label58.Text = percent_u.ToString();
                //            label58.BackColor = System.Drawing.Color.Red;

                //        }
                //        if (dollar_t_negative == true)
                //        {
                //            label57.Text = dollar_t.ToString();
                //            label57.BackColor = System.Drawing.Color.Red;

                //        }
                //        if (u_percent_negative == true)
                //        {
                //            label45.Text = "U% : " + u_percent.ToString();
                //            label45.BackColor = System.Drawing.Color.Red;
                //        }
                //    }
                //}
                MessageBox.Show("Please Click on + Button to Calculate $TT and %UU", "$TT and UU% Not Calculated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //case2...........
            else
            {
                //label45.BackColor = System.Drawing.Color.Transparent;
                label57.BackColor = System.Drawing.Color.Transparent;
                label58.BackColor = System.Drawing.Color.Transparent;
                //label66.BackColor = System.Drawing.Color.Transparent;
                //label68.BackColor = System.Drawing.Color.Transparent;
                label71.BackColor = System.Drawing.Color.Transparent;
                label70.BackColor = System.Drawing.Color.Transparent;
                label80.BackColor = System.Drawing.Color.Transparent;
                label81.BackColor = System.Drawing.Color.Transparent;
                //if (textBox8.Text == "")
                //{
                //    textBox8.Text = "0";
                //}
                if (textBox1.Text == "")
                {
                    string message = "Numeric Values is Missing For Gross Sale ($A)";
                    string title = "Alert";
                    MessageBox.Show(message, title);
                }
                else
                {
                    String dollar_a = textBox1.Text;
                    //String dollar_ts = textBox8.Text;
                    bool dollar_a_isFlost = double.TryParse(dollar_a, out double dollar_a_val);
                    //bool dollat_t_isFlost = double.TryParse(dollar_ts, out double dollar_t_val);
                    // double u_percent = dollar_t_val / dollar_a_val;

                    double percent_u, dollar_t;
                    if (checkBox3.Checked)
                    {
                        double.TryParse(textBox9.Text, out double new_t_val);
                        percent_u = new_t_val / dollar_a_val;
                        label57.Text = new_t_val + " $".ToString();
                        dollar_t = new_t_val;
                    }
                    else
                    {
                        String perr_x = label63.Text;
                        if (perr_x == "Null")
                        {
                            //label26.Text = "Null";
                            double.TryParse(textBox9.Text, out double new_t_val);
                            percent_u = new_t_val / dollar_a_val;
                            label57.Text = new_t_val + " $".ToString();
                            dollar_t = new_t_val;
                        }
                        else
                        {
                            bool percent_x_isFlost = double.TryParse(perr_x, out double v_val);
                            double dollar_ts_val = v_val * dollar_a_val;
                            dollar_t = dollar_ts_val;
                            dollar_t = Math.Round(dollar_t, 0, MidpointRounding.AwayFromZero);
                            textBox9.Text = dollar_t.ToString();
                            label57.Text = dollar_t + " $".ToString();
                            double.TryParse(textBox9.Text, out double new_t_val);
                            percent_u = new_t_val / dollar_a_val;

                        }
                    }
                    bool percent_u_negative = percent_u < 0;
                    bool dollar_t_negative = dollar_t < 0;
                    //bool u_percent_negative = u_percent < 0;
                    double.TryParse(label66.Text, out double dollar_tt_uu_percent);
                    //double.TryParse(textBox8.Text, out double real_t_val);
                    //bool real_dollar_t_negative = real_t_val < 0;
                    dollar_tt_uu_percent = percent_u + dollar_t + dollar_tt_uu_percent;
                    bool dollar_tt_uu_percent_negative = dollar_tt_uu_percent < 0;
                    double dollar_v, percent_w, dollar_vv, ww_percent;
                    double.TryParse(label79.Text, out dollar_z);


                    percent_u = Math.Round(percent_u, 0, MidpointRounding.AwayFromZero);
                    //u_percent = Math.Round(u_percent, 0, MidpointRounding.AwayFromZero);
                    dollar_tt_uu_percent = Math.Round(dollar_tt_uu_percent, 0, MidpointRounding.AwayFromZero);

                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && label17.Text != "---" && label40.Text != "---")
                    {
                        dollar_v = h_dollar - dollar_r - dollar_tt_uu_percent;
                        percent_w = dollar_v / dollar_a_val;
                        dollar_vv = h_dollar - dollar_r - dollar_tt_uu_percent + dollar_z;
                        ww_percent = dollar_vv / dollar_a_val;
                    }
                    else
                    {
                        dollar_v = 0;
                        percent_w = 0;
                        dollar_vv = 0;
                        ww_percent = 0;
                        string message = "$ V, W%, $VV and WW%  Can not be Calculated /n Please Calculate $H, $R and $TT First";
                        string title = "Alert";
                        MessageBox.Show(message, title);

                    }


                    dollar_v = Math.Round(dollar_v, 0, MidpointRounding.AwayFromZero);
                    dollar_vv = Math.Round(dollar_vv, 0, MidpointRounding.AwayFromZero);
                    ww_percent = Math.Round(ww_percent, 0, MidpointRounding.AwayFromZero);
                    percent_w = Math.Round(percent_w, 0, MidpointRounding.AwayFromZero);

                    bool dollar_v_negative = dollar_v < 0;
                    bool dollar_vv_negative = dollar_vv < 0;
                    bool percent_ww_negative = ww_percent < 0;
                    bool percent_w_negative = percent_w < 0;

                    if (percent_ww_negative == false && dollar_vv_negative == false && percent_w_negative == false && dollar_v_negative == false && dollar_tt_uu_percent_negative == false && percent_u_negative == false && dollar_t_negative == false)
                    {
                        label57.Text = dollar_t.ToString();
                        label58.Text = percent_u.ToString();
                        //label45.Text = "U% : " + u_percent.ToString();
                        label68.Text = dollar_tt_uu_percent.ToString();
                        label66.Text = dollar_tt_uu_percent.ToString();
                        label70.Text = "$V : " + dollar_v.ToString();
                        label71.Text = "W% : " + percent_w.ToString();
                        label80.Text = "$VV : " + dollar_vv.ToString();
                        label81.Text = "WW% : " + ww_percent.ToString();

                    }
                    else
                    {
                        label57.Text = dollar_t.ToString();
                        label58.Text = percent_u.ToString();
                        //label45.Text = "U% : " + u_percent.ToString();
                        label68.Text = dollar_tt_uu_percent.ToString();
                        label66.Text = dollar_tt_uu_percent.ToString();
                        label70.Text = "$V : " + dollar_v.ToString();
                        label71.Text = "W% : " + percent_w.ToString();
                        label80.Text = "$VV : " + dollar_vv.ToString();
                        label81.Text = "WW% : " + ww_percent.ToString();
                        if (percent_ww_negative == true)
                        {
                            label81.Text = "WW% : " + ww_percent.ToString();
                            label81.BackColor = System.Drawing.Color.Red;
                        }
                        if (dollar_vv_negative == true)
                        {
                            label80.Text = "$VV : " + dollar_vv.ToString();
                            label80.BackColor = System.Drawing.Color.Red;
                        }
                        if (percent_w_negative == true)
                        {
                            label71.Text = "W% : " + percent_w.ToString();
                            label71.BackColor = System.Drawing.Color.Red;
                        }
                        if (dollar_v_negative == true)
                        {
                            label70.Text = "$V : " + dollar_v.ToString();
                            label70.BackColor = System.Drawing.Color.Red;
                        }
                        if (dollar_tt_uu_percent_negative == true)
                        {
                            label68.Text = dollar_tt_uu_percent.ToString();
                            label68.BackColor = System.Drawing.Color.Red;
                            label66.Text = dollar_tt_uu_percent.ToString();
                            label66.BackColor = System.Drawing.Color.Red;

                        }
                        if (percent_u_negative == true)
                        {
                            label58.Text = percent_u.ToString();
                            label58.BackColor = System.Drawing.Color.Red;

                        }
                        if (dollar_t_negative == true)
                        {
                            label57.Text = dollar_t.ToString();
                            label57.BackColor = System.Drawing.Color.Red;

                        }
                        //if (u_percent_negative == true)
                        //{
                        //    label45.Text = "U% : " + u_percent.ToString();
                        //    label45.BackColor = System.Drawing.Color.Red;
                        //}
                    }
                }
            }

            //modifus dt???

        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You sure you want to reset all fields? ", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                ctk = -1;
                ctk2 = -1;
                comboBox1.Text = "Please Select...";
                comboBox3.Text = "Select Labor Type...";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                //label45.BackColor = System.Drawing.Color.Transparent;
                label57.BackColor = System.Drawing.Color.Transparent;
                label58.BackColor = System.Drawing.Color.Transparent;
                label66.BackColor = System.Drawing.Color.Transparent;
                label68.BackColor = System.Drawing.Color.Transparent;
                label71.BackColor = System.Drawing.Color.Transparent;
                label70.BackColor = System.Drawing.Color.Transparent;
                label80.BackColor = System.Drawing.Color.Transparent;
                label81.BackColor = System.Drawing.Color.Transparent;
                //label12.BackColor = System.Drawing.Color.Transparent;
                label21.BackColor = System.Drawing.Color.Transparent;
                label11.BackColor = System.Drawing.Color.Transparent;
                label32.BackColor = System.Drawing.Color.Transparent;
                label23.BackColor = System.Drawing.Color.Transparent;
                label40.BackColor = System.Drawing.Color.Transparent;
                label41.BackColor = System.Drawing.Color.Transparent;
                label16.BackColor = System.Drawing.Color.Transparent;
                label17.BackColor = System.Drawing.Color.Transparent;
                //label18.BackColor = System.Drawing.Color.Transparent;
                label19.BackColor = System.Drawing.Color.Transparent;
                label20.BackColor = System.Drawing.Color.Transparent;
                label5.BackColor = System.Drawing.Color.Transparent;
                label6.BackColor = System.Drawing.Color.Transparent;
                label7.BackColor = System.Drawing.Color.Transparent;
                label8.BackColor = System.Drawing.Color.Transparent;

                label57.Text = "---";
                //label45.Text = "---";
                label58.Text = "---";
                label66.Text = "---";
                label68.Text = "---";
                label71.Text = "---";
                label70.Text = "---";

                label80.Text = "---";
                label81.Text = "---";
                //label12.Text = "---";
                label21.Text = "---";
                label11.Text = "---";
                label23.Text = "---";
                label32.Text = "---";
                label40.Text = "---";
                label41.Text = "---";

                label5.Text = "---";
                label6.Text = "---";
                label7.Text = "---";
                label8.Text = "---";
                label16.Text = "---";
                label17.Text = "---";
                //label18.Text = "---";
                label19.Text = "---";
                label20.Text = "---";

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                //textBox4.Text = null;
                //textBox5.Text = null;
                textBox7.Text = null;
                //textBox8.Text = null;
                textBox9.Text = null;
                textBox6.Text = null;
                //database
                cmd.Parameters.Clear();
                string qry = "UPDATE reused_values_tb SET key_status='5' WHERE key_status='1'";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                int rows = cmd.ExecuteNonQuery();

                //database
                cmd.Parameters.Clear();
                string qrsy = "UPDATE reused_values_jk SET key_status='5' WHERE key_status='1'";
                cmd.CommandText = qrsy;
                cmd.Connection = db_conect;
                int rowse = cmd.ExecuteNonQuery();

                //Update
                //database
                cmd.Parameters.Clear();
                string qryy = "UPDATE reused_values_tu SET status_key='5' WHERE status_key='1'";
                cmd.CommandText = qryy;
                cmd.Connection = db_conect;
                int rrows = cmd.ExecuteNonQuery();
            }
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(ctk==1 || ctk2==1)
            {
                MessageBox.Show("Sucessfully Saved Data");
            }
            else
            {
                if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
                {
                    MessageBox.Show("Failed to Save Data");
                }
                else
                {
                    //save to database
                    cmd.Parameters.Clear();
                    string qry = "insert into profit_loss_tb (sale_rev_gross_sale,sale_rev_cash_sale,sale_rev_non_cash_sale,cash_sale_b_percent,non_cash_sale_c_percent,gross_sale_dollar_d,gross_sale_percent_e,cog_dollar_ff,cog_percent_gg,cog_dollar_h,cog_percent_I,dollar_l,percent_m,x_percent,dollar_n,o_percent,xx_percent,dollar_p,q_percent,dollar_r,percent_s,v_percent,new_dollar_t,new_u_percent,dollar_tt,percent_uu,dollar_v,percent_w,dollar_z,dollar_vv,percent_ww) VALUES (@sale_rev_gross_sale,@sale_rev_cash_sale,@sale_rev_non_cash_sale,@cash_sale_b_percent,@non_cash_sale_c_percent,@gross_sale_dollar_d,@gross_sale_percent_e,@cog_dollar_ff,@cog_percent_gg,@cog_dollar_h,@cog_percent_I,@dollar_l,@percent_m,@x_percent,@dollar_n,@o_percent,@xx_percent,@dollar_p,@q_percent,@dollar_r,@percent_s,@v_percent,@new_dollar_t,@new_u_percent,@dollar_tt,@percent_uu,@dollar_v,@percent_w,@dollar_z,@dollar_vv,@percent_ww) ";
                    cmd.CommandText = qry;
                    cmd.Connection = db_conect;
                    //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                    cmd.Parameters.AddWithValue("@sale_rev_gross_sale", textBox1.Text);
                    cmd.Parameters.AddWithValue("@sale_rev_cash_sale", textBox2.Text);
                    cmd.Parameters.AddWithValue("@sale_rev_non_cash_sale", textBox3.Text);
                    cmd.Parameters.AddWithValue("@cash_sale_b_percent", label5.Text);

                    cmd.Parameters.AddWithValue("@non_cash_sale_c_percent", label6.Text);
                    cmd.Parameters.AddWithValue("@gross_sale_dollar_d", label7.Text);
                    cmd.Parameters.AddWithValue("@gross_sale_percent_e", label8.Text);
                    //cmd.Parameters.Add("@cost_of_good_gross_sale", textBox4.Text);
                    //cmd.Parameters.Add("@cost_of_good_gross_sale_g_percent", label18.Text);

                    cmd.Parameters.AddWithValue("@cog_dollar_ff", label16.Text);
                    cmd.Parameters.AddWithValue("@cog_percent_gg", label19.Text);
                    cmd.Parameters.AddWithValue("@cog_dollar_h", label17.Text);
                    cmd.Parameters.AddWithValue("@cog_percent_I", label20.Text);
                    //cmd.Parameters.AddWithValue("@labor_exp_dollar_j", textBox5.Text);

                    //cmd.Parameters.AddWithValue("@labor_k_percent", label12.Text);
                    cmd.Parameters.AddWithValue("@dollar_l", label21.Text);
                    cmd.Parameters.AddWithValue("@percent_m", label11.Text);
                    cmd.Parameters.AddWithValue("@x_percent", label26.Text);
                    cmd.Parameters.AddWithValue("@dollar_n", textBox6.Text);

                    cmd.Parameters.AddWithValue("@o_percent", label32.Text);
                    cmd.Parameters.AddWithValue("@xx_percent", label38.Text);
                    cmd.Parameters.AddWithValue("@dollar_p", textBox7.Text);
                    cmd.Parameters.AddWithValue("@q_percent", label23.Text);
                    cmd.Parameters.AddWithValue("@dollar_r", label40.Text);

                    cmd.Parameters.AddWithValue("@percent_s", label41.Text);
                    //cmd.Parameters.AddWithValue("@dollar_t", textBox8.Text);
                    //cmd.Parameters.AddWithValue("@u_percent", label45.Text);
                    cmd.Parameters.AddWithValue("@v_percent", label63.Text);
                    cmd.Parameters.AddWithValue("@new_dollar_t", textBox9.Text);

                    cmd.Parameters.AddWithValue("@new_u_percent", label41.Text);
                    cmd.Parameters.AddWithValue("@dollar_tt", label66.Text);
                    cmd.Parameters.AddWithValue("@percent_uu", label68.Text);
                    cmd.Parameters.AddWithValue("@dollar_v", label63.Text);
                    cmd.Parameters.AddWithValue("@percent_w", textBox9.Text);

                    cmd.Parameters.AddWithValue("@dollar_z", label79.Text);
                    cmd.Parameters.AddWithValue("@dollar_vv", label80.Text);
                    cmd.Parameters.AddWithValue("@percent_ww", label81.Text);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {

                        //fetching refKey
                        string q = "SELECT TOP(1) tb_id FROM profit_loss_tb ORDER BY tb_id DESC";
                        cmd.CommandText = q;
                        cmd.Connection = db_conect;
                        adopt = new SqlDataAdapter(cmd);
                        adopt.Fill(refkey_dt);

                        foreach (DataRow dr in refkey_dt.Rows)
                        {
                            refskey = dr["tb_id"].ToString();

                        }


                        //database
                        cmd.Parameters.Clear();
                        string qry1 = "UPDATE reused_values_tb SET key_status='2', ref_key='" + refskey + "' WHERE key_status='1'";
                        cmd.CommandText = qry1;
                        cmd.Connection = db_conect;
                        int rowss = cmd.ExecuteNonQuery();


                        //database
                        cmd.Parameters.Clear();
                        string qrsy = "UPDATE reused_values_jk SET key_status='2', refr_key='" + refskey + "' WHERE key_status='1'";
                        cmd.CommandText = qrsy;
                        cmd.Connection = db_conect;
                        int rowse = cmd.ExecuteNonQuery();
                        //Update
                        //database
                        cmd.Parameters.Clear();
                        string qryy = "UPDATE reused_values_tu SET status_key='2',refrs_key='" + refskey + "' WHERE status_key='1'";
                        cmd.CommandText = qryy;
                        cmd.Connection = db_conect;
                        int rrows = cmd.ExecuteNonQuery();
                        //Update
                        ctk = 1;
                        MessageBox.Show(rows + " Record Saved TO Database Sucessfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save Data");
                        ctk2 = 0;
                    }
                }
            }
            
           
        }

        private void button12_Click(object sender, EventArgs e)
        {

            //database
            cmd.Parameters.Clear();
            string qry = "UPDATE reused_values_tb SET key_status='5' WHERE key_status='1'";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            int rows = cmd.ExecuteNonQuery();

            //database
            cmd.Parameters.Clear();
            string qrsy = "UPDATE reused_values_jk SET key_status='5' WHERE key_status='1'";
            cmd.CommandText = qrsy;
            cmd.Connection = db_conect;
            int rowse = cmd.ExecuteNonQuery();

            //Update
            //database
            cmd.Parameters.Clear();
            string qryy = "UPDATE reused_values_tu SET status_key='5' WHERE status_key='1'";
            cmd.CommandText = qryy;
            cmd.Connection = db_conect;
            int rrows = cmd.ExecuteNonQuery();
            //Update

            Form9 f9 = new Form9(this);
            f9.ShowDialog();
            //this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(ctk==1 || ctk2==1)
            {

                profit_loss_Report pfrp = new profit_loss_Report();
                pfrp.ShowDialog();
            }
            else
            {
                if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
                {
                    MessageBox.Show("Failed to Save Data");
                }
                else
                {
                    //save to database
                    cmd.Parameters.Clear();
                    string qry = "insert into profit_loss_tb (sale_rev_gross_sale,sale_rev_cash_sale,sale_rev_non_cash_sale,cash_sale_b_percent,non_cash_sale_c_percent,gross_sale_dollar_d,gross_sale_percent_e,cog_dollar_ff,cog_percent_gg,cog_dollar_h,cog_percent_I,dollar_l,percent_m,x_percent,dollar_n,o_percent,xx_percent,dollar_p,q_percent,dollar_r,percent_s,v_percent,new_dollar_t,new_u_percent,dollar_tt,percent_uu,dollar_v,percent_w,dollar_z,dollar_vv,percent_ww) VALUES (@sale_rev_gross_sale,@sale_rev_cash_sale,@sale_rev_non_cash_sale,@cash_sale_b_percent,@non_cash_sale_c_percent,@gross_sale_dollar_d,@gross_sale_percent_e,@cog_dollar_ff,@cog_percent_gg,@cog_dollar_h,@cog_percent_I,@dollar_l,@percent_m,@x_percent,@dollar_n,@o_percent,@xx_percent,@dollar_p,@q_percent,@dollar_r,@percent_s,@v_percent,@new_dollar_t,@new_u_percent,@dollar_tt,@percent_uu,@dollar_v,@percent_w,@dollar_z,@dollar_vv,@percent_ww) ";
                    cmd.CommandText = qry;
                    cmd.Connection = db_conect;
                    //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                    cmd.Parameters.AddWithValue("@sale_rev_gross_sale", textBox1.Text);
                    cmd.Parameters.AddWithValue("@sale_rev_cash_sale", textBox2.Text);
                    cmd.Parameters.AddWithValue("@sale_rev_non_cash_sale", textBox3.Text);
                    cmd.Parameters.AddWithValue("@cash_sale_b_percent", label5.Text);

                    cmd.Parameters.AddWithValue("@non_cash_sale_c_percent", label6.Text);
                    cmd.Parameters.AddWithValue("@gross_sale_dollar_d", label7.Text);
                    cmd.Parameters.AddWithValue("@gross_sale_percent_e", label8.Text);
                    //cmd.Parameters.Add("@cost_of_good_gross_sale", textBox4.Text);
                    //cmd.Parameters.Add("@cost_of_good_gross_sale_g_percent", label18.Text);

                    cmd.Parameters.AddWithValue("@cog_dollar_ff", label16.Text);
                    cmd.Parameters.AddWithValue("@cog_percent_gg", label19.Text);
                    cmd.Parameters.AddWithValue("@cog_dollar_h", label17.Text);
                    cmd.Parameters.AddWithValue("@cog_percent_I", label20.Text);
                    //cmd.Parameters.AddWithValue("@labor_exp_dollar_j", textBox5.Text);

                    //cmd.Parameters.AddWithValue("@labor_k_percent", label12.Text);
                    cmd.Parameters.AddWithValue("@dollar_l", label21.Text);
                    cmd.Parameters.AddWithValue("@percent_m", label11.Text);
                    cmd.Parameters.AddWithValue("@x_percent", label26.Text);
                    cmd.Parameters.AddWithValue("@dollar_n", textBox6.Text);

                    cmd.Parameters.AddWithValue("@o_percent", label32.Text);
                    cmd.Parameters.AddWithValue("@xx_percent", label38.Text);
                    cmd.Parameters.AddWithValue("@dollar_p", textBox7.Text);
                    cmd.Parameters.AddWithValue("@q_percent", label23.Text);
                    cmd.Parameters.AddWithValue("@dollar_r", label40.Text);

                    cmd.Parameters.AddWithValue("@percent_s", label41.Text);
                    //cmd.Parameters.AddWithValue("@dollar_t", textBox8.Text);
                    //cmd.Parameters.AddWithValue("@u_percent", label45.Text);
                    cmd.Parameters.AddWithValue("@v_percent", label63.Text);
                    cmd.Parameters.AddWithValue("@new_dollar_t", textBox9.Text);

                    cmd.Parameters.AddWithValue("@new_u_percent", label58.Text);
                    cmd.Parameters.AddWithValue("@dollar_tt", label66.Text);
                    cmd.Parameters.AddWithValue("@percent_uu", label68.Text);
                    cmd.Parameters.AddWithValue("@dollar_v", label70.Text);
                    cmd.Parameters.AddWithValue("@percent_w", label71.Text);

                    cmd.Parameters.AddWithValue("@dollar_z", label79.Text);
                    cmd.Parameters.AddWithValue("@dollar_vv", label80.Text);
                    cmd.Parameters.AddWithValue("@percent_ww", label81.Text);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {

                        //fetching refKey
                        string q = "SELECT TOP(1) tb_id FROM profit_loss_tb ORDER BY tb_id DESC";
                        cmd.CommandText = q;
                        cmd.Connection = db_conect;
                        adopt = new SqlDataAdapter(cmd);
                        adopt.Fill(refkey_dt);

                        foreach (DataRow dr in refkey_dt.Rows)
                        {
                            refskey = dr["tb_id"].ToString();

                        }


                        //database
                        cmd.Parameters.Clear();
                        string qry1 = "UPDATE reused_values_tb SET key_status='2', ref_key='" + refskey + "' WHERE key_status='1'";
                        cmd.CommandText = qry1;
                        cmd.Connection = db_conect;
                        int rowss = cmd.ExecuteNonQuery();

                        //database
                        cmd.Parameters.Clear();
                        string qrsy = "UPDATE reused_values_jk SET key_status='2', refr_key='" + refskey + "' WHERE key_status='1'";
                        cmd.CommandText = qrsy;
                        cmd.Connection = db_conect;
                        int rowse = cmd.ExecuteNonQuery();

                        //Update

                        //database
                        cmd.Parameters.Clear();
                        string qryy = "UPDATE reused_values_tu SET status_key='2',refrs_key='" + refskey + "' WHERE status_key='1'";
                        cmd.CommandText = qryy;
                        cmd.Connection = db_conect;
                        int rrows = cmd.ExecuteNonQuery();
                        //Update
                        ctk2 = 1;
                        profit_loss_Report pfrp = new profit_loss_Report();
                        pfrp.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save Data");
                        ctk2 = 0;
                    }
                }
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            

            if (label16.Text == "--g-" || label19.Text == "--g-")
            {
                string message = "Previous Calculated Value($FF and GG%) Will Be Lost Do You Wish to Continue?";
                string title = "Close Window";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    //database
                    label16.Text = "---";
                    label19.Text = "---";
                    cmd.Parameters.Clear();
                    string qry = "UPDATE reused_values_tb SET key_status='5' WHERE key_status='1'";
                    cmd.CommandText = qry;
                    cmd.Connection = db_conect;
                    int rows = cmd.ExecuteNonQuery();

                    //Update

                    dollar_f_vals dfval = new dollar_f_vals(this);
                    dfval.ShowDialog();
                }

            }
            else
            {
                dollar_f_vals dfval = new dollar_f_vals(this);
                dfval.ShowDialog();
            }

        }

        public void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar =='\b' || e.KeyChar == (char)Keys.Enter) //The  character represents a backspace
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
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if(label21.Text =="-j--" || label11.Text =="-j--")
            {
                string message = "Previous Calculated Value($l and M%) Will Be Lost Do You Wish to Continue?";
                string title = "Close Window";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    //database
                    label21.Text = "---";
                    label11.Text = "---";
                    cmd.Parameters.Clear();
                    string qrsy = "UPDATE reused_values_jk SET key_status='5' WHERE key_status='1'";
                    cmd.CommandText = qrsy;
                    cmd.Connection = db_conect;
                    int rowse = cmd.ExecuteNonQuery();

                    //Update

                    dollar_j_vals djval = new dollar_j_vals(this);
                    djval.ShowDialog();
                }
             
            }
            else
            {
                dollar_j_vals djval = new dollar_j_vals(this);
                djval.ShowDialog();
            }
            
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
           

            if (label66.Text == "-t--" || label68.Text == "-t--")
            {
                string message = "Previous Calculated Value($TT and UU%) Will Be Lost Do You Wish to Continue?";
                string title = "Close Window";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    //database
                    label66.Text = "---";
                    label68.Text = "---";
                    //database
                    cmd.Parameters.Clear();
                    string qryy = "UPDATE reused_values_tu SET status_key='5' WHERE status_key='1'";
                    cmd.CommandText = qryy;
                    cmd.Connection = db_conect;
                    int rrows = cmd.ExecuteNonQuery();
                    //Update

 

                    dollar_t_vals tvals = new dollar_t_vals(this);
                    tvals.ShowDialog();
                }

            }
            else
            {
                dollar_t_vals tvals = new dollar_t_vals(this);
                tvals.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //modify
            if(label16.Text=="---" && label19.Text=="---")
            {
                MessageBox.Show("Please Click on + Button to Calculate $FF and %GG", "$FF and %% Not Calculated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //CASE222222
            else
            {
                //label16.BackColor = System.Drawing.Color.Transparent;
                label17.BackColor = System.Drawing.Color.Transparent;
                label20.BackColor = System.Drawing.Color.Transparent;
            
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    string message = "Numeric Values is Missing";
                    string title = "Alert";
                    MessageBox.Show(message, title);
                }
                else
                {
                    //String grosss_sale = textBox1.Text;
                    //String cashh_sale = textBox2.Text;
                    //String non_cashh_sale = textBox3.Text;
                    //String percent_gg = label19.Text;
                    //String dolls_ff = label16.Text;
                    string str2 = "";
                    tbx1 = textBox1.Text;
                    tbx1 = tbx1.Replace("$", str2);
                    tbx1 = tbx1.Replace(",", str2);
                    tbx1 = tbx1.Replace(".", str2);

                    tbx2 = textBox2.Text;
                    tbx2 = tbx2.Replace("$", str2);
                    tbx2 = tbx2.Replace(",", str2);
                    tbx2 = tbx2.Replace(".", str2);

                    tbx3 = textBox3.Text;
                    tbx3 = tbx3.Replace("$", str2);
                    tbx3 = tbx3.Replace(",", str2);
                    tbx3 = tbx3.Replace(".", str2);


                    gross_sale = tbx1;
                    cash_sale = tbx2;
                    non_cash_sale = tbx3;


                    String grosss_sale = tbx1;
                    String cashh_sale = tbx2;
                    String non_cashh_sale = tbx3;

                    String dolls_ff = label16.Text;
                    String percent_gg = label19.Text;

                    if (dolls_ff.Contains("|"))
                    {
                        string[] tokens1 = dolls_ff.Split('|');
                        dolls_ff = tokens1[0];
                        percent_gg = tokens1[1];
                    }
                    string str21 = "";
                    dolls_ff = dolls_ff.Replace("$", str21);
                    dolls_ff = dolls_ff.Replace(",", str21);
                    dolls_ff = dolls_ff.Replace(".", str21);

                    percent_gg = percent_gg.Replace("%", str21);





                    bool grosss_sale_isFlost = double.TryParse(grosss_sale, out double f_ga_sale);
                    bool cash_sale_isFlost = double.TryParse(cashh_sale, out double f_cc_sale);
                    bool non_cash_isFlost = double.TryParse(non_cashh_sale, out double f_n_cc_sale);

                    double.TryParse(percent_gg, out double gg_percent);
                    double.TryParse(dolls_ff, out double ff_dollar);

                    double fcsh_sale = f_cc_sale / f_ga_sale; //B%
                    double n_csh_sale = f_n_cc_sale / f_ga_sale; //C%
                    double grs_sale = f_cc_sale + f_n_cc_sale; //$D
                    double ep = n_csh_sale + fcsh_sale; //E%
                    ep = ep * 100;
                    h_dollar = grs_sale - ff_dollar;
                    double i_percent = ep - gg_percent;
                    double iper = (ep - gg_percent)/ 100;


                    //bool gg_percent_negative = gg_percent < 0;
                    //bool ff_dollar_negative = ff_dollar < 0;
                    bool h_dollar_negative = h_dollar < 0;
                    bool i_percent_negative = iper < 0;

                    if ( h_dollar_negative == false && i_percent_negative == false)
                    {

                        string d_h = h_dollar.ToString();
                        string p_i = iper.ToString();
                        d_h = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(d_h));
                        p_i = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(p_i));
                        label17.Text = d_h+"   |   "+p_i;
                    }
                    else
                    {
                        string d_h = h_dollar.ToString();
                        string p_i = iper.ToString();
                        d_h = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(d_h));
                        p_i = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(p_i));
                        label17.Text = d_h + "   |   " + p_i;

                        if (h_dollar_negative == true)
                        {
                            label17.BackColor = System.Drawing.Color.Red;
                            //label17.Text = "$H :" + h_dollar + "$";
                        }
                        //if (i_percent_negative == true)
                        //{
                        //    label20.BackColor = System.Drawing.Color.Red;
                        //    label20.Text = "I% : " + i_percent + "%";
                        //}
                    }

                }

            }
            //modifysss
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //modify dol t
            if(label66.Text=="---" && label68.Text=="---")
            {
                
                MessageBox.Show("Please Click on + Button to Calculate $TT and %UU", "$TT and UU% Not Calculated", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            //case2...........
            else
            {
                //label45.BackColor = System.Drawing.Color.Transparent;
                label57.BackColor = System.Drawing.Color.Transparent;
                label58.BackColor = System.Drawing.Color.Transparent;
                //label66.BackColor = System.Drawing.Color.Transparent;
                //label68.BackColor = System.Drawing.Color.Transparent;
                label71.BackColor = System.Drawing.Color.Transparent;
                label70.BackColor = System.Drawing.Color.Transparent;
                label80.BackColor = System.Drawing.Color.Transparent;
                label81.BackColor = System.Drawing.Color.Transparent;

                String perr_xs = label63.Text;
                if (textBox1.Text == "" || perr_xs == "Null" && textBox7.Text == "" || textBox7.Text == null)
                {
                    string message = "Numeric Values is Missing For Gross Sale ($A)";
                    string title = "Alert";
                    MessageBox.Show(message, title);
                }
                else
                {
                    string str2 = "";
                    tbx1 = textBox1.Text;
                    tbx1 = tbx1.Replace("$", str2);
                    tbx1 = tbx1.Replace(",", str2);
                    tbx1 = tbx1.Replace(".", str2);

                    string d_t_val = label66.Text;
                    string per_uu_val = label67.Text;
                    if (d_t_val.Contains("|"))
                    {
                        string[] tokens1 = d_t_val.Split('|');
                        d_t_val = tokens1[0];
                        per_uu_val = tokens1[1];
                    }
                    string str21 = "";
                    d_t_val = d_t_val.Replace("$", str21);
                    d_t_val = d_t_val.Replace(",", str21);
                    d_t_val = d_t_val.Replace(".", str21);

                    per_uu_val = per_uu_val.Replace("%", str21);


                    String grossfs_sale = tbx1;


                    String dollar_a = tbx1;
                    //String dollar_ts = textBox8.Text;
                    bool dollar_a_isFlost = double.TryParse(dollar_a, out double dollar_a_val);
                    //bool dollat_t_isFlost = double.TryParse(dollar_ts, out double dollar_t_val);
                   // double u_percent = dollar_t_val / dollar_a_val;

                    double percent_u, dollar_t;
                    if (checkBox3.Checked)
                    {
                        double.TryParse(textBox9.Text, out double new_t_val);
                        percent_u = new_t_val / dollar_a_val;
                        label57.Text = new_t_val + " $".ToString();
                        dollar_t = new_t_val;
                    }
                    else
                    {
                        String perr_x = label63.Text;
                        if (perr_x == "Null")
                        {
                            //label26.Text = "Null";
                            double.TryParse(textBox9.Text, out double new_t_val);
                            percent_u = new_t_val / dollar_a_val;
                            label57.Text = new_t_val + " $".ToString();
                            dollar_t = new_t_val;
                        }
                        else
                        {
                            bool percent_x_isFlost = double.TryParse(perr_x, out double v_val);
                            double dollar_ts_val = v_val * dollar_a_val;
                            dollar_t = dollar_ts_val;
                            textBox9.Text = dollar_t.ToString();
                            label57.Text = dollar_t + " $".ToString();
                            double.TryParse(textBox9.Text, out double new_t_val);
                            percent_u = new_t_val / dollar_a_val;

                        }
                    }
                    bool percent_u_negative = percent_u < 0;
                    bool dollar_t_negative = dollar_t < 0;
                    //bool u_percent_negative = u_percent < 0;
                    double.TryParse(d_t_val, out double dollar_tts);
                    //double.TryParse(textBox8.Text, out double real_t_val);
                    //bool real_dollar_t_negative = real_t_val < 0;
                    ////////////dollar_tts = percent_u + dollar_t + dollar_tts;
                    
                    bool dollar_tt_uu_percent_negative = dollar_tts < 0;
                    double dollar_v, percent_w, dollar_vv, ww_percent;
                    double.TryParse(label79.Text, out dollar_z);
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && label17.Text != "---" && label40.Text != "---")
                    {
                        dollar_v = h_dollar - dollar_r - dollar_tts;
                        percent_w = dollar_v / dollar_a_val;
                        dollar_vv = h_dollar - dollar_r - dollar_tts + dollar_z;
                        ww_percent = dollar_vv / dollar_a_val;
                    }
                    else
                    {
                        dollar_v = 0;
                        percent_w = 0;
                        dollar_vv = 0;
                        ww_percent = 0;
                        string message = "$ V, W%, $VV and WW%  Can not be Calculated /n Please Calculate $H, $R and $TT First";
                        string title = "Alert";
                        MessageBox.Show(message, title);

                    }

                    bool dollar_v_negative = dollar_v < 0;
                    bool dollar_vv_negative = dollar_vv < 0;
                    bool percent_ww_negative = ww_percent < 0;
                    bool percent_w_negative = percent_w < 0;

                    if (percent_ww_negative == false && dollar_vv_negative == false && percent_w_negative == false && dollar_v_negative == false && dollar_tt_uu_percent_negative == false && percent_u_negative == false && dollar_t_negative == false)
                    {
                        label57.Text = dollar_t.ToString();
                        label58.Text = percent_u.ToString();
                        //label45.Text = "U% : " + u_percent.ToString();
                        label68.Text = dollar_tts.ToString();
                       // label66.Text = dollar_tt_uu_percent.ToString();
                        label70.Text = "$V : " + dollar_v.ToString();
                        label71.Text = "W% : " + percent_w.ToString();
                        label80.Text = "$VV : " + dollar_vv.ToString();
                        label81.Text = "WW% : " + ww_percent.ToString();

                    }
                    else
                    {
                        label57.Text = dollar_t.ToString();
                        label58.Text = percent_u.ToString();
                       //label45.Text = "U% : " + u_percent.ToString();
                       // label68.Text = dollar_tt_uu_percent.ToString();
                        //label66.Text = dollar_tt_uu_percent.ToString();
                        label70.Text = "$V : " + dollar_v.ToString();
                        label71.Text = "W% : " + percent_w.ToString();
                        label80.Text = "$VV : " + dollar_vv.ToString();
                        label81.Text = "WW% : " + ww_percent.ToString();
                        if (percent_ww_negative == true)
                        {
                            label81.Text = "WW% : " + ww_percent.ToString();
                            label81.BackColor = System.Drawing.Color.Red;
                        }
                        if (dollar_vv_negative == true)
                        {
                            label80.Text = "$VV : " + dollar_vv.ToString();
                            label80.BackColor = System.Drawing.Color.Red;
                        }
                        if (percent_w_negative == true)
                        {
                            label71.Text = "W% : " + percent_w.ToString();
                            label71.BackColor = System.Drawing.Color.Red;
                        }
                        if (dollar_v_negative == true)
                        {
                            label70.Text = "$V : " + dollar_v.ToString();
                            label70.BackColor = System.Drawing.Color.Red;
                        }
                        if (dollar_tt_uu_percent_negative == true)
                        {
                            label68.Text = dollar_tts.ToString();
                            label68.BackColor = System.Drawing.Color.Red;
                           // label66.Text = dollar_tt_uu_percent.ToString();
                           // label66.BackColor = System.Drawing.Color.Red;

                        }
                        if (percent_u_negative == true)
                        {
                            label58.Text = percent_u.ToString();
                            label58.BackColor = System.Drawing.Color.Red;

                        }
                        if (dollar_t_negative == true)
                        {
                            label57.Text = dollar_t.ToString();
                            label57.BackColor = System.Drawing.Color.Red;

                        }
                        //if (u_percent_negative == true)
                        //{
                        //    label45.Text = "U% : " + u_percent.ToString();
                        //    label45.BackColor = System.Drawing.Color.Red;
                        //}
                    }
                }
            }

            //modifus dt???
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Mofiys J
            if(label21.Text=="---" && label11.Text=="---")
            {
               
                MessageBox.Show("Please Click on + Button to Calculate $L and %M", "$L and %M Not Calculated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //case2================
            else
            {
           
                label32.BackColor = System.Drawing.Color.Transparent;
                label23.BackColor = System.Drawing.Color.Transparent;
                label40.BackColor = System.Drawing.Color.Transparent;
                label41.BackColor = System.Drawing.Color.Transparent;

                String per_xs = label26.Text;
                String perr_xs = label38.Text;
                if (textBox1.Text == "" || per_xs == "Null" && textBox6.Text == "" || textBox6.Text == null || perr_xs == "Null" && textBox7.Text == "" || textBox7.Text == null)
                {
                    string message = "Values is Missing For Gross Sale OR $P,$N not Availble ";
                    string title = "Alert";
                    MessageBox.Show(message, title);
                }
                else
                {
                   
                    string str2 = "";
                    tbx1 = textBox1.Text;
                    tbx1 = tbx1.Replace("$", str2);
                    tbx1 = tbx1.Replace(",", str2);
                    tbx1 = tbx1.Replace(".", str2);


                    String grossfs_sale = tbx1;
                    string d_l_val = label21.Text;
                    string per_m_val=label11.Text;
                    if (d_l_val.Contains("|"))
                    {
                        string[] tokens1 = d_l_val.Split('|');
                        d_l_val = tokens1[0];
                        per_m_val = tokens1[1];
                    }
                    string str21 = "";
                    d_l_val = d_l_val.Replace("$", str21);
                    d_l_val = d_l_val.Replace(",", str21);
                    d_l_val = d_l_val.Replace(".", str21);

                    per_m_val = per_m_val.Replace("%", str21);


                    //String cashh_sale = textBox2.Text;
                    //String non_cashh_sale = textBox3.Text;
                    //String f_val = textBox4.Text;
                    //String dollar_j = textBox5.Text;

                    //bool dollar_j_isFlost = double.TryParse(dollar_j, out double j_val);
                    bool grosfss_sale_isFlost = double.TryParse(grossfs_sale, out double ff_ga_sale);
                    //double k_percent = j_val / ff_ga_sale;
                    double.TryParse(d_l_val, out double dollar_L);
                    double.TryParse(per_m_val, out double M_percent);
                    //dollar_L_M_percent = j_val + k_percent;

                    double percent_o, percent_q;

                    if (checkBox1.Checked)
                    {
                        //string str22 = "";
                        tbx6 = textBox6.Text;
                        tbx6 = tbx6.Replace("$", str2);
                        tbx6 = tbx6.Replace(",", str2);
                        tbx6 = tbx6.Replace(".", str2);
                        double.TryParse(tbx6, out double new_n_val);
                        percent_o = new_n_val / ff_ga_sale;
                        //label31.Text = new_n_val.ToString();
                        //label31.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label31.Text));

                    }
                    else
                    {


                        String per_x = label26.Text;
                        if (per_x == "Null")
                        {
                            
                            label26.Text = "Null";
                            //string str22s = "";
                            tbx6 = textBox6.Text;
                            tbx6 = tbx6.Replace("$", str2);
                            tbx6 = tbx6.Replace(",", str2);
                            tbx6 = tbx6.Replace(".", str2);
                            double.TryParse(tbx6, out double new_n_val);
                            percent_o = new_n_val / ff_ga_sale;
                            //label31.Text = new_n_val.ToString();
                            //label31.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label31.Text));
                        }
                        else
                        {
                            bool percent_x_isFlost = double.TryParse(per_x, out double x_val);
                            x_val = x_val / 100;
                            double dollar_n = x_val * dollar_L;//dividng values
                            tbx6= dollar_n.ToString();
                            textBox6.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(tbx6));
                            //label31.Text = dollar_n.ToString();
                            // label31.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label31.Text));
                            double.TryParse(tbx6, out double new_n_val);
                            percent_o = new_n_val / ff_ga_sale;

                        }
                    }

                    if (checkBox2.Checked)
                    {
                        tbx7 = textBox7.Text;
                        tbx7 = tbx7.Replace("$", str2);
                        tbx7 = tbx7.Replace(",", str2);
                        tbx7 = tbx7.Replace(".", str2);
                        double.TryParse(tbx7, out double new_p_val);
                        percent_q = new_p_val / ff_ga_sale;
                        //label22.Text = new_p_val.ToString();
                        //label22.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label22.Text));
                    }
                    else
                    {


                        String perr_x = label38.Text;
                        if (perr_x == "Null")
                        {
                            //label38.Text = "Null";
                            tbx7 = textBox7.Text;
                            tbx7 = tbx7.Replace("$", str2);
                            tbx7 = tbx7.Replace(",", str2);
                            tbx7 = tbx7.Replace(".", str2);
                            double.TryParse(tbx7, out double new_p_val);
                            percent_q = new_p_val / ff_ga_sale;
                           // label22.Text = new_p_val .ToString();
                            //label22.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label22.Text));
                        }
                        else
                        {
                            bool percent_xx_isFlost = double.TryParse(perr_x, out double xx_val);
                            xx_val = xx_val / 100;
                            double dollar_p = xx_val * dollar_L;
                            tbx7 = dollar_p.ToString();
                            textBox7.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(tbx7));
                            //label22.Text = dollar_p.ToString();
                            //label22.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label22.Text));
                            percent_q = dollar_p / ff_ga_sale;


                        }
                    }

                    string str22 = "";
                    tbx6 = textBox6.Text;
                    tbx6 = tbx6.Replace("$", str22);
                    tbx6 = tbx6.Replace(",", str22);
                    tbx6 = tbx6.Replace(".", str22);

                    tbx7 = textBox7.Text;
                    tbx7 = tbx7.Replace("$", str22);
                    tbx7 = tbx7.Replace(",", str22);
                    tbx7 = tbx7.Replace(".", str22);

                    double.TryParse(tbx7, out double new_p_val_fr_r);
                    double.TryParse(tbx6, out double new_n_val_fr_r);
                    dollar_r = dollar_L + new_n_val_fr_r + new_p_val_fr_r;
                    double percent_s = dollar_r / ff_ga_sale;

                    bool percent_o_negative = percent_o < 0;
                    bool percent_q_negative = percent_q < 0;
                    //bool k_percent_negative = k_percent < 0;
                   // bool L_dollar_M_negative = dollar_L_M_percent < 0;
                    bool dollar_r_negative = dollar_r < 0;
                    bool s_percent_negative = percent_s < 0;

                    if (s_percent_negative == false  && percent_o_negative == false && percent_q_negative == false && dollar_r_negative == false)
                    {
                        //label12.Text = "K% : " + k_percent + "%";
                        //label21.Text = dollar_L_M_percent.ToString();
                        //label11.Text = dollar_L_M_percent.ToString();
                        string po = percent_o.ToString();
                        po = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(po));
                        label32.Text =textBox6.Text+"   |   "+po;
                        //label32.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(label32.Text));
                        string pq = percent_q.ToString();
                        pq = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(pq));
                        label23.Text = textBox7.Text + "   |   " + pq;
                        //label23.Text = percent_q .ToString();
                        //label23.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(label23.Text));
                        label40.Text = dollar_r.ToString();
                        label40.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label40.Text));
                        label41.Text = percent_s.ToString();
                        label41.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(label41.Text));
                    }
                    else
                    {
                        ////label12.Text = "K% : " + k_percent + "%";
                        ////label21.Text = dollar_L_M_percent.ToString();
                        ////label11.Text = dollar_L_M_percent.ToString();
                        //label32.Text = percent_o + " %".ToString();
                        //label23.Text = percent_q + " %".ToString();
                        //label40.Text = dollar_r + " $".ToString();
                        //label41.Text = percent_s + " %".ToString();
                        //label32.Text = percent_o.ToString();
                        //label32.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(label32.Text));
                        string po = percent_o.ToString();
                        po = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(po));
                        label32.Text = textBox6.Text + "   |   " + po;
                        //label23.Text = percent_q.ToString();
                        //label23.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(label23.Text));
                        string pq = percent_q.ToString();
                        pq = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(pq));
                        label23.Text = textBox7.Text + "   |   " + pq;
                        label40.Text = dollar_r.ToString();
                        label40.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label40.Text));
                        label41.Text = percent_s.ToString();
                        label41.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(label41.Text));

                        if (s_percent_negative == true)
                        {
                            label41.Text = percent_s.ToString();
                            label41.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(label41.Text));
                            label41.BackColor = System.Drawing.Color.Red;
                        }
                        if (dollar_r_negative == true)

                        {
                            label40.Text = dollar_r.ToString();
                            label40.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(label40.Text));
                            label40.BackColor = System.Drawing.Color.Red;
                        }
                        if (percent_q_negative == true)
                        {
                            //label23.Text = percent_q .ToString();
                            //label23.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(label23.Text));
                            label23.BackColor = System.Drawing.Color.Red;
                        }
                        if (percent_o_negative == true)
                        {
                            //label32.Text = percent_o.ToString();
                            //label32.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P1}", double.Parse(label32.Text));
                            label32.BackColor = System.Drawing.Color.Red;
                        }
                        //if (k_percent_negative == true)
                        //{
                        //    label12.Text = "K% : " + k_percent + "%";
                        //    label12.BackColor = System.Drawing.Color.Red;
                        //}
                        //if (L_dollar_M_negative == true)
                        //{
                        //    label21.Text = "L$ : " + dollar_L_M_percent + "$";
                        //    label11.Text = "M% : " + dollar_L_M_percent + "%";
                        //    label11.BackColor = System.Drawing.Color.Red;
                        //    label21.BackColor = System.Drawing.Color.Red;
                        //}
                    }

                }
            }
            //Modify?...
            
        }

        private void button16_Click(object sender, EventArgs e)
        {

            //database
            cmd.Parameters.Clear();
            string qry = "UPDATE reused_values_tb SET key_status='5' WHERE key_status='1'";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            int rows = cmd.ExecuteNonQuery();


            //database
            cmd.Parameters.Clear();
            string qrsy = "UPDATE reused_values_jk SET key_status='5' WHERE key_status='1'";
            cmd.CommandText = qrsy;
            cmd.Connection = db_conect;
            int rowse = cmd.ExecuteNonQuery();

            //Update
            //database
            cmd.Parameters.Clear();
            string qryy = "UPDATE reused_values_tu SET status_key='5' WHERE status_key='1'";
            cmd.CommandText = qryy;
            cmd.Connection = db_conect;
            int rrows = cmd.ExecuteNonQuery();
            //Update

            DropDown_menu dpm = new DropDown_menu(this);
            dpm.ShowDialog();
            //this.Hide();

        }

        public static void contest()
        {
            try
            {
                if(db_conect.State != ConnectionState.Open)
                {
                    db_conect.ConnectionString = con_str;
                    db_conect.Open();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox7.Text != "")
            {
                string name = textBox7.Text;
                string str2 = "";
                string result = name.Replace("$", str2);
                result = result.Replace(",", str2);
                //result = result.Replace(".", str2);
                if (result.Contains("."))
                {
                    string[] tokens = result.Split('.');
                    textBox7.Text = tokens[0];
                }
                else
                {
                    textBox7.Text = result;
                }

                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
                if (e.KeyChar == (char)13)
                {
                    //tbx1 = textBox1.Text;
                    textBox7.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox7.Text));
                    //SendKeys.Send("{TAB}");
                }

            }
        }

        public void set_ff_dol_val(double dolsff)
        {

           label19.Text = dolsff.ToString();
            label16.Text = dolsff.ToString();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox6.Text != "")
            {
                string name = textBox6.Text;
                string str2 = "";
                string result = name.Replace("$", str2);
                result = result.Replace(",", str2);
                //result = result.Replace(".", str2);
                if (result.Contains("."))
                {
                    string[] tokens = result.Split('.');
                    textBox6.Text = tokens[0];
                }
                else
                {
                    textBox6.Text = result;
                }

                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
                if (e.KeyChar == (char)13)
                {
                    //tbx1 = textBox1.Text;
                    textBox6.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox6.Text));
                    //SendKeys.Send("{TAB}");
                }

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
                    //tbx1 = textBox1.Text;
                    textBox1.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox1.Text));
                    //SendKeys.Send("{TAB}");
                }
            
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text != "")
            {
                string name = textBox2.Text;
                string str2 = "";
                string result = name.Replace("$", str2);
                result = result.Replace(",", str2);
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
                    //tbx2 = textBox2.Text;
                    textBox2.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox2.Text));
                    //SendKeys.Send("{TAB}");
                }

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox3.Text != "")
            {
                string name = textBox3.Text;
                string str2 = "";
                string result = name.Replace("$", str2);
                result = result.Replace(",", str2);
                //result = result.Replace(".", str2);
                if (result.Contains("."))
                {
                    string[] tokens = result.Split('.');
                    textBox3.Text = tokens[0];
                }
                else
                {
                    textBox3.Text = result;
                }

                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
                if (e.KeyChar == (char)13)
                {
                    //tbx3 = textBox3.Text;
                    textBox3.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(textBox3.Text));
                    //SendKeys.Send("{TAB}");
                }

            }
        }

        public static void fill_combox()
        {
            string qry = "select * From dropdowns_tb WHERE dropdown1 IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(combox_dt);

        }

        private void Profit_Loss_Calculations_FormClosing(object sender, FormClosingEventArgs e)
        {
            //form closing...
            DialogResult dialogResult = MessageBox.Show("Do You want to Exit ?", "You are About to Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                //database
                cmd.Parameters.Clear();
                string qry = "UPDATE reused_values_tb SET key_status='5' WHERE key_status='1'";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                int rows = cmd.ExecuteNonQuery();

                //database
                cmd.Parameters.Clear();
                string qrsy = "UPDATE reused_values_jk SET key_status='5' WHERE key_status='1'";
                cmd.CommandText = qrsy;
                cmd.Connection = db_conect;
                int rowse = cmd.ExecuteNonQuery();

                //Update
                //database
                cmd.Parameters.Clear();
                string qryy = "UPDATE reused_values_tu SET status_key='5' WHERE status_key='1'";
                cmd.CommandText = qryy;
                cmd.Connection = db_conect;
                int rrows = cmd.ExecuteNonQuery();

                System.Environment.Exit(1);

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                e.Cancel = true;
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }


        public static void fill_combox3()
        {
            string qry = "select * From dropdowns_tb WHERE dropdown3 IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(combox_3_dt);

        }



        private void Form7_Load(object sender, EventArgs e)
        {

            //db_conect.ConnectionString = con_str;
            //db_conect.Open();
            combox_dt.Clear();
            //combox_2_dt.Clear();
            combox_3_dt.Clear();
            //combox_4_dt.Clear();
            //combox_5_dt.Clear();
            ctk = -1;
            ctk2 = -1;
            contest();
            fill_combox();
            //fill_combox2();
            fill_combox3();
            //fill_combox4();
            //fill_combox5();
            comboBox1.DataSource = combox_dt;
            comboBox1.DisplayMember = "dropdown1";
            comboBox1.Text ="Please Select...";

            //comboBox2.DataSource = combox_2_dt;
            //comboBox2.DisplayMember = "dropdown2";
            //comboBox2.Text = "Please Select...";



            comboBox3.DataSource = combox_3_dt;
            comboBox3.DisplayMember = "dropdown3";
            comboBox3.Text = "Select Labor Type...";


            string qry = "select * From free_values WHERE v_id=1";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(defined_data);
            string pperr_x, pperr_xx, pper_v, ddollar_z;
            foreach (DataRow dr in defined_data.Rows)
            {
                pperr_x = dr["percent_x"].ToString();
                label26.Text = pperr_x;
                pperr_xx = dr["percent_xx"].ToString();
                label38.Text = pperr_xx;

                pper_v = dr["percent_v"].ToString();
                label63.Text = pper_v;
                ddollar_z = dr["dollar_z"].ToString();
                label79.Text = ddollar_z;
            }

    
            button7.Enabled = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "---";
            label6.Text = "---";
            label7.Text = "---";
            label8.Text = "---";
            label5.BackColor = System.Drawing.Color.Transparent;
            label6.BackColor = System.Drawing.Color.Transparent;
            label7.BackColor = System.Drawing.Color.Transparent;
            label8.BackColor = System.Drawing.Color.Transparent;


            if (textBox1.Text=="" || textBox2.Text == "" || textBox3.Text == "" )
            {
                string message = "Some Numeric Values is Missing";
                string title = "Alert";
                MessageBox.Show(message, title);
            }
            else
            {
                //gross_sale = textBox1.Text;
                //cash_sale = textBox2.Text;
                //non_cash_sale = textBox3.Text;

        
                string str2 = "";
                tbx1 = textBox1.Text;
                tbx1 = tbx1.Replace("$", str2);
                tbx1 = tbx1.Replace(",", str2);
                tbx1 = tbx1.Replace(".", str2);

                tbx2 = textBox2.Text;
                tbx2 = tbx2.Replace("$", str2);
                tbx2 = tbx2.Replace(",", str2);
                tbx2 = tbx2.Replace(".", str2);

                tbx3 = textBox3.Text;
                tbx3 = tbx3.Replace("$", str2);
                tbx3 = tbx3.Replace(",", str2);
                tbx3 = tbx3.Replace(".", str2);


                gross_sale = tbx1;
                cash_sale = tbx2;
                non_cash_sale = tbx3;
                //bool gross_sale_isNumber = int.TryParse(gross_sale, out int g_sale);
                //bool cash_sale_isNumber = int.TryParse(cash_sale, out int c_sale);
                //bool non_cash_sale_isNumber = int.TryParse(non_cash_sale, out int n_c_sale);
                bool grosss_sale_isFlost = double.TryParse(gross_sale, out double g_sale);
                bool cash_sale_isFlost = double.TryParse(cash_sale, out double c_sale);
                bool non_cash_isFlost = double.TryParse(non_cash_sale, out double n_c_sale);


                //double csh_sale = c_sale / g_sale; on14 sep
                //double n_csh_sale = n_c_sale / g_sale;on14 sep
                //double grs_sale = c_sale + n_csh_sale;on14 sep

                double csh_sale = c_sale / g_sale;
                double n_csh_sale = n_c_sale / g_sale;
                double grs_sale = c_sale + n_c_sale;
                double eper = n_csh_sale + csh_sale;

                bool csh_sale_negative = csh_sale < 0;
                bool n_csh_sale_negative = n_csh_sale < 0;
                bool grs_csh_sale_negative = grs_sale < 0;
                bool e_negative = eper < 0;

                if (csh_sale_negative == false && n_csh_sale_negative == false && grs_csh_sale_negative == false && e_negative==false)
                {
                    label5.Text = csh_sale.ToString();
                    label6.Text = n_csh_sale .ToString();
                    string dds = grs_sale.ToString();
                    string eps= eper.ToString();
                    label5.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label5.Text));
                    label6.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label6.Text));
                    dds= string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(dds));
                    eps= string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(eps));
                    label7.Text = dds + "    |    " + eps;

                }

                else
                {
                    if(csh_sale_negative== true)
                    {
                        label5.Text = csh_sale.ToString();
                        label5.BackColor = System.Drawing.Color.Red;
                        label6.Text = n_csh_sale.ToString();
                        string dds = grs_sale.ToString();
                        string eps = eper.ToString();
                        label5.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label5.Text));
                        label6.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label6.Text));
                        dds = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(dds));
                        eps = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(eps));
                        label7.Text = dds + "  -  " + eps;

                    }
                    if (n_csh_sale_negative == true)
                    {

                        label5.Text = csh_sale.ToString();
                        label6.Text = n_csh_sale.ToString();
                        label6.BackColor = System.Drawing.Color.Red;
                        string dds = grs_sale.ToString();
                        string eps = eper.ToString();
                        label5.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label5.Text));
                        label6.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label6.Text));
                        dds = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(dds));
                        eps = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(eps));
                        label7.Text = dds + "  -  " + eps;



                    }
                    if (grs_csh_sale_negative == true)
                    {
                        
                        label5.Text = csh_sale.ToString();
                        label6.Text = n_csh_sale.ToString();
                        string dds = grs_sale.ToString();
                        string eps = eper.ToString();
                        label5.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label5.Text));
                        label6.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label6.Text));
                        dds = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(dds));
                        eps = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(eps));
                        label7.Text = dds + "  -  " + eps;
                        label7.BackColor = System.Drawing.Color.Red;

                    }
                    if (e_negative == true)
                    {

                        label5.Text = csh_sale.ToString();
                        label6.Text = n_csh_sale.ToString();
                        string dds = grs_sale.ToString();
                        string eps = eper.ToString();
                        label5.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label5.Text));
                        label6.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(label6.Text));
                        dds = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C0}", double.Parse(dds));
                        eps = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:P0}", double.Parse(eps));
                        label7.Text = dds + "  -  " + eps;
                        label7.BackColor = System.Drawing.Color.Red;
                    }
                }

            }
           

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //float csh_sale = textBox_KeyPress.c_sale / g_sale;
            //label5.Text = csh_sale.ToString();
        }

        
    }
}

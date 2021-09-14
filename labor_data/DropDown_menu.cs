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
    public partial class DropDown_menu : Form
    {
        Profit_Loss_Calculations plsc;
        public DropDown_menu(Profit_Loss_Calculations prf)
        {
            InitializeComponent();
            listBox1.Click += new EventHandler(ListBox1_Click);
            listBox2.Click += new EventHandler(ListBox2_Click);
            listBox3.Click += new EventHandler(ListBox3_Click);
            listBox4.Click += new EventHandler(ListBox4_Click);
            listBox5.Click += new EventHandler(ListBox5_Click);
            plsc = prf;
            button3.Click += new EventHandler(button3_Click);
        }
        public static SqlCommand cmd = new SqlCommand();
        public static SqlConnection db_conect = new SqlConnection();
        public static SqlDataAdapter adopt = new SqlDataAdapter();
        public static DataTable dt_dropdown = new DataTable();
        public static DataTable dt_dropdown2 = new DataTable();
        public static DataTable dt_dropdown3 = new DataTable();
        public static DataTable dt_dropdown4 = new DataTable();
        public static DataTable dt_dropdown5 = new DataTable();
        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
            {
                MessageBox.Show("Can Not Enter Empty Values");
            }
            else
            {
                if (textBox1.Text != "")
                {
                    
                    cmd.Parameters.Clear();
                    string qry = "insert into dropdowns_tb (dropdown1) VALUES (@dp1) ";
                    cmd.CommandText = qry;
                    cmd.Connection = db_conect;
                    //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                    cmd.Parameters.AddWithValue("@dp1", textBox1.Text);
                  

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        textBox1.Text = null;
                        dt_dropdown.Clear();

                        fill_listbox();
                        listBox1.DataSource = dt_dropdown;
                        listBox1.DisplayMember = "dropdown1";
                        listBox1.ClearSelected();

                    }
                    else
                    {
                        MessageBox.Show("Failed to Save Data");
                    }
                }
                if (textBox2.Text != "")
                {
                    cmd.Parameters.Clear();
                    string qry = "insert into dropdowns_tb (dropdown2) VALUES (@dp2) ";
                    cmd.CommandText = qry;
                    cmd.Connection = db_conect;
                    //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                    cmd.Parameters.AddWithValue("@dp2", textBox2.Text);


                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        textBox2.Text = null;
                        dt_dropdown2.Clear();

                        fill_listbox2();
                        listBox2.DataSource = dt_dropdown2;
                        listBox2.DisplayMember = "dropdown2";
                        listBox2.ClearSelected();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save Data");
                    }
                }
                if (textBox3.Text != "")
                {
                    cmd.Parameters.Clear();
                    string qry = "insert into dropdowns_tb (dropdown3) VALUES (@dp3) ";
                    cmd.CommandText = qry;
                    cmd.Connection = db_conect;
                    //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                    cmd.Parameters.AddWithValue("@dp3", textBox3.Text);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        textBox3.Text = null;
                        dt_dropdown3.Clear();

                        fill_listbox3();
                        listBox3.DataSource = dt_dropdown3;
                        listBox3.DisplayMember = "dropdown3";
                        listBox3.ClearSelected();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save Data");
                    }
                }
                if (textBox4.Text != "")
                {
                    cmd.Parameters.Clear();
                    string qry = "insert into dropdowns_tb (dropdown4) VALUES (@dp4) ";
                    cmd.CommandText = qry;
                    cmd.Connection = db_conect;
                    //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                    cmd.Parameters.AddWithValue("@dp4", textBox4.Text);


                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        dt_dropdown4.Clear();
                        textBox4.Text = null;
                        fill_listbox4();
                        listBox4.DataSource = dt_dropdown4;
                        listBox4.DisplayMember = "dropdown4";
                        listBox4.ClearSelected();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save Data");
                    }
                }
                if (textBox5.Text != "")
                {
                    cmd.Parameters.Clear();
                    string qry = "insert into dropdowns_tb (dropdown5) VALUES (@dp5) ";
                    cmd.CommandText = qry;
                    cmd.Connection = db_conect;
                    //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                    cmd.Parameters.AddWithValue("@dp5", textBox5.Text);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        textBox5.Text = null;
                        dt_dropdown5.Clear();

                        fill_listbox5();
                        listBox5.DataSource = dt_dropdown5;
                        listBox5.DisplayMember = "dropdown5";
                        listBox5.ClearSelected();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save Data");
                    }
                }
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

        public static void fill_listbox()
        {
            string qry = "select * From dropdowns_tb WHERE dropdown1 IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(dt_dropdown);
            
        }


        public static void fill_listbox5()
        {
            string qry = "select * From dropdowns_tb WHERE dropdown5 IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(dt_dropdown5);

        }

        public static void fill_listbox2()
        {
            string qry = "select * From dropdowns_tb WHERE dropdown2 IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(dt_dropdown2);

        }

        public static void fill_listbox3()
        {
            string qry = "select * From dropdowns_tb WHERE dropdown3 IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(dt_dropdown3);

        }

        public static void fill_listbox4()
        {
            string qry = "select * From dropdowns_tb WHERE dropdown4 IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(dt_dropdown4);

        }

        private void DropDown_menu_Load(object sender, EventArgs e)
        {
            dt_dropdown.Clear();
            dt_dropdown2.Clear();
            dt_dropdown3.Clear();
            dt_dropdown4.Clear();
            dt_dropdown5.Clear();


            contest();

            fill_listbox();
            listBox1.DataSource = dt_dropdown;
            listBox1.DisplayMember = "dropdown1";

            listBox1.ClearSelected();

            fill_listbox2();
            listBox2.DataSource = dt_dropdown2;
            listBox2.DisplayMember = "dropdown2";

            listBox2.ClearSelected();

            fill_listbox3();
            listBox3.DataSource = dt_dropdown3;
            listBox3.DisplayMember = "dropdown3";

            listBox3.ClearSelected();

            fill_listbox4();
            listBox4.DataSource = dt_dropdown4;
            listBox4.DisplayMember = "dropdown4";

            listBox4.ClearSelected();

            fill_listbox5();
            listBox5.DataSource = dt_dropdown5;
            listBox5.DisplayMember = "dropdown5";

            listBox5.ClearSelected();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String valtoremove;

            if (listBox1.SelectedIndex != -1)
            {

                valtoremove = listBox1.GetItemText(listBox1.SelectedItem);
                //textBox1.Text = listBox1.SelectedItem.ToString();


                cmd.Parameters.Clear();
                string qry = "  DELETE FROM dropdowns_tb WHERE dropdown1=@valremove";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd.Parameters.AddWithValue("@valremove", valtoremove);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                 
                    dt_dropdown.Clear();
                    fill_listbox();
                    listBox1.DataSource = dt_dropdown;
                    listBox1.DisplayMember = "dropdown1";
                    listBox1.ClearSelected();
                    //textBox1.Text = null;
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                }

            }
            if (listBox2.SelectedIndex != -1)
            {
                valtoremove = listBox2.GetItemText(listBox2.SelectedItem);
                cmd.Parameters.Clear();
                string qry = "  DELETE FROM dropdowns_tb WHERE dropdown2=@valremove";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd.Parameters.AddWithValue("@valremove", valtoremove);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    dt_dropdown2.Clear();
                    fill_listbox2();
                    listBox2.DataSource = dt_dropdown2;
                    listBox2.DisplayMember = "dropdown2";
                    listBox2.ClearSelected();
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                }
            }
            if (listBox3.SelectedIndex != -1)
            {
                valtoremove = listBox3.GetItemText(listBox3.SelectedItem);
                cmd.Parameters.Clear();
                string qry = "  DELETE FROM dropdowns_tb WHERE dropdown3=@valremove";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd.Parameters.AddWithValue("@valremove", valtoremove);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {

                    dt_dropdown3.Clear();
                    fill_listbox3();
                    listBox3.DataSource = dt_dropdown3;
                    listBox3.DisplayMember = "dropdown3";
                    listBox3.ClearSelected();
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                }
            }
            if (listBox4.SelectedIndex != -1)
            {
               valtoremove = listBox4.GetItemText(listBox4.SelectedItem);
                cmd.Parameters.Clear();
                string qry = "DELETE FROM dropdowns_tb WHERE dropdown4=@valremove";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd.Parameters.AddWithValue("@valremove", valtoremove);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    dt_dropdown4.Clear();

                    fill_listbox4();
                    listBox4.DataSource = dt_dropdown4;
                    listBox4.DisplayMember = "dropdown4";
                    listBox4.ClearSelected();
                }
                else
                {
                    MessageBox.Show("Failed to Save Dataa");
                }
            }
            if (listBox5.SelectedIndex != -1)
            {
                valtoremove = listBox5.GetItemText(listBox5.SelectedItem);
                cmd.Parameters.Clear();
                string qry = "  DELETE FROM dropdowns_tb WHERE dropdown5=@valremove";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                cmd.Parameters.AddWithValue("@valremove", valtoremove);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    dt_dropdown5.Clear();
                    fill_listbox5();
                    listBox5.DataSource = dt_dropdown5;
                    listBox5.DisplayMember = "dropdown5";
                    listBox5.ClearSelected();
                }
                else
                {
                    MessageBox.Show("Failed to Save Data");
                }
            }

           

            // listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
           
        }
        

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
      
            //listBox2.SelectedIndex = -1;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           //
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           //
        }

        public void ListBox1_Click(object sender, EventArgs e)
        {
            listBox5.ClearSelected();
            listBox4.ClearSelected();
            listBox3.ClearSelected();
            listBox2.ClearSelected();
        }
        public void ListBox2_Click(object sender, EventArgs e)
        {
            listBox5.ClearSelected();
            listBox4.ClearSelected();
            listBox3.ClearSelected();
            listBox1.ClearSelected();
        }
        public void ListBox3_Click(object sender, EventArgs e)
        {
            listBox5.ClearSelected();
            listBox4.ClearSelected();
            listBox1.ClearSelected();
            listBox2.ClearSelected();
        }
        public void ListBox4_Click(object sender, EventArgs e)
        {
            listBox5.ClearSelected();
            listBox1.ClearSelected();
            listBox3.ClearSelected();
            listBox2.ClearSelected();
        }
        public void ListBox5_Click(object sender, EventArgs e)
        {
            listBox2.ClearSelected();
            listBox4.ClearSelected();
            listBox3.ClearSelected();
            listBox1.ClearSelected();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dt_dropdown.Clear();
            dt_dropdown2.Clear();
            dt_dropdown3.Clear();
            dt_dropdown4.Clear();
            dt_dropdown5.Clear();

            Profit_Loss_Calculations.combox_dt.Clear();
            Profit_Loss_Calculations.combox_3_dt.Clear();
            contest();
            Profit_Loss_Calculations.fill_combox();
            //fill_combox2();
            Profit_Loss_Calculations.fill_combox3();
            //fill_combox4();
            //fill_combox5();
            plsc.comboBox1.DataSource = Profit_Loss_Calculations.combox_dt;
            plsc.comboBox1.DisplayMember = "dropdown1";
            plsc.comboBox1.Text = "Please Select...";

            //comboBox2.DataSource = combox_2_dt;
            //comboBox2.DisplayMember = "dropdown2";
            //comboBox2.Text = "Please Select...";



            plsc.comboBox3.DataSource = Profit_Loss_Calculations.combox_3_dt;
            plsc.comboBox3.DisplayMember = "dropdown3";
            plsc.comboBox3.Text = "Select Labor Type...";


            //Profit_Loss_Calculations pfss = new Profit_Loss_Calculations();
            //pfss.Show();
            this.Hide();
        }

        private void DropDown_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            dt_dropdown.Clear();
            dt_dropdown2.Clear();
            dt_dropdown3.Clear();
            dt_dropdown4.Clear();
            dt_dropdown5.Clear();
        }
    }
}

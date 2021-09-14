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
    public partial class Form8 : Form
    {
        Form1 frm1;
        public Form8(Form1 fm1)
        {
            InitializeComponent();
            frm1 = fm1;
            button3.Click += new EventHandler(button3_Click);
        }
        Form1 f1 = new Form1();
       public static SqlCommand cmd = new SqlCommand();
       public static SqlConnection db_conect = new SqlConnection();
       public static SqlDataAdapter adopt = new SqlDataAdapter();
       public static DataTable dt_drops = new DataTable();
        public static DataTable dt_drops_7 = new DataTable();
        //string con_str = "Data Source =DESKTOP-D8I8EQJ;Initial Catalog=rms_db;Integrated Security=True";
        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;

        public static void fill_listbox()
        {
            string qry = "select * From dropdowns_tb WHERE dropdown6 IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(dt_drops);

            string qrzy = "select * From dropdowns_tb WHERE dropdown7 IS NOT NULL";
            cmd.CommandText = qrzy;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(dt_drops_7);
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            contest();
            fill_listbox();
            listBox1.DataSource = dt_drops;
            listBox1.DisplayMember = "dropdown6";
            listBox1.ClearSelected();
            //string qry = "select * From rms_db.dbo.labor_data_tb";
            //cmd2.CommandText = qry;
            //cmd2.Connection = db_conect;
            //adopt = new SqlDataAdapter(cmd2);
            //adopt.Fill(dt_labor_data);
            listBox2.DataSource = dt_drops_7;
            listBox2.DisplayMember = "dropdown7";
            listBox2.ClearSelected();


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

        private void button3_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Back to Tool 1 ?", "Finalize", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dialogResult == DialogResult.Yes)
            //{
                dt_drops.Clear();
                Form1.dt_drop.Clear();
                Form1.dt_drop_7.Clear();
                Form1.contest();
                Form1.fill_listbox();
                frm1.comboBox1.DataSource = Form1.dt_drop;
                frm1.comboBox1.DisplayMember = "dropdown6";
                frm1.comboBox1.Text = "Please Select...";
                //Form1 f1 = new Form1();
                frm1.comboBox2.DataSource = Form1.dt_drop_7;
                frm1.comboBox2.DisplayMember = "dropdown7";
                frm1.comboBox2.Text = "Please Select...";
            //f1.Show();
            this.Hide();
            //}
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            dt_drops.Clear();
            //DialogResult dialogResult = MessageBox.Show("Do You want to Exit Application ?", "You are About to Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dialogResult == DialogResult.Yes)
            //{

            //    //System.Environment.Exit(1);

            //}
            //else if (dialogResult == DialogResult.No)
            //{
            //    //do something else
            //    e.Cancel = true;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text=="")
            {
                MessageBox.Show("Can Not Enter Empty Values","Alert",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if(textBox1.Text !="")
                {
                    cmd.Parameters.Clear();
                    string qrrys = "select * From dropdowns_tb WHERE dropdown6=@newtxt ";
                    cmd.CommandText = qrrys;
                    cmd.Connection = db_conect;
                    cmd.Parameters.AddWithValue("@newtxt", textBox1.Text);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    cmd.Dispose();
                    if (rdr.HasRows)
                    {
                        //when in read mode ask for data
                        while (rdr.Read())
                        {
                            string uname = rdr["dropdown6"].ToString();
                            string ntxt = textBox1.Text;
                            uname = uname.ToLower();
                            ntxt = ntxt.ToLower();

                            if (ntxt == uname)
                            {
                                textBox1.Text = null;
                                MessageBox.Show("Value Already Exist in Database", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                        }
                        rdr.Close();
                    }
                    else
                    {
                        rdr.Close();
                        cmd.Parameters.Clear();
                        string qry = "insert into dropdowns_tb (dropdown6) VALUES (@dp6) ";
                        cmd.CommandText = qry;
                        cmd.Connection = db_conect;
                        //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                        cmd.Parameters.AddWithValue("@dp6", textBox1.Text);


                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            textBox1.Text = null;
                            dt_drops.Clear();
                            dt_drops_7.Clear();
                            fill_listbox();
                            listBox1.DataSource = dt_drops;
                            listBox1.DisplayMember = "dropdown6";
                            listBox1.ClearSelected();

                            
                           
                            listBox2.DataSource = dt_drops_7;
                            listBox2.DisplayMember = "dropdown7";
                            listBox2.ClearSelected();

                        }
                        else
                        {
                            MessageBox.Show("Failed to Save Data");
                        }
                    }

                }
                if (textBox2.Text !="")
                {
                    cmd.Parameters.Clear();
                    string qrrys = "select * From dropdowns_tb WHERE dropdown7=@newtxt ";
                    cmd.CommandText = qrrys;
                    cmd.Connection = db_conect;
                    cmd.Parameters.AddWithValue("@newtxt", textBox2.Text);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    cmd.Dispose();
                    if (rdr.HasRows)
                    {
                        //when in read mode ask for data
                        while (rdr.Read())
                        {
                            string uname = rdr["dropdown7"].ToString();
                            string ntxt = textBox2.Text;
                            uname = uname.ToLower();
                            ntxt = ntxt.ToLower();

                            if (ntxt == uname)
                            {
                                textBox2.Text = null;
                                MessageBox.Show("Value Already Exist in Database", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                        }
                        rdr.Close();
                    }
                    else
                    {
                        rdr.Close();
                        cmd.Parameters.Clear();
                        string qry = "insert into dropdowns_tb (dropdown7) VALUES (@dp7) ";
                        cmd.CommandText = qry;
                        cmd.Connection = db_conect;
                        //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                        cmd.Parameters.AddWithValue("@dp7", textBox2.Text);


                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            textBox2.Text = null;
                            dt_drops_7.Clear();
                            dt_drops.Clear();
                            fill_listbox();
                            listBox2.DataSource = dt_drops_7;
                            listBox2.DisplayMember = "dropdown7";
                            listBox2.ClearSelected();

                            listBox1.DataSource = dt_drops;
                            listBox1.DisplayMember = "dropdown6";
                            listBox1.ClearSelected();

                        }
                        else
                        {
                            MessageBox.Show("Failed to Save Data");
                        }
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure You Want To Remove Item ?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                String valtoremove;

                if (listBox1.SelectedIndex != -1)
                {

                    valtoremove = listBox1.GetItemText(listBox1.SelectedItem);
                    //textBox1.Text = listBox1.SelectedItem.ToString();


                    cmd.Parameters.Clear();
                    string qry = "  DELETE FROM dropdowns_tb WHERE dropdown6=@valremove";
                    cmd.CommandText = qry;
                    cmd.Connection = db_conect;
                    //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                    cmd.Parameters.AddWithValue("@valremove", valtoremove);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {

                        dt_drops.Clear();
                        dt_drops_7.Clear();
                        fill_listbox();
                        listBox1.DataSource = dt_drops;
                        listBox1.DisplayMember = "dropdown6";
                        listBox1.ClearSelected();
                        //textBox1.Text = null;
                        listBox2.DataSource = dt_drops_7;
                        listBox2.DisplayMember = "dropdown7";
                        listBox2.ClearSelected();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Delete Data");
                    }

                }

                if (listBox2.SelectedIndex !=-1)
                {
                    valtoremove = listBox2.GetItemText(listBox2.SelectedItem);
                    //textBox1.Text = listBox1.SelectedItem.ToString();


                    cmd.Parameters.Clear();
                    string qry = "  DELETE FROM dropdowns_tb WHERE dropdown7=@valremove";
                    cmd.CommandText = qry;
                    cmd.Connection = db_conect;
                    //@anum_gross_rev,@anum_op_days,@daily_op_hrs,@avg_sale_recpt,@daily_gross_rev,@hourly_gross_rev,@hourly_sale_ord,@daily_sale_ord,@anum_sale_ord
                    cmd.Parameters.AddWithValue("@valremove", valtoremove);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {

                        dt_drops_7.Clear();
                        dt_drops.Clear();
                        fill_listbox();
                        listBox2.DataSource = dt_drops_7;
                        listBox2.DisplayMember = "dropdown7";
                        listBox2.ClearSelected();
                        //textBox1.Text = null;
                        listBox1.DataSource = dt_drops;
                        listBox1.DisplayMember = "dropdown6";
                        listBox1.ClearSelected();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Delete Data");
                    }
                }
            }
        }
    }
}

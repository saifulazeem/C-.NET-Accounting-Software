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
    public partial class Form3 : Form
    {
        Form1 fms1;
        public Form3(Form1 frms1)
        {
            InitializeComponent();
            fms1 = frms1;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        public static DataTable labor_data_tb = new DataTable();
        public static DataTable labor_data_tb_1 = new DataTable();
        public static SqlCommand cmd = new SqlCommand();
        public static SqlConnection db_conect = new SqlConnection();
        public static SqlDataAdapter adopt = new SqlDataAdapter();
        public static string file_id;

        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Load_Data"].Index && dataGridView1.Rows.Count>1 && e.RowIndex+1 != dataGridView1.Rows.Count)
            {
                //Do something with your button.
             
                //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                file_id = labor_data_tb.Rows[e.RowIndex]["files_name"].ToString();

                cmd.Parameters.Clear();
                string qry = "select * From labor_data_tb WHERE files_name=@tid";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                cmd.Parameters.AddWithValue("@tid", file_id);
                adopt = new SqlDataAdapter(cmd);
                adopt.Fill(labor_data_tb_1);

                //string name = row["name"].ToString();
                string id = labor_data_tb_1.Rows[0]["id"].ToString();
                string arev = labor_data_tb_1.Rows[0]["annual_gross_revenue"].ToString();
                fms1.comboBox2.Text = arev;
                string aop = labor_data_tb_1.Rows[0]["annual_operating_days"].ToString();
                fms1.textBox2.Text = aop;
                string dwh = labor_data_tb_1.Rows[0]["daily_operating_hrs"].ToString();
                fms1.textBox3.Text = dwh;
                string aophr = labor_data_tb_1.Rows[0]["annual_operating_hrs"].ToString();
                fms1.label17.Text = aophr;


                string naml = labor_data_tb_1.Rows[0]["am_no_labor"].ToString();
                fms1.textBox6.Text = naml;
                string  amdhw= labor_data_tb_1.Rows[0]["am_daily_hrs_worked"].ToString();
                fms1.textBox10.Text = amdhw;
                string amadw = labor_data_tb_1.Rows[0]["am_annual_days_worked"].ToString();
                fms1.textBox11.Text = amadw;
                string amhwg = labor_data_tb_1.Rows[0]["am_hourly_wages"].ToString();
                fms1.textBox16.Text = amhwg;

                string amawg = labor_data_tb_1.Rows[0]["am_annual_wages"].ToString();
                fms1.label11.Text = amawg;

                string ncrewl = labor_data_tb_1.Rows[0]["crew_no_labor"].ToString();
                fms1.textBox4.Text = ncrewl;
                string crewdhw = labor_data_tb_1.Rows[0]["crew_daily_hrs_worked"].ToString();
                fms1.textBox9.Text = crewdhw;
                string crewadw = labor_data_tb_1.Rows[0]["crew_annual_days_worked"].ToString();
                fms1.textBox12.Text = crewadw;
                string crewhwg = labor_data_tb_1.Rows[0]["crew_hourly_wages"].ToString();
                fms1.textBox15.Text = crewhwg;

                string crewawg = labor_data_tb_1.Rows[0]["crew_annual_wages"].ToString();
                fms1.label10.Text = crewawg;

                string ngml = labor_data_tb_1.Rows[0]["gm_no_labor"].ToString();
                fms1.textBox21.Text = ngml;
                string gmdhw = labor_data_tb_1.Rows[0]["gm_daily_hrs_worked"].ToString();
                fms1.textBox31.Text = gmdhw;
                string gmadw = labor_data_tb_1.Rows[0]["gm_annual_days_worked"].ToString();
                fms1.textBox7.Text = gmadw;
                string gmhwg = labor_data_tb_1.Rows[0]["gm_hourly_wages"].ToString();
                fms1.textBox14.Text = gmhwg;

                string gmawg = labor_data_tb_1.Rows[0]["gm_annual_wages"].ToString();
                fms1.label13.Text = gmawg;


                string t_rev = labor_data_tb_1.Rows[0]["total_annual_wages"].ToString();
                fms1.label9.Text = t_rev;

                labor_data_tb_1.Clear();
                labor_data_tb.Clear();

                Form1.validate = 0;
                fms1.reportViewer1.Clear();

                this.Hide();




            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            labor_data_tb.Clear();
            labor_data_tb_1.Clear();
            contest();
            fill_grid();
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.ColumnCount = 3;
            dataGridView1.DataSource = labor_data_tb;
            
            DataGridViewButtonColumn loadButtonColumn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(loadButtonColumn);
            loadButtonColumn.HeaderText = "Actions";
            loadButtonColumn.Name = "Load_Data";
            loadButtonColumn.Text = "Open";
            loadButtonColumn.UseColumnTextForButtonValue = true;

            //int columnIndex = 1;
            //if (dataGridView1.Columns["Load_Data"] == null)
            //{
            //    dataGridView1.Columns.Insert(columnIndex, loadButtonColumn);
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

        public static void fill_grid()
        {
            cmd.Parameters.Clear();
            string qry = "select files_name,saved_date From labor_data_tb WHERE files_name IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(labor_data_tb);


        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace labor_data
{
    public partial class Form5 : Form
    {
        Form2 fms2;
        public Form5(Form2 frms2)
        {
            InitializeComponent();
            fms2 = frms2;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        public static DataTable sales_vol_tb = new DataTable();
        public static DataTable sales_vol_tb_1 = new DataTable();
        public static SqlCommand cmd = new SqlCommand();
        public static SqlConnection db_conect = new SqlConnection();
        public static SqlDataAdapter adopt = new SqlDataAdapter();
        public static string file_id;

        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Load_Data"].Index && dataGridView1.Rows.Count > 1 && e.RowIndex + 1 != dataGridView1.Rows.Count)
            {
                //Do something with your button.

                //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                file_id = sales_vol_tb.Rows[e.RowIndex]["files_name"].ToString();

                cmd.Parameters.Clear();
                string qry = "select * From sales_volume_tb WHERE files_name=@tid";
                cmd.CommandText = qry;
                cmd.Connection = db_conect;
                cmd.Parameters.AddWithValue("@tid", file_id);
                adopt = new SqlDataAdapter(cmd);
                adopt.Fill(sales_vol_tb_1);

                //string name = row["name"].ToString();
                string id = sales_vol_tb_1.Rows[0]["t_id"].ToString();
                string arev = sales_vol_tb_1.Rows[0]["anum_gross_rev"].ToString();
                fms2.textBox1.Text = arev;
                string aop = sales_vol_tb_1.Rows[0]["anum_op_days"].ToString();
                fms2.textBox2.Text = aop;
                string dwh = sales_vol_tb_1.Rows[0]["daily_op_hrs"].ToString();
                fms2.textBox3.Text = dwh;
                string avgsr = sales_vol_tb_1.Rows[0]["avg_sale_recpt"].ToString();
                fms2.textBox4.Text = avgsr;


                string dgr = sales_vol_tb_1.Rows[0]["daily_gross_rev"].ToString();
                fms2.label14.Text = dgr;
                string hgr = sales_vol_tb_1.Rows[0]["hourly_gross_rev"].ToString();
                fms2.label13.Text = hgr;
                string hso = sales_vol_tb_1.Rows[0]["hourly_sale_ord"].ToString();
                fms2.label12.Text = hso;
                string dso = sales_vol_tb_1.Rows[0]["daily_sale_ord"].ToString();
                fms2.label11.Text = dso;

                string aso = sales_vol_tb_1.Rows[0]["anum_sale_ord"].ToString();
                fms2.label10.Text = aso;

                sales_vol_tb_1.Clear();
                sales_vol_tb.Clear();

                Form2.val = 0;
                fms2.reportViewer1.Clear();

                this.Hide();




            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            sales_vol_tb.Clear();
            sales_vol_tb_1.Clear();
            contest();
            fill_grid();
            dataGridView1.DataSource = sales_vol_tb;

            DataGridViewButtonColumn loadButtonColumn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(loadButtonColumn);
            loadButtonColumn.HeaderText = "Actions";
            loadButtonColumn.Name = "Load_Data";
            loadButtonColumn.Text = "Open";
            loadButtonColumn.UseColumnTextForButtonValue = true;
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
            string qry = "select files_name,saved_date From sales_volume_tb WHERE files_name IS NOT NULL";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(sales_vol_tb);


        }
    }
}

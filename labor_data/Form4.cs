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
using System.Globalization;

namespace labor_data
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public static DataTable labor_data_tbs = new DataTable();
        public static DataTable labor_data_tbss = new DataTable();

        public static SqlCommand cmd = new SqlCommand();
        public static SqlConnection db_conect = new SqlConnection();
        public static SqlDataAdapter adopt = new SqlDataAdapter();

        public static string con_str => ConfigurationManager.ConnectionStrings["con_str"].ConnectionString;

        public static string file_id, chkfile_name;

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

        public static void update_grid()
        {
            cmd.Parameters.Clear();
            string qry = "select Top(1) id From labor_data_tb ORDER BY id DESC";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(labor_data_tbs);


        }

        private void Form4_Load(object sender, EventArgs e)
        {
            labor_data_tbs.Clear();
            contest();
            update_grid();
            file_id = labor_data_tbs.Rows[0]["id"].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text =="")
            {
                MessageBox.Show("Can't Save file with Blank Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                cmd.Parameters.Clear();
                string qrdy = "select * From labor_data_tb WHERE files_name=@fn ";
                cmd.CommandText = qrdy;
                cmd.Connection = db_conect;
                cmd.Parameters.AddWithValue("@fn",textBox1.Text);
                adopt = new SqlDataAdapter(cmd);
                adopt.Fill(labor_data_tbss);

                if (labor_data_tbss.Rows.Count > 0)
                {
                    chkfile_name = labor_data_tbss.Rows[0]["files_name"].ToString();
                    if (chkfile_name == textBox1.Text)
                    {
                        MessageBox.Show("File Name Already Exist!! Use Unique Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        labor_data_tbs.Clear();
                        labor_data_tbss.Clear();
                        update_grid();
                        file_id = labor_data_tbs.Rows[0]["id"].ToString();

                    }

                }
                else
                {
                    cmd.Parameters.Clear();
                    DateTime now = DateTime.Now;
                    CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                    string cdate = now.ToString();
                    string qry = "UPDATE labor_data_tb SET files_name =@filename,saved_date=@cdates WHERE id=@ids ";
                    cmd.CommandText = qry;
                    cmd.Connection = db_conect;
                    cmd.Parameters.AddWithValue("@ids", file_id);
                    cmd.Parameters.AddWithValue("@filename", textBox1.Text);
                    cmd.Parameters.AddWithValue("@cdates", cdate);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {

                        MessageBox.Show(textBox1.Text + " File Saved Sucessfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        labor_data_tbs.Clear();
                        labor_data_tbss.Clear();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save Data");
                    }
                }

            }
        }
    }
}

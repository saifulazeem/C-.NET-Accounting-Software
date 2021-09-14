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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }


        public static DataTable sale_vol_tbs = new DataTable();
        public static DataTable sale_vol_tbss = new DataTable();

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

        private void Form6_Load(object sender, EventArgs e)
        {
            sale_vol_tbs.Clear();
            contest();
            update_grid();
            file_id = sale_vol_tbs.Rows[0]["t_id"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Can't Save file with Blank Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cmd.Parameters.Clear();
                string qrdy = "select * From sales_volume_tb WHERE files_name=@fn ";
                cmd.CommandText = qrdy;
                cmd.Connection = db_conect;
                cmd.Parameters.AddWithValue("@fn", textBox1.Text);
                adopt = new SqlDataAdapter(cmd);
                adopt.Fill(sale_vol_tbss);

               if (sale_vol_tbss.Rows.Count > 0)
                {
                    chkfile_name = sale_vol_tbss.Rows[0]["files_name"].ToString();
                    if (chkfile_name == textBox1.Text)
                    {
                        MessageBox.Show("File Name Already Exist!! Use Unique Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        sale_vol_tbs.Clear();
                        sale_vol_tbss.Clear();
                        update_grid();
                        file_id = sale_vol_tbs.Rows[0]["t_id"].ToString();

                    }
                }
               else
                {
                    cmd.Parameters.Clear();
                    DateTime now = DateTime.Now;
                    CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                    string cdate = now.ToString();
                    string qry = "UPDATE sales_volume_tb SET files_name =@filename,saved_date=@cdates WHERE t_id=@ids ";
                    cmd.CommandText = qry;
                    cmd.Connection = db_conect;
                    cmd.Parameters.AddWithValue("@ids", file_id);
                    cmd.Parameters.AddWithValue("@filename", textBox1.Text);
                    cmd.Parameters.AddWithValue("@cdates", cdate);
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {

                        MessageBox.Show(textBox1.Text + " File Saved Sucessfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sale_vol_tbs.Clear();
                        sale_vol_tbss.Clear();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save Data");
                    }
                }
            }
        }

        public static void update_grid()
        {
            cmd.Parameters.Clear();
            string qry = "select Top(1) t_id From sales_volume_tb ORDER BY t_id DESC";
            cmd.CommandText = qry;
            cmd.Connection = db_conect;
            adopt = new SqlDataAdapter(cmd);
            adopt.Fill(sale_vol_tbs);


        }
    }
}

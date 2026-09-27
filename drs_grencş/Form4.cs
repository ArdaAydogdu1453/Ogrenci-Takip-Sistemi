using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drs_grencş
{
    public partial class Form4: Form
    {
        SqlDataAdapter da;
        SqlConnection con;
        DataSet ds;
        DataTable dt;
        SqlCommand cmd = new SqlCommand();
        public Form4()
        {
            InitializeComponent();
        }
        public void grid()
        {
            string sorgu = "select o.ogr_no,o.ogr_ad,o.ogr_soyad,o.ogr_sinif,d.ders_id,d.ders_adi from ogrenciler as o, dersler as d,ogrenci_ders as od where o.ogr_no=od.ogr_no and d.ders_id=od.ders_id;";
            con.Open();
            da = new SqlDataAdapter(sorgu, con);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=VCLOUD-LAB2;Initial Catalog=ardaDB;Integrated Security=True");
            con.Open();
            da = new SqlDataAdapter("select * from ogrenciler", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "ogr_ad";
            comboBox1.ValueMember = "ogr_no";
            con.Close();
            grid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ogrno = Convert.ToInt32(comboBox1.SelectedValue);
            int ogrid = Convert.ToInt32(comboBox2.SelectedValue);
            con.Open();
            SqlCommand cmd = new SqlCommand( "INSERT INTO ogrenci_ders(ogr_no,ders_id) VALUES (@ogr , @ders)", con);
            cmd.Parameters.AddWithValue("@ogr", ogrno);
            cmd.Parameters.AddWithValue("@ders", ogrid);
            cmd.ExecuteNonQuery();
            con.Close();
            grid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from dersler where sinif_seviyesi = (select ogr_sinif from ogrenciler where ogr_ad='" + comboBox1.Text + "')", con);
            dt = new DataTable();
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "ders_adi";
            comboBox2.ValueMember = "ders_id";
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            if (comboBox3.SelectedIndex == 0)
            {
                dv.RowFilter = "ogr_ad LIKE '%" + textBox1.Text + "%'";
            }
            if (comboBox3.SelectedIndex == 1)
            {
                dv.RowFilter = "ogr_sinif LIKE '%" + textBox1.Text + "%'";
            }
            if (comboBox3.SelectedIndex == 2)
            {
                dv.RowFilter = "ogr_no LIKE '%" + textBox1.Text + "%'";
            }
            if (comboBox3.SelectedIndex == 3)
            {
                dv.RowFilter = "ogr_soyad LIKE '%" + textBox1.Text + "%'";
            }
            dataGridView1.DataSource = dv;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowStateFilter = DataViewRowState.Deleted;
            dataGridView2.DataSource = dv;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dataGridView2.SelectedRows)
            {
                int i = 0;
                foreach (DataRow dc in dt.Rows)
                {
                    if (dc.RowState == DataRowState.Deleted)
                    {
                        if (dgvr.Index == i)
                        {
                            dc.RejectChanges();
                        }
                        i++;
                    }
                }
            }
        }
    }
}

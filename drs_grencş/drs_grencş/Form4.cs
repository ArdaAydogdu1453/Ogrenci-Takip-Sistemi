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
            grid();
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace drs_grencş
{
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        SqlConnection con;
        DataSet ds;
        SqlCommand cmd = new SqlCommand();
        public void Goster()
        {
            ds = new DataSet();
            da.Fill(ds, "ogrenciler");
            dataGridView1.DataSource = ds.Tables["ogrenciler"];
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=VCLOUD-LAB2;Initial Catalog=ardaDB;Integrated Security=True");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = con;

            string kayıt = "INSERT INTO ogrenciler(ogr_no,ogr_ad,ogr_soyad,ogr_sinif) VALUES (@ogrenci_no,@ogrenci_ad,@ogrenci_soyad,@ogrenci_sinif)";

            cmd.Parameters.AddWithValue("@ogrenci_no", textBox1.Text);
            cmd.Parameters.AddWithValue("@ogrenci_ad", textBox2.Text);
            cmd.Parameters.AddWithValue("@ogrenci_soyad", textBox3.Text);
            cmd.Parameters.AddWithValue("@ogrenci_sinif", textBox4.Text);

            cmd.CommandText = kayıt;
            da = new SqlDataAdapter("SELECT * FROM ogrenciler", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Goster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open(); 
            cmd = new SqlCommand();
            cmd.Connection = con;
            string sil = "delete from ogrenciler where ogr_no= @ogrenci_no";
            cmd.Parameters.AddWithValue("@ogrenci_no", textBox1.Text);
            da = new SqlDataAdapter("SELECT * FROM ogrenciler", con);
            cmd.CommandText = sil;
            cmd.ExecuteNonQuery();
            con.Close();
            Goster();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}

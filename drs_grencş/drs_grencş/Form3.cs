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
    public partial class Form3: Form
    {
        public Form3()
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
            da.Fill(ds, "dersler");
            dataGridView1.DataSource = ds.Tables["dersler"];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = con;

            string kayıt = "INSERT INTO dersler(ders_id,ders_adi,sinif_seviesi) VALUES (@ders_id,@ders_adi,@sinif_seviyesi)";

            cmd.Parameters.AddWithValue("@ders_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@ders_adi", textBox2.Text);
            cmd.Parameters.AddWithValue("@sinif_seviyesi", textBox3.Text);

            cmd.CommandText = kayıt;
            da = new SqlDataAdapter("SELECT * FROM dersler", con);
            con.Open();
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            string sil = "delete from dersler where ders_id= @ders_id";
            cmd.Parameters.AddWithValue("@ders_id", textBox1.Text);
            da = new SqlDataAdapter("SELECT * FROM dersler", con);
            cmd.CommandText = sil;
            cmd.ExecuteNonQuery();
            con.Close();
            Goster();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=VCLOUD-LAB2;Initial Catalog=ardaDB;Integrated Security=True");
        }
    }
}

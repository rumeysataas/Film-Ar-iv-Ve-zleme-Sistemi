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

namespace Film_Arşiv_Ve_İzleme_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Data Source = RUMEYSA - W10\SQLEXPRESS;Initial Catalog = FilmArşivim; Integrated Security = True
        SqlConnection baglantı = new SqlConnection(@"Data Source=RUMEYSA-W10\SQLEXPRESS;Initial Catalog=FilmArşivim;Integrated Security=True");
        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TblFilmler",baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFİLMLER(AD,KATEGORİ,LİNK) values (@ad,@kategori,@link)", baglantı);
            komut.Parameters.AddWithValue("@ad", TxtFilmAd.Text);
            komut.Parameters.AddWithValue("@kategori", TxtKategori.Text);
            komut.Parameters.AddWithValue("@link", TxtLink.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Film Kayıt İşlemi Gerçekleşti.");
            filmler();
        }
        static public int secilen;
        static public string link;
       public void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
          secilen = dataGridView1.SelectedCells[0].RowIndex;
          link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
         webBrowser1.Navigate(link);
        }
       

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void BtnTamEkran_Click(object sender, EventArgs e)
        {
            tam_ekran tamekran = new tam_ekran();
          //  this.WindowState = FormWindowState.Maximized;

           secilen = dataGridView1.SelectedCells[0].RowIndex;
            tamekran.webbrowser = dataGridView1.Rows[secilen].Cells[3].Value.ToString(); 
            tamekran.Show();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}

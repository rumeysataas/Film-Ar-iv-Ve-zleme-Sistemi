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
    public partial class tam_ekran : Form
    {
        public tam_ekran()
        {
            InitializeComponent();
        }
        public string webbrowser;
        SqlConnection baglantı = new SqlConnection(@"Data Source=RUMEYSA-W10\SQLEXPRESS;Initial Catalog=FilmArşivim;Integrated Security=True");

        private void tam_ekran_Load(object sender, EventArgs e)
        {
            this.Text = webbrowser.ToString();
            this.WindowState = FormWindowState.Maximized;
            web.Navigate(this.Text);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }
    }
}

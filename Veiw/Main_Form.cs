using System;
using Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veiw
{
    public partial class MainForm : Form
    {
        private string way = $@"C:\Users\{Environment.UserName}\AppData\Local\ToDoApp";
        private Database db;
        private 


        public MainForm()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(way))
            {
                new Firststart();
                MessageBox.Show("Откройте программу ещё раз", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
                db = new Database();

            string a = "";

            var b = db.Category();
            var d = db.Complete_Category();

            for (int i = 0; i < b.Count; i++)
            {
                a += $"{b[i]}, {d[i]}{"\n"}";
            }
            MessageBox.Show(a);

        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.CloseDB();
        }

        private void debug_Click(object sender, EventArgs e)
        {
            
        }
    }
}
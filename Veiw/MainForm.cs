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

namespace View
{
    public partial class MainForm : Form
    {
        private string way = $@"C:\Users\{Environment.UserName}\AppData\Local\ToDoApp";
        private Database db;
        private List<string> categories = new List<string>();
        private List<bool> categories_complete = new List<bool>();

        private List<string> note_name = new List<string>();
        private List<bool> note_complete = new List<bool>();

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
            {
                db = new Database();

                categories = db.Category();
                categories_complete = db.Complete_Category();

                for (int i = 0; i < categories.Count; i++)
                {
                    Category_List.Items.Add(categories[i]);
                }
            }
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.CloseDB();
        }

        private void debug_Click(object sender, EventArgs e)
        {
            
        }

        private void Category_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            note_name.Clear();
            note_complete.Clear();
            panel_note.Controls.Clear();

            note_name = db.Note_Name(Category_List.SelectedIndex+1);
            note_complete = db.Note_Complete(Category_List.SelectedIndex+1);

            int y = 5;
            List<CheckBox> checkBoxes = new List<CheckBox>();
            for (int i = 0; i < note_name.Count; i++)
            {
                checkBoxes.Add(new CheckBox());
                checkBoxes[i].Checked = note_complete[i];
                checkBoxes[i].Text = note_name[i].ToString();
                checkBoxes[i].AutoSize = true;
                checkBoxes[i].Location = new Point(10, y);
                panel_note.Controls.Add(checkBoxes[i]);
                y += 25;
            }
        }
    }
}
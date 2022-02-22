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
        private List<Note> Note = new List<Note>();
        private List<Category> Category = new List<Category>();

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

                Note = db.NoteFromDB();
                Category = db.CategoryFromDB();

                for (int i = 0; i < Category.Count; i++)
                {
                    Category_List.Items.Add(Category[i].Name);
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
            
            panel_note.Controls.Clear();

            int y = 5;
            List<CheckBox> checkBoxes = new List<CheckBox>();
            for (int i = 0; i < Note.Count; i++)
            {
                checkBoxes.Add(new CheckBox());
                checkBoxes[i].Checked = Note[i].Complete;
                checkBoxes[i].Text = Note[i].Name;
                checkBoxes[i].AutoSize = true;
                checkBoxes[i].Location = new Point(10, y);
                panel_note.Controls.Add(checkBoxes[i]);
                y += 25;
            }
        }
    }
}
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

        private List<CheckBox> checkBoxes = new List<CheckBox>();

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

        private void Category_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (checkBoxes.Count!=0)
            {
                for (int i = 0; i < checkBoxes.Count; i++)
                {
                    Note[i].Complete = checkBoxes[i].Checked;
                }
            }

            panel_note.Controls.Clear();
            
            int y = 5;
            int add = 25;

            for (int i = 0; i < Note.Count; i++)
            {
                if (Note[i].Id_Category == Category_List.SelectedIndex + 1)
                {
                    checkBoxes.Add(new CheckBox());
                    checkBoxes[i].Checked = Note[i].Complete;
                    checkBoxes[i].Text = Note[i].Name;
                    checkBoxes[i].AutoSize = true;
                    checkBoxes[i].Location = new Point(10, y);
                    checkBoxes[i].Name = $"checkBox{checkBoxes.Count}";
                    panel_note.Controls.Add(checkBoxes[i]);
                    y += add;
                }
            }
        }
    }
}
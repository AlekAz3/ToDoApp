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
            
            panel_note.Controls.Clear();
            
            int y = 5;
            int add = 25;

            for (int i = 0; i < Note.Count; i++)
            {
                if (Note[i].Id_Category == Category_List.SelectedIndex + 1)
                {
                    checkBoxes.Add(new MyCheckBox(Note[i].Name, Note[i].Complete, y));
                    panel_note.Controls.Add(checkBoxes[i]);
                    y += add;
                }
            }
        }

        private void Category_List_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < panel_note.Controls.Count; i++)
            {
                Note[i].Complete = checkBoxes[i].Checked;   
                db.SaveStateCheckBoxToDB(Note[i]);
            }
        }

        private void debug_Click(object sender, EventArgs e)
        {
            string a = "";
            for (int i = 0; i < Note.Count; i++)
            {
                a += $"{Note[i].Name} {Note[i].Complete} {"\n"}";
            }
            MessageBox.Show(a, "");
        }
    }
}

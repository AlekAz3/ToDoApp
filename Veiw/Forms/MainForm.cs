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
        private int CurrentCategory;

        private List<CheckBox> checkBoxes = new List<CheckBox>();

        private int indent;
        private readonly int step = 25;

        Label AddLabel;
        Button AddButton;
        TextBox TextBox;

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
                    Category_List.Items.Add(Category[i].Name);
                
            }
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Category_List_MouseClick(Category_List, null);
            db.CloseDB();
        }

        private void Category_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_note.Controls.Clear();
            CurrentCategory = Category_List.SelectedIndex;
            indent = 5;

            for (int i = 0; i < Note.Count; i++)
            {
                if (Note[i].Id_Category == CurrentCategory + 1)
                {
                    checkBoxes.Add(new MyCheckBox(Note[i].Name, Note[i].Complete, indent));
                    panel_note.Controls.Add(checkBoxes[i]);
                    indent += step;
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
            //string a = "";
            //for (int i = 0; i < Note.Count; i++)
            //{
            //    a += $"{Note[i].Name} {Note[i].Complete} {"\n"}";
            //}
            //MessageBox.Show(a, " ");
        }

        private void add_category_Click(object sender, EventArgs e)
        {
            AddLabel = new Label();
            
            this.AddLabel.AutoSize = true;
            this.AddLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.AddLabel.Location = new Point(11, 194);
            this.AddLabel.Name = "AddLabel";
            this.AddLabel.Size = new Size(165, 20);
            this.AddLabel.TabIndex = 5;
            this.AddLabel.Text = "Название категории";
            this.Controls.Add(this.AddLabel);


            TextBox = new TextBox();
            this.TextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.TextBox.Location = new Point(15, 217);
            this.TextBox.Name = "AddTB";
            this.TextBox.Size = new Size(171, 26);
            this.TextBox.TabIndex = 6;
            this.Controls.Add(this.TextBox);


            AddButton = new Button();
            this.AddButton.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.AddButton.Location = new Point(15, 249);
            this.AddButton.Name = "Add_btn";
            this.AddButton.Size = new Size(171, 30);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new EventHandler(this.WriteNewCategoryClick);
            this.Controls.Add(this.AddButton);

        }

        private void WriteNewCategoryClick(object sender, EventArgs e)
        {
            string category = this.TextBox.Text;
            Category.Add(new Category(Category.Count - 1, category));
            db.AddCategotyToDB(new Category(Category.Count - 1, category));
            Category_List.Items.Add(Category[Category.Count - 1].Name);

            AddButton.Dispose();
            TextBox.Dispose();
            AddLabel.Dispose();
        }
    }
}
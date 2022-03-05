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

        private Label AddLabel;
        private Button AddButton;
        private TextBox AddTextBox;

        private Label AddLabelNote;
        private Button AddButtonNote;
        private Button DestroyButtonNote;
        private TextBox AddTextBoxNote;

        private bool Add_Flag = false;

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
            if (db != null)
            {
                Category_List_MouseClick(Category_List, null);
                db.CloseDB();
            }
        }

        private void Category_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_note.Controls.Clear();
            CurrentCategory = Category_List.SelectedIndex;
            checkBoxes.Clear();
            indent = 5;
            for (int i = 0; i < Note.Count; i++)
            {
                if (Note[i].Id_Category == CurrentCategory + 1)
                {   
                    checkBoxes.Add(new MyCheckBox(Note[i].Name, Note[i].Complete, indent));
                    panel_note.Controls.Add(checkBoxes[checkBoxes.Count-1]);
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

        private void add_category_Click(object sender, EventArgs e)
        {
            if (!Add_Flag)
            {
                AddLabel = new Label();
                this.AddLabel.AutoSize = true;
                this.AddLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                this.AddLabel.Location = new Point(11, 194);
                this.AddLabel.Size = new Size(165, 20);
                this.AddLabel.Text = "Название категории";
                this.Controls.Add(this.AddLabel);

                AddTextBox = new TextBox();
                this.AddTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                this.AddTextBox.Location = new Point(15, 217);
                this.AddTextBox.Size = new Size(171, 26);
                this.Controls.Add(this.AddTextBox);

                AddButton = new Button();
                this.AddButton.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                this.AddButton.Location = new Point(15, 249);
                this.AddButton.Size = new Size(171, 30);
                this.AddButton.Text = "Добавить";
                this.AddButton.UseVisualStyleBackColor = true;
                this.AddButton.Click += new EventHandler(this.WriteNewCategoryClick);
                this.Controls.Add(this.AddButton);
                Add_Flag = true;
            }
            else
            {
                if (AddLabel != null)
                {
                    AddLabel.Dispose();
                    AddTextBox.Dispose();
                    this.AddButton.Dispose();
                    Add_Flag = false;
                }
            }
        }

        private void WriteNewCategoryClick(object sender, EventArgs e)
        {
            string category = this.AddTextBox.Text;
            if (category == "" || category == " ")
                MessageBox.Show("Поле не должно быть пустым","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {
                Category.Add(new Category(Category.Count - 1, category));
                db.AddCategotyToDB(new Category(Category.Count - 1, category));
                Category_List.Items.Add(Category[Category.Count - 1].Name);

                MessageBox.Show("Категория создана", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Category_List.SelectedIndex = Category_List.Items.Count - 1;

                AddButton.Dispose();
                AddTextBox.Dispose();
                AddLabel.Dispose();
                Add_Flag = false;
            }
        }

        private void add_note_Click(object sender, EventArgs e)
        {
            if (!Add_Flag)
            {
                AddLabelNote = new Label();

                this.AddLabelNote.AutoSize = true;
                this.AddLabelNote.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                this.AddLabelNote.Location = new Point(15, 194);
                this.AddLabelNote.Size = new Size(138, 20);
                this.AddLabelNote.Text = "Название пункта";

                AddTextBoxNote = new TextBox();
                this.AddTextBoxNote.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                this.AddTextBoxNote.Location = new Point(19, 218);
                this.AddTextBoxNote.Size = new Size(167, 26);

                AddButtonNote = new Button();
                this.AddButtonNote.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                this.AddButtonNote.Location = new Point(15, 250);
                this.AddButtonNote.Size = new Size(85, 30);
                this.AddButtonNote.Text = "Добавить";
                this.AddButtonNote.UseVisualStyleBackColor = true;
                this.AddButtonNote.Click += new EventHandler(this.AddNoteButton_Click);

                DestroyButtonNote = new Button();
                this.DestroyButtonNote.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                this.DestroyButtonNote.Location = new Point(106, 250);
                this.DestroyButtonNote.Size = new Size(80, 30);
                this.DestroyButtonNote.Text = "Готово";
                this.DestroyButtonNote.UseVisualStyleBackColor = true;
                this.DestroyButtonNote.Click += new EventHandler(this.DestroyButton_Click);

                this.Controls.Add(AddLabelNote);
                this.Controls.Add(AddTextBoxNote);
                this.Controls.Add(AddButtonNote);
                this.Controls.Add(DestroyButtonNote);
                Add_Flag = true;
            }
            else
            {
                if (AddLabelNote !=null)
                {
                     AddLabelNote.Dispose();
                     AddButtonNote.Dispose();
                     DestroyButtonNote.Dispose();
                     AddTextBoxNote.Dispose();
                     Add_Flag = false;
                }
            }
        }

        private void DestroyButton_Click(object sender, EventArgs e)
        {
            AddLabelNote.Dispose();
            AddTextBoxNote.Dispose();
            AddButtonNote.Dispose();
            DestroyButtonNote.Dispose();
            Add_Flag = false;
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            if (Category_List.SelectedIndex == -1)
                MessageBox.Show($"Пошел нахуй реально заебал{"\n"}(Не выбрана категория)");

            else
            {
                if (AddTextBoxNote.Text == "" || AddTextBoxNote.Text == " ")
                    MessageBox.Show($"Это поле не может быть пустым");
                else
                {
                    Note.Add(new Note(Note.Count, AddTextBoxNote.Text, CurrentCategory+1, false));
                    db.AddNoteToDB(Note[Note.Count - 1]);
                    AddTextBoxNote.Text = "";
                }
            }
        }

        private void DellAllDate_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены", "Инфо",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                db.CloseDB();
                File.Delete($@"{way}\todoapp.db");
                Directory.Delete(way);
                Application.Exit();
            }
        }

        private void Debug_click(object sender, EventArgs e)
        {
            //if (AddLabel != null)
            //    AddLabel.Dispose();

            //if (AddButton != null)
            //    AddButton.Dispose();

            //if (AddTextBox != null)
            //    AddTextBox.Dispose();

            //if (AddLabelNote != null)
            //    AddLabelNote.Dispose();

            //if (AddButtonNote != null)
            //    AddButtonNote.Dispose();

            //if (AddTextBoxNote != null)
            //    AddTextBoxNote.Dispose();

            //if (DestroyButtonNote != null)
            //    DestroyButtonNote.Dispose();
            MessageBox.Show("Закрой прогу и открой обратно");
        }

        private void ArchiveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Не готово");
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Не готово");
        }
    }
}
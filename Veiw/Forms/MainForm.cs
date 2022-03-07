using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Veiw.Forms
{
    public partial class MainForm : Form
    {
        private string way = $@"C:\Users\{Environment.UserName}\AppData\Local\ToDoApp";

        private Database db;
        private List<Note> Note = new List<Note>();
        private List<Category> Category = new List<Category>();

        private int CurrentCategory;
        private string curCategory;
        private List<CheckBox> checkBoxes = new List<CheckBox>();

        private int indent = 5;
        private readonly int step = 25;

        private Label AddLabel;
        private Button AddButton;
        private TextBox AddTextBox;

        private Label AddLabelNote;
        private Button AddButtonNote;
        private Button DestroyButtonNote;
        private TextBox AddTextBoxNote;

        private bool Add_Flag = false;

        public MainForm() => InitializeComponent();

        private void Main_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(way))
            {
                Firststart firststart = new Firststart();
                MessageBox.Show("Откройте программу ещё раз", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Application.Exit();
            }
            else
            {
                db = new Database();
                ReLoadCategoryList();
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
            curCategory = Category_List.SelectedItem.ToString();
            checkBoxes.Clear();
            indent = 5;

            for (int i = 0; i < Note.Count; i++)
            {
                if (Note[i].Name_Category == curCategory)
                {
                    checkBoxes.Add(new MyCheckBox(Note[i].Name, Note[i].Complete, indent));
                    panel_note.Controls.Add(checkBoxes[checkBoxes.Count - 1]);
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
                AddLabel.AutoSize = true;
                AddLabel.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
                AddLabel.Location = new Point(11, 194);
                AddLabel.Size = new Size(165, 20);
                AddLabel.Text = "Название категории";
                Controls.Add(AddLabel);
                AddTextBox = new TextBox();
                AddTextBox.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
                AddTextBox.Location = new Point(15, 217);
                AddTextBox.Size = new Size(171, 26);
                Controls.Add(AddTextBox);
                AddButton = new Button();
                AddButton.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
                AddButton.Location = new Point(15, 249);
                AddButton.Size = new Size(171, 30);
                AddButton.Text = "Добавить";
                AddButton.UseVisualStyleBackColor = true;
                AddButton.Click += new EventHandler(WriteNewCategoryClick);
                Controls.Add(AddButton);
                Add_Flag = true;
            }
            else if (AddLabel != null)
            {
                AddLabel.Dispose();
                AddTextBox.Dispose();
                AddButton.Dispose();
                Add_Flag = false;
            }
        }

        private void WriteNewCategoryClick(object sender, EventArgs e)
        {
            string text = AddTextBox.Text;
            if (text == "" || text == " ")
            {
                MessageBox.Show("Поле не должно быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (db.CheckCategoryName(text))
            {
                Category.Add(new Category(Category.Count - 1, text));
                db.AddCategotyToDB(new Category(Category.Count - 1, text));
                Category_List.Items.Add(Category[Category.Count - 1].Name);
                MessageBox.Show("Категория создана", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                Category_List.SelectedIndex = Category_List.Items.Count - 1;
                AddButton.Dispose();
                AddTextBox.Dispose();
                AddLabel.Dispose();
                Add_Flag = false;
            }
            else
            {
                MessageBox.Show("Названия катерогий не должна повторятся", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void add_note_Click(object sender, EventArgs e)
        {
            if (!Add_Flag)
            {
                AddLabelNote = new Label();
                AddLabelNote.AutoSize = true;
                AddLabelNote.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
                AddLabelNote.Location = new Point(15, 194);
                AddLabelNote.Size = new Size(138, 20);
                AddLabelNote.Text = "Название пункта";

                AddTextBoxNote = new TextBox();
                AddTextBoxNote.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 204);
                AddTextBoxNote.Location = new Point(19, 218);
                AddTextBoxNote.Size = new Size(167, 26);

                AddButtonNote = new Button();
                AddButtonNote.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
                AddButtonNote.Location = new Point(15, 250);
                AddButtonNote.Size = new Size(85, 30);
                AddButtonNote.Text = "Добавить";
                AddButtonNote.UseVisualStyleBackColor = true;
                AddButtonNote.Click += new EventHandler(AddNoteButton_Click);

                DestroyButtonNote = new Button();
                DestroyButtonNote.Font = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
                DestroyButtonNote.Location = new Point(106, 250);
                DestroyButtonNote.Size = new Size(80, 30);
                DestroyButtonNote.Text = "Готово";
                DestroyButtonNote.UseVisualStyleBackColor = true;
                DestroyButtonNote.Click += new EventHandler(DestroyButton_Click);

                Controls.Add(AddLabelNote);
                Controls.Add(AddTextBoxNote);
                Controls.Add(AddButtonNote);
                Controls.Add(DestroyButtonNote);
                Add_Flag = true;
            }
            else if (AddLabelNote != null)
            {
                AddLabelNote.Dispose();
                AddButtonNote.Dispose();
                DestroyButtonNote.Dispose();
                AddTextBoxNote.Dispose();
                Add_Flag = false;
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
            {
                MessageBox.Show("Пошел нахуй реально заебал\n(Не выбрана категория)");
            }
            else if (AddTextBoxNote.Text == "" || AddTextBoxNote.Text == " ")
            {
                MessageBox.Show("Это поле не может быть пустым");
            }
            else
            {
                Note.Add(new Note(Note.Count, AddTextBoxNote.Text, curCategory, db.GetIDCategoryFromName(curCategory), false));
                db.AddNoteToDB(Note[Note.Count - 1]);
                AddTextBoxNote.Text = "";
                checkBoxes.Add(new MyCheckBox(Note[Note.Count - 1].Name, Note[Note.Count - 1].Complete, indent));
                panel_note.Controls.Add(checkBoxes[checkBoxes.Count - 1]);
                indent += step;
            }
        }

        private void DellAllDate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены", "Инфо", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            db.CloseDB();
            File.Delete(way + "\\todoapp.db");
            Directory.Delete(way);
            Application.Exit();
        }

        private void Debug_click(object sender, EventArgs e)
        {
            MessageBox.Show("Закрой прогу и открой обратно");
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Не готово");
        }

        private void DellCurrentCategory(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, это нельзя обратить", "Точно?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            db.DellCategory(curCategory);
            ReLoadCategoryList();
        }

        private void CategoryToArchive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, это нельзя будет обратить", "Точно?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            db.ArchiveCategory(curCategory);
            ReLoadCategoryList();
        }

        private void ReLoadCategoryList()
        {
            Category_List.Items.Clear();
            Note.Clear();
            Category.Clear();

            Note = db.NoteFromDB();
            Category = db.CategoryFromDB();

            for (int index = 0; index < Category.Count; ++index)
                Category_List.Items.Add(Category[index].Name);

            Category_List.SelectedIndex = 0;
        }
    }
}

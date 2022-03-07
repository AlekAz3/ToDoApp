using System.Drawing;

namespace Veiw.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Category_List = new System.Windows.Forms.ComboBox();
            this.add_note = new System.Windows.Forms.Button();
            this.add_category = new System.Windows.Forms.Button();
            this.edit_btn = new System.Windows.Forms.Button();
            this.panel_note = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.программаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВсеДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВсеДанныеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьКатегориюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Category_List
            // 
            this.Category_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Category_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Category_List.FormattingEnabled = true;
            this.Category_List.Location = new System.Drawing.Point(12, 49);
            this.Category_List.Name = "Category_List";
            this.Category_List.Size = new System.Drawing.Size(171, 28);
            this.Category_List.TabIndex = 0;
            this.Category_List.SelectedIndexChanged += new System.EventHandler(this.Category_List_SelectedIndexChanged);
            this.Category_List.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Category_List_MouseClick);
            // 
            // add_note
            // 
            this.add_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_note.Location = new System.Drawing.Point(12, 84);
            this.add_note.Name = "add_note";
            this.add_note.Size = new System.Drawing.Size(171, 30);
            this.add_note.TabIndex = 1;
            this.add_note.Text = "Добавить категорию";
            this.add_note.UseVisualStyleBackColor = true;
            this.add_note.Click += new System.EventHandler(this.add_category_Click);
            // 
            // add_category
            // 
            this.add_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_category.Location = new System.Drawing.Point(12, 120);
            this.add_category.Name = "add_category";
            this.add_category.Size = new System.Drawing.Size(171, 30);
            this.add_category.TabIndex = 1;
            this.add_category.Text = "Добавить запись";
            this.add_category.UseVisualStyleBackColor = true;
            this.add_category.Click += new System.EventHandler(this.add_note_Click);
            // 
            // edit_btn
            // 
            this.edit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit_btn.Location = new System.Drawing.Point(12, 156);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(171, 30);
            this.edit_btn.TabIndex = 1;
            this.edit_btn.Text = "Редактировать";
            this.edit_btn.UseVisualStyleBackColor = true;
            this.edit_btn.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // panel_note
            // 
            this.panel_note.AutoScroll = true;
            this.panel_note.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel_note.Location = new System.Drawing.Point(201, 28);
            this.panel_note.Name = "panel_note";
            this.panel_note.Size = new System.Drawing.Size(448, 356);
            this.panel_note.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.программаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(663, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // программаToolStripMenuItem
            // 
            this.программаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьВсеДанныеToolStripMenuItem,
            this.удалитьВсеДанныеToolStripMenuItem1,
            this.удалитьКатегориюToolStripMenuItem});
            this.программаToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.программаToolStripMenuItem.Name = "программаToolStripMenuItem";
            this.программаToolStripMenuItem.Size = new System.Drawing.Size(90, 21);
            this.программаToolStripMenuItem.Text = "Программа";
            // 
            // удалитьВсеДанныеToolStripMenuItem
            // 
            this.удалитьВсеДанныеToolStripMenuItem.Name = "удалитьВсеДанныеToolStripMenuItem";
            this.удалитьВсеДанныеToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.удалитьВсеДанныеToolStripMenuItem.Text = "Категория выполнена";
            this.удалитьВсеДанныеToolStripMenuItem.Click += new System.EventHandler(this.CategoryToArchive_Click);
            // 
            // удалитьВсеДанныеToolStripMenuItem1
            // 
            this.удалитьВсеДанныеToolStripMenuItem1.Name = "удалитьВсеДанныеToolStripMenuItem1";
            this.удалитьВсеДанныеToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.удалитьВсеДанныеToolStripMenuItem1.Text = "Удалить все данные";
            this.удалитьВсеДанныеToolStripMenuItem1.Click += new System.EventHandler(this.DellAllDate_Click);
            // 
            // удалитьКатегориюToolStripMenuItem
            // 
            this.удалитьКатегориюToolStripMenuItem.Name = "удалитьКатегориюToolStripMenuItem";
            this.удалитьКатегориюToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.удалитьКатегориюToolStripMenuItem.Text = "Удалить категорию";
            this.удалитьКатегориюToolStripMenuItem.Click += new System.EventHandler(this.DellCurrentCategory);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Категория: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 399);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_note);
            this.Controls.Add(this.edit_btn);
            this.Controls.Add(this.add_category);
            this.Controls.Add(this.add_note);
            this.Controls.Add(this.Category_List);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.ComboBox Category_List;
        private System.Windows.Forms.Button add_note;
        private System.Windows.Forms.Button add_category;
        private System.Windows.Forms.Button edit_btn;
        private System.Windows.Forms.Panel panel_note;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem программаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВсеДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВсеДанныеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьКатегориюToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}
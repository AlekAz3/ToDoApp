namespace View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.add_category = new System.Windows.Forms.Button();
            this.Category_List = new System.Windows.Forms.ComboBox();
            this.add_note = new System.Windows.Forms.Button();
            this.edit_btn = new System.Windows.Forms.Button();
            this.archive_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_note = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.программаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВсеДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // add_category
            // 
            this.add_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_category.Location = new System.Drawing.Point(15, 82);
            this.add_category.Name = "add_category";
            this.add_category.Size = new System.Drawing.Size(171, 30);
            this.add_category.TabIndex = 1;
            this.add_category.Text = "Добавить категорию";
            this.add_category.UseVisualStyleBackColor = true;
            this.add_category.Click += new System.EventHandler(this.add_category_Click);
            // 
            // Category_List
            // 
            this.Category_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Category_List.FormattingEnabled = true;
            this.Category_List.Location = new System.Drawing.Point(15, 45);
            this.Category_List.Name = "Category_List";
            this.Category_List.Size = new System.Drawing.Size(171, 26);
            this.Category_List.TabIndex = 2;
            this.Category_List.SelectedIndexChanged += new System.EventHandler(this.Category_List_SelectedIndexChanged);
            this.Category_List.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Category_List_MouseClick);
            // 
            // add_note
            // 
            this.add_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_note.Location = new System.Drawing.Point(15, 118);
            this.add_note.Name = "add_note";
            this.add_note.Size = new System.Drawing.Size(171, 30);
            this.add_note.TabIndex = 1;
            this.add_note.Text = "Добавить пункт";
            this.add_note.UseVisualStyleBackColor = true;
            this.add_note.Click += new System.EventHandler(this.add_note_Click);
            // 
            // edit_btn
            // 
            this.edit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit_btn.Location = new System.Drawing.Point(15, 154);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(171, 30);
            this.edit_btn.TabIndex = 1;
            this.edit_btn.Text = "Редактировать ";
            this.edit_btn.UseVisualStyleBackColor = true;
            this.edit_btn.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // archive_btn
            // 
            this.archive_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.archive_btn.Location = new System.Drawing.Point(15, 342);
            this.archive_btn.Name = "archive_btn";
            this.archive_btn.Size = new System.Drawing.Size(171, 30);
            this.archive_btn.TabIndex = 1;
            this.archive_btn.Text = "Архив";
            this.archive_btn.UseVisualStyleBackColor = true;
            this.archive_btn.Click += new System.EventHandler(this.ArchiveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Категория: ";
            // 
            // panel_note
            // 
            this.panel_note.AutoScroll = true;
            this.panel_note.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel_note.Location = new System.Drawing.Point(211, 16);
            this.panel_note.Name = "panel_note";
            this.panel_note.Size = new System.Drawing.Size(448, 356);
            this.panel_note.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.программаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(673, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // программаToolStripMenuItem
            // 
            this.программаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem,
            this.удалитьВсеДанныеToolStripMenuItem});
            this.программаToolStripMenuItem.Name = "программаToolStripMenuItem";
            this.программаToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.программаToolStripMenuItem.Text = "Программа";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.debugToolStripMenuItem.Text = "debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.Debug_click);
            // 
            // удалитьВсеДанныеToolStripMenuItem
            // 
            this.удалитьВсеДанныеToolStripMenuItem.Name = "удалитьВсеДанныеToolStripMenuItem";
            this.удалитьВсеДанныеToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.удалитьВсеДанныеToolStripMenuItem.Text = "Удалить все данные";
            this.удалитьВсеДанныеToolStripMenuItem.Click += new System.EventHandler(this.DellAllDate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 389);
            this.Controls.Add(this.panel_note);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Category_List);
            this.Controls.Add(this.archive_btn);
            this.Controls.Add(this.edit_btn);
            this.Controls.Add(this.add_note);
            this.Controls.Add(this.add_category);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Заметки ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button add_category;
        private System.Windows.Forms.ComboBox Category_List;
        private System.Windows.Forms.Button add_note;
        private System.Windows.Forms.Button edit_btn;
        private System.Windows.Forms.Button archive_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_note;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem программаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьВсеДанныеToolStripMenuItem;
    }
}


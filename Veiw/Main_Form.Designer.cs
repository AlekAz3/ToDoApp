namespace Veiw
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
            this.debug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // add_category
            // 
            this.add_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_category.Location = new System.Drawing.Point(15, 69);
            this.add_category.Name = "add_category";
            this.add_category.Size = new System.Drawing.Size(171, 30);
            this.add_category.TabIndex = 1;
            this.add_category.Text = "Добавить категорию";
            this.add_category.UseVisualStyleBackColor = true;
            // 
            // Category_List
            // 
            this.Category_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Category_List.FormattingEnabled = true;
            this.Category_List.Location = new System.Drawing.Point(15, 32);
            this.Category_List.Name = "Category_List";
            this.Category_List.Size = new System.Drawing.Size(171, 26);
            this.Category_List.TabIndex = 2;
            // 
            // add_note
            // 
            this.add_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_note.Location = new System.Drawing.Point(15, 105);
            this.add_note.Name = "add_note";
            this.add_note.Size = new System.Drawing.Size(171, 30);
            this.add_note.TabIndex = 1;
            this.add_note.Text = "Добавить пункт";
            this.add_note.UseVisualStyleBackColor = true;
            // 
            // edit_btn
            // 
            this.edit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit_btn.Location = new System.Drawing.Point(15, 141);
            this.edit_btn.Name = "edit_btn";
            this.edit_btn.Size = new System.Drawing.Size(171, 30);
            this.edit_btn.TabIndex = 1;
            this.edit_btn.Text = "Редактировать ";
            this.edit_btn.UseVisualStyleBackColor = true;
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 11);
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
            // debug
            // 
            this.debug.Location = new System.Drawing.Point(55, 238);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(45, 22);
            this.debug.TabIndex = 5;
            this.debug.Text = "debug";
            this.debug.UseVisualStyleBackColor = true;
            this.debug.Click += new System.EventHandler(this.debug_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 389);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.panel_note);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Category_List);
            this.Controls.Add(this.archive_btn);
            this.Controls.Add(this.edit_btn);
            this.Controls.Add(this.add_note);
            this.Controls.Add(this.add_category);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Заметки ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
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
        private System.Windows.Forms.Button debug;
    }
}


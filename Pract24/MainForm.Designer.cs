namespace Pract24
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
            this.MainTextBox = new System.Windows.Forms.RichTextBox();
            this.AddDep = new System.Windows.Forms.Button();
            this.AddEmp = new System.Windows.Forms.Button();
            this.RemoveDep = new System.Windows.Forms.Button();
            this.RemoveEmp = new System.Windows.Forms.Button();
            this.EditDep = new System.Windows.Forms.Button();
            this.TransferEmp = new System.Windows.Forms.Button();
            this.MainSearch = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OKButton = new System.Windows.Forms.Button();
            this.CounterLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ShowAll = new System.Windows.Forms.Button();
            this.NameSearch = new System.Windows.Forms.Button();
            this.PosSearch = new System.Windows.Forms.Button();
            this.NameDepSearch = new System.Windows.Forms.Button();
            this.PosDepSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainTextBox
            // 
            this.MainTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MainTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MainTextBox.DetectUrls = false;
            this.MainTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainTextBox.Location = new System.Drawing.Point(12, 42);
            this.MainTextBox.Name = "MainTextBox";
            this.MainTextBox.ReadOnly = true;
            this.MainTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.MainTextBox.Size = new System.Drawing.Size(360, 300);
            this.MainTextBox.TabIndex = 0;
            this.MainTextBox.Text = "";
            // 
            // AddDep
            // 
            this.AddDep.Location = new System.Drawing.Point(12, 348);
            this.AddDep.Name = "AddDep";
            this.AddDep.Size = new System.Drawing.Size(150, 35);
            this.AddDep.TabIndex = 1;
            this.AddDep.Text = "Добавить отдел";
            this.AddDep.UseVisualStyleBackColor = true;
            this.AddDep.Click += new System.EventHandler(this.AddDep_Click);
            // 
            // AddEmp
            // 
            this.AddEmp.Location = new System.Drawing.Point(222, 348);
            this.AddEmp.Name = "AddEmp";
            this.AddEmp.Size = new System.Drawing.Size(150, 35);
            this.AddEmp.TabIndex = 2;
            this.AddEmp.Text = "Добавить сотрудника";
            this.AddEmp.UseVisualStyleBackColor = true;
            this.AddEmp.Click += new System.EventHandler(this.AddEmp_Click);
            // 
            // RemoveDep
            // 
            this.RemoveDep.Location = new System.Drawing.Point(12, 389);
            this.RemoveDep.Name = "RemoveDep";
            this.RemoveDep.Size = new System.Drawing.Size(150, 35);
            this.RemoveDep.TabIndex = 3;
            this.RemoveDep.Text = "Удалить отдел";
            this.RemoveDep.UseVisualStyleBackColor = true;
            this.RemoveDep.Click += new System.EventHandler(this.RemoveDep_Click);
            // 
            // RemoveEmp
            // 
            this.RemoveEmp.Location = new System.Drawing.Point(222, 389);
            this.RemoveEmp.Name = "RemoveEmp";
            this.RemoveEmp.Size = new System.Drawing.Size(150, 35);
            this.RemoveEmp.TabIndex = 4;
            this.RemoveEmp.Text = "Удалить сотрудника";
            this.RemoveEmp.UseVisualStyleBackColor = true;
            this.RemoveEmp.Click += new System.EventHandler(this.RemoveEmp_Click);
            // 
            // EditDep
            // 
            this.EditDep.Location = new System.Drawing.Point(12, 430);
            this.EditDep.Name = "EditDep";
            this.EditDep.Size = new System.Drawing.Size(150, 35);
            this.EditDep.TabIndex = 5;
            this.EditDep.Text = "Изменить описание отдела";
            this.EditDep.UseVisualStyleBackColor = true;
            this.EditDep.Click += new System.EventHandler(this.EditDep_Click);
            // 
            // TransferEmp
            // 
            this.TransferEmp.Location = new System.Drawing.Point(222, 430);
            this.TransferEmp.Name = "TransferEmp";
            this.TransferEmp.Size = new System.Drawing.Size(150, 35);
            this.TransferEmp.TabIndex = 6;
            this.TransferEmp.Text = "Перевести сотрудника";
            this.TransferEmp.UseVisualStyleBackColor = true;
            this.TransferEmp.Click += new System.EventHandler(this.TransferEmp_Click);
            // 
            // MainSearch
            // 
            this.MainSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainSearch.Location = new System.Drawing.Point(12, 471);
            this.MainSearch.Name = "MainSearch";
            this.MainSearch.Size = new System.Drawing.Size(360, 35);
            this.MainSearch.TabIndex = 7;
            this.MainSearch.Text = "Поиск и просмотр";
            this.MainSearch.UseVisualStyleBackColor = true;
            this.MainSearch.Click += new System.EventHandler(this.MainSearch_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(12, 512);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(150, 35);
            this.LoadButton.TabIndex = 9;
            this.LoadButton.Text = "Добавить данные из файла";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(222, 512);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(150, 35);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Сохранить данные в файл";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt";
            this.OpenFileDialog.Title = "Добавить данные из файла";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.CreatePrompt = true;
            this.SaveFileDialog.Filter = "Текстовые файлы(*.txt)|*.txt";
            this.SaveFileDialog.Title = "Сохранить данные в файл";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(168, 348);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(48, 35);
            this.OKButton.TabIndex = 11;
            this.OKButton.Text = "ОК";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Visible = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CounterLabel
            // 
            this.CounterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CounterLabel.Location = new System.Drawing.Point(12, 9);
            this.CounterLabel.Name = "CounterLabel";
            this.CounterLabel.Size = new System.Drawing.Size(360, 30);
            this.CounterLabel.TabIndex = 12;
            this.CounterLabel.Text = "Число отделов: 0. Число сотрудников: 0.";
            this.CounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(168, 389);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(48, 35);
            this.CancelButton.TabIndex = 13;
            this.CancelButton.Text = "Х";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Visible = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ShowAll
            // 
            this.ShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowAll.Location = new System.Drawing.Point(12, 430);
            this.ShowAll.Name = "ShowAll";
            this.ShowAll.Size = new System.Drawing.Size(360, 35);
            this.ShowAll.TabIndex = 14;
            this.ShowAll.Text = "Вывести список всех сотрудников";
            this.ShowAll.UseVisualStyleBackColor = true;
            this.ShowAll.Visible = false;
            this.ShowAll.Click += new System.EventHandler(this.ShowAll_Click);
            // 
            // NameSearch
            // 
            this.NameSearch.Location = new System.Drawing.Point(12, 348);
            this.NameSearch.Name = "NameSearch";
            this.NameSearch.Size = new System.Drawing.Size(150, 35);
            this.NameSearch.TabIndex = 15;
            this.NameSearch.Text = "Поиск по фамилии";
            this.NameSearch.UseVisualStyleBackColor = true;
            this.NameSearch.Visible = false;
            this.NameSearch.Click += new System.EventHandler(this.NameSearch_Click);
            // 
            // PosSearch
            // 
            this.PosSearch.Location = new System.Drawing.Point(222, 348);
            this.PosSearch.Name = "PosSearch";
            this.PosSearch.Size = new System.Drawing.Size(150, 35);
            this.PosSearch.TabIndex = 16;
            this.PosSearch.Text = "Поиск по должности ";
            this.PosSearch.UseVisualStyleBackColor = true;
            this.PosSearch.Visible = false;
            this.PosSearch.Click += new System.EventHandler(this.PosSearch_Click);
            // 
            // NameDepSearch
            // 
            this.NameDepSearch.Location = new System.Drawing.Point(12, 389);
            this.NameDepSearch.Name = "NameDepSearch";
            this.NameDepSearch.Size = new System.Drawing.Size(150, 35);
            this.NameDepSearch.TabIndex = 17;
            this.NameDepSearch.Text = "Поиск по фамилии и отделу";
            this.NameDepSearch.UseVisualStyleBackColor = true;
            this.NameDepSearch.Visible = false;
            this.NameDepSearch.Click += new System.EventHandler(this.NameDepSearch_Click);
            // 
            // PosDepSearch
            // 
            this.PosDepSearch.Location = new System.Drawing.Point(222, 389);
            this.PosDepSearch.Name = "PosDepSearch";
            this.PosDepSearch.Size = new System.Drawing.Size(150, 35);
            this.PosDepSearch.TabIndex = 18;
            this.PosDepSearch.Text = "Поиск по должности и отделу";
            this.PosDepSearch.UseVisualStyleBackColor = true;
            this.PosDepSearch.Visible = false;
            this.PosDepSearch.Click += new System.EventHandler(this.PosDepSearch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(384, 562);
            this.Controls.Add(this.PosDepSearch);
            this.Controls.Add(this.NameDepSearch);
            this.Controls.Add(this.PosSearch);
            this.Controls.Add(this.NameSearch);
            this.Controls.Add(this.ShowAll);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CounterLabel);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.MainSearch);
            this.Controls.Add(this.TransferEmp);
            this.Controls.Add(this.EditDep);
            this.Controls.Add(this.RemoveEmp);
            this.Controls.Add(this.RemoveDep);
            this.Controls.Add(this.AddEmp);
            this.Controls.Add(this.AddDep);
            this.Controls.Add(this.MainTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(400, 600);
            this.MinimumSize = new System.Drawing.Size(400, 600);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "База данных";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddDep;
        private System.Windows.Forms.Button AddEmp;
        private System.Windows.Forms.Button RemoveDep;
        private System.Windows.Forms.Button RemoveEmp;
        private System.Windows.Forms.Button EditDep;
        private System.Windows.Forms.Button TransferEmp;
        private System.Windows.Forms.Button MainSearch;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.RichTextBox MainTextBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label CounterLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ShowAll;
        private System.Windows.Forms.Button NameSearch;
        private System.Windows.Forms.Button PosSearch;
        private System.Windows.Forms.Button NameDepSearch;
        private System.Windows.Forms.Button PosDepSearch;
    }
}


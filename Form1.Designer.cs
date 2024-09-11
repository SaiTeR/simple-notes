namespace Lab2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            createTaskBtn = new Button();
            taskNameTxt = new TextBox();
            taskBoardGb = new CustomGroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupNameTxt = new TextBox();
            createGroupBtn = new Button();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // createTaskBtn
            // 
            createTaskBtn.Location = new Point(7, 55);
            createTaskBtn.Margin = new Padding(3, 4, 3, 4);
            createTaskBtn.Name = "createTaskBtn";
            createTaskBtn.Size = new Size(261, 45);
            createTaskBtn.TabIndex = 0;
            createTaskBtn.Text = "Создать заметку";
            createTaskBtn.UseVisualStyleBackColor = true;
            createTaskBtn.Click += createTaskBtn_Click;
            // 
            // taskNameTxt
            // 
            taskNameTxt.BorderStyle = BorderStyle.None;
            taskNameTxt.Location = new Point(7, 25);
            taskNameTxt.Margin = new Padding(3, 4, 3, 4);
            taskNameTxt.MaxLength = 26;
            taskNameTxt.Name = "taskNameTxt";
            taskNameTxt.PlaceholderText = "Новая заметка";
            taskNameTxt.Size = new Size(261, 20);
            taskNameTxt.TabIndex = 1;
            // 
            // taskBoardGb
            // 
            taskBoardGb.Component = null;
            taskBoardGb.Location = new Point(14, 149);
            taskBoardGb.Margin = new Padding(3, 4, 3, 4);
            taskBoardGb.Name = "taskBoardGb";
            taskBoardGb.Padding = new Padding(3, 4, 3, 4);
            taskBoardGb.Size = new Size(1223, 612);
            taskBoardGb.TabIndex = 2;
            taskBoardGb.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(taskNameTxt);
            groupBox2.Controls.Add(createTaskBtn);
            groupBox2.Location = new Point(14, 16);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(281, 125);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupNameTxt);
            groupBox3.Controls.Add(createGroupBtn);
            groupBox3.Location = new Point(955, 16);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(281, 125);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            // 
            // groupNameTxt
            // 
            groupNameTxt.BorderStyle = BorderStyle.None;
            groupNameTxt.Location = new Point(7, 25);
            groupNameTxt.Margin = new Padding(3, 4, 3, 4);
            groupNameTxt.Name = "groupNameTxt";
            groupNameTxt.PlaceholderText = "Новая группа";
            groupNameTxt.Size = new Size(261, 20);
            groupNameTxt.TabIndex = 1;
            // 
            // createGroupBtn
            // 
            createGroupBtn.Location = new Point(7, 55);
            createGroupBtn.Margin = new Padding(3, 4, 3, 4);
            createGroupBtn.Name = "createGroupBtn";
            createGroupBtn.Size = new Size(261, 45);
            createGroupBtn.TabIndex = 0;
            createGroupBtn.Text = "Создать группу";
            createGroupBtn.UseVisualStyleBackColor = true;
            createGroupBtn.Click += createGroupBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 777);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(taskBoardGb);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "SaiTeR's TO-DOer";
            FormClosing += Form1_FormClosing;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button createTaskBtn;
        private TextBox taskNameTxt;
        private CustomGroupBox taskBoardGb;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TextBox groupNameTxt;
        private Button createGroupBtn;
    }
}

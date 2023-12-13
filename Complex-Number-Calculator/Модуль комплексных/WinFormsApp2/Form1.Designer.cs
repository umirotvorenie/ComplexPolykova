namespace WinFormsApp2
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox realTextBox;
        private TextBox imaginaryTextBox;
        private Button calculateButton;
        private Label modulusLabel;
        private Label argumentLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            realTextBox = new TextBox();
            imaginaryTextBox = new TextBox();
            calculateButton = new Button();
            modulusLabel = new Label();
            argumentLabel = new Label();
            clearButton = new Button();
            wordButton = new Button();
            excelButton = new Button();
            exitButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button2 = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // realTextBox
            // 
            realTextBox.Location = new Point(161, 34);
            realTextBox.MaxLength = 9;
            realTextBox.Name = "realTextBox";
            realTextBox.Size = new Size(144, 23);
            realTextBox.TabIndex = 0;
            realTextBox.KeyPress += realTextBox_KeyPress;
            // 
            // imaginaryTextBox
            // 
            imaginaryTextBox.Location = new Point(338, 34);
            imaginaryTextBox.MaxLength = 9;
            imaginaryTextBox.Name = "imaginaryTextBox";
            imaginaryTextBox.Size = new Size(140, 23);
            imaginaryTextBox.TabIndex = 1;
            imaginaryTextBox.KeyPress += imaginaryTextBox_KeyPress;
            // 
            // calculateButton
            // 
            calculateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            calculateButton.FlatStyle = FlatStyle.Flat;
            calculateButton.Location = new Point(413, 133);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(206, 47);
            calculateButton.TabIndex = 2;
            calculateButton.Text = "Вычислить";
            calculateButton.UseVisualStyleBackColor = true;
            calculateButton.Click += calculateButton_Click;
            // 
            // modulusLabel
            // 
            modulusLabel.AutoSize = true;
            modulusLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            modulusLabel.Location = new Point(23, 247);
            modulusLabel.Name = "modulusLabel";
            modulusLabel.Size = new Size(0, 25);
            modulusLabel.TabIndex = 3;
            // 
            // argumentLabel
            // 
            argumentLabel.AutoSize = true;
            argumentLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            argumentLabel.Location = new Point(23, 292);
            argumentLabel.Name = "argumentLabel";
            argumentLabel.Size = new Size(0, 25);
            argumentLabel.TabIndex = 4;
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Location = new Point(413, 186);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(206, 47);
            clearButton.TabIndex = 5;
            clearButton.Text = "Очистить";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // wordButton
            // 
            wordButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            wordButton.FlatStyle = FlatStyle.Flat;
            wordButton.Location = new Point(413, 239);
            wordButton.Name = "wordButton";
            wordButton.Size = new Size(206, 47);
            wordButton.TabIndex = 6;
            wordButton.Text = "Вывести в Word";
            wordButton.UseVisualStyleBackColor = true;
            wordButton.Click += wordButton_Click;
            // 
            // excelButton
            // 
            excelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            excelButton.FlatStyle = FlatStyle.Flat;
            excelButton.Location = new Point(413, 292);
            excelButton.Name = "excelButton";
            excelButton.Size = new Size(206, 47);
            excelButton.TabIndex = 7;
            excelButton.Text = "Вывести в Excel";
            excelButton.UseVisualStyleBackColor = true;
            excelButton.Click += excelButton_Click;
            // 
            // exitButton
            // 
            exitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Location = new Point(413, 398);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(206, 47);
            exitButton.TabIndex = 8;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 133);
            label1.Name = "label1";
            label1.Size = new Size(374, 80);
            label1.TabIndex = 9;
            label1.Text = "Данная программа предназначена для вычисления\r\nмодуля и главного аргумента комплексного числа. \r\nКомплексное число - это число вида a + bi, \r\nгде a - \"Реальная часть\", а bi - \"Мнимая часть\".";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(161, 60);
            label2.Name = "label2";
            label2.Size = new Size(131, 21);
            label2.TabIndex = 10;
            label2.Text = "Реальная часть";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(338, 60);
            label3.Name = "label3";
            label3.Size = new Size(124, 21);
            label3.TabIndex = 11;
            label3.Text = "Мнимая часть";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(112, 35);
            label4.Name = "label4";
            label4.Size = new Size(43, 22);
            label4.TabIndex = 12;
            label4.Text = "Z = ";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(463, 36);
            label5.Name = "label5";
            label5.Size = new Size(13, 19);
            label5.TabIndex = 13;
            label5.Text = "i";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(413, 345);
            button2.Name = "button2";
            button2.Size = new Size(206, 47);
            button2.TabIndex = 15;
            button2.Text = "Вывести в PDF";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(311, 33);
            label6.Name = "label6";
            label6.Size = new Size(21, 22);
            label6.TabIndex = 16;
            label6.Text = "+";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            ClientSize = new Size(631, 469);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(exitButton);
            Controls.Add(excelButton);
            Controls.Add(wordButton);
            Controls.Add(clearButton);
            Controls.Add(realTextBox);
            Controls.Add(imaginaryTextBox);
            Controls.Add(calculateButton);
            Controls.Add(modulusLabel);
            Controls.Add(argumentLabel);
            Name = "MainForm";
            Text = "Модуль и главный аргумент комплексных чисел";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button clearButton;
        private Button wordButton;
        private Button excelButton;
        private Button exitButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button2;
        private Label label6;
    }
}

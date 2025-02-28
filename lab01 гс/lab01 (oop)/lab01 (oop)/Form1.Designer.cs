namespace lab01__oop_
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
            button1 = new Button();
            nameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            costTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            comboBox = new ComboBox();
            volumeTextBox = new TextBox();
            label5 = new Label();
            markupTextBox = new TextBox();
            label6 = new Label();
            everydayTextBox = new TextBox();
            selfCostTextBox = new TextBox();
            costPerTextBox = new TextBox();
            monthTextBox = new TextBox();
            label7 = new Label();
            resLabel = new Label();
            label9 = new Label();
            name2TextBox = new TextBox();
            label10 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Location = new Point(666, 348);
            button1.Name = "button1";
            button1.Size = new Size(154, 66);
            button1.TabIndex = 0;
            button1.Text = "Рассчитать";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(347, 4);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(262, 35);
            nameTextBox.TabIndex = 1;
            nameTextBox.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(257, 30);
            label1.TabIndex = 2;
            label1.Text = "Введите название товара";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(268, 30);
            label2.TabIndex = 3;
            label2.Text = "Введите стоимость товара";
            // 
            // costTextBox
            // 
            costTextBox.Location = new Point(347, 47);
            costTextBox.Name = "costTextBox";
            costTextBox.Size = new Size(175, 35);
            costTextBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 108);
            label3.Name = "label3";
            label3.Size = new Size(305, 30);
            label3.TabIndex = 6;
            label3.Text = "Выберите единицу измерения";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 160);
            label4.Name = "label4";
            label4.Size = new Size(230, 30);
            label4.TabIndex = 7;
            label4.Text = "Введите объём товара";
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "кг", "т", "л", "м^3" });
            comboBox.Location = new Point(347, 100);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(212, 38);
            comboBox.TabIndex = 8;
            comboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // volumeTextBox
            // 
            volumeTextBox.Location = new Point(347, 155);
            volumeTextBox.Name = "volumeTextBox";
            volumeTextBox.Size = new Size(175, 35);
            volumeTextBox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 213);
            label5.Name = "label5";
            label5.Size = new Size(175, 30);
            label5.TabIndex = 10;
            label5.Text = "Введите наценку";
            // 
            // markupTextBox
            // 
            markupTextBox.Location = new Point(347, 208);
            markupTextBox.Name = "markupTextBox";
            markupTextBox.Size = new Size(175, 35);
            markupTextBox.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 261);
            label6.Name = "label6";
            label6.Size = new Size(496, 30);
            label6.TabIndex = 12;
            label6.Text = "Введите кол-во ежедневного потребления товара";
            label6.Click += label6_Click;
            // 
            // everydayTextBox
            // 
            everydayTextBox.Location = new Point(572, 256);
            everydayTextBox.Name = "everydayTextBox";
            everydayTextBox.Size = new Size(175, 35);
            everydayTextBox.TabIndex = 13;
            // 
            // selfCostTextBox
            // 
            selfCostTextBox.Location = new Point(1184, 51);
            selfCostTextBox.Name = "selfCostTextBox";
            selfCostTextBox.Size = new Size(175, 35);
            selfCostTextBox.TabIndex = 14;
            // 
            // costPerTextBox
            // 
            costPerTextBox.Location = new Point(1184, 94);
            costPerTextBox.Name = "costPerTextBox";
            costPerTextBox.Size = new Size(175, 35);
            costPerTextBox.TabIndex = 15;
            // 
            // monthTextBox
            // 
            monthTextBox.Location = new Point(1184, 135);
            monthTextBox.Name = "monthTextBox";
            monthTextBox.Size = new Size(175, 35);
            monthTextBox.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(880, 56);
            label7.Name = "label7";
            label7.Size = new Size(232, 30);
            label7.TabIndex = 17;
            label7.Text = "Себестоимость товара";
            // 
            // resLabel
            // 
            resLabel.AutoSize = true;
            resLabel.Location = new Point(880, 99);
            resLabel.Name = "resLabel";
            resLabel.Size = new Size(0, 30);
            resLabel.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(880, 140);
            label9.Name = "label9";
            label9.Size = new Size(186, 30);
            label9.TabIndex = 19;
            label9.Text = "Расходы за месяц";
            // 
            // name2TextBox
            // 
            name2TextBox.Location = new Point(1184, 9);
            name2TextBox.Name = "name2TextBox";
            name2TextBox.Size = new Size(175, 35);
            name2TextBox.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(880, 14);
            label10.Name = "label10";
            label10.Size = new Size(177, 30);
            label10.TabIndex = 21;
            label10.Text = "Название товара";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1414, 684);
            Controls.Add(label10);
            Controls.Add(name2TextBox);
            Controls.Add(label9);
            Controls.Add(resLabel);
            Controls.Add(label7);
            Controls.Add(monthTextBox);
            Controls.Add(costPerTextBox);
            Controls.Add(selfCostTextBox);
            Controls.Add(everydayTextBox);
            Controls.Add(label6);
            Controls.Add(markupTextBox);
            Controls.Add(label5);
            Controls.Add(volumeTextBox);
            Controls.Add(comboBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(costTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nameTextBox);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox nameTextBox;
        private Label label1;
        private Label label2;
        private TextBox costTextBox;
        private Label label3;
        private Label label4;
        private ComboBox comboBox;
        private TextBox volumeTextBox;
        private Label label5;
        private TextBox markupTextBox;
        private Label label6;
        private TextBox everydayTextBox;
        private TextBox selfCostTextBox;
        private TextBox costPerTextBox;
        private TextBox monthTextBox;
        private Label label7;
        private Label resLabel;
        private Label label9;
        private TextBox name2TextBox;
        private Label label10;
    }
}

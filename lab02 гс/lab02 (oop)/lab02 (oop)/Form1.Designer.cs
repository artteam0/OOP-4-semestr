namespace lab02
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button1 = new Button();
            Apart = new TextBox();
            Corp = new TextBox();
            House = new TextBox();
            Street = new TextBox();
            District = new TextBox();
            City = new TextBox();
            Country = new ComboBox();
            Parking = new CheckBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            Floor = new NumericUpDown();
            label7 = new Label();
            Brick = new RadioButton();
            Panel = new RadioButton();
            label6 = new Label();
            label5 = new Label();
            YearOfBuilt = new DateTimePicker();
            ClosedBalcony = new CheckBox();
            OpenedBalcony = new CheckBox();
            Basement = new CheckBox();
            Studio = new CheckBox();
            Wardrobe = new CheckBox();
            Bathroom = new CheckBox();
            San = new CheckBox();
            Kitchen = new CheckBox();
            label4 = new Label();
            NumOfRooms = new ComboBox();
            Metraz = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            button2 = new Button();
            textBox1 = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Floor).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1499, 687);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(Apart);
            tabPage1.Controls.Add(Corp);
            tabPage1.Controls.Add(House);
            tabPage1.Controls.Add(Street);
            tabPage1.Controls.Add(District);
            tabPage1.Controls.Add(City);
            tabPage1.Controls.Add(Country);
            tabPage1.Controls.Add(Parking);
            tabPage1.Controls.Add(label15);
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(Floor);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(Brick);
            tabPage1.Controls.Add(Panel);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(YearOfBuilt);
            tabPage1.Controls.Add(ClosedBalcony);
            tabPage1.Controls.Add(OpenedBalcony);
            tabPage1.Controls.Add(Basement);
            tabPage1.Controls.Add(Studio);
            tabPage1.Controls.Add(Wardrobe);
            tabPage1.Controls.Add(Bathroom);
            tabPage1.Controls.Add(San);
            tabPage1.Controls.Add(Kitchen);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(NumOfRooms);
            tabPage1.Controls.Add(Metraz);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1491, 644);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Location = new Point(714, 543);
            button1.Name = "button1";
            button1.Size = new Size(269, 87);
            button1.TabIndex = 76;
            button1.Text = "Расчет стоимости и занесение данных в файл";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Apart
            // 
            Apart.Location = new Point(1177, 458);
            Apart.Name = "Apart";
            Apart.Size = new Size(62, 35);
            Apart.TabIndex = 75;
            // 
            // Corp
            // 
            Corp.Location = new Point(1177, 399);
            Corp.Name = "Corp";
            Corp.Size = new Size(62, 35);
            Corp.TabIndex = 74;
            // 
            // House
            // 
            House.Location = new Point(1177, 342);
            House.Name = "House";
            House.Size = new Size(62, 35);
            House.TabIndex = 73;
            // 
            // Street
            // 
            Street.Location = new Point(1177, 285);
            Street.Name = "Street";
            Street.Size = new Size(212, 35);
            Street.TabIndex = 72;
            // 
            // District
            // 
            District.Location = new Point(1177, 230);
            District.Name = "District";
            District.Size = new Size(212, 35);
            District.TabIndex = 71;
            // 
            // City
            // 
            City.Location = new Point(1177, 175);
            City.Name = "City";
            City.Size = new Size(212, 35);
            City.TabIndex = 70;
            // 
            // Country
            // 
            Country.FormattingEnabled = true;
            Country.Items.AddRange(new object[] { "Чехия", "Венгрия", "Германия", "Польша", "Литва", "Эстония", "Бельгия", "Великобритания" });
            Country.Location = new Point(1177, 119);
            Country.Name = "Country";
            Country.Size = new Size(212, 38);
            Country.TabIndex = 69;
            // 
            // Parking
            // 
            Parking.AutoSize = true;
            Parking.Location = new Point(639, 215);
            Parking.Name = "Parking";
            Parking.Size = new Size(217, 34);
            Parking.TabIndex = 68;
            Parking.Text = "Наличие паркинга";
            Parking.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(979, 458);
            label15.Name = "label15";
            label15.Size = new Size(181, 30);
            label15.TabIndex = 67;
            label15.Text = "Номер квартиры:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(979, 399);
            label14.Name = "label14";
            label14.Size = new Size(86, 30);
            label14.TabIndex = 66;
            label14.Text = "Корпус:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(979, 342);
            label13.Name = "label13";
            label13.Size = new Size(60, 30);
            label13.TabIndex = 65;
            label13.Text = "Дом:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(979, 285);
            label12.Name = "label12";
            label12.Size = new Size(77, 30);
            label12.TabIndex = 64;
            label12.Text = "Улица:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(979, 230);
            label11.Name = "label11";
            label11.Size = new Size(77, 30);
            label11.TabIndex = 63;
            label11.Text = "Район:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(979, 175);
            label10.Name = "label10";
            label10.Size = new Size(75, 30);
            label10.TabIndex = 62;
            label10.Text = "Город:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(979, 122);
            label9.Name = "label9";
            label9.Size = new Size(86, 30);
            label9.TabIndex = 61;
            label9.Text = "Страна:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1124, 67);
            label8.Name = "label8";
            label8.Size = new Size(76, 30);
            label8.TabIndex = 60;
            label8.Text = "Адрес:";
            // 
            // Floor
            // 
            Floor.Location = new Point(318, 403);
            Floor.Maximum = new decimal(new int[] { 37, 0, 0, 0 });
            Floor.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            Floor.Name = "Floor";
            Floor.Size = new Size(110, 35);
            Floor.TabIndex = 59;
            Floor.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(102, 403);
            label7.Name = "label7";
            label7.Size = new Size(67, 30);
            label7.TabIndex = 58;
            label7.Text = "Этаж:";
            // 
            // Brick
            // 
            Brick.AutoSize = true;
            Brick.Location = new Point(435, 358);
            Brick.Name = "Brick";
            Brick.Size = new Size(110, 34);
            Brick.TabIndex = 57;
            Brick.TabStop = true;
            Brick.Text = "Кирпич";
            Brick.UseVisualStyleBackColor = true;
            // 
            // Panel
            // 
            Panel.AutoSize = true;
            Panel.Location = new Point(320, 358);
            Panel.Name = "Panel";
            Panel.Size = new Size(109, 34);
            Panel.TabIndex = 56;
            Panel.TabStop = true;
            Panel.Text = "Панель";
            Panel.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(102, 358);
            label6.Name = "label6";
            label6.Size = new Size(162, 30);
            label6.TabIndex = 55;
            label6.Text = "Тип материала:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(102, 312);
            label5.Name = "label5";
            label5.Size = new Size(158, 30);
            label5.TabIndex = 54;
            label5.Text = "Год постройки:";
            // 
            // YearOfBuilt
            // 
            YearOfBuilt.CustomFormat = "yyyy";
            YearOfBuilt.Format = DateTimePickerFormat.Custom;
            YearOfBuilt.Location = new Point(318, 312);
            YearOfBuilt.MaxDate = new DateTime(2029, 2, 1, 0, 0, 0, 0);
            YearOfBuilt.MinDate = new DateTime(1911, 3, 17, 0, 0, 0, 0);
            YearOfBuilt.Name = "YearOfBuilt";
            YearOfBuilt.ShowUpDown = true;
            YearOfBuilt.Size = new Size(111, 35);
            YearOfBuilt.TabIndex = 53;
            YearOfBuilt.Value = new DateTime(2025, 2, 18, 0, 0, 0, 0);
            // 
            // ClosedBalcony
            // 
            ClosedBalcony.AutoSize = true;
            ClosedBalcony.Location = new Point(318, 255);
            ClosedBalcony.Name = "ClosedBalcony";
            ClosedBalcony.Size = new Size(208, 34);
            ClosedBalcony.TabIndex = 52;
            ClosedBalcony.Text = "Закрытый балкон";
            ClosedBalcony.UseVisualStyleBackColor = true;
            // 
            // OpenedBalcony
            // 
            OpenedBalcony.AutoSize = true;
            OpenedBalcony.Location = new Point(532, 255);
            OpenedBalcony.Name = "OpenedBalcony";
            OpenedBalcony.Size = new Size(211, 34);
            OpenedBalcony.TabIndex = 51;
            OpenedBalcony.Text = "Открытый балкон";
            OpenedBalcony.UseVisualStyleBackColor = true;
            // 
            // Basement
            // 
            Basement.AutoSize = true;
            Basement.Location = new Point(318, 215);
            Basement.Name = "Basement";
            Basement.Size = new Size(110, 34);
            Basement.TabIndex = 50;
            Basement.Text = "Подвал";
            Basement.UseVisualStyleBackColor = true;
            // 
            // Studio
            // 
            Studio.AutoSize = true;
            Studio.Location = new Point(433, 215);
            Studio.Name = "Studio";
            Studio.Size = new Size(200, 34);
            Studio.TabIndex = 49;
            Studio.Text = "Квартира-студия";
            Studio.UseVisualStyleBackColor = true;
            // 
            // Wardrobe
            // 
            Wardrobe.AutoSize = true;
            Wardrobe.Location = new Point(639, 175);
            Wardrobe.Name = "Wardrobe";
            Wardrobe.Size = new Size(164, 34);
            Wardrobe.TabIndex = 48;
            Wardrobe.Text = "Гардеробная";
            Wardrobe.UseVisualStyleBackColor = true;
            // 
            // Bathroom
            // 
            Bathroom.AutoSize = true;
            Bathroom.Location = new Point(536, 175);
            Bathroom.Name = "Bathroom";
            Bathroom.Size = new Size(97, 34);
            Bathroom.TabIndex = 47;
            Bathroom.Text = "Ванна";
            Bathroom.UseVisualStyleBackColor = true;
            // 
            // San
            // 
            San.AutoSize = true;
            San.Location = new Point(414, 175);
            San.Name = "San";
            San.Size = new Size(116, 34);
            San.TabIndex = 46;
            San.Text = "Санузел";
            San.UseVisualStyleBackColor = true;
            // 
            // Kitchen
            // 
            Kitchen.AutoSize = true;
            Kitchen.Location = new Point(318, 175);
            Kitchen.Name = "Kitchen";
            Kitchen.Size = new Size(94, 34);
            Kitchen.TabIndex = 45;
            Kitchen.Text = "Кухня";
            Kitchen.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(102, 175);
            label4.Name = "label4";
            label4.Size = new Size(83, 30);
            label4.TabIndex = 44;
            label4.Text = "Опции:";
            // 
            // NumOfRooms
            // 
            NumOfRooms.FormattingEnabled = true;
            NumOfRooms.Items.AddRange(new object[] { "1", "2", "3", "4" });
            NumOfRooms.Location = new Point(318, 114);
            NumOfRooms.Name = "NumOfRooms";
            NumOfRooms.Size = new Size(212, 38);
            NumOfRooms.TabIndex = 43;
            // 
            // Metraz
            // 
            Metraz.FormattingEnabled = true;
            Metraz.Items.AddRange(new object[] { "28-33 m^2", "34-40 m^2", "41-55 m^2", "40-47 m^2", "49-56 m^2", "58-75 m^2", "52-59 m^2", "60-74 m^2", "75-95 m^2" });
            Metraz.Location = new Point(318, 59);
            Metraz.Name = "Metraz";
            Metraz.Size = new Size(212, 38);
            Metraz.TabIndex = 42;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 114);
            label3.Name = "label3";
            label3.Size = new Size(205, 30);
            label3.TabIndex = 41;
            label3.Text = "Количество комнат:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 59);
            label2.Name = "label2";
            label2.Size = new Size(96, 30);
            label2.TabIndex = 40;
            label2.Text = "Метраж:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(730, 15);
            label1.Name = "label1";
            label1.Size = new Size(195, 30);
            label1.TabIndex = 39;
            label1.Text = "Объект \"Квартира\"";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(button2);
            tabPage2.Location = new Point(4, 39);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1491, 644);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // button2
            // 
            button2.Location = new Point(623, 525);
            button2.Name = "button2";
            button2.Size = new Size(215, 66);
            button2.TabIndex = 0;
            button2.Text = "Вывод из файла";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(62, 37);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(1355, 465);
            textBox1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1507, 689);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Floor).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button1;
        private TextBox Apart;
        private TextBox Corp;
        private TextBox House;
        private TextBox Street;
        private TextBox District;
        private TextBox City;
        private ComboBox Country;
        private CheckBox Parking;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private NumericUpDown Floor;
        private Label label7;
        private RadioButton Brick;
        private RadioButton Panel;
        private Label label6;
        private Label label5;
        private DateTimePicker YearOfBuilt;
        private CheckBox ClosedBalcony;
        private CheckBox OpenedBalcony;
        private CheckBox Basement;
        private CheckBox Studio;
        private CheckBox Wardrobe;
        private CheckBox Bathroom;
        private CheckBox San;
        private CheckBox Kitchen;
        private Label label4;
        private ComboBox NumOfRooms;
        private ComboBox Metraz;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button2;
        private TextBox textBox1;
    }
}

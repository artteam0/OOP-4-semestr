using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Data;
using System.Timers;
using Timer = System.Windows.Forms.Timer;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace lab02
{
    public partial class Form1 : Form
    {
        private int objectCount = 0;
        private string lastAction = "Ожидание действия";
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel countLabel;
        private ToolStripStatusLabel actionLabel;
        private ToolStripStatusLabel timeLabel;
        private Timer timer;
        public Form1()
        {
            InitializeComponent();
            statusStrip1 = new StatusStrip();

            countLabel = new ToolStripStatusLabel($"Объекты: {objectCount}");
            actionLabel = new ToolStripStatusLabel($"Действие: {lastAction}");
            timeLabel = new ToolStripStatusLabel($"Время: {DateTime.Now.ToString("G")}");

            statusStrip1.Items.Add(countLabel);
            statusStrip1.Items.Add(actionLabel);
            statusStrip1.Items.Add(timeLabel);

            Controls.Add(statusStrip1);
            statusStrip1.Items.Add(countLabel);
            statusStrip1.Items.Add(actionLabel);
            statusStrip1.Items.Add(timeLabel);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private List<Kvartira> history = new List<Kvartira>();
        private int currentStateIndex = -1;
        private int maxStateIndex = -1;
        private List<string> allItems = new List<string>();
        private bool wasCleared = false;

        public class Kvartira
        {
            [Required(ErrorMessage = "Метраж обязателен")]
            public string Metraz { get; set; }

            [Required(ErrorMessage = "Количество комнат обязательно")]
            public int NumOfRooms { get; set; }
            public bool Kitchen { get; set; }
            public bool San { get; set; }
            public bool Bathroom { get; set; }
            public bool Wardrobe { get; set; }
            public bool Basement { get; set; }
            public bool Studio { get; set; }
            public bool Parking { get; set; }
            public bool ClosedBalcony { get; set; }
            public bool OpenedBalcony { get; set; }
            //public string YearOfBuilt { get; set; }
            public string Panel { get; set; }
            public string Brick { get; set; }
            public int Floor { get; set; }

            [Required(ErrorMessage = "Страна обязательна")]
            [RegularExpression(@"^[А-Яа-яЁёA-Za-z\s-]+$", ErrorMessage = "Страна должна содержать только буквы")]
            public string Country { get; set; }

            [Required(ErrorMessage = "Город обязателен")]
            [RegularExpression(@"^[А-Яа-яЁёA-Za-z\s-]+$", ErrorMessage = "Город должен содержать только буквы")]
            public string City { get; set; }
            public string District { get; set; }

            [RegularExpression(@"^[А-Яа-яЁёA-Za-z\s-]+$", ErrorMessage = "Улица должна содержать только буквы")]
            public string Street { get; set; }

            [RegularExpression(@"^\d+[A-Za-zА-Яа-я]*$", ErrorMessage = "Номер дома должен начинаться с цифры")]
            public string House { get; set; }
            public string Corp { get; set; }
            public string Apart { get; set; }
        }
        private bool ValidateKvartira(Kvartira kvartira, out List<string> validationErrors)
        {
            var context = new ValidationContext(kvartira, null, null);
            var results = new List<ValidationResult>();
            validationErrors = new List<string>();

            bool isValid = Validator.TryValidateObject(kvartira, context, results, true);

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    validationErrors.Add(validationResult.ErrorMessage);
                }
            }

            return isValid;
        }
        private void UpdateStatus()
        {
            countLabel.Text = $"Объекты: {objectCount}";
            actionLabel.Text = $"Действие: {lastAction}";
        }
        private void cost()
        {
            objectCount = history.Count;
            lastAction = "Расчет стоимости и занесение данных в файл";
            UpdateStatus();
        }
        private void searchString()
        {
            objectCount = history.Count;
            lastAction = "Поиск по строке";
            UpdateStatus();
        }
        private void search()
        {
            objectCount = history.Count;
            lastAction = "Кнопка поиск";
            UpdateStatus();
        }
        private void searchKriteria()
        {
            objectCount = history.Count;
            lastAction = "Поиск фильтру";
            UpdateStatus();
        }
        private void outt()
        {
            objectCount = history.Count;
            lastAction = "Вывод данных из файла";
            UpdateStatus();
        }
        private void clear()
        {
            objectCount = history.Count;
            lastAction = "Очистка данных";
            UpdateStatus();
        }
        private void delete()
        {
            objectCount = history.Count;
            lastAction = "Удаление данных из файла";
            UpdateStatus();
        }
        private void back()
        {
            objectCount = history.Count;
            lastAction = "Назад";
            UpdateStatus();
        }
        private void forward()
        {
            objectCount = history.Count;
            lastAction = "Вперед";
            UpdateStatus();
        }
        private void SortByNumOfRooms()
        {
            var sortedList = history.OrderBy(kv => kv.NumOfRooms).ToList();
            UpdateListBox2(sortedList);
        }
        private void SortByFloor()
        {
            var sortedList = history.OrderBy(kv => kv.Floor).ToList();
            UpdateListBox2(sortedList);
        }
        private void SortByCountry()
        {
            var sortedList = history.OrderBy(kv => kv.Country).ToList();
            UpdateListBox2(sortedList);
        }
        private void UpdateListBox2(List<Kvartira> sortedList)
        {
            listBox1.Items.Clear();
            foreach (var kv in sortedList)
            {
                listBox1.Items.Add($"{kv.City}, {kv.Country} — {kv.NumOfRooms} комн., {kv.Metraz} м²");
            }
        }
        private void SortByMetraz()
        {
            var sortedList = history
                .OrderBy(kv => ExtractMinMetraz(kv.Metraz))
                .ToList();

            UpdateListBox2(sortedList);
        }
        private double ExtractMinMetraz(string metraz)
        {
            if (string.IsNullOrWhiteSpace(metraz)) return double.MaxValue;

            var match = Regex.Match(metraz, @"^(\d+)-");
            if (match.Success && double.TryParse(match.Groups[1].Value, out double minMetraz))
            {
                return minMetraz;
            }

            return double.MaxValue;
        }
        private double ExtractMaxMetraz(string metraz)
        {
            if (string.IsNullOrWhiteSpace(metraz)) return double.MinValue;

            var match = Regex.Match(metraz, @"-(\d+)");
            if (match.Success && double.TryParse(match.Groups[1].Value, out double maxMetraz))
            {
                return maxMetraz;
            }

            return double.MinValue;
        }

        private void SaveState()
        {
            Kvartira currentKvartira = new Kvartira
            {
                Metraz = Metraz.Text,
                NumOfRooms = int.Parse(NumOfRooms.Text),
                Kitchen = Kitchen.Checked,
                San = San.Checked,
                Bathroom = Bathroom.Checked,
                Wardrobe = Wardrobe.Checked,
                Basement = Basement.Checked,
                Studio = Studio.Checked,
                Parking = Parking.Checked,
                ClosedBalcony = ClosedBalcony.Checked,
                OpenedBalcony = OpenedBalcony.Checked,
                //YearOfBuilt = YearOfBuilt.Text,
                Panel = Panel.Checked ? "Panel" : null,
                Brick = Brick.Checked ? "Brick" : null,
                Floor = int.Parse(Floor.Text),
                Country = Country.Text,
                City = City.Text,
                District = District.Text,
                Street = Street.Text,
                House = House.Text,
                Corp = Corp.Text,
                Apart = Apart.Text
            };
            if (currentStateIndex < history.Count - 1)
            {
                history.RemoveRange(currentStateIndex + 1, history.Count - currentStateIndex - 1);
            }

            history.Add(currentKvartira);
            currentStateIndex = history.Count - 1;
            maxStateIndex = currentStateIndex;

            listBox1.Items.Add($"{currentKvartira.City}, {currentKvartira.Country} — {currentKvartira.NumOfRooms} комн., {currentKvartira.Metraz} м²");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            cost();
            Kvartira currentKvartira = new Kvartira
            {
                Metraz = Metraz.Text,
                NumOfRooms = int.TryParse(NumOfRooms.Text, out int rooms) ? rooms : 0,
                Kitchen = Kitchen.Checked,
                San = San.Checked,
                Bathroom = Bathroom.Checked,
                Wardrobe = Wardrobe.Checked,
                Basement = Basement.Checked,
                Studio = Studio.Checked,
                Parking = Parking.Checked,
                ClosedBalcony = ClosedBalcony.Checked,
                OpenedBalcony = OpenedBalcony.Checked,
                Floor = int.TryParse(Floor.Text, out int floor) ? floor : 0,
                Country = Country.Text,
                City = City.Text,
                Street = Street.Text,
                House = House.Text,
                Corp = Corp.Text,
                Apart = Apart.Text
            };
            if (!Valid())
            {
                if (!ValidateKvartira(currentKvartira, out List<string> errors))
                {
                    MessageBox.Show(string.Join("\n", errors), "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            string selectedMetraz = Metraz.SelectedItem.ToString();
            double minArea = ExtractMinMetraz(selectedMetraz);
            double maxArea = ExtractMaxMetraz(selectedMetraz);

            if (rooms == 4 && minArea >= 25 && maxArea <= 75)
            {
                MessageBox.Show("Выбранная площадь слишком мала для указанного количества комнат!",
                                "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (rooms == 3 && minArea >= 25 && maxArea <= 60)
            {
                MessageBox.Show("Выбранная площадь слишком мала для указанного количества комнат!",
                                "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (rooms == 3 && minArea >= 77 && maxArea <= 95)
            {
                MessageBox.Show("Выбранная площадь слишком велика для указанного количества комнат!",
                                "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (rooms == 2 && minArea >= 25 && maxArea <= 40)
            {
                MessageBox.Show("Выбранная площадь слишком мала для указанного количества комнат!",
                                "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (rooms == 2 && minArea >= 65 && maxArea <= 95)
            {
                MessageBox.Show("Выбранная площадь слишком велика для указанного количества комнат!",
                                "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (rooms == 1 && minArea >= 42 && maxArea <= 95)
            {
                MessageBox.Show("Выбранная площадь слишком мала для указанного количества комнат!",
                                "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            SaveState();
            toFile(history[currentStateIndex]);
        }

        private void LoadState(Kvartira kvartira)
        {
            Metraz.Text = kvartira.Metraz;
            NumOfRooms.Text = kvartira.NumOfRooms.ToString();
            Kitchen.Checked = kvartira.Kitchen;
            San.Checked = kvartira.San;
            Bathroom.Checked = kvartira.Bathroom;
            Wardrobe.Checked = kvartira.Wardrobe;
            Basement.Checked = kvartira.Basement;
            Studio.Checked = kvartira.Studio;
            Parking.Checked = kvartira.Parking;
            ClosedBalcony.Checked = kvartira.ClosedBalcony;
            OpenedBalcony.Checked = kvartira.OpenedBalcony;
            //YearOfBuilt.Text = kvartira.YearOfBuilt;
            Panel.Checked = kvartira.Panel == "Panel";
            Brick.Checked = kvartira.Brick == "Brick";
            Floor.Text = kvartira.Floor.ToString();
            Country.Text = kvartira.Country;
            City.Text = kvartira.City;
            District.Text = kvartira.District;
            Street.Text = kvartira.Street;
            House.Text = kvartira.House;
            Corp.Text = kvartira.Corp;
            Apart.Text = kvartira.Apart;
        }
        private void Undo()
        {
            if (history.Count == 0 || currentStateIndex < 0)
            {
                MessageBox.Show("Нет действий для отмены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentStateIndex > 0)
            {
                currentStateIndex--;
                LoadState(history[currentStateIndex]);
                UpdateListBox();
            }
            else
            {
                MessageBox.Show("Нельзя отменить дальше!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Redo()
        {
            if (currentStateIndex < history.Count - 1)
            {
                currentStateIndex++;
                LoadState(history[currentStateIndex]);
                UpdateListBox();
            }
            else
            {
                MessageBox.Show("Нет последующих изменений!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void UpdateListBox()
        {
            listBox1.Items.Clear();

            // Добавляем только элементы до текущего состояния
            for (int i = 0; i <= currentStateIndex; i++)
            {
                var kv = history[i];
                listBox1.Items.Add($"{kv.City}, {kv.Country} — {kv.NumOfRooms} комн., {kv.Metraz} м²");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            outt();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kvartira.json");
            string json = File.ReadAllText(filePath);
            Kvartira kvartira = JsonSerializer.Deserialize<Kvartira>(json);


            textBox1.Text = $"Метраж: {kvartira.Metraz}\r\n" +
                             $"Количество комнат: {kvartira.NumOfRooms}\r\n" +
                             $"Кухня: {(kvartira.Kitchen ? "Есть" : "Нет")}\r\n" +
                             $"Санузел: {(kvartira.San ? "Есть" : "Нет")}\r\n" +
                             $"Ванная: {(kvartira.Bathroom ? "Есть" : "Нет")}\r\n" +
                             $"Гардероб: {(kvartira.Wardrobe ? "Есть" : "Нет")}\r\n" +
                             $"Подвал: {(kvartira.Basement ? "Есть" : "Нет")}\r\n" +
                             $"Студия: {(kvartira.Studio ? "Да" : "Нет")}\r\n" +
                             $"Парковка: {(kvartira.Parking ? "Да" : "Нет")}\r\n" +
                             $"Закрытый балкон: {(kvartira.ClosedBalcony ? "Да" : "Нет")}\r\n" +
                             $"Открытый балкон: {(kvartira.OpenedBalcony ? "Да" : "Нет")}\r\n" +
                             //$"Год постройки: {kvartira.YearOfBuilt}\r\n" +
                             $"Материал стен: {(kvartira.Panel == "Panel" ? "Панель" : kvartira.Brick == "Brick" ? "Кирпич" : "Не указан")}\r\n" +
                             $"Этаж: {kvartira.Floor}\r\n" +
                             $"Страна: {kvartira.Country}\r\n" +
                             $"Город: {kvartira.City}\r\n" +
                             $"Район: {kvartira.District}\r\n" +
                             $"Улица: {kvartira.Street}\r\n" +
                             $"Дом: {kvartira.House}\r\n" +
                             $"Корпус: {kvartira.Corp}\r\n" +
                             $"Квартира: {kvartira.Apart}";

            Metraz.Text = kvartira.Metraz;
            NumOfRooms.Text = kvartira.NumOfRooms.ToString();
            Kitchen.Checked = kvartira.Kitchen;
            San.Checked = kvartira.San;
            Bathroom.Checked = kvartira.Bathroom;
            Wardrobe.Checked = kvartira.Wardrobe;
            Basement.Checked = kvartira.Basement;
            Studio.Checked = kvartira.Studio;
            Parking.Checked = kvartira.Parking;
            ClosedBalcony.Checked = kvartira.ClosedBalcony;
            OpenedBalcony.Checked = Kitchen.Checked;
            //YearOfBuilt.Text = kvartira.YearOfBuilt;
            Panel.Checked = kvartira.Panel == "Panel";
            Brick.Checked = kvartira.Brick == "Brick";
            Floor.Text = kvartira.Floor.ToString();
            Country.Text = kvartira.Country;
            City.Text = kvartira.City;
            District.Text = kvartira.District;
            Street.Text = kvartira.Street;
            House.Text = kvartira.House;
            Corp.Text = kvartira.Corp;
            Apart.Text = kvartira.Apart;
        }

        private bool Valid()
        {
            if (string.IsNullOrWhiteSpace(Metraz.Text) || string.IsNullOrWhiteSpace(NumOfRooms.Text) || string.IsNullOrWhiteSpace(Country.Text) || string.IsNullOrWhiteSpace(City.Text) || string.IsNullOrWhiteSpace(Floor.Text) || (!Panel.Checked && !Brick.Checked))
            {
                return false;
            }
            return true;
        }

        private void toFile(Kvartira kvartira)
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kvartira.json");
                string json = JsonSerializer.Serialize(kvartira, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
                MessageBox.Show($"Данные сохранены в файл: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }
        private void ClearListBox()
        {
            listBox1.Items.Clear();
        }
        private void ClearJsonFile()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kvartira.json");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                MessageBox.Show("Файл JSON успешно очищен.");
            }
            else
            {
                MessageBox.Show("Файл JSON отсутствует, очистка не требуется.");
            }
        }
        private void FilterList(string searchText)
        {
            var filteredItems = allItems
                .Where(item => item.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            listBox2.Items.Clear();
            listBox2.Items.AddRange(filteredItems.ToArray());
        }
        private void FilterByCriteria()
        {
            int.TryParse(Metraz.Text, out int metraz);
            int.TryParse(NumOfRooms.Text, out int numOfRooms);
            int.TryParse(Floor.Text, out int floor);
            string country = Country.Text.Trim();
            string city = City.Text.Trim();
            bool isPanel = Panel.Checked;
            bool isBrick = Brick.Checked;

            var filteredList = history.Where(kv =>
                (metraz == 0 || kv.Metraz == Metraz.Text) &&
                (numOfRooms == 0 || kv.NumOfRooms == numOfRooms) &&
                (floor == 0 || kv.Floor == floor) &&
                (string.IsNullOrEmpty(country) || kv.Country.Equals(country, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(city) || kv.City.Equals(city, StringComparison.OrdinalIgnoreCase)) &&
                (!isPanel || kv.Panel == "Panel") &&
                (!isBrick || kv.Brick == "Brick")
            ).ToList();

            listBox2.Items.Clear();
            if (filteredList.Count > 0)
            {
                foreach (var kv in filteredList)
                {
                    listBox2.Items.Add($"{kv.City}, {kv.Country} — {kv.NumOfRooms} комн., {kv.Metraz} м²");
                }
            }
            else
            {
                listBox2.Items.Add("Совпадений не найдено");
            }
        }
        private void SearchByText(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                listBox3.Items.Clear();
                listBox3.Items.Add("Введите текст для поиска...");
                return;
            }

            searchText = searchText.ToLower();

            var filteredList = history
                .Where(kv => kv.City.ToLower().Contains(searchText) ||
                             kv.Street.ToLower().Contains(searchText) ||
                             kv.House.ToLower().Contains(searchText) ||
                             kv.NumOfRooms.ToString().Contains(searchText) ||
                             kv.Metraz.ToLower().Contains(searchText) ||
                             kv.Country.ToLower().Contains(searchText))
                .ToList();

            listBox3.Items.Clear();
            if (filteredList.Count > 0)
            {
                foreach (var kv in filteredList)
                {
                    listBox3.Items.Add($"{kv.City}, {kv.Country} — {kv.NumOfRooms} комн., {kv.Metraz} м²");
                }
            }
            else
            {
                listBox3.Items.Add("Совпадений не найдено");
            }
        }
        private void ClearAllFields()
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            numericUpDown1.Value = numericUpDown1.Minimum;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = $"Время: {DateTime.Now.ToString("G")}";

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            search();
            tabControl1.SelectedTab = tabPage3;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            back();
            Undo();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            forward();
            Redo();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (history.Count > 0)
            {
                SaveState();
            }
            listBox1.Items.Clear();
            listBox4.Items.Clear();
            clear();
            ClearListBox();
            wasCleared = true;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox4.Items.Clear();
            history.Clear();
            delete();
            ClearJsonFile();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //SearchByText(textBox3.Text);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            allItems = listBox1.Items.Cast<string>().ToList();
            listBox2.Items.AddRange(allItems.ToArray());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox3 is null)
            {
                MessageBox.Show("Введите значение в поле!");
            }
            string searchText = textBox3.Text;
            SearchByText(searchText);
            searchString();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кулешов Артём Алексеевич", "Версия 1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void поМетражуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortByMetraz();
        }

        private void поПлощадиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            SortByNumOfRooms();
        }

        private void поЭатжуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortByFloor();
        }

        private void поСтранеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortByCountry();
        }

        private void Metraz_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        bool isHidden = false;
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (!isHidden)
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton3.Visible = false;
                toolStripButton4.Visible = false;
                toolStripButton5.Visible = false;
                toolStripButton6.Visible = false;
                isHidden = true;
                toolStripButton7.Image = Image.FromFile("D:\\уник\\4 сем\\ООП\\lab03\\images\\123.png");
            }
            else
            {
                toolStripButton1.Visible = true;
                toolStripButton2.Visible = true;
                toolStripButton3.Visible = true;
                toolStripButton4.Visible = true;
                toolStripButton5.Visible = true;
                toolStripButton6.Visible = true;
                isHidden = false;
                toolStripButton7.Image = Image.FromFile("D:\\уник\\4 сем\\ООП\\lab03\\images\\43731.png");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SortByMetraz();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FilterByCriteria();
            searchKriteria();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }
    }
}

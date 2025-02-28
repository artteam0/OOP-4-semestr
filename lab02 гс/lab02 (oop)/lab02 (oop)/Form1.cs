using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace lab02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Kvartira
        {
            public string Metraz { get; set; }
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
            public string YearOfBuilt { get; set; }
            public string Panel { get; set; }
            public string Brick { get; set; }
            public int Floor { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string District { get; set; }
            public string Street { get; set; }
            public string House { get; set; }
            public string Corp { get; set; }
            public string Apart { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!Valid())
            {
                MessageBox.Show("Заполните все обязательные поля");
                return;
            }

            Kvartira kvartira = new Kvartira
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
                YearOfBuilt = YearOfBuilt.Text,
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
            toFile(kvartira);
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                             $"Год постройки: {kvartira.YearOfBuilt}\r\n" +
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
            if (string.IsNullOrWhiteSpace(Metraz.Text) || string.IsNullOrWhiteSpace(NumOfRooms.Text) || string.IsNullOrWhiteSpace(Country.Text) || string.IsNullOrWhiteSpace(City.Text) || string.IsNullOrWhiteSpace(YearOfBuilt.Text) || string.IsNullOrWhiteSpace(Floor.Text) || (!Panel.Checked && !Brick.Checked))
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}

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
                MessageBox.Show("��������� ��� ������������ ����");
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


            textBox1.Text = $"������: {kvartira.Metraz}\r\n" +
                             $"���������� ������: {kvartira.NumOfRooms}\r\n" +
                             $"�����: {(kvartira.Kitchen ? "����" : "���")}\r\n" +
                             $"�������: {(kvartira.San ? "����" : "���")}\r\n" +
                             $"������: {(kvartira.Bathroom ? "����" : "���")}\r\n" +
                             $"��������: {(kvartira.Wardrobe ? "����" : "���")}\r\n" +
                             $"������: {(kvartira.Basement ? "����" : "���")}\r\n" +
                             $"������: {(kvartira.Studio ? "��" : "���")}\r\n" +
                             $"��������: {(kvartira.Parking ? "��" : "���")}\r\n" +
                             $"�������� ������: {(kvartira.ClosedBalcony ? "��" : "���")}\r\n" +
                             $"�������� ������: {(kvartira.OpenedBalcony ? "��" : "���")}\r\n" +
                             $"��� ���������: {kvartira.YearOfBuilt}\r\n" +
                             $"�������� ����: {(kvartira.Panel == "Panel" ? "������" : kvartira.Brick == "Brick" ? "������" : "�� ������")}\r\n" +
                             $"����: {kvartira.Floor}\r\n" +
                             $"������: {kvartira.Country}\r\n" +
                             $"�����: {kvartira.City}\r\n" +
                             $"�����: {kvartira.District}\r\n" +
                             $"�����: {kvartira.Street}\r\n" +
                             $"���: {kvartira.House}\r\n" +
                             $"������: {kvartira.Corp}\r\n" +
                             $"��������: {kvartira.Apart}";

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
                MessageBox.Show($"������ ��������� � ����: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� ������: {ex.Message}");
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

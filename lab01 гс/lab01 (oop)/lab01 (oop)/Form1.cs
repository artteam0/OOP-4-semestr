namespace lab01__oop_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += button1_Click;
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show("Привет");
                string name = nameTextBox.Text;
                decimal cost = 0;
                decimal volume = 0;
                decimal markup = 0;
                decimal everyday = 0;
                string combo = comboBox.Text;
                if (name == null || name.Length == 0) 
                {
                    throw new Exception("Введите название товара");
                    //MessageBox.Show("Введите название товара");
                }
                else
                {
                    name = nameTextBox.Text;
                    cost = decimal.Parse(costTextBox.Text);
                    if (cost <= 0)
                    {
                        throw new Exception("Стоимость не может быть отрицательна");
                        //MessageBox.Show("Стоимость не может быть отрицательна");
                    }
                    else
                    {
                        volume = decimal.Parse(volumeTextBox.Text);
                        if (volume <= 0)
                        {
                            throw new Exception("Объём не может быть отрицателен");
                            //MessageBox.Show("Объём не может быть отрицателен");
                        }
                        else
                        {
                            markup = decimal.Parse(markupTextBox.Text);
                            if (markup <= 0)
                            {
                                throw new Exception("Наценка не может быть отрицательна");
                                //MessageBox.Show("Наценка не может быть отрицательна");
                            }
                            else
                            {
                                everyday = decimal.Parse(everydayTextBox.Text);
                                if (everyday < 0)
                                {
                                    throw new Exception("Количество продаж не может быть отрицательным");
                                    //MessageBox.Show("Количество продаж не может быть отрицательным");
                                }
                                else
                                {
                                    combo = comboBox.Text;

                                    if (combo.Length == 0) 
                                    {
                                        throw new Exception("Выберите хотя бы один вариант");
                                    }
                                    else
                                    {
                                        {
                                            decimal selfCost = cost - markup;
                                            decimal costPer = cost / volume;
                                            decimal month = selfCost * everyday * 28;

                                            name2TextBox.Text = name;
                                            selfCostTextBox.Text = $"{selfCost}"; //selfCost
                                            resLabel.Text = $"Стоимость за 1 {comboBox.SelectedItem}";
                                            costPerTextBox.Text = $"{costPer}";
                                            monthTextBox.Text = $"{month}";
                                        }
                                    }
                                    
                                }
                            }
                        } 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace ConferenceHallAPI
{

        public partial class CreateHall : Form
    {
        
        public CreateHall()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CreateHall_Load(object sender, EventArgs e)
        {
            LoadServices();
        }
        private void LoadServices() // Завантаження даних у таблицю
        {
            DataTable table = new DataTable();

            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();

                string sql = "SELECT Id, Name, Price FROM Services";
                using (var command = new SqliteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            AvaliableServices.DataSource = table;

            // Дозволяємо редагування
            // Дозволяємо редагування
            AvaliableServices.ReadOnly = false;
            


            // Назви колонок
            AvaliableServices.Columns["Id"].HeaderText = "№";
            AvaliableServices.Columns["Name"].HeaderText = "Послуга";
            AvaliableServices.Columns["Price"].HeaderText = "Ціна, грн";
            // Створюємо Checkbox
            DataGridViewCheckBoxColumn checkBoxColumn =  new DataGridViewCheckBoxColumn();

            checkBoxColumn.Name = "SelectColumn";
            checkBoxColumn.HeaderText = "Включити?";
            checkBoxColumn.Width = 70;
            checkBoxColumn.ReadOnly = false;
            AvaliableServices.Columns.Add(checkBoxColumn);
            // Ширина колонок
            AvaliableServices.AutoSizeColumnsMode =  DataGridViewAutoSizeColumnsMode.Fill;
        }
        //Створення зали  
        private void HallCreate_Click(object sender, EventArgs e)
        {
         string  Hall_Name = HallNameTextBox.Text;
         double People_Amount = Convert.ToDouble(HallSizeCount.Value);
         decimal Base_Rent = RentBase.Value;
            string Projector = null;
            string WiFi = null;
            string Sounds = null;
        foreach (DataGridViewRow row in AvaliableServices.Rows)
            {
                if (Convert.ToBoolean(row.Cells["SelectColumn"].Value))
                {
                    string name = row.Cells["Name"].Value.ToString();
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

                    Console.WriteLine($"{name} - {price} грн");

                    switch (name) {
                        case "Проєктор":
                            Projector = name;
                            break;
                        case "Wi - Fi":
                            WiFi = name;
                            break;
                        case "Звук":
                            Sounds = name;
                            break;
                    }
                }
            }
            Database.AddHall(Hall_Name, People_Amount, Base_Rent, Projector, WiFi, Sounds);
            MessageBox.Show("Залу створено");
            HallNameTextBox.Clear();
            HallSizeCount.Value = 0;
            RentBase.Value = 0;
        }

        private void HallEditMove_Click(object sender, EventArgs e)
        {
            RedactHall Editorial = new RedactHall();
            Editorial.Show();
            this.Hide();
        }

        private void RentMove_Click(object sender, EventArgs e)
        {
            SelectHall RentSelector = new SelectHall();
            RentSelector.Show();
            this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace ConferenceHallAPI
{
    public partial class SelectHall : Form
    {
            public SelectHall()
        {
            InitializeComponent();
        }

        private void LoadNames()
        {
            HallComboBox.Items.Clear();
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();

                string sql = "SELECT ID, Hall_Name FROM Hall";
                using (var command = new SqliteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HallComboBox.Items.Add(reader["Hall_Name"].ToString());
                    }
                }
            }
            // Очищення combobox після видалення зали
            HallComboBox.SelectedIndex = -1;
        }
        //Завантаження даних у ComboBox
        private void LoadHalls()
        {
            HallComboBox.Items.Clear();

            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();

                string sql = "SELECT Hall_Name FROM Hall";

                using (var command = new SqliteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HallComboBox.Items.Add(reader["Hall_Name"].ToString());
                    }
                }
            }

            HallComboBox.SelectedIndex = -1;
        }
        //Змінення даних таблиці при виборі варіанта у ComboBox
        private void HallComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        //Функція завантаження даних у DataGridView
        private void LoadHallData(string hallName)
        {
            DataTable table = new DataTable();

            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();

                string sql = "SELECT Id, Hall_Name, Size, Base_Price, Projector, WiFi, Sound FROM Hall WHERE Hall_Name = $hallName";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("$hallName", hallName);

                    using (var reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
            }

            HallSelectTable.Columns.Clear();
            HallSelectTable.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Id";
            idColumn.HeaderText = "№ зали";
            idColumn.DataPropertyName = "Id";
            HallSelectTable.Columns.Add(idColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Hall_Name";
            nameColumn.HeaderText = "Назва зали";
            nameColumn.DataPropertyName = "Hall_Name";
            HallSelectTable.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn sizeColumn = new DataGridViewTextBoxColumn();
            sizeColumn.Name = "Size";
            sizeColumn.HeaderText = "Місткість, осіб";
            sizeColumn.DataPropertyName = "Size";
            HallSelectTable.Columns.Add(sizeColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.Name = "Base_Price";
            priceColumn.HeaderText = "Ціна, грн";
            priceColumn.DataPropertyName = "Base_Price";
            HallSelectTable.Columns.Add(priceColumn);

            if (Convert.ToInt32(table.Rows[0]["Projector"]) == 1)
            {
                DataGridViewCheckBoxColumn projectorColumn = new DataGridViewCheckBoxColumn();
                projectorColumn.Name = "Projector";
                projectorColumn.HeaderText = "Проєктор";
                projectorColumn.DataPropertyName = "Projector";
                projectorColumn.TrueValue = 1;
                projectorColumn.FalseValue = 0;
                HallSelectTable.Columns.Add(projectorColumn);
            }

            if (Convert.ToInt32(table.Rows[0]["WiFi"]) == 1)
            {
                DataGridViewCheckBoxColumn wifiColumn = new DataGridViewCheckBoxColumn();
                wifiColumn.Name = "WiFi";
                wifiColumn.HeaderText = "Wi-Fi";
                wifiColumn.DataPropertyName = "WiFi";
                wifiColumn.TrueValue = 1;
                wifiColumn.FalseValue = 0;
                HallSelectTable.Columns.Add(wifiColumn);
            }

            if (Convert.ToInt32(table.Rows[0]["Sound"]) == 1)
            {
                DataGridViewCheckBoxColumn soundColumn = new DataGridViewCheckBoxColumn();
                soundColumn.Name = "Sound";
                soundColumn.HeaderText = "Звук";
                soundColumn.DataPropertyName = "Sound";
                soundColumn.TrueValue = 1;
                soundColumn.FalseValue = 0;
                HallSelectTable.Columns.Add(soundColumn);
            }

            HallSelectTable.DataSource = table;
            HallSelectTable.ReadOnly = false;
            HallSelectTable.ClearSelection();
            UpdatePriceLabel();
        }
        //Завантаження даних у combobox при запуску форми
        private void SelectHall_Load(object sender, EventArgs e)
        {
            LoadHalls();
        }
        //Запуск програми розрахунку вартості оренди та внесення інформації у базу даних
        private void button1_Click(object sender, EventArgs e)
        {
            if (HallSelectTable.Rows.Count == 0)
            {
                MessageBox.Show("Спочатку виберіть залу.");
                return;
            }

            DataGridViewRow row = HallSelectTable.Rows[0];

            int id = Convert.ToInt32(row.Cells["Id"].Value);

            string rensStartTable = RentDateTimeStart.Value.ToString("yyyy-MM-dd HH:mm");
            string rensEndTable = RentDateTimeEnd.Value.ToString("yyyy-MM-dd HH:mm");

            bool projector = false;
            bool wifi = false;
            bool sound = false;

            if (HallSelectTable.Columns.Contains("Projector"))
                projector = Convert.ToBoolean(row.Cells["Projector"].Value);

            if (HallSelectTable.Columns.Contains("WiFi"))
                wifi = Convert.ToBoolean(row.Cells["WiFi"].Value);

            if (HallSelectTable.Columns.Contains("Sound"))
                sound = Convert.ToBoolean(row.Cells["Sound"].Value);

            decimal totalPrice = RentPrecalculation(Convert.ToDecimal(row.Cells["Base_Price"].Value), RentDateTimeStart.Value, RentDateTimeEnd.Value, projector, wifi, sound);

            make_rent(id, rensStartTable, rensEndTable, projector, wifi, sound, totalPrice);

            MessageBox.Show("Оренду успішно додано.");
        }

        private decimal RentPrecalculation(decimal basePrice, DateTime startRent, DateTime endRent, bool projector, bool wifi, bool sound)
        {
            decimal totalPrice = 0;

            if (endRent <= startRent)
                return 0;

            DateTime currentTime = startRent;

            while (currentTime < endRent)
            {
                DateTime nextHour = currentTime.AddHours(1);

                if (nextHour > endRent)
                    nextHour = endRent;

                decimal multiplier = 1.0m;

                TimeSpan time = currentTime.TimeOfDay;

                if (time >= new TimeSpan(6, 0, 0) && time < new TimeSpan(9, 0, 0))
                {
                    multiplier = 0.90m;
                }
                else if (time >= new TimeSpan(12, 0, 0) && time < new TimeSpan(14, 0, 0))
                {
                    multiplier = 1.15m;
                }
                else if (time >= new TimeSpan(18, 0, 0) && time < new TimeSpan(23, 0, 0))
                {
                    multiplier = 0.80m;
                }

                decimal hours = (decimal)(nextHour - currentTime).TotalHours;
                totalPrice += basePrice * multiplier * hours;

                currentTime = nextHour;
            }

            if (projector)
                totalPrice += 500;

            if (wifi)
                totalPrice += 300;

            if (sound)
                totalPrice += 700;

            return totalPrice;
        }

        private void UpdatePriceLabel()
        {
            if (HallSelectTable.Rows.Count == 0)
            {
                PriceLabel.Text = "0.00 грн";
                return;
            }

            if (HallSelectTable.Rows[0].Cells["Base_Price"].Value == null)
            {
                PriceLabel.Text = "0.00 грн";
                return;
            }

            decimal basePrice = Convert.ToDecimal(HallSelectTable.Rows[0].Cells["Base_Price"].Value);

            bool projector = false;
            bool wifi = false;
            bool sound = false;

            if (HallSelectTable.Columns.Contains("Projector"))
                projector = Convert.ToBoolean(HallSelectTable.Rows[0].Cells["Projector"].Value);

            if (HallSelectTable.Columns.Contains("WiFi"))
                wifi = Convert.ToBoolean(HallSelectTable.Rows[0].Cells["WiFi"].Value);

            if (HallSelectTable.Columns.Contains("Sound"))
                sound = Convert.ToBoolean(HallSelectTable.Rows[0].Cells["Sound"].Value);

            decimal totalPrice = RentPrecalculation(basePrice, RentDateTimeStart.Value, RentDateTimeEnd.Value, projector, wifi, sound);

            PriceLabel.Text = totalPrice.ToString("0.00") + " грн";
        }

        private void RentDateTimeStart_ValueChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }

        private void RentDateTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
        }
        private void HallSelectTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;

            if (HallSelectTable.Columns[e.ColumnIndex].Name == "Projector" || HallSelectTable.Columns[e.ColumnIndex].Name == "WiFi" || HallSelectTable.Columns[e.ColumnIndex].Name == "Sound")
            {
                UpdatePriceLabel();
            }
        }
        private void HallSelectTable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (HallSelectTable.IsCurrentCellDirty)
                HallSelectTable.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        //Розрахунок вартості оренди
        //private decimal CalculateRentPrice(int id,decimal basePrice, DateTime rentStart, DateTime rentEnd, bool projector, bool wifi, bool sound)
        //{
        //    decimal totalPrice = 0;

        //}
        // Внесення даних про орендовану залу до таблиці
        private void make_rent(int id, string rensStartTable, string rensEndTable, bool projector, bool wifi, bool sound, decimal totalPrice)
        {
            Database.AddRentedHalls(id, rensStartTable, rensEndTable, projector, wifi, sound, totalPrice);
        }
                // Перехід на інші форми
        private void CreateHallButton_Click(object sender, EventArgs e)
        {
            CreateHall creation = new CreateHall();
            creation.Show();
            this.Hide();
        }

        private void EditHallButton_Click(object sender, EventArgs e)
        {
            RedactHall Editorial = new RedactHall();
            Editorial.Show();
            this.Hide();
        }

        private void ExistRent_Click(object sender, EventArgs e)
        {
            SeeRent review = new SeeRent();
            review.Show();
            this.Hide();
        }

        private void HallComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (HallComboBox.SelectedIndex == -1)
                return;

            string hallName = HallComboBox.SelectedItem.ToString();

            LoadHallData(hallName);
        }

        
    }
}

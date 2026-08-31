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
    public partial class RedactHall : Form
    {
        public RedactHall()
        {
            InitializeComponent();
        }

        private void RedactHall_Load(object sender, EventArgs e)
        {
                        LoadNames();
        }
        //Завантаження назв зал у ComboBox
        private void LoadNames()
        {
            HallSelectorComboBox.Items.Clear();
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();

                string sql = "SELECT ID, Hall_Name FROM Hall";
                using (var command = new SqliteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HallSelectorComboBox.Items.Add(reader["Hall_Name"].ToString());
                    }
                }
            }
            // Очищення combobox після видалення зали
            HallSelectorComboBox.SelectedIndex = -1;
        }
               
        private void HallSelectorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HallSelectorComboBox.SelectedItem != null)
            {
                LoadHallData(HallSelectorComboBox.SelectedItem.ToString());
            }
        }

        private void LoadHallData(string hallName)
        {
            DataTable table = new DataTable();

            using (var connection =  new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();

                string sql = "SELECT Id, Hall_Name, Size, Base_Price, Projector, WiFi, Sound FROM Hall WHERE Hall_Name = $hallName";
        
        using (var command =  new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("$hallName", hallName);

                    using (var reader = command.ExecuteReader())
                    {
                        table.Load(reader);
                    }
                }
            }
            HallEditTable.Columns.Clear();
            HallEditTable.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Id";
            idColumn.HeaderText = "№ зали";
            idColumn.DataPropertyName = "Id";
            HallEditTable.Columns.Add(idColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Hall_Name";
            nameColumn.HeaderText = "Назва зали";
            nameColumn.DataPropertyName = "Hall_Name";
            HallEditTable.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn sizeColumn = new DataGridViewTextBoxColumn();
            sizeColumn.Name = "Size";
            sizeColumn.HeaderText = "Розмір зали, к-сть осіб";
            sizeColumn.DataPropertyName = "Size";
            HallEditTable.Columns.Add(sizeColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.Name = "Base_Price";
            priceColumn.HeaderText = "Ціна, грн";
            priceColumn.DataPropertyName = "Base_Price";
            HallEditTable.Columns.Add(priceColumn);

            DataGridViewCheckBoxColumn projectorColumn = new DataGridViewCheckBoxColumn();
            projectorColumn.Name = "Projector";
            projectorColumn.HeaderText = "Проєктор";
            projectorColumn.DataPropertyName = "Projector";
            projectorColumn.TrueValue = 1;
            projectorColumn.FalseValue = 0;
            HallEditTable.Columns.Add(projectorColumn);

            DataGridViewCheckBoxColumn wifiColumn = new DataGridViewCheckBoxColumn();
            wifiColumn.Name = "WiFi";
            wifiColumn.HeaderText = "Wi-Fi";
            wifiColumn.DataPropertyName = "WiFi";
            wifiColumn.TrueValue = 1;
            wifiColumn.FalseValue = 0;
            HallEditTable.Columns.Add(wifiColumn);

            DataGridViewCheckBoxColumn soundColumn = new DataGridViewCheckBoxColumn();
            soundColumn.Name = "Sound";
            soundColumn.HeaderText = "Звук";
            soundColumn.DataPropertyName = "Sound";
            soundColumn.TrueValue = 1;
            soundColumn.FalseValue = 0;
            HallEditTable.Columns.Add(soundColumn);

            HallEditTable.DataSource = table;
        }
       private void HallCreateMove_Click(object sender, EventArgs e)
        {
            CreateHall creation = new CreateHall();
            creation.Show();
            this.Hide();
        }
        //Збереження змін зали
        private void EditSave_Click(object sender, EventArgs e)
        {
            
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();

                foreach (DataGridViewRow row in HallEditTable.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    string name = row.Cells["Hall_Name"].Value.ToString();
                    double size = Convert.ToDouble(row.Cells["Size"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["Base_Price"].Value);
                    int projector = Convert.ToBoolean(row.Cells["Projector"].Value) ? 1 : 0;
                    int wifi = Convert.ToBoolean(row.Cells["WiFi"].Value) ? 1 : 0;
                    int sound = Convert.ToBoolean(row.Cells["Sound"].Value) ? 1 : 0;

                    string sql = "UPDATE Hall SET Hall_Name = $name, Size = $size, Base_Price = $price, Projector = $projector, WiFi = $wifi, Sound = $sound WHERE Id = $id";

                    using (var command = new SqliteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("$name", name);
                        command.Parameters.AddWithValue("$size", size);
                        command.Parameters.AddWithValue("$price", price);
                        command.Parameters.AddWithValue("$projector", projector);
                        command.Parameters.AddWithValue("$wifi", wifi);
                        command.Parameters.AddWithValue("$sound", sound);
                        command.Parameters.AddWithValue("$id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Зміни успішно збережено!");
        }
        //Видалення зали
private void RemoveHall_Click(object sender, EventArgs e)
        {
            if (HallEditTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Натисніть на рядок зали у таблиці, і натисніть кнопку видалення ще раз.");
                return;
            }

            int hallId = Convert.ToInt32(HallEditTable.SelectedRows[0].Cells["Id"].Value);

            DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити вибрану залу?", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();

                string sql = "DELETE FROM Hall WHERE Id = $id";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("$id", hallId);
                    command.ExecuteNonQuery();
                }
            }
            HallEditTable.DataSource = null;
            LoadHallData(HallSelectorComboBox.SelectedItem.ToString());

            HallEditTable.ClearSelection();
            HallEditTable.Rows.Remove(HallEditTable.SelectedRows[0]);

            HallEditTable.ClearSelection();

            MessageBox.Show("Залу видалено.");
            LoadNames();
        }

        private void RentMakeButton_Click(object sender, EventArgs e)
        {
            SelectHall RentSelector = new SelectHall();
            RentSelector.Show();
            this.Hide();
        }
    }

        
    }


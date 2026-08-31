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
    public partial class SeeRent : Form
    {
        public SeeRent()
        {
            InitializeComponent();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            SelectHall RentSelector = new SelectHall();
            RentSelector.Show();
            this.Hide();
        }

        private void LoadRentedHalls()
        {
            DataTable table = new DataTable();

            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();

                string sql = "SELECT Rentals.Id, Hall.Hall_Name, Hall.Size, Rentals.RentStart, Rentals.RentEnd, Rentals.Projector, Rentals.WiFi, Rentals.Sound, Rentals.TotalPrice FROM Rentals INNER JOIN Hall ON Rentals.Hall_Id = Hall.Id";

                using (var command = new SqliteCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            ExistRentViewer.DataSource = table;

            ExistRentViewer.Columns["Id"].HeaderText = "№ оренди";
            ExistRentViewer.Columns["Hall_Name"].HeaderText = "Зала";
            ExistRentViewer.Columns["Size"].HeaderText = "Місткість";
            ExistRentViewer.Columns["RentStart"].HeaderText = "Початок оренди";
            ExistRentViewer.Columns["RentEnd"].HeaderText = "Кінець оренди";
            ExistRentViewer.Columns["Projector"].HeaderText = "Проєктор";
            ExistRentViewer.Columns["WiFi"].HeaderText = "Wi-Fi";
            ExistRentViewer.Columns["Sound"].HeaderText = "Звук";
            ExistRentViewer.Columns["TotalPrice"].HeaderText = "Загальна вартість";

            ExistRentViewer.Columns["Projector"].ValueType = typeof(bool);
            ExistRentViewer.Columns["WiFi"].ValueType = typeof(bool);
            ExistRentViewer.Columns["Sound"].ValueType = typeof(bool);

            ExistRentViewer.ReadOnly = true;
            ExistRentViewer.AllowUserToAddRows = false;
            ExistRentViewer.AllowUserToDeleteRows = false;
            ExistRentViewer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ExistRentViewer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    
        private void SeeRent_Load(object sender, EventArgs e)
        {
            LoadRentedHalls();
        }
    }
}

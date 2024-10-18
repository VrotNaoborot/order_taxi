using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering_taxi
{
    public partial class Change_type_transport : Form
    {
        public Change_type_transport()
        {
            InitializeComponent();
            load_type_transport();
        }
        public void load_type_transport()
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "SELECT `тип_транспорта`.`ID_типа_транспорта`, " +
               "`тип_транспорта`.`Название` " +
               "FROM `ordering_taxi`.`тип_транспорта`; ";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["ID_типа_транспорта"].Visible = false;
        }

        public object selected_id_type_transport;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selected_id_type_transport = dataGridView1.SelectedRows[0].Cells["ID_типа_транспорта"].Value;
                name.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Название"].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "UPDATE `тип_транспорта` SET " +
                "`Название`='" + name.Text + "' " +
                "WHERE `ID_типа_транспорта`=" + selected_id_type_transport + " ;";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlQuery, connection);
            try
            {
                mySqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить строку базу. Произошла ошибка: " + ex.Message,
                    "Неуспешное завершение действия", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return;
            }
            MessageBox.Show("Данные успешно изменены",
                    "Успешное завершение действия", MessageBoxButtons.OK, MessageBoxIcon.Information);

            load_type_transport();
        }
    }
}

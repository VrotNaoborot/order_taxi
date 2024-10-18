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
    public partial class Add_type_transport : Form
    {
        public Add_type_transport()
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

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "INSERT INTO тип_транспорта (Название) " +
                "VALUES (@Название);";

            MySqlCommand insertOrderCommand = new MySqlCommand(sqlQuery, connection);
            insertOrderCommand.Parameters.AddWithValue("@Название", name.Text);


            try
            {
                insertOrderCommand.ExecuteNonQuery();
                MessageBox.Show("Новые данные успешно добавлены в базу",
                "Успешное завершение действия", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить данные в базу. Произошла ошибка: " + ex.Message,
                "Неуспешное завершение действия", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                connection.Close();
                load_type_transport();
            }
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering_taxi
{
    public partial class Catalog : Form
    {
        public Catalog()
        {
            InitializeComponent();
            load_transport();
            load_type();
        }
        public void load_transport()
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "SELECT `транспорт`.`ID_транспорта`, " +
               "`транспорт`.`Марка`, " +
               "`транспорт`.`Модель`, " +
               "`транспорт`.`Тип`, " +
               "`транспорт`.`Год_выпуска`, " +
               "`транспорт`.`Государственный_номер`, " +
               "`транспорт`.`Длина_кузова`, " +
               "`транспорт`.`Высота_кузова`, " +
               "`транспорт`.`Ширина_кузова`, " +
               "`транспорт`.`Цена_за_км`, " +
               "`тип_транспорта`.`Название` " +
               "FROM `ordering_taxi`.`транспорт` " +
               "left join `тип_транспорта` on `транспорт`.`Тип`=`тип_транспорта`.`ID_типа_транспорта`";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["ID_транспорта"].Visible = false;
            dataGridView1.Columns["Тип"].Visible = false;
        }
        public void load_transport_for_type(int typeId)
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "SELECT `транспорт`.`ID_транспорта`, " +
               "`транспорт`.`Марка`, " +
               "`транспорт`.`Модель`, " +
               "`транспорт`.`Тип`, " +
               "`транспорт`.`Год_выпуска`, " +
               "`транспорт`.`Государственный_номер`, " +
               "`транспорт`.`Длина_кузова`, " +
               "`транспорт`.`Высота_кузова`, " +
               "`транспорт`.`Ширина_кузова`, " +
               "`транспорт`.`Цена_за_км`, " +
               "`тип_транспорта`.`Название` " +
               "FROM `ordering_taxi`.`транспорт` " +
               "left join `тип_транспорта` on `транспорт`.`Тип`=`тип_транспорта`.`ID_типа_транспорта` " +
               "WHERE `транспорт`.`Тип`= " + typeId + ";";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["ID_транспорта"].Visible = false;
            dataGridView1.Columns["Тип"].Visible = false;
        }

        public void load_type()
        {
            try
            {
                DbWorker db = new DbWorker();
                MySqlConnection conn = db.Connect();

                String query = "SELECT `тип_транспорта`.`ID_типа_транспорта`, `тип_транспорта`.`Название` FROM `ordering_taxi`.`тип_транспорта`;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Добавляем новый столбец для строкового идентификатора
                dt.Columns.Add("StringID", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    row["StringID"] = row["ID_типа_транспорта"].ToString();
                }

                // Добавляем строку для "Все рестораны"
                DataRow allCategories = dt.NewRow();
                allCategories["ID_типа_транспорта"] = DBNull.Value;
                allCategories["Название"] = "Без категории";
                allCategories["StringID"] = "All";
                dt.Rows.InsertAt(allCategories, 0);

                comboBox1.DisplayMember = "Название";
                comboBox1.ValueMember = "StringID";
                comboBox1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки категорий: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                string selectedValue = comboBox1.SelectedValue.ToString();
                if (selectedValue == "All")
                {
                    load_transport();
                }
                else
                {
                    int typeId = Convert.ToInt32(selectedValue);
                    load_transport_for_type(typeId);
                }
            }
        }

        private void AddOrder(int transportId, string dateFinish, decimal price)
        {
            try
            {
                DbWorker db = new DbWorker();
                MySqlConnection conn = db.Connect();

                string query = "INSERT INTO заказы (ID_пользователя, ID_транспорта, Дата_и_время_заказа, Дата_и_время_выполнения, Цена) VALUES (@ID_пользователя, @ID_транспорта, NOW(), @Дата_и_время_выполнения, @Цена);";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_пользователя", GlobalVariables.UserID);
                cmd.Parameters.AddWithValue("@ID_транспорта", transportId);
                cmd.Parameters.AddWithValue("@Дата_и_время_выполнения", dateFinish);
                cmd.Parameters.AddWithValue("@Цена", price);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Заказ успешно добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении заказа: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (count.Text.Length == 0)
                {
                    MessageBox.Show("Необходимо ввести количество киллометров для заказа.");
                    return;
                }
                int selectedIdTransport = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_транспорта"].Value);
                string dateFinish = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm");
                
                decimal priceOfCar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Цена_за_км"].Value);
                decimal countLong = Convert.ToDecimal(count.Text);

                decimal priceOrder = priceOfCar * countLong;
                DialogResult result = MessageBox.Show("Итоговая цена будет равна: " + priceOrder + ". Выпонлить заказ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    AddOrder(selectedIdTransport, dateFinish, priceOrder);
                    if (comboBox1.SelectedValue.ToString() == "All")
                    {
                        load_transport();
                    }
                    else
                    {
                        int categoryId = Convert.ToInt32(comboBox1.SelectedValue);
                        load_transport_for_type(categoryId);
                    }
                }

               
            }
            else
            {
                MessageBox.Show("Выберите курс для добавления в заказ.");
            }
        }

        private void моиЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserOrders userOrders = new UserOrders();
            userOrders.Show();
            this.Hide();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Hide();
        }
    }
}

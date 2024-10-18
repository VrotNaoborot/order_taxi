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
    public partial class Change_orders : Form
    {
        public Change_orders()
        {
            InitializeComponent();
            load_orders();
        }
        public void load_orders()
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "SELECT `заказы`.`ID_заказа`, " +
                "`заказы`.`ID_пользователя`, " +
                "`заказы`.`ID_транспорта`, " +
                "`заказы`.`Дата_и_время_заказа`, " +
                "`заказы`.`Дата_и_время_выполнения`,  " +
                "`заказы`.`Цена`, " +
                "`пользователи`.`Логин`, " +
                "`транспорт`.`Марка`, " +
                "`транспорт`.`Модель` " +
                "FROM `ordering_taxi`.`заказы` " +
                "left join `пользователи` on `заказы`.`ID_пользователя`=`пользователи`.`ID_пользователя` " +
                "left join `транспорт` on `заказы`.`ID_транспорта`=`заказы`.`ID_транспорта`";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["ID_заказа"].Visible = false;
            dataGridView1.Columns["ID_пользователя"].Visible = false;
            dataGridView1.Columns["ID_транспорта"].Visible = false;


            connection.Close();
        }
        public object detected_id_orders;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                detected_id_orders = dataGridView1.SelectedRows[0].Cells["ID_заказа"].Value;

                detected_id_users = dataGridView1.SelectedRows[0].Cells["ID_пользователя"].Value;
                user.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Логин"].Value);

                detected_id_transport = dataGridView1.SelectedRows[0].Cells["ID_транспорта"].Value;
                courses.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Марка"].Value) + " " + Convert.ToString(dataGridView1.SelectedRows[0].Cells["Марка"].Value);

                dateOrder.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Дата_и_время_заказа"].Value);
                dateOrderFinished.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Дата_и_время_выполнения"].Value);
                price.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Цена"].Value);
            }
        }

        public object detected_id_users;
        private void user_Click(object sender, EventArgs e)
        {
            Select_users select_Users = new Select_users();
            select_Users.ShowDialog();
            detected_id_users = select_Users.selected_id_user;
            user.Text = Convert.ToString(select_Users.selected_login_user);
        }

        public object detected_id_transport;
        private void courses_Click(object sender, EventArgs e)
        {
            Select_transport select_Transport = new Select_transport();
            select_Transport.ShowDialog();
            detected_id_transport = select_Transport.selected_id_transport;
            courses.Text = Convert.ToString(select_Transport.selected_info_transport);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "UPDATE `заказы` SET " +
                "`ID_пользователя`='" + detected_id_users + "', " +
                "`ID_транспорта`='" + detected_id_transport + "', " +
                "`Дата_и_время_заказа`='" + dateOrder.Value.ToString("yyyy-MM-dd HH:mm")+ "', " +
                "`Дата_и_время_выполнения`='" + dateOrderFinished.Value.ToString("yyyy-MM-dd HH:mm") + "', " +
                "`Цена`='" + price.Text.Replace(",", ".") + "' " +
                "WHERE `ID_заказа`=" + detected_id_orders + " ;";
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

            load_orders();
        }
    }
}

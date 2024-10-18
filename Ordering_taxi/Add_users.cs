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
    public partial class Add_users : Form
    {
        public Add_users()
        {
            InitializeComponent();
            load_users();
        }
        public void load_users()
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "SELECT `пользователи`.`ID_пользователя`, " +
               "`пользователи`.`Логин`, " +
               "`пользователи`.`Пароль`, " +
               "`пользователи`.`Админ` " +
               "FROM `ordering_taxi`.`пользователи`;";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["ID_пользователя"].Visible = false;
            dataGridView1.Columns["Пароль"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "INSERT INTO пользователи (Логин, Пароль, Админ) " +
                "VALUES (@Логин, @Пароль, @Админ);";

            MySqlCommand insertOrderCommand = new MySqlCommand(sqlQuery, connection);
            insertOrderCommand.Parameters.AddWithValue("@Логин", login.Text);
            insertOrderCommand.Parameters.AddWithValue("@Пароль", pasww.Text);
            insertOrderCommand.Parameters.AddWithValue("@Админ", 0);


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
                load_users();
            }
        }
    }
}

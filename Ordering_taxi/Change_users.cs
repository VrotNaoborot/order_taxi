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
    public partial class Change_users : Form
    {
        public Change_users()
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

            dataGridView1.Columns["Пароль"].Visible = false;
        }

        public object selected_id_user;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selected_id_user = dataGridView1.SelectedRows[0].Cells["ID_пользователя"].Value;
                login.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Логин"].Value);
                pasww.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Пароль"].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "UPDATE `пользователи` SET " +
                "`Логин`='" + login.Text + "', " +
                "`Пароль`='" + pasww.Text + "' " +
                "WHERE `ID_пользователя`=" + selected_id_user + " ;";
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

            load_users();
        }
    }
}

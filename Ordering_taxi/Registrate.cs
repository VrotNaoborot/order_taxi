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
using System.Xml.Linq;

namespace Ordering_taxi
{
    public partial class Registrate : Form
    {
        public Registrate()
        {
            InitializeComponent();
            this.password.AutoSize = false;
            this.password.Size = new Size(this.password.Size.Width, 45);
        }

        private void Registrate_Load(object sender, EventArgs e)
        {

            if (login.Text.Length == 0)
            {
                MessageBox.Show("Необходимо ввести username");
                return;
            }
            if (password.Text.Length == 0)
            {
                MessageBox.Show("Необходимо ввести пароль");
                return;
            }
            var db = new DbWorker();
            MySqlConnection connection = db.Connect();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand check_user_command = new MySqlCommand("SELECT * FROM `пользователи` WHERE `логин` = @login", connection);
            check_user_command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login.Text;

            adapter.SelectCommand = check_user_command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Данный логин занят!");
                connection.Close();
                return;
            }

            MySqlCommand command = new MySqlCommand("INSERT INTO `пользователи` (`Логин`, `Пароль`, `Имя`, `Фамилия`) VALUES (@Логин, @Пароль, @Имя, @Фамилия)", connection);
            command.Parameters.Add("@Логин", MySqlDbType.VarChar).Value = this.login.Text;
            command.Parameters.Add("@Пароль", MySqlDbType.VarChar).Value = this.password.Text;

            if (command.ExecuteNonQuery() == 1)
            {
                connection.Close();
                MessageBox.Show("Аккаунт создан!");
                Auth auth = new Auth();
                auth.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Аккаунт не был создан.");
                connection.Close();
                Registrate registrate = new Registrate();
                registrate.Show();
                this.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Hide();
        }
    }
}

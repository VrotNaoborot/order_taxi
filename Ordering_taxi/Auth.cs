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
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
            this.password.AutoSize = false;
            this.password.Size = new Size(this.password.Size.Width, 45);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login.Text.Length == 0)
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (password.Text.Length == 0)
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            var db = new DbWorker();
            MySqlConnection connection = db.Connect();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `пользователи` WHERE `логин` = @username AND `пароль` = @password", connection);
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = login.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            connection.Close();

            if (table.Rows.Count > 0)
            {
                bool isAdmin = Convert.ToBoolean(table.Rows[0]["Админ"]);
                int userId = Convert.ToInt32(table.Rows[0]["ID_пользователя"]);

                GlobalVariables.IsAdmin = isAdmin;
                GlobalVariables.UserID = userId;
                this.Hide();

                if (!isAdmin)
                {
                    Catalog catalog = new Catalog();
                    catalog.Show();
                    this.Hide();
                }
                else
                {
                    Main main = new Main();
                    main.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Не удалось войти. Логин или пароль неверны.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Registrate registrate = new Registrate();
            registrate.Show();
            this.Hide();
        }
    }
}

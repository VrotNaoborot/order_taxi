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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            load_orders();

        }
        public string currentTable = "Заказы";
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

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_orders();
            currentTable = "Заказы";
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_users();
            currentTable = "Пользователи";
        }

        private void типТранспортаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_type_transport();
            currentTable = "Тип_транспорта";
        }

        private void транспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_transport();
            currentTable = "Транспорт";
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(currentTable == "Заказы")
            {
                Add_orders add_Orders = new Add_orders();
                add_Orders.Show();
            }
            else if(currentTable == "Пользователи")
            {
                Add_users add_Users = new Add_users();
                add_Users.Show();
            }
            else if(currentTable == "Тип_транспорта")
            {
                Add_type_transport add_Type_Transport = new Add_type_transport();
                add_Type_Transport.Show();
            }
            else if(currentTable == "Транспорт")
            {
                Add_transport add_Transport = new Add_transport();
                add_Transport.Show();
            }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentTable == "Заказы")
            {
                load_orders();
            }
            else if(currentTable == "Пользователи")
            {
                load_users();
            }
            else if(currentTable == "Тип_транспорта")
            {
                load_type_transport();
            }
            else if(currentTable == "Транспорт")
            {
                load_transport();
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentTable == "Заказы")
            {
                Change_orders change_Orders = new Change_orders();
                change_Orders.Show();
            }
        }
    }
}
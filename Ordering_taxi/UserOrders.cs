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
    public partial class UserOrders : Form
    {
        public UserOrders()
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
                "left join `транспорт` on `заказы`.`ID_транспорта`=`транспорт`.`ID_транспорта` " +
                $"WHERE `заказы`.`ID_пользователя` = {GlobalVariables.UserID};";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["ID_пользователя"].Visible = false;
            dataGridView1.Columns["ID_транспорта"].Visible = false;
            dataGridView1.Columns["Логин"].Visible = false;


            connection.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                date.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Дата_и_время_выполнения"].Value);
                price.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Цена"].Value);
                car.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Марка"].Value) + " " + Convert.ToString(dataGridView1.SelectedRows[0].Cells["Модель"].Value);
            }
        }

        private void выборToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalog catalog = new Catalog();
            catalog.Show();
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

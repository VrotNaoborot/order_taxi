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
    public partial class Add_orders : Form
    {
        public Add_orders()
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

        private void Add_orders_Load(object sender, EventArgs e)
        {

        }

        public object detected_id_user;
        private void user_Click(object sender, EventArgs e)
        {
            Select_users select_Users = new Select_users();
            select_Users.ShowDialog();
            detected_id_user = select_Users.selected_id_user;
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

            String sqlQuery = "INSERT INTO заказы (ID_пользователя, ID_транспорта, Дата_и_время_заказа, Дата_и_время_выполнения, Цена) " +
                "VALUES (@ID_пользователя, @ID_транспорта, @Дата_и_время_заказа, @Дата_и_время_выполнения, @Цена);";

            MySqlCommand insertOrderCommand = new MySqlCommand(sqlQuery, connection);
            insertOrderCommand.Parameters.AddWithValue("@ID_пользователя", detected_id_user);
            insertOrderCommand.Parameters.AddWithValue("@ID_транспорта", detected_id_transport);
            insertOrderCommand.Parameters.AddWithValue("@Дата_и_время_заказа", dateOrder.Value.ToString("yyyy-MM-dd HH:mm"));
            insertOrderCommand.Parameters.AddWithValue("@Дата_и_время_выполнения", dateOrderFinished.Value.ToString("yyyy-MM-dd HH:mm"));
            insertOrderCommand.Parameters.AddWithValue("@Цена", price.Text.Replace(",", "."));


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
                load_orders();
            }
        }
    }
}

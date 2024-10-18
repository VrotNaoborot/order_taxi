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
    public partial class Add_transport : Form
    {
        public Add_transport()
        {
            InitializeComponent();
            load_transport();
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

        public object detected_id_type;
        private void textBox1_Click(object sender, EventArgs e)
        {
            Select_type_transport select_Type_Transport = new Select_type_transport();
            select_Type_Transport.ShowDialog();
            detected_id_type = select_Type_Transport.selected_id_transport;
            textBox1.Text = Convert.ToString(select_Type_Transport.selected_name_transport);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "INSERT INTO транспорт (Марка, Модель, Тип, Год_выпуска, Государственный_номер, Длина_кузова, Высота_кузова, Ширина_кузова, Цена_за_км) " +
                "VALUES (@Марка, @Модель, @Тип, @Год_выпуска, @Государственный_номер, @Длина_кузова, @Высота_кузова, @Ширина_кузова, @Цена_за_км);";

            MySqlCommand insertOrderCommand = new MySqlCommand(sqlQuery, connection);
            insertOrderCommand.Parameters.AddWithValue("@Марка", user.Text);
            insertOrderCommand.Parameters.AddWithValue("@Модель", courses.Text);
            insertOrderCommand.Parameters.AddWithValue("@Тип", detected_id_type);
            insertOrderCommand.Parameters.AddWithValue("@Год_выпуска", textBox2.Text);
            insertOrderCommand.Parameters.AddWithValue("@Государственный_номер", price.Text);
            insertOrderCommand.Parameters.AddWithValue("@Длина_кузова", textBox3.Text.Replace(",", "."));
            insertOrderCommand.Parameters.AddWithValue("@Высота_кузова", textBox4.Text.Replace(",", "."));
            insertOrderCommand.Parameters.AddWithValue("@Ширина_кузова", textBox5.Text.Replace(",", "."));
            insertOrderCommand.Parameters.AddWithValue("@Цена_за_км", textBox6.Text.Replace(",", "."));


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
                load_transport();
            }
        }
    }
}

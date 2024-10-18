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
    public partial class Change_transport : Form
    {
        public Change_transport()
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

        public object selected_id_transport;
        public object selected_id_type_transport;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                selected_id_transport = dataGridView1.SelectedRows[0].Cells["ID_транспорта"].Value;
                user.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Марка"].Value);
                courses.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Модель"].Value);
                textBox1.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Тип"].Value);
                selected_id_transport = dataGridView1.SelectedRows[0].Cells["ID_транспорта"].Value;

                textBox2.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Год_выпуска"].Value);
                price.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Государственный_номер"].Value);
                textBox3.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Длина_кузова"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Высота_кузова"].Value);
                textBox5.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Ширина_кузова"].Value);
                textBox6.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells["Цена_за_км"].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "UPDATE `транспорт` SET " +
                "`Марка`='" + user.Text + "', " +
                "`Модель`='" + courses.Text + "', " +
                "`Тип`='" + selected_id_type_transport + "', " +
                "`Год_выпуска`='" + textBox2.Text + "', " +
                "`Государственный_номер`='" + price.Text.Replace(",", ".") + "', " +
                "`Длина_кузова`='" + textBox3.Text.Replace(",", ".") + "', " +
                "`Высота_кузова`='" + textBox4.Text.Replace(",", ".") + "', " +
                "`Ширина_кузова`='" + textBox5.Text.Replace(",", ".") + "', " +
                "`Цена_за_км`='" + textBox6.Text.Replace(",", ".") + "' " +
                "WHERE `ID_транспорта`=" + selected_id_transport + " ;";
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

            load_transport();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            Select_type_transport select_Type_Transport = new Select_type_transport();
            select_Type_Transport.ShowDialog();
            selected_id_type_transport = select_Type_Transport.selected_id_transport;
            textBox1.Text = Convert.ToString(select_Type_Transport.selected_name_transport);
        }
    }
}

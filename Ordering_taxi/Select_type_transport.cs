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
    public partial class Select_type_transport : Form
    {
        public Select_type_transport()
        {
            InitializeComponent();
            load_type_transport();
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

        public object selected_id_transport;
        public object selected_name_transport;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selected_id_transport = dataGridView1.SelectedRows[0].Cells["ID_типа_транспорта"].Value;
                selected_name_transport = dataGridView1.SelectedRows[0].Cells["Название"].Value;
                DialogResult = DialogResult.OK;
            }
        }
    }
}

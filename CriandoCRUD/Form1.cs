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

namespace CriandoCRUD
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        string sql = "datasource=localhost;username=root;password=123456;database=db_agenda";

        public Form1()
        {
            InitializeComponent();

            listContatos.View = View.Details;
            listContatos.LabelEdit = true;
            listContatos.AllowColumnReorder = true;
            listContatos.FullRowSelect = true;
            listContatos.GridLines = true;

            listContatos.Columns.Add("Id", 30, HorizontalAlignment.Left);
            listContatos.Columns.Add("Nome", 150, HorizontalAlignment.Left);
            listContatos.Columns.Add("E-mail", 150, HorizontalAlignment.Left);
            listContatos.Columns.Add("Telefone", 150, HorizontalAlignment.Left);
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(sql);
                conn.Open();

                string comandInsert = "INSERT INTO contato (nome, email, telefone) " +
                    "VALUES " +
                    "('" + txtNome.Text + "', '" + txtEmail.Text + "', '" + txtTelefone.Text + "') ";

                MySqlCommand commandInsert = new MySqlCommand(comandInsert, conn);

                commandInsert.ExecuteReader();

                MessageBox.Show("De certo, contato Salvo!!!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(sql);
                conn.Open();

                var query = "'%"+txtbuscar.Text+"%'";
                var comandSelect = "SELECT * FROM contato WHERE nome LIKE " + query +
                    " OR email LIKE " + query;

                MySqlCommand commandSelect = new MySqlCommand(comandSelect, conn);
                MySqlDataReader reader = commandSelect.ExecuteReader();

                listContatos.Items.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                    };

                    var linhaListContato = new ListViewItem(row);
                    listContatos.Items.Add(linhaListContato);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

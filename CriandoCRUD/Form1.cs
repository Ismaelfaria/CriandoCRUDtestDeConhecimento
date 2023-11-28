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
        private int? idSelecionado = null;

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
            listContatos.Columns.Add("Email", 150, HorizontalAlignment.Left);
            listContatos.Columns.Add("Telefone", 150, HorizontalAlignment.Left);

            loadListContatos();
        }

        private void CreateAndUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(sql);
                conn.Open();
                var comandCreate = new MySqlCommand();

                comandCreate.Connection = conn;

                if (idSelecionado == null)
                {
                    comandCreate.CommandText = "INSERT INTO contato (nome, email, telefone) " +
                                        "VALUE (@n, @e, @t) ";
                    comandCreate.Parameters.AddWithValue("@n", txtNome.Text);
                    comandCreate.Parameters.AddWithValue("@e", txtEmail.Text);
                    comandCreate.Parameters.AddWithValue("@t", txtTelefone.Text);
                
                    MessageBox.Show("Contato inserido com secesso");
                }
                else
                {
                    comandCreate.CommandText = "UPDATE contato SET " +
                                      "nome=@n, email=@e, telefone=@t " +
                                      "WHERE id=@id ";
                    comandCreate.Parameters.AddWithValue("@n", txtNome.Text);
                    comandCreate.Parameters.AddWithValue("@e", txtEmail.Text);
                    comandCreate.Parameters.AddWithValue("@t", txtTelefone.Text);
                    comandCreate.Parameters.AddWithValue("@id", idSelecionado);

                    MessageBox.Show("Contato atualizado com secesso");
                }


                comandCreate.ExecuteNonQuery();

                

                loadListContatos();
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

        private void Read_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(sql);
                conn.Open();

                var commandSelect = new MySqlCommand();

                commandSelect.Connection = conn;

                commandSelect.CommandText = "SELECT * FROM contato WHERE nome LIKE @q OR email LIKE @q ";

                commandSelect.Parameters.AddWithValue("@q", "%" + txtbuscar.Text + "%");

                commandSelect.Prepare();

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

        private void loadListContatos()
        {
            try
            {
                conn = new MySqlConnection(sql);
                conn.Open();

                var commandSelect = new MySqlCommand();

                commandSelect.Connection = conn;

                commandSelect.CommandText = "SELECT * FROM contato ORDER BY id DESC ";

                commandSelect.Prepare();

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

                ClearFormulary.Visible = true;
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

        private void listContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemDaList = listContatos.SelectedItems;

            foreach (ListViewItem item in itemDaList)
            {
                idSelecionado = Convert.ToInt32(item.SubItems[0].Text);

                txtNome.Text = item.SubItems[1].Text;
                txtEmail.Text = item.SubItems[2].Text;
                txtTelefone.Text = item.SubItems[3].Text;

                ClearFormulary.Visible = true;
            }
        }

        private void ClearFormulary_Click(object sender, EventArgs e)
        {
            idSelecionado = null;

            txtNome.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtTelefone.Text = String.Empty;

            mouseOnTheForm();
        }

        private void mouseOnTheForm()
        {
            txtNome.Focus();
            ClearFormulary.Visible = false;
        }
    }
}

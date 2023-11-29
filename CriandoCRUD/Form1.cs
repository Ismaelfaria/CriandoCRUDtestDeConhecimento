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

            DeleteItem.Visible = false;
        }
        private void CreateAndUpdate_Click(object sender, EventArgs e)
        {
            if (Validation.valid(txtNome.Text, txtEmail.Text, txtTelefone.Text) == true)
            {
                try
                {
                    conn = new MySqlConnection(sql);
                    conn.Open();

                    var comandCreateAndUpdate = new MySqlCommand();

                    comandCreateAndUpdate.Connection = conn;

                    if (idSelecionado == null)
                    {
                        comandCreateAndUpdate.CommandText = "INSERT INTO contato (nome, email, telefone) " +
                                            "VALUE (@n, @e, @t) ";
                        comandCreateAndUpdate.Parameters.AddWithValue("@n", txtNome.Text);
                        comandCreateAndUpdate.Parameters.AddWithValue("@e", txtEmail.Text);
                        comandCreateAndUpdate.Parameters.AddWithValue("@t", txtTelefone.Text);

                        MessageBox.Show("Contato inserido com secesso");
                    }
                    else
                    {
                        comandCreateAndUpdate.CommandText = "UPDATE contato SET " +
                                          "nome=@n, email=@e, telefone=@t " +
                                          "WHERE id=@id ";
                        comandCreateAndUpdate.Parameters.AddWithValue("@n", txtNome.Text);
                        comandCreateAndUpdate.Parameters.AddWithValue("@e", txtEmail.Text);
                        comandCreateAndUpdate.Parameters.AddWithValue("@t", txtTelefone.Text);
                        comandCreateAndUpdate.Parameters.AddWithValue("@id", idSelecionado);

                        MessageBox.Show("Contato atualizado com secesso");
                    }

                    comandCreateAndUpdate.ExecuteNonQuery();

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
            else
            {
                MessageBox.Show("Campo/s invalidos","Atenção", MessageBoxButtons.OK);
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
            DeleteItem.Visible = true;
        }
        private void ClearFormularyAndMouse_Click(object sender, EventArgs e)
        {
            if(Validation.validcamp(txtNome.Text, txtEmail.Text, txtTelefone.Text) == true) 
            { 
            cleanFormulary();
            mouseOnTheForm();
            }
            else
            {
                MessageBox.Show("Campos já estão limpos", "Atenção", MessageBoxButtons.OK);
            }
        }
        private void cleanFormulary()
        {
            idSelecionado = null;

            txtNome.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtTelefone.Text = String.Empty;
        }
        private void mouseOnTheForm()
        {
            txtNome.Focus();
            ClearFormulary.Visible = false;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }
        private void DeleteContact()
        {
            try
            {
                DialogResult conf = MessageBox.Show("Tem certeza que deseja excluir o registro?",
                                                    "Ops, tem certeza?",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

                if (conf == DialogResult.Yes)
                {
                    conn = new MySqlConnection(sql);
                    conn.Open();

                    MySqlCommand commandDelete = new MySqlCommand();

                    commandDelete.Connection = conn;

                    commandDelete.CommandText = "DELETE FROM contato WHERE id=@id ";
                    commandDelete.Parameters.AddWithValue("@id", idSelecionado);
                    commandDelete.Prepare();
                    commandDelete.ExecuteNonQuery();


                    MessageBox.Show("Contato Excluído com Sucesso!",
                                    "Sucesso!", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    loadListContatos();

                    cleanFormulary();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro " + ex.Number + " ocorreu: " + ex.Message,
                               "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu: " + ex.Message,
                                "Erro", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            DeleteContact();

            DeleteItem.Visible = false;
        }
      }
    }


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CRUD
{
    public partial class Form1 : Form
    {
        string conexion = "Server=localhost\\SQLEXPRESS;Database=CRUD_Usuarios;Trusted_Connection=True;";
        public Form1()
        {
           

            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurarse que no sea cabecera
            {
                DataGridViewRow fila = dgvUsuario.Rows[e.RowIndex];

                textNombre.Text = fila.Cells["Nombre"].Value.ToString();
                textCorreo.Text = fila.Cells["Correo"].Value.ToString();
                textTelefono.Text = fila.Cells["Telefono"].Value.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuario.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvUsuario.SelectedRows[0].Cells["Id"].Value);
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET Nombre=@n, Correo=@c, Telefono=@t WHERE Id=@id", con);
                    cmd.Parameters.AddWithValue("@n", textNombre.Text);
                    cmd.Parameters.AddWithValue("@c", textCorreo.Text);
                    cmd.Parameters.AddWithValue("@t", textTelefono.Text);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
                
            }
        }
    }
}

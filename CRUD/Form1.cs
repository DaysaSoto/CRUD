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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.BACKEND;
using login.FRONTEND;
using login.POJOS;
namespace login.FRONTEND
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            usuario obj = new usuario();
            obj.NombreUsuario = txtUsuario.Text;
            obj.Contrasenia = txtContra.Text;
            obj.Apellido = txtApellido.Text;
            obj.Nombre = txtNombre.Text;
            if(new DAOusuario().validarUsuario(obj)) 
            {
                MessageBox.Show("Usuario duplicado, intente con otro nombre de usuario");
                txtApellido.Text = "APELLIDO";
                txtContra.Text = "CONTRASEÑA";
                txtNombre.Text = "NOMBRE";
                txtUsuario.Text = "NOMBRE DE USUARIO";
            }
            else
            {
                if(txtUsuario.Text == "" || txtContra.Text == ""
                    || txtContra.Text == "CONTRASEÑA" || txtUsuario.Text =="NOMBRE DE USUARIO")
                {
                     MessageBox.Show("WARNING!", "Campos vacíos");
                }
                else
                {
                   MessageBox.Show("Usuario agregado :)");
                   new DAOusuario().registro(obj);
                }
                
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRE")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.LightGray;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "NOMBRE";
                txtNombre.ForeColor = Color.DimGray;
            }
        }

        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if(txtApellido.Text == "")
            {
                txtApellido.Text = "APELLIDO";
                txtApellido.ForeColor = Color.DimGray;
            }
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "APELLIDO")
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(txtUsuario.Text =="")
            {
                txtUsuario.Text = "NOMBRE DE USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "NOMBRE DE USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            if(txtContra.Text == "CONTRASEÑA")
            {
                txtContra.Text = "";
                txtContra.ForeColor = Color.LightGray;
                txtContra.UseSystemPasswordChar = true;
            }
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if(txtContra.Text == "")
            {
                txtContra.Text = "CONTRASEÑA";
                txtContra.ForeColor = Color.DimGray;
                txtContra.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Black;
        }

        
    }
}

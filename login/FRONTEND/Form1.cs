using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using login.POJOS;
using login.BACKEND;
using login.FRONTEND;

namespace login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btn_inicio_MouseHover(object sender, EventArgs e)
        {
            btn_inicio.Cursor = Cursors.Hand;
            
               
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            usuario obj = new usuario();
            //obtenemos los datos
            obj.NombreUsuario = txtUsuario.Text;
            obj.Contrasenia = txtContra.Text;
            if(new DAOusuario().validarUsuario(obj))
            {
                MessageBox.Show("USUARIO DENTRO DE LA BD");
                txtContra.Text = "";
                txtUsuario.Text = "";
            }
            else
            {
                MessageBox.Show("USUARIO NO REGISTRADO");
                txtContra.Text = "";
                txtUsuario.Text = "";
            }
        }

        

        private void btn_registro_Click(object sender, EventArgs e)
        {
            Registro form = new Registro();
            form.ShowDialog();
             
        }

        private void btn_registro_MouseHover(object sender, EventArgs e)
        {
            btn_registro.BackColor = Color.FromArgb(0, 0, 125);

        }

        private void btn_registro_MouseLeave(object sender, EventArgs e)
        {
            btn_registro.BackColor = Color.FromArgb(0,0,0,1);
        }

        /*private void txtUsuario_MouseEnter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }*/

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;

            }
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (txtContra.Text == "")
            {
                txtContra.Text = "CONTRASEÑA";
                txtContra.ForeColor = Color.DimGray;
                txtContra.UseSystemPasswordChar = false;
            }
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            if (txtContra.Text == "CONTRASEÑA")
            {
                txtContra.Text = "";
                txtContra.ForeColor = Color.LightGray;
                txtContra.UseSystemPasswordChar = true;

            }
        }

        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pbExit.BackColor = Color.Red;
        }

        private void pbExit_MouseLeave(object sender, EventArgs e)
        {
            pbExit.BackColor = Color.Black;
        }
    }
}

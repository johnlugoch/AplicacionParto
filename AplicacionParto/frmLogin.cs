using CADAplicacionParto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionParto
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                errorProvider1.SetError(txtUsuario, "Debe ingresar un usuario");
                txtUsuario.Focus();
                return;
            }
            errorProvider1.SetError(txtUsuario, "");
            if (txtClave.Text == "")
            {
                errorProvider1.SetError(txtClave, "Debe ingresar una clave");
                txtClave.Focus();
                return;
            }
            errorProvider1.SetError(txtClave, "");

            if (!CADUsuario.ValidarUsuario(txtUsuario.Text, txtClave.Text))
            {
                MessageBox.Show("Usuario y Clave Invalidados","Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                txtUsuario.Text="";
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return;
            }
            frmPrincipal miForm = new frmPrincipal();
            miForm.UsuarioLogueado = CADUsuario.GetUsuario(txtUsuario.Text);
            miForm.Show();
            this.Hide();
        }
    }
}

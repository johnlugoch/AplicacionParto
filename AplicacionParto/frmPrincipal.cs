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
    public partial class frmPrincipal : Form
    {
        internal static string variableUsuario;
        private CADUsuario usuarioLogueado;

        public CADUsuario UsuarioLogueado
        {
            get { return usuarioLogueado; }
            set { usuarioLogueado = value; }
        }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMatriz miForm = new frmMatriz();
            miForm.MdiParent = this;
            miForm.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            UsuariotoolStripStatusLabel1.Text = "Usuario: " + UsuarioLogueado.IDUsuario;
            variableUsuario = UsuarioLogueado.IDUsuario;
        }
    }
}

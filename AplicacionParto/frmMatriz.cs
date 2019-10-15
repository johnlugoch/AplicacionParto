using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AplicacionParto
{
    public partial class frmMatriz : Form
    {
        private int i = 0;
        private bool nuevo;
        string sexo;
        string gestante_remitida;
        string parto_vaginal;
        string TSH;
        string VIH;
        string gestiono_rc;
        string bcg;
        string hb;
        string contacto_piel;
        string alojamiento;
        string lact_materna;
        string dificultad_lactancia;
        string control_rn;
        string control_post;


        public frmMatriz()
        {
            InitializeComponent();
        }

        private void frmMatriz_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSAplicacionParto.HemoClasificacion' Puede moverla o quitarla según sea necesario.
            this.hemoClasificacionTableAdapter.Fill(this.dSAplicacionParto.HemoClasificacion);
            // TODO: esta línea de código carga datos en la tabla 'dSAplicacionParto.Medico' Puede moverla o quitarla según sea necesario.
            this.medicoTableAdapter.Fill(this.dSAplicacionParto.Medico);
            // TODO: esta línea de código carga datos en la tabla 'dSAplicacionParto.Etnia' Puede moverla o quitarla según sea necesario.
            this.etniaTableAdapter.Fill(this.dSAplicacionParto.Etnia);
            // TODO: esta línea de código carga datos en la tabla 'dSAplicacionParto.Poblacion' Puede moverla o quitarla según sea necesario.
            this.poblacionTableAdapter.Fill(this.dSAplicacionParto.Poblacion);
            // TODO: esta línea de código carga datos en la tabla 'dSAplicacionParto.Regimen' Puede moverla o quitarla según sea necesario.
            this.regimenTableAdapter.Fill(this.dSAplicacionParto.Regimen);
            // TODO: esta línea de código carga datos en la tabla 'dSAplicacionParto.EAPB' Puede moverla o quitarla según sea necesario.
            this.eAPBTableAdapter.Fill(this.dSAplicacionParto.EAPB);
            // TODO: esta línea de código carga datos en la tabla 'dSAplicacionParto.TipoDocumento' Puede moverla o quitarla según sea necesario.
            this.tipoDocumentoTableAdapter.Fill(this.dSAplicacionParto.TipoDocumento);
            //MessageBox.Show(dgvDatos.Rows.Count.ToString());
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = CADAplicacionParto.CADMatriz.GetData();

            //MessageBox.Show(CADAplicacionParto.CADMatriz.GetData().Count.ToString());
            //MessageBox.Show(dgvDatos.Rows.Count.ToString());
            MostrarRegistro();
            //MessageBox.Show(frmPrincipal.variableUsuario);
        }

        private void MostrarRegistro()
        {
            if (dgvDatos.Rows.Count == 1) return;
            txtIDParto.Text = dgvDatos.Rows[i].Cells["IDParto"].Value.ToString();
            txtDocumento.Text = dgvDatos.Rows[i].Cells["Documento"].Value.ToString();
            txtNombre1.Text = dgvDatos.Rows[i].Cells["PrimerNombre"].Value.ToString();
            txtNombre2.Text = dgvDatos.Rows[i].Cells["SegundoNombre"].Value.ToString();
            txtApellido1.Text = dgvDatos.Rows[i].Cells["PrimerApellido"].Value.ToString();
            txtApellido2.Text = dgvDatos.Rows[i].Cells["SegundoApellido"].Value.ToString();
            txtEdad.Text = dgvDatos.Rows[i].Cells["Edad"].Value.ToString();
            txtDireccion.Text = dgvDatos.Rows[i].Cells["Direccion"].Value.ToString();
            txtBarrio.Text = dgvDatos.Rows[i].Cells["Barrio"].Value.ToString();
            txttelefono.Text = dgvDatos.Rows[i].Cells["Telefono"].Value.ToString();
            txtHoraParto.Text = dgvDatos.Rows[i].Cells["HoraPartoV"].Value.ToString();
            txtAcompTP.Text = dgvDatos.Rows[i].Cells["AcompTrabajo"].Value.ToString();
            txtAcompPV.Text = dgvDatos.Rows[i].Cells["AcompParto"].Value.ToString();
            txtNacidoVivo.Text = dgvDatos.Rows[i].Cells["NacidoVivo"].Value.ToString();
            txtPeso.Text = dgvDatos.Rows[i].Cells["Peso"].Value.ToString();
            txtTalla.Text = dgvDatos.Rows[i].Cells["Talla"].Value.ToString();
            txtPC.Text = dgvDatos.Rows[i].Cells["PC"].Value.ToString();
            txtPT.Text = dgvDatos.Rows[i].Cells["PT"].Value.ToString();
            txtPA.Text = dgvDatos.Rows[i].Cells["PA"].Value.ToString();
            txtSifilis.Text = dgvDatos.Rows[i].Cells["SIFILIS"].Value.ToString();
            txtRegistro.Text = dgvDatos.Rows[i].Cells["Registro"].Value.ToString();
            txtObservacion.Text = dgvDatos.Rows[i].Cells["Observaciones"].Value.ToString();

            cmbTipoDocumento.SelectedValue = dgvDatos.Rows[i].Cells["IDTipoDocumento"].Value;
            cmbEAPB.SelectedValue = dgvDatos.Rows[i].Cells["EAPB"].Value;
            cmbRegimen.SelectedValue = dgvDatos.Rows[i].Cells["Regimen"].Value;
            cmbPoblacion.SelectedValue = dgvDatos.Rows[i].Cells["PoblacionClave"].Value;
            cmbEtnia.SelectedValue = dgvDatos.Rows[i].Cells["Etnia"].Value;
            cmbMedico.SelectedValue = dgvDatos.Rows[i].Cells["IDMedico"].Value;
            cmbHemo.SelectedValue = dgvDatos.Rows[i].Cells["HemoClasificacion"].Value;

            try
            {
                dtpFechaNac.Value = Convert.ToDateTime(dgvDatos.Rows[i].Cells["FechaNacimiento"].Value);
                DTPParto.Value = Convert.ToDateTime(dgvDatos.Rows[i].Cells["FechaPartoV"].Value);
                dtpTamizaje.Value = Convert.ToDateTime(dgvDatos.Rows[i].Cells["FechaTamizaje"].Value);
            }
            catch(Exception)
            {
                dtpFechaNac.Value = DateTime.Now;
                DTPParto.Value = DateTime.Now;
                dtpTamizaje.Value = DateTime.Now;
            }
            

            //RadioButton Remitida            
            if (dgvDatos.Rows[i].Cells["Remitida"].Value.ToString() == "Si")
            {
                radioButton1.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["Remitida"].Value.ToString() == "No")
            {
                radioButton2.Checked = false;
            }
            //RadioButton Parto Vaginal
            if (dgvDatos.Rows[i].Cells["Control"].Value.ToString() == "Si")
            {
                radioButton4.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["Control"].Value.ToString() == "No")
            {
                radioButton3.Checked = false;
            }
            //RadioButton Sexo
            if (dgvDatos.Rows[i].Cells["Sexo"].Value.ToString() == "Masculino")
            {
                radioButton28.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["Sexo"].Value.ToString() == "Femenino")
            {
                radioButton27.Checked = false;
            }
            //RadioButton TSH
            if (dgvDatos.Rows[i].Cells["TSH"].Value.ToString() == "Positivo")
            {
                radioButton6.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["TSH"].Value.ToString() == "Negativo")
            {
                radioButton5.Checked = false;
            }
            //RadioButton VIH
            if (dgvDatos.Rows[i].Cells["VIH"].Value.ToString() == "Positivo")
            {
                radioButton8.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["VIH"].Value.ToString() == "Negativo")
            {
                radioButton7.Checked = false;
            }
            //RadioButton GestionoRC
            if (dgvDatos.Rows[i].Cells["GestionoRC"].Value.ToString() == "Si")
            {
                radioButton10.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["GestionoRC"].Value.ToString() == "No")
            {
                radioButton9.Checked = false;
            }
            //RadioButton BCG
            if (dgvDatos.Rows[i].Cells["BCG"].Value.ToString() == "Si")
            {
                radioButton12.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["BCG"].Value.ToString() == "No")
            {
                radioButton11.Checked = false;
            }
            //RadioButton HB
            if (dgvDatos.Rows[i].Cells["HB"].Value.ToString() == "Si")
            {
                radioButton14.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["HB"].Value.ToString() == "No")
            {
                radioButton13.Checked = false;
            }
            //RadioButton Contacto Piel
            if (dgvDatos.Rows[i].Cells["ContactoPiel"].Value.ToString() == "Si")
            {
                radioButton16.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["ContactoPiel"].Value.ToString() == "No")
            {
                radioButton15.Checked = false;
            }
            //RadioButton AlojamientoMadre
            if (dgvDatos.Rows[i].Cells["AlojamientoMadre"].Value.ToString() == "Si")
            {
                radioButton18.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["AlojamientoMadre"].Value.ToString() == "No")
            {
                radioButton17.Checked = false;
            }
            //RadioButton Lactancia
            if (dgvDatos.Rows[i].Cells["Lactancia"].Value.ToString() == "Si")
            {
                radioButton20.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["Lactancia"].Value.ToString() == "No")
            {
                radioButton19.Checked = false;
            }
            //RadioButton Dificultad Lactancia
            if (dgvDatos.Rows[i].Cells["DificultadLactancia"].Value.ToString() == "Si")
            {
                radioButton22.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["DificultadLactancia"].Value.ToString() == "No")
            {
                radioButton21.Checked = false;
            }
            //RadioButton Control 72 
            if (dgvDatos.Rows[i].Cells["ControlHoras"].Value.ToString() == "Si")
            {
                radioButton24.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["ControlHoras"].Value.ToString() == "No")
            {
                radioButton23.Checked = false;
            }
            //RadioButton Control Post-Parto
            if (dgvDatos.Rows[i].Cells["ControlPost"].Value.ToString() == "Si")
            {
                radioButton26.Checked = true;
            }
            else if (dgvDatos.Rows[i].Cells["ControlPost"].Value.ToString() == "No")
            {
                radioButton25.Checked = false;
            }
        }

        private void HabilitarCampos()
        {
            tsbPrimero.Enabled = false;
            tsbSiguiente.Enabled = false;
            tsbAnterior.Enabled = false;
            tsbUltimo.Enabled = false;

            tsbModificar.Enabled = false;
            tsbNuevo.Enabled = false;
            tsbBorrar.Enabled = false;
            //tsbBuscar.Enabled = false;
            tsbCancelar.Enabled = true;
            tsbGuardar.Enabled = true;
            txtDocumento.ReadOnly = false;

            txtDocumento.ReadOnly = false;
            txtNombre1.ReadOnly = false;
            txtNombre2.ReadOnly = false;
            txtApellido1.ReadOnly = false;
            txtApellido2.ReadOnly = false;

            txtBarrio.ReadOnly = false;
            txttelefono.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtHoraParto.ReadOnly = false;
            txtNacidoVivo.ReadOnly = false;
            txtEdad.ReadOnly = false;
            txtHoraParto.ReadOnly = false;
            txtAcompTP.ReadOnly = false;
            txtAcompPV.ReadOnly = false;
            txtPeso.ReadOnly = false;
            txtTalla.ReadOnly = false;
            txtPC.ReadOnly = false;
            txtPT.ReadOnly = false;
            txtPA.ReadOnly = false;
            txtRegistro.ReadOnly = false;
            txtObservacion.ReadOnly = false;
            txtSifilis.ReadOnly = false;

            cmbTipoDocumento.Enabled = true;
            cmbEAPB.Enabled = true;
            cmbRegimen.Enabled = true;
            cmbPoblacion.Enabled = true;
            cmbEtnia.Enabled = true;
            dtpFechaNac.Enabled = true;
            //cmbSexo.Enabled = true;
            cmbHemo.Enabled = true;
            cmbMedico.Enabled = true;

            DTPParto.Enabled = true;
            dtpTamizaje.Enabled = true;

            //grupo
            gbGestanteR.Enabled = true;
            gbSexo.Enabled = true;
            gbPartoV.Enabled = true;
            gbTSH.Enabled = true;
            gbVIH.Enabled = true;
            gbRegistro.Enabled = true;
            gbBCG.Enabled = true;
            gbHB.Enabled = true;
            gbContacto.Enabled = true;
            gbAlojamiento.Enabled = true;
            gbLactancia.Enabled = true;
            gbDificultad.Enabled = true;
            gbMadreControl.Enabled = true;
            gbControlPost.Enabled = true;

            radioButton7.Checked = true;
            //radiobutton
            /*radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            radioButton15.Checked = false;
            radioButton16.Checked = false;
            radioButton17.Checked = false;
            radioButton18.Checked = false;
            radioButton19.Checked = false;
            radioButton20.Checked = false;
            radioButton21.Checked = false;
            radioButton22.Checked = false;
            radioButton23.Checked = false;
            radioButton24.Checked = false;
            radioButton25.Checked = false;
            radioButton26.Checked = false;
            radioButton27.Checked = false;
            radioButton28.Checked = false;*/
        }

        private void DeshabilitarCampos()
        {
            tsbPrimero.Enabled = true;
            tsbSiguiente.Enabled = true;
            tsbAnterior.Enabled = true;
            tsbUltimo.Enabled = true;

            tsbModificar.Enabled = true;
            tsbNuevo.Enabled = true;
            tsbBorrar.Enabled = true;
            //tsbBuscar.Enabled = true;

            tsbCancelar.Enabled = false;
            tsbGuardar.Enabled = false;

            txtDocumento.ReadOnly = true;
            txtDocumento.ReadOnly = true;
            txtNombre1.ReadOnly = true;
            txtNombre2.ReadOnly = true;
            txtApellido1.ReadOnly = true;
            txtApellido2.ReadOnly = true;

            txtBarrio.ReadOnly = true;
            txttelefono.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtHoraParto.ReadOnly = true;
            txtNacidoVivo.ReadOnly = true;
            txtEdad.ReadOnly = true;
            txtHoraParto.ReadOnly = true;
            txtAcompTP.ReadOnly = true;
            txtAcompPV.ReadOnly = true;
            txtPeso.ReadOnly = true;
            txtTalla.ReadOnly = true;
            txtPC.ReadOnly = true;
            txtPT.ReadOnly = true;
            txtPA.ReadOnly = true;
            txtRegistro.ReadOnly = true;
            txtObservacion.ReadOnly = true;
            txtSifilis.ReadOnly = true;

            cmbTipoDocumento.Enabled = false;
            cmbEAPB.Enabled = false;
            cmbRegimen.Enabled = false;
            cmbPoblacion.Enabled = false;
            cmbEtnia.Enabled = false;
            dtpFechaNac.Enabled = false;
            //cmbSexo.Enabled = false;
            cmbHemo.Enabled = false;
            cmbMedico.Enabled = false;
            cmbHemo.Enabled = false;

            DTPParto.Enabled = false;
            dtpTamizaje.Enabled = false;

            gbGestanteR.Enabled = false;
            gbSexo.Enabled = false;
            gbPartoV.Enabled = false;
            gbTSH.Enabled = false;
            gbVIH.Enabled = false;
            gbRegistro.Enabled = false;
            gbBCG.Enabled = false;
            gbHB.Enabled = false;
            gbContacto.Enabled = false;
            gbAlojamiento.Enabled = false;
            gbLactancia.Enabled = false;
            gbDificultad.Enabled = false;
            gbMadreControl.Enabled = false;
            gbControlPost.Enabled = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            nuevo = false;
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarCampos();
            MostrarRegistro();
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            if (nuevo)
            {                                
                CADAplicacionParto.CADMatriz.InsertarParto( //1
                    (string) cmbTipoDocumento.SelectedValue, 
                    txtDocumento.Text, 
                    txtNombre1.Text,
                    txtNombre2.Text,
                    txtApellido1.Text,
                    txtApellido2.Text,
                    dtpFechaNac.Value,
                    Convert.ToInt32(txtEdad.Text), 
                    txtDireccion.Text, //10
                    txtBarrio.Text, 
                    txttelefono.Text,
                    (string)cmbEAPB.SelectedValue,
                    (int) cmbRegimen.SelectedValue, 
                    (int)cmbPoblacion.SelectedValue, 
                    (int)cmbEtnia.SelectedValue, 
                    gestante_remitida,
                    DTPParto.Value, 
                    txtHoraParto.Text, 
                    parto_vaginal, //20
                    txtAcompTP.Text, 
                    txtAcompPV.Text, 
                    dtpTamizaje.Value, 
                    sexo, 
                    txtNacidoVivo.Text,
                    (txtPeso.Text),
                    (txtTalla.Text),
                    (txtPC.Text),
                    (txtPT.Text),
                    (txtPA.Text), //30
                    TSH, 
                    txtSifilis.Text, 
                    VIH, 
                    cmbHemo.Text, 
                    gestiono_rc, 
                    txtRegistro.Text,
                    bcg, 
                    hb, 
                    contacto_piel, 
                    alojamiento, //40
                    lact_materna,  
                    dificultad_lactancia, 
                    control_rn, 
                    control_post,
                    Convert.ToInt32(cmbMedico.SelectedValue),//Convert.ToInt32(cmbMedico.Text),                   
                    txtObservacion.Text,
                    cmbMedico.Text,
                    frmPrincipal.variableUsuario,
                    cmbEAPB.Text);//47            cmbMedico.SelectedText.ToString()
            }
            else
            {
                CADAplicacionParto.CADMatriz.UpdateParto(
                   (string)cmbTipoDocumento.SelectedValue,
                    txtDocumento.Text,
                    txtNombre1.Text,
                    txtNombre2.Text,
                    txtApellido1.Text,
                    txtApellido2.Text,
                    dtpFechaNac.Value,
                    Convert.ToInt32(txtEdad.Text),
                    txtDireccion.Text, //10
                    txtBarrio.Text,
                    txttelefono.Text,
                    (string)cmbEAPB.SelectedValue,
                    (int)cmbRegimen.SelectedValue,
                    (int)cmbPoblacion.SelectedValue,
                    (int)cmbEtnia.SelectedValue,
                    gestante_remitida,
                    DTPParto.Value,
                    txtHoraParto.Text,
                    parto_vaginal, //20
                    txtAcompTP.Text,
                    txtAcompPV.Text,
                    dtpTamizaje.Value,
                    sexo,
                    txtNacidoVivo.Text,
                    (txtPeso.Text),
                    (txtTalla.Text),
                    (txtPC.Text),
                    (txtPT.Text),
                    (txtPA.Text), //30
                    TSH,
                    txtSifilis.Text,
                    VIH,
                    cmbHemo.Text,
                    gestiono_rc,
                    txtRegistro.Text,
                    bcg,
                    hb,
                    contacto_piel,
                    alojamiento, //40
                    lact_materna,
                    dificultad_lactancia,
                    control_rn,
                    control_post,
                    Convert.ToInt32(cmbMedico.SelectedValue),//Convert.ToInt32(cmbMedico.Text),                   
                    txtObservacion.Text,
                    cmbMedico.Text,//47 
                    frmPrincipal.variableUsuario,
                    cmbEAPB.Text,
                    Convert.ToInt32(txtIDParto.Text));
            }
            DeshabilitarCampos();
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = CADAplicacionParto.CADMatriz.GetData();
            if (nuevo) tsbUltimo_Click(sender, e);
            MostrarRegistro();
        }

        private bool ValidarCampos()
        {
            if (cmbTipoDocumento.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbTipoDocumento, "Debe seleccionar un tipo de documento");
                cmbTipoDocumento.Focus();
                return false;
            }
            errorProvider1.SetError(cmbTipoDocumento, "");

            if (txtDocumento.Text == "")
            {
                errorProvider1.SetError(txtDocumento, "Debe ingresar un documento");
                txtDocumento.Focus();
                return false;
            }
            errorProvider1.SetError(txtDocumento, "");

            if (txtNombre1.Text == "")
            {
                errorProvider1.SetError(txtNombre1, "Debe ingresar el primer nombre");
                txtNombre1.Focus();
                return false;
            }
            errorProvider1.SetError(txtNombre1, "");

            if (txtNombre2.Text == "")
            {
                errorProvider1.SetError(txtNombre2, "Debe ingresar el segundo nombre");
                txtNombre2.Focus();
                return false;
            }
            errorProvider1.SetError(txtNombre2, "");

            if (txtApellido1.Text == "")
            {
                errorProvider1.SetError(txtApellido1, "Debe ingresar el primer apellido");
                txtApellido1.Focus();
                return false;
            }
            errorProvider1.SetError(txtApellido1, "");

            if (txtApellido2.Text == "")
            {
                errorProvider1.SetError(txtApellido2, "Debe ingresar el segundo apellido");
                txtApellido2.Focus();
                return false;
            }
            errorProvider1.SetError(txtApellido2, "");

            if (txtEdad.Text == "")
            {
                errorProvider1.SetError(txtEdad, "La edad no puede estar vacia, debe seleccionar la fecha de nacimiento");
                txtEdad.Focus();
                return false;
            }
            errorProvider1.SetError(txtEdad, "");

            if (txtDireccion.Text == "")
            {
                errorProvider1.SetError(txtDireccion, "Debes colocalar una dirección");
                txtDireccion.Focus();
                return false;
            }
            errorProvider1.SetError(txtDireccion, "");

            if (txtBarrio.Text == "")
            {
                errorProvider1.SetError(txtBarrio, "Debes colocar el barrio");
                txtBarrio.Focus();
                return false;
            }
            errorProvider1.SetError(txtBarrio, "");

            if (txttelefono.Text == "")
            {
                errorProvider1.SetError(txttelefono, "Debes colocar el barrio");
                txttelefono.Focus();
                return false;
            }
            errorProvider1.SetError(txttelefono, "");

            if (cmbEAPB.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbEAPB, "Debes Seleccionar la EPS a la que pertenece el usuario");
                cmbEAPB.Focus();
                return false;
            }
            errorProvider1.SetError(cmbEAPB, "");

            if (cmbRegimen.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbRegimen, "Debes Seleccionar la EPS a la que pertenece el usuario");
                cmbRegimen.Focus();
                return false;
            }
            errorProvider1.SetError(cmbRegimen, "");

            if (cmbPoblacion.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbPoblacion, "Debes Seleccionar la población objeto");
                cmbPoblacion.Focus();
                return false;
            }
            errorProvider1.SetError(cmbPoblacion, "");

            if (cmbEtnia.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbEtnia, "Debes Seleccionar la etnia");
                cmbEtnia.Focus();
                return false;
            }
            errorProvider1.SetError(cmbEtnia, "");

            if (cmbHemo.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbHemo, "Debes Seleccionar la Hemoclasificación");
                cmbHemo.Focus();
                return false;
            }
            errorProvider1.SetError(cmbHemo, "");

            if (cmbMedico.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbMedico, "Debes Seleccionar la Hemoclasificación");
                cmbMedico.Focus();
                return false;
            }
            errorProvider1.SetError(cmbMedico, "");

            if (txtHoraParto.Text == "")
            {
                errorProvider1.SetError(txtHoraParto, "Debes colocar la hora");
                txtHoraParto.Focus();
                return false;
            }
            errorProvider1.SetError(txtHoraParto, "");

            if (txtAcompTP.Text == "")
            {
                errorProvider1.SetError(txtAcompTP, "Debes colocar el acompañamiento en el trabajo de parto");
                txtAcompTP.Focus();
                return false;
            }
            errorProvider1.SetError(txtAcompTP, "");

            if (txtAcompPV.Text == "")
            {
                errorProvider1.SetError(txtAcompPV, "Debes colocar el acompañamiento en el parto vaginal");
                txtAcompPV.Focus();
                return false;
            }
            errorProvider1.SetError(txtAcompPV, "");

            if (txtNacidoVivo.Text == "")
            {
                errorProvider1.SetError(txtNacidoVivo, "Debes colocar No. Nacido Vivo");
                txtNacidoVivo.Focus();
                return false;
            }
            errorProvider1.SetError(txtNacidoVivo, "");

            if (txtSifilis.Text == "")
            {
                errorProvider1.SetError(txtSifilis, "Debes colocar disoluciones Sifilis congenita");
                txtSifilis.Focus();
                return false;
            }
            errorProvider1.SetError(txtSifilis, "");

            if (txtRegistro.Text == "")
            {
                errorProvider1.SetError(txtRegistro, "Debes colocar El registro");
                txtRegistro.Focus();
                return false;
            }
            errorProvider1.SetError(txtRegistro, "");

            if (txtObservacion.Text == "")
            {
                errorProvider1.SetError(txtObservacion, "La observación no debe quedar vacia");
                txtObservacion.Focus();
                return false;
            }
            errorProvider1.SetError(txtObservacion, "");


            return true;                        
        }

        private void LimpiarCampos()
        {
            txtIDParto.Text = "";
            txtDocumento.Text = "";
            txtDocumento.Text = "";
            txtNombre1.Text = "";
            txtNombre2.Text = "";
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtBarrio.Text = "";
            txttelefono.Text = "";
            txtDireccion.Text = "";
            txtHoraParto.Text = "";
            txtNacidoVivo.Text = "";
            txtEdad.Text = "";
            txtHoraParto.Text = "";
            txtAcompTP.Text = "";
            txtAcompPV.Text = "";
            txtPeso.Text = "";
            txtTalla.Text = "";
            txtPC.Text = "";
            txtPT.Text = "";
            txtPA.Text = "";
            txtRegistro.Text = "";
            txtObservacion.Text = "";
            txtSifilis.Text = "";

            cmbTipoDocumento.SelectedIndex = -1;
            cmbEAPB.SelectedIndex = -1;
            cmbRegimen.SelectedIndex = -1;
            cmbPoblacion.SelectedIndex = -1;
            cmbEtnia.SelectedIndex = -1;            
            
            cmbHemo.SelectedIndex = -1;
            cmbMedico.SelectedIndex = -1;

            dtpFechaNac.Value = DateTime.Now;
            DTPParto.Value = DateTime.Now;
            dtpTamizaje.Value = DateTime.Now;

            /*radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            radioButton15.Checked = false;
            radioButton16.Checked = false;
            radioButton17.Checked = false;
            radioButton18.Checked = false;
            radioButton19.Checked = false;
            radioButton20.Checked = false;
            radioButton21.Checked = false;
            radioButton22.Checked = false;
            radioButton23.Checked = false;
            radioButton24.Checked = false;
            radioButton25.Checked = false;
            radioButton26.Checked = false;
            radioButton27.Checked = false;
            radioButton28.Checked = false;*/
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            LimpiarCampos();
            nuevo = true;
        }

        private void gbGestanteR_Enter(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gestante_remitida = "Si";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gestante_remitida = "No";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            parto_vaginal = "Si";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            parto_vaginal = "No";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            TSH = "Positivo";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            TSH = "Negativo";
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            gestiono_rc = "Si";
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            gestiono_rc = "No";
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            bcg = "Si";
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            bcg = "No";
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            hb = "Si";
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            hb = "No";
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            contacto_piel = "Si";
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            contacto_piel = "No";
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            alojamiento = "Si";
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            alojamiento = "No";
        }        

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            lact_materna = "Si";
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            lact_materna = "No";
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            dificultad_lactancia = "Si";
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            dificultad_lactancia = "No";
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            control_rn = "Si";
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            control_rn = "No";
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            control_post = "Si";
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            control_post = "No";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            VIH = "Positivo";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            VIH = "Negativo";
        }

        private void radioButton28_CheckedChanged(object sender, EventArgs e)
        {
            sexo = "Masculino";
        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {
            sexo = "Femenino";
        }

        private void tsbSiguiente_Click(object sender, EventArgs e)
        {
            if (i >= dgvDatos.Rows.Count - 2) return;
            i++;
            MostrarRegistro();                                                    
        }

        private void tsbAnterior_Click(object sender, EventArgs e)
        {
            if (i == 0) return;
            i--;
            MostrarRegistro();
        }

        private void tsbPrimero_Click(object sender, EventArgs e)
        {
            i = 0;
            MostrarRegistro();
        }

        private void tsbUltimo_Click(object sender, EventArgs e)
        {
            i = dgvDatos.Rows.Count - 2;
            MostrarRegistro();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("Esta seguro de borrar el registro actual?",
                "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button2);
            if (rta == DialogResult.No) return;
            CADAplicacionParto.CADMatriz.DeleteParto(Convert.ToInt32(txtIDParto.Text));
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = CADAplicacionParto.CADMatriz.GetData();
            MostrarRegistro();
        }

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
            DateTime nacimiento = Convert.ToDateTime(dtpFechaNac.Text);//new DateTime(2000, 1, 25); //Fecha de nacimiento
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
            txtEdad.Text = Convert.ToString(edad);
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPeso_Leave(object sender, EventArgs e)
        {
            int peso = Convert.ToInt32(txtPeso.Text);
            if (peso < 2500)
            {              
                txtPeso.Focus();
                MessageBox.Show("El peso esta por debajo de 2.500 Gr");
            }
            if (peso > 4000)
            {
                MessageBox.Show("El peso esta por encima de 4.000 Gr");
                txtPeso.Focus();                
            }
                        
        }

        private void txtTalla_Leave(object sender, EventArgs e)
        {
            int talla = Convert.ToInt32(txtTalla.Text);
            if (talla < 48)
            {
                MessageBox.Show("La Talla esta por debajo de 48 cm");
                txtTalla.Focus();
            }

            if (talla > 52)
            {
                MessageBox.Show("La Talla esta por encima de 52 cm");
                txtTalla.Focus();
            }
        }

        private void txtPC_Leave(object sender, EventArgs e)
        {
            int PC = Convert.ToInt32(txtPC.Text);
            if (PC < 32)
            {
                MessageBox.Show("El perimetro cefálico esta por debajo de 32 cm");
                txtPC.Focus();
            }

            if (PC > 36)
            {
                MessageBox.Show("El perimetro cefálico esta por encima de 52 cm");
                txtPC.Focus();
            }
        }

        private void txtPT_Leave(object sender, EventArgs e)
        {
            int PT = Convert.ToInt32(txtPT.Text);
            if (PT < 31)
            {
                MessageBox.Show("El perimetro torácico esta por debajo de 31 cm");
                txtPT.Focus();
            }

            if (PT > 35)
            {
                MessageBox.Show("El perimetro torácico esta por encima de 35 cm");
                txtPT.Focus();
            }
        }

        private void txtPA_Leave(object sender, EventArgs e)
        {
            int PA = Convert.ToInt32(txtPA.Text);
            if (PA < 28)
            {
                MessageBox.Show("El perimetro abdominal esta por debajo de 28 cm");
                txtPA.Focus();
            }

            if (PA > 34)
            {
                MessageBox.Show("El perimetro abdominal esta por encima de 34 cm");
                txtPA.Focus();
            }
        }

        private void txtPeso_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!int.TryParse(txtPeso.Text, out i))
            {
                //no numérico
                e.Cancel = true;
            }
            if (e.Cancel)
                MessageBox.Show("El campo debe contener un valor numérico");
        }

        private void txtPeso_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtPeso, "");
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void txtTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void ExportarDataGridViewExcel(DataGridView grd)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                for (int i = 0; i < dgvDatos.ColumnCount; i++)
                {
                    hoja_trabajo.Cells[1, i + 1] = dgvDatos.Columns[i].HeaderText;
                }
                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 0; i < grd.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < grd.Columns.Count; j++)
                    {
                        hoja_trabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                    }
                }
                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewExcel(dgvDatos);
        }
    }
}

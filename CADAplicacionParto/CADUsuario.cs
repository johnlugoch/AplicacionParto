using CADAplicacionParto.DSAplicacionPartoTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADAplicacionParto
{
    public class CADUsuario
    {
        public string IDUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Clave { get; set; }
        public DateTime FechaModificacionClave { get; set; }
        public int IDRol { get; set; }
        public string Correo { get; set; }

        private static UsuarioTableAdapter adaptador = new UsuarioTableAdapter();

        public static bool ValidarUsuario(string IDUsuario, string Clave)
        {
            if (adaptador.ValidaUsuario(IDUsuario, Clave) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static CADUsuario GetUsuario(String IDUsuario)
        {
            CADUsuario miUsuario = null;
            DSAplicacionParto.UsuarioDataTable miTabla = adaptador.GetUsuario(IDUsuario);
            if (miTabla.Rows.Count == 0) return miUsuario;
            DSAplicacionParto.UsuarioRow miRegistro = (DSAplicacionParto.UsuarioRow)miTabla.Rows[0];
            miUsuario = new CADUsuario();
            miUsuario.Apellidos = miRegistro.Apellidos;
            miUsuario.Clave = miRegistro.Clave;
            miUsuario.Correo = miRegistro.Correo;
            miUsuario.FechaModificacionClave = miRegistro.FechaModificacionClave;
            miUsuario.IDRol = miRegistro.IDRol;
            miUsuario.IDUsuario = miRegistro.IDUsuario;
            return miUsuario;
        }
    }
}

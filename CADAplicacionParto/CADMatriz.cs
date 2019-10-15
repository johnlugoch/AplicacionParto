using CADAplicacionParto.DSAplicacionPartoTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADAplicacionParto
{
    public class CADMatriz
    {
        private static PartoTableAdapter adaptador = new PartoTableAdapter();

        public static DSAplicacionParto.PartoDataTable GetData()
        {
            return adaptador.GetData();
        }

        public static void InsertarParto(string IDTipoDocumento, string Documento, string PrimerNombre, string SegundoNombre, string PrimerApellido, 
            string SegundoApellido, DateTime FechaNacimiento, int Edad, string Direccion, string Barrio, string Telefono, string EAPB, int Regimen, 
            int PoblacionClave, int Etnia, string Remitida, DateTime FechaPartoV, string HoraPartoV, string Partov, string AcompTrabajo, string AcompParto,
            DateTime FechaTamizaje, string Sexo, string NacidoVivo, string Peso, string Talla, string PC, string PT, string PA, string TSH, string SIFILIS, string VIH, string Hemoclasificacion, 
            string GestionoRC, string Registro, string BCG, string HB, string ContactoPiel, string AlojamientoMadre, string Lactancia, string DificultadLactancia, string ControlHoras, string ControlPost, 
            int medico, string observaciones, string nommedico, string IDUsuario, string NomEAPB)
        {
            adaptador.InsertParto(IDTipoDocumento, Documento, PrimerNombre, SegundoNombre, PrimerApellido,
                SegundoApellido, FechaNacimiento, Edad, Direccion, Barrio, Telefono, EAPB, Regimen,
                PoblacionClave, Etnia, Remitida, FechaPartoV, HoraPartoV, Partov, AcompTrabajo, AcompParto,
                FechaTamizaje, Sexo, NacidoVivo, Peso, Talla, PC, PT, PA, TSH, SIFILIS, VIH, Hemoclasificacion,
                GestionoRC, Registro, BCG, HB, ContactoPiel, AlojamientoMadre, Lactancia, DificultadLactancia,
                ControlHoras, ControlPost, medico, observaciones, nommedico, IDUsuario, NomEAPB);
        }

        public static void UpdateParto(string IDTipoDocumento, string Documento, string PrimerNombre, string SegundoNombre, string PrimerApellido,
            string SegundoApellido, DateTime FechaNacimiento, int Edad, string Direccion, string Barrio, string Telefono, string EAPB, int Regimen,
            int PoblacionClave, int Etnia, string Remitida, DateTime FechaPartoV, string HoraPartoV, string Partov, string AcompTrabajo, string AcompParto,
            DateTime FechaTamizaje, string Sexo, string NacidoVivo, string Peso, string Talla, string PC, string PT, string PA, string TSH, string SIFILIS, string VIH, string Hemoclasificacion,
            string GestionoRC, string Registro, string BCG, string HB, string ContactoPiel, string AlojamientoMadre, string Lactancia, string DificultadLactancia, string ControlHoras, 
            string ControlPost, int medico, string observaciones, string nommedico, string IDUsuario, string NomEAPB, int IDParto)
        {
            adaptador.UpdateParto(IDTipoDocumento, Documento, PrimerNombre, SegundoNombre, PrimerApellido,
                SegundoApellido, FechaNacimiento, Edad, Direccion, Barrio, Telefono, EAPB, Regimen,
                PoblacionClave, Etnia, Remitida, FechaPartoV, HoraPartoV, Partov, AcompTrabajo, AcompParto,
                FechaTamizaje, Sexo, NacidoVivo, Peso, Talla, PC, PT, PA, TSH, SIFILIS, VIH, Hemoclasificacion,
                GestionoRC, Registro, BCG, HB, ContactoPiel, AlojamientoMadre, Lactancia, DificultadLactancia,
                ControlHoras, ControlPost, medico, observaciones, nommedico, IDUsuario, NomEAPB, IDParto);
        }

        public static void DeleteParto(int IDParto)
        {
            adaptador.DeleteParto(IDParto);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{

    public enum Tipo_Seguro
    {
        Vida,
        Salud,
        Automovil,
        Hogar,
        Otro
    }

    public enum Estado_Seguro
    {
        Activo,
        Inactivo
    }

    public struct Seguro
    {
        public int id_seguro;
        public string nombre;
        public Tipo_Seguro tipo_seguro;
        public string cobertura;
        public decimal costo;
        public int duracion_meses;
        public string beneficios;
        public string exclusiones;
        public string condiciones;
        public int id_aseguradora;
        public Estado_Seguro estado;
    }

    public class CN_Seguro
    {
    }
}

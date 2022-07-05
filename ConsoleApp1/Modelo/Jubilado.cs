using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Modelo
{
    public class Jubilado : Persona
    {
        public int AniosDeAporte { get; set; }
        public char Categoria { get; set; } // tipo char representa un caracter
    }
}

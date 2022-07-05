using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Modelo;

namespace ConsoleApp1.Repositorio
{
    public class RepositorioDePersonas
    {
        public Dictionary<string, Persona> Personas { get; set; } // utilizo un Diccionario para guardar las personas. Un diccionario utiliza un indice que es un valor único para evitar que se repitan los valores, e este caso tenemos el DNI que es único por lo que usamos un string (ya que el DNI se guardó como un string) como TKey 

        public RepositorioDePersonas() // constructor
        {
            Personas = new Dictionary<string, Persona>();// creo el diccionario
        }

        public void Insertar(Persona persona)
        {
            var numeroDocumento = persona.NumeroDeDocumento;
            var personaExiste = Personas.ContainsKey(numeroDocumento);
            if (!personaExiste)
            {
                Personas[numeroDocumento] = persona;
            }
        }

        public void Eliminar(string numeroDocumento)
        {
            Persona personaAEliminar = null;
            foreach (var persona in Personas)
            {
                if (persona.NumeroDeDocumento == numeroDocumento)
                {
                    personaAEliminar = persona;
                    break;
                }
            }
            if (personaAEliminar != null)
            {
                Personas.Remove(personaAEliminar);
            }
        }

        public void Actualizar(Persona persona)
        {
            foreach (var personaActual in Personas)
            {
                if (personaActual.NumeroDeDocumento == persona.NumeroDeDocumento)
                {
                    personaActual.Nombre = persona.Nombre;
                    personaActual.Apellido = persona.Apellido;
                    personaActual.FechaNacimiento = persona.FechaNacimiento;
                }
            }
        }

        public void Actualizar(string numeroDocumento, string nombre, string apellido)
        {
            foreach (var personaActual in Personas)
            {
                if (personaActual.NumeroDeDocumento == numeroDocumento)
                {
                    personaActual.Nombre = nombre;
                    personaActual.Apellido = apellido;
                }
            }
        }
    }
}

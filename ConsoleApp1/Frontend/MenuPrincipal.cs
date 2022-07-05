using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Modelo;
using ConsoleApp1.Repositorio;

namespace ConsoleApp1.Frontend
{
    public class MenuPrincipal
    {
        private RepositorioDePersonas _repositorio;

        public MenuPrincipal()
        {
            _repositorio = new RepositorioDePersonas();
        }
        public void Iniciar()
        {
            Console.WriteLine("Bienvenido al gestor de personas");
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1 - Agregar una persona");
            Console.WriteLine("2 - Listar personas");
            Console.WriteLine("3 - Eliminar persona");
            Console.WriteLine("4 - Salir");

            int opcion;

            do
            {
                opcion= Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        MostrarAgregarPersona();
                        break;
                        
                    default:
                        break;
                }
                Console.WriteLine("Elija otra opción:");
                opcion = Convert.ToInt32(Console.ReadLine());

            } while (opcion!=4);


        }
        
        public void MostrarAgregarPersona() 
        {
            Console.WriteLine("Ingrese el tipo de persona a agregar:");
            Console.WriteLine("1 - Empleado");
            Console.WriteLine("2 - Desempleado");
            Console.WriteLine("3 - Jubilado");

            Persona personaAAgregar;

            var opcionTipoPersona = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre:");
            var nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido:");
            var apellido = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento en formato DD/MM/AAAA:");
            var fechaDeNacimiento = Console.ReadLine();


            switch (opcionTipoPersona)
            {
                case 1:
                    //empleado
                    var empleado = new Empleado
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        FechaNacimiento = fechaDeNacimiento
                    };
                    Console.WriteLine("Ingrese ocupación:");
                    empleado.Ocupacion = Console.ReadLine();
                    
                    Console.WriteLine("Ingrese el nombre de la empresa en la que trabaja:");
                    empleado.Empresa = Console.ReadLine();
                    
                    Console.WriteLine("Ingrese el nombre de su obra social:");
                    empleado.ObraSocial = Console.ReadLine();

                    personaAAgregar = empleado;

                    break;

                case 2:
                    //empleado
                    var desempleado = new Desemplado
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        FechaNacimiento = fechaDeNacimiento
                    };
                    
                    Console.WriteLine("Ingrese su última ocupación:");
                    desempleado.UltimaOcupacion = Console.ReadLine();

                    Console.WriteLine("Ingrese el nombre de la última empresa en la que trabajó:");
                    desempleado.UltimaEmpresa = Console.ReadLine();

                    Console.WriteLine("Manifiesta alguna discapacidad? S/N");      
                    var esDiscapacitado = Console.ReadLine();
                    if (esDiscapacitado.ToLower() == "s")
                    {
                        desempleado.EsDiscapacitado = true;
                    }

                    personaAAgregar = desempleado;

                    break;

                case 3:
                    //jubilado
                    var jubilado = new Jubilado
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        FechaNacimiento = fechaDeNacimiento
                    };
                    Console.WriteLine("Ingrese la cantidad de años de aporte que posee:");
                    jubilado.AniosDeAporte = int.Parse( Console.ReadLine());

                    Console.WriteLine("Ingrese su categoría:");
                    jubilado.Categoria = char.Parse( Console.ReadLine());

                    personaAAgregar = jubilado;

                    break;

                default:
                    Console.WriteLine("Opción Ingresada Incorrecta");
                    return;
            }

            _repositorio.Insertar(personaAAgregar);
            Console.WriteLine("Persona agregada correctamente");
        }
    }
}

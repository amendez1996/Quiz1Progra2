using System;

class Program
{
    //metodos

    //metodo salario neto
    static float CalcularSalarioNeto(int tipo, int horas, float precio, out float salarioOrdinario, out float aumento, out float bruto, out float deduccion)
    {
        salarioOrdinario = horas * precio;

        if (tipo == 1)
            aumento = salarioOrdinario * 0.15f;
        else if (tipo == 2)
            aumento = salarioOrdinario * 0.10f;
        else
            aumento = salarioOrdinario * 0.05f;

        bruto = salarioOrdinario + aumento;
        deduccion = bruto * 0.0917f;
        return bruto - deduccion;
    }

    //metodo datos empleado
    static void MostrarEmpleado(string cedula, string nombre, int tipo, int horas, float precio, float salarioOrdinario, float aumento, float bruto, float deduccion, float neto)
    {
        string tipoEmpleado = tipo == 1 ? "Operario" : tipo == 2 ? "Tecnico" : "Profesional";

        Console.WriteLine("\n Datos del Empleado ");
        Console.WriteLine("Cedula: " + cedula);
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Tipo: " + tipoEmpleado);
        Console.WriteLine("Salario por hora: " + precio);
        Console.WriteLine("Cantidad de horas: " + horas);
        Console.WriteLine("Salario Ordinario: " + salarioOrdinario);
        Console.WriteLine("Aumento: " + aumento);
        Console.WriteLine("Salario Bruto: " + bruto);
        Console.WriteLine("Deduccion CCSS: " + deduccion);
        Console.WriteLine("Salario Neto: " + neto);
    }

    //metodo estadisticas
    static void MostrarEstadisticas(int contOperarios, float sumaOperarios, int contTecnicos, float sumaTecnicos, int contProfesionales, float sumaProfesionales)
    {
        Console.WriteLine("\n Estadisticas Finales ");

        if (contOperarios > 0)
        {
            Console.WriteLine("Operarios: " + contOperarios);
            Console.WriteLine("Acumulado Neto Operarios: " + sumaOperarios);
            Console.WriteLine("Promedio Neto Operarios: " + (sumaOperarios / contOperarios));
        }
        if (contTecnicos > 0)
        {
            Console.WriteLine("Tecnicos: " + contTecnicos);
            Console.WriteLine("Acumulado Neto Tecnicos: " + sumaTecnicos);
            Console.WriteLine("Promedio Neto Tecnicos: " + (sumaTecnicos / contTecnicos));
        }
        if (contProfesionales > 0)
        {
            Console.WriteLine("Profesionales: " + contProfesionales);
            Console.WriteLine("Acumulado Neto Profesionales: " + sumaProfesionales);
            Console.WriteLine("Promedio Neto Profesionales: " + (sumaProfesionales / contProfesionales));
        }
    }

    //menu
    static void Menu()
    {
        int contOperarios = 0, contTecnicos = 0, contProfesionales = 0;
        float sumaOperarios = 0, sumaTecnicos = 0, sumaProfesionales = 0;

        int opcion = 0;

        do
        {
            Console.WriteLine("\n MENU ");
            Console.WriteLine("1. Registrar Empleado");
            Console.WriteLine("2. Ver Estadisticas");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: //registrar empleado
                    Console.WriteLine("\nDigite la cedula:");
                    string cedula = Console.ReadLine();

                    Console.WriteLine("Digite el nombre:");
                    string nombre = Console.ReadLine();

                    Console.WriteLine("Digite el tipo de empleado (1=Operario, 2=Tecnico, 3=Profesional):");
                    int tipo = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite la cantidad de horas trabajadas:");
                    int horas = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite el precio por hora:");
                    float precio = float.Parse(Console.ReadLine());

                    //calculo salario
                    float salarioOrdinario, aumento, bruto, deduccion;
                    float neto = CalcularSalarioNeto(tipo, horas, precio, out salarioOrdinario, out aumento, out bruto, out deduccion);

                    //datos empleado
                    MostrarEmpleado(cedula, nombre, tipo, horas, precio, salarioOrdinario, aumento, bruto, deduccion, neto);

                    //acumuladores y contadores
                    if (tipo == 1)
                    {
                        contOperarios++;
                        sumaOperarios += neto;
                    }
                    else if (tipo == 2)
                    {
                        contTecnicos++;
                        sumaTecnicos += neto;
                    }
                    else if (tipo == 3)
                    {
                        contProfesionales++;
                        sumaProfesionales += neto;
                    }
                    break;

                case 2: //estadisticas
                    MostrarEstadisticas(contOperarios, sumaOperarios, contTecnicos, sumaTecnicos, contProfesionales, sumaProfesionales);
                    break;

                case 3: //aslida
                    Console.WriteLine("\nSaliendo del programa.");
                    break;

                default:
                    Console.WriteLine("Opcion invalida. Intente de nuevo.");
                    break;
            }

        } while (opcion != 3);
    }

    //principal
    static void Main()
    {
        Menu(); 
    }
}

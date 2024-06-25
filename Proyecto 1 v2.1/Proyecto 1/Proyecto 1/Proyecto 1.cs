using System;

class Program
{
    const int maxSize = 10; // Tamaño máximo de los vectores

    static int[] numeroPago = new int[maxSize];
    static string[] fecha = new string[maxSize];
    static string[] hora = new string[maxSize];
    static string[] cedula = new string[maxSize];
    static string[] nombre = new string[maxSize];
    static string[] apellido1 = new string[maxSize];
    static string[] apellido2 = new string[maxSize];
    static int[] numeroCaja = new int[maxSize];
    static int[] tipoServicio = new int[maxSize];
    static string[] numeroFactura = new string[maxSize];
    static decimal[] montoPagar = new decimal[maxSize];
    static decimal[] montoComision = new decimal[maxSize];
    static decimal[] montoDeducido = new decimal[maxSize];
    static decimal[] montoPagaCliente = new decimal[maxSize];
    static decimal[] vuelto = new decimal[maxSize];

    static int count = 0;

    static void Main(string[] args)
    {
        int option;

        do
        {
            ShowMainMenu();
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    InicializarVectores();
                    break;
                case 2:
                    RealizarPagos();
                    break;
                case 3:
                    ConsultarPagos();
                    break;
                case 4:
                    ModificarPagos();
                    break;
                case 5:
                    EliminarPagos();
                    break;
                case 6:
                    SubmenuReportes();
                    break;
                case 7:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente nuevamente.");
                    break;
            }
        } while (option != 7);
    }

    static void ShowMainMenu()
    {
        Console.WriteLine("Menú Principal");
        Console.WriteLine("1. Inicializar Vectores");
        Console.WriteLine("2. Realizar Pagos");
        Console.WriteLine("3. Consultar Pagos");
        Console.WriteLine("4. Modificar Pagos");
        Console.WriteLine("5. Eliminar Pagos");
        Console.WriteLine("6. Submenú Reportes");
        Console.WriteLine("7. Salir");
        Console.Write("Seleccione una opción: ");
    }

    static void InicializarVectores()
    {
        count = 0;
        for (int i = 0; i < maxSize; i++)
        {
            numeroPago[i] = 0;
            fecha[i] = "";
            hora[i] = "";
            cedula[i] = "";
            nombre[i] = "";
            apellido1[i] = "";
            apellido2[i] = "";
            numeroCaja[i] = 0;
            tipoServicio[i] = 0;
            numeroFactura[i] = "";
            montoPagar[i] = 0;
            montoComision[i] = 0;
            montoDeducido[i] = 0;
            montoPagaCliente[i] = 0;
            vuelto[i] = 0;
        }
        Console.WriteLine("Vectores inicializados correctamente.");
        Console.WriteLine("Presione cualquier tecla para continuar");
             Console.ReadKey();
    }

    static void RealizarPagos()
    {
        while (count < maxSize)
        {
            numeroPago[count] = count + 1;
            Console.Write("Fecha (dd/mm/yyyy): ");
            fecha[count] = Console.ReadLine();
            Console.Write("Hora (hh:mm): ");
            hora[count] = Console.ReadLine();
            Console.Write("Cédula: ");
            cedula[count] = Console.ReadLine();
            Console.Write("Nombre: ");
            nombre[count] = Console.ReadLine();
            Console.Write("Primer Apellido: ");
            apellido1[count] = Console.ReadLine();
            Console.Write("Segundo Apellido: ");
            apellido2[count] = Console.ReadLine();

            Random rand = new Random();
            numeroCaja[count] = rand.Next(1, 4);

            Console.Write("Tipo de Servicio (1=Recibo de Luz, 2=Recibo Teléfono, 3=Recibo de Agua): ");
            tipoServicio[count] = int.Parse(Console.ReadLine());
            Console.Write("Número de Factura: ");
            numeroFactura[count] = Console.ReadLine();
            Console.Write("Monto a Pagar: ");
            montoPagar[count] = decimal.Parse(Console.ReadLine());

            switch (tipoServicio[count])
            {
                case 1:
                    montoComision[count] = montoPagar[count] * 0.04m;
                    break;
                case 2:
                    montoComision[count] = montoPagar[count] * 0.055m;
                    break;
                case 3:
                    montoComision[count] = montoPagar[count] * 0.065m;
                    break;
                default:
                    montoComision[count] = 0;
                    break;
            }

            montoDeducido[count] = montoPagar[count] - montoComision[count];

            do
            {
                Console.Write("Monto que paga el cliente: ");
                montoPagaCliente[count] = decimal.Parse(Console.ReadLine());

                if (montoPagaCliente[count] < montoPagar[count])
                {
                    Console.WriteLine("El monto pagado por el cliente no puede ser menor al monto a pagar.");
                }

            } while (montoPagaCliente[count] < montoPagar[count]);

            vuelto[count] = montoPagaCliente[count] - montoPagar[count];

            count++;

            Console.WriteLine("¿Desea realizar otro pago? (s/n): ");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() != "s")
            {
                break;
            }
        }

        if (count >= maxSize)
        {
            Console.WriteLine("Vectores Llenos.");
        }
    }

    static void ConsultarPagos()
    {
        Console.Write("Ingrese el número de factura a consultar: ");
        string numFactura = Console.ReadLine();

        for (int i = 0; i < count; i++)
        {
            if (numeroFactura[i] == numFactura)
            {
                Console.WriteLine($"Pago {numeroPago[i]}: {fecha[i]}, {hora[i]}, {cedula[i]}, {nombre[i]}, {apellido1[i]}, {apellido2[i]}, Caja {numeroCaja[i]}, Servicio {tipoServicio[i]}, Factura {numeroFactura[i]}, Monto Pagar {montoPagar[i]}, Comisión {montoComision[i]}, Deducido {montoDeducido[i]}, Pagado {montoPagaCliente[i]}, Vuelto {vuelto[i]}");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
                return;
            }
        }
        Console.WriteLine("Número de factura no encontrado.");
        Console.WriteLine("Presione cualquier tecla para continuar");
        Console.ReadKey();
    }

    static void ModificarPagos()
    {
        Console.Write("Ingrese el número de factura a modificar: ");
        string numFactura = Console.ReadLine();

        for (int i = 0; i < count; i++)
        {
            if (numeroFactura[i] == numFactura)
            {
                Console.Write("Fecha (dd/mm/yyyy): ");
                fecha[i] = Console.ReadLine();
                Console.Write("Hora (hh:mm): ");
                hora[i] = Console.ReadLine();
                Console.Write("Cédula: ");
                cedula[i] = Console.ReadLine();
                Console.Write("Nombre: ");
                nombre[i] = Console.ReadLine();
                Console.Write("Primer Apellido: ");
                apellido1[i] = Console.ReadLine();
                Console.Write("Segundo Apellido: ");
                apellido2[i] = Console.ReadLine();
                Console.Write("Tipo de Servicio (1=Recibo de Luz, 2=Recibo Teléfono, 3=Recibo de Agua): ");
                tipoServicio[i] = int.Parse(Console.ReadLine());
                Console.Write("Número de Factura: ");
                numeroFactura[i] = Console.ReadLine();
                Console.Write("Monto a Pagar: ");
                montoPagar[i] = decimal.Parse(Console.ReadLine());

                switch (tipoServicio[i])
                {
                    case 1:
                        montoComision[i] = montoPagar[i] * 0.04m;
                        break;
                    case 2:
                        montoComision[i] = montoPagar[i] * 0.055m;
                        break;
                    case 3:
                        montoComision[i] = montoPagar[i] * 0.065m;
                        break;
                    default:
                        montoComision[i] = 0;
                        break;
                }

                montoDeducido[i] = montoPagar[i] - montoComision[i];

                do
                {
                    Console.Write("Monto que paga el cliente: ");
                    montoPagaCliente[i] = decimal.Parse(Console.ReadLine());

                    if (montoPagaCliente[i] < montoPagar[i])
                    {
                        Console.WriteLine("El monto pagado por el cliente no puede ser menor al monto a pagar.");
                    }

                } while (montoPagaCliente[i] < montoPagar[i]);

                vuelto[i] = montoPagaCliente[i] - montoPagar[i];

                Console.WriteLine("Pago modificado correctamente.");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
                return;
            }
        }
        Console.WriteLine("Número de factura no encontrado.");
        Console.WriteLine("Presione cualquier tecla para continuar");
        Console.ReadKey();
    }

    static void EliminarPagos()
    {
        Console.Write("Ingrese el número de factura a eliminar: ");
        string numFactura = Console.ReadLine();

        for (int i = 0; i < count; i++)
        {
            if (numeroFactura[i] == numFactura)
            {
                for (int j = i; j < count - 1; j++)
                {
                    numeroPago[j] = numeroPago[j + 1];
                    fecha[j] = fecha[j + 1];
                    hora[j] = hora[j + 1];
                    cedula[j] = cedula[j + 1];
                    nombre[j] = nombre[j + 1];
                    apellido1[j] = apellido1[j + 1];
                    apellido2[j] = apellido2[j + 1];
                    numeroCaja[j] = numeroCaja[j + 1];
                    tipoServicio[j] = tipoServicio[j + 1];
                    numeroFactura[j] = numeroFactura[j + 1];
                    montoPagar[j] = montoPagar[j + 1];
                    montoComision[j] = montoComision[j + 1];
                    montoDeducido[j] = montoDeducido[j + 1];
                    montoPagaCliente[j] = montoPagaCliente[j + 1];
                    vuelto[j] = vuelto[j + 1];
                }
                count--;
                Console.WriteLine("Pago eliminado correctamente.");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
                return;
            }
        }
        Console.WriteLine("Número de factura no encontrado.");
        Console.WriteLine("Presione cualquier tecla para continuar");
        Console.ReadKey();
    }

    static void SubmenuReportes()
    {
        int option;
        do
        {
            ShowReportMenu();
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    VerTodosLosPagos();
                    break;
                case 2:
                    VerPagosPorTipoDeServicio();
                    break;
                case 3:
                    VerPagosPorCodigoDeCaja();
                    break;
                case 4:
                    VerDineroComisionadoPorServicios();
                    break;
                case 5:
                    Console.WriteLine("Regresando al menú principal...");
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente nuevamente.");
                    break;
            }
        } while (option != 5);
    }

    static void ShowReportMenu()
    {
        Console.WriteLine("Submenú Reportes");
        Console.WriteLine("1. Ver todos los Pagos");
        Console.WriteLine("2. Ver Pagos por tipo de Servicio");
        Console.WriteLine("3. Ver Pagos por código de caja");
        Console.WriteLine("4. Ver Dinero Comisionado por servicios");
        Console.WriteLine("5. Regresar Menú Principal");
        Console.Write("Seleccione una opción: ");
    }

    static void VerTodosLosPagos()
    {
        Console.WriteLine("Ver todos los Pagos:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Pago {numeroPago[i]}: {fecha[i]}, {hora[i]}, {cedula[i]}, {nombre[i]}, {apellido1[i]}, {apellido2[i]}, Caja {numeroCaja[i]}, Servicio {tipoServicio[i]}, Factura {numeroFactura[i]}, Monto Pagar {montoPagar[i]}, Comisión {montoComision[i]}, Deducido {montoDeducido[i]}, Pagado {montoPagaCliente[i]}, Vuelto {vuelto[i]}");
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }
    }

    static void VerPagosPorTipoDeServicio()
    {
        Console.Write("Ingrese el tipo de servicio a consultar (1=Recibo de Luz, 2=Recibo Teléfono, 3=Recibo de Agua): ");
        int tipo = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            if (tipoServicio[i] == tipo)
            {
                Console.WriteLine($"Pago {numeroPago[i]}: {fecha[i]}, {hora[i]}, {cedula[i]}, {nombre[i]}, {apellido1[i]}, {apellido2[i]}, Caja {numeroCaja[i]}, Servicio {tipoServicio[i]}, Factura {numeroFactura[i]}, Monto Pagar {montoPagar[i]}, Comisión {montoComision[i]}, Deducido {montoDeducido[i]}, Pagado {montoPagaCliente[i]}, Vuelto {vuelto[i]}");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
        }
    }

    static void VerPagosPorCodigoDeCaja()
    {
        Console.Write("Ingrese el código de caja a consultar (1, 2 o 3): ");
        int codigoCaja = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            if (numeroCaja[i] == codigoCaja)
            {
                Console.WriteLine($"Pago {numeroPago[i]}: {fecha[i]}, {hora[i]}, {cedula[i]}, {nombre[i]}, {apellido1[i]}, {apellido2[i]}, Caja {numeroCaja[i]}, Servicio {tipoServicio[i]}, Factura {numeroFactura[i]}, Monto Pagar {montoPagar[i]}, Comisión {montoComision[i]}, Deducido {montoDeducido[i]}, Pagado {montoPagaCliente[i]}, Vuelto {vuelto[i]}");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
        }
    }

    static void VerDineroComisionadoPorServicios()
    {
        decimal totalComision = 0;
        for (int i = 0; i < count; i++)
        {
            totalComision += montoComision[i];
        }
        Console.WriteLine($"Dinero comisionado por servicios: {totalComision}");
        Console.WriteLine("Presione cualquier tecla para continuar");
        Console.ReadKey();
    }
}

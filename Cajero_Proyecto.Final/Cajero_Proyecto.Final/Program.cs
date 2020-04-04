using System;

namespace Cajero_Proyecto.Final
{
    class Program
    {
        static void Main(string[] args)
        {
            int balanceg = 0, retiro = 0;
            int bg100 = 0, bg200 = 0, bg500 = 0, bg1000 = 0;
            int res100 = 0, res500 = 0, res200 = 0, res1000 = 0;
            int cant100 = 0, cant500 = 0, cant200 = 0, cant1000 = 0;

            bg1000 = 40; bg500 = 60; bg200 = 100; bg100 = 100;
            balanceg = (bg1000 * 1000) + (bg500 * 500) + (bg200 * 200) + (bg100 * 100);

            Console.WriteLine("Balance Inicial es de RD$" + balanceg + "\n");
            ConsoleKeyInfo tecla;
            do
            {
                Console.WriteLine("¿Qué cantidad deseas retirar?");
                if (Int32.TryParse(Console.ReadLine(), out retiro))
                {
                    Console.WriteLine("\n");
                    if (retiro > 40000)
                        Console.WriteLine("El monto máximo a es de RD$40,000.00" + "\n");
                    else if (retiro % 100 > 0)
                        Console.WriteLine("El monto ingresado no es válido." + "\n" +
                                 "La cantidad entregar debe ser múltiplo de 100." + "\n");
                    else if (retiro > balanceg)
                        Console.WriteLine("No disponemos de efectivo suficiente en este momento." + "\n" +
                                         "Por favor, vuelva más tarde. Disculpe los inconvenientes." + "\n");

                    else if (retiro >= 100)//Parámetros billetes
                    {
                        cant1000 = retiro / 1000;
                        res1000 = retiro % 1000;
                        cant500 = retiro / 500;
                        res500 = retiro % 500;
                        cant200 = retiro / 200;
                        res200 = retiro % 200;
                        cant100 = retiro / 100;
                        res100 = retiro % 100;

                        if (cant1000 <= bg1000 && res1000 == 0)//Operaciones enteras billetes de 1000
                        {
                            Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                            bg1000 = bg1000 - cant1000;
                            balanceg = balanceg - retiro;
                            Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + "\n" +
                                              "Balance billetes de 1000 = " + bg1000 + "\n" +
                                              "Balance billetes de 500 = " + bg500 + "\n" +
                                              "Balance billetes de 200 = " + bg200 + "\n" +
                                              "Balance billetes de 100 = " + bg100 + "\n");
                        }
                        else if (cant1000 > bg1000 && res1000 == 0)//Billetes de 1000 no son suficientes
                        {
                            cant500 = cant500 - bg1000 * 2;
                            if (cant500 <= bg500)//dan las de 500
                            {
                                Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                bg1000 = 0;
                                bg500 = bg500 - cant500;
                                balanceg = balanceg - retiro;
                                Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                  "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                  "Balance billetes de 500 = " + bg500 + "\n" +
                                                  "Balance billetes de 200 = " + bg200 + "\n" +
                                                  "Balance billetes de 100 = " + bg100 + "\n");
                            }
                            else//Billetes de 500 no son suficientes
                            {
                                cant200 = cant200 - bg1000 * 5;//Actualiza billetes de 200
                                bg1000 = 0;
                                if (bg500 % 2 == 0)
                                {
                                    cant200 = cant200 - bg500 * 5 / 2;//Billetes de 200 comletan la cantidad
                                    if (cant200 <= bg200)
                                    {
                                        Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                        bg1000 = 0;
                                        bg500 = 0;
                                        bg200 = bg200 - cant200;
                                        balanceg = balanceg - retiro;
                                        Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                          "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                          "Balance billetes de 500 = " + bg500 + "\n" +
                                                          "Balance billetes de 200 = " + bg200 + "\n" +
                                                          "Balance billetes de 100 = " + bg100 + "\n");
                                    }
                                    else//Billetes de 100 completan el monto
                                    {
                                        cant100 = cant100 - bg1000 * 10;
                                        cant100 = cant100 - bg500 * 5;
                                        cant100 = cant100 - bg200 * 2;
                                        if (cant100 <= bg100)
                                        {
                                            Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                            bg1000 = 0;
                                            bg500 = 0;
                                            bg200 = 0;
                                            bg100 = bg100 - cant100;
                                            balanceg = balanceg - retiro;
                                            Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                              "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                              "Balance billetes de 500 = " + bg500 + "\n" +
                                                              "Balance billetes de 200 = " + bg200 + "\n" +
                                                              "Balance billetes de 100 = " + bg100 + "\n");
                                        }
                                    }
                                }
                                else//Si los billetes de 500 no alcanzan para cubrir la cantidad completa y quedan 500 
                                {
                                    cant200 = (cant200 * 2 - bg500 * 5) / 2;//Entrega 2 billetes de 200 y 1 de 100
                                    bg500 = 0;
                                    if (cant200 <= bg200)
                                    {
                                        bg200 = bg200 - cant200;
                                        cant100 = 1;
                                        if (cant100 <= bg100)
                                        {
                                            Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");

                                            bg100 = bg100 - cant100;
                                            balanceg = balanceg - retiro;
                                            Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                              "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                              "Balance billetes de 500 = " + bg500 + "\n" +
                                                              "Balance billetes de 200 = " + bg200 + "\n" +
                                                              "Balance billetes de 100 = " + bg100 + "\n");
                                        }
                                    }
                                    else//Cuando no hay de 200
                                    {
                                        cant200 = cant200 - bg200;
                                        cant100 = cant200 * 2 + 1;
                                        if (cant100 <= bg100)
                                        {
                                            Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                            bg200 = 0;
                                            bg100 = bg100 - cant100;
                                            balanceg = balanceg - retiro;
                                            Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                              "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                              "Balance billetes de 500 = " + bg500 + "\n" +
                                                              "Balance billetes de 200 = " + bg200 + "\n" +
                                                              "Balance billetes de 100 = " + bg100 + "\n");
                                        }
                                    }
                                }
                            }
                        }//Terminan las operaciones con billetes de 1000 para retiros enteros                 
                        else if (cant500 % 2 == 1 && res500 == 0)//Operaciones con billetes de 500
                        {
                            if (cant1000 <= bg1000)
                            {
                                bg1000 = bg1000 - cant1000;
                                cant500 = 1;
                            }
                            else
                            {
                                cant1000 = cant1000 - bg1000;
                                cant500 = cant500 - bg1000 * 2;
                                bg1000 = 0;
                            }
                            if (cant500 <= bg500)
                            {
                                Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                bg500 = bg500 - cant500;
                                balanceg = balanceg - retiro;
                                Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + "\n" +
                                               "Balance billetes de 1000 = " + bg1000 + "\n" +
                                               "Balance billetes de 500 = " + bg500 + "\n" +
                                               "Balance billetes de 200 = " + bg200 + "\n" +
                                               "Balance billetes de 100 = " + bg100 + "\n");
                            }
                            else if (cant500 > bg500)//No hay suficientes billetes de 500
                            {
                                cant200 = cant200 - bg1000 * 5;
                                bg1000 = 0;
                                if (bg500 % 2 == 0 && bg500 > 0)
                                {
                                    cant200 = cant200 - bg500 * 5 / 2;
                                    if (cant200 <= bg200)
                                    {
                                        Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                        bg1000 = 0;
                                        bg500 = 0;
                                        bg200 = bg200 - cant200;
                                        balanceg = balanceg - retiro;
                                        Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                          "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                          "Balance billetes de 500 = " + bg500 + "\n" +
                                                          "Balance billetes de 200 = " + bg200 + "\n" +
                                                          "Balance billetes de 100 = " + bg100 + "\n");
                                    }
                                    else
                                    {
                                        cant100 = cant100 - bg1000 * 10;
                                        cant100 = cant100 - bg500 * 5;
                                        cant100 = cant100 - bg200 * 2;
                                        if (cant100 <= bg100)
                                        {
                                            Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                            bg1000 = 0;
                                            bg500 = 0;
                                            bg200 = 0;
                                            bg100 = bg100 - cant100;
                                            balanceg = balanceg - retiro;
                                            Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                              "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                              "Balance billetes de 500 = " + bg500 + "\n" +
                                                              "Balance billetes de 200 = " + bg200 + "\n" +
                                                              "Balance billetes de 100 = " + bg100 + "\n");
                                        }
                                    }
                                }
                                else//Si los billetes de 500 no alcanzan para cubrir la cantidad completa y quedan 500
                                {
                                    cant200 = (cant200 * 2 - bg500 * 5) / 2;
                                    bg500 = 0;
                                    if (cant200 <= bg200)
                                    {
                                        bg200 = bg200 - cant200;
                                        cant100 = 1;
                                        if (cant100 <= bg100)
                                        {
                                            Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                            bg100 = bg100 - cant100;
                                            balanceg = balanceg - retiro;
                                            Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                              "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                              "Balance billetes de 500 = " + bg500 + "\n" +
                                                              "Balance billetes de 200 = " + bg200 + "\n" +
                                                              "Balance billetes de 100 = " + bg100 + "\n");
                                        }
                                    }
                                    else
                                    {
                                        cant200 = cant200 - bg200;
                                        cant100 = cant200 * 2 + 1;
                                        if (cant100 <= bg100)
                                        {
                                            Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                            bg200 = 0;
                                            bg100 = bg100 - cant100;
                                            balanceg = balanceg - retiro;
                                            Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                              "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                              "Balance billetes de 500 = " + bg500 + "\n" +
                                                              "Balance billetes de 200 = " + bg200 + "\n" +
                                                              "Balance billetes de 100 = " + bg100 + "\n");
                                        }
                                    }
                                }
                            }
                        }
                        else if (cant100 % 5 != 0 && res100 == 0)//inicio operaciones billetes 100 y retiros de 200, 400 y 800
                        {
                            if (cant1000 <= bg1000)//Entrega completa con billetes de 1000
                            {
                                bg1000 = bg1000 - cant1000;
                                cant100 = cant100 - cant1000 * 10;
                            }
                            else if (cant1000 > bg1000)//Billetes de 1000 no son suficientes
                            {
                                cant1000 = cant1000 - bg1000;
                                cant100 = cant100 - bg1000 * 10;
                                bg1000 = 0;
                            }
                            if (cant100 > 5)
                            {
                                cant500 = cant100 / 5;
                                if (cant500 <= bg500)
                                {
                                    bg500 = bg500 - cant500;
                                    cant100 = cant100 - cant500 * 5;
                                }
                                else if (cant500 > bg500)
                                {
                                    cant500 = cant500 - bg500;
                                    cant100 = cant100 - bg500 * 5;
                                    bg500 = 0;
                                }
                                cant200 = cant100 / 2;
                                if (cant200 <= bg200)
                                {
                                    bg200 = bg200 - cant200;
                                    cant100 = cant100 - cant200 * 2;
                                    if (cant100 == 0)
                                    {
                                        Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                        balanceg = balanceg - retiro;
                                        Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                          "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                          "Balance billetes de 500 = " + bg500 + "\n" +
                                                          "Balance billetes de 200 = " + bg200 + "\n" +
                                                          "Balance billetes de 100 = " + bg100 + "\n");
                                    }
                                }
                                else if (cant200 > bg200)
                                {
                                    cant200 = cant200 - bg200;
                                    cant100 = cant100 - bg200 * 2;
                                    bg200 = 0;
                                    if (cant100 <= bg100)
                                    {
                                        Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                        bg100 = bg100 - cant100;
                                        balanceg = balanceg - retiro;
                                        Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                          "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                          "Balance billetes de 500 = " + bg500 + "\n" +
                                                          "Balance billetes de 200 = " + bg200 + "\n" +
                                                          "Balance billetes de 100 = " + bg100 + "\n");
                                    }
                                }
                            }
                            if (cant100 == 4)
                            {
                                cant200 = 2;
                                if (cant200 <= bg200)
                                {
                                    bg200 = bg200 - cant200;
                                    Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                    balanceg = balanceg - retiro;
                                    Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                      "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                      "Balance billetes de 500 = " + bg500 + "\n" +
                                                      "Balance billetes de 200 = " + bg200 + "\n" +
                                                      "Balance billetes de 100 = " + bg100 + "\n");
                                }
                                else if (cant200 > bg200)
                                {
                                    cant100 = cant100 - cant200 * 2;
                                    if (cant100 <= bg100)
                                    {
                                        Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                        bg100 = bg100 - cant100;
                                        balanceg = balanceg - retiro;
                                        Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                          "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                          "Balance billetes de 500 = " + bg500 + "\n" +
                                                          "Balance billetes de 200 = " + bg200 + "\n" +
                                                          "Balance billetes de 100 = " + bg100 + "\n");
                                    }
                                }
                            }
                            if (cant100 == 3)
                            {
                                cant200 = 1;
                                if (cant200 <= bg200)
                                {
                                    bg200 = bg200 - cant200;
                                    cant100 = cant100 - cant200 * 2;
                                }
                                else if (cant200 > bg200)
                                {
                                    cant100 = 3;
                                    if (cant100 <= bg100)
                                    {
                                        Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                        bg100 = bg100 - cant100;
                                        balanceg = balanceg - retiro;
                                        Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                          "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                          "Balance billetes de 500 = " + bg500 + "\n" +
                                                          "Balance billetes de 200 = " + bg200 + "\n" +
                                                          "Balance billetes de 100 = " + bg100 + "\n");
                                    }
                                }
                            }
                            if (cant100 == 2)
                            {
                                cant200 = 1;
                                if (cant200 <= bg200)
                                {
                                    bg200 = bg200 - cant200;

                                    Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                    balanceg = balanceg - retiro;
                                    Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                      "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                      "Balance billetes de 500 = " + bg500 + "\n" +
                                                      "Balance billetes de 200 = " + bg200 + "\n" +
                                                      "Balance billetes de 100 = " + bg100 + "\n");
                                }
                                else if (cant200 > bg200)
                                {
                                    cant100 = 2;
                                    if (cant100 <= bg100)
                                    {
                                        Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                        bg100 = bg100 - cant100;
                                        balanceg = balanceg - retiro;
                                        Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                          "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                          "Balance billetes de 500 = " + bg500 + "\n" +
                                                          "Balance billetes de 200 = " + bg200 + "\n" +
                                                          "Balance billetes de 100 = " + bg100 + "\n");
                                    }
                                }
                            }
                            if (cant100 == 1)
                            {
                                if (cant100 <= bg100)
                                {
                                    Console.WriteLine("El monto retirado es de RD$" + retiro + "\n");
                                    bg100 = bg100 - cant100;
                                    balanceg = balanceg - retiro;
                                    Console.WriteLine("Balance Cajero = " + "RD$" + balanceg + ".\n" +
                                                      "Balance billetes de 1000 = " + bg1000 + "\n" +
                                                      "Balance billetes de 500 = " + bg500 + "\n" +
                                                      "Balance billetes de 200 = " + bg200 + "\n" +
                                                      "Balance billetes de 100 = " + bg100 + "\n");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Debe digitar solo valores numéricos por favor." + "\n");
                }
                Console.WriteLine("(Esc) para salir." + "\n" +
                                  "(Enter) para continuar." + "\n");
                tecla = Console.ReadKey(true);
            } while (tecla.Key != ConsoleKey.Escape);
        }//main
    }//class program
}//namespace

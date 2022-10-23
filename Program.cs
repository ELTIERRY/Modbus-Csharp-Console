using System.Runtime.CompilerServices;
using System;
using System.Net;
using EasyModbus;

namespace Programa3
{
    class Program
    {
        static void Main()
        {
            int cont = 1;
            var modbusClient = new ModbusClient("127.0.0.1", 502);
            Console.Clear();

            while (true)
            {
                try 
                {
                    modbusClient.Connect();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar " + ex);
                }

                if (modbusClient.Connected)
                {
                    try
                    {
                        // Solicita 10 registros a partir do endereço 0
                        var meuArray = modbusClient.ReadHoldingRegisters(0,10);

                        Console.WriteLine($"Requisições: {cont++} -- {DateTime.Now}");
                        foreach (var item in meuArray)
                        {
                            Console.WriteLine($"Valor: {item}");
                        }
                        //Console.WriteLine(string.Join(' ', meuArray) + " as: " + DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro não tratado " + ex);
                    }
                    finally
                    {
                        modbusClient.Disconnect();
                    }
                }
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}

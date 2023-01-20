using System;
using EasyModbus;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.7.64", 502);
            modbusClient.Connect();
            while (true)
            {
                //q tuşuna basıldığında modbus haberleşmesi sonlandırılıyor. w tuşuna basıldığında ise holder değeri değiştiriliyor.
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    modbusClient.Disconnect();
                    break;
                }
                else if (Console.ReadKey().Key == ConsoleKey.W)
                {
                     Console.WriteLine("Hangi register'i değişeceksiniz?");
                    int holder = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Değiştirilecek değeri giriniz:");
                    int value = Convert.ToInt32(Console.ReadLine());
                    modbusClient.WriteSingleRegister(holder, value);
                    Console.WriteLine("Değiştirilen değer: " + modbusClient.ReadHoldingRegisters(holder, 1)[0]);
                    Console.WriteLine("**********************************************");
                }
            }
        }
    }
}
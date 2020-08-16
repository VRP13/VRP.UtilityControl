using System;
using System.Globalization;
using System.Resources;
using VRP.UtilityControl.BL.Controller;
using VRP.UtilityControl.BL.Model;

namespace VRP.UtilityControl.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("VRP.UtilityControl.CMD.Languages.Messages", typeof(Program).Assembly);
            
            Console.WriteLine(resourceManager.GetString("Greating", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();
            
            var userController = new UserController(name);
            var billController = new BillController(userController.CurrentUser);
            var paymentController = new PaymentController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите название вашего города:");
                var city = Console.ReadLine();
                
                Console.WriteLine("Введите название вашей улицы:");
                var street = Console.ReadLine();
                
                Console.WriteLine("Введите номер вашего дома:");
                var house = Console.ReadLine();
                
                Console.WriteLine("Введите номер вашей квартиры:");
                var flat = Console.ReadLine();
                userController.SetNewUserData(city, street, house, flat);
            }
            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Для продолжения выберите действие:");
                Console.WriteLine("Чтобы ввести новый счет нажмите клавишу 'B'.");
                Console.WriteLine("Чтобы ввести новый платеж нажмите клавишу 'P'.");
                Console.WriteLine("Для выхода из приложения нажмите клавишу 'Q'.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.B:
                        var utilitiesB = EnterBill();
                        billController.Add(utilitiesB.Utility, utilitiesB.Money);
                        foreach (var item in billController.Bill.Bills)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.P:
                        var utilitiesP = EnterPayment();
                        paymentController.Add(utilitiesP.Utility, utilitiesP.Money);
                        foreach (var item in paymentController.Payment.Payments)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
        }

        private static (Utility Utility, decimal Money) EnterBill()
        {
            Console.WriteLine("Введите название коммунальной услуги: ");
            var utility = Console.ReadLine();
            
            var money = ParseMoney();
            var tariff = ParseTariff();
            var volume = ParseVolume();


            var newUtility = new Utility(utility, tariff, volume);
            return (Utility: newUtility, Money: money);
        }
        private static (Utility Utility, decimal Money) EnterPayment()
        {
            Console.WriteLine("Введите название коммунальной услуги: ");
            var utility = Console.ReadLine();

            var money = ParseMoney();
            var tariff = ParseTariff();
            var volume = ParseVolume();


            var newUtility = new Utility(utility, tariff, volume);
            return (Utility: newUtility, Money: money);
        }
        private static decimal ParseMoney()
        {
            while(true)
            {
                Console.WriteLine("Введите денежную сумму(руб.): ");
                if(decimal.TryParse(Console.ReadLine(), out decimal value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Неверный формат денежной суммы.");
                }
            }
        }
        private static int ParseVolume()
        {
            while (true)
            {
                Console.WriteLine("Введите объем услуги: ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Неверный формат объема услуги.");
                }
            }
        }
        private static double ParseTariff()
        {
            while (true)
            {
                Console.WriteLine("Введите тариф: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Неверный формат тарифа.");
                }
            }
        }
    }

}

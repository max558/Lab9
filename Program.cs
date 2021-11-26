using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_09
{
    /*
     *  Смоделируйте работу простого калькулятора. 
     *  Программа должна запрашивать 2 числа, а затем – код операции (например, 1 – сложение, 2 – вычитание, 3 – произведение, 4 – частное). 
     *  После этого на консоль выводится ответ. 
     *  Используйте обработку исключений для защиты от ввода некорректных данных.
     */
    class Program
    {
        static void Main(string[] args)
        {
            //Поскольку числа могут быть и дрбными, то используем тип данных double
            Console.WriteLine("Вас приветствует калькулятор!");
            bool commandBool = false;
            double x = 0,
                y = 0;
            EnterData("X", ref x, ref commandBool);
            if (!commandBool)
            {
                ErrorCatchMessage();
                return;
            }
            EnterData("Y", ref y, ref commandBool);
            if (!commandBool)
            {
                ErrorCatchMessage();
                return;
            }

            int oper = 0;
            EnterData(ref oper, ref commandBool);

            if (!commandBool)
            {
                ErrorCatchMessage();
                return;
            }

            Calculator(x, y, oper);

            Console.ReadKey();
        }

        static void EnterData(string str, ref double value, ref bool res)
        {
            Console.Write("Введите число {0}= ", str);
            try
            {
                value = Convert.ToDouble(Console.ReadLine());
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
                Console.WriteLine("Ошибка: {0}", ex.Message);
            }
        }

        static void EnterData(ref int value, ref bool res)
        {
            res = false;
            Console.WriteLine("Введите код операции:");
            Console.WriteLine("1 - сложение");
            Console.WriteLine("2 - вычитание");
            Console.WriteLine("3 - произведение");
            Console.WriteLine("4 - частное");
            Console.Write("Ваш выбор: ");
            try
            {
                value = Convert.ToInt32(Console.ReadLine());
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ErrorCatchMessage()
        {
            Console.WriteLine("Калькулятор завершил работу из-за ошибки.");
            Console.ReadKey();
        }

        static void Calculator(double a, double b, int oper)
        {
            bool dataEnter = true;
            double res = 0;
            switch (oper)
            {
                case 1:
                    res = a + b;
                    break;
                case 2:
                    res = a - b;
                    break;
                case 3:
                    res = a * b;
                    break;
                case 4:
                    try
                    {
                        res = a / b;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                default:
                    dataEnter = false;
                    break;                    
            }

            if (dataEnter)
            {
                Console.WriteLine("Результат = {0}", res);
            }
            else
            {
                Console.WriteLine("Нет операции с указанным номером.");
                ErrorCatchMessage();
            }
        }
    }
}

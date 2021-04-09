using Calculate_2021.ViewModels.Base;
using Calculate_2021.Infrastructure.Commands;
using Calculate_2021.Infrastructure.Commands.Base;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading;

namespace Calculate_2021.ViewModels
{
    class MainWindowModel : ViewModel
    {
        public MainWindowModel()
        {
            #region Инициализация команд

            #region Base commands
            Operation_Percent = new LambdaCommand(On_Operation_Percent_Executed, Can_Operation_Percrnt_Execute);
            Operation_CE = new LambdaCommand(On_Operation_CE_Executed, Can_Operation_CE_Execute);
            Operation_C = new LambdaCommand(On_Operation_C_Executed, Can_Operation_C_Execute);
            Operation_DEL = new LambdaCommand(On_Operation_DEL_Executed, Can_Operation_DEL_Execute);
            Operation_One_Divided_By_X = new LambdaCommand(On_Operation_One_Divided_By_X_Executed, Can_Operation_One_Divided_By_X_Execute);
            Operation_To_The_Power_Of_X = new LambdaCommand(On_Operation_To_The_Power_Of_X_Executed, Can_Operation_To_The_Power_Of_X_Execute);
            Operation_Two_Roots_Of_X = new LambdaCommand(On_Operation_Two_Roots_Of_X_Executed, Can_Operation_To_The_Power_Of_X_Execute);
            Operation_Devide = new LambdaCommand(On_Operation_Devide_Executed, Can_Operation_Devide_Execute);
            Operation_Multiply = new LambdaCommand(On_Operation_Multiply_Executed, Can_Operation_Multiply_Execute);
            Operation_Minus = new LambdaCommand(On_Operation_Minus_Executed, Can_Operation_Minus_Execute);
            Operation_Plus = new LambdaCommand(On_Operation_Plus_Executed, Can_Operation_Plus_Execute);
            Operation_Sing_Change = new LambdaCommand(On_Operation_Sing_Change_Executed, Can_Operation_Sing_Change_Execute);
            Operation_Floating_Point = new LambdaCommand(On_Operation_Floating_Point_Executed, Can_Operation_Floating_Poitn_Execute);
            Operation_Answer = new LambdaCommand(On_Operation_Answer_Executed, Can_Operation_Answer_Execute);
            Operation_Clear_History = new LambdaCommand(On_Operation_Clear_History_Executed, Can_Operation_Clear_History_Execute);
            #endregion

            #region Keyboard commands

            Num_0 = new LambdaCommand(On_Num_0_Executed, Can_Num_0_Execute);
            Num_1 = new LambdaCommand(On_Num_1_Executed, Can_Num_1_Execute);
            Num_2 = new LambdaCommand(On_Num_2_Executed, Can_Num_2_Execute);
            Num_3 = new LambdaCommand(On_Num_3_Executed, Can_Num_3_Execute);
            Num_4 = new LambdaCommand(On_Num_4_Executed, Can_Num_4_Execute);
            Num_5 = new LambdaCommand(On_Num_5_Executed, Can_Num_5_Execute);
            Num_6 = new LambdaCommand(On_Num_6_Executed, Can_Num_6_Execute);
            Num_7 = new LambdaCommand(On_Num_7_Executed, Can_Num_7_Execute);
            Num_8 = new LambdaCommand(On_Num_8_Executed, Can_Num_8_Execute);
            Num_9 = new LambdaCommand(On_Num_9_Executed, Can_Num_9_Execute);

            #endregion

            #endregion
        }

        #region Application - Инициализация полей

        private string leftop = null; // Левый операнд
        private string operation = null; // Знак операции
        private string rightop = null; // Правый операнд
        private string result = null; // Результат операции
        private string history = null; // Последняя операция
        private ObservableCollection<string> listHistory = new ObservableCollection<string>() {"Истории нет..."}; // История операций
        private int limit = 0; // Максимальное количество символов на дисплее

        #endregion

        #region Application - Свойства

        #region Display

        public string Display
        {
            get => result;
            set => Set(ref result, value);
        }

        #endregion

        #region History

        public ObservableCollection<string> ShowHistory
        {
            get => listHistory;
        }

        #endregion

        #endregion

        #region Application - Команды

        #region Base

        #region Operation Percent

        public ICommand Operation_Percent { get; }

        private bool Can_Operation_Percrnt_Execute(object value) => true;
        private void On_Operation_Percent_Executed(object value)
        {
            RunAsyncCalculate("%");
        }

        #endregion

        #region Operation CE

        public ICommand Operation_CE { get; }

        private bool Can_Operation_CE_Execute(object value) => true;
        private void On_Operation_CE_Executed(object value)
        {
            RunAsyncCalculate("CE");
        }

        #endregion

        #region Operation C

        public ICommand Operation_C { get; }
        private bool Can_Operation_C_Execute(object value) => true;
        private void On_Operation_C_Executed(object value)
        {
            RunAsyncCalculate("C");
        }

        #endregion

        #region Operation DEL

        public ICommand Operation_DEL { get; }
        private bool Can_Operation_DEL_Execute(object value) => true;
        private void On_Operation_DEL_Executed(object value)
        {
            RunAsyncCalculate("DEL");
        }
        #endregion

        #region Operation 1 / x

        public ICommand Operation_One_Divided_By_X { get; }
        private bool Can_Operation_One_Divided_By_X_Execute(object value) => true;
        private void On_Operation_One_Divided_By_X_Executed(object value)
        {
            RunAsyncCalculate("1/x");
        }
        #endregion

        #region Operation 1 ^ x

        public ICommand Operation_To_The_Power_Of_X { get; }
        private bool Can_Operation_To_The_Power_Of_X_Execute(object value) => true;
        private void On_Operation_To_The_Power_Of_X_Executed(object value)
        {
            RunAsyncCalculate("x^2");
        }
        #endregion

        #region Operation 2 Roots of X

        public ICommand Operation_Two_Roots_Of_X { get; }
        private bool Can_Operation_Two_Roots_Of_X_Execute(object value) => true;
        private void On_Operation_Two_Roots_Of_X_Executed(object value)
        {
            RunAsyncCalculate("2√x");
        }
        #endregion

        #region Operation Devide

        public ICommand Operation_Devide { get; }
        private bool Can_Operation_Devide_Execute(object value) => true;
        private void On_Operation_Devide_Executed(object value)
        {
            RunAsyncCalculate("/");
        }

        #endregion

        #region Operation Multiply

        public ICommand Operation_Multiply { get; }
        private bool Can_Operation_Multiply_Execute(object value) => true;
        private void On_Operation_Multiply_Executed(object value)
        {
            RunAsyncCalculate("X");
        }

        #endregion

        #region Operation Minus

        public ICommand Operation_Minus { get; }
        private bool Can_Operation_Minus_Execute(object value) => true;
        private void On_Operation_Minus_Executed(object value)
        {
            RunAsyncCalculate("-");
        }

        #endregion

        #region Operation Plus

        public ICommand Operation_Plus { get; }
        private bool Can_Operation_Plus_Execute(object value) => true;
        private void On_Operation_Plus_Executed(object value)
        {
            RunAsyncCalculate("+");
        }
        #endregion

        #region Operation Sing Change

        public ICommand Operation_Sing_Change { get; }
        private bool Can_Operation_Sing_Change_Execute(object value) => true;
        private void On_Operation_Sing_Change_Executed(object value)
        {
            RunAsyncCalculate("+/-");
        }

        #endregion

        #region Operation Floating point

        public ICommand Operation_Floating_Point { get; }
        private bool Can_Operation_Floating_Poitn_Execute(object value) => true;
        private void On_Operation_Floating_Point_Executed(object value)
        {
            RunAsyncCalculate(".");
        }

        #endregion

        #region Operation Answer

        public ICommand Operation_Answer { get; }
        private bool Can_Operation_Answer_Execute(object value) => true;
        private void On_Operation_Answer_Executed(object value)
        {
            RunAsyncCalculate("=");
        }

        #endregion

        #region Operation Clear History

        public ICommand Operation_Clear_History { get; }
        private bool Can_Operation_Clear_History_Execute(object value) => true;
        private void On_Operation_Clear_History_Executed(object value)
        {
            RunAsyncCalculate("ORY");
        }

        #endregion

        #endregion

        #region Keyboard

        #region Num_0

        public ICommand Num_0 { get; }
        private bool Can_Num_0_Execute(object value) => true;
        private void On_Num_0_Executed(object value)
        {
            RunAsyncCalculate(0);
        }

        #endregion

        #region Num_1

        public ICommand Num_1 { get; }
        private bool Can_Num_1_Execute(object value) => true;
        private void On_Num_1_Executed(object value)
        {
            RunAsyncCalculate(1);
        }

        #endregion

        #region Num_2

        public ICommand Num_2 { get; }
        private bool Can_Num_2_Execute(object value) => true;
        private void On_Num_2_Executed(object value)
        {
            RunAsyncCalculate(2);
        }

        #endregion

        #region Num_3

        public ICommand Num_3 { get; }
        private bool Can_Num_3_Execute(object value) => true;
        private void On_Num_3_Executed(object value)
        {
            RunAsyncCalculate(3);
        }

        #endregion

        #region Num_4

        public ICommand Num_4 { get; }
        private bool Can_Num_4_Execute(object value) => true;
        private void On_Num_4_Executed(object value)
        {
            RunAsyncCalculate(4);
        }

        #endregion

        #region Num_5

        public ICommand Num_5 { get; }
        private bool Can_Num_5_Execute(object value) => true;
        private void On_Num_5_Executed(object value)
        {
            RunAsyncCalculate(5);
        }

        #endregion

        #region Num_6

        public ICommand Num_6 { get; }
        private bool Can_Num_6_Execute(object value) => true;
        private void On_Num_6_Executed(object value)
        {
            RunAsyncCalculate(6);
        }

        #endregion

        #region Num_7

        public ICommand Num_7 { get; }
        private bool Can_Num_7_Execute(object value) => true;
        private void On_Num_7_Executed(object value)
        {
            RunAsyncCalculate(7);
        }

        #endregion

        #region Num_8

        public ICommand Num_8 { get; }
        private bool Can_Num_8_Execute(object value) => true;
        private void On_Num_8_Executed(object value)
        {
            RunAsyncCalculate(8);
        }

        #endregion

        #region Num_9

        public ICommand Num_9 { get; }
        private bool Can_Num_9_Execute(object value) => true;
        private void On_Num_9_Executed(object value)
        {
            RunAsyncCalculate(9);
        }

        #endregion

        #endregion

        #endregion

        #region Application - Методы

        private void RunAsyncCalculate(object value)
        {
            // Получаем сообщение нажатой кнопки
            string messageInput = Convert.ToString(value);

            // Пытаемся привести сообщение в число
            double messageOutput;
            bool test = double.TryParse(messageInput, out messageOutput);

            // Если сообщение - число
            if(test)
            {
                if(limit < 14)
                {
                    // Выводим число на дисплей
                    Display += messageOutput;

                    // Если операция не задана
                    if (operation == null)
                    {
                        // Добавляем число к левому операнду
                        leftop += messageOutput;
                    }
                    // Если операция была установлена
                    else
                    {
                        // Добавляем число к правому операнду
                        rightop += messageOutput;
                    }

                    limit++;
                }
            }
            // Если сообщение не чисо
            else
            {
                // Если равно, то выводим результат
                if (messageInput == "=")
                {
                    try
                    {
                        if(listHistory[0] != "Истории нет...")
                        {
                            Display += messageInput;
                            history = $"{leftop} {operation} {rightop} {messageInput}";
                            Update_Right_Op();
                            history += $" {rightop}";
                            listHistory.Add(history);
                            Display += rightop;
                            operation = null;
                            limit = 0;
                        }
                        else
                        {
                            if(Display != null)
                            {
                                listHistory.Clear();
                                Display += messageInput;
                                history = $"{leftop} {operation} {rightop} {messageInput}";
                                Update_Right_Op();
                                history += $" {rightop}";
                                listHistory.Add(history);
                                Display += rightop;
                                operation = null;
                                limit = 0;
                            }
                        }
                    }
                    catch
                    {
                        //
                    }
                }
                // Если CE, то очищаем дисплей, переменные и историю
                else if(messageInput == "CE")
                {
                    leftop = null;
                    rightop = null;
                    operation = null;
                    Display = null;
                    limit = 0;
                    listHistory.Clear();
                    listHistory.Add("Истории нет...");
                }
                // Если C, то очищаем дисплей и переменные
                else if(messageInput == "C")
                {
                    leftop = null;
                    rightop = null;
                    operation = null;
                    Display = null;
                    limit = 0;
                }
                // Если CLEAR HISTORY, то очищаем историю
                else if(messageInput == "ORY")
                {
                    listHistory.Clear();
                    listHistory.Add("Истории нет...");
                }
                // Если DEL, то удаляем последний символ
                else if(messageInput == "DEL")
                {
                    try
                    {
                        if(Display != null)
                        {
                            Display = Display.Remove(Display.Length - 1);
                            limit--;
                        }
                    }
                    catch
                    {
                        Display = null;
                    }
                }
                // Если ., то вычисляем
                else if(messageInput == ".")
                {
                    if (rightop != null)
                    {
                        leftop = rightop;
                        rightop = null;
                    }
                    else
                    {
                        leftop = Convert.ToString(Convert.ToDouble(leftop) + 0.00001);
                        Display = leftop;
                    }
                }
                // Если +/-, то меняем тип данных числа
                else if(messageInput == "+/-")
                {
                    if (rightop != null)
                    {
                        leftop = rightop;
                        rightop = null;
                    }
                    else
                    {
                        leftop = Convert.ToString(Convert.ToDouble(leftop) * (-1));
                        Display = leftop;
                    }
                }
                // Получаем %, то переводим число в проценты
                else if(messageInput == "%")
                {
                    if(rightop != null)
                    {
                        leftop = rightop;
                        rightop = null;
                    }
                    else
                    {
                        leftop = Convert.ToString(Convert.ToDouble(leftop) / 100);
                        listHistory.Add(leftop);
                    }

                }
                // Если 1/x, то вычисляем
                else if(messageInput == "1/x")
                {
                    if (rightop != null)
                    {
                        leftop = rightop;
                        rightop = null;
                    }
                    else
                    {
                        leftop = Convert.ToString(1 / Convert.ToDouble(leftop));
                        Display = leftop;
                        listHistory.Add(leftop);
                    }
                }
                // Если 1^2, то вычисляем
                else if(messageInput == "x^2")
                {
                    if (rightop != null)
                    {
                        leftop = rightop;
                        rightop = null;
                    }
                    else
                    {
                        leftop = Convert.ToString(Convert.ToDouble(leftop) * Convert.ToDouble(leftop));
                        Display = leftop;
                        listHistory.Add(leftop);
                    }
                }
                // Если 2√x, то вычисляем
                else if(messageInput == "2√x")
                {
                    if(rightop != null)
                    {
                        leftop = rightop;
                        rightop = null;
                    }
                    else
                    {
                        leftop = Convert.ToString(2 * Math.Sqrt(Convert.ToDouble(leftop)));
                        Display = leftop;
                        listHistory.Add(leftop);
                    }
                }
                // Если +, то вычисляем
                else if(messageInput == "+")
                {
                    if (rightop != null)
                    {
                        Update_Right_Op();
                        leftop = rightop;
                        rightop = null;
                    }
                    else
                    {
                        operation = messageInput;
                        Display += operation;
                    }
                }
                // Если -, то вычисляем
                else if(messageInput == "-")
                {
                    if (rightop != null)
                    {
                        Update_Right_Op();
                        leftop = rightop;
                        rightop = null;
                    }
                    else
                    {
                        operation = messageInput;
                        Display += operation;
                    }
                }
                // Если X, то вычисляем
                else if(messageInput == "X")
                {
                    if (rightop != null)
                    {
                        Update_Right_Op();
                        leftop = rightop;
                        rightop = null;
                    }
                    else
                    {
                        operation = messageInput;
                        Display += operation;
                    }
                }
                // Если /, то вычисляем
                else if(messageInput == "/")
                {
                    if (rightop != null)
                    {
                        Update_Right_Op();
                        leftop = rightop;
                        rightop = null;
                    }
                    else
                    {
                        operation = messageInput;
                        Display += operation;
                    }
                }
            }
        }


        private void Update_Right_Op()
        {
            try
            {
                double resA, resB;

                bool num_1 = double.TryParse(leftop, out resA);
                bool num_2 = double.TryParse(rightop, out resB);

                // Если операция по 2м числам
                if((num_1) && (num_2))
                {
                    switch(operation)
                    {
                        case "+":
                            rightop = (resA + resB).ToString();
                            break;
                        case "-":
                            rightop = (resA - resB).ToString();
                            break;
                        case "X":
                            rightop = (resA * resB).ToString();
                            break;
                        case "/":
                            if((resA != 0) && (resB != 0))
                                rightop = (resA / resB).ToString();
                            break;
                    }
                }
            }
            catch
            {

            }
        }
        #endregion
    }
}

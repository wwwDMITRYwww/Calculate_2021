using System;
using System.Windows.Input;

namespace Calculate_2021.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;

            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Данный метод проверяет параметр команды на корректность
        /// и генерирует событие EventHandler.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>
        /// Данный метод реализует логику, которую должна выполнить созданная команда.
        /// </summary>
        /// <param name="parameter"></param>
        public abstract void Execute(object parameter);

    }
}

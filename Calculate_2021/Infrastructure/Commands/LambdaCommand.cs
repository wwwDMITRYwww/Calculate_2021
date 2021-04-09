using Calculate_2021.Infrastructure.Commands.Base;
using System;

namespace Calculate_2021.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(Execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Данный метод проверяет входящую команду на возможность её исполнения.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Данный метод получает тело входящей команды на исполнение.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter) => _execute(parameter);

    }
}

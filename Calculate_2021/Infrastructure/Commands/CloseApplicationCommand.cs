using Calculate_2021.Infrastructure.Commands.Base;
using System.Windows;

namespace Calculate_2021.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.MainWindow.Close();

    }
}

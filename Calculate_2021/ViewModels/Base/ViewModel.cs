using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculate_2021.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Задачей данного метода является уведомление графической части приложения о том,
        /// что внутри объекта изменилось какое то свойство.
        /// </summary>
        /// <param name="PropertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        /// <summary>
        /// Задачей данного метода является обновление свойства, для которого определено поле,
        /// в котором это свойство хранит свои данные.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="PropertyName"></param>
        /// <returns></returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value))
            {
                return false;
            }
            else
            {
                field = value;
                OnPropertyChanged(PropertyName);
            }

            return true;
        }

        /// <summary>
        /// Задачей данного метода является вызов метода Dispose, который в свою очередь освобождает упровалемые ресурсы.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        private bool _disposed;

        /// <summary>
        /// Задачей данного метода является освобождение упровляемых ресурсов.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _disposed) return;

            _disposed = true;
        }

    }
}

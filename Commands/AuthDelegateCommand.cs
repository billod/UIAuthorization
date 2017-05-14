using System;
using UIAuthorization.Providers;

namespace UIAuthorization.Commands
{
    /// <summary>
    /// Auth command
    /// </summary>
    public class AuthDelegateCommand : DelegateCommandBase
    {
        public AuthDelegateCommand(Action executeMethod)
            : base(op => executeMethod(), op => AuthProvider.Instance.CheckAccess(op))
        {
            if (executeMethod == null)
                throw new ArgumentNullException(nameof(executeMethod));
        }

        /// <summary>
        /// overwrite execute
        /// </summary>
        public void Execute()
        {
            base.Execute(null);
        }
    }

    /// <summary>
    /// Generic version of AuthDelegateCommand
    /// </summary>
    public class AuthDelegateCommand<T> : DelegateCommandBase
    {
        public AuthDelegateCommand(Action<T> executeMethod)
            : base(op => executeMethod((T)op), op => AuthProvider.Instance.CheckAccess(op))
        {
            if (executeMethod == null)
                throw new ArgumentNullException(nameof(executeMethod));

            Type genericType = typeof(T);
            if (genericType.IsValueType)
            {
                if ((!genericType.IsGenericType) || (!typeof(Nullable<>).IsAssignableFrom(genericType.GetGenericTypeDefinition())))
                {
                    throw new InvalidCastException("T for AuthDelegateCommand<T> is not an object nor Nullable.");
                }
            }
        }

        /// <summary>
        /// Overwrite canexecute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(T parameter)
        {
            return base.CanExecute(parameter);
        }

        /// <summary>
        /// Overwrite execute
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(T parameter)
        {
            base.Execute(parameter);
        }
    }
}

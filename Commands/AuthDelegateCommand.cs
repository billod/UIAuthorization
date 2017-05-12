using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using UIAuthorization.Commands;
using UIAuthorization.Providers;


namespace UIAuthorization.Commands
{
    public class AuthDelegateCommand : DelegateCommandBase
    {
        public AuthDelegateCommand(Action executeMethod)
            : base((op) => executeMethod(), (op) => AuthProvider.Instance.CheckAccess(op))
        {
            if (executeMethod == null)
                throw new ArgumentNullException("executeMethod");
        }

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
            : base((op) => executeMethod((T)op), (op) => AuthProvider.Instance.CheckAccess(op))
        {
            if (executeMethod == null)
                throw new ArgumentNullException("executeMethod");

            Type genericType = typeof(T);
            if (genericType.IsValueType)
            {
                if ((!genericType.IsGenericType) || (!typeof(Nullable<>).IsAssignableFrom(genericType.GetGenericTypeDefinition())))
                {
                    throw new InvalidCastException("T for AuthDelegateCommand<T> is not an object nor Nullable.");
                }
            }
        }

        public bool CanExecute(T parameter)
        {
            throw new NotSupportedException();
        }

        public void Execute(T parameter)
        {
            base.Execute(parameter);
        }
    }
}

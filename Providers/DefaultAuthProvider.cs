using System;
using System.Linq;

namespace UIAuthorization.Providers
{
    /// <summary>
    /// Default auth provider
    /// </summary>
    public class DefaultAuthProvider : AuthProvider
    {
        /// <summary>
        /// provider array.
        /// </summary>
        private static string[] _operations;

        /// <summary>
        /// Load the operation Access Control List
        /// </summary>
        public DefaultAuthProvider(object[] parameters)
        {
            _operations = parameters.Cast<string>().ToArray();
        }

        /// <summary>
        /// This method determines whether the user is authorize to perform the requested operation
        /// </summary>
        public override bool CheckAccess(string operation)
        {
            if (String.IsNullOrEmpty(operation))
                return false;

            if (_operations != null && _operations.Length > 0)
            {
                //  Match the requested operation with the ACL
                return _operations.Any(p => p.ToUpperInvariant() == operation.ToUpperInvariant());
            }
            return false;
        }

        /// <summary>
        /// This method determines whether the user is authorize to perform the requested operation
        /// </summary>
        public override bool CheckAccess(object commandParameter)
        {
            string operation = Convert.ToString(commandParameter);
            return CheckAccess(operation);
        }
    }
}

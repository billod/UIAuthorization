using System;

namespace UIAuthorization.Providers
{
    /// <summary>
    /// Auth Provider
    /// </summary>
    public abstract class AuthProvider
    {
        private static AuthProvider _instance;

        /// <summary>
        /// This method determines whether the user is authorize to perform the requested operation
        /// </summary>
        public abstract bool CheckAccess(string operation);

        /// <summary>
        /// This method determines whether the user is authorize to perform the requested operation
        /// </summary>
        public abstract bool CheckAccess(object commandParameter);

        /// <summary>
        /// No params init provider
        /// </summary>
        /// <typeparam name="TProvider"></typeparam>
        public static void Initialize<TProvider>() where TProvider : AuthProvider, new()
        {
            _instance = new TProvider();
        }

        /// <summary>
        /// params init provider
        /// </summary>
        /// <typeparam name="TProvider"></typeparam>
        /// <param name="parameters"></param>
        public static void Initialize<TProvider>(object[] parameters)
        {
            var constructorInfo = typeof(TProvider).GetConstructor(new[] { typeof(object[]) });
            if (constructorInfo != null) _instance = (AuthProvider)constructorInfo.Invoke(new object[] { parameters });
        }

        /// <summary>
        /// instance get_method
        /// </summary>
        public static AuthProvider Instance => _instance;
    }
}

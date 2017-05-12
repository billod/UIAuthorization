using System;
using System.Windows.Markup;
using UIAuthorization.Providers;

namespace UIAuthorization.Primitives
{
    /// <summary>
    /// Flag should show this UI Element
    /// </summary>
    [MarkupExtensionReturnType(typeof(bool))]
    public class AuthToEnabledExtension : MarkupExtension
    {
        /// <summary>
        /// Provider
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Structure function
        /// </summary>
        public AuthToEnabledExtension()
        {
            Operation = String.Empty;
        }

        /// <summary>
        /// No params structure function
        /// </summary>
        /// <param name="operation"></param>
        public AuthToEnabledExtension(string operation)
        {
            Operation = operation;
        }

        /// <summary>
        /// Get the object property value
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrEmpty(Operation)) return false;
            return AuthProvider.Instance.CheckAccess(Operation);
        }
    }
}
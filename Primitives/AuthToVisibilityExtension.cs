using System;
using System.Windows;
using System.Windows.Markup;
using UIAuthorization.Providers;

namespace UIAuthorization.Primitives
{
    /// <summary>
    /// 是否显示标记扩展
    /// </summary>
    [MarkupExtensionReturnType(typeof(Visibility))]
    public class AuthToVisibilityExtension : MarkupExtension
    {
        public string Operation { get; set; }

        /// <summary>
        /// 无参数构造函数
        /// </summary>
        public AuthToVisibilityExtension()
        {
            Operation = String.Empty;
        }

        /// <summary>
        /// 有参数构造函数
        /// </summary>
        /// <param name="operation"></param>
        public AuthToVisibilityExtension(string operation)
        {
            Operation = operation;
        }

        /// <summary>
        /// 重写ProvideValue方法，返回实例的期望的属性
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrEmpty(Operation)) return Visibility.Collapsed;

            if (AuthProvider.Instance.CheckAccess(Operation)) return Visibility.Visible;
            return Visibility.Hidden;
        }
    }
}
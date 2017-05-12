using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace UIAuthorization.Behaviors
{
    /// <summary>
    /// 自定义附加关闭窗体行为
    /// </summary>
    public class CloseWindowBehavior : Behavior<Window>
    {
        /// <summary>
        /// 注册附加属性
        /// </summary>
        public static readonly DependencyProperty ClosingCommandProperty = DependencyProperty.RegisterAttached(
            "ClosingCommand",
            typeof(ICommand),
            typeof(CloseWindowBehavior));

        /// <summary>
        /// 注册附加属性
        /// </summary>
        public static readonly DependencyProperty ClosedCommandProperty = DependencyProperty.RegisterAttached(
            "ClosedCommand",
            typeof(ICommand),
            typeof(CloseWindowBehavior));

        private Window _attachedWindow;

        /// <summary>
        /// 附加行为
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += OnWindowLoaded;
        }

        /// <summary>
        /// 移除行为
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= OnWindowLoaded;

            if (_attachedWindow != null)
            {
                _attachedWindow.Closing -= OnWindowClosing;
                _attachedWindow.Closed -= OnWindowClosed;
            }

            base.OnDetaching();
        }

        /// <summary>
        /// 加载行为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            _attachedWindow = (Window)sender;
            _attachedWindow.Closing += OnWindowClosing;
            _attachedWindow.Closed += OnWindowClosed;
        }

        /// <summary>
        /// 正在关闭中
        /// </summary>
        public ICommand ClosingCommand
        {
            get { return (ICommand)GetValue(ClosingCommandProperty); }
            set { SetValue(ClosingCommandProperty, value); }
        }

        /// <summary>
        /// 已经关闭
        /// </summary>
        public ICommand ClosedCommand
        {
            get { return (ICommand)GetValue(ClosedCommandProperty); }
            set { SetValue(ClosedCommandProperty, value); }
        }

        /// <summary>
        /// 关闭中行为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ClosingCommand != null)
            {
                e.Cancel = !ClosingCommand.CanExecute(null);
            }
        }

        /// <summary>
        /// 已经关闭行为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowClosed(object sender, EventArgs e)
        {
            ClosedCommand?.Execute(null);
        }
    }
}
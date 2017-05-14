using System.Windows;
using System.Windows.Input;
using UIAuthorization.Commands;
using UIAuthorization.Providers;

namespace UIAuthorization
{
    public class MainWindowVm
    {
        private ICommand _createCommand;
        public ICommand CreateCommand
        {
            get 
            { 
                return _createCommand ?? (_createCommand = new AuthDelegateCommand(() =>
                    MessageBox.Show("You can execute the Create command.", "Authorization"))
                ); 
            }
        }
        private ICommand _readCommand;
        public ICommand ReadCommand
        {
            get 
            { 
                return _readCommand ?? (_readCommand = new AuthDelegateCommand(() =>
                    MessageBox.Show("You can execute the Read command.", "Authorization"))
                ); 
            }
        }
        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get 
            { 
                return _updateCommand ?? (_updateCommand = new AuthDelegateCommand(() =>
                    MessageBox.Show("You can execute the Update command.", "Authorization"))
                ); 
            }
        }
        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get 
            { 
                return _deleteCommand ?? (_deleteCommand = new AuthDelegateCommand(() =>
                    MessageBox.Show("You can execute the Delete command.", "Authorization"))
                ); 
            }
        }

        private ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get 
            { 
                return _closeCommand ?? (_closeCommand = new AuthDelegateCommand(() =>
                    MessageBox.Show("You can close the window through the Close button on the Top Right corner.", "Authorization"))
                ); 
            }
        }

        private ICommand _closingCommand;
        public ICommand ClosingCommand
        {
            get
            {
                return _closingCommand ?? (_closingCommand = new DelegateCommandBase(
                    _ => { },
                    _ => AuthProvider.Instance.CheckAccess(ACL.CAN_CLOSE)
                ));
            }
        }
    }
}

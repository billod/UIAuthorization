using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using UIAuthorization.Providers;


namespace UIAuthorization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Login();
            InitializeComponent();
            DataContext = new MainWindowVM();
        }

        private void Login()
        {
            //  Try out each section to see how it applies to your view screen
            string[] myACL;
            
            //  You can click the 'Read' button and close the window
            myACL = new string[] {
                ACL.CAN_READ,
                ACL.CAN_CLOSE
            };

            //  You can see both images but cannot click any button or close the window
            /*
            myACL = new string[] {
                ACL.CAN_VIEW
            };
            */

            //  You can close the window but cannot click any button
            /*
            myACL = new string[] {
                ACL.CAN_CLOSE
            };
            */

            //  You can see both images and click any button but cannot close the window
            /*
            myACL = new string[] {
                ACL.CAN_VIEW,
                ACL.CAN_CREATE,
                ACL.CAN_READ,
                ACL.CAN_UPDATE,
                ACL.CAN_DELETE,
            };
            */

            //  Full trust
            /*
            myACL = new string[] {
                ACL.CAN_VIEW,
                ACL.CAN_CREATE,
                ACL.CAN_READ,
                ACL.CAN_UPDATE,
                ACL.CAN_DELETE,
                ACL.CAN_CLOSE
            };
            */

            AuthProvider.Initialize<DefaultAuthProvider>(myACL);
        }
    }
}

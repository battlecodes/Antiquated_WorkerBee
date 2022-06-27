using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WorkerBee.ViewModels;

namespace WorkerBee.Views
{
    /// <summary>
    /// Interaction logic for CreateNewBookView.xaml
    /// </summary>
    public partial class CreateNewBookView : UserControl
    {
        public CreateNewBookView()
        {
            InitializeComponent();
        }

        private void NameTextBox_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                Dispatcher.BeginInvoke(
                    DispatcherPriority.ContextIdle,
                    new Action(delegate ()
                    {
                        NameTextBox.Focus();
                    }));
            }
        }
    }
}

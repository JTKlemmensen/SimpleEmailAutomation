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

namespace SimpleEmailAutomation.Views
{
    /// <summary>
    /// Interaction logic for FieldLine.xaml
    /// </summary>
    public partial class FieldLine : UserControl
    {
        public FieldLine(string identifier = "",  bool canEdit = true, bool canDelete = true)
        {
            InitializeComponent();
            this.Identifier.Text = identifier;
            this.Identifier.IsEnabled = canEdit;
            this.DeleteButton.IsEnabled = canDelete;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Parent is StackPanel)
                (Parent as StackPanel).Children.Remove(this);
        }
    }
}
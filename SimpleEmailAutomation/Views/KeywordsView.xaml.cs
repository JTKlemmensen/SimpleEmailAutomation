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
    /// Interaction logic for KeywordsView.xaml
    /// </summary>
    public partial class KeywordsView : UserControl
    {
        public KeywordsView()
        {
            InitializeComponent();
        }

        public void AddKeyword(string identifier = "", bool canEdit = true, bool canDelete = true)
        {
            this.Keywords.Children.Add(new FieldLine(identifier, canEdit, canDelete));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Keywords.Children.Add(new FieldLine());
        }
    }
}

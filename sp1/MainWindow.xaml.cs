using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace sp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListView listView = new ListView();

        public MainWindow()
        {
            InitializeComponent();
            this.Width = 250;
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(9, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            Button button = new Button { Content = "Get threads" };
            grid.Children.Add(button);
            grid.Children.Add(listView);

            GridView gridView = new GridView();
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name",
                Width = 160,
                DisplayMemberBinding = new Binding("Name")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Id",
                Width = 50,
                DisplayMemberBinding = new Binding("Id"),
            });
            listView.View = gridView;

            Grid.SetRow(listView, 0);
            Grid.SetRow(button, 1);

            button.Click += Get_threads_Click;
        }

        private void Get_threads_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            Process[] p = Process.GetProcesses().OrderBy(x => x.Id).ToArray();
            foreach (Process item in p)
            {
                listView.Items.Add(new { Id = item.Id, Name = item.ProcessName });
            }
        }
    }
}

using DryIoc;
using GrpcService1;
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

namespace WpfAppgRPC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Container container;
        public MainWindow()
        {
            InitializeComponent();
            container = new Container();
            container.Register<IGrpcDataSourceProvider, GrpcDataSourceProvider>();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            using var serviceProvider = container.Resolve<IGrpcDataSourceProvider>();
            var client = serviceProvider.GetDataSourceClient();
            try
            {
                int id;
                if (!int.TryParse(txtBox.Text, out id)) return;
                var reply = await client.ReturnDataAsync(new DataRequest() { Id = id });
                txt.Text = reply.Data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

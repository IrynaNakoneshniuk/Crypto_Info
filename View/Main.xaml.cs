using System.Windows.Controls;


namespace Crypto_Info
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        public MainVM mainVM;
        public Main()
        {
            InitializeComponent();
            mainVM=new MainVM();
            DataContext = mainVM;
        }
    }
}

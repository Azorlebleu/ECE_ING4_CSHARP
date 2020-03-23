using countries;
using System.Threading.Tasks;
using System.Windows;



namespace Countries
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new VM();
        }

        private async void ComboBox_Selected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           
        
            POKEMON c = (POKEMON)CB.SelectedItem;
            //MessageBox.Show(c.CapitalCity);

            Task<Pokemon> task = Task.Run(() =>
            GetDataPokemons.GetPokemonAsync(73));
            Pokemon returnValue = await task;

            textBlock1.Text = "Name : " + returnValue.history;
        }
        
        /*

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void textBlock1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
        */
    }
}

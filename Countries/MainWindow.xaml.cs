using countries;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        public static System.Windows.Media.Color typeColor { get; set; }
        public static System.Windows.Media.Color typeColor2 { get; set; }


        public static System.Windows.Media.Color GetColourForType(String type)
        {
                    
            switch (type)
            {
                case "normal":
                    return (typeColor = Colors.Silver);
                case "fight":
                    return (typeColor = Colors.Firebrick);
                case "flying":
                    return (typeColor = Colors.MediumOrchid);  
                case "poison":
                    return (typeColor = Colors.DarkViolet);   
                case "ground":
                    return (typeColor = Colors.LightGoldenrodYellow);   
                case "rock":
                    return (typeColor = Colors.SandyBrown);   
                case "bug":
                    return (typeColor = Colors.YellowGreen);
                case "ghost":
                    return (typeColor = Colors.DarkMagenta);  
                case "fire":
                    return (typeColor = Colors.Orange);
                case "water":
                    return (typeColor = Colors.DeepSkyBlue);
                case "grass":
                    return (typeColor = Colors.LimeGreen);
                case "electrik":
                    return (typeColor = Colors.Yellow);
                case "psych":
                    return (typeColor = Colors.HotPink);
                case "ice":
                    return (typeColor = Colors.PowderBlue); 
                case "dragon":
                    return (typeColor = Colors.DarkOrchid);
            }
            return (typeColor = Colors.White);
        }

        private async void ComboBox_Selected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           
        
            POKEMON c = (POKEMON)CB.SelectedItem;

            Task<Pokemon> task = Task.Run(() =>
            GetDataPokemons.GetPokemonAsync(3));
            Pokemon returnValue = await task;

            textBlockName.Text = "Nom : " + returnValue.name;
            textBlockGeneration.Text = "Génération : " + returnValue.genera;
            textBlockHistoire.Text = "Histoire : " + returnValue.history;
            textBlockType1.Text = "Type : " + returnValue.type1;
            textBlockType2.Text = "\t" + returnValue.type2;

            LinearGradientBrush linear = new LinearGradientBrush();
            
            linear.StartPoint = new Point(0, 0);
            linear.EndPoint = new Point(1, 1);

           
            //linear.GradientStops.Add(new GradientStop() { Color = Colors.Blue, Offset = 0.75 });
            //linear.GradientStops.Add(new GradientStop() { Color = Colors.Green, Offset = 1.0 });
            //return new SolidColorBrush(Colors.Black);
            mainGrid.Background = linear;
            typeColor = GetColourForType(returnValue.type1);

            linear.GradientStops.Add(new GradientStop() { Color = typeColor, Offset = 0.0 });
            if (returnValue.type2 != null)
            {
                typeColor2 = GetColourForType(returnValue.type2);
                linear.GradientStops.Add(new GradientStop() { Color = typeColor2, Offset = 0.50 });
            }
            linear.GradientStops.Add(new GradientStop() { Color = Colors.White, Offset = 1 });
            image1.Source = new BitmapImage(new System.Uri(returnValue.sprite_front));
            image1s.Source = new BitmapImage(new System.Uri(returnValue.sprite_back));
            image2.Source = new BitmapImage(new System.Uri(returnValue.sprite_front_shiney));
            image2s.Source = new BitmapImage(new System.Uri(returnValue.sprite_back_shiney));
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

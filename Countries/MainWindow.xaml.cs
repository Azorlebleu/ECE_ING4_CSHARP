using countries;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            update_UI(1);
        }

        public static System.Windows.Media.Color typeColor { get; set; }
        public static System.Windows.Media.Color typeColor2 { get; set; }

        public string type_traduction = "";
        public int photo_actuelle = 0 ;
    
        public System.Windows.Media.Color GetColourForType(String type)
        {
            switch (type)
            {
                case "normal":
                    type_traduction = "Normal";
                    return (typeColor = Colors.Silver);
                case "fighting":
                    type_traduction = "Combat";
                    return (typeColor = Colors.Firebrick);
                case "flying":
                    type_traduction = "Vol";
                    return (typeColor = Colors.MediumOrchid);  
                case "poison":
                    type_traduction = "Poison";
                    return (typeColor = Colors.DarkViolet);   
                case "ground":
                    type_traduction = "Sol";
                    return (typeColor = Colors.LightGoldenrodYellow);   
                case "rock":
                    type_traduction = "Roche";
                    return (typeColor = Colors.SandyBrown);   
                case "bug":
                    type_traduction = "Insecte";
                    return (typeColor = Colors.YellowGreen);
                case "ghost":
                    type_traduction = "Spectre";
                    return (typeColor = Colors.DarkMagenta);  
                case "fire":
                    type_traduction = "Feu";
                    return (typeColor = Colors.Orange);
                case "water":
                    type_traduction = "Eau";
                    return (typeColor = Colors.DeepSkyBlue);
                case "grass":
                    type_traduction = "Plante";
                    return (typeColor = Colors.LimeGreen);
                case "electric":
                    type_traduction = "Électrique";
                    return (typeColor = Colors.Yellow);
                case "psychic":
                    type_traduction = "Psy";
                    return (typeColor = Colors.HotPink);
                case "ice":
                    type_traduction = "Glace";
                    return (typeColor = Colors.PowderBlue); 
                case "dragon":
                    type_traduction = "Dragon";
                    return (typeColor = Colors.DarkOrchid);
                case "fairy":
                    type_traduction = "Fée";
                    return (typeColor = Colors.MistyRose);
                case "steel":
                    type_traduction = "Acier";
                    return (typeColor = Colors.Gray);
                default:
                    return (typeColor = Colors.White);
            }
            
        }
        public async void update_UI(int pokemon_id)
        {

            
            //Appelle l'API pour prendre les données du pokémon sélectionné

            Task<Pokemon> task = Task.Run(() =>
            GetDataPokemons.GetPokemonAsync(pokemon_id));
            Pokemon returnValue = await task;
            VM vm = (VM)this.DataContext;

            vm.updatePokemon(returnValue.name, returnValue.history, returnValue.type1, returnValue.type2, returnValue.genera, returnValue.sprite_front, returnValue.sprite_back, returnValue.sprite_front_shiney, returnValue.sprite_back_shiney);
            LinearGradientBrush linear = new LinearGradientBrush();

            //Affiche le(s) type(s) du pokémon et fait changer le fond d'écran en conséquence
            typeColor = GetColourForType(returnValue.type1);
            returnValue.type1 = this.type_traduction;
            linear.GradientStops.Add(new GradientStop() { Color = typeColor, Offset = 0.3 });
            Type1.Background = new SolidColorBrush(typeColor);
            Type1.BorderBrush = new SolidColorBrush(typeColor);

            //On vérifie si le pokémon a un deuxième type (pas toujous le cas)
            if (returnValue.type2 != null)
            {
                typeColor2 = GetColourForType(returnValue.type2);
                linear.GradientStops.Add(new GradientStop() { Color = typeColor2, Offset = 0.75 });
                Type2.Background = new SolidColorBrush(typeColor);
                Type2.BorderBrush = new SolidColorBrush(typeColor);
                Type2.Visibility = Visibility.Visible;
            }
            else
            {
                Type2.Visibility = Visibility.Hidden;
            }


            //Ajoute différents éléments constants au fond d'écran
            linear.GradientStops.Add(new GradientStop() { Color = Colors.White, Offset = 1 });
            linear.StartPoint = new Point(0, 0);
            linear.EndPoint = new Point(1, 1);
            mainGrid.Background = linear; //Monte le fond d'écran créé sur l'application
        }


        public async void update_UI(object sender, RoutedEventArgs e)
        {

            int pokemon_id = (int)((Button)sender).Tag;

            this.photo_actuelle = 3;
            this.nouvelle_image(sender, e);
            //Appelle l'API pour prendre les données du pokémon sélectionné

            Task<Pokemon> task = Task.Run(() =>
            GetDataPokemons.GetPokemonAsync(pokemon_id));
            Pokemon returnValue = await task;
            VM vm = (VM)this.DataContext;

            LinearGradientBrush linear = new LinearGradientBrush();

            //Affiche le(s) type(s) du pokémon et fait changer le fond d'écran en conséquence
            typeColor = GetColourForType(returnValue.type1);
            returnValue.type1 =  this.type_traduction;
            linear.GradientStops.Add(new GradientStop() { Color = typeColor, Offset = 0.3 });
            Type1.Background = new SolidColorBrush(typeColor);
            Type1.BorderBrush = new SolidColorBrush(typeColor);
            //On vérifie si le pokémon a un deuxième type (pas toujous le cas)
            if (returnValue.type2 != null)
            {
                typeColor2 = GetColourForType(returnValue.type2);
                returnValue.type2 = this.type_traduction;
                linear.GradientStops.Add(new GradientStop() { Color = typeColor2, Offset = 0.75 });
                Type2.Background = new SolidColorBrush(typeColor);
                Type2.BorderBrush = new SolidColorBrush(typeColor);
                Type2.Visibility = Visibility.Visible;
            }
            else
            {
                //textBlockType2.Text = "";
                Type2.Visibility = Visibility.Hidden;
            }

            vm.updatePokemon(returnValue.name, returnValue.history, returnValue.type1, returnValue.type2, returnValue.genera, returnValue.sprite_front, returnValue.sprite_back, returnValue.sprite_front_shiney, returnValue.sprite_back_shiney);
            //Ajoute différents éléments constants au fond d'écran
            linear.GradientStops.Add(new GradientStop() { Color = Colors.White, Offset = 1 });
            linear.StartPoint = new Point(0, 0);
            linear.EndPoint = new Point(1, 1);
            mainGrid.Background = linear; //Monte le fond d'écran créé sur l'application
        }

        public void nouvelle_image(object sender, System.EventArgs e)
        {
            photo_actuelle = (photo_actuelle + 1) % 4;
            image_front.Visibility = Visibility.Hidden;
            image_back.Visibility = Visibility.Hidden;
            image_front_s.Visibility = Visibility.Hidden;
            image_back_s.Visibility = Visibility.Hidden;

            switch(photo_actuelle)
            {
                case 0:
                    image_front.Visibility = Visibility.Visible;
                    break;
                case 1:
                    image_back.Visibility = Visibility.Visible;
                    break;
                case 2:
                    image_front_s.Visibility = Visibility.Visible;
                    break;
                case 3:
                    image_back_s.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }

        }
        private void myPokemonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}

using Countries;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Countries
{


    class POKEMON
    {
        //
        /*
         * innotify..changed..., binding, observableCollection <pokemon>
         * class
         
*/
        public string Name { get; set; }
        public int Id{ get; set; }

        public POKEMON (int id, string n) { Id = id; Name = n;}
    }
    class VM : INotifyPropertyChanged
    {
        public VM()
        {
           
            M model = new M();

          /*  
            collection1 = new ObservableCollection<COUNTRY>();
            foreach(KeyValuePair<int, string> a in model.GetCountries())
            {
                COUNTRY c = new COUNTRY(a.Key, a.Value);
                collection1.Add(c);
            }*/



            collection_pokemons = new ObservableCollection<POKEMON>();
            foreach (KeyValuePair<int, string> a in model.GetPokemons())
            {
                POKEMON p = new POKEMON(a.Key, a.Value);
                collection_pokemons.Add(p);
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string History;
        private string Name;
        private string Type1;
        private string Type2;
        private string Genera;
        private BitmapImage Sprite_front_shiney;
        private BitmapImage Sprite_front;
        private BitmapImage Sprite_back_shiney;
        private BitmapImage Sprite_back;

        public void updatePokemon(string new_name, string new_history, string new_type1, string new_type2, string new_genera, string new_sprite_front, string new_sprite_back, string new_sprite_front_shiney, string new_sprite_back_shiney)
        {
            history = new_history;
            name = new_name;
            type1 = new_type1;
            type2 = new_type2;
            genera = new_genera;
            sprite_back = new BitmapImage(new System.Uri(new_sprite_back));
            sprite_front = new BitmapImage(new System.Uri(new_sprite_front));
            sprite_back_shiney = new BitmapImage(new System.Uri(new_sprite_back_shiney));
            sprite_front_shiney = new BitmapImage(new System.Uri(new_sprite_front_shiney));
        }

        public string history
        {
            get { return this.History; }
            set { this.History = value; OnPropertyChanged("history"); }
        }
        
        public string name
        {
            get { return this.Name; }
            set { this.Name = value; OnPropertyChanged("name"); }
        }
    
        public string genera
        {
            get { return this.Genera; }
            set { this.Genera = value; OnPropertyChanged("genera");}
        }
        public string type1
        {
            get { return this.Type1; }
            set { 
                this.Type1 = value;
                OnPropertyChanged("type1");
            }
        }
        public string type2
        {
            get { return this.Type2; }
            set { this.Type2 = value;
                OnPropertyChanged("type2");
            }
        }
        public BitmapImage sprite_back
        {
            get { return this.Sprite_back; }
            set { this.Sprite_back = value;
                OnPropertyChanged("sprite_back");
            }
        }
        public BitmapImage sprite_back_shiney
        {
            get { return this.Sprite_back_shiney; }
            set { this.Sprite_back_shiney = value;
                OnPropertyChanged("sprite_back_shiney");
            }
        }
        public BitmapImage sprite_front
        {
            get { return this.Sprite_front; }
            set { this.Sprite_front = value;
                OnPropertyChanged("sprite_front");
            }
        }
        public BitmapImage sprite_front_shiney
        {
            get { return this.Sprite_front_shiney; }
            set { this.Sprite_front_shiney = value;
                OnPropertyChanged("sprite_front_shiney");
            }
        }
        
        

 
        private ObservableCollection<POKEMON> collection_pokemons;
        public ObservableCollection<POKEMON> Collection
        {
            get { return this.collection_pokemons; }
            set { this.collection_pokemons = value; }
        }


        //private ObservableCollection<POKEMON> collectionPokemon;
    }


    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
    //String chaine = ;
    /*var x = JsonConvert.DeserializeObject<List<POKEMON>>(@"[{""Name"":""Joao""}]");

     foreach (var user in x.Name)
            {

               ComboboxItem item = new ComboboxItem();
                * item.Text = user.first_name + " " + user.last_name;
               item.Value = user.user_id;
               comboBox1.Items.Add(item);
            }
    */
    }


/*
 * 
 *     <Grid>
        <Image Source="Images/image1.jpg"  Height="Auto" Margin="648,47,0,278"/>
        <TextBox Text="{Binding MyValue, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Margin="90,89,452.6,262" />
        <ComboBox Name="CB" ItemsSource="{Binding Path=Collection}" Height="25" DisplayMemberPath="Name" SelectedItem="Path SelectedCountry" SelectionChanged="ComboBox_Selected" Margin="90,247,452.6,148" RenderTransformOrigin="1.171,0.46" />
        <TextBox HorizontalAlignment="Left" Margin="502,226,0,0" Text="{Binding ROBI, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" VerticalAlignment="Top" Height="72" Width="254"/>
        <TextBox HorizontalAlignment="Left" Margin="369,101,0,0" Text  = "{Binding ElementName = comboBox, Path = SelectedItem.Content, Mode = TwoWay, UpdateSourceTrigger = PropertyChanged}" Background = "{Binding ElementName = comboBox, Path = SelectedItem.Content}" VerticalAlignment="Top" Height="72" Width="254"/>
    </Grid>
 */

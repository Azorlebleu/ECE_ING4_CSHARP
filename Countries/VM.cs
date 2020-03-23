using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

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

    class COUNTRY
    {
        public string Name { get; set; }
        public string CapitalCity { get; set; }
        public COUNTRY (string n, string c) { Name = n; CapitalCity = c; }
    }

    class VM : INotifyPropertyChanged
    {
        public VM()
        {
            myValue = "ECE Paris";
            ROBI = "1";
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
        
        private string myValue;
        public string MyValue
        {
            get { return this.myValue; }
            set
            {
                this.myValue = value;
                OnPropertyChanged("MyValue");
                ROBI = (int.Parse(ROBI) + 1).ToString();
                //OnPropertyChanged("ROBI");
            }
        }
        private string robi;

        public string ROBI
        {
            get { return this.robi; }
            set
            {
                this.robi = value;
                OnPropertyChanged("ROBI");
            }
        }


        private COUNTRY selectedCountry;
        public COUNTRY SelectedCountry
        {
            get { return this.selectedCountry; }
            set
            {
                this.selectedCountry = value;
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

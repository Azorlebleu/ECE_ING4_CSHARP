using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace countries

{

    //A lot of classes that are needed to deserialize the JSON objects we receive
    public class Color
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class EggGroup
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class EvolutionChain
    {
        public string url { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class FlavorTextEntry
    {
        public string flavor_text { get; set; }
        public Language language { get; set; }
        public Version version { get; set; }
    }

    public class Language2
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Genera
    {
        public string genus { get; set; }
        public Language2 language { get; set; }
    }

    public class Generation
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class GrowthRate
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Habitat
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Language3
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Name
    {
        public Language3 language { get; set; }
        public string name { get; set; }
    }

    public class Area
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PalParkEncounter
    {
        public Area area { get; set; }
        public int base_score { get; set; }
        public int rate { get; set; }
    }

    public class Pokedex
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PokedexNumber
    {
        public int entry_number { get; set; }
        public Pokedex pokedex { get; set; }
    }

    public class Shape
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Variety
    {
        public bool is_default { get; set; }

    }


    public class Ability2
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Ability
    {
        public Ability2 ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }

    public class Form
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class GameIndice
    {
        public int game_index { get; set; }
        public Version version { get; set; }
    }

    public class Move2
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class MoveLearnMethod
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class VersionGroup
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class VersionGroupDetail
    {
        public int level_learned_at { get; set; }
        public MoveLearnMethod move_learn_method { get; set; }
        public VersionGroup version_group { get; set; }
    }

    public class Move
    {
        public Move2 move { get; set; }
        public List<VersionGroupDetail> version_group_details { get; set; }
    }

    public class Species
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Sprites
    {
        public string back_default { get; set; }
        public object back_female { get; set; }
        public string back_shiny { get; set; }
        public object back_shiny_female { get; set; }
        public string front_default { get; set; }
        public object front_female { get; set; }
        public string front_shiny { get; set; }
        public object front_shiny_female { get; set; }
    }

    public class Stat2
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Stat
    {
        public int base_stat { get; set; }
        public int effort { get; set; }
        public Stat2 stat { get; set; }
    }

    public class Type2
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Type
    {
        public int slot { get; set; }
        public Type2 type { get; set; }
        public String getName()
        {
            return (this.type.name);
        }
    }

    //More general classes that use some of the classes above


    //First class used for the 1st JSON request used
    //Related function : GetPokemonAsync(int id_pokemon)
    public class PokemonData
    {
        public List<Ability> abilities { get; set; }
        public int base_experience { get; set; }
        public List<Form> forms { get; set; }
        public List<GameIndice> game_indices { get; set; }
        public int height { get; set; }
        public List<object> held_items { get; set; }
        public int id { get; set; }
        public bool is_default { get; set; }
        public string location_area_encounters { get; set; }
        public List<Move> moves { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public Species species { get; set; }
        public Sprites sprites { get; set; }
        public List<Stat> stats { get; set; }
        public List<Type> types { get; set; }
        public int weight { get; set; }

        //Get name
        public String GetName()
        {
            String name = this.name;
            return (name);
        }

        //Get the pokemon's type(s) ; return type is an array, that can be either of length 1, either 2.
        public String[] GetTypesName()
        {
            if (this.types.Count == 2)
            {
                String[] types = new string[2];
                types[0] = this.types[0].getName();
                types[1] = this.types[1].getName();
                return types;
            }
            else
            {
                String[] types = new string[1];
                types[0] = this.types[0].getName();
                return types;
            }

        }

        //Sprites part ; sprites represent the images of the pokemon. Each pokemon has 4 sprites : back/front, and shiney/not shiney.
        //A shiney pokemon is just the same pokemon with a different color. 
        public String GetSpriteFront()
        {
            String sprite = this.sprites.front_default;
            return (sprite);
        }
        public String GetSpriteBack()
        {
            String sprite = this.sprites.back_default;
            return (sprite);
        }
        public String GetSpriteFrontShiney()
        {
            String sprite = this.sprites.front_shiny;
            return (sprite);
        }
        public String GetSpriteBackShiney()
        {
            String sprite = this.sprites.back_shiny;
            return (sprite);
        }

        //Return all sprites in an array
        public String[] GetAllSprites()
        {
            String[] sprites = new string[4];
            sprites[0] = this.GetSpriteFront();
            sprites[1] = this.GetSpriteBack();
            sprites[2] = this.GetSpriteFrontShiney();
            sprites[3] = this.GetSpriteBackShiney();
            return (sprites);
        }

        //Returns all the important information needed in this pokémon's class
        public Tuple<String, String[], String[]> GetAll()
        {
            return (Tuple.Create(this.GetName(), this.GetTypesName(), this.GetAllSprites()));
        }
    }

    //Second class used for the 2nd JSON request used
    //Related function : GetPokemonBackgroundAsync(int id_pokemon)
    public class PokemonBackground
    {
        public int base_happiness { get; set; }
        public int capture_rate { get; set; }
        public Color color { get; set; }
        public List<EggGroup> egg_groups { get; set; }
        public EvolutionChain evolution_chain { get; set; }
        public object evolves_from_species { get; set; }
        public List<FlavorTextEntry> flavor_text_entries { get; set; }
        public List<object> form_descriptions { get; set; }
        public bool forms_switchable { get; set; }
        public int gender_rate { get; set; }
        public List<Genera> genera { get; set; }
        public Generation generation { get; set; }
        public GrowthRate growth_rate { get; set; }
        public Habitat habitat { get; set; }
        public bool has_gender_differences { get; set; }
        public int hatch_counter { get; set; }
        public int id { get; set; }
        public bool is_baby { get; set; }
        public string name { get; set; }
        public List<Name> names { get; set; }
        public int order { get; set; }
        public List<PalParkEncounter> pal_park_encounters { get; set; }
        public List<PokedexNumber> pokedex_numbers { get; set; }
        public Shape shape { get; set; }
        public List<Variety> varieties { get; set; }

        //Usually it is some text, that is available in many languages. We take the french one.

        //Gets the background story of the Pokémon
        public String GetHistory()
        {
            int nb = this.flavor_text_entries.Count;
            for (int i = 0; i < nb; i++)
            {
                if (this.flavor_text_entries[i].language.name == "fr")
                {
                    return (this.flavor_text_entries[i].flavor_text);
                }
            }

            //In case nothing's been found
            return ("Text Not Found");
        }

        //Gets the "Class" name of the Pokémon
        public String GetGenera()
        {

            int nb = this.genera.Count;
            for (int i = 0; i < nb; i++)
            {
                if (this.genera[i].language.name == "fr")
                {
                    return (this.genera[i].genus);
                }
            }
            return ("Text Not Found");
        }

        //Gets the name of the Pokémon (in French)
        public String GetName()
        {
            int nb = this.names.Count;
            for (int i = 0; i < nb; i++)
            {
                if (this.names[i].language.name == "fr")
                {
                    return (this.names[i].name);
                }
            }
            return ("Text Not Found");
        }

        //Returns all the important information needed in this pokémon's class
        public Tuple<String, String, String> GetAll()
        {
            return Tuple.Create(this.GetHistory(), this.GetGenera(), this.GetName());
        }
    }
    public class Pokemon
    {
        public String sprite_front { get; set; }
        public String sprite_back { get; set; }
        public String sprite_front_shiney { get; set; }
        public String sprite_back_shiney { get; set; }
        public String name { get; set; }
        public String type1 { get; set; }
        public String type2 { get; set; }
        public String history { get; set; }
        public String genera { get; set; }

        //instanciates a new pokemon which uses the data of the two other classes (but only the useful one).

        public Pokemon(Tuple<String, String[], String[]> pokemon_data, Tuple<String, String, String> pokemon_background)
        {
            this.type1 = pokemon_data.Item2[0];
            if (pokemon_data.Item2.Length == 2)
            {
                this.type2 = pokemon_data.Item2[1];
            }
            else { this.type2 = null; }

            this.sprite_front = pokemon_data.Item3[0];
            this.sprite_back = pokemon_data.Item3[1];
            this.sprite_front_shiney = pokemon_data.Item3[2];
            this.sprite_back_shiney = pokemon_data.Item3[3];
            this.history = pokemon_background.Item1;
            this.genera = pokemon_background.Item2;
            this.name = pokemon_background.Item3;
        }
        public void SeeAll()
        {
            Console.WriteLine(this.name);
            Console.WriteLine(this.history);
            Console.WriteLine(this.type1 + this.type2);
            Console.WriteLine(this.genera);
            Console.WriteLine(this.sprite_front);
            Console.WriteLine(this.sprite_back);
            Console.WriteLine(this.sprite_front_shiney);
            Console.WriteLine(this.sprite_back_shiney);
        }
    }


    public class GetDataPokemons
    {

        //Corresponds to the 1st JSON used to get data on 1 pokémon
        public static async Task<PokemonData> GetPokemonDataAsync(int id_pokemon)
        {
            String path = "https://pokeapi.co/api/v2/pokemon/" + id_pokemon.ToString();
             var client = new HttpClient();
            var content = await client.GetStringAsync(path);
            PokemonData pokemon = JsonConvert.DeserializeObject<PokemonData>(content);
            return pokemon;
        }

        //Corresponds to the 2nd JSON used to get data on 1 pokémon
        public static async Task<PokemonBackground> GetPokemonBackgroundAsync(int id_pokemon)
        {
            String path = "https://pokeapi.co/api/v2/pokemon-species/" + id_pokemon.ToString();
             var client = new HttpClient();
            var content = await client.GetStringAsync(path);
            PokemonBackground pokemon_background = JsonConvert.DeserializeObject<PokemonBackground>(content);
            return pokemon_background;
        }

       public static async Task<Pokemon> GetPokemonAsync(int id_pokemon)
        {
            PokemonData pokemon_data = await GetPokemonDataAsync(id_pokemon);
            PokemonBackground pokemon_background = await GetPokemonBackgroundAsync(id_pokemon);

            Pokemon pokemon = new Pokemon(pokemon_data.GetAll(), pokemon_background.GetAll());
            return (pokemon);
        }
 
    }

}
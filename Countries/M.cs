using System.Collections.Generic;

namespace Countries
{
    class M
    {
        public Dictionary<int, string> GetPokemons()
        {
         
            Dictionary<int, string> dict = new Dictionary<int, string>();
            string[] Pokemons = new string[] { "Bulbizare", "Herbizarre", "Florizarre" };

            for (int i = 0; i < Pokemons.Length; i++)
            {
                dict.Add(i + 1, Pokemons[i]);
            }

            return dict;
        }
    }
}

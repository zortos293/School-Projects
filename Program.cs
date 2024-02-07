using System.Collections.ObjectModel;
using System.ComponentModel;

class Program
{
    class Charmander
    {
        public String Name { get; set; }
        public String Type = "Fire";
        public List<String> Attack = ["Battle Cry"];
        public int Attack_count = 10;

    }
    class PokeBall
    {
        
        // Pokemon inside the pokeball
        public Charmander Charmander;
       
    }

    class Trainer
    {
        public String Name { get; set; }
        // Belt has 6 Pokeballs
        public List<PokeBall> Belt = new List<PokeBall>();


        // Use the pokeball to use the pokemon then return the pokemon
        public Charmander UsePokeBall(int PokeBallIndex)
        {
            Charmander Charmander = Belt[PokeBallIndex].Charmander;
            Belt[PokeBallIndex].Charmander = null;
            return Charmander;
        }

        // Add the pokemon to the pokeball
        public void 
        
    }   
    static void Main(string[] args)
    {
        Charmander charmander = new Charmander();
        
        
        Boolean Loop = true;
        while (Loop)
        {

            Console.Write("Name your Charmander :");
            String Name = Console.ReadLine();
            charmander.Name = Name;
            Console.WriteLine("Your Charmander's Name is " + charmander.Name);
            for (int i = 0; i < charmander.Attack_count; i++)
            {
                Console.WriteLine(charmander.Name + " Used " + charmander.Attack[0]);
            }
        }
        
    }
}



using System;
using System.Collections.Generic;

namespace expression_members
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            Bug bug1 = new Bug("Spider", "Arachnid", new List<string>(){"a shoe", " Jackie"}, new List<string>(){"unsuspecting victims"});
            Bug bug2 = new Bug("Wasp", "Hymenoptera", new List<string>(){"Raid Wasp Spray", " a flyswatter"}, new List<string>(){"more unsuspecting victims"});

            Console.WriteLine($"The {bug1.FormalName} predators are {bug1.PredatorList()} and its prey are {bug1.PreyList()}");
            Console.WriteLine();
            Console.WriteLine($"The {bug2.FormalName}'s predators are {bug2.PredatorList()} and its prey are {bug2.PreyList()}");

            Console.WriteLine();

            Console.WriteLine(bug1.Eat("unsuspecting victims"));
            Console.WriteLine(bug2.Eat("tacos"));

        }
    }
}

    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public ICollection<string> Predators { get; } = new List<string>();
        public ICollection<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        public string FormalName => $"{this.Name} the {this.Species}";
        // {
        //     get
        //     {
        //         return $"{this.Name} the {this.Species}";
        //     }
        // }

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        // Convert this method to an expression member
        public string PreyList() => string.Join(",", this.Prey);
        // {
        //     var commaDelimitedPrey = string.Join(",", this.Prey);
        //     return commaDelimitedPrey;
        // }

        // Convert this method to an expression member
        public string PredatorList() => string.Join(",", this.Predators);
        // {
        //     var commaDelimitedPredators = string.Join(",", this.Predators);
        //     return commaDelimitedPredators;
        // }

        // Convert this to expression method (hint: use a C# ternary)
        public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry";
        // {
        //     if (this.Prey.Contains(food))
        //     {
        //         return $"{this.Name} ate the {food}.";
        //     } else {
        //         return $"{this.Name} is still hungry.";
        //     }
        // }
    }

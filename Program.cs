using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human one = new Human("Jonathan");
            System.Console.WriteLine($"{one.Name}, strength: {one.Strength}, intelligence: {one.Intelligence}, dexterity: {one.Dexterity}, health: {one.health}");
            Wizard two = new Wizard("Harry");
            System.Console.WriteLine($"{two.Name}, strength: {two.Strength}, intelligence: {two.Intelligence}, dexterity: {two.Dexterity}, health: {two.health}");
            Ninja three = new Ninja("Naruto");
            System.Console.WriteLine($"{three.Name}, strength: {three.Strength}, intelligence: {three.Intelligence}, dexterity: {three.Dexterity}, health: {three.health}");
            Samurai four = new Samurai("Jack");
            System.Console.WriteLine($"{four.Name}, strength: {four.Strength}, intelligence: {four.Intelligence}, dexterity: {four.Dexterity}, health: {four.health}");
            // two.Attack(four);
            // System.Console.WriteLine(two.health);
            // three.Attack(one);
            // System.Console.WriteLine(one.health);
            // four.Attack(two);
            // System.Console.WriteLine(two.health);
            // four.Attack(two);
            // four.Attack(two);
            // four.Attack(two);
            // four.Attack(two);
            // four.Attack(two);
            // four.Attack(two);
            // four.Attack(two);
            // four.Attack(two);
            // four.Attack(two);
            // four.Attack(two);
            // four.Attack(two);
            // four.Attack(two);
            // four.Attack(two);
            // four.Attack(two);
            // System.Console.WriteLine(two.health);
            // two.Heal(two);
            // System.Console.WriteLine(two.health);
            // four.Meditate();
            // System.Console.WriteLine(four.health);
            // three.Steal(one);
            // System.Console.WriteLine(one.health);
            // System.Console.WriteLine(three.health);
        }
    }

    public class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        public int health;

        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }

        public Human(string name, int str, int intel, int dex, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }

        public virtual int Attack(Human target)
        {
            int dmg = Strength * 3;
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }
    }

    public class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            health = 50;
            Intelligence = 25;
        }

        public override int Attack(Human target)
        {
            int dmg = Intelligence * 5;
            target.health -= dmg;
            health += dmg;
            System.Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage and healed for {dmg} health!");
            return target.health;
        }

        public int Heal(Human target)
        {
            int healAmt = Intelligence * 10;
            target.health += healAmt;
            System.Console.WriteLine($"{Name} has healed {target.Name} for {healAmt} health!");
            return target.health;
        }
    }

    public class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 175;
        }

        public override int Attack(Human target)
        {
            Random rand = new Random();
            int chance = rand.Next(1,11);
            if(chance <= 2)
            {
                int dmg = 10 + (Dexterity * 5);
                target.health -= dmg;
                System.Console.WriteLine($"{Name} attacked {target.Name} for {dmg}!");
                return target.health;
            }
            else
            {
            int dmg = Dexterity * 5;
            target.health -= dmg;
            System.Console.WriteLine($"{Name} attacked {target.Name} for {dmg}!");
            return target.health;
            }
        }

        public int Steal(Human target)
        {
            int dmg = 5;
            target.health -= dmg;
            health += dmg;
            System.Console.WriteLine($"{target.Name} has been mugged and loses 5 health, while {Name} gains 5 health from stealing.");
            return target.health;
        }
    }

    public class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
        }

        public override int Attack(Human target)
        {
            if(target.health < 50)
            {
                target.health = 0;
                System.Console.WriteLine($"{Name} attacked, {target.Name} has been critically hit, {target.Name} has died!");
                return target.health;
            }
            return base.Attack(target);
        }

        public int Meditate()
        {
            health = 200;
            System.Console.WriteLine($"{Name} meditates and health has been fully restored!");
            return health;
        }
    }
}

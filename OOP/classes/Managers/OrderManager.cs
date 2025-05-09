using OOP.classes.OrderManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.classes.PizzaTypes;
using OOP.classes.PizzaComponents;

namespace OOP.classes.Managers
{
    public class OrderManager
    {
        public OrderManager(List<Ingredient> ingredients, List<Border> borders,
            List<PizzaBase> bases, List<Order> orderHistory,
            List<Pizza> systemPizzas, List<Pizza> customPizzas)
        {
            this.orderHistory = orderHistory;
            this.ingredients = ingredients;
            this.borders = borders;
            this.bases = bases;

            this.pizzas = systemPizzas;
            this.userCustomRecipes = customPizzas;
        }

        public List<Ingredient> ingredients;
        public List<Border> borders;
        public List<PizzaBase> bases;
        public List<Pizza> pizzas;

        public List<Pizza> userCustomRecipes;

        public List<Order> orderHistory;

        public void makeAnOrder()
        {
            Order order = new Order();
            bool chooses;
            string ans;

            Console.WriteLine("Please enter the number of pizzas:");
            order.pizzasCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < order.pizzasCount; ++i)
            {
                Console.WriteLine($"Pizza number {i + 1}");

                chooses = true;
                while (chooses)
                {
                    Console.WriteLine("Do you want to assemble your custom pizza or choose a ready-made one?\n" +
                        "(c - custom, r - ready)");
                    ans = Console.ReadLine().TrimEnd();

                    if (ans == "r") { this.chooseReady(order); chooses = false; }
                    else if (ans == "c") { this.buildCustomPizza(order); chooses = false; }
                }
            }
            Console.WriteLine("Should you order now or place a deferred order? (now / *date dd.mm.yyyy hh.mm*)");
            ans = Console.ReadLine().TrimEnd();
            if (ans == "now") order.date = DateTime.Now.ToString();
            else order.date = ans;

            Console.WriteLine("Leave a comment? (otherwise press enter)");
            order.comment = Console.ReadLine().TrimEnd();
            this.orderHistory.Add(order);
        }

        public void chooseReady(Order order)
        {
            int i = 0;
            bool chooses = true;
            string ans;
            while (chooses)
            {
                Console.WriteLine("System catalog:\n");
                foreach (Pizza pizza in this.pizzas)
                {
                    Console.Write($"{++i}. ");
                    pizza.print();
                }

                Console.WriteLine("User custom pizzas:\n");
                if (this.userCustomRecipes.Count == 0) Console.WriteLine("empty");
                foreach (Pizza pizza in this.userCustomRecipes)
                {
                    Console.Write($"{++i}. ");
                    pizza.print();
                }

                Console.WriteLine("Your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine()) - 1;
                if (choice < this.pizzas.Count)
                {
                    Console.WriteLine("Want to double the ingredients? (y/n)");
                    ans = Console.ReadLine().TrimEnd();
                    if (ans == "y")
                    {
                        Pizza currPizza = this.pizzas[choice];
                        currPizza.doubleBoost();
                        order.pizzas.Add(new CombinedPizza(new List<Pizza> { currPizza }));
                        chooses = false;
                    }
                    else
                    {
                        order.pizzas.Add(new CombinedPizza(new List<Pizza> { this.pizzas[choice] }));
                        chooses = false;
                    }
                }
                else if (choice < (this.pizzas.Count + this.userCustomRecipes.Count))
                {
                    Console.WriteLine("Want to double the ingredients? (y/n)");
                    ans = Console.ReadLine().TrimEnd();
                    if (ans == "y")
                    {
                        Pizza currPizza = this.pizzas[choice];
                        currPizza.doubleBoost();
                        order.pizzas.Add(new CombinedPizza(new List<Pizza> { currPizza }));
                        chooses = false;
                    }
                    else
                    {
                        order.pizzas.Add(new CombinedPizza(new List<Pizza> { this.userCustomRecipes[choice - this.pizzas.Count] }));
                        chooses = false;
                    }
                }    
            }

        }

        //TODO ВАРИАТИВНОСТЬ 
        public void buildCustomPizza(Order order)
        {
            string ans, size;
            Console.WriteLine(
                "Pizza size:\n" +
                "1. Small\n2. Middle\n3. Large");
            size = Console.ReadLine();

            Console.WriteLine("Number of pizza parts: ");
            int countOfPieces = Convert.ToInt32(Console.ReadLine());

            for (int c = 0; c < countOfPieces; ++c)
            {
                Console.WriteLine($"Lets buils {c + 1} pizza part");

                int baseNumber = -1;
                while (baseNumber < 0 || baseNumber > this.bases.Count)
                {
                    for (int i = 0; i < this.bases.Count; ++i)
                    {
                        Console.WriteLine($"{i + 1}. {this.bases[i].price}$ {this.bases[i].name}");
                    }

                    Console.WriteLine("Choose the base:");
                    baseNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                    baseNumber = ((baseNumber > 0) && (baseNumber < this.bases.Count)) ? baseNumber : 0;
                }

                int borderNumber = -1;
                while (borderNumber < 0 || borderNumber > this.borders.Count)
                {
                    for (int i = 0; i < this.borders.Count; ++i)
                    {
                        Console.WriteLine($"{i + 1}. {this.borders[i].price}$ {this.borders[i].name}");
                    }

                    Console.WriteLine("Choose the borders:");
                    borderNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                }


                for (int i = 0; i < this.ingredients.Count; ++i)
                {
                    Console.WriteLine($"{i + 1}. {this.ingredients[i].price}$ {this.ingredients[i].name}");
                }

                Console.WriteLine("Enter ingredient numbers separated by spaces: ");
                string input = Console.ReadLine();
                string[] numbers = input.Split(' ');
                List<int> indexes = new List<int>();

                List<Ingredient> ings = new List<Ingredient>();
                foreach (string i in numbers)
                {
                    int n = Convert.ToInt32(i) - 1;
                    if ((n >= 0) && (n < this.ingredients.Count))
                    {
                        ings.Add(this.ingredients[n]);
                    }
                }
                Console.WriteLine("Your pizza:");
                Pizza newPizza = new Pizza("user pizza", this.bases[baseNumber], this.borders[borderNumber], ings);
                newPizza.print();

                Console.WriteLine("Add this pizza to the catalog? (y/n)");
                ans = Console.ReadLine();
                if (ans == "y") this.userCustomRecipes.Add(newPizza);
            }
        }
    }
}

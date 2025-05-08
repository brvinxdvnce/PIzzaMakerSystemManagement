using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Diagnostics.CodeAnalysis;
using OOP.classes.Managers;
using OOP.classes;
using OOP.classes.Pizza;
using OOP.classes.OrderManagementSystem;

namespace OOP
{
   

    public class OrderManager
    {
        public OrderManager(List<Ingredient> ingredients, List<Ingredient> borders, List<PizzaBase> bases) { }


        /*public void buildPizza()
        {
            Console.WriteLine("Number of pizza parts: ");
            this.countOfPieces = Convert.ToInt32(Console.ReadLine());

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
                    if ((n > 0) && (n < this.ingredients.Count))
                    {
                        ings.Add(this.ingredients[n]);
                    }
                }
                Console.WriteLine("Your pizza:");
                Pizza newPizza = new Pizza("user pizza", this.bases[baseNumber], this.borders[borderNumber], ings);
                newPizza.print();

                string ans;
                Console.WriteLine("Order? (y/n)");
                ans = Console.ReadLine();
                if (ans == "y") ;
                Console.WriteLine("Add this pizza to the catalog? (y/n)");
                ans = Console.ReadLine();
                if (ans == "y") this.userCustomRecipes.Add(newPizza);
            }
        }
*/
    }

    public class PizzaBase : Ingredient
    {
        private int base_price = 100;

        public PizzaBase(string name, int price) : base(name, price)
        {
            this._name = name;
            this._price = price;
        }

        public override int price
        {
            get { return this._price; }
            set { this._price = (((double)value / base_price > 1.2) || (value < 0)) ? base_price : value ; }
        }
    }

    public class ManagementSystem
    {
        public ManagementSystem()
        {
            setDefaultIngridient();
            setDefaultBases();
            setDefaultSides();
            setDefaultCatalog();

            this.ingredientManager = new IngredientManager(this.ingredients);
            this.borderManager = new PizzaBorderManager(this.borders);
            this.baseManager = new PizzaBaseManager(this.bases);
            //this.orderManager = new OrderManager();

            this.userCustomRecipes = new List<Pizza>();
            this.orderHistory = new List<Order>();
        }

        IngredientManager ingredientManager;
        PizzaBorderManager borderManager;
        PizzaBaseManager baseManager;
        OrderManager orderManager;

        public List<Ingredient> ingredients;
        public List<Ingredient> borders;
        public List<PizzaBase> bases;
        public List<Pizza> pizzas;

        public List<Pizza> userCustomRecipes;

        public List<Order> orderHistory;

        public int countOfPieces;

        Random rnd = new Random();
        public void setDefaultIngridient()
        {
            this.ingredients = new List<Ingredient>
            {
                new Ingredient("cheese",          80 ),
                new Ingredient("magic mushrooms", 110),
                new Ingredient("ham",             95 ),
                new Ingredient("pineapples",      95 ),
                new Ingredient("french fries",    95 )
            };
        }

        public void setDefaultBases()
        {
            this.bases = new List<PizzaBase>
            {
                new PizzaBase("default", 100),
                new PizzaBase("sheese",  115),
                new PizzaBase("black",   110),
                new PizzaBase("grandma", 105)
            };
        }

        public void setDefaultSides()
        {
            this.borders = new List<Ingredient>
            {
                new Ingredient("default",     100),
                new Ingredient("not default", 115),
                new Ingredient("spicy sauce", 110),
                new Ingredient("idk",         105)
            };
        }

        public void setDefaultCatalog()
        {
            this.pizzas = new List<Pizza>
            {
                new Pizza(
                    "OldSchool",
                    this.bases[rnd.Next(this.bases.Count)],
                    this.borders[rnd.Next(this.borders.Count)],
                    this.ingredients.OrderBy(x => rnd.Next()).ToArray().Take(this.ingredients.Count/2).ToList()),
                new Pizza(
                    "DontCry",
                    this.bases[rnd.Next(this.bases.Count)],
                    this.borders[rnd.Next(this.borders.Count)],
                    this.ingredients.OrderBy(x => rnd.Next()).ToArray().Take(this.ingredients.Count/2).ToList()),
                new Pizza(
                    "Forever",
                    this.bases[rnd.Next(this.bases.Count)],
                    this.borders[rnd.Next(this.borders.Count)],
                    this.ingredients.OrderBy(x => rnd.Next()).ToArray().Take(this.ingredients.Count/2).ToList()),
            };
        }

        public void buildPizza()
        {
            Console.WriteLine("Number of pizza parts: ");
            this.countOfPieces = Convert.ToInt32(Console.ReadLine());

            for (int c = 0; c < countOfPieces; ++c)
            {
                Console.WriteLine($"Lets buils {c+1} pizza part");

                
                int baseNumber = -1;
                while (baseNumber < 0 || baseNumber > this.bases.Count)
                {
                    for (int i = 0; i < this.bases.Count; ++i)
                    {
                        Console.WriteLine($"{i+1}. {this.bases[i].price}$ {this.bases[i].name}");
                    }

                    Console.WriteLine("Choose the base:");
                    baseNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                    baseNumber = ((baseNumber > 0) && (baseNumber < this.bases.Count))? baseNumber : 0;
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
                string input = Console.ReadLine().TrimEnd();
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
                
                string ans;
                Console.WriteLine("Order? (y/n)");
                ans = Console.ReadLine();
                if (ans == "y") ;
                Console.WriteLine("Add this pizza to the catalog? (y/n)");
                ans = Console.ReadLine();
                if (ans == "y") this.userCustomRecipes.Add(newPizza);
            }
        }

        public void printAll ()
        {
            Console.WriteLine("=== Ingredients ===");
            this.printIngredients();
            Console.WriteLine("\n=== Borders ===");
            this.printBorders();
            Console.WriteLine("\n=== Bases ===");
            this.printBases();
            Console.WriteLine("\n=== Pizza catalog ===");
            this.printPizzas();
        }

        public void printIngredients()
        {
            foreach (Ingredient ing in this.ingredients)
            {
                ing.print();
            }
        }

        public void printBorders()
        {
            foreach (Ingredient border in this.borders)
            {
                border.print();
            }
        }
        
        public void printBases ()
        {
            foreach (PizzaBase border in this.bases)
            {
                border.print();
            }
        }

        public void printPizzas ()
        {
            Console.WriteLine("System catalog:\n");
            foreach (Pizza pizza in this.pizzas)
            {
                pizza.print();
            }
            Console.WriteLine("User custom pizzas:\n");
            foreach (Pizza pizza in this.userCustomRecipes)
            {
                pizza.print();
            }
        }

        public void start()
        {
            this.clear();
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine(
                    "========== Select action ================\n" +
                    "1. Editing Ingredients\n" +
                    "2. Editing pizza bases\n" +
                    "3. Pizza constructor\n" +
                    "4. Pizza catalog\n" +
                    "5. Check available components\n" +
                    "6. Check order history\n" +
                    "7. End the program\n" +
                    "============================================\n" +
                    "Action: ");

                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        this.clear();
                        ingredientManager.processing();
                        break;
                    case 2:
                        this.clear();
                        baseManager.processing();
                        break;
                    case 3:
                        this.clear();
                        this.buildPizza();
                        break;
                    case 4:
                        this.clear();
                        this.printPizzas();
                        break;
                    case 5:
                        this.clear();
                        this.printAll();
                        break;
                    case 7:
                        this.clear();
                        Console.WriteLine("bye bye...");
                        isWorking = false;
                        break;
                }
            }
        }
         

        public void clear()
        {
            Console.Clear();
            Console.WriteLine("=========== Pizza Maker ================");
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            ManagementSystem  pizza = new ManagementSystem();
            pizza.start();
        }
    }
}

/*
 * + Возможность создания, редактирования и удаления ингредиентов в системе. Ингредиент имеет название и стоимость. 
 * Возможность создания, редактирования и удаления типа основы для пиццы. Примеры: классическое, чёрное, толстое.
 * + У основы есть своя стоимость, притом любые, отличающиеся от классического, не должны превышать 20% стоимости
 * классического.
 * Возможность создания, редактирования и удаления пиццы. Пицца состоит из названия, ингредиентов и основы для пиццы.
 * + Стоимость пиццы формируется из стоимости ингредиентов и основы, притом без основы создать пиццу невозможно.
 * + Возможность вывода списка ингредиентов, основ для пицц, пицц.
 * 
 * У пиццы добавляются бортики. Бортики формируются также из ингредиентов (примеры: с кунжутом, с сыром). У бортика должен
 * быть список пицц, с которыми его можно использовать, или список пицц, с которым бортик использовать нельзя.
 * Возможность создания заказов. Заказы формируются из:
     * уже имеющихся в системе пицц, с возможностью удвоения имеющихся ингредиентов, 
     * созданных вручную пицц из ингредиентов в системе (притом пицца не должна сохраняться в общем списке),
     * комбинированных пицц. Например, половина пиццы А и половина пиццы Б,
 * у любого из вариантов пицц необходимо указать размер - маленькая, средняя или большая. Основа для пиццы должна быть
 * одной вне зависимости от типа пиццы, бортики могут быть как отдельные, так и общие.
 * У заказа есть номер, содержащиеся в нём пиццы, общая стоимость, комментарий и время заказа. Заказ можно так же
 * сделать отложенным, указав дату и время.
 * Возможность вывода всех заказов, сделанных в системе. 
 * Для вывода любого списка необходимо написать фильтрацию. Например, вывод всех пицц, содержащих помидоры,
 * или вывод всех заказов, сделанных 03.05.2025.
 */

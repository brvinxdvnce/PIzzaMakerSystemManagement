using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.classes.Managers
{
    public class IngredientManager : IManager<Ingredient>
    {
        public IngredientManager(List<Ingredient> ingredients)
        {
            this.ingredients = ingredients;
        }

        public List<Ingredient> ingredients;

        public void processing()
        {
            Console.WriteLine(
                    "========== Choose action ================\n" +
                    "1. Add ingredient\n" +
                    "2. Delete ingredient\n" +
                    "3. Change ingredient\n" +
                    "0. Break" +
                    "============================================\n" +
                    "Action: ");
            int action = Convert.ToInt32(Console.ReadLine());

            string name;
            int price;

            switch (action)
            {
                case 1:
                    Console.WriteLine("Name :");
                    name = Console.ReadLine();
                    Console.WriteLine("Price:");
                    price = Convert.ToInt32(Console.ReadLine());

                    this.addElem(new Ingredient(name, price));
                    break;
                case 2:
                    this.print();
                    Console.WriteLine("Enter ingredient (just name): ");
                    name = Console.ReadLine();
                    this.deleteElem(new Ingredient(name, 0));
                    break;
                case 3:
                    this.print();
                    Console.WriteLine("Enter ingredient (just name): ");
                    name = Console.ReadLine();
                    this.deleteElem(new Ingredient(name, 0));

                    Console.WriteLine("New name :");
                    name = Console.ReadLine();
                    Console.WriteLine("New price:");
                    price = Convert.ToInt32(Console.ReadLine());
                    this.addElem(new Ingredient(name, price));
                    break;
                default:
                    break;
            }
        }

        public void addElem(Ingredient ing)
        {
            ingredients.Add(ing);
        }

        public void deleteElem(Ingredient ing)
        {
            this.ingredients.RemoveAll(item => item.name == ing.name);
        }

        public void changeElem(Ingredient ing1, Ingredient ing2)
        {
            this.deleteElem(ing1);
            this.addElem(ing2);
        }

        public void print()
        {
            foreach (var ing in this.ingredients)
            {
                ing.print();
            }
        }
    }

}

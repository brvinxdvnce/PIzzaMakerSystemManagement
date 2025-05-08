using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.classes.Pizza
{
    public class Pizza
    {
        public Pizza(string name, PizzaBase warp, Ingredient borders, List<Ingredient> ingredients)
        {
            this.totalPrice = 0;
            this.name = name;
            this.warp = warp;
            this.borders = borders;
            this.ingredients = ingredients;

            totalPrice = warp.price + borders.price + ingredients.Sum(item => item.price);
        }

        public string name;
        public int totalPrice;

        public PizzaBase warp;
        public Ingredient borders;
        public List<Ingredient> ingredients;

        public void addIngredien(Ingredient obj)
        {
            ingredients.Add(obj);
            this.totalPrice += obj.price;
        }

        public void deleteIngredien(Ingredient ing)
        {
            this.ingredients.RemoveAll(item => item.name == ing.name);
        }

        public void changeIngredien(Ingredient obj1, Ingredient obj2)
        {
            deleteIngredien(obj1);
            addIngredien(obj2);
        }

        public void print()
        {
            Console.WriteLine(
                $"\nPizza name: {this.name}\n" +
                $"Borders: {this.borders.name}\n" +
                $"Base: {this.warp.name}\n" +
                $"Ingredients: ");
            foreach (Ingredient i in ingredients)
            {
                i.print();
            }
            Console.WriteLine($"Pizza price: {this.totalPrice}$\n");

        }
    }

}

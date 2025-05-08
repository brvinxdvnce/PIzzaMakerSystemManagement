using OOP.classes.PizzaComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.classes.Managers
{
    public class PizzaBaseManager : IManager<PizzaBase>
    {
        public PizzaBaseManager(List<PizzaBase> bases)
        {
            this.bases = bases;
        }

        List<PizzaBase> bases;
        public void processing()
        {

            Console.WriteLine(
                    "========== Выберите действие ================\n" +
                    "1. Add base\n" +
                    "2. Delete base\n" +
                    "3. Change base\n" +
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

                    this.addElem(new PizzaBase(name, price));
                    break;
                case 2:
                    this.print();
                    Console.WriteLine("Enter base (just name): ");
                    name = Console.ReadLine();
                    this.deleteElem(new PizzaBase(name, 0));
                    break;
                case 3:
                    this.print();
                    Console.WriteLine("Enter base (just name): ");
                    name = Console.ReadLine();
                    this.deleteElem(new PizzaBase(name, 0));

                    Console.WriteLine("New name :");
                    name = Console.ReadLine();
                    Console.WriteLine("New price:");
                    price = Convert.ToInt32(Console.ReadLine());
                    this.addElem(new PizzaBase(name, price));
                    break;
                default:
                    break;
            }
        }

        public void addElem(PizzaBase pizzaBase)
        {
            this.bases.Add(pizzaBase);
        }

        public void deleteElem(PizzaBase pizzaBase)
        {
            this.bases.RemoveAll(item => item.name == pizzaBase.name);
        }

        public void changeElem(PizzaBase pizzaBase1, PizzaBase pizzaBase2)
        {
            this.deleteElem(pizzaBase1);
            this.addElem(pizzaBase2);
        }

        public void print()
        {
            foreach (var ing in this.bases)
            {
                ing.print();
            }
        }
    }

}

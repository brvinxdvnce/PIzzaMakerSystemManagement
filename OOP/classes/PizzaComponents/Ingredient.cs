using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.classes
{
    public class Ingredient
    {
        public Ingredient(string name, int price)
        {
            this._name = name;
            this._price = price;
        }

        protected string _name;
        protected int _price;

        public string name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public virtual int price
        {
            get { return this._price; }
            set { this._price = Math.Max(0, value); }
        }

        public void print()
        {
            Console.WriteLine($"{this._price}$ - {this._name}");
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.classes.PizzaComponents
{
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
            set { this._price = (((double)value / base_price > 1.2) || (value < 0)) ? base_price : value; }
        }
    }
}

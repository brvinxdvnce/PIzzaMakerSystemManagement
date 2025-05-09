using OOP.classes.PizzaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.classes.PizzaComponents
{
    public class Border : Ingredient
    {
        public Border (string name, int price) : base(name, price)
        {
            this.name = name;
            this.price = price;
            this.whiteListPizzas = whiteListPizzas;
        }

        List<Pizza> whiteListPizzas;
    }
}

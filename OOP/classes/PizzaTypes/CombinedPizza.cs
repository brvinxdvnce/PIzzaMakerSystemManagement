using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP.classes.PizzaTypes
{
    public class CombinedPizza
    {
        public CombinedPizza(List<Pizza> pizzaParts)
        {
            this.pizzaParts = pizzaParts;
            this.price = pizzaParts.Sum(item => item.totalPrice) / this.pizzaParts.Count;
        }

        public List<Pizza> pizzaParts;
        public int price;
    }
}

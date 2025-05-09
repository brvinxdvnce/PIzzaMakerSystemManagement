using OOP.classes.PizzaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.classes.OrderManagementSystem
{
    public class Order
    {
        public Order()
        {
            this.pizzas = new List<CombinedPizza>();
        }

        public int pizzasCount;
        public List<CombinedPizza> pizzas;
        public int totalPrice;
        public string date;
        public string comment;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.classes.Managers
{
    public class PizzaBorderManager : IManager<Ingredient>
    {
        public PizzaBorderManager(List<Ingredient> borders)
        {
            this.borders = borders;
        }

        List<Ingredient> borders;

        public void processing()
        {
            throw new NotImplementedException();
        }

        public void addElem(Ingredient border)
        {
            this.borders.Add(border);
        }

        public void deleteElem(Ingredient border)
        {
            this.borders.RemoveAll(item => item.name == border.name);
        }

        public void changeElem(Ingredient border1, Ingredient border2)
        {
            this.deleteElem(border1);
            this.addElem(border2);
        }

        public void print()
        {
            foreach (var ing in this.borders)
            {
                ing.print();
            }
        }
    }

}

using OOP.classes.PizzaComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.classes.Managers
{
    public class PizzaBorderManager : IManager<Border>
    {
        public PizzaBorderManager(List<Border> borders)
        {
            this.borders = borders;
        }

        List<Border> borders;

        public void processing()
        {
            throw new NotImplementedException();
        }

        public void addElem(Border border)
        {
            this.borders.Add(border);
        }

        public void deleteElem(Border border)
        {
            this.borders.RemoveAll(item => item.name == border.name);
        }

        public void changeElem(Border border1, Border border2)
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

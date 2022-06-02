using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogue
{

    public abstract class Products 
    {
        public double Price { get => _price; } //give a get/setter 
        public string Name  { get => _name; }
    public double _price;
    public string _name;
    public virtual double CalculateTax()
        {
            return _price + (_price * 10 / 100);

        }   
        
        //public double CalculateTotal()
        //{
        //    double Total = 0;
        //    foreach (KeyValuePair kvp in _catalogue)
        //    {
        //        Total += kvp.CalculateTax();
        //    }

        //    return Total;
        //}
    }
}

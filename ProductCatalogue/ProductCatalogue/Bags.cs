using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogue
{
    internal class Bag : Products
    {
        
        public string Colour {  get => _colour;}
        public string _colour;
        public Bag(double price, string colour, string name)
        {
            _price = price;
            _colour = colour;
            _name = name;
        }
            public static Bag CreateABag( string name, double price, string colour)
        {
                Bag Bagx = new Bag(price, colour, name);
            return Bagx;
               
            }

        public static void RemoveABag()
        {

        }

        public override string ToString()
        {
            return $"Bag Price: {Price}, Bag Colour: {Colour}";
        }



    }
}


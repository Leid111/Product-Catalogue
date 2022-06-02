using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogue
{
     public class Shoes : Products
    {
        public float Size { get => _size; }
        public float _size;// give get and setter 
        public Shoes(double price, float size, string name)
        {
            
            _price = price;
            _size = size; 
            _name = name;
        }


        public static Shoes CreateAShoe(double price, float size, string name)
        {
            Shoes Shoesx = new Shoes(price, size, name);
            return Shoesx;

        }

        public override string ToString()
        {
            return $" Shoe Price: {Price}, Shoe Size: {Size}";
        }



    }
}

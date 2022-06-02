using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogue
{
    public class Catalogue<T> where T : Products  // add a contraint where we bound type to produjct. ie we can only mage a cataolgue of products 
    {

        public Dictionary<string,T> _catalogue = new Dictionary<string, T>();
        public Dictionary<string, T> Dict { get => _catalogue; set => _catalogue = value; }
        public void Add(string productname ,T product)
        {
            _catalogue.Add(productname,product);
        }
        public void Remove(string productname)
        {
            _catalogue.Remove(productname);
        }

        public void Clear()
        {
            _catalogue.Clear();
        }

        public  double CalculateTotal() 
        {
            double Total = 0;
            foreach (Products item in Dict.Values)
            {
                Total += item.CalculateTax();
            }

            return Total;
        }

        


}


}


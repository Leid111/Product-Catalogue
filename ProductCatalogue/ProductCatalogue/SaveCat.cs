using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ProductCatalogue
{

    
    internal class SaveCat
    {
    
        public static string serialise<T>(Catalogue<T> catalogue) where T : Products
        {

            return JsonSerializer.Serialize(catalogue);
          
        }

  
       
    }
}

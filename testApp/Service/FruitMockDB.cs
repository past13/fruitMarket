using System.Collections.Generic;
using testApp.Models;

namespace testApp.Service
{
    public static class FruitMockDB
    {
        public static List<FruitDTO> GetList() 
        {
            List<FruitDTO> list = new List<FruitDTO>
            {
                new FruitDTO(1, "Apple", 2.5, true),
                new FruitDTO(2, "Banana", 3.5, true),
                new FruitDTO(3, "Kiwi", 1.25, false),
                new FruitDTO(4, "Berry", 2.3, true),
            };

            return list;
        }
    }
}

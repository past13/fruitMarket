using System;
using System.Collections.Generic;
using testApp.Models;
using testApp.Service.Interface;
using System.Linq;
using testApp.Service.Utility;

namespace testApp.Service
{
    public class FruitService : IFruitService
    {
        public List<FruitDTO> Add(Fruit fruit)
        {
            var newId = fruitList.LastOrDefault().Id;

            if (newId != 0) 
            {
                newId++;
            }
           
            var fruitDTO = new FruitDTO(newId, fruit.Name, fruit.Price, fruit.InStock, DateTime.Now);

            fruitList.Add(fruitDTO);

            return fruitList;
        }

        public List<FruitDTO> Delete(int Id)
        {
            var itemToRemove = fruitList.FirstOrDefault(f => f.Id == Id);
            fruitList.Remove(itemToRemove);
            return fruitList;
        }

        public List<FruitDTO> GetExpiredFruits(DateTime date)
        {
            foreach(var fruit in fruitList)
            {
                fruit.ExpiredDate(date);
            }
            return fruitList;
        }

        public List<FruitDTO> GetReversedList()
        {
            fruitList.Reverse();

            foreach(var item in fruitList)
            {
                item.Name = ModifySequece.ReverseName(item.Name);
            }

            return fruitList;
        }

        public FruitDTO GetFruit(int id)
        {
            return fruitList.Find(x => x.Id == id);
        }

        public List<FruitDTO> GetFruitList()
        {
            return fruitList;
        }

        public static List<FruitDTO> fruitList = new List<FruitDTO>()
        {
            new FruitDTO(1, "Apple", 2.5, true, new DateTime(2018, 07, 31)),
            new FruitDTO(2, "Banana", 3.5, true, new DateTime(2018, 08, 01)),
            new FruitDTO(3, "Kiwi", 1.25, false, new DateTime(2018, 08, 05)),
            new FruitDTO(4, "Berry", 2.3, true, new DateTime(2018, 08, 10))
        };
    }
}

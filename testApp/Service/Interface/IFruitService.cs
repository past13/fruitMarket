using System;
using System.Collections.Generic;
using testApp.Models;

namespace testApp.Service.Interface
{
    public interface IFruitService
    {
        List<FruitDTO> Add(Fruit fruit);

        List<FruitDTO> Delete(int Id);

        List<FruitDTO> GetExpiredFruits(DateTime date);

        List<FruitDTO> GetFruitList();

        List<FruitDTO> GetReversedList();
    }
}

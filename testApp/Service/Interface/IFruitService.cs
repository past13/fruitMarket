using System;
using System.Collections.Generic;
using testApp.Models;
using static testApp.Service.FruitService;

namespace testApp.Service.Interface
{
    public interface IFruitService
    {
        List<FruitDTO> Add(Fruit fruit);

        List<FruitDTO> Delete(int Id);

        List<FruitDTO> GetExpiredFruits(DateTime date);

        List<FruitDTO> GetFruitList();

        FruitDTO GetFruit(int id);

        List<FruitDTO> GetReversedList();
    }
}

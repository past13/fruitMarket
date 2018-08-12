using System;
using Moq;
using Xunit;
using testApp.Models;
using testApp.Service.Interface;
using System.Collections.Generic;
using testApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace testApp.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_GetFruitList_Return_Passed()
        {
            var fruit = new FruitDTO(1, "test", 1.25, true, new DateTime(2018, 08, 08));
            var fruit1 = new FruitDTO(2, "test", 2.25, false, new DateTime(2018, 01, 01));

            var fruitList = new List<FruitDTO>
            {
                fruit,
                fruit1
            };

            var mockInterface = new Mock<IFruitService>();
            mockInterface.Setup(repo => repo.GetFruitList()).Returns(fruitList);

            var controller = new HomeController(mockInterface.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<FruitDTO>>(
                viewResult.ViewData.Model);
            
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Test_GetFruitList_Return_Empty()
        {
            var fruitList = new List<FruitDTO>
            {
            };

            var mockInterface = new Mock<IFruitService>();
            mockInterface.Setup(repo => repo.GetFruitList()).Returns(fruitList);

            var controller = new HomeController(mockInterface.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<FruitDTO>>(
                viewResult.ViewData.Model);
            Assert.Equal(0, model.Count());
        }

        [Fact]
        public void Test_DeleteFruitFromList_Return_CorrectList()
        {
            var fruit1 = new FruitDTO(2, "test", 2.25, false, new DateTime(2018, 01, 01));

            var fruitList = new List<FruitDTO>
            {
                fruit1
            };

            var mockInterface = new Mock<IFruitService>();
            mockInterface.Setup(repo => repo.Delete(1)).Returns(fruitList);

            var controller = new HomeController(mockInterface.Object);

            var result = controller.Delete(1);

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<FruitDTO>>(
                viewResult.ViewData.Model);
            
            Assert.Equal(1, model.Count());
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using RectanglesApp.Services;
using System.Threading.Tasks;

namespace RectanglesApp.Tests
{
    public class Tests:BaseTestInit
    {

        [Test]
        public void RectanglesService_GetRectangles_ReturnsAll()
        {
            Init(); 
            var rectangles = rectanglesService.GetRectanglesAsync().Result;
            Assert.AreEqual(3,rectangles.Count);
            Dispose();
        }

        [Test]
        public void RectanglesService_GetRectanglesByCoordinates_ReturnRectangle()
        {
            Init();
            var rectangles = rectanglesService.GetRectanglesByCoordinatesAsync(3,3).Result;
            Assert.AreEqual(3, rectangles[0].X);
            Assert.AreEqual(3, rectangles[0].Y);
            Dispose();
        }
    }
}
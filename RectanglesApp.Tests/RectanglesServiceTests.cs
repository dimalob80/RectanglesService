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
        public void RectanglesService_GetMatchingRectanglesAsync_1Match()
        {
            Init();
            var rectangles = rectanglesService.GetMatchingRectanglesAsync(5, 5).Result;
            Assert.AreEqual(1, rectangles[0].Id);
            Assert.AreEqual(1, rectangles.Count);
            Dispose();
        }

        [Test]
        public void RectanglesService_GetMatchingRectanglesAsync_2Matches()
        {
            Init();
            var rectangles = rectanglesService.GetMatchingRectanglesAsync(10, 10).Result;
            Assert.AreEqual(1, rectangles[0].Id);
            Assert.AreEqual(2, rectangles[1].Id);
            Assert.AreEqual(2, rectangles.Count);
            Dispose();
        }
        [Test]
        public void RectanglesService_GetMatchingRectanglesAsync_NoMatches()
        {
            Init();
            var rectangles = rectanglesService.GetMatchingRectanglesAsync(20, 20).Result;
            Assert.AreEqual(0, rectangles.Count);
            Dispose();
        }


    }
}
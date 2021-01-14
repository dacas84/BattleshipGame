using Battleship.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Extensions
{
    [TestClass]
    public class IntExtensionTests
    {
        [TestMethod]
        public void IsInvalidLimit_PointIsOutOfLimits_True()
        {
            int point = 10;
            bool result;

            result = point.IsInvalidLimit();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsInvalidLimit_PointIsInsideLimits_False()
        {
            int point = 5;
            bool result;

            result = point.IsInvalidLimit();

            Assert.IsFalse(result);
        }
    }
}

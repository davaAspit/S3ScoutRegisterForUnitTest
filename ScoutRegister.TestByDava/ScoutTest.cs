using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScoutRegister.Entity;

namespace ScoutRegister.TestByDava
{
    [TestClass]
    public class ScoutTest
    {
        public static Scout GetValidScout() => new Scout("Daniel", "Valsby-Koch", DateTime.Parse("03/11/1989"), DateTime.Parse("12/5/2015"));
        public static Relative GetValidRelative() => new Relative("Britta", "Valsby-Koch", "22928155", DateTime.Parse("19/07/1966"));

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowArgumentOutOfRangeExceptionWhenGivenFutureDateForBirthday()
        {
            //Arrange
            Scout validScout = GetValidScout();
            DateTime invalidBirthday = DateTime.Now.AddDays(1);

            //Act & Assert
            validScout.Birthday = invalidBirthday;
        }

        [TestMethod]
        public void ShouldReturnOneHigherForIceListWhenAddingRelative()
        {
            //Arrange
            Scout validScout = GetValidScout();
            Relative validRelative = GetValidRelative();
            int startCountIce = validScout.Ices.Count;
            int expectedResult = startCountIce + 1;
            int actualResult;

            //Act
            actualResult = validScout.AddIce(validRelative);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}

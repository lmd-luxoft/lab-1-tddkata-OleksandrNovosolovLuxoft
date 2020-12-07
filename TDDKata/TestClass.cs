// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TDDKata
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void ThreeItems_AreSumedCorrectly()
        {
            // Arrange
            StringCalc calc = new StringCalc();
            var values = new[] { 1, 3, 78 };
            var expected = values.Sum();

            // Act
            int value = calc.Sum(string.Join(",", values));

            // Assert
            Assert.That(value, Is.EqualTo(expected), "Wrong actual value");
        }

        [Test]
        public void OneItem_IsSumedCorrectly()
        {
            // Arrange
            StringCalc calc = new StringCalc();
            var values = new[] { 1 };
            var expected = values.Sum();

            // Act
            int value = calc.Sum(string.Join(",", values));

            // Assert
            Assert.That(value, Is.EqualTo(expected), "Wrong actual value");
        }

        [Test]
        public void MoreThanThreeItems_AreAllowed()
        {
            // Arrange
            StringCalc calc = new StringCalc();
            var values = new[] { 1, 3, 78, 78 };
            var expected = values.Sum();

            // Act
            int value = calc.Sum(string.Join(",", values));

            // Assert
            Assert.That(value, Is.EqualTo(expected), "Wrong actual value");
        }

        [Test]
        public void NullString_IsNotAllowed()
        {
            // Arrange
            StringCalc calc = new StringCalc();
            var expected = -1;

            // Act
            int value = calc.Sum(null);

            // Assert
            Assert.That(value, Is.EqualTo(expected), "Wrong actual value");
        }

        [Test]
        public void EmptyString_ReturnsZero()
        {
            // Arrange
            StringCalc calc = new StringCalc();
            var expected = 0;

            // Act
            int value = calc.Sum(string.Empty);

            // Assert
            Assert.That(value, Is.EqualTo(expected), "Wrong actual value");
        }

        [Test]
        public void NegativeNumber_IsNotAllowed()
        {
            // Arrange
            StringCalc calc = new StringCalc();
            var values = new[] { 1, 3, -78 };
            var expected = -1;

            // Act
            int value = calc.Sum(string.Join(",", values));

            // Assert
            Assert.That(value, Is.EqualTo(expected), "Wrong actual value");
        }

        [Test]
        public void NaN_IsNotAllowed()
        {
            // Arrange
            StringCalc calc = new StringCalc();
            var values = new object[] { 1, 3, " " };
            var expected = -1;

            // Act
            int value = calc.Sum(string.Join(",", values));

            // Assert
            Assert.That(value, Is.EqualTo(expected), "Wrong actual value");
        }
    }
}

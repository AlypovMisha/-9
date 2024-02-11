using Лабораторная_9;
namespace UnitTest2
{
    [TestClass]
    public class DialClockArrayTests
    {
        [TestMethod]
        public void Length_DefaultConstructor_ReturnsOne()
        {
            // Arrange
            DialClockArray dialClockArray = new DialClockArray();

            // Act
            int length = dialClockArray.Length;

            // Assert
            Assert.AreEqual(1, length);
        }

        [TestMethod]
        public void Length_ParameterizedConstructor_ReturnsCorrectLength()
        {
            // Arrange
            int expectedLength = 5;
            DialClockArray dialClockArray = new DialClockArray(expectedLength);

            // Act
            int length = dialClockArray.Length;

            // Assert
            Assert.AreEqual(expectedLength, length);
        }

        [TestMethod]
        public void Length_KeyboardInputConstructor_ReturnsCorrectLength()
        {
            // Arrange
            int expectedLength = 3;
            int a = 0; // Not used in the provided code
            DialClockArray dialClockArray = new DialClockArray(expectedLength, a);

            // Act
            int length = dialClockArray.Length;

            // Assert
            Assert.AreEqual(expectedLength, length);
        }

        [TestMethod]
        public void Length_CopyConstructor_ReturnsCorrectLength()
        {
            // Arrange
            DialClockArray originalArray = new DialClockArray(4);
            DialClockArray dialClockArray = new DialClockArray(originalArray);

            // Act
            int length = dialClockArray.Length;

            // Assert
            Assert.AreEqual(originalArray.Length, length);
        }

        [TestMethod]
        public void Show_PrintsAllElements()
        {
            // Arrange
            DialClockArray dialClockArray = new DialClockArray(3);
            string expectedOutput = "HH:MM\nHH:MM\nHH:MM\n"; // Replace HH:MM with actual values

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                dialClockArray.Show();
                string output = sw.ToString();

                // Assert
                Assert.AreEqual(expectedOutput, output);
            }
        }

        [TestMethod]
        public void GetMaxAngle_ReturnsMaxAngle()
        {
            // Arrange
            DialClockArray dialClockArray = new DialClockArray(3);
            DialClock expectedMaxAngle = new DialClock(12, 30); // Replace 12 and 30 with actual values

            // Act
            DialClock maxAngle = dialClockArray.GetMaxAngle();

            // Assert
            Assert.AreEqual(expectedMaxAngle, maxAngle);
        }

        [TestMethod]
        public void GetCollectionCount_ReturnsCorrectCount()
        {
            // Arrange
            int expectedCount = DialClockArray.GetCollectionCount() + 1;
            DialClockArray dialClockArray = new DialClockArray();

            // Act
            int count = DialClockArray.GetCollectionCount();

            // Assert
            Assert.AreEqual(expectedCount, count);
        }
    }

}
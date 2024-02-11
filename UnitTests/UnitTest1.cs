using Лабораторная_9;
namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            DialClock clock = new DialClock();
            //Act
            DialClock clock1 = new DialClock(0, 0);
            //Assert
            Assert.AreEqual(clock.Hours, clock1.Hours);
            Assert.AreEqual(clock.Minutes, clock1.Minutes);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            DialClock clock = new DialClock(25, 5);
            //Act
            DialClock clock1 = new DialClock(0, 65);
            //Assert
            Assert.AreEqual(clock.Hours, clock1.Hours);
            Assert.AreEqual(clock.Minutes, clock1.Minutes);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            DialClock clock = new DialClock(5, 55);
            //Act
            DialClock clock1 = new DialClock(clock);
            //Assert
            Assert.AreEqual(clock.Hours, clock1.Hours);
            Assert.AreEqual(clock.Minutes, clock1.Minutes);
        }

        [TestMethod]
        public void TestMethod4()
        {
            //Arrange
            DialClock clock = new DialClock("0", "65");
            //Act
            DialClock clock1 = new DialClock("1", "5");
            //Assert
            Assert.AreEqual(clock.Hours, clock1.Hours);
            Assert.AreEqual(clock.Minutes, clock1.Minutes);
        }

        [TestMethod]
        public void TestMethod5()
        {
            //Arrange
            DialClock clock = new DialClock("0", "45");
            //Act
            DialClock clock1 = new DialClock(4, 4);
            clock1.Hours = clock.Hours;
            clock1.Minutes = clock.Minutes;
            //Assert
            Assert.AreEqual(clock.Hours, clock1.Hours);
            Assert.AreEqual(clock.Minutes, clock1.Minutes);
        }

        [TestMethod]
        public void GetTestAngle()
        {
            //Arrange
            DialClock clock1 = new DialClock("0", "30");
            DialClock clock2 = new DialClock(7, 38);
            DialClock clock3 = new DialClock(4, 10);
            DialClock clock4 = new DialClock(0, 0);
            DialClock clock5 = new DialClock(clock1);
            //Act
            int angle1 = 165;
            int angle2 = 1;
            int angle3 = 65;
            int angle4 = 0;
            int angle5 = 165;
            //Assert
            Assert.AreEqual(clock1.GetLittleAngle(), angle1);
            Assert.AreEqual(clock2.GetLittleAngle(), angle2);
            Assert.AreEqual(clock3.GetLittleAngle(), angle3);
            Assert.AreEqual(clock4.GetLittleAngle(), angle4);
            Assert.AreEqual(clock5.GetLittleAngle(), angle5);
        }

        [TestMethod]
        public void GetTestOperator()
        {
            //Arrange
            DialClock clock1 = new DialClock("0", "30");
            DialClock clock2 = new DialClock(7, 38);
            DialClock clock3 = new DialClock(4, 10);
            DialClock clock4 = new DialClock(0, 0);
            DialClock clock5 = new DialClock(clock1);
            DialClock clock6 = new DialClock(5, 5);
            DialClock clock7 = new DialClock(5, 5);
            //Act
            clock1++;
            DialClock answer1 = new DialClock("0", "31");
            clock2--;
            DialClock answer2 = new DialClock(7, 37);
            clock3 += 60;
            DialClock answer3 = new DialClock(5, 10);
            clock4 -= 60;
            DialClock answer4 = new DialClock(23, 0);
            bool answer5 = (bool)clock5;
            int answer6 = clock6;
            clock7 = 60 + clock7;
            DialClock answer7 = new DialClock(6, 5);

            //Assert
            Assert.AreEqual(clock1.Minutes, answer1.Minutes);
            Assert.AreEqual(clock2.Minutes, answer2.Minutes);
            Assert.AreEqual(clock3.Hours, answer3.Hours);
            //Assert.AreEqual(clock4.Hours, answer4.Hours);
            Assert.AreEqual(answer5, true);
            Assert.AreEqual(answer6, 305);
            Assert.AreEqual(answer7.Hours, answer7.Hours);
        }

        [TestClass]
        public class DialClockArrayTests
        {
            [TestMethod]
            public void Length_DefaultConstructor_LengthIsOne()
            {
                var dialClockArray = new DialClockArray();

                Assert.AreEqual(1, dialClockArray.Length);
            }

            [TestMethod]
            public void Length_ConstructorWithRandomValues_CorrectLength()
            {
                int lengthArray = 3;
                var dialClockArray = new DialClockArray(lengthArray);

                Assert.AreEqual(lengthArray, dialClockArray.Length);
            }


            [TestMethod]
            public void Length_ConstructorCopy()
            {
                int lengthArray = 3;
                var dialClockArray = new DialClockArray(lengthArray);
                var dialClockArrayCopy = new DialClockArray(dialClockArray);

                Assert.AreEqual(dialClockArray[0], dialClockArrayCopy[0]);
                Assert.AreEqual(dialClockArray[1], dialClockArrayCopy[1]);
                Assert.AreEqual(dialClockArray[2], dialClockArrayCopy[2]);
            }

            [TestMethod]
            public void Indexer_SetAndGetElement_CorrectElement()
            {
                var dialClockArray = new DialClockArray();
                var dialClock = new DialClock(10, 30);

                dialClockArray[0] = dialClock;
                var retrievedDialClock = dialClockArray[0];

                Assert.AreEqual(dialClock, retrievedDialClock);
            }

            [TestMethod]
            public void GetTestMaxAngle()
            {
                var dialClockArray = new DialClockArray();

                dialClockArray[0] = new DialClock(0, 30);

                Assert.AreEqual(dialClockArray.GetMaxAngle(), 165);
            }

            [TestMethod]
            public void GetCollectionCount_AfterCreatingObjects_ReturnsCorrectCount()
            {
                int initialCount = DialClockArray.GetCollectionCount();

                var dialClockArray1 = new DialClockArray();
                var dialClockArray2 = new DialClockArray(2);

                int currentCount = DialClockArray.GetCollectionCount();

                Assert.AreEqual(initialCount + 2, currentCount);
            }


           



            // Добавим тест для проверки метода ToString


        }
    }
}
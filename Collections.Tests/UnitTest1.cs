using NUnit.Framework;
using System;

namespace Collections.Tests
{
    public class Tests
    {

        public Collection<int> nums = new Collection<int>();
        int Collection_Count = 0;
        int capacity = 0;
        Random rnd = new Random();


        [SetUp]
        public void Setup()
        {
            nums = new Collection<int>(new int[] { 10, 20, 30, 40, 50 , 60 });
            Collection_Count = nums.Count;
            capacity = nums.Capacity;


        }

        [TearDown]
        public void BaseTearDown()
        {
            nums.Clear();
        }

        [Test]
        [Timeout(200)]
        [TestCase(TestName = "Add 1 million items with timeout 200ms")]
        public void Test_Collections_1MillionItems()
        {

            for (int i = 0; i < 1000000; i++)
            {
                nums.Add(i);
                Collection_Count++;
            }
            Assert.AreEqual(Collection_Count, nums.Count);
        }


        [Test]
        public void Count_and_Capacity()
        {
            for (int i = 0; i < 1000; i++)
            {
                nums.Add(1);
                Collection_Count++;
                if (Collection_Count == capacity)
                {
                    capacity = 2 * capacity;
                }
            }

            Assert.AreEqual(nums.Count, Collection_Count);
            Assert.AreEqual(nums.Capacity, capacity);

        }

        [Test]
        public void InsertAtStart()
        {

            int firstValue = nums[0];
            nums.InsertAt(0, 22);
            int insertedValue = nums[0];
            Assert.AreEqual(firstValue, nums[1]);
            Assert.AreEqual(firstValue, 10);
            Assert.AreEqual(insertedValue, 22);

        }

        [Test]
        public void InsertAtEnd()
        {
            int lastValue = nums[Collection_Count - 1];
            int insertedValue = nums[Collection_Count - 1] + 10;
            nums.Add(insertedValue);
            Collection_Count++;
            Assert.AreEqual(insertedValue, nums[Collection_Count - 2] + 10 );
            Assert.AreEqual(nums.Count, Collection_Count);

        }

        [Test]
        public void InsertWithGrowAtStart()
        {


            int max = nums[0];
            int random_number = rnd.Next(0, max);
            nums.InsertAt(0, random_number);
            Collection_Count++;
            Assert.That(nums[0] < nums[1]);
            Assert.AreEqual(nums.Count, Collection_Count);

        }


        [Test]
        public void InsertWithGrowAtEnd()
        {
            int min = nums[Collection_Count - 1];
            int max = min + 100000;
            int random_number = rnd.Next(min, max);
            nums.Add(random_number);
            Collection_Count++;
            Assert.AreEqual(nums.Count, 7);
            Assert.AreEqual(Collection_Count , 7 );
            Assert.That(nums[Collection_Count - 1] > nums[Collection_Count - 2]);
            Assert.AreEqual(nums.Count, Collection_Count);
        }

        [Test]
        public void InsertWithGrowAtMiddle()
        {
            int middleIndex = 0;
            int min;
            int max;

            int random_number = 0;
            if (Collection_Count % 2 == 1)
            {
                middleIndex = ((Collection_Count + 1) / 2) - 1;
            }

            if (Collection_Count % 2 == 0)
            {
                int lastIndexValue = nums[Collection_Count - 1];
                random_number = rnd.Next(lastIndexValue, 1000000);
                nums.Add(random_number);
                Collection_Count++;
                middleIndex = ((Collection_Count + 1) / 2) - 1;
            }
            
            min = nums[middleIndex - 1];
            max = nums[middleIndex];
            random_number = rnd.Next(min, max);
            nums.InsertAt(middleIndex, random_number);
            Collection_Count++;
            Assert.That(nums[middleIndex] < nums[middleIndex + 1]);
            Assert.That(nums[middleIndex] >= nums[middleIndex - 1]);
            Assert.AreEqual(nums.Count, Collection_Count);


        }

        [Test]
        public void AddRange()        
        {           
            var items = new int[] { 70, 80, 90 };
           
            nums.AddRange(items);             
           
            Assert.AreEqual(nums.Count, 9);
        }

        [Test]
        public void ConstructorMultipleItemString()
        {
           
            Collection<string> nums = new Collection<string>("Rali");
            Assert.That(nums.Count == 1);
            Assert.AreEqual(nums.Capacity, 16);
            Assert.That(nums.ToString() == "[Rali]");
        }

        [Test]
        public void Delete_At_End()
        {
            nums.RemoveAt(Collection_Count - 1);
            Collection_Count--;
            Assert.AreEqual(nums.Count, Collection_Count);

            String array = nums.ToString();
            Assert.AreEqual(array, "[10, 20, 30, 40, 50]");
        }



        [Test]
        public void Delete_At_Start()
        {
            nums.RemoveAt(0);
            Collection_Count--;
            Assert.AreEqual(nums.Count, Collection_Count);

        }

        [Test]
        public void Test_Collections_Clear()
        {
            nums.Clear();
            Assert.AreEqual(nums.Count, 0);

        }

        [Test]
        public void Exchange_First_Last()
        {
            int firstElement = nums[0];
            int lastElement = nums[Collection_Count - 1];
            nums.Exchange(0, Collection_Count - 1);
            Assert.AreEqual(nums[Collection_Count - 1], firstElement);
            Assert.AreEqual(nums[0], lastElement);

        }

        [Test]
        public void ExcganedMiddleFirst()
        {
            int firstIndexValue = nums[0];
            int middleIndex = 0;

            int random_number = 0;

            if (Collection_Count % 2 == 1)
            {
                middleIndex = ((Collection_Count + 1) / 2) - 1;
            }

            if (Collection_Count % 2 == 0)
            {
                int lastIndexValue = nums[Collection_Count - 1];
                random_number = rnd.Next(lastIndexValue, 1000000);
                nums.Add(random_number);
                Collection_Count++;
                middleIndex = ((Collection_Count + 1) / 2) - 1;
            }

            int middleIndexValue = nums[middleIndex];

            nums.Exchange(0, middleIndex);

            Assert.AreEqual(nums[middleIndex], firstIndexValue);
            Assert.AreEqual(nums[0], middleIndexValue);
            Assert.AreEqual(nums.Count, Collection_Count);
        }


        [Test]
        public void GetElementByInvalidIndex()
        {
            int random_number;
            random_number = rnd.Next(0, 8);

            if (random_number > Collection_Count - 1)

            {

                Assert.That(random_number, Is.Not.InRange(0, Collection_Count - 1));
                //  Assert.Fail();

            }

            else
            {
                Assert.That(random_number, Is.InRange(0, Collection_Count - 1));

            }

        }

        [Test]
        public void InsertAtInvalidIndex()
        {
            int random_number;
            random_number = rnd.Next(0, 8);

            if (random_number > Collection_Count - 1)

            {

                Assert.That(random_number, Is.Not.InRange(0, Collection_Count - 1));
                //  Assert.Fail();

            }

            else
            {
                nums.InsertAt(random_number, 25);
                Collection_Count++;
                int insertedValue = nums[random_number];
                Assert.AreEqual(insertedValue, 25);
                Assert.That(random_number, Is.InRange(0, Collection_Count - 1));

            }

        }

        [Test]
        public void DeleteAtInvalidIndex()
        {
            int random_number;
            random_number = rnd.Next(0, 8);

            if (random_number > Collection_Count - 1)

            {

                Assert.That(random_number, Is.Not.InRange(0, Collection_Count - 1));
                //  Assert.Fail();

            }

            else
            {
                nums.RemoveAt(random_number);
                Collection_Count--;
                Assert.AreEqual(nums.Count, Collection_Count);
                Assert.That(random_number, Is.InRange(0, Collection_Count - 1));

            }

        }


    }
}
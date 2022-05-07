using NUnit.Framework;
using System;

namespace Collections.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Timeout(200)]
        [TestCase(TestName = "Add 1 million items with timeout 200ms")]
        public void Test_Collections_1MillionItems()
        {
            Collection<int> nums = new Collection<int>();
            int Collection_Count = nums.Count;
            Assert.AreEqual(Collection_Count, 0);
            for (int i = 0; i < 1000000; i++)
            {
                nums.Add(i);
                Collection_Count++;
            }
            Assert.AreEqual(Collection_Count, 1000000);
        }

        [Test]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, TestName = "AddAtEnd - 5 elements + 1 added")]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70 }, TestName = "AddAtEnd - 7 elements + 1 added")]
        public void Test_Collections_InsertAtEnd(int[] values)
        {
            Collection<int> nums = new Collection<int>(values);
            int Collection_Count = nums.Count;
            nums.Add(1);
            Assert.AreEqual(nums.Count, Collection_Count + 1);

        }

        [Test]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, TestName = "Count and Capacity - 5 elements + 1 added")]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70 }, TestName = "Count and Capacity - 7 elements + 1 added")]
        public void Test_Collections_Count_and_Capacity(int[] values)
        {
            int Collection_Count = 0;
            int capacity = 0;

            Collection<int> nums = new Collection<int>(values);

            Collection_Count = nums.Count;
            capacity = nums.Capacity;

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
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, TestName = "InsertAtStart - 5 elements + 1 added")]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70 }, TestName = "InsertAtStart - 7 elements + 1 added")]
        public void InsertAtStart(int[] values)
        {
            Collection<int> nums = new Collection<int>(values);
            int Collection_Count = nums.Count;
            int firstValue = nums[0];
            nums.InsertAt(0, 22);
            int insertedValue = nums[0];
            Assert.AreEqual(firstValue, 10);
            Assert.AreEqual(insertedValue, 22);

        }

        [Test]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, TestName = "InsertWithGrowAtStart - 5 elements + 3 added")]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70 }, TestName = "InsertWithGrowAtStart - 7 elements + 3 added")]
        public void InsertWithGrow(int[] values)
        {
            Collection<int> nums = new Collection<int>(values);
            int count = nums.Count;

            Random rnd = new Random();
            int max = nums[0];
            int random_number = rnd.Next(0, max);
            nums.InsertAt(0, random_number);
            Assert.That(nums[0] < nums[1]);
            Assert.AreEqual(nums.Count, count + 1);

        }


        [Test]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, TestName = "InsertWithGrowAtEnd - 5 elements + 3 added")]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70 }, TestName = "InsertWithGrowAtEnd - 7 elements + 3 added")]
        public void InsertWithGrowAtEnd(int[] values)
        {
            Collection<int> nums = new Collection<int>(values);
            int count = nums.Count;
            Random rnd = new Random();
            int min = nums[count - 1];
            int random_number = rnd.Next(min, min + 1000000);
            nums.Add(random_number);
            Assert.That(nums[count] > nums[count - 1]);
            Assert.AreEqual(nums.Count, count + 1);
        }

        [Test]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60 }, TestName = "InsertWithGrowAtMiddle - 6 elements")]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70 }, TestName = "InsertWithGrowAtMiddle - 7 elements")]
        public void InsertWithGrowAtMiddle(int[] values)
        {
            Collection<int> nums = new Collection<int>(values);
            int count = nums.Count;
            int middleIndex = 0;
            int min;
            int max;

            Random rnd = new Random();
            int random_number = 0;
            if (count % 2 == 1)
            {
                middleIndex = (count + 1) / 2;
            }

            if (count % 2 == 0)
            {
                int lastIndexValue = nums[count - 1];
                random_number = rnd.Next(lastIndexValue, 1000000);
                nums.Add(random_number);
                count++;
                middleIndex = (count + 1) / 2;
            }

            min = nums[middleIndex - 1];
            max = nums[middleIndex];
            random_number = rnd.Next(min, max);
            nums.InsertAt(middleIndex, random_number);
            Assert.That(nums[middleIndex] < nums[middleIndex + 1]);
            Assert.That(nums[middleIndex] >= nums[middleIndex - 1]);
            Assert.AreEqual(nums.Count, count + 1);


        }

        [Test]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, TestName = "Delete_At_End - 5 elements - 1 removed")]
        public void Test_Collections_Delete_At_End(int[] values)
        {
            Collection<int> nums = new Collection<int>(values);
            int Collection_Count = nums.Count;
            nums.RemoveAt(Collection_Count - 1);
            Assert.AreEqual(nums.Count, Collection_Count - 1);

            String array = nums.ToString();
            Assert.AreEqual(array, "[10, 20, 30, 40]");
        }



        [Test]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, TestName = "Delete_At_Start - 5 elements - 1 removed")]
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70 }, TestName = "Delete_At_Start - 7 elements - 1 removed")]
        public void Test_Collections_Delete_At_Start(int[] values)
        {
            Collection<int> nums = new Collection<int>(values);
            int Collection_Count = nums.Count;
            nums.RemoveAt(0);
            Assert.AreEqual(nums.Count, Collection_Count - 1);

        }

        [Test]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, TestName = "Clear 5 elements ")]
        [TestCase(new int[] { }, TestName = "Clear-all")]
        public void Test_Collections_Clear(int[] values)
        {
            Collection<int> nums = new Collection<int>(values);
            nums.Clear();
            Assert.AreEqual(nums.Count, 0);

        }

        [Test]
        [TestCase(new int[] { 10, 20, 30, 40, 50 }, TestName = "Test_Collections_Delete_At_Start - 5 elements - 1 removed")]
        [TestCase(new int[] { 10, 20, 30, 40, 60, 70, 50 }, TestName = "Test_Collections_Delete_At_Start - 7 elements - 1 removed")]
        public void Test_Collections_Exchange_First_Last(int[] values)
        {
            Collection<int> nums = new Collection<int>(values);
            int Collection_Count = nums.Count;
            int firstElement = nums[0];
            int lastElement = nums[Collection_Count - 1];
            nums.Exchange(0, Collection_Count - 1);
            Assert.AreEqual(nums[Collection_Count - 1], firstElement);
            Assert.AreEqual(nums[0], lastElement);

        }


    }
}
using NUnit.Framework.Interfaces;
using IRR.Application.Service;

namespace IRRTest
{


    [TestFixture]
    public class IRRTTests
    {
        [SetUp]
        public void Setup()
        {




            Type[] premiumTypes = [typeof(int), typeof(int), typeof(int), typeof(DateTime),
                typeof(double), typeof(double), typeof(int)];

            Type[] paidLossTypes = [typeof(int), typeof(int), typeof(int), typeof(int), typeof(DateTime),
                typeof(double), typeof(double)];

            Type[] incurredLossTypes = [typeof(int), typeof(int), typeof(int), typeof(int), typeof(DateTime),
                typeof(double), typeof(double)];

            Type[] capitalTypes = [typeof(int), typeof(double), typeof(DateTime)];

            Type[] bufferTypes = [typeof(int), typeof(float), typeof(DateTime)];


            /*var PremiumTable = _testData.ReadFileToObject<PremiumSchedule>("C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/PremiumScheduleTest.csv", premiumTypes);

            var IncurredLossTable = _testData.ReadFileToObject<IRRLossSchedule>("C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/LossScheduleTest.csv", incurredLossTypes);

            var PaidLossTable = _testData.ReadFileToObject<PaidSchedule>("C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/PaidLossTest.csv", paidLossTypes);

            var CapitalTable = _testData.ReadFileToObject<CapitalSchedule>("C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/CapitalScheduleTest.csv", capitalTypes);


            var BufferTable = _testData.ReadFileToObject<BufferSchedule>("C:/Users/maheto/OneDrive - " +
                "Arch Capital Group/Desktop/Work Files/Cashflow Modelling/BufferScheduleTest.csv", bufferTypes); */





        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
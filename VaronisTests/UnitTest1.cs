using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Varonis.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /* TestMethod1 passes because statistically you should not obtain
         * any numbers in the range at first. If you reduce the range to
         * say 0-200 instead of 0-1000000, then it will fail.
        */
        [TestMethod]
        public void TestMethod1()
        {
            var s = InterviewQuestion.questionOne();
            int count = s.Where(s => s > 99 && s < 201).Count();
            Assert.IsTrue(count == 0);
            
        }
    }
}
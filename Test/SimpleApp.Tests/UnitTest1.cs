using System;
using Xunit;

namespace SimpleApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            var expectedLower = 17.3;
            Assert.Equal(book.getLowerGrade(),expectedLower);
            var expectedHighest = 90.5;
            Assert.Equal(book.getHighestGrade(),expectedHighest);
        }
    }
}

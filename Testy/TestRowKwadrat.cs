using Library;

namespace Testy
{
    public class TestRowKwadrat
    {
        private Kwadratowe kw;
        [Fact]
        public void Test1()
        {
            kw = new Kwadratowe(1, -2, 1);
            Assert.Equal(new double[] { 1 }, kw.Rozwiazania());
        }
        [Fact]
        public void Test2()
        {
            kw = new Kwadratowe(2, -5, -3);
            Assert.Equal(new double[] {3, -0.5}, kw.Rozwiazania());
        }
        [Fact]
        public void Test3() 
        {
            kw = new Kwadratowe(4, 3, 2);
            Assert.Equal(null, kw.Rozwiazania());
        }
    }
}
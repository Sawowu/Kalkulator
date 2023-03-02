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
    }
}
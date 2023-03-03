using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testy
{
    public class TestTrapez
    {
        private Trapez tr;
        [Fact]
        public void Test()
        {
            tr = new Trapez(4, 2, 1.5, 1);
            Assert.Equal(3, tr.Pole());
        }
    }
}

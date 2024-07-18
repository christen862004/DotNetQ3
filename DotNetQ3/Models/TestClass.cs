using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DotNetQ3.Models
{
    public class TestClass
    {
        public int Add(int x,int y)
        {
                return x + y;
        }
        public int AdvAdd() {
            int a = 10;
            int b = 20;
            return Add(a, b);
        
        }
    }

}

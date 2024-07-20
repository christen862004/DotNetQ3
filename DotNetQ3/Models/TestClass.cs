using Humanizer;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DotNetQ3.Models
{
    public class TestClass
    {
        int no;
        public int No
        {
            set {no = value;}
            get { return no; }
        }

        public dynamic Number
        {
            set { No=value;}
            get { return No; }
        }






        public int Add(int x,int y)
        {
            No = 10;
            int x1 = Number;
            
            dynamic no = 1;
            dynamic name = "Ahmed";
            dynamic z = new Student();
            name = no.ID + z;//throw exception
                return x + y;
        }
        public int AdvAdd() {
            int a = 10;
            int b = 20;
            return Add(a, b);
        
        }
    }

}

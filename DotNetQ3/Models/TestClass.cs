using Humanizer;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DotNetQ3.Models
{
    interface ISort
    {
        void Sort(int[] arr);
    }

    class BubbleSort:ISort
    {
        public void Sort(int [] arr)
        {
            //Sort algrithm using Bubblesort
        }
        public void test()
        {

        }
    }

    class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {
            //Sort algrithm using Select
        }
    }

    class ChrisSort : ISort
    {
        public void Sort(int[] arr)
        {
            //alo.
        }
    }

    class MyClass 
        //hih level Class depend on low level class (tigh Couple)
        //==>DIP (lossly Couple) low level ==>abstraction | interface
    {
        int[] arr;
        ISort SortAl=null;//Low Level Class
        public MyClass(ISort sort)
        {
            SortAl = sort;
            
        }
        public void DisplaySortedArr()
        {
            SortAl.Sort(arr);
            //display
        }
    }











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
            //Tigh Couple | Lossly Couple
            MyClass c1 = new MyClass(new BubbleSort());

            MyClass c2 = new MyClass(new SelectionSort());
            
            MyClass c3 = new MyClass(new ChrisSort());







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

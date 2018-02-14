using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListAndString
{
    class Program
    {
        static void Main(string[] args)
        {
           var lsp=new ListAndStringProblems();
           var list=new List<int>{20,30,4050,90,2,3,56,80};


            //lsp.LargestValueInList(list);

            //lsp.RevereList(list);

            //lsp.SearchAnElement(list);

            //lsp.ReturnOddPositonElement(list);

            //lsp.TotalOfList(list);

            //lsp.PalpalindromeString("abba");

            //var sumRec = lsp.RecursionSum(list,0);

            //Console.WriteLine(sumRec);

            //lsp.ConcatinateTwoList();

            //lsp.AlterNativeTakingList();

            //lsp.SortListSortConcat();

            //lsp.RotateListElement();

            //lsp.FibonacciNumbers();

            //lsp.ListOfDigit();

            lsp.BinarySearch();
        }
    }
}

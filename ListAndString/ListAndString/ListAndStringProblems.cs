using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ListAndString
{
    class ListAndStringProblems
    {
        public void LargestValueInList(List<int>list)
        {
            //Console.WriteLine("Problem 1 Solution......\n\n");
            foreach (var i in list)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();
            var value = list[0];
            for (var i = 1; i < list.Count; i++)
            {
                if (value < list[i])
                {
                    value = list[i];
                }
            }

            Console.WriteLine("Largest Value :"+value);
        }

        public void RevereList(List<int> list)
        {
            Console.WriteLine("Before Revere........");

            foreach (var i in list)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();



            for (var i = 0; i < list.Count/2; i++)
            {
                var temp = list[list.Count - i - 1];
                list[list.Count - i - 1] = list[i];
                list[i] = temp;
            }
            Console.WriteLine("After Revere........");


            foreach (var i in list)
            {
                Console.Write(i+"\t");
            }
            Console.WriteLine();
        }

        public void SearchAnElement(List<int>list)
        {
            //Console.WriteLine("Problem 3 Solution......\n\n");

            Console.Write("Enter a Value for Search :");
            var element = Convert.ToInt32(Console.ReadLine());

            var flag=false;
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] != element) continue;
                Console.WriteLine("Value:"+element+" Found in Index "+i);
                flag = true;
            }
            if (flag == false)
            {
                Console.WriteLine(element+" Not Found in List.");
            }
        }

        public void ReturnOddPositonElement(List<int> list)
        {
            //Console.WriteLine("Problem 4 Solution......\n\n");

            var i = 0;
            var tempList=new List<int>();
            for (; i <list.Count; i++)
            {
                if (i %2!=0)
                {
                    tempList.Add(list[i]);
                }
            }

            foreach (var i1 in tempList)
            {
                Console.WriteLine(i1+"\t");
            }
        }

        public void TotalOfList(List<int> list)
        {
            //Console.WriteLine("List Element........");
            foreach (var i in list)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();

            var total = 0;
            for (var i = 0; i < list.Count; i++)
            {
                total += list[i];
            }
            Console.WriteLine("Total Value of List :"+total);
        }

        public void PalpalindromeString(string str)
        {
            int length = str.Length;
            Console.WriteLine(length);
            bool flag = true;

            for (int i = 0; i < length; i++)
            {
                if (str[length - 1 - i] == str[i])
                {
                    continue;
                }
                else
                {
                    flag = false;
                    break;   
                }
            }

            if (flag)
            {
                Console.WriteLine(str+" is Palpalindrome String");
            }
            else
            {
                Console.WriteLine(str+"Not Palpalindrome String");
            }
        }

        public int RecursionSum(List<int> l, int i)
        {
            var sum = 0;

            if (i ==l.Count )
            {
                return l[i];
            }

            sum+=RecursionSum(l,i+1);

            return sum;
        }

        public void ConcatinateTwoList()
        {
            List<string> list1 = new List<string> { "1", "2","3" };
            List<string> list2 = new List<string> { "a", "b", "c" };

            list2.AddRange(list1);

            foreach(var i in list2)
            {
                Console.Write(i+"\t");
            }
            Console.WriteLine();
        }
        public void AlterNativeTakingList()
        {
            List<string> list1 = new List<string> { "1", "2", "3"};
            List<string> list2 = new List<string> { "a", "b", "c" };

            List<string> ConcatList=new List<string>();

            int totalElement = list2.Count + list1.Count;
            //Console.WriteLine(totalElement/2);

            for(var i = 0; i < totalElement / 2; i++)
            {

                    ConcatList.Add(list1[i]);
                    ConcatList.Add(list2[i]);
            }

            foreach(var i in ConcatList)
            Console.Write(i+"\t");
            Console.WriteLine();

        }

        public void SortListSortConcat()
        {
            var list1 = new List<int> { 1, 4, 6,9,10 };
            var list2 = new List<int> { 2, 3, 5 };

            var sortList = new List<int>();

            var totalCount = list1.Count + list2.Count;

            while (list1.Count!=0 && list2.Count!=0)
            {
                int minValuelist1 = list1.Min();
                int minValuelist2 = list2.Min();
                if (minValuelist1 < minValuelist2)
                {
                    sortList.Add(minValuelist1);

                    list1.Remove(minValuelist1);
                }
                else if (minValuelist2 < minValuelist1)
                {
                    sortList.Add(minValuelist2);

                    list2.Remove(minValuelist2);
                }
                else
                {
                    sortList.Add(minValuelist1);
                    sortList.Add(minValuelist2);

                    list1.Remove(minValuelist1);
                    list2.Remove(minValuelist2);
                }
                //Console.WriteLine(minValuelist1);
                //Console.WriteLine(minValuelist2);
            }

            Console.WriteLine(list1.Count+"\t"+list2.Count);
            if (list1.Count != 0)
            {
                    list1.Sort();
                    sortList.AddRange(list1);
            }
            else if (list2.Count != 0)
            {
                list2.Sort();
                sortList.AddRange(list2);

            }
            foreach (var i in sortList)
            Console.Write(i + "\t");
            Console.WriteLine();
        }

        public void RotateListElement()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6 };

            List<int> demo = new List<int>() { 1, 2, 3, 4, 5, 6 };

            Console.Write("Enter Rotate Count :");
            var k = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Before Rotate :");

            foreach (var i in list)
            Console.Write(i + "\t");
            Console.WriteLine();
            for (var j = 0; j < k; j++)
            {
            for (int i = list.Count-1; i >=0; i--)
                {
                    //demo[i] = i;
                    //var index = ((i + 1));
                    //demo.Insert(index, i);
                    //Console.WriteLine(index);
                    //var last = list.Count;
                    //Console.WriteLine(last);
                    //if(i==0)
                   // var temp=
                    demo[i] = list[(i +1)% 6];
                    //demo[(i + 1) % 6] = list[i];
                    //demo[i] = list[i]+4;
                    //demo.Add(list[list.Count - 1]);
                    //demo.Insert((i + 1) % 6, list[i]);
                    //demo.Add(i);
               }
                list.Clear();
                list.AddRange(demo);
         }
            Console.WriteLine("After Rotate :");
            foreach (var i in demo)
            Console.Write(i + "\t");
            Console.WriteLine();
        }

        public void FibonacciNumbers()
        {
            decimal a = 0, b = 1, c = 0;

            Console.Write("{0} {1}", a, b);

            for (int i = 2; i < 100; i++)

            {

                c = a + b;

                Console.Write(" {0}", c);

                a = b;

                b = c;

            }
        }
        public void ListOfDigit()
        {
            var digitList = new List<long>();
            Console.Write("Enter your Number :");
            long number = long.Parse(Console.ReadLine());

            while (number != 0)
            {
                var digit = number % 10;
                number = number / 10;
                digitList.Add(digit);
            }
            digitList.Reverse();

            string list=String.Join(",",digitList);
            Console.WriteLine(list);
        }

        public void RectangularFrameString()
        {

        }

        public void BinarySearch()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6 };
            bool flag = false;
            foreach (var VARIABLE in list)
                Console.Write(VARIABLE + "\t");

            Console.WriteLine();
            Console.Write("Enter Search Value :");
            var value = Convert.ToInt32(Console.ReadLine());
            int start = 0;
            int end = list.Count - 1;

            while (start<=end)
            {
                int mid = (start + end) / 2;

                if (value == list[mid])
                {
                    Console.WriteLine(value+" Found in Index :"+mid);
                    flag = true;
                    break;
                }
                else if (value < list[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            if (flag == false)
                Console.WriteLine(value + " Not Found in List.");
        }
    }
}

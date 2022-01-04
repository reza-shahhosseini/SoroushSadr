using System;
using System.Linq;
namespace GroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            //GroupByExample();
            //GroupBySortByGroupKey();
            GroupBySortByGroupCount();
        }

        private static void GroupByExample(){
            int[] numbers = {1,2,3,4,5,6,7,8,9,10};

            var query = from n in numbers
                        group n by n%3 into grp
                        select new {
                            GroupKey = grp.Key,
                            GroupItems = grp,
                            GroupItemsCount = grp.Count(),
                        };

            foreach(var group in query){
                Console.WriteLine($"numbers in group {group.GroupKey} are:");
                foreach(int number in group.GroupItems){
                    Console.WriteLine(number);
                }
            }            
        }

        private static void GroupBySortByGroupKey(){
            var numbers = new int[]{1,2,3,4,5,6,7,8,9,10};

            var query = from number in numbers 
                        group number by number%3 into grp
                        select new{
                            GroupKey = grp.Key,
                            GroupItems = grp,
                            GroupItemsCount = grp.Count(),
                        };

            // var query2 = (from grp in (
            //         from number in numbers 
            //         group number by number%3 into grp
            //         select new{
            //             GroupKey = grp.Key,
            //             GroupItems = grp,
            //             GroupItemsCount = grp.Count(),
            //         }
            //     )
            //     orderby grp.GroupKey
            //     select grp);

            var query2 = from grp in query
                         orderby grp.GroupKey
                         select grp;

            foreach(var group in query2){
                Console.WriteLine($"Items of group {group.GroupKey} are :");
                foreach(int number in group.GroupItems){
                    Console.WriteLine(number);
                }
            }
        }


        private static void GroupBySortByGroupCount(){
            int[] numbers = {1,2,3,4,5,6,7,8,9,10,28,29,35,62};

            var query = from number in numbers
                        group number by number%3 into grp
                        select new {
                            GroupKey = grp.Key,
                            GroupItems = grp,
                            GroupItemsCount = grp.Count(),
                        };
            var query3 = from grp in query
                         orderby grp.GroupItemsCount descending
                         select grp;

            foreach(var group in query3){
                Console.WriteLine($"Items of group {group.GroupKey} are :");
                foreach(int number in group.GroupItems){
                    Console.WriteLine(number);
                }
            }
        }
    }
}

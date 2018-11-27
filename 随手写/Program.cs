using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 随手写;

namespace 随手写
{
    class Program
    {
        static void Main (string[] args)
        {
            //OperationSome<int> a = new OperationSome<int> ();
            //int ab = a.Add (1 , 2 , 3 , 4);
            //Console.WriteLine (ab);

            //OperationSome<double> b = new OperationSome<double> ();
            //double add= b.Add (1.0 , 2 , 3.3 , 4);
            //Console.WriteLine (add);

            ////OperationSome2<string> c = new 随手写.OperationSome2<string> ();
            ////string str = c.Add ("111" , "222" , "333");
            ////Console.WriteLine (str);

            //OperationSome2<Person> p = new OperationSome2<Person> ();
            //Person p2 = p.Add (new Person () { Id = 1 , Name = "A" } , new Person () { Id = 4 , Name = "C" });
            //Console.WriteLine (p2.ToString ());

            //OperationSome3<string> s = new OperationSome3<string> ();
            //string str = string.Empty;
            //s.Add (ss => str += ss , "111" , "2" , "333");
            //Console.WriteLine ("string类型的和为:"+str);

            //Console.WriteLine ("=====================");

            //OperationSome3<int> list = new OperationSome3<int> ();
            //int sum = 0;
            //list.Add (i => sum += i , 1 , 4 , 3 , 6 , 2 , 6);
            //Console.WriteLine ("int类型的和为:"+sum);

            //Console.WriteLine ("=====================");

            //OperationSome3<Person> p3 = new OperationSome3<Person> ();
            //Person p = new Person ();
            //p3.Add (ps=>p+=ps,new Person () { Id = 1 , Name = "A" } , new Person () { Id = 4 , Name = "C" });
            //Console.WriteLine (p.ToString ());


            //Opt opt = new Opt ();
            //int num = opt.AddStruct (1 , 2 , 3 , 4 , 5);
            //Console.WriteLine (num);
            //double dum = opt.AddStruct (1.0 , 2.1 , 2 , 3 , 4.5);
            //Console.WriteLine (dum);
            //float fum = opt.AddStruct (1.25f , 3.63f , 2.96f , 3.23f);
            //Console.WriteLine (fum);

            //int?[] nu = { 1 , 2 , 3 , 4 , null };

            // List<double> list = new List<double> () { 1.0 , 2.1 , 2 , 3 , 4.5 };
            //int sum= list.Sum ((o) => { return Convert.ToInt32(o); });
            // Console.WriteLine (sum);

            int[] arr = GetArry ();
            Opt opt = new Opt ();
            int num = opt.AddStruct1 (arr); //opt.AddStruct1 (1 , 2 , 3 , 4 , 5);
            Console.WriteLine (num + Environment.NewLine);
            int num2 = opt.AddStruct2 (arr);//opt.AddStruct2 (1 , 2 , 3 , 4 , 5);
            Console.WriteLine (num2 + Environment.NewLine);

            Console.WriteLine (opt.AddDy (arr) + Environment.NewLine);

            Stopwatch watch = new Stopwatch ();
            watch.Start ();
            int sum = arr.Sum ();
            Console.WriteLine ("GetArry ().Sum () is :" + sum);
            Console.WriteLine ("这是系统的======耗时:" + watch.ElapsedMilliseconds + " ms" + Environment.NewLine);

            ////让字符串数组也相加
            //string[] strs = { "A" , "B" , "123" };
            //string str = opt.AddDy (strs);
            //Console.WriteLine (str + Environment.NewLine);

            ////字符数组
            //char[] chars = { 'a' , 'b' , 'c' };
            //Console.WriteLine (opt.AddDy (chars));


            Console.ReadKey ();
        }

        static float[] GetFloat ()
        {
            List<float> list = new List<float> ();
            for ( int i = 0; i < 1000; i++ )
            {
                list.Add (i);
            }
            return list.ToArray ();
        }

        static int[] GetArry ()
        {
            List<int> list = new List<int> ();
            for ( int i = 0; i < 1000; i++ )
            {
                Random r = new Random ();
                list.Add (r.Next(900000,990000));
            }
            return list.ToArray();
        }

        static double[] GetArryD ()
        {
            List<double> list = new List<double> ();
            for ( double i = 0; i < 1000; i++ )
            {
                Random r = new Random ();
                list.Add (r.NextDouble()*10);
            }
            return list.ToArray ();
        }
    }
    
    class Person
    {
        public event Action action;
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

        public Person ()
        {
            this.Id = 0;
            this.Name = "";
        }

        public static Person operator +(Person p1,Person p2)
        {
            return new Person () { Id = p1.Id + p2.Id , Name = p1.Name + p2.Name };
        }

        public override string ToString ()
        {
            return $"Person: {this.Id} {this.Name}";
        }
    }
}

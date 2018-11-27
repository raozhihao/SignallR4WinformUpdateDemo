using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 随手写
{
    public class OperationSome<T> where T:struct
    {
        public T Add(params T[] arr)
        {
            dynamic t=default(T);
            foreach ( T ti in arr )
            {
                t += ti;
            }
            return t;
        }
    }

    public class OperationSome2<T> where T:new () 
    {
        public T Add (params T[] arr)
        {
            //T t1=default(T);
            T a = new T ();
            dynamic t = a;//default (T);
            foreach ( T ti in arr )
            {
                t += ti;
            }
            return t;
        }
    }

    public class OperationSome3<T>
    {
        public void Add (Action<T> selctor,params T[] arr)
        {
            T t1=default(T);
            dynamic t = t1;
            foreach ( T ti in arr )
            {
                selctor?.Invoke (ti);
            }
            
        }
    }

    public class Opt
    {

        public T AddStruct<T>(params T[] arr) where T : struct
        {
            Stopwatch watch = new Stopwatch ();
            watch.Start ();

            //方法1:
            //dynamic temp = default (T);
            //foreach ( T t in arr )
            //{
            //    temp += t;
            //}

            //方法2:
             var temp= (T)TypeDescriptor.GetConverter (default (T).GetType ()).ConvertFrom (arr.Sum (p => { return (double)( (dynamic)p ); }).ToString ());


            Console.WriteLine ("======耗时:" + watch.ElapsedMilliseconds + " ms");
            watch.Stop ();

            return temp;
        }

        public void Add<T>(Action<T> selctor,params T[] arr) 
        {
            T t1 = default (T);
            dynamic t = t1;
            foreach ( T ti in arr )
            {
                selctor?.Invoke (ti);
            }
        }

        public T AddStruct1<T> (params T[] arr) where T : struct
        {
            Stopwatch watch = new Stopwatch ();
            watch.Start ();
            dynamic temp = default (T);
            foreach ( T t in arr )
            {
                temp += t;
            }
           
            Console.WriteLine ("这是我的======耗时:" + watch.ElapsedMilliseconds + " ms");
            return temp;
        }

        public dynamic AddDy (dynamic arr)
        {
            Stopwatch watch = new Stopwatch ();
            watch.Start ();
            dynamic temp = 0.0;
            if ( arr is string[] || arr is string )
            {
                temp = string.Empty;
            }
            foreach ( var item in arr )
            {
                temp += item;
            }
            Console.WriteLine ("这是第三种======耗时:" + watch.ElapsedMilliseconds + " ms");
            return temp;
        }

        public T AddStruct2<T> (params T[] arr) where T : struct
        {
            Stopwatch watch = new Stopwatch ();
            watch.Start ();
            //方法2:
            var temp = (T)TypeDescriptor.GetConverter (default (T).GetType ()).ConvertFrom (arr.Sum (p => { return (double)( (dynamic)p ); }).ToString ());

            Console.WriteLine ("这是他的======耗时:" + watch.ElapsedMilliseconds + " ms");
            watch.Stop ();

            return temp;
        }
    }
}

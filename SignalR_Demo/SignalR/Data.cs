using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR_Demo.SignalR
{
    public class Data
    {
        public void CreateDate ()
        {
            List<Person> list = new List<SignalR.Person> ()
            {
                new Person() { Id=1, Name="A" },
                new Person() { Id=1, Name="B" },
                new Person() { Id=1, Name="C" },
                new Person() { Id=1, Name="D" },
                new Person() { Id=1, Name="E" },
            };
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer ();
            string json = js.Serialize (list);
            string dirPath = System.AppDomain.CurrentDomain.RelativeSearchPath;
            System.IO.File.WriteAllText (System.IO.Path.Combine(dirPath,"config.json") , json);
        }

        public Person GetNewPerson ()
        {

            return null;
        }
    }
}
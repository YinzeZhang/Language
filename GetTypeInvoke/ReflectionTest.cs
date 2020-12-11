using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

//C# 反射技术实现：对象转json，json转对象
namespace GetTypeInvoke
{

    class ReflectionTest
    {
        public static string Tojson(object obj)
        {
            StringBuilder builder = new StringBuilder("{");
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var item in properties)
            {
                builder.AppendFormat("\"{0}\":\"{1}\",", item.Name, item.GetValue(obj, null));
            }
            string json = builder.ToString();
            json = json.Substring(0, json.Length - 1);
            json += "}";
            return json;
        }

        public static T FromJson<T>(string json, Type type)
        {
            try
            {
                object obj = Activator.CreateInstance(type);
                Console.WriteLine(obj.GetType());
                PropertyInfo[] properties = type.GetProperties();
                Dictionary<string, object> valus = new Dictionary<string, object>();
                string[] str = json.Substring(1, json.Length - 2).Split(',');
                foreach (var item in str)
                {
                    string[] keyValue = item.Split(':');
                    valus.Add(keyValue[0].Replace("\"", ""), keyValue[1].Replace("\"", ""));
                }
                foreach (var item in properties)
                {
                    object value = valus[item.Name];

                    if (item.PropertyType == typeof(Int32))
                    {

                        value = Convert.ToInt32(value);
                    }
                    type.InvokeMember(item.Name, BindingFlags.SetProperty, null, obj, new object[] { value });
                }

                return (T)obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void test()
        {
            Student student = new Student();
            student.age = 18;
            student.name = "张三";
            student.Id = 1000;
            string json = Tojson(student);
            Console.WriteLine(json);
            //Student s = FromJson<Student>(json, new Student().GetType());
            Student s = FromJson<Student>(json, Type.GetType("GetTypeInvoke.Student"));
            Console.WriteLine("编号：{0}\n 姓名：{1}\n年龄：{2} ", s.Id, s.name, s.age);
            Console.ReadKey();
        }

    }

    public class Student
    {
        public string name { get; set; }

        public int age { get; set; }

        public int Id { get; set; }

    }
}
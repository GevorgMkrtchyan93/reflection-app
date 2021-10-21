using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ReflectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Type myType = Type.GetType("ReflectionApp.User", false, true);

            Console.WriteLine("Methods");

            foreach (MethodInfo method in myType.GetMethods())
            {
                string modificator = "";
                if (method.IsStatic)
                {
                    modificator += "static";
                }
                if (method.IsVirtual)
                {
                    modificator += "virtual";
                }

                Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} ( ");

                ParameterInfo[] parameters = method.GetParameters();

                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if (i + 1 < parameters.Length)
                    {
                        Console.WriteLine(",");
                    }
                }
                Console.WriteLine(")");
            }

            Console.WriteLine(new string('_', 50));
            Console.WriteLine("Constructors");

            foreach (_ConstructorInfo ctor in myType.GetConstructors())
            {
                Console.Write(myType.Name + "(");
                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length)
                    {
                        Console.Write(",");
                    }
                }
                Console.WriteLine(")");
            }

            Console.WriteLine(new string('_', 50));
            Console.WriteLine("Fields");

            foreach (FieldInfo field in myType.GetFields())
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
            }

            Console.WriteLine("Properties");

            foreach (PropertyInfo prop in myType.GetProperties())
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }

            Console.WriteLine("Implemented interfaces");

            foreach (Type i in myType.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }

           

            Console.WriteLine(new string('_',50));

            Assembly asm = Assembly.LoadFrom("ClassLibrary2.dll");

            Console.WriteLine(asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine(t.Name);
            }

            Console.WriteLine(new string('_', 50));

            try
            {
                Assembly asm1 = Assembly.LoadFrom("ClassLibrary2.dll");

                Type t1 = asm1.GetType("ReflectionApp.Class1", true, true);

                object obj = Activator.CreateInstance(t1);
                MethodInfo method = t1.GetMethod("GetResult");

                object result = method.Invoke(obj, new object[] { 6, 100, 3 });
                Console.WriteLine(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(new string('_', 50));
         
            User user = new User("Narek", 30);
            User user1 = new User("Arman", 25);
            bool userIsValid = ValidateUser(user);
            bool user1IsValid = ValidateUser(user1);

            int payment = user.Payment(8, 3000);
            user.Display();
            Console.WriteLine($"Payment={payment}");

            Console.ReadLine();
        }

        private static bool ValidateUser(User user)
        {
            Type t = typeof(User);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (AgeValidationAttribute attr in attrs)
            {
                if (user.Age >= attr.Age)
                {
                    return true;
                }
                else return false;
            }
            return true;
        }
        
    }
}

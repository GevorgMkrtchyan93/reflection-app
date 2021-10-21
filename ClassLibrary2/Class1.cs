using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Class1
    {
        public static double GetResult(int percent,double capital,int year)
        {
            for (int i = 0; i < year; i++)
            {
                capital += capital / 100 * percent;
            }
            return capital;
        }
    }
}

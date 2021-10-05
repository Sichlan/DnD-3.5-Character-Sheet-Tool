using NCalc2;
using System;

namespace MathParserTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Not working
            string ex = "3d6d1+2";


            Expression expression = new Expression(ex);
            expression.EvaluateParameter += delegate (string name, ParameterArgs arg)
            {

            };
            expression.EvaluateFunction += delegate (string name, FunctionArgs arg)
            {
                throw new NotImplementedException();
            };
            Console.WriteLine(expression.Evaluate());
            Console.Read();
        }
    }
}

//Write a program that calculates the value of given arithmetical expression.
//The expression can contain the following elements only:
//Real numbers, e.g. 5, 18.33, 3.14159, 12.6
//Arithmetic operators: +, -, *, / (standard priorities)
//Mathematical functions: ln(x), sqrt(x), pow(x,y)
//Brackets (for changing the default priorities): (, )

namespace ArithmeticalExpressions
{
    class ArithmeticalExpressions
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator(" (pow(5,2) - sqrt(25))/((6/3)*2)");
            System.Console.WriteLine(calculator.Result);
            System.Console.WriteLine(calculator.ReversedPolishNotation);
        }
    }
}

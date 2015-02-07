
namespace ArithmeticalExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class Calculator
    {
        private string infixExpression;
        private Token[] tokens;
        private double result;
        private string reversedPolishNotationStr;
        private bool inFunction = false;
        private bool afterFunction = false;

        public Calculator(string infix)
        {
            this.infixExpression = infix.ToLower();
            string[] stringTokens = Tokenize(this.infixExpression);
            ConvertToToken(stringTokens);
            Token[] reversedPolishNotation = ToPolishNotation();
            this.ReversedPolishNotation = GetExpressionString(reversedPolishNotation);
            this.Result = Calculate(reversedPolishNotation);
        }

        public double Result
        {
            get
            {
                return this.result;
            }
            private set
            {
                this.result = value;
            }
        }

        public string ReversedPolishNotation
        {
            get
            {
                return this.reversedPolishNotationStr;
            }
            private set
            {
                this.reversedPolishNotationStr = value;
            }
        }

        private string GetExpressionString(Token[] reversedPolishNotation)
        {
            StringBuilder result = new StringBuilder();

            foreach (var token in reversedPolishNotation)
            {
                if (token.Type == TokenType.Number)
                {
                    result.Append(" " + token.Value + " ");
                }
                else if (token.Type == TokenType.Operator)
                {
                    switch (token.OperatorType)
                    {
                        case OperatorType.Addition:
                            result.Append(" + ");
                            break;
                        case OperatorType.Substraction:
                            result.Append(" - ");
                            break;
                        case OperatorType.Mulitiplication:
                            result.Append(" * ");
                            break;
                        case OperatorType.Partition:
                            result.Append(" / ");
                            break;
                        case OperatorType.UnaryMinus:
                            result.Append(" _ ");
                            break;
                    }
                }
                else if (token.Type == TokenType.Function)
                {
                    switch (token.FunctionType)
                    {
                        case FunctionType.Log:
                            result.Append(" LOG ");
                            break;
                        case FunctionType.Sqrt:
                            result.Append(" SQRT ");
                            break;
                        case FunctionType.Pow:
                            result.Append(" POW ");
                            break;
                    }
                }
            }

            return result.ToString();
        }

        private double Calculate(Token[] reversedPolishNotation)
        {
            Stack<Token> numberStack = new Stack<Token>();

            for (int index = 0; index < reversedPolishNotation.Length; index++)
            {
                if (reversedPolishNotation[index].Type == TokenType.Number)
                {
                    numberStack.Push(reversedPolishNotation[index]);
                }
                else
                {
                    if (reversedPolishNotation[index].Type == TokenType.Operator)
                    {
                        List<Token> operands = new List<Token>();
                        for (int count = 0; count < reversedPolishNotation[index].OperandsCount; count++)
                        {
                            operands.Add(numberStack.Pop());
                        }
                        numberStack.Push(ExecuteOperation(operands, reversedPolishNotation[index].OperatorType));
                    }
                    else if (reversedPolishNotation[index].Type == TokenType.Function)
                    {
                        List<Token> operands = new List<Token>();
                        for (int count = 0; count < reversedPolishNotation[index].OperandsCount; count++)
                        {
                            operands.Add(numberStack.Pop());
                        }
                        numberStack.Push(ExecuteFunction(operands, reversedPolishNotation[index].FunctionType));
                    }
                }
            }

            if (numberStack.Count == 1)
            {
                return numberStack.Pop().Value;
            }
            else
            {
                throw new Exception("Invalid expression");
            }
        }

        private Token ExecuteFunction(List<Token> operands, FunctionType functionType)
        {
            switch (functionType)
            {
                case FunctionType.Log:
                    operands[0].Value = Math.Log(operands[0].Value);
                    break;
                case FunctionType.Sqrt:
                    operands[0].Value = Math.Sqrt(operands[0].Value);
                    break;
                case FunctionType.Pow:
                    operands[0].Value = Math.Pow(operands[1].Value, operands[0].Value);
                    break;
                default:
                    break;
            }

            return operands[0];
        }

        private Token ExecuteOperation(List<Token> operands, OperatorType operatorType)
        {
            switch (operatorType)
            {
                case OperatorType.Addition:
                    operands[0].Value = operands[1].Value + operands[0].Value;
                    break;
                case OperatorType.Substraction:
                    operands[0].Value = operands[1].Value - operands[0].Value;
                    break;
                case OperatorType.Mulitiplication:
                    operands[0].Value = operands[1].Value * operands[0].Value;
                    break;
                case OperatorType.Partition:
                    operands[0].Value = operands[1].Value / operands[0].Value;
                    break;
                case OperatorType.UnaryMinus:
                    operands[0].Value = -operands[0].Value;
                    break;
                default:
                    throw new Exception("Invalid operation.");
            }

            return operands[0];
        }

        private Token[] ToPolishNotation()
        {
            Queue<Token> outputQueue = new Queue<Token>();
            Stack<Token> operatorStack = new Stack<Token>();

            for (int index = 0; index < this.tokens.Length; index++)
            {
                if (this.tokens[index].Type == TokenType.Number)
                {
                    outputQueue.Enqueue(this.tokens[index]);
                }
                else
                {
                    if (this.tokens[index].Type == TokenType.Operator)
                    {
                        if (this.tokens[index].OperatorType == OperatorType.OpeningBrace)
                        {
                            operatorStack.Push(this.tokens[index]);
                        }
                        else if (this.tokens[index].OperatorType == OperatorType.ClosingBrace)
                        {
                            while (true)
                            {
                                Token temp = operatorStack.Pop();
                                if (temp.OperatorType == OperatorType.OpeningBrace)
                                    break;
                                outputQueue.Enqueue(temp);
                            }
                        }
                        else
                        {
                            while (operatorStack.Count > 0 &&
                                operatorStack.Peek().Precedence >= this.tokens[index].Precedence)
                            {
                                outputQueue.Enqueue(operatorStack.Pop());
                            }
                            operatorStack.Push(this.tokens[index]);
                        }
                    }
                    else if (this.tokens[index].Type == TokenType.Function)
                    {
                        if (this.tokens[index].FunctionType != FunctionType.Separator)
                        {
                            operatorStack.Push(this.tokens[index]);
                        }
                        else
                        {
                            while (true)
                            {
                                Token temp = operatorStack.Peek();
                                if(temp.Type==TokenType.Operator && 
                                    temp.OperatorType == OperatorType.OpeningBrace)
                                {
                                    break;
                                }
                                outputQueue.Enqueue(operatorStack.Pop());
                            }
                        }
                    }
                }
            }

            while (operatorStack.Count > 0)
            {
                outputQueue.Enqueue(operatorStack.Pop());
            }

            return outputQueue.ToArray();
        }

        private void ConvertToToken(string[] stringTokens)
        {
            this.tokens = new Token[stringTokens.Length];
            double value = 0;

            for (int index = 0; index < this.tokens.Length; index++)
            {
                if (double.TryParse(stringTokens[index], out value))
                {
                    this.tokens[index] = new Token(value);
                }
                else
                {
                    switch (stringTokens[index])
                    {
                        case "+":
                            afterFunction = false;
                            this.tokens[index] = new Token(OperatorType.Addition, 2, Associativity.Left);
                            break;
                        case "-":
                            if (index == 0 ||
                                (this.tokens[index - 1].Type == TokenType.Operator &&
                                (this.tokens[index - 1].OperatorType == OperatorType.OpeningBrace ||
                                this.tokens[index - 1].OperatorType == OperatorType.ClosingBrace)))
                            {
                                if (afterFunction)
                                {
                                    afterFunction = false;
                                    this.tokens[index] = new Token(OperatorType.Substraction, 2, Associativity.Left);
                                }
                                else
                                {
                                    this.tokens[index] = new Token(OperatorType.UnaryMinus, 1, Associativity.Left);
                                }
                            }
                            else
                            {
                                this.tokens[index] = new Token(OperatorType.Substraction, 2, Associativity.Left);
                            }
                            break;
                        case "*":
                            afterFunction = false;
                            this.tokens[index] = new Token(OperatorType.Mulitiplication, 2, Associativity.Left);
                            break;
                        case "/":
                            afterFunction = false;
                            this.tokens[index] = new Token(OperatorType.Partition, 2, Associativity.Left);
                            break;
                        case "(":
                            this.tokens[index] = new Token(OperatorType.OpeningBrace, 0, Associativity.Right);
                            break;
                        case ")":
                            this.tokens[index] = new Token(OperatorType.ClosingBrace, 0, Associativity.Right);
                            if (inFunction)
                            {
                                inFunction = false;
                                afterFunction = true;
                            }
                            break;
                        case "pow":
                            this.tokens[index] = new Token(FunctionType.Pow, 2);
                            inFunction = true;
                            break;
                        case "log":
                            this.tokens[index] = new Token(FunctionType.Log, 1);
                            inFunction = true;
                            break;
                        case "sqrt":
                            this.tokens[index] = new Token(FunctionType.Sqrt, 1);
                            inFunction = true;
                            break;
                        case ",":
                            this.tokens[index] = new Token(FunctionType.Separator, 0);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private string[] Tokenize(string infix)
        {
            this.infixExpression = this.infixExpression.Replace("*", " * ");
            this.infixExpression = this.infixExpression.Replace("+", " + ");
            this.infixExpression = this.infixExpression.Replace("-", " - ");
            this.infixExpression = this.infixExpression.Replace("^", " ^ ");
            this.infixExpression = this.infixExpression.Replace("/", " / ");
            this.infixExpression = this.infixExpression.Replace("(", " ( ");
            this.infixExpression = this.infixExpression.Replace(")", " ) ");
            this.infixExpression = this.infixExpression.Replace("pow", " pow ");
            this.infixExpression = this.infixExpression.Replace("log", " log ");
            this.infixExpression = this.infixExpression.Replace("sqrt", " sqrt ");
            this.infixExpression = this.infixExpression.Replace(",", " , ");

            string[] stringTokens = this.infixExpression
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            return stringTokens;
        }
    }
}

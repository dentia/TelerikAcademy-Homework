
namespace ArithmeticalExpressions
{
    using System;
    public class Token
    {
        private TokenType type;

        // number
        private double value;

        // operator
        private OperatorType operatorType;
        private Associativity assoc;
        private int precedence;

        private int operandsCount;
        // funcion
        private FunctionType functionType;


        public Token(double value)
        {
            this.Type = TokenType.Number;
            this.Value = value;
        }

        public Token(OperatorType operatorType, int operandsCount, Associativity assoc)
        {
            this.Type = TokenType.Operator;
            this.OperatorType = operatorType;
            this.OperandsCount = operandsCount;
            this.Associativity = assoc;
            this.Precedence = GetPrecedence();
        }

        public Token(FunctionType functionType, int operandsCount)
        {
            this.Type = TokenType.Function;
            this.FunctionType = functionType;
            this.OperandsCount = operandsCount;
            this.Precedence = GetPrecedence();
        }

        public TokenType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public double Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public FunctionType FunctionType
        {
            get
            {
                return this.functionType;
            }
            set
            {
                this.functionType = value;
            }
        }

        public OperatorType OperatorType
        {
            get
            {
                return this.operatorType;
            }
            set
            {
                this.operatorType = value;
            }
        }

        public int OperandsCount
        {
            get
            {
                return this.operandsCount;
            }
            set
            {
                this.operandsCount = value;
            }
        }

        private Associativity Associativity
        {
            get
            {
                return this.assoc;
            }
            set
            {
                this.assoc = value;
            }
        }

        public int Precedence
        {
            get
            {
                return this.precedence;
            }
            set
            {
                this.precedence = value;
            }
        }

        private int GetPrecedence()
        {
            if (this.Type == TokenType.Function)
                return 50;
            switch (this.OperatorType)
            {
                case OperatorType.Addition:
                case OperatorType.Substraction:
                    return 10;
                case OperatorType.Mulitiplication:
                case OperatorType.Partition:
                    return 20;
                case OperatorType.OpeningBrace:
                case OperatorType.ClosingBrace:
                    return 0;
                case OperatorType.UnaryMinus:
                    return 40;
                default:
                    throw new Exception("Invalid operator");
            }
        }
    }
}

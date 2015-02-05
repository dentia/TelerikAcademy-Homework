
namespace PolynomialOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class Polynomial
    {
        private long maxPower;
        private List<Mononomial> mononomials;
        private string literal;

        public Polynomial(string literal)
        {
            this.Literal = literal.ToLower();
            this.maxPower = -1;
            this.Mononomials = new List<Mononomial>();
        }

        private string Literal
        {
            get
            {
                return this.literal;
            }
            set
            {
                this.literal = value;
            }
        }

        private uint MaxPower
        {
            get
            {
                return (uint)this.maxPower;
            }
            set
            {
                this.maxPower = value;
            }
        }

        private List<Mononomial> Mononomials
        {
            get
            {
                return this.mononomials;
            }
            set
            {
                this.mononomials = value;
            }
        }

        public bool HasAnyMononomials()
        {
            return (this.maxPower > -1);
        }

        public void AddMononomial(Mononomial mononomial)
        {
            this.Mononomials.Add(mononomial);
            this.maxPower = Math.Max(this.maxPower, mononomial.Power);
        }

        public void AddMononomials(ICollection<Mononomial> mononomials)
        {
            this.Mononomials.AddRange(mononomials);
            this.maxPower = Math.Max(this.maxPower, mononomials.Select(x => x.Power).Max());
        }

        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            if (!a.HasAnyMononomials() || !b.HasAnyMononomials())
            {
                throw new ArgumentNullException("polynomial", "Both polynomials must have at least one mononomial.");
            }

            uint maxPower = Math.Max(a.MaxPower, b.MaxPower);
            List<Mononomial> mononomials = new List<Mononomial>();

            for (uint pow = 0; pow <= maxPower; pow++)
            {
                decimal tempCoeff = 0.0m;
                tempCoeff += a.Mononomials.Where(x => x.Power == pow).Select(x => x.Coefficient).ToArray().Sum();
                tempCoeff += b.Mononomials.Where(x => x.Power == pow).Select(x => x.Coefficient).ToArray().Sum();
                mononomials.Add(new Mononomial(tempCoeff, pow));
            }
            mononomials = mononomials.Where(x => x != null).ToList();
            string literal = (a.Literal == b.Literal) ? b.Literal : a.Literal + b.Literal;

            Polynomial result = new Polynomial(literal);
            result.AddMononomials(mononomials);
            return result;
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            Polynomial negativeB = new Polynomial(b.Literal);
            foreach (var mononomial in b.Mononomials)
            {
                negativeB.AddMononomial(new Mononomial(-mononomial.Coefficient, mononomial.Power));
            }

            Polynomial result = a + negativeB;
            return result;
        }

        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            uint maxPower = a.MaxPower + b.MaxPower;
            List<Mononomial> mononomials = new List<Mononomial>();

                foreach (var mononomialA in a.Mononomials)
                {
                    foreach (var mononomialB in b.Mononomials)
                    {
                        decimal tempCoeff = mononomialA.Coefficient;
                        tempCoeff *= mononomialB.Coefficient;
                        uint tempPow = mononomialA.Power + mononomialB.Power;

                        mononomials.Add(new Mononomial(tempCoeff, tempPow));
                    }
                }
            mononomials = mononomials.Where(x => x != null).ToList();
            string literal = (a.Literal == b.Literal) ? b.Literal : a.Literal + b.Literal;

            Polynomial result = new Polynomial(literal);
            result.AddMononomials(mononomials);
            return result;
        }

        private void ClearZeros()
        {
            for (int mononomial = 0; mononomial < this.Mononomials.Count - 1; mononomial++)
            {
                uint pow = this.Mononomials[mononomial].Power;
                decimal coeff = this.Mononomials[mononomial].Coefficient;

                uint nextPow = this.Mononomials[mononomial + 1].Power;
                decimal nextCoeff = this.Mononomials[mononomial + 1].Coefficient;

                if (pow == nextPow && coeff == -nextCoeff)
                {
                    this.Mononomials.RemoveRange(mononomial, 2);
                    mononomial -= 2;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            this.Mononomials = this.Mononomials.OrderByDescending(x => x.Power).ToList();
            ClearZeros();

            foreach (var mononomial in this.Mononomials)
            {
                if (mononomial.Coefficient == 0.0m)
                    continue;
                result.Append(String.Format("{3} {0:0.##}{1}^{2} ", Math.Abs(mononomial.Coefficient),
                    this.Literal, mononomial.Power, (mononomial.Coefficient >= 0) ? '+' : '-'));
            }

            return result.ToString().TrimStart(new char[] { '+', ' ' });
        }
    }
}
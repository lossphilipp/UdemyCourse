using System;
using System.Numerics;

namespace Coding.Exercise
{
    public interface IDiscriminantStrategy
    {
        double CalculateDiscriminant(double a, double b, double c);
    }

    public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            return ((b * b) - (4 * a * c));
        }
    }

    public class RealDiscriminantStrategy : IDiscriminantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            double solution = ((b * b) - (4 * a * c));
            if (solution < 0)
            {
                return double.NaN;
            }
            return solution;
        }
    }

    public class QuadraticEquationSolver
    {
        private readonly IDiscriminantStrategy strategy;

        public QuadraticEquationSolver(IDiscriminantStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            double discriminant = strategy.CalculateDiscriminant(a, b, c);

            Complex plusResult;
            Complex minusResult;

            if (discriminant < 0)
            {
                Complex imaginaryPart = Complex.Sqrt(new Complex(discriminant, 0));
                plusResult = (-b + imaginaryPart) / (2 * a);
                minusResult = (-b - imaginaryPart) / (2 * a);
            }
            else
            {
                plusResult = (-b + Complex.Sqrt(discriminant)) / (2 * a);
                minusResult = (-b - Complex.Sqrt(discriminant)) / (2 * a);
            }
            return new Tuple<Complex, Complex>(plusResult, minusResult);
        }
    }
}
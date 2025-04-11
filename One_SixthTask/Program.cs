// sixth task

using One_SixthTask;

NewtonMethod.FindRoots();



// package org.example;
//
// import java.util.function.Function;
//
// public class Main {
//     public static void main(String[] args) {
//         Function<Double, Double> f = x -> Math.pow(x - 1, 3) * Math.sin(Math.PI * x) * (Math.cos(2 * Math.PI * x) - 1);
//         Function<Double, Double> df = x -> {
//             double term1 = 3 * Math.pow(x - 1, 2) * Math.sin(Math.PI * x) * (Math.cos(2 * Math.PI * x) - 1);
//             double term2 = Math.PI * Math.pow(x - 1, 3) * Math.cos(Math.PI * x) * (Math.cos(2 * Math.PI * x) - 1);
//             double term3 = 2 * Math.PI * Math.pow(x - 1, 3) * Math.sin(Math.PI * x) * Math.sin(2 * Math.PI * x);
//             return term1 + term2 - term3;
//         };
//
//         double[] tolerances = {1e-3, 1e-4, 1e-5, 1e-6};
//
//         double[] initialGuesses = {0.5, 1.5, 2.5};
//         int[] multiplicities = {3, 1, 1};
//
//         for (int i = 0; i < initialGuesses.length; i++) {
//             System.out.printf("\nПоиск корня #%d около x0 = %.1f (кратность %d):\n",
//                     i + 1, initialGuesses[i], multiplicities[i]);
//             System.out.println("Точность | Модиф.Ньютона | Обычный Ньютон");
//             System.out.println("---------|---------------|---------------");
//
//             for (double tol : tolerances) {
//                 Result modResult = modifiedNewton(f, df, initialGuesses[i], multiplicities[i], tol);
//                 Result stdResult = standardNewton(f, df, initialGuesses[i], tol);
//
//                 System.out.printf("%.0e | %11d | %13d\n",
//                         tol, modResult.iterations, stdResult.iterations);
//             }
//         }
//     }
//
//     static Result modifiedNewton(Function<Double, Double> f, Function<Double, Double> df,
//                                  double x0, int p, double tol) {
//         int iterations = 0;
//         double x = x0;
//         double fx = f.apply(x);
//
//         while (Math.abs(fx) > tol) {
//             double dfx = df.apply(x);
//             if (Math.abs(dfx) < 1e-15) {
//                 throw new ArithmeticException("Производная близка к нулю");
//             }
//             x = x - p * fx / dfx;
//             fx = f.apply(x);
//             iterations++;
//             if (iterations > 1000) break;
//         }
//         return new Result(x, iterations);
//     }
//
//     static Result standardNewton(Function<Double, Double> f, Function<Double, Double> df,
//                                  double x0, double tol) {
//         int iterations = 0;
//         double x = x0;
//         double fx = f.apply(x);
//
//         while (Math.abs(fx) > tol) {
//             double dfx = df.apply(x);
//             if (Math.abs(dfx) < 1e-15) {
//                 throw new ArithmeticException("Производная близка к нулю");
//             }
//             x = x - fx / dfx;
//             fx = f.apply(x);
//             iterations++;
//             if (iterations > 1000) break;
//         }
//         return new Result(x, iterations);
//     }
//
//     static class Result {
//         double root;
//         int iterations;
//
//         Result(double root, int iterations) {
//             this.root = root;
//             this.iterations = iterations;
//         }
//     }
// }


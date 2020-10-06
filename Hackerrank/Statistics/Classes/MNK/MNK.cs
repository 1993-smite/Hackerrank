using System;
using System.Collections.Generic;
using System.Text;

namespace Statistics.Classes.MNK
{
    public static class ArrayExtension
    {
        public static double Sum(this double[] arr)
        {
            double sum = 0;
            foreach (var it in arr)
                sum += it;
            return sum;
        }

        public static double[,] Transpone(this double[,] matrix)
        {
            double[,] mass = new double[matrix.GetLength(1), matrix.GetLength(0)];

            for(int i=0;i< matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    mass[j, i] = matrix[i, j];
                }
            }

            return mass;
        }

        public static double[,] Mult(this double[,] matrix, double[,] arr)
        {
            if (matrix.GetLength(1) != arr.GetLength(0))
                throw new ArgumentException("Not available argumemt");

            double[,] mass = new double[matrix.GetLength(0), arr.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k= 0; k < matrix.GetLength(1); k++)
                    {
                        mass[i, j] += matrix[i, k] * arr[k, j];
                    }
                }
            }

            return mass;
        }

        public static double[,] MatrixCreate(int rows, int cols)
        {
            // Создаем матрицу, полностью инициализированную
            // значениями 0.0. Проверка входных параметров опущена.
            double[,] result = new double[rows,cols];
            return result;
        }

        public static double[,] MatrixDuplicate(this double[,] matrix)
        {
            // Предполагается, что матрица не нулевая
            double[,] result = MatrixCreate(matrix.GetLength(0), matrix.GetLength(1));
            for (int i = 0; i < matrix.GetLength(0); ++i) // Копирование значений
                for (int j = 0; j < matrix.GetLength(1); ++j)
                    result[i,j] = matrix[i,j];
            return result;
        }

        public static double[,] CopyLine(this double[,] matrix, int line1, int line2)
        {
            double buff;
            for (int i = 0; i < matrix.GetLength(1); ++i) // Копирование значений
            {
                buff = matrix[line1, i];
                matrix[line1, i] = matrix[line2, i];
                matrix[line2, i] = buff;
            }
            return matrix;
        }

        public static double[,] MatrixDecompose(this double[,] matrix, out int[] perm, out int toggle)
        {
            // Разложение LUP Дулитла. Предполагается,
            // что матрица квадратная.
            int n = matrix.GetLength(0); // для удобства
            double[,] result = matrix.MatrixDuplicate();
            perm = new int[n];
            for (int i = 0; i < n; ++i) { perm[i] = i; }
            toggle = 1;
            for (int j = 0; j < n - 1; ++j) // каждый столбец
            {
                double colMax = Math.Abs(result[j,j]); // Наибольшее значение в столбце j
                int pRow = j;
                for (int i = j + 1; i < n; ++i)
                {
                    if (result[i,j] > colMax)
                    {
                        colMax = result[i,j];
                        pRow = i;
                    }
                }
                if (pRow != j) // перестановка строк
                {
                    result.CopyLine(pRow, j);
                    /*double[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;*/
                    int tmp = perm[pRow]; // Меняем информацию о перестановке
                    perm[pRow] = perm[j];
                    perm[j] = tmp;
                    toggle = -toggle; // переключатель перестановки строк
                }
                if (Math.Abs(result[j,j]) < 1.0E-20)
                    return null;
                for (int i = j + 1; i < n; ++i)
                {
                    result[i,j] /= result[j,j];
                    for (int k = j + 1; k < n; ++k)
                        result[i,k] -= result[i,j] * result[j,k];
                }
            } // основной цикл по столбцу j
            return result;
        }

        public static double[] HelperSolve(this double[,] luMatrix, double[] b)
        {
            // Решаем luMatrix * x = b
            int n = luMatrix.GetLength(0);
            double[] x = new double[n];
            b.CopyTo(x, 0);
            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i,j] * x[j];
                x[i] = sum;
            }
            x[n - 1] /= luMatrix[n - 1,n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i,j] * x[j];
                x[i] = sum / luMatrix[i,i];
            }
            return x;
        }

        public static double[,] MatrixInverse(this double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double[,] result = matrix.MatrixDuplicate();
            int[] perm;
            int toggle;
            double[,] lum = matrix.MatrixDecompose(out perm, out toggle);
            if (lum == null)
                throw new Exception("Unable to compute inverse");
            double[] b = new double[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;
                }
                double[] x = lum.HelperSolve(b);
                for (int j = 0; j < n; ++j)
                    result[j,i] = x[j];
            }
            return result;
        }
    }

    public static class Matrix
    {
        public static decimal[][] create(int rows, int cols)
        {
            decimal[][] result = new decimal[rows][];
            for (int i = 0; i < rows; i++)
                result[i] = new decimal[cols];
            return result;
        }

        /* Multiplies 2 matrices in O(n^3) time */
        public static decimal[][] multiply(decimal[][] A, decimal[][] B)
        {
            int aRows = A.Length;
            int aCols = A[0].Length;
            int bRows = B.Length;
            int bCols = B[0].Length;

            decimal[][] C = Matrix.create(aRows, bCols);
            int cRows = C.Length;
            int cCols = bCols;

            for (int row = 0; row < cRows; row++)
            {
                C[row] = new decimal[cCols];
                for (int col = 0; col < cCols; col++)
                {
                    for (int k = 0; k < aCols; k++)
                    {
                        C[row][col] += A[row][k] * B[k][col];
                    }
                }
            }
            return C;
        }

        public static decimal[][] transpose(decimal[][] matrix)
        {
            /* Create new array with switched dimensions */
            int originalRows = matrix.Length;
            int originalCols = matrix[0].Length;
            int rows = originalCols;
            int cols = originalRows;
            decimal[][] result = Matrix.create(rows, cols);

            /* Fill our new 2D array */
            for (int row = 0; row < originalRows; row++)
            {
                for (int col = 0; col < originalCols; col++)
                {
                    result[col][row] = matrix[row][col];
                }
            }
            return result;
        }

        /******************************************************************/
        /* Matrix Inversion code (shown below) is from:                   */
        /*   http://www.sanfoundry.com/java-program-find-inverse-matrix/  */
        /******************************************************************/

        public static decimal[][] invert(decimal[][] a)
        {
            int n = a.Length;
            decimal[][] x = new decimal[n][];
            decimal[][] b = new decimal[n][];

            for (int i = 0; i < n; i++)
            {
                x[i] = new decimal[n];
                b[i] = new decimal[n];
            }

            int[] index = new int[n];
            for (int i = 0; i < n; ++i)
                b[i][i] = 1;

            // Transform the matrix into an upper triangle
            Matrix.gaussian(a, index);

            // Update the matrix b[i][j] with the ratios stored
            for (int i = 0; i < n - 1; ++i)
                for (int j = i + 1; j < n; ++j)
                    for (int k = 0; k < n; ++k)
                    {
                        b[index[j]][k]
                                -= a[index[j]][i] * b[index[i]][k];
                    }

            // Perform backward substitutions
            for (int i = 0; i < n; ++i)
            {
                x[n - 1][i] = b[index[n - 1]][i] / a[index[n - 1]][n - 1];
                for (int j = n - 2; j >= 0; --j)
                {
                    x[j][i] = b[index[j]][i];
                    for (int k = j + 1; k < n; ++k)
                    {
                        x[j][i] -= a[index[j]][k] * x[k][i];
                    }
                    x[j][i] /= a[index[j]][j];
                }
            }
            return x;
        }

        // Method to carry out the partial-pivoting Gaussian
        // elimination.  Here index[] stores pivoting order.

        public static void gaussian(decimal[][] a, int[] index)
        {
            int n = index.Length;
            decimal[] c = new decimal[n];

            // Initialize the index
            for (int i = 0; i < n; ++i)
                index[i] = i;

            // Find the rescaling factors, one from each row
            for (int i = 0; i < n; ++i)
            {
                decimal c1 = 0;
                for (int j = 0; j < n; ++j)
                {
                    decimal c0 = Math.Abs(a[i][j]);
                    if (c0 > c1) c1 = c0;
                }
                c[i] = c1;
            }

            // Search the pivoting element from each column
            int k = 0;
            for (int j = 0; j < n - 1; ++j)
            {
                decimal pi1 = 0;
                for (int i = j; i < n; ++i)
                {
                    decimal pi0 = Math.Abs(a[index[i]][j]);
                    pi0 /= c[index[i]];
                    if (pi0 > pi1)
                    {
                        pi1 = pi0;
                        k = i;
                    }
                }

                // Interchange rows according to the pivoting order
                int itmp = index[j];
                index[j] = index[k];
                index[k] = itmp;
                for (int i = j + 1; i < n; ++i)
                {
                    decimal pj = a[index[i]][j] / a[index[j]][j];

                    // Record pivoting ratios below the diagonal
                    a[index[i]][j] = pj;

                    // Modify other elements accordingly
                    for (int l = j + 1; l < n; ++l)
                        a[index[i]][l] -= pj * a[index[j]][l];
                }
            }
        }
    }

    public class MNK
    {
        public static double B(double[] x, double[] y)
        {
            //X^t * X
            double res = 0;
            foreach (var it in x)
                res += it * it;

            //X^t * Y
            double resH = 0;
            for (int i = 0; i < x.Length; i++)
                resH += x[i] * y[i];

            //(X^t * X)^-1 * X^t * y
            return resH / res;
        }

        public static double[,] B(double[,] x, double[] y)
        {
            //(X^t * X) ^ 1
            var xt = x.Transpone();
            var res = xt.Mult(x).MatrixInverse();


            //* X^t * Y
            var h = res.Mult(x.Transpone());

            var yy = new double[y.Length, 1];
            for (int i = 0; i < y.Length; i++)
                yy[i, 0] = y[i];

            var result = h.Mult(yy);

            //(X^t * X)^-1 * X^t * y
            return result;
        }

        public static double[] BA(double[] x, double[] y)
        {
            double[] result = new double[2];

            int n = x.Length;

            //X^t * Y
            double resXY = 0;
            for (int i = 0; i < x.Length; i++)
                resXY += x[i] * y[i];

            double sx = x.Sum();
            double sy = y.Sum();

            double sqx = 0;
            foreach (var it in x)
                sqx += it * it;

            result[1] = (n * resXY - sx * sy) 
                      / (n * sqx - sx * sx);

            result[0] = (sy - result[1] * sx) / n;
            //(X^t * X)^-1 * X^t * y
            return result;
        }
    }
}

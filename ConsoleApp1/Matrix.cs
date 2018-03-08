using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinealAlg
{
    public class Matrix
    {
        public int row { get; set; }
        public int column { get; set; }


        public Matrix(int row, int column)
        {
            arry = new double[row, column];
            this.row = row;
            this.column = column;
        }

        public double [,] arry { get; set; }

        public double this[int index1, int index2] //indexamos el arry al objeto
        {
            get
            {
                return arry[index1, index2];
            }
            set
            {
                arry[index1, index2] = value;
            }
        }

        public void Modify(int row, int column)
        {
            arry = new double[row, column];
            Console.WriteLine("Valores reiniciados a 0 con dimensiones especificadas");
        }

        public void AddRow(Matrix aRow, int pos)
        {
            if ((aRow.row == 1) && (aRow.column == column) && (pos <= row ))
            {
                double[,] temp = new double[row, column];
                temp = arry;
                double[,] modify = new double[row + 1, column];

                for (int i = 0; i < pos; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        modify[i, j] = temp[i, j];
                    }
                }

                for (int j = 0; j < column; j++)
                {
                    modify[pos, j] = aRow[0, j];
                }

                for (int i = pos + 1; i < row + 1; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        modify[i, j] = temp[i - 1, j];
                    }
                }

                arry = modify;
                row++;
            }
            else
            {
                Console.WriteLine("AddRow no es posible, ningún cambio efectuado");
            }
        }

        public void AddColumn(Matrix aColumn, int pos)
        {
            if ((aColumn.row == 1) && (aColumn.column == column) && (pos <= row))
            {
                double[,] temp = new double[row, column];
                temp = arry;
                double[,] modify = new double[row, column + 1];

                for (int j = 0; j < pos; j++)
                {
                    for (int i = 0; i < column; i++)
                    {
                        modify[i, j] = temp[i, j];
                    }
                }

                for (int i = 0; i < column; i++)
                {
                    modify[i, pos] = aColumn[i, 0];
                }

                for (int j = pos + 1; j < column + 1; j++)
                {
                    for (int i = 0; i < column; i++)
                    {
                        modify[i, j] = temp[i, j-1];
                    }
                }

                arry = modify;
                column++;
            }
            else
            {
                Console.WriteLine("AddColumn no es posible, ningún cambio efectuado");
            }
        }


        //SUMA DE MATRICES////////////
        public static Matrix operator+(Matrix a, Matrix b)
        {
            if ((a.row == b.row) && (a.column == b.column))
            {
                Matrix c = new Matrix(a.row, a.column);
                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < a.column; j++)
                    {
                        c[i, j] = a[i, j] + b[i, j];
                    }
                }
                return c;
            }
            else
            {
                Matrix c = new Matrix(2, 2);
                Matrix.Identity(c);
                Console.WriteLine("suma de matrices de dimensiones diferente, retornando matriz identidad 2x2");
                return c;
            }
        }

        public static Matrix operator +(double a, Matrix b)
        {
            Matrix temp = new Matrix(b.row, b.column);
            temp.arry = b.arry;
            for (int i = 0; i < b.row; i++)
            {
                for (int j = 0; j < b.column; j++)
                {
                    temp[i, j] += a;
                }
            }
            return temp;
        }

        public static Matrix operator +(Matrix b, double a)
        {
            Matrix temp = new Matrix(b.row, b.column);
            temp.arry = b.arry;
            for (int i = 0; i < b.row; i++)
            {
                for (int j = 0; j < b.column; j++)
                {
                    temp[i, j] += a;
                }
            }
            return temp;
        }
        ///////////////////////////////////////////////////////////////////////////////


        public static void Identity(Matrix a) {
            if (a.row == a.column)
            {
                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < a.column; j++)
                    {
                        if (i == j)
                        {
                           a[i, j] = 1;
                        }
                        else
                        {
                            a[i, j] = 0;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Identidad Error: Matriz no cuadrada");
            }
        }

        //MULTIPLICACION DE MATRICES//////////////////////////////////////////////////7

        public static Matrix operator*(Matrix a, Matrix b)
        {
            if (a.column == b.row)
            {
                Matrix c = new Matrix(a.row, b.column);
                for (int i = 0; i < a.row; i++)
                {
                    for (int k = 0; k < b.column; k++)
                    {
                        double sumatemp = 0;
                        for (int j = 0; j < a.column; j++)
                        {
                            sumatemp += a[i, j] * b[j, k];
                        }
                        c[i, k] = sumatemp;
                    }
                }
                return c;
            }
            else if ((a.row ==b.row) && (a.column == b.column))
            {
                Matrix c = new Matrix(a.row, a.column);
                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < a.column; j++)
                    {
                        c[i, j] = a[i, j] * b[i, j];
                    }
                }
                return c;
            }

            else
            {
                Matrix c = new Matrix(2, 2);
                Matrix.Identity(c);
                Console.WriteLine("Matrix.Mult Error. Retornando matriz identidad 2x2");
                return c;
            }
        }

        public static Matrix operator *(double a, Matrix b)
        {
            Matrix temp = new Matrix(b.row, b.column);
            temp.arry = b.arry;
            for (int i = 0; i < b.row; i++)
            {
                for (int j = 0; j < b.column; j++)
                {
                    temp[i, j] *= a;
                }
            }
            return temp;
        }

        public static Matrix operator *(Matrix b, double a)
        {
            Matrix temp = new Matrix(b.row, b.column);
            temp.arry = b.arry;
            for (int i = 0; i < b.row; i++)
            {
                for (int j = 0; j < b.column; j++)
                {
                    temp[i, j] *= a;
                }
            }
            return temp;
        }
        //////////////////////////////////////////////////////////////////////////////////////

        public static void WriteLine(Matrix a)
        {
            for (int i = 0; i < a.row; i++)
            {
                for (int j = 0; j < a.column; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static Matrix Transp(Matrix a)
        {
            Matrix b = new Matrix(a.column, a.row);
            for (int i = 0; i < a.column; i++)
            {
                for (int j = 0; j < a.row; j++)
                {
                    b[i, j] = a[j, i];
                }
            }
            return b;
        }

        //SUMA DE MATRICES////////////
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if ((a.row == b.row) && (a.column == b.column))
            {
                Matrix c = new Matrix(a.row, a.column);
                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < a.column; j++)
                    {
                        c[i, j] = a[i, j] - b[i, j];
                    }
                }
                return c;
            }
            else
            {
                Matrix c = new Matrix(2, 2);
                Matrix.Identity(c);
                Console.WriteLine("Resta de matrices de dimensiones diferente, retornando matriz identidad 2x2");
                return c;
            }
        }

        public static Matrix operator -(double a, Matrix b)
        {
            Matrix temp = new Matrix(b.row, b.column);
            temp.arry = b.arry;
            for (int i = 0; i < b.row; i++)
            {
                for (int j = 0; j < b.column; j++)
                {
                    temp[i, j] = (temp[i,j] - a)*-1;
                }
            }
            return temp;
        }

        public static Matrix operator -(Matrix b, double a)
        {
            Matrix temp = new Matrix(b.row, b.column);
            temp.arry = b.arry;
            for (int i = 0; i < b.row; i++)
            {
                for (int j = 0; j < b.column; j++)
                {
                    temp[i, j] -= a;
                }
            }
            return temp;
        }
        ///////////////////////////////////////////////////////////////////////////////

        //POTENCIA////////////////////////////////////////////////////
        public static Matrix operator ^(Matrix a, int b)
        {
            Matrix result = new Matrix(a.row, a.column);
            for (int i = 0; i < a.row; i++)
            {
                for (int j = 0; j < a.column; j++)
                {
                    result[i, j] = Math.Pow(a[i, j], b);
                }
            }
            return result;
        }
        //////////////////////////////////////////////////////////////

        public static double Sum(Matrix a)
        {
            double temp = 0;
            for (int i = 0; i < a.row; i++)
            {
                for (int j = 0; j < a.column; j++)
                {
                    temp += a[i, j];
                }
            }
            return temp;
        }


    }
}

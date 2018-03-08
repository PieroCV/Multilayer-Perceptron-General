using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinealAlg;
using ArtificialInt;

namespace MultPercep
{
    class Program
    {
        static void Main(string[] args)
        {
            //Valores iniciales enteros y doubles

            const int capas = 3; //Capas total

            const int cInput = 4;     //Definimos cantidad de entradas
            const int cOutput = 3;    //Definimos cantidad de salidas

            int[] nxcapa = new int[capas]; //Neuronas por capa
            nxcapa[0] = cInput;
            nxcapa[1] = 5;
            nxcapa[2] = cOutput;

            const int seriesEnt = 75; //Series de entrenamiento
            const int seriesVal = 75; //Series de validación
            const double LearnRate = 0.02d; //Taza de aprendizaje
            const int epocas = 30000;  //Épocas de entrenamiento

            //Valores iniciales Matrices

            Matrix[] Input = new Matrix[seriesEnt];
            double[][,] aInput = new double[seriesEnt][,];
                aInput[0] = new double[1,cInput] { {5.1,3.5,1.4,0.2} };
                aInput[1] = new double[1,cInput] { {7,3.2,4.7,1.4 } };
                aInput[2] = new double[1,cInput] { {6.3,3.3,6,2.5 } };
                aInput[3] = new double[1,cInput] { {4.9,3,1.4,0.2 } };
                aInput[4] = new double[1,cInput] { {6.4,3.2,4.5,1.5 } };
                aInput[5] = new double[1,cInput] { {5.8,2.7,5.1,1.9 } };
                aInput[6] = new double[1,cInput] { {4.7,3.2,1.3,0.2 } };
                aInput[7] = new double[1,cInput] { {6.9,3.1,4.9,1.5 } };
                aInput[8] = new double[1,cInput] { {7.1,3,5.9,2.1 } };
                aInput[9] = new double[1,cInput] { {4.6,3.1,1.5,0.2 } };
                aInput[10] = new double[1,cInput] { {5.5,2.3,4,1.3 } };
                aInput[11] = new double[1,cInput] { {6.3,2.9,5.6,1.8 } };
                aInput[12] = new double[1,cInput] { {5,3.6,1.4,0.2 } };
                aInput[13] = new double[1,cInput] { {6.5,2.8,4.6,1.5 } };
                aInput[14] = new double[1,cInput] { {6.5,3,5.8,2.2 } };
                aInput[15] = new double[1,cInput] { {5.4,3.9,1.7,0.4 } };
                aInput[16] = new double[1,cInput] { {5.7,2.8,4.5,1.3 } };
                aInput[17] = new double[1,cInput] { {7.6,3,6.6,2.1 } };
                aInput[18] = new double[1,cInput] { {4.6,3.4,1.4,0.3 } };
                aInput[19] = new double[1,cInput] { {6.3,3.3,4.7,1.6 } };
                aInput[20] = new double[1,cInput] { {4.9,2.5,4.5,1.7 } };
                aInput[21] = new double[1,cInput] { {5,3.4,1.5,0.2 } };
                aInput[22] = new double[1,cInput] { {4.9,2.4,3.3,1 } };
                aInput[23] = new double[1,cInput] { {7.3,2.9,6.3,1.8 } };
                aInput[24] = new double[1,cInput] { {4.4,2.9,1.4,0.2 } };
                aInput[25] = new double[1,cInput] { {6.6,2.9,4.6,1.3 } };
                aInput[26] = new double[1,cInput] { {6.7,2.5,5.8,1.8 } };
                aInput[27] = new double[1,cInput] { {4.9,3.1,1.5,0.1 } };
                aInput[28] = new double[1,cInput] { {5.2,2.7,3.9,1.4 } };
                aInput[29] = new double[1,cInput] { {7.2,3.6,6.1,2.5 } };
                aInput[30] = new double[1,cInput] { {5.4,3.7,1.5,0.1 } };
                aInput[31] = new double[1,cInput] { {5,2,3.5,1 } };
                aInput[32] = new double[1,cInput] { {6.5,3.2,5.1,2 } };
                aInput[33] = new double[1,cInput] { {4.8,3.4,1.6,0.2 } };
                aInput[34] = new double[1,cInput] { {5.9,3,4.2,1.5 } };
                aInput[35] = new double[1,cInput] { {6.4,2.7,5.3,1.9 } };
                aInput[36] = new double[1,cInput] { {4.8,3,1.4,0.1 } };
                aInput[37] = new double[1,cInput] { {6,2.2,4,1 } };
                aInput[38] = new double[1,cInput] { {6.8,3,5.5,2.1 } };
                aInput[39] = new double[1,cInput] { {4.3,3,1.1,0.1 } };
                aInput[40] = new double[1,cInput] { {6.1,2.9,4.7,1.4 } };
                aInput[41] = new double[1,cInput] { {5.7,2.5,5,2 } };
                aInput[42] = new double[1,cInput] { {5.8,4,1.2,0.2 } };
                aInput[43] = new double[1,cInput] { {5.6,2.9,3.6,1.3 } };
                aInput[44] = new double[1,cInput] { {5.8,2.8,5.1,2.4 } };
                aInput[45] = new double[1,cInput] { {5.7,4.4,1.5,0.4 } };
                aInput[46] = new double[1,cInput] { {6.7,3.1,4.4,1.4 } };
                aInput[47] = new double[1,cInput] { {6.4,3.2,5.3,2.3 } };
                aInput[48] = new double[1,cInput] { {5.4,3.9,1.3,0.4 } };
                aInput[49] = new double[1,cInput] { {5.6,3,4.5,1.5 } };
                aInput[50] = new double[1,cInput] { {6.5,3,5.5,1.8 } };
                aInput[51] = new double[1,cInput] { {5.1,3.5,1.4,0.3 } };
                aInput[52] = new double[1,cInput] { {5.8,2.7,4.1,1 } };
                aInput[53] = new double[1,cInput] { {7.7,3.8,6.7,2.2 } };
                aInput[54] = new double[1,cInput] { {5.7,3.8,1.7,0.3 } };
                aInput[55] = new double[1,cInput] { {6.2,2.2,4.5,1.5 } };
                aInput[56] = new double[1,cInput] { {7.7,2.6,6.9,2.3 } };
                aInput[57] = new double[1,cInput] { {5.1,3.8,1.5,0.3 } };
                aInput[58] = new double[1,cInput] { {5.6,2.5,3.9,1.1 } };
                aInput[59] = new double[1,cInput] { {6,2.2,5,1.5 } };
                aInput[60] = new double[1,cInput] { {5.4,3.4,1.7,0.2 } };
                aInput[61] = new double[1,cInput] { {5.9,3.2,4.8,1.8 } };
                aInput[62] = new double[1,cInput] { {6.9,3.2,5.7,2.3 } };
                aInput[63] = new double[1,cInput] { {5.1,3.7,1.5,0.4 } };
                aInput[64] = new double[1,cInput] { {6.1,2.8,4,1.3 } };
                aInput[65] = new double[1,cInput] { {5.6,2.8,4.9,2 } };
                aInput[66] = new double[1,cInput] { {4.6,3.6,1,0.2 } };
                aInput[67] = new double[1,cInput] { {6.3,2.5,4.9,1.5 } };
                aInput[68] = new double[1,cInput] { {7.7,2.8,6.7,2 } };
                aInput[69] = new double[1,cInput] { {5.1,3.3,1.7,0.5 } };
                aInput[70] = new double[1,cInput] { {6.1,2.8,4.7,1.2 } };
                aInput[71] = new double[1,cInput] { {6.3,2.7,4.9,1.8 } };
                aInput[72] = new double[1,cInput] { {4.8,3.4,1.9,0.2 } };
                aInput[73] = new double[1,cInput] { {6.4,2.9,4.3,1.3 } };
                aInput[74] = new double[1,cInput] { {6.7,3.3,5.7,2.1 } };
            for (int i = 0; i < seriesEnt; i++)
            {
                Input[i] = new Matrix(1, cInput);
                Input[i].arry = aInput[i];
            }

            Matrix[] Output = new Matrix[seriesEnt];
            double[][,] aOutput = new double[seriesEnt][,];
            for (int i = 0; i < seriesEnt; i++)
            {
                if (i % 3 == 0)
                {
                    aOutput[i] = new double[1, cOutput] { { 1 , 0, 0} };
                }
                else if (i%3 == 1)
                {
                    aOutput[i] = new double[1, cOutput] { { 0,1,0 } };
                }
                else
                {
                    aOutput[i] = new double[1, cOutput] { { 0,0,1 } };
                }
            }
            for (int i = 0; i < seriesEnt; i++)
            {
                Output[i] = new Matrix(1, cOutput);
                Output[i].arry = aOutput[i];
            }

            Matrix[] InputVal = new Matrix[seriesVal];
            double[][,] aInputVal = new double[seriesVal][,];
                aInputVal[0] = new double[1, cInput] { {5,3,1.6,0.2 } };
                aInputVal[1] = new double[1, cInput] { { 5, 3.4, 1.6, 0.4 } };
                aInputVal[2] = new double[1, cInput] { { 5.2, 3.5, 1.5, 0.2 } };
                aInputVal[3] = new double[1, cInput] { { 5.2, 3.4, 1.4, 0.2 } };
                aInputVal[4] = new double[1, cInput] { { 4.7, 3.2, 1, 1 } };
                aInputVal[5] = new double[1, cInput] { { 4.8, 3.1, 1.6, 0.2 } };
                aInputVal[6] = new double[1, cInput] { { 5.4, 3.4, 1.5, 0.4 } };
                aInputVal[7] = new double[1, cInput] { { 5.2, 4.1, 1.5, 0.1 } };
                aInputVal[8] = new double[1, cInput] { { 5.5, 4.2, 1.4, 0.2 } };
                aInputVal[9] = new double[1, cInput] { { 4.9, 3.1, 1.5, 0.2 } };
                aInputVal[10] = new double[1, cInput] { { 5, 3.2, 1.2, 0.2 } };
                aInputVal[11] = new double[1, cInput] { { 5.5, 3.5, 1.3, 0.2 } };
                aInputVal[12] = new double[1, cInput] { { 4.9, 3.6, 1.4, 0.1 } };
                aInputVal[13] = new double[1, cInput] { { 4.4, 3, 1.3, 0.2 } };
                aInputVal[14] = new double[1, cInput] { { 5.1, 3.4, 1.5, 0.2 } };
                aInputVal[15] = new double[1, cInput] { { 5, 3.5, 1.3, 0.3 } };
                aInputVal[16] = new double[1, cInput] { { 4.5, 2.3, 1.3, 0.3 } };
                aInputVal[17] = new double[1, cInput] { { 4.4, 3.2, 1.3, 0.2 } };
                aInputVal[18] = new double[1, cInput] { { 5, 3.5, 1.6, 0.6 } };
                aInputVal[19] = new double[1, cInput] { { 5.1, 3.8, 1.9, 0.4 } };
                aInputVal[20] = new double[1, cInput] { { 4.8, 3, 1.4, 0.3 } };
                aInputVal[21] = new double[1, cInput] { { 5.1, 3.8, 1.6, 0.2 }  };
                aInputVal[22] = new double[1, cInput] { { 4.6, 3.2, 1.4, 0.2 } };
                aInputVal[23] = new double[1, cInput] { { 5.3, 3.7, 1.5, 0.2 } };
                aInputVal[24] = new double[1, cInput] { { 5, 3.3, 1.4, 0.2 } };
                aInputVal[25] = new double[1, cInput] { { 6.6, 3, 4.4, 1.4 } };
                aInputVal[26] = new double[1, cInput] { { 6.8, 2.8, 4.8, 1.4 } };
                aInputVal[27] = new double[1, cInput] { { 6.7, 3, 5, 1.7 } };
                aInputVal[28] = new double[1, cInput] { { 6, 2.9, 4.5, 1.5 } };
                aInputVal[29] = new double[1, cInput] { { 5.7, 2.6, 3.5, 1 } };
                aInputVal[30] = new double[1, cInput] { { 5.5, 2.4, 3.8, 1.1 } };
                aInputVal[31] = new double[1, cInput] { { 5.5, 2.4, 3.7, 1 } };
                aInputVal[32] = new double[1, cInput] { { 5.8, 2.7, 3.9, 1.2 } };
                aInputVal[33] = new double[1, cInput] { { 6, 2.7, 5.1, 1.6 } };
                aInputVal[34] = new double[1, cInput] { { 5.4, 3, 4.5, 1.5 } };
                aInputVal[35] = new double[1, cInput] { { 6, 3.4, 4.5, 1.6 } };
                aInputVal[36] = new double[1, cInput] { { 6.7, 3.1, 4.7, 1.5 } };
                aInputVal[37] = new double[1, cInput] { { 6.3, 2.3, 4.4, 1.3 } };
                aInputVal[38] = new double[1, cInput] { { 5.6, 3, 4.1, 1.3 } };
                aInputVal[39] = new double[1, cInput] { { 5.5, 2.5, 4, 1.3 } };
                aInputVal[40] = new double[1, cInput] { { 5.5, 2.6, 4.4, 1.2 } };
                aInputVal[41] = new double[1, cInput] { { 6.1, 3, 4.6, 1.4 } };
                aInputVal[42] = new double[1, cInput] { { 5.8, 2.6, 4, 1.2 } };
                aInputVal[43] = new double[1, cInput] { { 5, 2.3, 3.3, 1 } };
                aInputVal[44] = new double[1, cInput] { { 5.6, 2.7, 4.2, 1.3 } };
                aInputVal[45] = new double[1, cInput] { { 5.7, 3, 4.2, 1.2 } };
                aInputVal[46] = new double[1, cInput] { { 5.7, 2.9, 4.2, 1.3 } };
                aInputVal[47] = new double[1, cInput] { { 6.2, 2.9, 4.3, 1.3 } };
                aInputVal[48] = new double[1, cInput] { { 5.1, 2.5, 3, 1.1 } };
                aInputVal[49] = new double[1, cInput] { { 5.7, 2.8, 4.1, 1.3 } };
                aInputVal[50] = new double[1, cInput] { { 7.2, 3.2, 6, 1.8 } };
                aInputVal[51] = new double[1, cInput] { { 6.2, 2.8, 4.8, 1.8 } };
                aInputVal[52] = new double[1, cInput] { { 6.1, 3, 4.9, 1.8 } };
                aInputVal[53] = new double[1, cInput] { { 6.4, 2.8, 5.6, 2.1 } };
                aInputVal[54] = new double[1, cInput] { { 7.2, 3, 5.8, 1.6 } };
                aInputVal[55] = new double[1, cInput] { { 7.4, 2.8, 6.1, 1.9 } };
                aInputVal[56] = new double[1, cInput] { { 7.9, 3.8, 6.4, 2 } };
                aInputVal[57] = new double[1, cInput] { { 6.4, 2.8,  5.6, 2.2 } };
                aInputVal[58] = new double[1, cInput] { { 6.3, 2.8, 5.1, 1.5 } };
                aInputVal[59] = new double[1, cInput] { { 6.1, 2.6, 5.6, 1.4 } };
                aInputVal[60] = new double[1, cInput] { { 7.7, 3, 6.1, 2.3 } };
                aInputVal[61] = new double[1, cInput] { { 6.3, 3.4, 5.6, 2.4 } };
                aInputVal[62] = new double[1, cInput] { { 6.4, 3.1, 5.5, 1.8 } };
                aInputVal[63] = new double[1, cInput] { { 6, 3, 4.8, 1.8 } };
                aInputVal[64] = new double[1, cInput] { { 6.9, 3.1, 5.4, 2.1 } };
                aInputVal[65] = new double[1, cInput] { { 6.7, 3.1, 5.6, 2.4} };
                aInputVal[66] = new double[1, cInput] { { 6.9, 3.1, 5.1, 2.3 } };
                aInputVal[67] = new double[1, cInput] { { 5.8, 2.7, 5.1, 1.9 } };
                aInputVal[68] = new double[1, cInput] { { 6.8, 3.2, 5.9, 2.3 } };
                aInputVal[69] = new double[1, cInput] { { 6.7, 3.3, 5.7, 2.5 } };
                aInputVal[70] = new double[1, cInput] { { 6.7, 3, 5.2, 2.3 } };
                aInputVal[71] = new double[1, cInput] { { 6.3, 2.5, 5, 1.9 } };
                aInputVal[72] = new double[1, cInput] { { 6.5, 3, 5.2, 2 } };
                aInputVal[73] = new double[1, cInput] { { 6.2, 3.4, 5.4, 2.3 } };
                aInputVal[74] = new double[1, cInput] { { 5.9, 3, 5.1, 1.8 } };
          for (int i = 0; i < seriesVal; i++)
          {
                InputVal[i] = new Matrix(1, cInput);
                InputVal[i].arry = aInputVal[i];
          }

          Matrix[] OutputVal = new Matrix[seriesVal];
          double[][,] aOutputVal = new double[seriesVal][,];
          for (int i = 0; i < seriesEnt; i++)
          {
              if (i < 25)
              {
                aOutputVal[i] = new double [1,cOutput] {{1,0,0}};
              }

              else if ( i < 50 )
              {
                aOutputVal[i] = new double [1,cOutput] {{0,1,0}};
              }

              else
              {
                aOutputVal[i] = new double [1,cOutput] {{0,0,1}};
              }

          }
          for (int i = 0; i < seriesEnt; i++)
          {
                OutputVal[i] = new Matrix(1, cOutput);
                OutputVal[i].arry = aOutputVal[i];
          }

            Random rndm = new Random(0);//Usaremos un generador de random

            Matrix[] Peso = new Matrix[capas-1];    //Creación de pesos como matriz
            for (int i = 0; i < capas-1; i++)       //Asignación de valores aleatorios
            {
                Peso[i] = new Matrix(nxcapa[i],nxcapa[i+1]);
                for (int j = 0; j < nxcapa[i]; j++)
                {
                    for (int k = 0; k < nxcapa[i+1]; k++)
                    {
                        Peso[i][j, k] = rndm.NextDouble();
                    }
                }
            }

            Matrix[] Umbral = new Matrix[capas - 1];    //Creación de umbrales
            for (int i = 0; i < capas-1; i++)           //Asignación de valores aleatorios
            {
                Umbral[i] = new Matrix(1, nxcapa[i + 1]);
                for (int j = 0; j < nxcapa[i+1]; j++)
                {
                    Umbral[i][0, j] = rndm.NextDouble();
                }
            }

            //Creación de funciones activación
            Matrix[] Active = new Matrix[capas];
            for (int i = 0; i < capas; i++)
            {
                Active[i] = new Matrix(1, nxcapa[i]);
            }

            //CREACION DE FUNCIONES DELTA
            Matrix[] Delta = new Matrix[capas];
            for (int i = 0; i < capas; i++)
            {
                Delta[i] = new Matrix(nxcapa[i], 1);
            }

            //ES NECESARIO ASIGNAR VALORES INICIALES A PESOS Y UMBRALES
            //Utilizar funcion random en bucles preferiblemente

            //ENTRENAMIENTO//////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////
            
            for (int e = 0; e < epocas; e++) //Repetir épocas
            {
                double totalError = 0;
                for (int s = 0; s < seriesEnt; s++) //Iterar en series de entrenamiento
                {
                    double Error = 0;
                    //ASIGNACION DE VALORES A ACTIVACION
                    //FORWARD PROPAGATION

                    Active[0] = Input[s];

                    for (int i = 1; i < capas; i++)
                    {
                        Active[i] = Functions.Sigmoid((Active[i - 1] * Peso[i - 1]) + Umbral[i - 1]);
                    }

                    //BACKPROPAGATION

                    //Asignacion de valores delta
                    for (int n = capas - 1; n > 0; n--)
                    {
                        if (n == capas - 1)
                        {
                            Delta[n] = Matrix.Transp((Active[n] * (1d - Active[n])) * (Active[n] - Output[s]));
                        }
                        else
                        {
                            Delta[n] = Matrix.Transp((Active[n] * (1d - Active[n])) * Matrix.Transp(Peso[n] * Delta[n + 1]));
                        }
                    }


                    //Modificación de pesos
                    for (int n = 0; n < capas - 1; n++)
                    {
                        Peso[n] = Peso[n] + (LearnRate * Matrix.Transp(Delta[n+1]*Active[n]));
                    }

                    //Modificación de umbrales
                    for (int n = 0; n < capas-1; n++)
                    {
                        Umbral[n] = Umbral[n] + (LearnRate * Matrix.Transp(Delta[n + 1]));
                    }

                    Error = (Matrix.Sum((Output[s] - Active[capas - 1]) ^ 2)/2);
                    totalError += Error;
                }

                totalError /= seriesEnt;
                //CALCULAR EL ERROR DE VALIDACION CADA 50 EPOCAS
                if ((e + 1) % 100 == 0)
                {
                    double valError = 0;
                    for (int v = 0; v < seriesVal; v++) //Iterar en series de entrenamiento
                    {
                        double Error = 0;
                        //ASIGNACION DE VALORES A ACTIVACION
                        //FORWARD PROPAGATION

                        Active[0] = InputVal[v];

                        for (int i = 1; i < capas; i++)
                        {
                            Active[i] = Functions.Sigmoid((Active[i - 1] * Peso[i - 1]) + Umbral[i - 1]);
                        }
                        Error = Matrix.Sum((OutputVal[v] - Active[capas - 1]) ^ 2)/2;
                        valError += Error;
                    }
                    valError /= seriesVal;
                    Console.WriteLine("Error de Entrenamiento Época {0} = {1}", e + 1, totalError);
                    Console.WriteLine("Error de Validación Época {0} = {1}", e + 1, valError);
                }
            }
            
            double[,] ArryShow = { {7.4 ,2.8,6.1,1.9 } };
            Active[0].arry = ArryShow;
            for (int i = 1; i < capas; i++)
            {
                Active[i] = Functions.Sigmoid((Active[i - 1] * Peso[i - 1]) + Umbral[i - 1]);
            }
            Matrix.WriteLine(Active[0]);
            Matrix.WriteLine(Active[capas - 1]);

            double[,] ArryShow2 = { { 5.9, 3.2, 4.8, 1.8 } };
            Active[0].arry = ArryShow2;
            for (int i = 1; i < capas; i++)
            {
                Active[i] = Functions.Sigmoid((Active[i - 1] * Peso[i - 1]) + Umbral[i - 1]);
            }
            Matrix.WriteLine(Active[0]);
            Matrix.WriteLine(Active[capas - 1]);




            Console.ReadKey();

        }
    }
}

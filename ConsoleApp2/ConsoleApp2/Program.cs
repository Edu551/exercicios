using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ConsoleApp2.classes;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 3, 4, 5, 4, 4, 4, 1 };

            var hasDuplicates = list.GroupBy(x => x).Any(g => g.Count() > 1);

            if (hasDuplicates)
            {
                var duplicates = list.GroupBy(x => x)
                                     .Where(g => g.Count() > 1)
                                     .Select(x => new { Element = x.Key, Count = x.Count() })
                                     .ToList();

                Console.WriteLine(String.Join(", ", duplicates));
            }
            else
            {
                Console.WriteLine("Não há valores duplicados na lista.");
            }






            Console.ReadLine();
        }


        public void StringFormat()
        {
            object[] values = { 1603, 1794.68235, 15436.14 };
            string result;
            foreach (var value in values)
            {
                // C = Currency para moeda 
                // E = Exponencial, notação exponencial
                // F = Ponto fixo, dígitos integrais e decimais com sinal negativo opcional.
                // P = Porcentagem, número multiplicado por 100 e exibido com um sinal de porcentagem.
                // link = https://docs.microsoft.com/pt-br/dotnet/standard/base-types/standard-numeric-format-strings

                result = String.Format("{0,12:C4}   {0,12:E4}   {0,12:F4}   {0,12:N4}  {1,12:P4}\n",
                                       Convert.ToDouble(value), Convert.ToDouble(value) / 10000);
                Console.WriteLine(result);
            }
        }
        public void converterTipos()
        {
            List<int> list = new List<int> { 396285104, 573261094, 759641832, 819230764, 364801279 };

            var retornaUmaLista = list.Select(r => (long)r).ToList();
            Console.WriteLine($"{retornaUmaLista[0]} {retornaUmaLista[1]} {retornaUmaLista[2]}");

            var retornaIEnumerable = list.Select(r => (long)r);
            Console.WriteLine($"{retornaIEnumerable.ElementAt(0)} {retornaIEnumerable.ElementAt(1)} {retornaIEnumerable.ElementAt(2)}");

            List<long> novaLista = list.ConvertAll(r => (long)r);
            Console.WriteLine($"{novaLista[0]} {novaLista[1]} {novaLista[2]} {novaLista[3]} {novaLista[4]}");
        }




        public void MinMaxSum()
        {
            List<int> list = new List<int> { 396285104, 573261094, 759641832, 819230764, 364801279 };

            var lista = list.Select(r => (long)r).ToList();


            long result1 = 0;
            long result2 = 0;
            long max = lista.Max();
            long min = lista.Min();
            for (int i = 0; i < lista.Count; i++)
            {
                result1 += lista[i];
                result2 += lista[i];
            }
            Console.WriteLine("{0} {1}", result1 - max, result2 - min);


            long valorMin = 0;
            long valorMax = 0;
            var isFirstloop = true;

            for (int i = 0; i < lista.Count; i++)
            {
                long tempCount = 0;
                for (int j = 0; j < lista.Count; j++)
                {
                    if (i != j)
                    {
                        tempCount += lista[j];

                    }
                }

                if (isFirstloop)
                {

                    valorMin = tempCount;
                    valorMax = tempCount;
                    isFirstloop = false;
                }
                else
                {
                    if (tempCount < valorMin)
                    {
                        valorMin = tempCount;

                    }
                    else if (tempCount > valorMax)
                    {
                        valorMax = tempCount;
                    }
                }
            }

            Console.WriteLine($"{valorMin} {valorMax}");
        }
        public void Staircase()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
                Console.WriteLine(new String('#', i + 1).PadLeft(n, '.'));


            for (int i = 0; i < n;)
            {
                int numeroDeVezesEspaco = n - 1 - i;
                i++;
                int numeroDeVezesHastag = i;

                string espaco = new string(' ', numeroDeVezesEspaco);
                string hastag = new string('#', numeroDeVezesHastag);

                Console.WriteLine($"{espaco}{hastag}");
            }
        }
        public void PlusMinus()
        {
            List<int> arr = new List<int> { -4, 3, -9, 0, 4, 1 };

            decimal positivos = 0;
            decimal negativos = 0;
            decimal zeros = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] > 0)
                {
                    positivos++;
                }
                else if (arr[i] < 0)
                {
                    negativos++;
                }
                else
                {
                    zeros++;
                }
            }

            decimal porcPositivos = positivos / arr.Count;
            decimal porcNegativos = negativos / arr.Count;
            decimal porcZeros = zeros / arr.Count;


            Console.WriteLine($"{porcPositivos:F6}");
            Console.WriteLine($"{porcNegativos:F6}");
            Console.WriteLine($"{porcZeros:F6}");
        }
        public void ValoresDiagonais()
        {
            List<List<int>> arr = new List<List<int>>();

            List<int> item1 = new List<int> { 6, 6, 7, -10, 9, -3, 8, 9, -1 };
            List<int> item2 = new List<int> { 9, 7, -10, 6, 4, 1, 6, 1, 1 };
            List<int> item3 = new List<int> { -1, -2, 4, -6, 1, -4, -6, 3, 9, };
            List<int> item4 = new List<int> { -8, 7, 6, -1, -6, -6, 6, -7, 2 };
            List<int> item5 = new List<int> { -10, -4, 9, 1, -7, 8, -5, 3, -5 };
            List<int> item6 = new List<int> { -8, -3, -4, 2, -3, 7, -5, 1, -5 };
            List<int> item7 = new List<int> { -2, -7, -4, 8, 3, -1, 8, 2, 3 };
            List<int> item8 = new List<int> { -3, 4, 6, -7, -7, -8, -3, 9, -6 };
            List<int> item9 = new List<int> { -2, 0, 5, 4, 4, 4, -3, 3, 0 };

            arr.Add(item1);
            arr.Add(item2);
            arr.Add(item3);
            arr.Add(item4);
            arr.Add(item5);
            arr.Add(item6);
            arr.Add(item7);
            arr.Add(item8);
            arr.Add(item9);


            int result = DiagonalDifference(arr);

            Console.WriteLine(result);
        }
        public static int DiagonalDifference(List<List<int>> arr)
        {
            int soma;
            int diagonal1 = 0;
            int diagonal2 = 0;

            for (int i = 0; i < arr.Count; )
            {
                diagonal1 = arr[i][i] + diagonal1;
                diagonal2 = arr[i][arr.Count - 1 - i] + diagonal2;

                i++;
            }

            soma = diagonal1 - diagonal2;

            if (diagonal1 < diagonal2)
            {
                return soma * -1;
            }
            else
            {
                return soma;
            }
        }
        public static List<int> comparaListas(List<int> a, List<int> b)
        {
            List<int> resultado = new List<int>();
            int alice = 0;
            int bob = 0;

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] > b[i])
                {
                    alice++;
                }
                else if (a[i] < b[i])
                {
                    bob++;
                }
            }

            resultado.Add(alice);
            resultado.Add(bob);

            return resultado;
        }
        public void BEE1103()
        {
            List<int> listaMinutos = new List<int>();

            int[] arrFinal = { 0, 0, 0, 0 };
            int minEmUmDia = 1440;

            string[] RecebeDados()
            {
                return Console.ReadLine().Split(' ').ToArray();
            }

            int[] TransformaArrayInt(string[] arr)
            {
                int[] arrInt = new int[4];

                for (int i = 0; i < arr.Length; i++)
                {
                    arrInt[i] = int.Parse(arr[i]);
                }


                return arrInt;
            }

            bool ComparaArrays(int[] arr1, int[] arr2)
            {
                return Enumerable.SequenceEqual(arr1, arr2);
            }
            bool comparaArrays;

            do
            {
                int totalDeMinutos;
                int[] primeiroArray = TransformaArrayInt(RecebeDados());
                int[] arrInicial = primeiroArray;


                int horaAtual = (arrInicial[0] + 1) * 60;
                int minAtual = arrInicial[1];
                int totalAtual = horaAtual + minAtual;

                int horaDespertador = (arrInicial[2] + 1) * 60;
                int minDespertador = arrInicial[3];
                int totalDespertador = horaDespertador + minDespertador;

                if (horaDespertador == horaAtual)
                {
                    if (minDespertador < minAtual)
                    {
                        totalDeMinutos = minEmUmDia - totalAtual + totalDespertador;
                    }
                    else
                    {
                        totalDeMinutos = totalDespertador - totalAtual;
                    }
                }
                else if (horaDespertador < horaAtual)
                {
                    totalDeMinutos = totalDespertador + minEmUmDia - totalAtual;
                }
                else
                {
                    totalDeMinutos = totalDespertador - totalAtual;
                }


                if (totalDeMinutos != 0)
                {
                    listaMinutos.Add(totalDeMinutos);
                }

                comparaArrays = ComparaArrays(arrInicial, arrFinal);
            } while (!comparaArrays);


            for (int i = 0; i < listaMinutos.Count; i++)
            {
                Console.WriteLine(listaMinutos[i]);
            }
        }
        public void BEE1589()
        {
            int casosDeTeste = int.Parse(Console.ReadLine());
            int[] menorRaio = new int[casosDeTeste];

            for (int i = 0; i < casosDeTeste; i++)
            {
                var arrayDados = Console.ReadLine().Split(' ').ToArray();

                int raioR1 = int.Parse(arrayDados[0]);
                int raioR2 = int.Parse(arrayDados[1]);

                menorRaio[i] = (raioR1 * 2 + raioR2 * 2) / 2;

            }

            for (int i = 0; i < casosDeTeste; i++)
            {
                Console.WriteLine(menorRaio[i]);
            }
        }
        public void BEE2006()
        {
            int tipoDeCha = int.Parse(Console.ReadLine());

            var arrayDados = Console.ReadLine().Split(' ').ToArray();

            int respostasCorretas = 0;

            for (int i = 0; i < arrayDados.Length; i++)
            {
                if (int.Parse(arrayDados[i]) == tipoDeCha)
                {
                    respostasCorretas++;
                }
            }
            Console.WriteLine(respostasCorretas);
        }
        public void BEE2434()
        {
            var arrayDados = Console.ReadLine().Split(' ').ToArray();

            int dias = int.Parse(arrayDados[0]);
            int saldoInicial = int.Parse(arrayDados[1]);
            int menorValor = saldoInicial;

            for (int i = 0; i < dias; i++)
            {
                int movimentacaoDoDia = int.Parse(Console.ReadLine());

                int saldoFinal = saldoInicial + movimentacaoDoDia;

                saldoInicial = saldoFinal;

                if (saldoFinal < menorValor)
                {
                    menorValor = saldoFinal;
                }
                Console.WriteLine($"O menor valor é R${menorValor},00.");
                Console.WriteLine($"O saldo do dia {i + 1} é R$ {saldoFinal},00.");
            }
        }
        public void BEE1041()
        {
            var arrayDados = Console.ReadLine().Split(' ').ToArray();

            double eixoX = double.Parse(arrayDados[0]);
            double eixoY = Convert.ToDouble(arrayDados[1]);

            if (eixoX == 0 && eixoY == 0)
            {
                Console.WriteLine("Origem");
            }
            else if (eixoX == 0)
            {
                Console.WriteLine("Eixo X");
            }
            else if (eixoY == 0)
            {
                Console.WriteLine("Eixo Y");
            }
            else
            {
                if (eixoX > 0 && eixoY > 0)
                {
                    Console.WriteLine("Q1");
                }
                else if (eixoX < 0 && eixoY > 0)
                {
                    Console.WriteLine("Q2");
                }
                else if (eixoX < 0 && eixoY < 0)
                {
                    Console.WriteLine("Q3");
                }
                else
                {
                    Console.WriteLine("Q4");
                }
            }
        }
        public static double MediaPonderada()
        {
            var arrayDados = Console.ReadLine().Split(' ').ToArray();

            double[] pesoDasNotas = { 2, 3, 4, 1 };
            double[] notas = new double[4];
            double[] notasXpesos = new double[4];

            for(int i = 0; i < arrayDados.Length; i++)
            {
                double nota = Convert.ToDouble(arrayDados[i]);
                notas[i] = nota;
            }

            for (int i = 0; i < notas.Length; i++)
            {
                notasXpesos[i] = notas[i] * pesoDasNotas[i];
            }

            double mediaPonderada = notasXpesos.Sum() / pesoDasNotas.Sum();

            return mediaPonderada;
        }
        public static bool AprovaAluno(double mediaPonderada)
        {
            if (mediaPonderada >= 7.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ReprovaAluno(double media)
        {
            if (media < 5.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void URI1040()
        {
            double mediaPonderada = MediaPonderada();


            Console.WriteLine($"Media: {mediaPonderada}");

            if (AprovaAluno(mediaPonderada))
            {
                Console.WriteLine("Aluno aprovado.");
            }
            else if (ReprovaAluno(mediaPonderada))
            {
                Console.WriteLine("Aluno reprovado.");
            }
            else
            {
                Console.WriteLine("Aluno em exame.");

                if (!ReprovaAluno(mediaPonderada))
                {
                    var notaExame = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine($"Nota do exame: {notaExame}");

                    double mediaFinal = (notaExame + mediaPonderada) / 2;

                    if (ReprovaAluno(mediaFinal))
                    {
                        Console.WriteLine("Aluno repovado.");
                    }
                    else
                    {
                        Console.WriteLine("Aluno aprovado.");
                        Console.WriteLine($"Media final: {mediaFinal}");
                    }
                }
            }
        }
        public void URI1040v2()
        {
            var arrayDados = Console.ReadLine().Split(' ').ToArray();

            float a = float.Parse(arrayDados[0]);
            float b = float.Parse(arrayDados[1]);
            float c = float.Parse(arrayDados[2]);
            float d = float.Parse(arrayDados[3]);

            float media = (a * 2 + b * 3 + c * 4 + d * 1) / 10;

            Console.WriteLine($"Media: {media:F1}");

            if (media >= 7.0)
            {
                Console.WriteLine("Aluno aprovado");
            }
            else if (media >= 5.0 && media <= 6.9)
            {
                Console.WriteLine("Aluno em exame.");
                float notaDoExame = float.Parse(Console.ReadLine());
                Console.WriteLine($"Nota do exame: {notaDoExame:F1}");
                float mediaFinal = (notaDoExame + media) / 2;

                if (mediaFinal >= 5.0)
                {
                    Console.WriteLine("Aluno aprovado. ");
                    Console.WriteLine($"Media final: {mediaFinal:F1}");
                }
                else
                {
                    Console.WriteLine("Aluno reprovado. ");
                    Console.WriteLine($"Media final: {mediaFinal:F1}");
                }
            }
            else
            {
                Console.WriteLine("Aluno reprovado.");
            }
        }
        public void URI1015()
        {
            var entradaP1 = Console.ReadLine().Split(' ').ToArray();
            double eixoX1 = Convert.ToDouble(entradaP1[0]);
            double eixoY1 = Convert.ToDouble(entradaP1[1]);

            var entradaP2 = Console.ReadLine().Split(' ').ToArray();
            double eixoX2 = Convert.ToDouble(entradaP2[0]);
            double eixoY2 = Convert.ToDouble(entradaP2[1]);

            double distancia = Math.Sqrt(
                Math.Pow((eixoX2 - eixoX1), 2) + Math.Pow((eixoY2 - eixoY1), 2)
                );
            //distancia = Math.Round(distancia, 4);

            Console.WriteLine(distancia.ToString("F4"));
        }
        public void URI1017()
        {
            double tempo = double.Parse(Console.ReadLine());
            double velocidade = double.Parse(Console.ReadLine());
            double litros = (tempo * velocidade) / 12.0;

            //Console.WriteLine(Math.Round(litros, 3) + "\n");
            Console.WriteLine(litros.ToString("0.000"));
        }        
        public void URI1019()
        {
            int tempo = int.Parse(Console.ReadLine());
            int horas = tempo / 3600;
            int minutos = (tempo % 3600) / 60;
            int segundos = tempo % 60;

            Console.WriteLine($"{horas}:{minutos}:{segundos}");
        }
        public void URI1020()
        {
            var dados = int.Parse(Console.ReadLine());
            int ano = dados / 365;
            int mes = (dados % 365) / 30;
            int dia = (dados % 365) % 30;

            Console.WriteLine($"{ano} ano(s)");
            Console.WriteLine($"{mes} mes(es)");
            Console.WriteLine($"{dia} dia(s)");
        }
        public void URI1035()
        {
            var dados = Console.ReadLine().Split(' ').ToArray();
            int A = int.Parse(dados[0]);
            int B = int.Parse(dados[1]);
            int C = int.Parse(dados[2]);
            int D = int.Parse(dados[3]);

            if (B > C && D > A && C + D > A + B && C > 0 && D > 0 && A % 2 == 0)
            {
                Console.WriteLine("Valores aceitos");
            }
            else
            {
                Console.WriteLine("Valores nao aceitos");
            }
        }
        public void ListaDeLanches()
        {
            List<Lanche> lanches;

            lanches = new List<Lanche>
            {
                new Lanche(1, "Cachorro Quente", 4.00),
                new Lanche(2, "X-Salada", 4.50),
                new Lanche(3, "X-Bacon", 5.00),
                new Lanche(4, "Torrada simples", 2.00),
                new Lanche(5, "Refrigerante", 1.50)
            };

            foreach (Lanche item in lanches)
            {
                Console.WriteLine($"{item.Codigo} {item.Especificacao} R${item.Preco:N2}");
            }
        }
        public void URI1038()
        {
            var dados = Console.ReadLine().Split(' ').ToArray();
            int codigo = Convert.ToInt32(dados[0]);
            double quantidade = Convert.ToDouble(dados[1]);

            string[] especificacoes = { "Cachorro Quente", "X-Salada", "X-Bacon", "Torrada simples", "Refrigerante" };
            double[] preco = { 4.00, 4.50, 5.00, 2.00, 1.50 };

            double valorDoItem = preco[codigo - 1];
            double totalDaCompra = valorDoItem * quantidade;

            Console.WriteLine($"Total: R$ {totalDaCompra:N2}\n");
        }
    }   
}
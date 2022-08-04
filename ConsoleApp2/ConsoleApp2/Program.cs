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
            var arrayDados = Console.ReadLine().Split(' ').ToArray();





            Console.ReadLine();
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

            lanches = new List<Lanche>();

            lanches.Add(new Lanche(1, "Cachorro Quente", 4.00));
            lanches.Add(new Lanche(2, "X-Salada", 4.50));
            lanches.Add(new Lanche(3, "X-Bacon", 5.00));
            lanches.Add(new Lanche(4, "Torrada simples", 2.00));
            lanches.Add(new Lanche(5, "Refrigerante", 1.50));

            foreach (Lanche item in lanches)
            {
                Console.WriteLine($"{item.Codigo} {item.Especificacao} R${item.Preco.ToString("N2")}");
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

        public void StringFormat()
        {
            object[] values = { 1603, 1794.68235, 15436.14 };
            string result;
            foreach (var value in values)
            {
                result = String.Format("{0,12:C4}   {0,12:E4}   {0,12:F4}   {0,12:N4}  {1,12:P4}\n",
                                       Convert.ToDouble(value), Convert.ToDouble(value) / 10000);
                Console.WriteLine(result);
            }
        }
    }   
}
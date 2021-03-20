using System;

namespace Revisão
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do Aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do Aluno:");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }   
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal!");
                        }  

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;                  

                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nota} - NOTA: {a.Nota}");
                            }
                        }

                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for(int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceitos conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceitos.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceitos.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceitos.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceitos.B;
                        }
                        else
                        {
                            conceitoGeral = Conceitos.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            opcaoUsuario = ObterOpcaoUsuario();

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("INFORME A OPÇÃO DESEJADA!!!");
            Console.WriteLine("1: Inserir Novo Aluno");
            Console.WriteLine("2: Listar Alunos");
            Console.WriteLine("3: Calcular a Média Geral");
            Console.WriteLine("X: SAIR!");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}

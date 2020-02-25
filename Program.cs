using System;
 using Revisao;

namespace SistemaEscolaDIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var iA = 0;
            Aluno[] alunos = new Aluno[5];
            string op = opcaoUsuario();

            while (op != "4")
            {
                switch (op)
                {
                    case "1":
                        //TODO: implementar inserção de aluno
                        Aluno aluno = new Aluno();
                        Console.WriteLine("\n\n Informe o ID do aluno: \n");
                        aluno.ID = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n\n Informe o nome do aluno: \n");
                        aluno.Name = Console.ReadLine();
                        Console.WriteLine("\n\n Informe a nota do aluno: \n");
                        if(decimal.TryParse(Console.ReadLine(),out decimal nota))
                        {
                            aluno.Grades = nota;
                        }
                        else
                        {
                            throw new ArgumentException("valor da nota deve ser decimal");
                        }
                        alunos[iA] = aluno;
                        iA++;
                        

                        break;
                    case "2":
                        //TODO: Implementar listagem de alunos
                        foreach(var al in alunos)
                        {
                            Console.WriteLine($"Aluno:{al.Name} - Nota:{al.Grades}");
                        }
                        break;
                    case "3":
                        //TODO: Implementar calculo da média de notas
                        decimal nt = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Name))
                            {
                                nt += alunos[i].Grades;
                                nrAlunos++;
                            }

                        }
                        var mediaGeral = nt / nrAlunos;
                        Conceito conceitoGeral;
                        
                        if(mediaGeral < 2){
                            conceitoGeral = conceito.E;
                        } else if(mediaGeral < 4){
                            conceitoGeral = conceito.D;
                        } else if(mediaGeral < 6){
                            conceitoGeral = conceito.C;
                        }else if(mediaGeral < 8){
                            conceitoGeral = conceito.B;
                        }else{
                            conceitoGeral = conceito.A;
                        }
                        
                        Console.WriteLine($"Media Geral:{mediaGeral} - Conceito: {conceitoGeral}");

                        break;
                    case "4":
                        //Saindo....
                        break;
                    default :
                        throw new ArgumentOutOfRangeException();
                        break;
                }
            }
        }

        private static string opcaoUsuario()
        {
            Console.WriteLine("=============================\n");
            Console.WriteLine("Informe a opção desejada:\n");
            Console.WriteLine("1) Inserir novo aluno \n ");
            Console.WriteLine("2) Listar alunos \n ");
            Console.WriteLine("3) Calcular media Geral \n ");
            Console.WriteLine("4) Sair \n ");
            Console.WriteLine("=============================\n");

            string op = Console.ReadLine();
            return op;
        }
    }
}

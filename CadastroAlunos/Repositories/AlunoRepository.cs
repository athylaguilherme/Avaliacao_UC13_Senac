using CadastroAlunos.Models;
using CadastroAlunos.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAlunos.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        public List<Aluno> AllAlunos()
        {
            List<Aluno> alunos = new List<Aluno>()
            {
                new Aluno()
                {
                    Id = 1,
                    Nome = "Pedro Raul",
                    Turma = "9A",
                    Media = 8.5   
                },

                 new Aluno()
                {
                    Id = 2,
                    Nome = "Pedro Queixada",
                    Turma = "8F",
                    Media = 9

                },

                  new Aluno()
                {
                    Id = 3,
                    Nome = "Richarlison",
                    Turma = "7D",
                    Media = 9.5

                },

                   new Aluno()
                {
                    Id = 4,
                    Nome = "Casemiro",
                    Turma = "6A",
                    Media = 8

                },
                    new Aluno()
                {
                    Id = 5,
                    Nome = "Marquinhos",
                    Turma = "1E",
                    Media = 10

                }
            };
            return alunos;
        }
    }
}

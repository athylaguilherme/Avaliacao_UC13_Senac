using CadastroAlunos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAlunos.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        List<Aluno> AllAlunos();
    }
}

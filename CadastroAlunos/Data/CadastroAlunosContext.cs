using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroAlunos.Models;

namespace CadastroAlunos.Data
{
    public class CadastroAlunosContext : DbContext
    {
        public CadastroAlunosContext (DbContextOptions<CadastroAlunosContext> options)
            : base(options)
        {
        }

        public DbSet<CadastroAlunos.Models.Aluno> Aluno { get; set; }
    }
}

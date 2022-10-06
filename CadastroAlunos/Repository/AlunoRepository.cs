using CadastroAlunos.Contratos;
using CadastroAlunos.Data;
using CadastroAlunos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAlunos.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly CadastroAlunosContext _context;

        public AlunoRepository(CadastroAlunosContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> GetAluno()
        {
            return await _context.Aluno.ToListAsync();
        }

        public async Task<Aluno> GetAlunoById(int? id)
        {
            return await _context.Aluno.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Aluno> AddAluno(Aluno aluno)
        {
            if (aluno.Media >= 0 && aluno.Media <= 10)
            {
                _context.Aluno.Add(aluno);
                await _context.SaveChangesAsync();
                return aluno;
            }
          

            return aluno;
        }

        public async Task<int> UpdateAluno(int id, Aluno alunoAlterado)
        {
            var aluno = await _context.Aluno.FirstOrDefaultAsync(a => a.Id == id);

            if (aluno == null)
                return 0;

            if (alunoAlterado.Media >=0 && alunoAlterado.Media <= 10)
            {
                aluno.AtualizarDados(alunoAlterado.Nome, alunoAlterado.Turma);
                aluno.AtualizaMedia(alunoAlterado.Media);

                _context.Entry(aluno).State = EntityState.Modified;
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task DeleteAluno(int id)
        {
            var aluno = await _context.Aluno.FirstOrDefaultAsync(a => a.Id == id);

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}

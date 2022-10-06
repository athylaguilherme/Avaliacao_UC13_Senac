using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroAlunos.Data;
using CadastroAlunos.Models;
using CadastroAlunos.Contratos;

namespace CadastroAlunos.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunosController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        // GET: Aluno

        public async Task<ActionResult<IEnumerable<Aluno>>> Index()
        {
            return View(await _alunoRepository.GetAluno());
        }

        // GET: Aluno/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var aluno = await _alunoRepository.GetAlunoById(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Aluno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Aluno>> Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
            
                var result = await _alunoRepository.AddAluno(aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _alunoRepository.GetAlunoById(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }



        //GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _alunoRepository.GetAlunoById(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Turma,Media")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await _alunoRepository.UpdateAluno(id, aluno);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!AlunoExists(aluno.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _alunoRepository.GetAlunoById(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _alunoRepository.GetAlunoById(id);
            await _alunoRepository.DeleteAluno(aluno.Id);
            return RedirectToAction(nameof(Index));
        }

        //private bool AlunoExists(int? id)
        //{
        //    var result = _alunoRepository.GetAlunoById(id);
        //    if (result != null)
        //    {
        //        return result;
        //    }

        //    return _context.Aluno.Any(e => e.Id == id);
        //}
    }
}


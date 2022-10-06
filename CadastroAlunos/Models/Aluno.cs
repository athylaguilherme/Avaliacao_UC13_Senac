using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAlunos.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(1, ErrorMessage = "Nome tem que ter no Minimo 1 Caracter")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Turma é obrigatório")]
        [MinLength(2, ErrorMessage = "Turma tem que ter no Minimo 2 Caracter")]
        [MaxLength(3, ErrorMessage = "Turma tem que ter no Maximo 3 Caracter")]
        public string Turma { get; set; }
        [Required(ErrorMessage = "Media é obrigatório")]

        public double Media { get; set; }


        public void AtualizarDados(string nome, string turma)
        {
            Nome = nome;
            Turma = turma;
        }
        public bool VerificaAprovacao() 
            => Media >= 5;        

        public void AtualizaMedia(double novaMedia)
        {
            Media = novaMedia;
        }
        
    }
}

using CadastroAlunos.Contratos;
using CadastroAlunos.Models;
using Moq;
using System;
using Xunit;

namespace CadastroAlunosTest
{
    public class ModelsTest
    {
        Mock<IAlunoRepository> _repository;
        Aluno aluno;

        public ModelsTest()
        {
            _repository = new Mock<IAlunoRepository>();
        }

        [Fact]
        public void AtualizarDados_RetornandoComSucessoComDadosPassadosCorretamente()
        {
            //Arrange

            Aluno aluno = new Aluno();
            aluno.Nome = "Athyla";
            aluno.Turma = "T91";
            //Act
            aluno.AtualizarDados("João", "7A");
            //Assert
            Assert.Equal("João", aluno.Nome);
            Assert.Equal("7A", aluno.Turma);
        }

        [Fact]
        public void AtualizarDados_RetornandoComSucessoIndependenteDosDadosPassados()
        {
            //Arrange

            Aluno aluno = new Aluno();
            aluno.Nome = "@th1l@";
            aluno.Turma = "t@91";
            //Act
            aluno.AtualizarDados("J0@o", "7A@");
            //Assert
            Assert.Equal("J0@o", aluno.Nome);
            Assert.Equal("7A@", aluno.Turma);
        }

        [Fact]
        public void VerificaAprovacaoVerdadeiroParaMediaMaiorOuIgualCinco()
        {
            //Arrange

            Aluno aluno = new Aluno();
            aluno.Media = 5;

            //Act

            //Assert
            Assert.True(aluno.VerificaAprovacao());
        }

        [Fact]
        public void VerificaAprovacaoFalseParaMediamenorCinco()
        {
            //Arrange

            Aluno aluno = new Aluno();
            aluno.Media = 4;
            //Act

            //Assert
            Assert.False(aluno.VerificaAprovacao());
        }

        [Fact]
        public void AtualizarMediaDoAluno()
        {
            //Arrange

            Aluno aluno = new Aluno();
            aluno.Media = 4;

            //Act
            aluno.AtualizaMedia(10);
            //Assert
            Assert.Equal(10, aluno.Media);
          
        }
    }
}

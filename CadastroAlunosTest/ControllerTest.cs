using CadastroAlunos.Contratos;
using CadastroAlunos.Controllers;
using CadastroAlunos.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAlunosTest
{
    public class ControllerTest
    {
        Mock<IAlunoRepository> _alunoRepository;
        Aluno alunoMoq;

        public ControllerTest()
        {
            _alunoRepository = new Mock<IAlunoRepository>();
        }

        [Fact]
        public async void MetodoIndexDeveRetornarUmViewResult()
        {
            //Arrange
            AlunosController controller = new AlunosController(_alunoRepository.Object);

            //Act
            var aluno = await controller.Index();

            //Assert
            Assert.IsType<ViewResult>(aluno.Result);

        }

        [Fact]
        public async void MetodoIndexChamarUmaVezORepositorio()
        {
            //Arrange
            var controller = new AlunosController(_alunoRepository.Object);

            _alunoRepository.Setup(a => a.GetAluno());

            //Act
            await controller.Index();

            //Assert
            _alunoRepository.Verify(alunoRepo => alunoRepo.GetAluno(), Times.Once);

        }

        [Fact]
        public async void DetailsIdNuloRetornaBadRequest()
        {
            //Arrange
            AlunosController controller = new AlunosController(_alunoRepository.Object);

            
            //Act
            var aluno = await controller.Details(null);

            //Assert
           Assert.IsType<BadRequestResult>(aluno);

        }
        [Fact]
        public async void DetailsIdValidoMasNaoExisteNoBancoRetornaNotFound()
        {
            //Arrange
            AlunosController controller = new AlunosController(_alunoRepository.Object);

          
            //Act
            var aluno = await controller.Details(20);

            //Assert
            Assert.IsType<NotFoundResult>(aluno);

        }

        [Fact]
        public async void DetailsAlunoEncontradoNoBanco()
        {
            //Arrange
            AlunosController controller = new AlunosController(_alunoRepository.Object);

            Aluno aluno = new Aluno();
            aluno.Id = 1;

             _alunoRepository.Setup(a => a.GetAlunoById(1))
                .ReturnsAsync(aluno);

            //Act
            var alunos = await controller.Details(1);

            //Assert
            Assert.IsType<ViewResult>(alunos);

        }
        [Fact]
        public async void MetodoDetailsChamarUmaVezORepositorio()
        {
            //Arrange
            AlunosController controller = new AlunosController(_alunoRepository.Object);

            Aluno aluno = new Aluno();
            aluno.Id = 1;

           var result = _alunoRepository.Setup(a => a.GetAlunoById(1))
               .ReturnsAsync(aluno);

            //Act
            var alunos = await controller.Details(1);


            //Assert
            _alunoRepository.Verify(alunoRepo => alunoRepo.GetAlunoById(1), Times.Once);
        }

        [Fact]
        public  void MetodoCreateDeveRetornarUmaViewResult()
        {
            //Arrange
            AlunosController controller = new AlunosController(_alunoRepository.Object);

            //Act
            var aluno =  controller.Create();

            //Assert
            Assert.IsType<ViewResult>(aluno);

        }

        [Fact]
        public async void MetodoCreateModelStateInvalidaReturnaView()
        {
            //Arrange
            AlunosController controller = new AlunosController(_alunoRepository.Object);
            Aluno aluno = new Aluno();
            aluno.Id = -5;
            aluno.Nome = null;
            aluno.Turma = null;
            aluno.Media = -15;
            //Act
            await controller.Create(aluno);

            //Assert

            _alunoRepository.Verify(alunoRepo => alunoRepo.AddAluno(aluno), Times.Once);
        }





    }
}

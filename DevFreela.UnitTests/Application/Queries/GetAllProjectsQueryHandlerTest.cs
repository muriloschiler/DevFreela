// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using DevFreela.Application.Queries.GetAllProject;
// using DevFreela.Application.Queries.GetProject;
// using DevFreela.Core.Entities;
// using DevFreela.Core.Repositories;
// using Moq;
// using Xunit;

// public class GetAllProjectsQueryHandlerTest
// {
//     [Fact]
//     public async void threeProjectsExists_Executed_ThreeProjectViewModelReturned()
//     {
//         //Arrange
//         var listProject = new List<Project>
//         {
//             new Project("Titulo 1","Descricao 1",1,100),
//             new Project("Titulo 2","Descricao 2",2,200),
//             new Project("Titulo 3","Descricao 3",3,300)
//         };
        
//         var projectRepositoryMock = new Mock<IProjectRepository>();
//         projectRepositoryMock.Setup(p => p.GetAllProjects(It.IsAny<string>())).Returns(Task.FromResult(listProject));

//         var getAllProjectQuery = new GetAllProjectQuery("query");
//         var getAllProjectQueryHandler = new GetAllProjectQueryHandler(projectRepositoryMock.Object);

//         //Act
//         var projectsViewsModels = await getAllProjectQueryHandler.Handle(getAllProjectQuery,new CancellationToken());
        
//         //Assert

//         Assert.Equal(3,projectsViewsModels.Count);
//         Assert.Equal(typeof(ProjectViewModel),projectsViewsModels[0].GetType());

//         projectRepositoryMock.Verify(pr=>pr.GetAllProjects(It.IsAny<string>()),Times.Once);
//         }
// }
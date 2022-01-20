using MediatR;

namespace DevFreela.Application.Commands.HireProject
{
    public class HireProjectCommand : IRequest<Unit>
    {

        public HireProjectCommand(int idFreelancer)
        {
            this.idFreelancer = idFreelancer;

        }
        public int idFreelancer { get; private set; }
        public int idProject { get; private set; }
        public void SetIdProject(int idProject){
            this.idProject=idProject;
        }
    }
}
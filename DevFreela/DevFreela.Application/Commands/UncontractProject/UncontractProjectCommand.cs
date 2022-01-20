using MediatR;

namespace DevFreela.Application.Commands.UncontractProject
{
    public class UncontractProjectCommand:IRequest<Unit>
    {
        public UncontractProjectCommand(int idFreelancer)
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
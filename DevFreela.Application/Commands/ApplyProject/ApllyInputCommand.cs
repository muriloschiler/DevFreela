using MediatR;

namespace DevFreela.Application.Commands.ApplyProject
{
    public class ApllyInputCommand : IRequest<bool>
    {


        public ApllyInputCommand(int idFreelancer)
        {
            this.IdFreelancer = idFreelancer;

        }
        public int IdFreelancer { get; private set; }
        public int idProject { get; private set; }
        public void SetIdProject(int idProject){
            this.idProject=idProject;
        }
    }
}
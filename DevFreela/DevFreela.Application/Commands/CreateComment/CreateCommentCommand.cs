using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int>
    {

        public CreateCommentCommand(string content, int idUser)
        {
            this.Content = content;
            this.IdUser = idUser;

        }
        public string Content { get; private set; }
        public int IdProject { get; private set; }
        public void SetIdProject(int idProject){
            this.IdProject = idProject;
        }
        public int IdUser { get; private set; }
    
    
    }
}
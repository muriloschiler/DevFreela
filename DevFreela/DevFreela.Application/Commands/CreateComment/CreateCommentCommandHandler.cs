using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        public IProjectRepository _ProjectRepository;

        public CreateCommentCommandHandler(IProjectRepository projectRepository)
        {
            _ProjectRepository = projectRepository;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var newComment = new ProjectComment(request.Content,request.IdProject,request.IdUser);
            await _ProjectRepository.AddComment(newComment);
            return newComment.Id;
        }
    }
}
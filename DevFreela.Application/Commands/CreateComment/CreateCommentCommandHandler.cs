using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly DevFreelaDbContext _devFreelaDbContext;
        public CreateCommentCommandHandler(DevFreelaDbContext devFreelaDbContext)
        {
            _devFreelaDbContext=devFreelaDbContext;
        }
        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var newComment = new ProjectComment(request.Content,request.IdProject,request.IdUser);
            await _devFreelaDbContext.ProjectComments.AddAsync(newComment);
            await _devFreelaDbContext.SaveChangesAsync();
            return newComment.Id;
        }
    }
}
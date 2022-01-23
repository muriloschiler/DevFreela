using MediatR;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {

        public CreateProjectCommand(string title, string description, int idClient, decimal totalCost)
        {
            this.Title = title;
            this.Description = description;
            this.IdClient = idClient;
            this.TotalCost = totalCost;

        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public decimal TotalCost { get; private set; }

    }
}
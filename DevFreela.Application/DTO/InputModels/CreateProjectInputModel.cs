
namespace DevFreela.Application.DTO.InputModels{
    public class CreateProjectInputModel{
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public int IdFreelancer { get; private set; }
        public decimal TotalCost { get; private set; }

    }
}
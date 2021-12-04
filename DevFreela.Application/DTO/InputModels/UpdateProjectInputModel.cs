namespace DevFreela.Application.DTO.InputModels
{
    public class UpdateProjectInputModel
    {
        public int Id { get; set;}
        public string Title { get; private set;}
        public string Description { get; private set;}
        public decimal TotalCost { get; private set;}

        //Como realizar uma possivel troca de Freelancer
    }
}
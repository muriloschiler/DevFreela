namespace DevFreela.Application.DTO.InputModels
{
    public class SkillUpdateInputViewModel
    {

        public SkillUpdateInputViewModel(string description)
        {
            this.Description = description;

        }
        public int Id { get; private set; }
        public string Description { get; private set; }
    }
}
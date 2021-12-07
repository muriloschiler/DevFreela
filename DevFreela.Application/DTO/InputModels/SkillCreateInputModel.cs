namespace DevFreela.Application.DTO.InputModels
{
    public class SkillCreateInputModel
    {

        public SkillCreateInputModel(string description)
        {
            this.Description = description;

        }
        public string Description { get; private set; }
    }
}
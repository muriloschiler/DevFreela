namespace DevFreela.Application.DTO.InputModels
{
    public class CreateProjectCommentInputModel
    {
        
        public string Content { get; private set; }
        public int IdProject { get; private set; }
        public int IdUser { get; private set; }
    }
}
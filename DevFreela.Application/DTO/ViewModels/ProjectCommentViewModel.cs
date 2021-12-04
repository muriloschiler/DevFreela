namespace DevFreela.Application.DTO.InputModels
{
    public class ProjectCommentViewModel
    {

        public ProjectCommentViewModel(string content, int idUser)
        {
            this.Content = content;
            this.IdUser = idUser;

        }
        public string Content { get; set; }
        public int IdUser { get; set; }
    }
}
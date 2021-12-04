using System;

namespace DevFreela.Application.DTO.ViewModels
{
    public class ProjectCommentDetailsViewModel
    {

        public ProjectCommentDetailsViewModel(string content, int idProject, int idUser, DateTime createdAt)
        {
            this.Content = content;
            this.IdProject = idProject;
            this.IdUser = idUser;
            this.CreatedAt = createdAt;

        }
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
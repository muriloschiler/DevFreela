using System;

namespace DevFreela.Core.Entities
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, int idProject, int idUser)
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
            this.CreatedAt = DateTime.Now;
        }

        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
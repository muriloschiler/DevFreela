using System;

namespace DevFreela.Application.DTO.ViewModels
{
    public class ProjectCommentViewModel
    {
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }   
    }
}
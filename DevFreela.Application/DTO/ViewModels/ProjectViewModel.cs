using System;
using System.Collections.Generic;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.Application.DTO.ViewModels
{
    public class ProjectViewModel
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public decimal TotalCost { get; private set; }
        public ProjectStatus ProjectStatus { get; private set; }
    }
}
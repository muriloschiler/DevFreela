using System.Collections.Generic;
using DevFreela.Application.DTO.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetProject
{
    public class GetProjectQuery : IRequest<List<ProjectViewModel>>
    {

        public GetProjectQuery(string query)
        {
            this.Query = query;

        }
        public string Query { get; private set; }
    }
}
using System.Collections.Generic;
using DevFreela.Application.Queries.GetAllProject;
using MediatR;

namespace DevFreela.Application.Queries.GetProject
{
    public class GetAllProjectQuery : IRequest<List<ProjectViewModel>>
    {

        public GetAllProjectQuery(string query)
        {
            this.Query = query;

        }
        public string Query { get; private set; }
    }
}
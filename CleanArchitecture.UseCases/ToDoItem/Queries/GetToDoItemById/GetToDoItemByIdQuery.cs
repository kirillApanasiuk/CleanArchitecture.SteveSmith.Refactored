using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Architecture.Web.ApiModels;
using MediatR;

namespace CleanArchitecture.UseCases.ToDoItem.Queries.GetToDoItemById
{
    public class GetToDoItemByIdQuery:IRequest<ToDoItemDTO>
    {
        public int Id{ get; set; }
    }
}

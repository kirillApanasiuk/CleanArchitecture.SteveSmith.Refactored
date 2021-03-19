using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Architecture.Web.ApiModels;
using MediatR;

namespace CleanArchitecture.UseCases.ToDoItem.Commands
{
    public class CreateToDoItemQuery : IRequest<ToDoItemDTO>
    {
        public ToDoItemDTO dto { get; set; }
    }


}

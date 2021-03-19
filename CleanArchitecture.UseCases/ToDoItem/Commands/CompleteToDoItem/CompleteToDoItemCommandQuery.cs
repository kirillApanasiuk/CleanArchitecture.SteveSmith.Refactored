using Clean.Architecture.Web.ApiModels;
using MediatR;

namespace CleanArchitecture.UseCases.ToDoItem.Commands.CompleteToDoItem
{
   public class CompleteToDoItemCommandQuery:IRequest<ToDoItemDTO>
    {
        public int Id { get; set; }
    }

}

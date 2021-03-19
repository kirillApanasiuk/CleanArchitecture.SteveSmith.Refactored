using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Architecture.Web.ApiModels;
using MediatR;

namespace CleanArchitecture.UseCases.ToDoItem.Queries.GetToDoItemList
{
    public class GetToDoItemListQuery:IRequest<List<ToDoItemDTO>>
    {
    }
}

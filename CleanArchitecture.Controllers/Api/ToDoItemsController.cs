using System.Threading.Tasks;
using Clean.Architecture.Web.ApiModels;
using CleanArchitecture.Infrastructure.Interfaces;
using CleanArchitecture.UseCases.ToDoItem.Commands;
using CleanArchitecture.UseCases.ToDoItem.Commands.CompleteToDoItem;
using CleanArchitecture.UseCases.ToDoItem.Queries.GetToDoItemById;
using CleanArchitecture.UseCases.ToDoItem.Queries.GetToDoItemList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Architecture.Web.Api
{
    public class ToDoItemsController : BaseApiController
    {
        private readonly IRepository _repository;
        private readonly IMediator _mediator;

        public ToDoItemsController(
            IRepository repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var items = _mediator.Send(new GetToDoItemListQuery());
            return Ok(items);
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _mediator.Send(new GetToDoItemByIdQuery{Id = id});
            return Ok(item);
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoItemDTO item)
        {
           
            var dto = await _mediator.Send(new CreateToDoItemQuery{dto = item} );
            return Ok(dto);
        }

        [HttpPatch("{id:int}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var dto = _mediator.Send(new CompleteToDoItemCommandQuery {Id = id});

            return Ok(dto);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Clean.Architecture.Web.ApiModels;
using CleanArchitecture.Infrastructure.Interfaces;
using MediatR;

namespace CleanArchitecture.UseCases.ToDoItem.Commands.CompleteToDoItem
{
    public class CompleteToDoItemCommandHandler : IRequestHandler<CompleteToDoItemCommandQuery, ToDoItemDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public CompleteToDoItemCommandHandler(IMapper mapper,IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ToDoItemDTO> Handle(CompleteToDoItemCommandQuery request, CancellationToken cancellationToken)
        {
            var toDoItem = await _repository.GetByIdAsync<Clean.Architecture.Core.Entities.ToDoItem>(request.Id);
            toDoItem.MarkComplete();
            await _repository.UpdateAsync(toDoItem);
            var dto = _mapper.Map<ToDoItemDTO>(toDoItem);
            return dto;
        }
    }
}

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

namespace CleanArchitecture.UseCases.ToDoItem.Commands
{
    public class CreateToDoItemHandler : IRequestHandler<CreateToDoItemQuery, ToDoItemDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateToDoItemHandler(IRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ToDoItemDTO> Handle(CreateToDoItemQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Clean.Architecture.Core.Entities.ToDoItem>(request.dto);
            await _repository.AddAsync(entity);
            var dto = _mapper.Map<ToDoItemDTO>(entity);
            return dto;
        }
    }
}

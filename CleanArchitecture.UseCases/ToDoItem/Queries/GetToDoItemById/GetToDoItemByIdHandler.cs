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

namespace CleanArchitecture.UseCases.ToDoItem.Queries.GetToDoItemById
{
    public class GetToDoItemByIdHandler : IRequestHandler<GetToDoItemByIdQuery,ToDoItemDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetToDoItemByIdHandler(IRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ToDoItemDTO> Handle(GetToDoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync<Clean.Architecture.Core.Entities.ToDoItem>(request.Id);
            var dto= _mapper.Map<ToDoItemDTO>(entity);
            return dto;
        }
    }
}

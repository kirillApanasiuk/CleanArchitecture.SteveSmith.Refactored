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

namespace CleanArchitecture.UseCases.ToDoItem.Queries.GetToDoItemList
{
    public class GetToDoItemListHandler : IRequestHandler<GetToDoItemListQuery, List<ToDoItemDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetToDoItemListHandler(
            IRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ToDoItemDTO>> Handle(GetToDoItemListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.ListAsync<Clean.Architecture.Core.Entities.ToDoItem>();
            var dtos = _mapper.Map<List<ToDoItemDTO>>(entities);
            return dtos;

        }
    }
}

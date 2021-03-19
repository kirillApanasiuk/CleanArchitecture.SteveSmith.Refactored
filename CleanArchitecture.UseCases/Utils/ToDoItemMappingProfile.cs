using AutoMapper;
using Clean.Architecture.Web.ApiModels;

namespace CleanArchitecture.UseCases.Utils
{
   public  class ToDoItemMappingProfile:Profile
    {
        public ToDoItemMappingProfile()
        {
            CreateMap<Clean.Architecture.Core.Entities.ToDoItem, ToDoItemDTO>().ReverseMap();
        }
    }
}

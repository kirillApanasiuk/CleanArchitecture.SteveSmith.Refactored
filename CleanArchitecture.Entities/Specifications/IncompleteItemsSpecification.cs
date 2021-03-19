using Ardalis.Specification;
using Clean.Architecture.Core.Entities;

namespace CleanArchitecture.Entities.Specifications
{
    public class IncompleteItemsSpecification : Specification<ToDoItem>
    {
        public IncompleteItemsSpecification()
        {
            Query.Where(item => !item.IsDone);
        }
    }
}

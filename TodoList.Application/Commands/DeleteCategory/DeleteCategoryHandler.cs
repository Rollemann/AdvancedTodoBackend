using MediatR;
using TodoList.Application.Repositories;

namespace TodoList.Application.Commands.DeleteCategory;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<DeleteCategoryResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        //TODO: Hier kann noch logger rein
        var deleted = await _categoryRepository.DeleteCategory(request.Id);
        return new DeleteCategoryResult(deleted);
    }
}

using MediatR;
using TodoList.Application.Repositories;
using TodoList.Application.Validators;
using TodoList.Domain.Entities;

namespace TodoList.Application.Commands.UpdateCategory;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<UpdateCategoryResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (!ColorValidator.IsColorString(request.Color))
        {
            return new UpdateCategoryResult(false);
        }
        //TODO: Hier kann noch logger rein
        var category = new Category()
        {
            Id = request.Id,
            Name = request.Name,
            Color = request.Color,
            TodoItems = []
        };
        var updated = await _categoryRepository.UpdateCategory(category);
        return new UpdateCategoryResult(updated);
    }
}

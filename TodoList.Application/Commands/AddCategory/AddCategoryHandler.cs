using MediatR;
using TodoList.Application.Repositories;
using TodoList.Application.Validators;
using TodoList.Domain.Entities;

namespace TodoList.Application.Commands.AddCategory;

public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, AddCategoryResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<AddCategoryResult> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        //TODO: Hier kann noch logger rein
        if (!ColorValidator.IsColorString(request.Color))
        {
            return new AddCategoryResult(-1);
        }
        var categoryId = await _categoryRepository.AddCategory(new Category() { Name = request.Name, Color = request.Color, TodoItems = [] });
        return new AddCategoryResult(categoryId);
    }
}
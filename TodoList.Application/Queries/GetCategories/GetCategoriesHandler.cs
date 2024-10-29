using MediatR;
using TodoList.Application.Repositories;

namespace TodoList.Application.Queries.GetCategories;

public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, GetCategoriesResult>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategoriesResult> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        //TODO: Hier kann noch logger rein
        var categories = await _categoryRepository.GetCategories();
        return new GetCategoriesResult(categories);
    }
}

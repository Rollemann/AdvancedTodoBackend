using MediatR;

namespace TodoList.Application.Queries.GetCategories;

public record GetCategoriesQuery() : IRequest<GetCategoriesResult>;
using MediatR;

namespace TodoList.Application.Commands.DeleteCategory;

public record DeleteCategoryCommand(int Id) : IRequest<DeleteCategoryResult>;
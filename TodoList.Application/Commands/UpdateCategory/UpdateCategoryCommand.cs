using MediatR;

namespace TodoList.Application.Commands.UpdateCategory;

public record UpdateCategoryCommand(int Id, string Name, string Color) : IRequest<UpdateCategoryResult>;
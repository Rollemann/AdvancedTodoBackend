using MediatR;

namespace TodoList.Application.Commands.AddCategory;

public record AddCategoryCommand(string Name, string Color) : IRequest<AddCategoryResult>; 
// TODO: So gut oder Category als Input;
//mMn ist das mit Category zu viel abhängig und wenn man mal Category ändert dann ändert man die API
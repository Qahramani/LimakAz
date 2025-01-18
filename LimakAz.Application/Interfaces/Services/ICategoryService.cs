using LimakAz.Application.Interfaces.Services.Generic;

namespace LimakAz.Application.Interfaces.Services;

public interface ICategoryService: IGetService<CategoryGetDto>,IModifyService<CategoryCreateDto,CategoryUpdateDto>
{
}
public interface IMessageService 
{ 

}

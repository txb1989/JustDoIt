using Jst.Core.Application;
using Jurisdiction.Application.Dto;
using System.Collections.Generic;

namespace Jurisdiction.Application.Interface
{
    public interface IRoleApplicationService : IApplicationService
    {
        List<RoleDto> GetAllRole();
    }
}

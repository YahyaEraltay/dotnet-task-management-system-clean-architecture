using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Auth
{
    public interface IGenerateJwtToken
    {
        string GenerateToken(User user);
    }
}

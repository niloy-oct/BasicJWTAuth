using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicJWTAuth.Models;

namespace BasicJWTAuth.Repositories
{
    public interface IJWTManagerRepository
    {
        Tokens AuthenticateTokes(User user);
    }
}

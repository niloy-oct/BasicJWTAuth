using BasicJWTAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicJWTAuth.Repositories
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        // make this static//
        private Dictionary<string, string> userRecords = new Dictionary<string, string>
        {
            {"Niloy","HPLMIS"},
            {"Admin","HPLMIS123"},
            {"MIS","mis"},
        };


        public Tokens AuthenticateTokes(User user)
        {
            throw new NotImplementedException();
        }
    }
}

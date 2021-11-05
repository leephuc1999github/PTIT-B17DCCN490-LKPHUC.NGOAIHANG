using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models
{
    public enum StatusCode
    {
        Success = 200,
        NotFound = 404,
        InternalServerError = 500,
        Created = 201,
        NoContent = 204,
        Authorized = 401
    }
}

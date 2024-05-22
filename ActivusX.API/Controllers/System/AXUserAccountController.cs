using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActivusX.API.Data;
using ActivusX.Shared.Models.System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActivusX.API.Controllers.System;

[Route("api/MSAD/UserObj/[controller]")]
[ApiController]
public class AXUserAccountController : ControllerBase
{
    private readonly AppDbContext _context;

    public AXUserAccountController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AXUserAccount>>> GetUsers()
    {
        return await _context.AXUserAccounts.ToListAsync();
    }
}

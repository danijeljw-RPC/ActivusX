using ActivusX.API.Data;
using ActivusX.Shared.Models.MSAD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActivusX.API.Controllers.System;

[Route("api/MSAD/UserObj/[controller]")]
[ApiController]
public class ActiveDirectoryUserController : ControllerBase
{
    private readonly AppDbContext _context;

    public ActiveDirectoryUserController(AppDbContext context)
    {
        _context = context;
    }

    // GET: All AD users    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActiveDirectoryUser>>> GetUsers()
    {
        return await _context.ActiveDirectoryUsers.ToListAsync();
    }

    // GET: Count number of AD users
    [HttpGet]
    public async Task<ActionResult<int>> GetUsersCount()
    {
        var count = await _context.ActiveDirectoryUsers.ToListAsync();
        return count.Count;
    }

    // GET: Disabled users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActiveDirectoryUser>>> GetDisabledUsers()
    {
        return await _context.ActiveDirectoryUsers
            .Where(u => u.AccountEnabled == false)
            .ToListAsync();
    }
}

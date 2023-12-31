﻿using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers;
[ApiController]
[Route("api/[controller]")] // / api/users
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserApp>>> GetUsers() 
    {
        var users = await _context.Users.ToListAsync();

        return users;
    }

    [HttpGet("{id}")] // /api/users/2
    public async Task<ActionResult<UserApp>> GetUser(int id) 
    {
        return await _context.Users.FindAsync(id);
    }
}

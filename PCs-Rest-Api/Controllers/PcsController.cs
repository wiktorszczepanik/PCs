using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCs_Rest_Api.Data;
using PCs_Rest_Api.Entities;
using PCs_Rest_Api.Exceptions;
using PCs_Rest_Api.Services;

namespace PCs_Rest_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PcsController : ControllerBase {

    private readonly IComputerService _computerService;
    
    public PcsController(IComputerService computerService) {
        _computerService = computerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var computers = await _computerService.GetAllComputers();
        return Ok(computers);
    }
    
    //TODO

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        try {
            await _computerService.RemoveComputer(id);
            return NoContent();
        }
        catch (NotFoundException exception) {
            return NotFound(exception.Message);
        }
    }
    
}
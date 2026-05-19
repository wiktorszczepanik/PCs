using Microsoft.EntityFrameworkCore;
using PCs_Rest_Api.Data;
using PCs_Rest_Api.DTOs;
using PCs_Rest_Api.Exceptions;

namespace PCs_Rest_Api.Services;

public class ComputerService : IComputerService {

    private readonly AppDbContext _context;
    
    public ComputerService(AppDbContext context) {
        _context = context;
    }
    
    public async Task<IEnumerable<GetComputerDto>> GetAllComputers() {
        var computers = await _context.Computers.Select(computer => new GetComputerDto() {
            Id = computer.Id,
            Name = computer.Name,
            Weight = computer.Weight,
            Warranty = computer.Warranty,
            CreatedAt = computer.CreatedAt,
            Stock = computer.Stock
        }).ToListAsync();
        return computers;
    }

    public async Task DeleteComputer(int id) {
        var computer = await _context.Computers.FindAsync(id);
        if (computer == null) throw new NotFoundException();
        _context.Remove(computer);
        await _context.SaveChangesAsync();
    }
    
}
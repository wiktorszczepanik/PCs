using Microsoft.EntityFrameworkCore;
using PCs_Rest_Api.Data;
using PCs_Rest_Api.DTOs;
using PCs_Rest_Api.Entities;
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

    public async Task<GetComputerWithComponentsDto> GetComputerWithComponentsById(int id) {
        var computer = await _context.Computers
            .Where(computer => computer.Id == id)
            .Select(computer => new GetComputerWithComponentsDto() {
                Id = computer.Id,
                Name = computer.Name,
                Weight = computer.Weight,
                Warranty = computer.Warranty,
                CreatedAt = computer.CreatedAt,
                Stock = computer.Stock,
                Components = computer.ComputerComponents.Select(component => new GetComponentDto() {
                    Code = component.Component.Code,
                    Name = component.Component.Name,
                    Description = component.Component.Description,
                    Manufacturer = new GetComponentManufacturerDto() {
                        Id = component.Component.ComponentManufacturer.Id,
                        Abbreviation = component.Component.ComponentManufacturer.Abbreviation,
                        FullName = component.Component.ComponentManufacturer.FullName,
                        FoundationDate = component.Component.ComponentManufacturer.FoundationDate
                    },
                    Type = new GetComponentTypeDto() {
                        Id = component.Component.ComponentType.Id,
                        Abbreviation = component.Component.ComponentType.Abbreviation,
                        Name = component.Component.ComponentType.Name
                    }
                }).ToList()
            }).FirstOrDefaultAsync();
        return computer;
    }

    public async Task<GetComputerDto> CreateComputer(PostComputerDto postComputerDto) {
        var newComputer = new Computer() {
            Name = postComputerDto.Name,
            Weight = postComputerDto.Weight,
            Warranty = postComputerDto.Warranty,
            CreatedAt = postComputerDto.CreatedAt,
            Stock = postComputerDto.Stock
        };
        await _context.AddAsync(newComputer);
        await _context.SaveChangesAsync();
        return new GetComputerDto() {
            Id = newComputer.Id,
            Name = newComputer.Name,
            Weight = newComputer.Weight,
            Warranty = newComputer.Warranty,
            CreatedAt = newComputer.CreatedAt,
            Stock = newComputer.Stock
        };
    }

    public async Task ReplaceComputerInfoById(int id, PostComputerDto postComputerDto) {
        var computer = await _context.Computers.FirstOrDefaultAsync(computer => computer.Id == id);
        if (computer == null) throw new NotFoundException();
        computer.Name = postComputerDto.Name;
        computer.Weight = postComputerDto.Weight;
        computer.Warranty = postComputerDto.Warranty;
        computer.CreatedAt = postComputerDto.CreatedAt;
        computer.Stock = postComputerDto.Stock;
        await _context.SaveChangesAsync();
    }

    public async Task RemoveComputer(int id) {
        var computer = await _context.Computers.FindAsync(id);
        if (computer == null) throw new NotFoundException();
        _context.Remove(computer);
        await _context.SaveChangesAsync();
    }
    
}
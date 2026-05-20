using PCs_Rest_Api.DTOs;

namespace PCs_Rest_Api.Services;

public interface IComputerService {

    Task<IEnumerable<GetComputerDto>> GetAllComputers();
    Task<GetComputerWithComponentsDto> GetComputerWithComponentsById(int id);
    Task CreateComputer(PostComputerDto postComputerDto);
    Task ReplaceComputerInfoById(int id, PostComputerDto postComputerDto);
    Task RemoveComputer(int id);
    
}
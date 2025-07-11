using Microsoft.AspNetCore.Mvc;
using FP.Backend.Base.Services.Interface;

namespace FP.Backend.Base.Presentation;

[Route("api/[controller]")]
[ApiController]
public class MongoBaseController<T, TResponse> : ControllerBase where T : BaseEntity<Guid>
{
    private readonly IMongoBaseService<T> _service;

    public MongoBaseController(IMongoBaseService<T> service)
    {
        _service = service;
    }

    [HttpGet]
    public virtual async Task<ActionResult> GetAllAsync(
        [FromQuery] string search = null,   // Generic search across all properties
        [FromQuery] string filter = null,  // Specific filtering (e.g., "Department=Accounting")
        [FromQuery] int page = 1,           // Page number
        [FromQuery] int pageSize = 100,      // Items per page
        [FromQuery] string select = null)
    {
        var requestTime = DateTime.UtcNow;
        var response = await _service.GetAllAsync<TResponse>(search, filter, page, pageSize, select);
        var responseTime = DateTime.UtcNow;

        response.RequestTime = requestTime;
        response.ResponseTime = responseTime;

        if (response.IsSuccess)
            return Ok(response);
        else
            return BadRequest(response);
    }

    [HttpGet]
    [Route("{id}")]
    public virtual async Task<ActionResult> GetByIdAsync(string id)
    {
        var requestTime = DateTime.UtcNow;
        var response = await _service.GetByIdAsync<TResponse>(new Guid(id));
        var responseTime = DateTime.UtcNow;

        response.RequestTime = requestTime;
        response.ResponseTime = responseTime;

        if (response.IsSuccess)
            return Ok(response);
        else
            return BadRequest(response);
    }

    [HttpDelete]
    [Route("delete-all")]
    public virtual async Task<ActionResult> RemoveAsync()
    {
        var requestTime = DateTime.UtcNow;
        var response = await _service.RemoveAsync(x => x.IsActive == true);
        var responseTime = DateTime.UtcNow;

        response.RequestTime = requestTime;
        response.ResponseTime = responseTime;

        if (response.IsSuccess)
            return Ok(response);
        else
            return BadRequest(response);
    }

    protected async Task<ActionResult> CreateAsync<TRequest>([FromBody] TRequest request)
    {
        var requestTime = DateTime.UtcNow;
        var response = await _service.CreateAsync<TResponse, TRequest>(request);
        var responseTime = DateTime.UtcNow;

        response.RequestTime = requestTime;
        response.ResponseTime = responseTime;

        if (response.IsSuccess)
            return Ok(response);
        else
            return BadRequest(response);
    }

    protected async Task<ActionResult> UpdateAsync<TRequest>(Guid id, [FromBody] TRequest request)
    {
        var requestTime = DateTime.UtcNow;
        var response = await _service.UpdateAsync(id, request);
        var responseTime = DateTime.UtcNow;

        response.RequestTime = requestTime;
        response.ResponseTime = responseTime;

        if (response.IsSuccess)
            return Ok(response);
        else
            return BadRequest(response);
    }

    protected async Task<ActionResult> RemoveAsync(Guid id)
    {
        var requestTime = DateTime.UtcNow;
        var response = await _service.RemoveAsync(id);
        var responseTime = DateTime.UtcNow;

        response.RequestTime = requestTime;
        response.ResponseTime = responseTime;

        if (response.IsSuccess)
            return Ok(response);
        else
            return BadRequest(response);
    }

    protected async Task<ActionResult> ImportAsync<TRequest>([FromBody] TRequest[] requests)
    {
        var requestTime = DateTime.UtcNow;
        var response = await _service.ImportAsync(requests);
        var responseTime = DateTime.UtcNow;

        response.RequestTime = requestTime;
        response.ResponseTime = responseTime;

        if (response.IsSuccess)
            return Ok(response);
        else
            return BadRequest(response);
    }
}
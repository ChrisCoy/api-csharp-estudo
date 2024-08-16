using Infra;
using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _usersRepository;
    public UsersController(IUserRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    // GET: api/<UsersController>
    [HttpGet]
    public IEnumerable<object> Get()
    {
        return _usersRepository.FindAll();
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public object Get(string id)
    {
        return _usersRepository.FindById(new Guid(id));
    }

    // POST api/<UsersController>
    [HttpPost]
    public object Post([FromBody] string value)
    {
        return _usersRepository.Create(new User() { Id = Guid.NewGuid(), Name = value, Pedidos = {}});
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public object Put(string id, [FromBody] string value)
    {
        return _usersRepository.Update(new Guid(id), new User() { Id = new Guid(id), Name = value, Pedidos = { } });
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public object Delete(string id)
    {
        return _usersRepository.Delete(new Guid(id));
    }
}

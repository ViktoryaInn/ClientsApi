using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClientsApi.Models;
using ClientsApi.Schemas;
using ClientsApi.Services;
using ClientsApi.Validators;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/")]
    public class ClientController : Controller
    {
        private readonly ApiContext _context;
        private readonly ClientValidator _clientValidator;

        public ClientController(ApiContext context)
        {
            _clientValidator = new ClientValidator();
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Page<ClientDto>>> Get([FromQuery] PageInfo info)
        {
            var validator = new PageInfoValidator();
            await validator.ValidateAndThrowAsync(info);
            
            var clients = _context.Client.IncludeAll().ProjectToType<ClientDto>();

            var pageModel = await Page<ClientDto>.Create(info, clients);
            return pageModel;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> Get(Guid id, CancellationToken ct)
        {
            var client = await _context.Client.Where(c => c.Id == id).IncludeAll()
                .FirstOrDefaultAsync(ct);

            if (client == null)
            {
                return NotFound();
            }

            return client.Adapt<ClientDto>();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ClientDto clientDto, CancellationToken ct)
        {
            await _clientValidator.ValidateAndThrowAsync(clientDto, ct);

            var client = clientDto.Adapt<Client>();

            await using var transaction = await _context.Database.BeginTransactionAsync(ct);
            await _context.Client.AddAsync(client, ct);
            await _context.SaveChangesAsync(ct);
            if (client.Spouse != null)
                client.Spouse.SpouseId = client.Id;
            await _context.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Client>> Patch(Guid id, [FromBody] ClientDto patchedClient, CancellationToken ct)
        {
            await _clientValidator.ValidateAndThrowAsync(patchedClient, ct);
            patchedClient.Id = id;

            var client = await _context.Client.IncludeAll().FirstOrDefaultAsync(c => c.Id == id, ct);

            if (client == null)
            {
                return NotFound();
            }

            _context.Update(client);
            
            patchedClient.Adapt(client);

            await _context.SaveChangesAsync(ct);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> Delete(Guid id, CancellationToken ct)
        {
            var client = await _context.Client.FirstOrDefaultAsync(c => c.Id == id, ct);

            if (client == null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync(ct);
            return Ok();
        }
    }
}
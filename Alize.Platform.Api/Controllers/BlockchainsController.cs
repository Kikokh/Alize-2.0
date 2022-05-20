using Alize.Platform.Api.Responses.Blockchains;
using Alize.Platform.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlockchainsController : ControllerBase
    {
        private readonly IBlockchainRepository _blockchainRepository;
        private readonly IMapper _mapper;

        public BlockchainsController(IBlockchainRepository blockchainRepository, IMapper mapper)
        {
            _blockchainRepository = blockchainRepository;            
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blockchains = await _blockchainRepository.GetBlockchainsAsync();

            return Ok(_mapper.Map<IEnumerable<BlockchainResponse>>(blockchains));
        }
    }
}

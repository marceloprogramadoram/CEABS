using CEABS.Service.DTO;
using CEABS.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ceabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _serviceProducer;

        public ProducerController(IProducerService serviceProducer)
        {
            _serviceProducer = serviceProducer;
        }

        [HttpPost("add")]
        public async Task<ActionResult> Post(ProducerDTO producerDTO)
        {
            try
            {
                if (producerDTO is null)
                    return BadRequest();
                await _serviceProducer.AddProducerAsync(producerDTO);
                return Ok(producerDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> Update(int id)
        {
            try
            {
                await _serviceProducer.UpdateProducerAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpPut("remove/{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                await _serviceProducer.DeleteProducerAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }


        [HttpGet("all")]
        public async Task<ActionResult<List<ProducerDTO>>> GetProducers()
        {
            try
            {
                return (await _serviceProducer.GetAllProducerAsync()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpGet("byname/{producerName}")]
        public async Task<ActionResult<ProducerDTO>> GetProducerByName(string producerName)
        {
            try
            {
                return await _serviceProducer.GetProducerByNameAsync(producerName);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpGet("code/{key}")]
        public async Task<ActionResult<ProducerDTO>> GetProducerById(int key)
        {
            try
            {
                return await _serviceProducer.GetProducerByIdAsync(key);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }
    }
}

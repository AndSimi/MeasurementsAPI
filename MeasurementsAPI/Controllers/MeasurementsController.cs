using MeasurementsAPI.Models;
using MeasurementsAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeasurementsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementServices measurementServices;

        public MeasurementsController(IMeasurementServices measurementServices)
        {
            this.measurementServices = measurementServices;
        }

        // GET: api/<MeasurementsController>
        [HttpGet]
        public ActionResult<List<Measurements>> Get()
        {
            return measurementServices.GetAll();
        }

        // GET api/<MeasurementsController>/5
        [HttpGet("{id}")]
        public ActionResult<Measurements> Get(string id)
        {
           var measurement = measurementServices.get(id);

            if (measurement == null)
            {
                return NotFound($"Measurement with id = {id} not found");
            }

            return measurement;



        }

        // POST api/<MeasurementsController>
        [HttpPost]
        public void Post([FromBody] Measurements value)
        {

            measurementServices.create(value);
            




        }

     
    }
}

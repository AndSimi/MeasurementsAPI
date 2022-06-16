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
        //Get Http request used to get all of the measurements
        [HttpGet]
        public ActionResult<List<Measurements>> Get()
        {
            return measurementServices.GetAll();
        }

        // GET api/<MeasurementsController>/5
        // Get Http request used to get a single measurement by using it's id to query and find it in the database
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

        // GET: api/<MeasurementsController>
        // Get Http request used to get a list of all measurements for a specific plant, using it's name to query the database
        [HttpGet("{PlantName}")]
        public ActionResult<List<Measurements>> GetCertificate(string plantName)
        {
            var certificate = measurementServices.GetCertificate(plantName);
            if (certificate == null)
            {
                return NotFound($"Certificate for plant: {plantName} not found");
            }
            return certificate;
        }



        // POST api/<MeasurementsController>
        // Post Http request used to post new measurements to database
        [HttpPost]
        public void Post([FromBody] Measurements value)
        {

            measurementServices.create(value);
            
        }

     
    }
}

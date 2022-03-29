using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureFlight.Api.Models;
using SecureFlight.Api.Utils;
using SecureFlight.Core.Entities;
using SecureFlight.Core.Interfaces;

namespace SecureFlight.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassengersController : ControllerBase
    {
        private readonly IService<Passenger> _personService;
        private readonly IRepository<PassengerFlight> _passengerFlightRepository;
        private readonly IService<Flight> _flightService;

        public PassengersController(IService<Passenger> personService, IService<Flight> flightService)
        {
            _personService = personService;
            _flightService = flightService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PassengerDataTransferObject>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponseActionResult))]
        public async Task<IActionResult> Get()
        {
            var passengers = (await _personService.GetAllAsync()).Result
                .Select(x => new PassengerDataTransferObject
                {
                    Email = x.Email,
                    FirstName = x.FirstName,
                    Id = x.Id,
                    LastName = x.LastName
                });

            return Ok(passengers);
        }


        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<PassengerDataTransferObject>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResponseActionResult))]
        public async Task<IActionResult> AddPassengerToAnExistingFlight(PassengerFlightDataTransferObject passengerFlight) 
        {
            //_passengerService.AddPassengerToAnExistingFlight()
            var persons = _personService.GetAllAsync().Result;
            var passenger = persons.Result.FirstOrDefault();

            if () {
                var flights = _flightService.GetAllAsync().Result;
                if(flights.Result.Any(x => x.Id == passengerFlight.FlightId))
                {
                    _passengerFlightRepository.Save( new PassengerFlight passengerFlight);
                }
            }
            return NotFound();



            _personService.GetByIdAsync(passengerFlight.PassengerId)
            var passengers = (await _personService.GetAllAsync()).Result
                .Select(x => new PassengerDataTransferObject
                {
                    Email = x.Email,
                    FirstName = x.FirstName,
                    Id = x.Id,
                    LastName = x.LastName
                });

            return Ok(passengers);
        }

    }
}

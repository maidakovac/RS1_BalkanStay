﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApartmentController : ControllerBase
    {

        private readonly ApplicationDbContext _DbContext;


        public ApartmentController(ApplicationDbContext _DbContext)
        {

            this._DbContext = _DbContext;
        }

        [HttpGet]

        public ActionResult<List<Apartment>> Get()
        {
            var apartments = _DbContext.Apartments.Include(x=> x.City).ToList();

            if (apartments == null)
            {
                return BadRequest();
            }


            return Ok(apartments);
        }




        [HttpGet("{ApartmentId}")]

        public ActionResult<Apartment> GetById(int ApartmentId)
        {
            var apartment = _DbContext.Apartments.Find(ApartmentId);

            if (apartment == null)
            {
                return BadRequest();
            }

            return Ok(apartment);
        }




        [HttpDelete("{ApartmentId}")]

        public ActionResult Delete(int ApartmentId)
        {
            var apartment = _DbContext.Apartments.Find(ApartmentId);

            if (apartment == null)
            {
                return BadRequest();
            }

            _DbContext.Apartments.Remove(apartment);
            _DbContext.SaveChanges();

            return Ok();
        }




        [HttpPost] /// INSERT

        public ActionResult Insert(ApartmentInsertVM apartment)
        {
            var newApartment = new Apartment()
            {
                Name = apartment.Name,
                Description = apartment.Description,
                Adress = apartment.Adress,
                PricePerNight = apartment.PricePerNight,
                CityId = apartment.CityId,
                AccountID = apartment.AccountID
            };

            _DbContext.Apartments.Add(newApartment);
            _DbContext.SaveChanges();

            return Ok(newApartment);
        }



        [HttpPut] ///UPDATE

        public ActionResult Update(ApartmentUpdateVM apartment)
        {
            var updatedApartment = _DbContext.Apartments.Find(apartment.ApartmentId);

            if(updatedApartment == null)
            {
                return BadRequest();
            }

            updatedApartment.Name = apartment.Name;
            updatedApartment.Description = apartment.Description;
            updatedApartment.Adress = apartment.Address;
            updatedApartment.PricePerNight = apartment.PricePerNight;
            updatedApartment.CityId = apartment.CityId;
            updatedApartment.AccountID = apartment.AccountID;

            _DbContext.Apartments.Update(updatedApartment);
            _DbContext.SaveChanges();

            return Ok();
        }
    }
}

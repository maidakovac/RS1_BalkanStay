using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.DataTransferObjects;
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

        //[HttpGet]

        //public ActionResult<List<Apartment>> Get()
        //{
        //    var apartments = _DbContext.Apartments
        //                        .Include(x => x.City)
        //                            .ThenInclude(x => x.Country)
        //                        .Include(y => y.ApartmentImages)
        //                            .ThenInclude(y => y.Image)
        //                        .ToList();

        //    if (apartments == null)
        //    {
        //        return BadRequest();
        //    }


        //    return Ok(apartments);
        //}


        [HttpGet]
        public ActionResult<List<ApartmentDTO>> Get()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}"; // Generiše bazni URL, npr. http://localhost:8000

            var apartments = _DbContext.Apartments
                                       .Include(x => x.City)
                                           .ThenInclude(y => y.Country)
                                       .Include(x => x.ApartmentImages)
                                           .ThenInclude(z => z.Image)
                                       .Include(x => x.Account)
                                       .Include(x => x.Reservations)
                                           .ThenInclude(a => a.Account)
                                       .Include(x => x.ApartmentRules)
                                       .Include(x => x.ApartmentAmenities)
                                       .Include(x => x.ApartmentToiletries)
                                       .ToList();

           
            var apartmentDtos = apartments.Select(apartment => new ApartmentDTO
            {
                ApartmentId = apartment.ApartmentId,
                Name = apartment.Name,
                Description = apartment.Description,
                Adress = apartment.Adress, 
                PricePerNight = apartment.PricePerNight,
                CityName = apartment.City?.Name,
                CountryName = apartment.City?.Country?.Name,
                Amenities = apartment.ApartmentAmenities
                             .Where(aa => aa.Amenity != null) 
                             .Select(aa => aa.Amenity.AmenityText)
                             .ToList(),
                Toiletries = apartment.ApartmentToiletries
                              .Where(at => at.Toiletry != null)
                              .Select(at => at.Toiletry.Name)
                              .ToList(),
                Rules = apartment.ApartmentRules
                               .Where(ar => ar.Rule != null)
                               .Select(r => r.Rule.RuleText)
                               .ToList(),
                ImagePaths = apartment.ApartmentImages
                    .Where(image => !string.IsNullOrEmpty(image.Image?.ImagePath))
                    .Select(image => $"http://localhost:8000/images/{Path.GetFileName(image.Image.ImagePath)}")
                    .ToList()
            }).ToList();

            return Ok(apartmentDtos);
        }



        [HttpGet("{ApartmentId}")]
        public ActionResult<ApartmentDTO> GetById(int ApartmentId)
        {
            var apartment = _DbContext.Apartments
                                      .Include(x => x.City)
                                          .ThenInclude(y => y.Country)
                                      .Include(x => x.ApartmentImages)
                                          .ThenInclude(z => z.Image)
                                      .Include(x => x.Account)
                                      .Include(x => x.Reservations)
                                          .ThenInclude(a => a.Account)
                                      .Include(x => x.ApartmentRules)
                                          .ThenInclude(r => r.Rule)
                                      .Include(x => x.ApartmentAmenities)
                                          .ThenInclude(aa => aa.Amenity)
                                      .Include(x => x.ApartmentToiletries)
                                          .ThenInclude(t => t.Toiletry)
                                      .FirstOrDefault(a => a.ApartmentId == ApartmentId);

            if (apartment == null)
            {
                return NotFound();
            }

            // Pripremite DTO
            var apartmentDto = new ApartmentDTO
            {
                ApartmentId = apartment.ApartmentId,
                Name=apartment.Name,
                Description=apartment.Description,
                Adress=apartment.Adress,
                PricePerNight=apartment.PricePerNight,
                CityName = apartment.City?.Name,
                CountryName = apartment.City?.Country?.Name,
                Amenities = apartment.ApartmentAmenities.Select(aa => aa.Amenity.AmenityText).ToList(),
                Toiletries = apartment.ApartmentToiletries.Select(t => t.Toiletry.Name).ToList(),
                Rules = apartment.ApartmentRules.Select(r => r.Rule.RuleText).ToList(),
                ImagePaths = apartment.ApartmentImages
                    .Where(image => !string.IsNullOrEmpty(image.Image?.ImagePath))
                    .Select(image => $"http://localhost:8000/images/{Path.GetFileName(image.Image.ImagePath)}")
                    .ToList()
            };

            return Ok(apartmentDto);
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

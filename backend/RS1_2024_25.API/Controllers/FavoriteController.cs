﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.ViewModel;


namespace RS1_2024_25.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    
    public class FavoriteController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;


        public FavoriteController(ApplicationDbContext _DbContext)
        {
            this._DbContext = _DbContext;
        }



        [HttpGet]

        public ActionResult<List<Favorite>> Get()
        {
            var favorites = _DbContext.Favorites
                                        .Include(x => x.Account)
                                        .Include(x => x.Apartment)
                                            .ThenInclude(y => y.City)
                                                .ThenInclude(z => z.Country)
                                        .ToList();

            if (favorites == null)
            {
                return BadRequest();
            }


            return Ok(favorites);
        }
        [HttpGet("{FavoriteID}")]

        public ActionResult<Favorite> GetById(int FavoriteID)
        {
            var favorites = _DbContext.Favorites
                                        .Include(x => x.Account)
                                        .Include(x => x.Apartment)
                                            .ThenInclude(y => y.City)
                                                .ThenInclude(z => z.Country)
                                        .FirstOrDefault(a => FavoriteID == FavoriteID);

            if (favorites == null)
            {
                return BadRequest();
            }

            return Ok(favorites);
        }




        [HttpDelete("{FavoriteID}")]

        public ActionResult Delete(int FavoriteID)
        {
            var favorite = _DbContext.Favorites.Find(FavoriteID);

            if (favorite == null)
            {
                return BadRequest();
            }

            _DbContext.Favorites.Remove(favorite);
            _DbContext.SaveChanges();

            return Ok();
        }




        [HttpPost] /// INSERT

        public ActionResult Insert(FavoriteInsertVM favorite)
        {
            var newFavorite = new Favorite()
            {
                AccountID = favorite.AccountID,
                ApartmentId =favorite.ApartmentId
            };

            _DbContext.Favorites.Add(newFavorite);
            _DbContext.SaveChanges();


            return Ok(newFavorite);
        }




        [HttpPut] ///UPDATE

        public ActionResult Update(FavoriteUpdateVM favorite)
        {
            var updatedFavorite = _DbContext.Favorites.Find(favorite.FavoriteID);

            if (updatedFavorite == null)
            {
                return BadRequest();
            }

            updatedFavorite.AccountID = favorite.AccountID;
            updatedFavorite.ApartmentId = favorite.ApartmentId;

            _DbContext.Favorites.Update(updatedFavorite);
            _DbContext.SaveChanges();

            return Ok(updatedFavorite);
        }
    }
}

﻿using ClientManagementService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly ILogger<OfferController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public OfferController(
            ILogger<OfferController> logger,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var offers = await _unitOfWork.Offers.All();
            _logger.LogInformation($"Total Offer:{offers.Count()}");
            return Ok(offers);
        }

        // GET api/<OfferController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var offer = await _unitOfWork.Offers.GetByID(id);

            if (offer == null)
                return NotFound();
            _logger.LogInformation($"Offer Info:{JsonConvert.SerializeObject(offer)}");
            return Ok(offer);
        }

        // POST api/<OfferController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Offer offer)
        {
            try
            {
                _logger.LogInformation($"Offer Info:{JsonConvert.SerializeObject(offer)}");
                if (offer == null || offer.OfferItems == null)
                {
                    return BadRequest();
                }
                var offerItems = offer.OfferItems;
                await _unitOfWork.Offers.Add(offer);
                foreach (var item in offerItems)
                {
                    await _unitOfWork.OfferItems.Add(item);
                }
                await _unitOfWork.CompleteAsync();
                await Task.FromResult(offer);
                _logger.LogInformation($"{offer.Id}-Client{offer.ArticleNumber} added successfully.");
                return Ok(offer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }

        // PUT api/<OfferController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Offer>> Put(int id, [FromBody] Offer offer)
        {
            _logger.LogInformation($"Offer Update Info:{JsonConvert.SerializeObject(offer)}");
            if (id != offer.Id)
            {
                return BadRequest();
            }
            var offerExists = await _unitOfWork.Offers.GetByID(id);
            if (offerExists == null)
                return NotFound();
            try
            {
                foreach (var item in offer.OfferItems)
                {
                    await _unitOfWork.OfferItems.Update(item);
                }
                await _unitOfWork.Offers.Update(offer);
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"{id}:{offer.ArticleNumber} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
            return await Task.FromResult(offer);
        }


        [HttpPut("{id}/{date}/")]
        public async Task<ActionResult> OfferOrderUpdate(int id, DateTime date, [FromBody] List<OfferItem> items)
        {
            _logger.LogInformation($"Offer Update Info:{JsonConvert.SerializeObject("Offer "+id+" is updating.")}");
            
            var offerExists = await _unitOfWork.Offers.GetByID(id);
            if (offerExists == null)
                return NotFound();
            try
            {
                foreach (var item in items)
                {
                    await _unitOfWork.OfferItems.UpdatePurchaseFlag(item.Id, item.IsPurchased);
                }
                await _unitOfWork.Offers.UpdateOfferPurchaseDate(id, date);
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"Offer Id: {id} updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
            return new JsonResult("Offer updated successfully") { StatusCode = 200 };
        }
        // DELETE api/<OfferController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Offer>> Delete(int id)
        {
            try
            {
                var offer = await _unitOfWork.Offers.GetByID(id);
                if (offer == null)
                    return NotFound();
                foreach (var item in offer.OfferItems)
                {
                    await _unitOfWork.OfferItems.Delete(item.Id);
                }
                await _unitOfWork.Offers.Delete(offer.Id);
                await _unitOfWork.CompleteAsync();
                _logger.LogInformation($"{id}:{offer.ArticleNumber} deleted successfully.");
                return await Task.FromResult(offer);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 500 };
            }
        }
    }
}

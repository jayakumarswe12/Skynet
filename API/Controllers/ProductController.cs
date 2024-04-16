using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DataContext;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _Repo;

        public ProductController(IProductRepository Repo)
        {
            _Repo = Repo;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _Repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductsById{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _Repo.GetProductByIdAsync(id);
        }
    }
}
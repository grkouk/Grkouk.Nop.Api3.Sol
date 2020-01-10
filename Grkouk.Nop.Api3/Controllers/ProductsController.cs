using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grkouk.Nop.Api3.Data;
using Grkouk.Nop.Api3.Dtos;
using Grkouk.Nop.Api3.Filters;
using Grkouk.Nop.Api3.Models;
using GrKouk.Shared.Definitions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Hosting;
using ProductListDto = Grkouk.Nop.Api3.Dtos.ProductListDto;

namespace Grkouk.Nop.Api3.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AngelikasDbContext _angContext;
        private readonly HandmadeDbContext _handContext;
        private readonly BraxiolakiContext _braxiolakiContext;
      

        public ProductsController(AngelikasDbContext angContext,HandmadeDbContext handContext, BraxiolakiContext braxiolakiContext)
        {
            _angContext = angContext;
            _handContext = handContext;
            _braxiolakiContext = braxiolakiContext;
         
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _angContext.Product.ToListAsync();
        }

        [HttpGet("ShopProductPictures")]
        public async Task<ActionResult<IEnumerable<ProductPictureDto>>> GetShopProductPictures(int productId, string shop)
        {
            if (!String.IsNullOrEmpty(shop) && Int32.TryParse(shop, out var shopId) && shopId > 0)
            {
                var flt = (ShopEnum)shopId;
                IQueryable<ProductPictureMapping> items;
                switch (flt)
                {
                    case ShopEnum.ShopAngelikasCreations:
                        items = _angContext.ProductPictureMapping;
                        break;
                    case ShopEnum.ShopHandmadeCreations:
                        items = _handContext.ProductPictureMapping;
                        break;
                    case ShopEnum.ShopToBraxiolaki:
                        items = _braxiolakiContext.ProductPictureMapping;
                        break;
                    default:
                        return BadRequest();
                }
                var t = items.Where(p => p.ProductId == productId)
                    .Select(p => new ProductPictureDto
                    {
                        ProductId = p.ProductId,
                        ProductName = p.Product.Name,
                        SeoFilename = p.Picture.SeoFilename

                    });
                var t1 = await t.ToListAsync();

                return Ok(t1);
            }
            return BadRequest();
        }
        [HttpGet("FltShopProductsAutoCompleteList")]
        public async Task<ActionResult<IEnumerable<ProductListDto>>> GetFltShopAutoCompleteProductsList(string shop)
        {
            if (!String.IsNullOrEmpty(shop) && Int32.TryParse(shop, out var shopId) && shopId > 0)
            {
                var flt = (ShopEnum)shopId;
                IQueryable<Product> items;
                switch (flt)
                {
                    case ShopEnum.ShopAngelikasCreations:
                        items = _angContext.Product;
                        break;
                    case ShopEnum.ShopHandmadeCreations:
                        items = _handContext.Product;
                        break;
                    case ShopEnum.ShopToBraxiolaki:
                        items = _braxiolakiContext.Product;
                        break;
                    default:
                        return BadRequest();
                }
                var t = items.Select(p => new ProductListDto
                    {
                        Id=p.Id,
                        Name = p.Name,
                        Code = p.Sku
                    });
                var t1 = await t.ToListAsync();

                return Ok(t1);
            }

            return Ok(new {});
        }
        [HttpGet("AngProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAngProduct()
        {
            return await _angContext.Product.ToListAsync();
        }
        [HttpGet("HandProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetHandProduct()
        {
            return await _handContext.Product.ToListAsync();
        }
        [HttpGet("ProductCodes")]
        public async Task<ActionResult<IEnumerable<CodeDto>>> GetProductCodes(string codeBase)
        {
            List<CodeDto> items;
            if (string.IsNullOrEmpty(codeBase))
            {
                items = await _angContext.Product.OrderByDescending(p => p.Sku)
                    .Select(t => new CodeDto
                    {
                        Code = t.Sku
                    }).ToListAsync();
            }
            else
            {
                items = await _angContext.Product.Where(p => p.Sku.Contains(codeBase))
                    .OrderByDescending(p => p.Sku)
                    .Select(t => new CodeDto
                    {
                        Code = t.Sku
                    }).ToListAsync();
            }

            return Ok(items);
        }
        [HttpGet("Codes")]
        public async Task<ActionResult<IEnumerable<ProductListDto>>> GetProductsByCode(string codeBase)
        {
            var items = _angContext.Product
                .Select(p => new ProductListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Sku
                });

            if (!String.IsNullOrEmpty(codeBase))
            {
                items = items.Where(p => p.Code.Contains(codeBase));
            }
            var listItems = await items.OrderByDescending(p => p.Code).ToListAsync();

            return Ok(listItems);
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _angContext.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _angContext.Entry(product).State = EntityState.Modified;

            try
            {
                await _angContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _angContext.Product.Add(product);
            await _angContext.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _angContext.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _angContext.Product.Remove(product);
            await _angContext.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _angContext.Product.Any(e => e.Id == id);
        }
    }
}

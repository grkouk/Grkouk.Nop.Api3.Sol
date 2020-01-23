using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Grkouk.Nop.Api3.Data;
using GrKouk.Shared.Mobile.Dtos;
using Grkouk.Nop.Api3.Filters;
using Grkouk.Nop.Api3.Helpers;
using Grkouk.Nop.Api3.Models;
using GrKouk.Shared.Core;
using GrKouk.Shared.Definitions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProductListDto = GrKouk.Shared.Mobile.Dtos.ProductListDto;

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


        public ProductsController(AngelikasDbContext angContext, HandmadeDbContext handContext, BraxiolakiContext braxiolakiContext)
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

        private string GetProductImageUrl(int pictureId, string seoFilename, string mimeType, string urlBase)
        {
            var a1 = pictureId.ToString("D7");
            var a2 = seoFilename;
            var a3 = "jpeg";
            return $"{urlBase}{a1}_{a2}.{a3}";
        }
        [HttpGet("ShopProductPictures")]
        public async Task<ActionResult<IEnumerable<ProductListDto>>> GetShopProductPictures(int productId, string shop)
        {
            if (!String.IsNullOrEmpty(shop) && Int32.TryParse(shop, out var shopId) && shopId > 0)
            {
                var urlBase = "";
                var flt = (ShopEnum)shopId;
                IQueryable<ProductPictureMapping> items;
                switch (flt)
                {
                    case ShopEnum.ShopAngelikasCreations:
                        urlBase = "https://angelikascreations.com/images/thumbs/000/";
                        items = _angContext.ProductPictureMapping;
                        break;
                    case ShopEnum.ShopHandmadeCreations:
                        urlBase = "https://handmade-creations.com/images/thumbs/000/";
                        items = _handContext.ProductPictureMapping;
                        break;
                    case ShopEnum.ShopToBraxiolaki:
                        urlBase = "https://tobraxiolaki.gr/images/thumbs/000/";
                        items = _braxiolakiContext.ProductPictureMapping;
                        break;
                    default:
                        return BadRequest();
                }
                var t = await items.Where(p => p.ProductId == productId)
                    .Select(p => new ProductPictureDto
                    {
                        ProductId = p.ProductId,
                        PictureId = p.PictureId,
                        ProductName = $"{{{p.Product.Sku}}} {p.Product.Name}",
                        SeoFilename = p.Picture.SeoFilename,
                        MimeType = p.Picture.MimeType

                    }).ToListAsync();
                var t1 = t.Select(p => new ProductListDto
                {
                    Id = p.ProductId,
                    Name = p.ProductName,

                    ImageUrl = GetProductImageUrl(p.PictureId, p.SeoFilename, p.MimeType, urlBase)
                }).ToList();

                return Ok(t1);
            }
            return BadRequest();
        }
        [HttpGet("ShopProductPrimarySlug")]
        public async Task<ActionResult<ListItemDto>> GetShopProductPrimarySlug(int productId, string shop)
        {
            if (!String.IsNullOrEmpty(shop) && Int32.TryParse(shop, out var shopId) && shopId > 0)
            {
                var flt = (ShopEnum)shopId;
                IQueryable<UrlRecord> items;
                switch (flt)
                {
                    case ShopEnum.ShopAngelikasCreations:
                        items = _angContext.UrlRecord;
                        break;
                    case ShopEnum.ShopHandmadeCreations:
                        items = _handContext.UrlRecord;
                        break;
                    case ShopEnum.ShopToBraxiolaki:
                        items = _braxiolakiContext.UrlRecord;
                        break;
                    default:
                        return BadRequest();
                }
                var t = await items.Where(p => p.EntityId == productId && p.EntityName == "Product" && p.IsActive && p.LanguageId == 0)
                    .Select(p => new ListItemDto
                    {
                        ItemId = p.Id,
                        ItemName = p.Slug,
                        ItemCode = p.Slug

                    }).SingleOrDefaultAsync();

                return Ok(t);
            }
            return BadRequest();
        }
        [HttpGet("ShopProductSlugs")]
        public async Task<ActionResult<IEnumerable<ListItemDto>>> GetShopProductSlugs(int productId, string shop)
        {
            if (!String.IsNullOrEmpty(shop) && Int32.TryParse(shop, out var shopId) && shopId > 0)
            {
                var flt = (ShopEnum)shopId;
                IQueryable<UrlRecord> items;
                switch (flt)
                {
                    case ShopEnum.ShopAngelikasCreations:
                        items = _angContext.UrlRecord;
                        break;
                    case ShopEnum.ShopHandmadeCreations:
                        items = _handContext.UrlRecord;
                        break;
                    case ShopEnum.ShopToBraxiolaki:
                        items = _braxiolakiContext.UrlRecord;
                        break;
                    default:
                        return BadRequest();
                }
                var t = await items.Where(p => p.EntityId == productId && p.EntityName == "Product" && p.IsActive && p.LanguageId == 0)
                    .Select(p => new ListItemDto
                    {
                        ItemId = p.Id,
                        ItemName = p.Slug,
                        ItemCode = p.Slug

                    }).ToListAsync();

                return Ok(t);
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
                    Id = p.Id,
                    Name = p.Name,
                    NameCombined = $"{{{p.Sku}}} {p.Name}",
                    Code = p.Sku
                });
                var t1 = await t.ToListAsync();

                return Ok(t1);
            }

            return Ok(new { });
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
            List<CodeDto> items1;
            List<CodeDto> items2;
            List<CodeDto> items3;
            if (string.IsNullOrEmpty(codeBase))
            {
                items1 = await _angContext.Product.OrderByDescending(p => p.Sku)
                    .Select(t => new CodeDto
                    {
                        Code = t.Sku
                    }).ToListAsync();
                items2 = await _handContext.Product.OrderByDescending(p => p.Sku)
                    .Select(t => new CodeDto
                    {
                        Code = t.Sku
                    }).ToListAsync();
                items3 = await _braxiolakiContext.Product.OrderByDescending(p => p.Sku)
                    .Select(t => new CodeDto
                    {
                        Code = t.Sku
                    }).ToListAsync();
            }
            else
            {
                items1 = await _angContext.Product.Where(p => p.Sku.Contains(codeBase))
                    .OrderByDescending(p => p.Sku)
                    .Select(t => new CodeDto
                    {
                        Code = t.Sku
                    }).ToListAsync();
                items2 = await _handContext.Product.Where(p => p.Sku.Contains(codeBase))
                    .OrderByDescending(p => p.Sku)
                    .Select(t => new CodeDto
                    {
                        Code = t.Sku
                    }).ToListAsync();
                items3 = await _braxiolakiContext.Product.Where(p => p.Sku.Contains(codeBase))
                    .OrderByDescending(p => p.Sku)
                    .Select(t => new CodeDto
                    {
                        Code = t.Sku
                    }).ToListAsync();
            }

            var cmbList = new HashSet<CodeDto>(items1, new CodeDtoComparer());
            cmbList.UnionWith(items2);
            cmbList.UnionWith(items3);
            //var rt = cmbList.ToList();


            return Ok(cmbList);
        }
        [HttpGet("Codes")]
        public async Task<ActionResult<IEnumerable<ProductListDto>>> GetProductsByCode(string codeBase)
        {
            Debug.WriteLine($"*********Inside GetProductsByCode with codeBase={codeBase} ");
            //return StatusCode(StatusCodes.Status500InternalServerError);
            var items1 = _angContext.Product
                 .Select(p => new ProductListDto
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Code = p.Sku
                 });
            var items2 = _handContext.Product
                .Select(p => new ProductListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Sku
                });
            var items3 = _braxiolakiContext.Product
                   .Select(p => new ProductListDto
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Code = p.Sku
                   });
           
            if (!String.IsNullOrEmpty(codeBase))
            {
                items1 = items1.Where(p => p.Code.Contains(codeBase)).OrderByDescending(p => p.Code);
                items2 = items2.Where(p => p.Code.Contains(codeBase)).OrderByDescending(p => p.Code);
                items3 = items3.Where(p => p.Code.Contains(codeBase)).OrderByDescending(p => p.Code);
            }
            var listItems1 = await items1.ToListAsync();
            var listItems2 = await items2.ToListAsync();
            var listItems3 = await items3.ToListAsync();
            var listItems = new HashSet<ProductListDto>( listItems1, new ProductListDtoComparer());
            listItems.UnionWith(listItems2);
            listItems.UnionWith(listItems3);
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

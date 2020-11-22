using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grkouk.Nop.Api3.Data;
using Grkouk.Nop.Api3.Models;
using GrKouk.Shared.Definitions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grkouk.Nop.Api3.Controllers
{
    [ApiController]
  
    [Route("[controller]")]
    public class InfoController: ControllerBase
    {
        private readonly AngelikasDbContext _angContext;
        private readonly HandmadeDbContext _handContext;
        private readonly BraxiolakiContext _braxiolakiContext;


        public InfoController(AngelikasDbContext angContext, HandmadeDbContext handContext, BraxiolakiContext braxiolakiContext)
        {
            _angContext = angContext;
            _handContext = handContext;
            _braxiolakiContext = braxiolakiContext;

        }
        [HttpGet]
        public  IActionResult Get(int shopId=0)
        {
            string databaseServer;
            string shopName;
            if (shopId==0)
            {
                shopId = 1;
            }
            var flt = (ShopEnum)shopId;
           
            switch (flt)
            {
                case ShopEnum.ShopAngelikasCreations:
                    databaseServer = _angContext.Database.GetDbConnection().DataSource;
                    shopName = "Angelikas Creations";
                    break;
                case ShopEnum.ShopHandmadeCreations:
                    databaseServer = _handContext.Database.GetDbConnection().DataSource;
                    shopName = "The Art Of Handmade";
                    break;
                case ShopEnum.ShopToBraxiolaki:
                    databaseServer = _braxiolakiContext.Database.GetDbConnection().DataSource;
                    shopName = "To Braxiolaki";
                    break;
                default:
                    databaseServer = _angContext.Database.GetDbConnection().DataSource;
                    shopName = "Angelikas Creations";
                    break;
            }
           
            return  Ok(new {ServerName=$"{databaseServer}",ShopName=$"{shopName}"});
        }
    }
}

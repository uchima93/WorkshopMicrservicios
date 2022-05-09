using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientInfoController : ControllerBase
    {
        private static readonly ClientInfo[] TheMenu = new[]
        {
        new ClientInfo {id= 0, nombres= "María Altagracia", apellidos= "Rodríguez Perez", correoElectronico= "altaperez@gmail.com", tipoCliente= "Mayorista", fechaCreacion= Convert.ToDateTime("2019-09-04")},
        new ClientInfo {id= 1, nombres= "Rafael", apellidos= "Martínez García", correoElectronico= "rafaelmarga@hotmail.com", tipoCliente= "Minorista", fechaCreacion= Convert.ToDateTime("2020-03-05")},
        new ClientInfo {id= 2, nombres= "Juana", apellidos= "Sánchez Ramírez", correoElectronico= "juanitaram@ymail.com", tipoCliente= "Publico", fechaCreacion= Convert.ToDateTime("2015-01-08")},
        new ClientInfo {id= 3, nombres= "Juan Carlos", apellidos= "Díaz González", correoElectronico= "jcdiaz@icloud.com", tipoCliente= "Minorista", fechaCreacion= Convert.ToDateTime("2022-02-02")},
        new ClientInfo {id= 4, nombres= "Carmen Elizabeh", apellidos= "Reyes Castillo", correoElectronico= "carrey@msn.es", tipoCliente= "Mayorista", fechaCreacion= Convert.ToDateTime("2021-07-06")}
    };

        private readonly ILogger<ClientInfoController> _logger;

        public ClientInfoController(ILogger<ClientInfoController> logger)
        {
            _logger = logger;
        }

         [HttpGet]
         public IEnumerable<ClientInfo> Get()
         {
             return TheMenu;
         }
    }
}

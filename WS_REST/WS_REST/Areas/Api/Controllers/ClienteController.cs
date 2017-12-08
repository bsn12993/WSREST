using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WS_REST.Areas.Api.Models;

namespace WS_REST.Areas.Api.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteManager clientesManager;

        public ClienteController()
        {
            clientesManager = new ClienteManager();
        }

        [HttpGet]
        public JsonResult Clientes()
        {
            return Json(this.clientesManager.ObtenerClientes(),JsonRequestBehavior.AllowGet);
        }

        public JsonResult Cliente(int? id,Cliente item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(clientesManager.InsertarCliente(item));
                case "PUT":
                    return Json(clientesManager.ActualizarCliente(item));
                case "GET":
                    return Json(clientesManager.ObtenerCliente(id.GetValueOrDefault()),JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(clientesManager.EliminarCliente(id.GetValueOrDefault()));
            }
            return Json(new { Error = true, Message = "Operacion HTTP desconocida" });
        }
    }
}
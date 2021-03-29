using BNE_API.Controllers;
using BNE_API.Models;

namespace BNEAPITEST
{
    internal class TarefaPedidosController : TarefaPedidoController
    {
        private IPedidos _service;

        public TarefaPedidosController(IPedidos service)
        {
            _service = service;
        }
    }
}
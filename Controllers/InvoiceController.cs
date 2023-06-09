using Microsoft.AspNetCore.Mvc;
using ParkingSystemApi.Models;
using ParkingSystemApi.Service;

namespace ParkingSystemApi.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public IActionResult InvoiceList()
        {
            var invoices = _invoiceService.GetAllInvoice();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public IActionResult GetInvoiceById(int id)
        {
            var invoice = _invoiceService.GetInvoiceById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            
            return Ok(invoice);
        }

        [HttpGet("unpaid")]
        public IActionResult UnpaidInvoice()
        {
            var invoices = _invoiceService.GetUnpaidInvoice();
            return Ok(invoices);
        }

        [HttpGet("parkinghistory/{parkingHistoryId}")]
        public IActionResult GetInvoiceByParkingHistory(int parkingHistoryId)
        {
            var invoice = _invoiceService.GetInvoiceByParkingHistory(parkingHistoryId);
            if (invoice == null)
            {
                return NotFound("The vehicle is still parked");
            }

            return Ok(invoice);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            var invoice = _invoiceService.DeleteInvoice(id);
            if (invoice == null)
            {
                return NotFound();
            }

            return Ok($"Invoice {id} was successfully deleted");
        }
    }
}
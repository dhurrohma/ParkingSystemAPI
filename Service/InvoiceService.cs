using System.Collections.Generic;
using ParkingSystemApi.Models;
using ParkingSystemApi.Repository;

namespace ParkingSystemApi.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public Invoice CreateInvoice(Invoice invoice)
        {
            return _invoiceRepository.CreateInvoice(invoice);
        }

        public Invoice DeleteInvoice(int id)
        {
            return _invoiceRepository.DeleteInvoice(id);
        }

        public List<Invoice> GetAllInvoice()
        {
            return _invoiceRepository.GetAllInvoice();
        }

        public Invoice GetInvoiceById(int id)
        {
            return _invoiceRepository.GetInvoiceById(id);
        }

        public Invoice GetInvoiceByParkingHistory(int parkingHistoryId)
        {
            return _invoiceRepository.GetInvoiceByParkingHistory(parkingHistoryId);
        }

        public List<Invoice> GetUnpaidInvoice()
        {
            return _invoiceRepository.GetUnpaidInvoice();
        }

        public Invoice Payment(Invoice invoice)
        {
            return _invoiceRepository.Payment(invoice);
        }
    }
}
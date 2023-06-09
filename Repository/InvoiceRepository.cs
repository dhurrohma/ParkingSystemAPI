using System.Collections.Generic;
using System.Linq;
using ParkingSystemApi.Models;
using ParkingSystemApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ParkingSystemApi.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ParkingDbContext _dbContext;

        public InvoiceRepository(ParkingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Invoice CreateInvoice(Invoice invoice)
        {
            _dbContext.invoices.Add(invoice);
            _dbContext.SaveChanges();
            return invoice;
        }

        public Invoice DeleteInvoice(int id)
        {
            var invoice = _dbContext.invoices.FirstOrDefault(i => i.Id == id);
            if (invoice != null)
            {
                _dbContext.invoices.Remove(invoice);
                _dbContext.SaveChanges();
            }
            return invoice;
        }

        public List<Invoice> GetAllInvoice()
        {
            return _dbContext.invoices
                    .Include(i => i.ParkingHistory)
                    .ToList();
        }

        public Invoice GetInvoiceById(int id)
        {
            return _dbContext.invoices
                    .Include(i => i.ParkingHistory)
                    .FirstOrDefault(i => i.Id == id);
        }

        public List<Invoice> GetUnpaidInvoice()
        {
            return _dbContext.invoices
                    .Include(i => i.ParkingHistory)
                    .Where(i => i.PaidAt == null)
                    .ToList();
        }

        public Invoice GetInvoiceByParkingHistory(int parkingHistoryId)
        {
            return _dbContext.invoices
                    .Include(i => i.ParkingHistory)
                    .FirstOrDefault(i => i.ParkingHistoryId == parkingHistoryId);
        }

        public Invoice Payment(Invoice invoice)
        {
            _dbContext.invoices.Update(invoice);
            _dbContext.SaveChanges();
            return invoice;            
        }
    }
}
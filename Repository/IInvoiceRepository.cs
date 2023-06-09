using ParkingSystemApi.Models;

namespace ParkingSystemApi.Repository
{
    public interface IInvoiceRepository
    {
        Invoice CreateInvoice(Invoice invoice);
        List<Invoice> GetAllInvoice();
        Invoice GetInvoiceById(int id);
        List<Invoice> GetUnpaidInvoice();
        Invoice GetInvoiceByParkingHistory(int parkingHistoryId);
        Invoice Payment(Invoice invoice);
        Invoice DeleteInvoice(int id);
    }
}
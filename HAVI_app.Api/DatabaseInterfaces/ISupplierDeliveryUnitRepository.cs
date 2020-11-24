using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    public interface ISupplierDeliveryUnitRepository
    {
        Task<IEnumerable<SupplierDeliveryUnit>> GetSupplierDeliveryUnits();
        Task<SupplierDeliveryUnit> AddSupplierDeliveryUnit(SupplierDeliveryUnit supplierDeliveryUnit);
        Task<SupplierDeliveryUnit> UpdateSupplierDeliveryUnit(SupplierDeliveryUnit supplierDeliveryUnit);
        void DeleteSupplierDeliveryUnitAsync(int supplierDeliveryUnitId);
    }
}
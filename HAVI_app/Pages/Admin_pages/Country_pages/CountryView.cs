using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Pages.Admin_pages.Country_pages
{
    public class CountryView : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public CountryService CountryService { get; set; }

        [Inject]
        public VailedForCustomerService VailedForCustomerService { get; set; }

        [Inject]
        public CompanyCodeService CompanyCodeService { get; set; }

        [Inject]
        public SupplierDeliveryUnitService SupplierDeliveryUnitService { get; set; }

        [Inject]
        public ILOSOrderpickgroupService ILOSOrderpickgroupService { get; set; }

        [Inject]
        public PrimaryDCILOSCodeService PrimaryDCILOSCodeService { get; set; }

        [Inject]
        public VatTaxCodeService VatTaxCodeService { get; set; }

        [Inject]
        public ILOSCategoriesService ILOSCategoriesService { get; set; }

        public Country CurrentCountry;

        public int NumberOfCustomers = 0;
        public List<VailedForCustomer> Customers;
        public List<int> CustomersToDelete = new List<int>();

        public int NumberOfCodes = 0;
        public List<CompanyCode> CompanyCodes;
        public List<int> CompanyCodesToDelete = new List<int>();

        public int NumberOfUnits = 0;
        public List<SupplierDeliveryUnit> Units;
        public List<int> UnitsToDelete = new List<int>();

        public int NumberOfOrders = 0;
        public List<Ilosorderpickgroup> OrderPickGroups;
        public List<int> OrderPickGroupsToDelete = new List<int>();

        public int NumberOfPrim = 0;
        public List<PrimaryDciloscode> ILOSCodes;
        public List<int> ILOSCodesToDelete = new List<int>();

        public int NumberOfTAX = 0;
        public List<VatTaxCode> TaxCodes;
        public List<int> TaxCodesToDelete = new List<int>();

        public int NumberOfCat = 0;
        public List<Iloscategory> ILOSCategories;
        public List<int> ILOSCategoriesToDelete = new List<int>();

        protected async override Task OnInitializedAsync()
        {
            CurrentCountry = new Country();
            CurrentCountry = await CountryService.GetCountry(1);

            Customers = await VailedForCustomerService.GetVailedCustomers(1);
            if(Customers == null)
            {
                Customers = new List<VailedForCustomer>
                {
                    new VailedForCustomer() { Id = 0 }
                };
            }
            else
            {
                NumberOfCustomers = Customers.Count-1;
            }

            CompanyCodes = new List<CompanyCode>();
            CompanyCodes = await CompanyCodeService.GetCompanyCodes(CurrentCountry.Id);
            if (CompanyCodes.Count == 0)
            {
                CompanyCodes.Add(new CompanyCode());
            }
            else
            {
                NumberOfCodes = CompanyCodes.Count-1;
            }

            Units = new List<SupplierDeliveryUnit>();
            Units = await SupplierDeliveryUnitService.GetSupplierDeliveryUnits(CurrentCountry.Id);
            if (Units.Count == 0)
            {
                Units.Add(new SupplierDeliveryUnit());
            }
            else
            {
                NumberOfUnits = Units.Count-1;
            }

            OrderPickGroups = new List<Ilosorderpickgroup>();
            OrderPickGroups = await ILOSOrderpickgroupService.GetILOSOrderpickgroup(CurrentCountry.Id);
            if (OrderPickGroups.Count == 0)
            {
                OrderPickGroups.Add(new Ilosorderpickgroup());
            }
            else
            {
                NumberOfOrders = OrderPickGroups.Count-1;
            }

            ILOSCodes = new List<PrimaryDciloscode>();
            ILOSCodes = await PrimaryDCILOSCodeService.GetPrimaryDCILOSCodes(CurrentCountry.Id);
            if (ILOSCodes.Count == 0)
            {
                ILOSCodes.Add(new PrimaryDciloscode());
            }
            else
            {
                NumberOfPrim = ILOSCodes.Count-1;
            }


            TaxCodes = new List<VatTaxCode>();
            TaxCodes = await VatTaxCodeService.GetVatTaxCodes(CurrentCountry.Id);
            if (TaxCodes.Count == 0)
            {
                TaxCodes.Add(new VatTaxCode());
            }
            else
            {
                NumberOfTAX = TaxCodes.Count-1;
            }

            ILOSCategories = new List<Iloscategory>();
            ILOSCategories = await ILOSCategoriesService.GetILOSCategories(CurrentCountry.Id);
            if (ILOSCategories.Count == 0)
            {
                ILOSCategories.Add(new Iloscategory());
            }
            else
            {
                NumberOfCat = ILOSCategories.Count-1;
            }
        }

        public void AddCustomer()
        {
            Customers.Add(new VailedForCustomer() { Id = 0 });
            NumberOfCustomers++;
        }

        public void RemoveCustomer(int toRemove)
        {
            Console.WriteLine(toRemove);
            if(Customers[toRemove - 1].Id != 0)
            {
                CustomersToDelete.Add(Customers[toRemove - 1].Id);
            }
            Customers.RemoveAt(toRemove - 1);
            NumberOfCustomers--;
        }

        public void UpdateCustomers()
        {
            foreach (int delete in CustomersToDelete)
            {
                VailedForCustomerService.DeleteVailedForCustomer(delete);
            }

            foreach (VailedForCustomer customer in Customers)
            {
                if (customer.Id == 0)
                {
                    VailedForCustomerService.CreateVailedForCustomer(customer);
                }
                else
                {
                    VailedForCustomerService.UpdateVailedForCustomer(customer.Id, customer);
                }
            }
        }
        public void AddCode()
        {
            CompanyCodes.Add(new CompanyCode() { Id = 0 });
            NumberOfCodes++;
        }

        public void RemoveCode(int toRemove)
        {
            if(CompanyCodes[toRemove - 1].Id != 0)
            {
                CompanyCodesToDelete.Add(CompanyCodes[toRemove - 1].Id);
            }
            CompanyCodes.RemoveAt(toRemove - 1);
            NumberOfCodes--;
        }
        public void UpdateCompany()
        {
            foreach (int delete in CompanyCodesToDelete)
            {
                CompanyCodeService.DeleteCompanyCode(delete);
            }

            foreach (CompanyCode code in CompanyCodes)
            {
                if (code.Id == 0)
                {
                    CompanyCodeService.CreateCompanyCode(code);
                }
                else
                {
                    CompanyCodeService.UpdateCompanyCode(code.Id, code);
                }
            }
        }

        public void AddUnit()
        {
            Units.Add(new SupplierDeliveryUnit() { Id = 0 });
            NumberOfUnits++;
        }

        public void RemoveUnit(int toRemove)
        {
            if(Units[toRemove - 1].Id != 0)
            {
                UnitsToDelete.Add(Units[toRemove - 1].Id);
            }
            Units.RemoveAt(toRemove - 1);
            NumberOfUnits--;
        }

        public void UpdateUnits()
        {
            foreach (int delete in UnitsToDelete)
            {
                SupplierDeliveryUnitService.DeleteSupplierDeliveryUnit(delete);
            }

            foreach (SupplierDeliveryUnit unit in Units)
            {
                if (unit.Id == 0)
                {
                    SupplierDeliveryUnitService.CreateSupplierDeliveryUnit(unit);
                }
                else
                {
                    SupplierDeliveryUnitService.UpdateSupplierDeliveryUnit(unit.Id, unit);
                }
            }
        }

        public void AddOrder()
        {
            OrderPickGroups.Add(new Ilosorderpickgroup() { Id = 0 });
            NumberOfOrders++;
        }

        public void RemoveOrder(int toRemove)
        {
            if(OrderPickGroups[toRemove - 1].Id != 0)
            {
                OrderPickGroupsToDelete.Add(OrderPickGroups[toRemove - 1].Id);
            }
            OrderPickGroups.RemoveAt(toRemove - 1);
            NumberOfOrders--;
        }
        public void UpdateOrderpickgroup()
        {
            foreach (int delete in OrderPickGroupsToDelete)
            {
                ILOSOrderpickgroupService.DeleteILOSOrderpickgroup(delete);
            }

            foreach (Ilosorderpickgroup group in OrderPickGroups)
            {
                if (group.Id == 0)
                {
                    ILOSOrderpickgroupService.CreateILOSOrderpickgroup(group);
                }
                else
                {
                    ILOSOrderpickgroupService.UpdateILOSOrderpickgroup(group.Id, group);
                }
            }
        }

        public void AddPrim()
        {
            ILOSCodes.Add(new PrimaryDciloscode() { Id = 0 });
            NumberOfPrim++;
        }

        public void RemovePrim(int toRemove)
        {
            if(ILOSCodes[toRemove-1].Id != 0)
            {
                ILOSCodesToDelete.Add(ILOSCodes[toRemove - 1].Id);
            }
            ILOSCodes.RemoveAt(toRemove - 1);
            NumberOfCodes--;
        }

        public void UpdateCodes()
        {
            foreach (int delete in ILOSCodesToDelete)
            {
                PrimaryDCILOSCodeService.DeletePrimaryDCILOSCode(delete);
            }

            foreach (PrimaryDciloscode code in ILOSCodes)
            {
                if (code.Id == 0)
                {
                    PrimaryDCILOSCodeService.CreatePrimaryDCILOSCode(code);
                }
                else
                {
                    PrimaryDCILOSCodeService.UpdatePrimaryDCILOSCode(code.Id, code);
                }
            }
        }

        public void AddTAX()
        {
            TaxCodes.Add(new VatTaxCode() { Id = 0 });
            NumberOfTAX++;
        }

        public void RemoveTAX(int toRemove)
        {
            if(TaxCodes[toRemove-1].Id != 0)
            {
                TaxCodesToDelete.Add(TaxCodes[toRemove - 1].Id);
            }
            TaxCodes.RemoveAt(toRemove - 1);
            NumberOfTAX--;
        }

        public void UpdateTaxCodes()
        {
            foreach (int delete in TaxCodesToDelete)
            {
                VatTaxCodeService.DeleteVatTaxCode(delete);
            }

            foreach (VatTaxCode code in TaxCodes)
            {
                if (code.Id == 0)
                {
                    VatTaxCodeService.CreateVatTaxCode(code);
                }
                else
                {
                    VatTaxCodeService.UpdateVatTaxCode(code.Id, code);
                }
            }
        }

        public void AddCat()
        {
            ILOSCategories.Add(new Iloscategory() { Id = 0 });
            NumberOfCat++;
        }

        public void RemoveCat(int toRemove)
        {
            if(ILOSCategories[toRemove-1].Id != 0)
            {
                ILOSCategoriesToDelete.Add(ILOSCategories[toRemove - 1].Id);
            }
            ILOSCategories.RemoveAt(toRemove - 1);
            NumberOfCat--;
        }

        public void UpdateCat()
        {
            foreach(int delete in ILOSCategoriesToDelete)
            {
                ILOSCategoriesService.DeleteILOSCategory(delete);
            }

            foreach(Iloscategory category in ILOSCategories)
            {
                if(category.Id == 0)
                {
                    ILOSCategoriesService.CreateILOSCategory(category);
                }
                else
                {
                    ILOSCategoriesService.UpdateILOSCategory(category.Id, category);
                }
            }
        }

        public void SaveChangesForCountry()
        {
            UpdateCat();
            UpdateCodes();
            UpdateCompany();
            UpdateCustomers();
            UpdateOrderpickgroup();
            UpdateTaxCodes();
            UpdateUnits();
            NavigationManager.NavigateTo("/country_view", true);
        }
    }
}

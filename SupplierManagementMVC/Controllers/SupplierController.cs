using SupplierManagementMVC.Models;
using SupplierManagementMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SupplierManagementMVC.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            HttpResponseMessage responce = CallsFromApi.client.GetAsync("Supplier").Result;
            IEnumerable<Supplier> suppliers = responce.Content.ReadAsAsync<IEnumerable<Supplier>>().Result;
            return View(suppliers);
        }
        public ActionResult CreateSupplier()
        {
            HttpResponseMessage responceCategory = CallsFromApi.client.GetAsync("SupplierCategory").Result;
            IEnumerable<SupplierCategory> supplierCategories = responceCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>().Result;
            HttpResponseMessage responceCountry = CallsFromApi.client.GetAsync("SupplierCountry").Result;
            IEnumerable<SupplierCountry> supplierCountries = responceCountry.Content.ReadAsAsync<IEnumerable<SupplierCountry>>().Result;
            var supplierCategoriesNew = supplierCategories;
            var supplierCountriesNew = supplierCountries;
            var viewModel = new SupplierCategoryCountryViewModel()
            {
                Supplier = new Supplier(),
                SupplierCategories = supplierCategoriesNew,
                SupplierCountries = supplierCountriesNew
            };
            return View("CreateSupplierForm", viewModel);
            //return View();
        }
        [HttpPost]
        public ActionResult SaveSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                HttpResponseMessage responceCategory = CallsFromApi.client.GetAsync("SupplierCategory").Result;
                IEnumerable<SupplierCategory> supplierCategories = responceCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>().Result;
                HttpResponseMessage responceCountry = CallsFromApi.client.GetAsync("SupplierCountry").Result;
                IEnumerable<SupplierCountry> supplierCountries = responceCountry.Content.ReadAsAsync<IEnumerable<SupplierCountry>>().Result;
                var supplierCategoriesNew = supplierCategories;
                var supplierCountriesNew = supplierCountries;
                var viewModel = new SupplierCategoryCountryViewModel()
                {
                    Supplier = new Supplier(),
                    SupplierCategories = supplierCategoriesNew,
                    SupplierCountries = supplierCountriesNew
                };
                return View("CreateSupplierForm", viewModel);
            }
            else
            {
                HttpResponseMessage response = CallsFromApi.client.PostAsJsonAsync("Supplier", supplier).Result;
                return RedirectToAction("Index", "Supplier");
            }
        }
        public ActionResult SupplierDetails(int id)
        {
            HttpResponseMessage response = CallsFromApi.client.GetAsync($"Supplier/{id}").Result;
            Supplier supplier = response.Content.ReadAsAsync<Supplier>().Result;
            HttpResponseMessage responceCategory = CallsFromApi.client.GetAsync("SupplierCategory").Result;
            IEnumerable<SupplierCategory> supplierCategories = responceCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>().Result;
            HttpResponseMessage responceCountry = CallsFromApi.client.GetAsync("SupplierCountry").Result;
            IEnumerable<SupplierCountry> supplierCountries = responceCountry.Content.ReadAsAsync<IEnumerable<SupplierCountry>>().Result;
            var supplierCategoriesNew = supplierCategories;
            var supplierCountriesNew = supplierCountries;
            var viewModel = new SupplierCategoryCountryViewModel()
            {
                Supplier = supplier,
                SupplierCategories = supplierCategoriesNew,
                SupplierCountries = supplierCountriesNew
            };
            return View("SupplierDetails",viewModel);
        }
        public ActionResult EditSupplier(int id)
        {
            HttpResponseMessage response = CallsFromApi.client.GetAsync($"Supplier/{id}").Result;
            Supplier supplier = response.Content.ReadAsAsync<Supplier>().Result;
            HttpResponseMessage responceCategory = CallsFromApi.client.GetAsync("SupplierCategory").Result;
            IEnumerable<SupplierCategory> supplierCategories = responceCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>().Result;
            HttpResponseMessage responceCountry = CallsFromApi.client.GetAsync("SupplierCountry").Result;
            IEnumerable<SupplierCountry> supplierCountries = responceCountry.Content.ReadAsAsync<IEnumerable<SupplierCountry>>().Result;
            var supplierCategoriesNew = supplierCategories;
            var supplierCountriesNew = supplierCountries;
            var viewModel = new SupplierCategoryCountryViewModel()
            {
                Supplier = supplier,
                SupplierCategories = supplierCategoriesNew,
                SupplierCountries = supplierCountriesNew
            };
            return View("EditSupplier", viewModel);
        }
        [HttpPost]
        public ActionResult SaveEditSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                HttpResponseMessage responceCategory = CallsFromApi.client.GetAsync("SupplierCategory").Result;
                IEnumerable<SupplierCategory> supplierCategories = responceCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>().Result;
                HttpResponseMessage responceCountry = CallsFromApi.client.GetAsync("SupplierCountry").Result;
                IEnumerable<SupplierCountry> supplierCountries = responceCountry.Content.ReadAsAsync<IEnumerable<SupplierCountry>>().Result;
                var supplierCategoriesNew = supplierCategories;
                var supplierCountriesNew = supplierCountries;
                var viewModel = new SupplierCategoryCountryViewModel()
                {
                    Supplier = new Supplier(),
                    SupplierCategories = supplierCategoriesNew,
                    SupplierCountries = supplierCountriesNew
                };
                return View("EditSupplier", viewModel);
            }
            else
            {
                HttpResponseMessage response = CallsFromApi.client.PutAsJsonAsync($"Supplier/{supplier.ID}", supplier).Result;
                return RedirectToAction("Index", "Supplier");
            }
        }
    }
}
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
        public ActionResult Index(string supplierCategory)
        {
            HttpResponseMessage responce = CallsFromApi.client.GetAsync("Supplier").Result;
            IEnumerable<Supplier> suppliers = responce.Content.ReadAsAsync<IEnumerable<Supplier>>().Result;

            HttpResponseMessage responceCategory = CallsFromApi.client.GetAsync("SupplierCategory").Result;
            IEnumerable<SupplierCategory> supplierCategories = responceCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>().Result;

            HttpResponseMessage responceCountry = CallsFromApi.client.GetAsync("SupplierCountry").Result;
            IEnumerable<SupplierCountry> supplierCountries = responceCountry.Content.ReadAsAsync<IEnumerable<SupplierCountry>>().Result;

            var supplierCategoryFilter = new List<string>();
            var supplierCategoryDb = supplierCategories.OrderByDescending(s => s.CategoryName).Select(sup => sup.CategoryName);
            supplierCategoryFilter.AddRange(supplierCategoryDb.Distinct());
            ViewBag.supplierCategory = new SelectList(supplierCategoryFilter);

            if (!string.IsNullOrEmpty(supplierCategory))
            {
                suppliers = suppliers.Where(s => s.SupplierCategory.CategoryName == supplierCategory);
            }
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
        //Delete supplier request to api
        public ActionResult DeleteSupplier(int? id)
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
            return View(viewModel);
        }
        [HttpPost,ActionName("DeleteSupplier")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmationForDelete(int id)
        {
            HttpResponseMessage response = CallsFromApi.client.DeleteAsync($"Supplier/{id}").Result;
            return RedirectToAction("Index", "Supplier");
        }
    }
}
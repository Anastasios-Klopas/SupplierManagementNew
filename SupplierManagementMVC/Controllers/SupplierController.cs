using SupplierManagementMVC.Models;
using SupplierManagementMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SupplierManagementMVC.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public async Task<ActionResult> Index(string supplierCategory)
        {
            try
            {
                HttpResponseMessage response = await CallsFromApi.client.GetAsync("Supplier");
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                IEnumerable<Supplier> suppliers = await response.Content.ReadAsAsync<IEnumerable<Supplier>>();

                HttpResponseMessage responseCategory = await CallsFromApi.client.GetAsync("SupplierCategory");
                if (responseCategory.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await responseCategory.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                IEnumerable<SupplierCategory> supplierCategories = await responseCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>();

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
            catch (HttpException ex)
            {
                ViewBag.Message = ex.ErrorCode;

                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;

                return View("Error");
            }
        }
        public async Task<ActionResult> CreateSupplier()
        {
            try
            {
                HttpResponseMessage responseCategory = await CallsFromApi.client.GetAsync("SupplierCategory");
                if (responseCategory.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await responseCategory.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                IEnumerable<SupplierCategory> supplierCategories = await responseCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>();

                HttpResponseMessage responseCountry = await CallsFromApi.client.GetAsync("SupplierCountry");
                if (responseCountry.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await responseCountry.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                IEnumerable<SupplierCountry> supplierCountries = await responseCountry.Content.ReadAsAsync<IEnumerable<SupplierCountry>>();

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
            catch (HttpException ex)
            {
                ViewBag.Message = ex.ErrorCode;

                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;

                return View("Error");
            }
        }
        [HttpPost]
        public async Task<ActionResult> SaveSupplier(Supplier supplier)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    HttpResponseMessage responseCategory = await CallsFromApi.client.GetAsync("SupplierCategory");
                    if (responseCategory.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        string errorMessage = await responseCategory.Content.ReadAsStringAsync();
                        ViewBag.Message = errorMessage;

                        return View("Error");
                    }
                    IEnumerable<SupplierCategory> supplierCategories = await responseCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>();

                    HttpResponseMessage responseCountry = await CallsFromApi.client.GetAsync("SupplierCountry");
                    if (responseCountry.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        string errorMessage = await responseCountry.Content.ReadAsStringAsync();
                        ViewBag.Message = errorMessage;

                        return View("Error");
                    }
                    IEnumerable<SupplierCountry> supplierCountries = await responseCountry.Content.ReadAsAsync<IEnumerable<SupplierCountry>>();

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
                HttpResponseMessage response = await CallsFromApi.client.PostAsJsonAsync("Supplier", supplier);
                if (response.StatusCode != System.Net.HttpStatusCode.Created)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }

                return RedirectToAction("Index", "Supplier");
            }
            catch (HttpException ex)
            {
                ViewBag.Message = ex.ErrorCode;

                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;

                return View("Error");
            }

        }
        public async Task<ActionResult> SupplierDetails(int id)
        {
            try
            {
                HttpResponseMessage response = await CallsFromApi.client.GetAsync($"Supplier/{id}");
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                Supplier supplier = await response.Content.ReadAsAsync<Supplier>();

                HttpResponseMessage responseCategory = await CallsFromApi.client.GetAsync("SupplierCategory");
                if (responseCategory.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await responseCategory.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                IEnumerable<SupplierCategory> supplierCategories = await responseCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>();

                HttpResponseMessage responseCountry = await CallsFromApi.client.GetAsync("SupplierCountry");
                if (responseCountry.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await responseCountry.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                IEnumerable<SupplierCountry> supplierCountries = await responseCountry.Content.ReadAsAsync<IEnumerable<SupplierCountry>>();

                var supplierCategoriesNew = supplierCategories;
                var supplierCountriesNew = supplierCountries;
                var viewModel = new SupplierCategoryCountryViewModel()
                {
                    Supplier = supplier,
                    SupplierCategories = supplierCategoriesNew,
                    SupplierCountries = supplierCountriesNew
                };

                return View("SupplierDetails", viewModel);
            }
            catch (HttpException ex)
            {
                ViewBag.Message = ex.ErrorCode;

                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;

                return View("Error");
            }

        }
        public async Task<ActionResult> EditSupplier(int id)
        {
            try
            {
                var a = id;
                HttpResponseMessage response = await CallsFromApi.client.GetAsync($"Supplier/{id}");
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                Supplier supplier = await response.Content.ReadAsAsync<Supplier>();

                HttpResponseMessage responseCategory = await CallsFromApi.client.GetAsync("SupplierCategory");
                if (responseCategory.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await responseCategory.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                IEnumerable<SupplierCategory> supplierCategories = await responseCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>();

                HttpResponseMessage responseCountry = await CallsFromApi.client.GetAsync("SupplierCountry");
                if (responseCountry.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await responseCountry.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                IEnumerable<SupplierCountry> supplierCountries = await responseCountry.Content.ReadAsAsync<IEnumerable<SupplierCountry>>();

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
            catch (HttpException ex)
            {
                ViewBag.Message = ex.ErrorCode;

                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;

                return View("Error");
            }
        }
        [HttpPost]
        public async Task<ActionResult> SaveEditSupplier(Supplier supplier)
        {
            try
            {
                var b = supplier.ID;
                var a = ModelState.IsValid;
                if (!ModelState.IsValid)
                {
                    HttpResponseMessage responseCategory = await CallsFromApi.client.GetAsync("SupplierCategory");
                    if (responseCategory.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        string errorMessage = await responseCategory.Content.ReadAsStringAsync();
                        ViewBag.Message = errorMessage;

                        return View("Error");
                    }
                    IEnumerable<SupplierCategory> supplierCategories = await responseCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>();

                    HttpResponseMessage responseCountry = await CallsFromApi.client.GetAsync("SupplierCountry");
                    if (responseCountry.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        string errorMessage = await responseCountry.Content.ReadAsStringAsync();
                        ViewBag.Message = errorMessage;

                        return View("Error");
                    }
                    IEnumerable<SupplierCountry> supplierCountries = await responseCountry.Content.ReadAsAsync<IEnumerable<SupplierCountry>>();

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

                HttpResponseMessage response = await CallsFromApi.client.PutAsJsonAsync($"Supplier/{supplier.ID}", supplier);
                if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }

                return RedirectToAction("Index", "Supplier");
            }
            catch (HttpException ex)
            {
                ViewBag.Message = ex.ErrorCode;

                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;

                return View("Error");
            }
        }
        //Delete supplier request to api
        public async Task<ActionResult> DeleteSupplier(int? id)
        {
            try
            {
                HttpResponseMessage response = await CallsFromApi.client.GetAsync($"Supplier/{id}");
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                Supplier supplier = await response.Content.ReadAsAsync<Supplier>();

                HttpResponseMessage responseCategory = await CallsFromApi.client.GetAsync("SupplierCategory");
                if (responseCategory.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await responseCategory.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                IEnumerable<SupplierCategory> supplierCategories = await responseCategory.Content.ReadAsAsync<IEnumerable<SupplierCategory>>();

                HttpResponseMessage responseCountry = await CallsFromApi.client.GetAsync("SupplierCountry");
                if (responseCountry.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await responseCountry.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                IEnumerable<SupplierCountry> supplierCountries = await responseCountry.Content.ReadAsAsync<IEnumerable<SupplierCountry>>();

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
            catch (HttpException ex)
            {
                ViewBag.Message = ex.ErrorCode;

                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;

                return View("Error");
            }
        }
        [HttpPost, ActionName("DeleteSupplier")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmationForDelete(int id)
        {
            try
            {
                HttpResponseMessage response = await CallsFromApi.client.DeleteAsync($"Supplier/{id}");
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = errorMessage;

                    return View("Error");
                }
                return RedirectToAction("Index", "Supplier");
            }
            catch (HttpException ex)
            {
                ViewBag.Message = ex.ErrorCode;

                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.InnerException.Message;

                return View("Error");
            }
        }
    }
}
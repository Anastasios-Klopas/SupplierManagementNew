using SupplierManagementAPI.DAL;
using SupplierManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SupplierManagementAPI.Controllers
{
    public class SupplierCategoryController : ApiController
    {
        private SupplierManagementDbContext db = new SupplierManagementDbContext();
        public IQueryable<SupplierCategory> GetAllSuppliers()
        {
            return db.SupplierCategories;
        }
    }
}

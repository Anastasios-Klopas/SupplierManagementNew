using SupplierManagementAPI.DAL;
using SupplierManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace SupplierManagementAPI.Controllers
{
    public class SupplierController : ApiController
    {
        private SupplierManagementDbContext db = new SupplierManagementDbContext();
        // all suppliers
        public IQueryable<Supplier> GetAllSuppliers()
        {
            return db.Suppliers.Include(s => s.SupplierCategory).Include(sup => sup.SupplierCountry);
        }
        // supplier details
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult GetSupplier(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }
        //create supplier
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult PostSupplier(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = supplier.ID }, supplier);
        }
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupplier(int id, Supplier supplier)
        {
            if (id != supplier.ID)
            {
                return BadRequest();
            }
            //sto mvc an einai modified dld an exoun ginei allages
            //db.Entry(supplier).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        private bool SupplierExists(int id)
        {
            return db.Suppliers.Count(e => e.ID == id) > 0;
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}

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
using System.Net.Mail;
using System.Web;
using System.Threading.Tasks;

namespace SupplierManagementAPI.Controllers
{
    public class SupplierController : ApiController
    {
        private SupplierManagementDbContext db = new SupplierManagementDbContext();
        // all suppliers
        public IQueryable<Supplier> GetAllSuppliers()
        {
            try
            {
                return db.Suppliers.Include(s => s.SupplierCategory).Include(sup => sup.SupplierCountry);
            }
            catch (Exception)
            {
                throw;
            }
        }
        // supplier details
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult GetSupplier(int id)
        {
            try
            {
                Supplier supplier = db.Suppliers.Find(id);
                if (supplier == null)
                {
                    return NotFound();
                }

                return Ok(supplier);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //create supplier
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult PostSupplier(Supplier supplier)
        {
            try
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                //Welcome Email
                //WelcomeEmail(supplier.SupplierName, supplier.Email);
                return CreatedAtRoute("DefaultApi", new { id = supplier.ID }, supplier);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //update supplier
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupplier(int id, Supplier supplier)
        {
            try
            {
                if (id != supplier.ID)
                {
                    return BadRequest();
                }
                db.Entry(supplier).State = EntityState.Modified;
                try
                {
                    var a = supplier;
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
            catch (Exception)
            {
                throw;
            }
        }
        //Delete Supplier
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult DeleteSupplier(int id)
        {
            try
            {
                Supplier supplier = db.Suppliers.Find(id);
                if (supplier == null)
                {
                    return NotFound();
                }

                db.Suppliers.Remove(supplier);
                db.SaveChanges();

                return Ok(supplier);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool SupplierExists(int id)
        {
            try
            {
                return db.Suppliers.Count(e => e.ID == id) > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        public static void WelcomeEmail(string supplierName, string supplierEmail)
        {
            try
            {
                MailMessage mailMessage = new MailMessage("", supplierEmail);
                mailMessage.Subject = "Welcome to our Company";
                mailMessage.Body = $"Welcome to our Company {supplierName}, we look forward to having a good cooperation";
                SmtpClient client = new SmtpClient();
                client.Send(mailMessage);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

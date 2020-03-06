using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ACEntrepidusTest.Models;
using System.Globalization;
using ACEntrepidusTest.Extensions;
using PagedList;
using NLog;

namespace ACEntrepidusTest.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        Logger logger = LogManager.GetCurrentClassLogger();

        //TODO Validar entrada de fechas (Alfredo Castro)
        [AcceptVerbs("Get", "Post")]
        public JsonResult NotAfterToday(string date)
        {
            DateTime dDate;
            bool isValid = DateTime.TryParseExact(date, "dd/M/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out dDate) && dDate.Date <= DateTime.Now.Date;
            return Json(isValid);
        }

        /// <summary>
        /// Get Action: Lista de Empleados (Alfredo Castro)
        /// </summary>
        /// <param name="search"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<ActionResult> Index(string search, DateTime? start, DateTime? end, int? page, int? pageSize)
        {
            try
            {
                var query = db.Employees.AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.RemoveDiacritics().ToUpper();
                    //TODO Búsqueda diacrítica
                    query = query.Where(x => 
                                    x.DocumentId.Contains(search) || //x.DocumentId.ContainsDiac(search) ||
                                    x.FullName.Contains(search) || //x.FullName.ContainsDiac(search) ||
                                    x.EMail.Contains(search) || //x.EMail.ContainsDiac(search) ||
                                    x.Address.Contains(search)); //x.DocumeAddressntId.ContainsDiac(search) ||
                }
                if (start.HasValue && end.HasValue)
                {
                    query = query.Where(x => x.ContractDate.Date >= start.Value.Date && x.ContractDate.Date <= end.Value.Date);
                }

                int pageSizeNumber = pageSize ?? 5;
                int pageNumber = page ?? 1;
                query = query.OrderBy(x => x.DocumentId).ThenBy(x => x.FullName);

                ViewBag.search = search;
                ViewBag.start = start;
                ViewBag.end = end;
                ViewBag.pageSize = pageSizeNumber;

                if (HttpContext.Request.IsAjaxRequest())
                {
                    return PartialView("_Index", query.ToPagedList(pageNumber, pageSizeNumber));
                }
                return View(query.ToPagedList(pageNumber, pageSizeNumber));

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
            return View();
        }

        /// <summary>
        /// Get Action: Detalle de un Empleado (Alfredo Castro)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        /// <summary>
        /// Get Action: Agregar un nuevo empleado (Alfredo Castro)
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Action: Agregar un nuevo empleado (Alfredo Castro)
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DocumentId,FullName,Address,EMail,PhoneNumber,ContractDate,BirthDate,IsFreelance,PayRate")] Employee employee)
        {
            try
            {
                if (!employee.IsFreelance)
                {
                    ModelState.Remove("PayRate");
                    employee.PayRate = 0;
                }

                //La cédula se guarda en mayúsculas
                employee.DocumentId = employee.DocumentId.ToUpper();
                //No puede existir dos empleados con la misma Cédula
                if (db.Employees.Any(x => x.DocumentId.Equals(employee.DocumentId)))
                {
                    ModelState.AddModelError("DocumentId", "Ya existe un empleado con esta Cédula.");
                }

                if (ModelState.IsValid)
                {
                    db.Employees.Add(employee);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                ModelState.AddModelError(string.Empty, "No fue posible guardar los cambios. Intente de nuevo o contacte al administrador.");
            }

            return View(employee);
        }

        /// <summary>
        /// Get Action: Modificar un empleado (Alfredo Castro)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        /// <summary>
        /// Post Action: Modificar un empleado (Alfredo Castro)
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DocumentId,FullName,Address,EMail,PhoneNumber,ContractDate,BirthDate,IsFreelance,PayRate")] Employee employee)
        {
            try
            {
                if (!employee.IsFreelance)
                {
                    ModelState.Remove("PayRate");
                    employee.PayRate = 0;
                }

                //La cédula se guarda en mayúsculas
                employee.DocumentId = employee.DocumentId.ToUpper();
                //No puede existir dos empleados con la misma Cédula
                if (db.Employees.Any(x => x.Id != employee.Id && x.DocumentId.Equals(employee.DocumentId)))
                {
                    ModelState.AddModelError("DocumentId", "Ya existe un empleado con esta Cédula.");
                }

                if (ModelState.IsValid)
                {
                    db.Entry(employee).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                ModelState.AddModelError(string.Empty, "No fue posible guardar los cambios. Intente de nuevo o contacte al administrador.");
            }
            return View(employee);
        }

        /// <summary>
        /// Get Action: Eliminar un empleado (Alfredo Castro)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        /// <summary>
        /// Post Action: Eliminar un empleado (Alfredo Castro)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

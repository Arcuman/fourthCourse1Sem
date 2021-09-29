using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml;
using System.Xml.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  
    public class StudentController : ApiController
    {

        private Context _context = new Context();


        [HttpGet]
        [ResponseType(typeof(Student))]
        public object GetStudent(int id)
        {
            Student student = _context.Students.Find(id);
            if (student == null)
                return Content(HttpStatusCode.NotFound, new HATEOS("/api/error/404", "error.404"));

            return Content(HttpStatusCode.OK, new { student, links = new HATEOS("/api/student/" + id, "self") });
        }

        [HttpGet]
        public IHttpActionResult Get(
                int limit = 2,
                int offset = 0,
                int minId = 0,
                int maxId = 100,
                string sort = "ID",
                string columns = "id, name, phone",
                string like = null,
                string globalLike = null,
                String type = "json")
        {
            var students = _context.Students.Where(x => x.Id > 0).AsNoTracking();

            if (sort.ToLower() == "name")
            {
                students = students.OrderBy(prop => prop.Name);
            }
            else if (sort.ToLower() == "id")
            {
                students = students.OrderBy(prop => prop.Id);
            }

            students = students
               .Where(prop => prop.Id >= minId && prop.Id <= maxId)
               .Skip(offset)
               .Take(limit);

            if (like != null)
            {
                students = students.Where(prop => prop.Name.ToLower().Contains(like.ToLower()));
            }

            if (globalLike != null)
            {
                students = students.Where(prop => (prop.Name + prop.Id.ToString() + prop.Phone).ToLower().Contains(globalLike.ToLower()));
            }

            var res = new List<dynamic>();
            var xElements = new List<XElement>();
            foreach (var item in students)
            {
                if (type.ToLower() == "xml")
                {
                    var xHref = new XElement("href", $"/api/student/{item.Id}");
                    var linksXml = new List<XElement>();
                    linksXml.Add(xHref);
                    var xId = new XAttribute("id", item.Id);
                    var xName = new XAttribute("name", item.Name);
                    var xPhone = new XAttribute("phone", item.Phone);
                    var xUser = new XElement("student", linksXml);
                    if (columns.Contains("id"))
                    {
                        xUser.Add(xId);
                    }
                    if (columns.Contains("name"))
                    {
                        xUser.Add(xName);
                    }
                    if (columns.Contains("phone"))
                    {
                        xUser.Add(xPhone);
                    }
                    xElements.Add(xUser);
                }
                else
                {
                    dynamic temp = new ExpandoObject();
                    if (columns.Contains("id"))
                    {
                        temp.Id = item.Id;
                    }
                    if (columns.Contains("name"))
                    {
                        temp.Name = item.Name;
                    }
                    if (columns.Contains("phone"))
                    {
                        temp.Phone = item.Phone;
                    }
                    temp.Links = new
                    {
                        href = $"/api/student/{item.Id}",
                        rel = "User",
                    };
                    res.Add(temp);
                }
            }

            switch (type)
            {
                case "xml":
                    return Content(HttpStatusCode.OK, xElements, Configuration.Formatters.XmlFormatter);
                case "json":
                default:
                    return Content(HttpStatusCode.OK, res, Configuration.Formatters.JsonFormatter);
            }
        }

        [HttpPost]
        [ResponseType(typeof(Student))]
        public object PostStudent(Student student)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, new { ModelState, links = new HATEOS("/api/error/400", "error.400") });

            _context.Students.Add(student);
            _context.SaveChanges();

            return Content(HttpStatusCode.Created, new { student, links = new HATEOS("/api/student/" + student.Id, "self") });
        }

        // PUT api/values/5
        [HttpPut]
        [ResponseType(typeof(Student))]
        public object PutStudent(int id, Student student)
        {
            student.Id = id;

            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, new { ModelState, links = new HATEOS("/api/error/400", "error.400") });
            }
            try
            {
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
                return Content(HttpStatusCode.OK, new { student, links = new HATEOS("/api/Student/" + student.Id, "self") });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return Content(HttpStatusCode.NotFound, new HATEOS("/api/Error/404", "error.404"));
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpDelete]
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = _context.Students.Find(id);
            if (student == null)
                return Content(HttpStatusCode.NotFound, new { links = new HATEOS("/api/error/404", "error.404") });

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Content(HttpStatusCode.NoContent, new { links = new HATEOS("/api/student/" + id, "self") });
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Count(x => x.Id == id) > 0;
        }
    }
}

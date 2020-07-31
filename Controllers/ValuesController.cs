using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPractice.DAL;
using WebApiPractice.Models;

namespace WebApiPractice.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private QuoteContext db = new QuoteContext();
        // GET api/values
        public IEnumerable<Quote> Get()
        {
            var stuff = db.Quotes.ToList();
            return stuff;
        }

        // GET api/values/5
        public IEnumerable<Quote> Get(int id)
        {
            var result = new List<Quote>();
            var stuff = db.Quotes.Find(id.ToString());
            result.Add(stuff);
            return result;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        public string Put(int id, [FromBody]Quote value)
        {
            string msg = "";
            try
            {
                var rec = db.Quotes.Find(id.ToString());

                if (rec == null)//do insert
                {
                    db.Quotes.Add(value);
                    db.SaveChanges();
                    msg = "Insertion complete!";
                    return msg;
                }
                else//do update
                {
                    rec.QuoteID = value.QuoteID;
                    rec.QuoteType = value.QuoteType;
                    rec.Contact = value.Contact;
                    rec.Task = value.Task;
                    rec.DueDate = value.DueDate;
                    rec.TaskType = value.TaskType;
                    db.SaveChanges();
                    msg = "Update complete!";
                    return msg;
                }
            }
            catch (Exception e)
            {
                msg = "BAD:" + e.Message;
                return msg;
            }
            
        }

        // DELETE api/values/5
        public string Delete(int id)//removes a quote
        {
            try 
            {
                var del = db.Quotes.Find(id.ToString());
                db.Quotes.Remove(del);
                db.SaveChanges();
                var msg = "Deleted!";
                return msg;
            }
            catch(Exception e)
            {
                var msg = "Deletion Failed!" + e.Message.ToString();
                return msg;
            }
            
        
        }
    }
}

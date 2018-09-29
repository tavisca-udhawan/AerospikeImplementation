using AerospikeWebApi.DataAccess;
using AerospikeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AerospikeWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET: api/Values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Values/5
        public string Get(int id)
        {

            return "value";
        }

        // POST: api/Values
        [HttpPost]
        public List<Data> Post([FromBody]List<long> id)
        {
            Tweet obj = new Tweet();
            return obj.getData(id);
        }

        // PUT: api/Values/5
        [HttpPut]
        public string Put([FromBody] Data data)
        {
            Tweet obj = new Tweet();
            bool result = obj.PutData(data);
            if (result == true)
                return "Data Updated Successfully";
            else
                return "Not Successfully Updated";
        }

        // DELETE: api/Values/5
        [HttpDelete]
        public string Delete([FromBody]List<long> id)
        {
            Tweet obj = new Tweet();
            bool result=obj.DeleteData(id);
            if (result == true)
                return "Data Deleted Successfully from database";
            else
                return "Not Successfully Deleted";
        }
    }
}

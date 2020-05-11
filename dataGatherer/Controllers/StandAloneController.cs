using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using dataGatherer.Models;
using dataGatherer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dataGatherer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandAloneController : ControllerBase
    {
        private readonly RepoShield _repo;
        private HttpClient client = new HttpClient();

        public StandAloneController(RepoShield repo)
        {
            _repo = repo;
        }

        [HttpPost("post")]
        public ActionResult DumpResults([FromBody]Model model)
        {
            try
            {
                _repo.Push(model);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
            return new OkObjectResult(Ok());
        }

        [HttpPost("post/syncfusion")]
        public ActionResult DumpSyncResults([FromBody]SyncModelStore model)
        {
            try
            {
                _repo.Push(model);
            }
            catch (Exception)
            {

                throw;
            }
            return new OkObjectResult(Ok());
        }

        [HttpGet]
        public ActionResult<IEnumerable<Model>> GetAll()
        {
            return new OkObjectResult(_repo.GetAll());
        }

        [HttpGet("fetchData/{index}")]
        public async Task<ActionResult<SyncModel>> GetData(int index)
        {
            string req = _repo.GetDataUri(index);
            int loopcount = 1;
            while (req == null)
            {
                req = _repo.GetDataUri(index + loopcount);
                loopcount++;
            }
            Uri requestString = new Uri(req);
            HttpResponseMessage message = new HttpResponseMessage();
            SyncModel model = new SyncModel();
            try
            {
                message = await client.GetAsync(requestString);
                message.EnsureSuccessStatusCode();
                string body = await message.Content.ReadAsStringAsync();
                JObject buffer = JObject.Parse(body);
                IList<JToken> entries = buffer["entries"].Children().ToList();
                model.Items = entries;
                model.Count = entries.Count;
            }
            catch (Exception)
            {

            }
            return model;
        }

        [HttpGet("fetchid/{index}")]
        public ActionResult<int> GetDataId(int index)
        {
            Model model = _repo.GetId(index);
            int loopcount = 1;
            while (model == null)
            {
                model = _repo.GetId(index + loopcount);
                loopcount++;
            }
            return model.ID;

        }

        [HttpGet("syncfusion")]
        public ActionResult<IEnumerable<SyncModelStore>> GetAllSyncData()
        {
            return new OkObjectResult(_repo.GetAllSync());
        }
    }
}
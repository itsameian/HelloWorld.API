using HelloWorld.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWorld.API.Controllers
{
    public class HWController : ApiController
    {
        List<HWModel> model;
        public HWController()
        {
            model = new List<HWModel>()
            {
                new HWModel
                {
                    ID = 1 ,
                    Message = "Hello World!"
                },
                new HWModel
                {
                    ID = 2,
                    Message = "Goodbye!"
                }
            };
        }

        public IEnumerable<HWModel> GetMessages()
        {
            return model;
        }

        public HWModel GetMessage(int id)
        {
            return model.SingleOrDefault(m => m.ID == id);
        }

        public void PutMessage(int id, [FromBody]string message)
        {
            HWModel modelToEdit = model.SingleOrDefault(m => m.ID == id);
            
            modelToEdit.Message = message;
        }

        public void PostMessage(HWModel modelToAdd)
        {
            model.Add(modelToAdd);
        }

        public void DeleteMessage(int id)
        {
            HWModel modelToDelete = model.SingleOrDefault(m => m.ID == id);
            model.Remove(modelToDelete);
        }
    }
}

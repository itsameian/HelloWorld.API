using HelloWorld.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWorld.API.Controllers
{
    /// <summary>
    /// RESTful api controller for the HWModel object 
    /// </summary>
    public class HWController : ApiController
    {
        List<HWModel> model;

        /// <summary>
        /// Instantiates the Model for the api and populates 2 values
        /// </summary>
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
 
        /// <summary>
        /// Returns a list of all HWModel objects currently in memory
        /// </summary>
        public IEnumerable<HWModel> GetMessages()
        {
            return model;
        }

        /// <summary>
        /// Returns a single HWModel object
        /// </summary>
        /// <param name="id">The ID of teh object to return</param>
        public HWModel GetMessage(int id)
        {
            return model.SingleOrDefault(m => m.ID == id);
        }

        /// <summary>
        /// Updates the HWObject of the selected ID
        /// </summary>
        /// <param name="id">The ID of teh object to update</param>
        /// <param name="message">the message to be updated</param>
        public void PutMessage(int id, [FromBody]string message)
        {
            HWModel modelToEdit = model.SingleOrDefault(m => m.ID == id);
            
            modelToEdit.Message = message;
        }
        /// <summary>
        /// Adds a new HWModel Object to the list of objects
        /// </summary>
        /// <param name="modelToAdd">Object of type HWModel to be added to the list</param>
        public void PostMessage(HWModel modelToAdd)
        {
            model.Add(modelToAdd);
        }
        /// <summary>
        /// Deletes the selected object of ID "id" from teh list
        /// </summary>
        /// <param name="id">The ID of the selected object</param>
        public void DeleteMessage(int id)
        {
            HWModel modelToDelete = model.SingleOrDefault(m => m.ID == id);
            model.Remove(modelToDelete);
        }
    }
}

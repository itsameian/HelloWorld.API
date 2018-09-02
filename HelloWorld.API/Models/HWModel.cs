using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.API.Models
{
    public class HWModel
    {
        private int id;
        private string message;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
    }
}
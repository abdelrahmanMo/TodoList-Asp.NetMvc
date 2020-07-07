using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyStore.Models;

namespace VidlyStore.Dtos
{
    public class taskDto
    {
        public int Id { get; set; }
        public string describtion { get; set; }
        public DateTime TaskDate { get; set; }
        public string TaskTime { get; set; }
       
    }
}
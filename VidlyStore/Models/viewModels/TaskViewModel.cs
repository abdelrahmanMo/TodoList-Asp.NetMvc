using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyStore.Models.viewModels
{
    public class TaskViewModel
    {
        public List<Images> images { get; set; }
        public task task { get; set; }
    }
}
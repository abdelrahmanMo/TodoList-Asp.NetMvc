using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VidlyStore.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public task task { get; set; }
        [ForeignKey("task")]
        public int taskId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VidlyStore.Models
{
    public class task
    {
        public int Id { get; set; }
        [ForeignKey("user")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser user { get; set; }
        public string describtion { get; set; }
        public DateTime TaskDate { get; set; }
        public TimeSpan TaskTime { get; set; }
    }
}
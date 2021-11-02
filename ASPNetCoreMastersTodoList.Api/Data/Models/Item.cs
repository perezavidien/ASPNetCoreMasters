using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Data.Models
{
        public class Item
        {
            [Key]
            public int Id { get; set; }
            public string Title { get; set; }
            public string ShortDescriptiton { get; set; }
            public string CreatedBy { get; set; }
            public DateTime DateCreated { get; set; }
        }
}

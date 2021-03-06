using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.BindingModels
{
    public class ItemUpdateBindingModel
    {
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Title { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
    }
}

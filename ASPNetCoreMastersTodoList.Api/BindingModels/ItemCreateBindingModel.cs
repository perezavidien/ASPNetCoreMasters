using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.ApiModels
{
    public class ItemCreateBindingModel
    {

        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Text { get; set; }
    }

    // todo create separate file
    public class ItemUpdateBindingModel
    {

        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Text { get; set; }
    }
}

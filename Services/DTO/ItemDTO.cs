using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class ItemDTO
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

        public ItemDTO()
        { }

        public ItemDTO(string title)
        {
            if (!String.IsNullOrEmpty(title))
                Title = title;
        }
        public ItemDTO(int id, string title)
        {
            if (id != default)
                Id = id;

            if (!String.IsNullOrEmpty(title))
                Title = title;
        }
    }
}

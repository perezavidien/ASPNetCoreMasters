using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class ItemDTO
    {
        public string Text { get; set; }
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }

        public ItemDTO()
        { }

        public ItemDTO(string text)
        {
            if (!String.IsNullOrEmpty(text))
                Text = text;
        }
        public ItemDTO(int id, string text)
        {
            if (id != default)
                Id = id;

            if (!String.IsNullOrEmpty(text))
                Text = text;
        }

    }
}

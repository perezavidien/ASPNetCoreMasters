using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class ItemByFilterDTO
    {
        public ItemByFilterDTO(int id, string text)
        {
            if (id != default)
                Id = id;

            if (!String.IsNullOrEmpty(text))
                Text = text;
        }
        public string Text { get; set; }
        public int Id { get; set; }
    }
}

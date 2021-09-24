using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class ItemByFilterDTO
    {
        public string Text { get; set; }

        public ItemByFilterDTO(string text)
        {
            if (text == null)
                return;

            Text = text;
        }
    }
}

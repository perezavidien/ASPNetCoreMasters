﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class ItemDTO
    {
        public string Text { get; set; }

        public ItemDTO(string text)
        {
            this.Text = text;
        }

    }
}

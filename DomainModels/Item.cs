using System;

namespace DomainModels
{
    public class Item
    {
        // ? map the DTO Property to the Domain Item property
        public Item(string text)
        {
            if (text == null)
                return;

            this.Text = text;
        }

        public string Text { get; set; }
    }
}

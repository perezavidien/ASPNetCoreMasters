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
        public Item(int id, string text)
        {
            if (text == null)
                return;

            this.Text = text;
            this.Id = id;
        }

        public int Id { get; set; }
        public string Text { get; set; }
    }
}

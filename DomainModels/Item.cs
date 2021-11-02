using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Item
    {
        // ? map the DTO Property to the Domain Item property
        public Item(string title)
        {
            if (title == null)
                return;

            this.Title = title;
        }
        public Item(int id, string title)
        {
            if (title == null)
                return;

            this.Title = title;
            this.Id = id;
        }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescriptiton { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

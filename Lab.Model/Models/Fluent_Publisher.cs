﻿using System.Collections.Generic;

namespace Lab.Model.Models
{
    public class Fluent_Publisher
    {
        public int Publisher_Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Fluent_Book> Fluent_Books { get; set; }
    }
}

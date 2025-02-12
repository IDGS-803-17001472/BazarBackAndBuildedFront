﻿using System.Collections.Generic;

namespace ExamenBazar.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountPercentage { get; set; }
        public double Rating { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Thumbnail { get; set; }
        public ICollection<Sale> Sales { get; set; }

        // Almacenará una lista de URLs como un JSON en la base de datos
        public List<string> Images { get; set; }
    }
}
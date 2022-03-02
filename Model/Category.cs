﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Complete { get; set; }

        public Category(int Id, string name)
        {
            this.Id = Id;
            this.Name = name;
        }
    }
}
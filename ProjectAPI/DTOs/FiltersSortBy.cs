using System;
using System.Collections.Generic;
using System.Text;
using static DTOs.FiltersSortBy;

namespace DTOs
{
    public class SearchBy
    {
        public string Search { get; set; }
        public Categories Category { get; set; }
        public Genders Gender { get; set; }
        public Conditions Condition { get; set; }
        public PriceRange PriceRange { get; set; }
        public bool FreeShipping { get; set; }
    }
    public class FiltersSortBy
    {
        public enum Categories
        {
            All = 0,
            Clothes = 1,
            Toys = 2
        }
        public enum Genders
        {
            All = 0,
            Man = 1,
            Woman = 2
        }
        public enum Conditions
        {
            New = 0,
            Used = 1
        }

        public class PriceRange
        {
            public double FromPrice { get; set; }
            public double ToPrice { get; set; }
        }
    }
}

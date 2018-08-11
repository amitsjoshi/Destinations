using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destinations.Models
{
    public class ShowGrid
    {
        public ShowGrid()
        { }
        public ShowGrid(string First, string Last, string Design)
        {
            FirstName = First;
            LastName = Last;
            Designation = Design;
        }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Designation { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public override string ToString()
        {
            return FirstName + LastName + Designation;
        }


    }
}

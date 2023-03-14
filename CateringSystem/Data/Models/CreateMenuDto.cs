using System;
using System.Collections.Generic;

namespace CateringSystem.Data.Models
{
    public class CreateMenuDto
    {
        public int MenuTypeId { get; set; }
        public DateTime Date { get; set; }
        public List<MealDtoForMenu> Meals { get; set; }
    }
}

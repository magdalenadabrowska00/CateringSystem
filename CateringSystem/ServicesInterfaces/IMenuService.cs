﻿using CateringSystem.Data.Models;
using System.Collections.Generic;

namespace CateringSystem.ServicesInterfaces
{
    public interface IMenuService
    {
        List<MenuDto> GetAll();
    }
}

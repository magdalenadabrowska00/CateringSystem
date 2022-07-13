using CateringSystem.Data.Entities;
using CateringSystem.Data.Models;
using System;
using System.Collections.Generic;

namespace CateringSystem.ServicesInterfaces
{
    public interface IMealService
    {
        List<MealDto> GetAllMeals(int restaurantId); //pobrać wszystkie dania z restauracji, 
        
        
        
        //to będzie w menu servisie!
        //List<MealDto> GetAllMealsPerWeek(Restaurant restaurantName, DateTime startDate, DateTime endDate);// pobrac wszystkie dania z restauracji na dany tydzien
        // wstawić tez do bazy po 5 dan na caly tydzien
        //wstawić do bazy danych tyle Menu pozycji, żeby na przykład na 9 dni
        //było do przodu i jeśli ktoś chce na dwa dni zrobić zamówienie, 
        //to żeby podał te dni i niech mu pokaże jakie są opcje Dań z tej restauracji!
        //zmiany będzie można wykonać wcześniej śledząc jakie są wszystkie dania z Restauracji,
        //i wymienić jedną pozycje, na taką, jakiej Id jest w bazie danych lub że nazwa contains
    }
}

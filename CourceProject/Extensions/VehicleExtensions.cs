using System.Collections.Generic;
using System.Linq;
using CourceProject.Entities;

namespace CourceProject.Extensions;

public static class VehicleExtensions
{
    public static IQueryable<Car> Sort(this IQueryable<Car> query, string orderBy)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
            return query.OrderBy(i => i.Manufacturer);

        query = orderBy switch
        {
            "name" => query.OrderBy(i => i.Manufacturer),
            "priceDesc" => query.OrderByDescending(i => i.AveragePrice),
            "priceInc" => query.OrderBy(i => i.AveragePrice),
            "yearDesc" => query.OrderByDescending(i => i.YearOfProduction),
            _ => query.OrderBy(i => i.Manufacturer)
        };

        return query;
    }

    public static IQueryable<Car> Search(this IQueryable<Car> query, string searTerm)
    {
        if (string.IsNullOrWhiteSpace(searTerm)) return query;

        var lowerCaseSearchTerm = searTerm.Trim().ToLower();

        var searchResult = query.Where(i => i.Manufacturer.ToLower().Contains(lowerCaseSearchTerm));

        if (searchResult.Any() == false)
            searchResult = query.Where(i => i.Model.ToLower().Contains(lowerCaseSearchTerm));

        return searchResult;
    }

    public static IQueryable<Car> Filter(this IQueryable<Car> query, string manufacturers)
    {
        var manufacturerList = new List<string>();
        // var typeList = new List<string>();

        if (!string.IsNullOrEmpty(manufacturers))
            manufacturerList.AddRange(manufacturers.ToLower().Split(",").ToList());

        query = query.Where(i => manufacturerList.Count == 0 || manufacturerList.Contains(i.Manufacturer.ToLower()));

        return query;
    }
}
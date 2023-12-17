﻿using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;

namespace AirBnb.ServerApp.Application.Common.Models;

public class LocationFilter : FilterPagination, IQueryConvertible<Location>
{
    public string? Category { get; set; }
    
    public QuerySpecification<Location> ToQuerySpecification()
    {
        var querySpecification = new QuerySpecification<Location>(PageSize, PageToken);

        if (Category is not null)
        {
            querySpecification.IncludeOptions.Add(location => location.Category!);
            querySpecification.FilteringOptions.Add(location => location.Category!.Name.Equals("Castle"));
        }
        querySpecification.PaginationOptions = this;
        
        return querySpecification;
    }
}
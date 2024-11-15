﻿using Ardalis.Specification;
using TD.KCN.WebApi.Application.Common.Specification;
using TD.KCN.WebApi.Application.Identity.Users;

namespace TD.KCN.WebApi.Infrastructure.Identity;

public class UserListFilterSpec : EntitiesByBaseFilterSpec<ApplicationUser>
{
    public UserListFilterSpec(UserListFilter request)
        : base(request)
    {

        Query
            .Where(p => p.IsActive == request.IsActive, request.IsActive.HasValue)
        ;
    }

    public static DateTime GetDateZeroTime(DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
    }
}
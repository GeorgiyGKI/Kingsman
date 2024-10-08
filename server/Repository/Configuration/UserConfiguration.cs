﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Repository.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new PasswordHasher<User>();

        var user1 = new User
        {
            Id = new Guid("11111111-1111-1111-1111-111111111111").ToString(),
            FirstName = "FirstName",
            LastName = "LastName",
            UserName = "user1",
            NormalizedUserName = "USER1",
            Email = "user1@example.com",
            NormalizedEmail = "USER1@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = string.Empty
        };
        var user2 = new User
        {
            Id = new Guid("22222222-2222-2222-2222-222222222222").ToString(),
            FirstName = "FirstName",
            LastName = "LastName",
            UserName = "user2",
            NormalizedUserName = "USER2",
            Email = "user2@example.com",
            NormalizedEmail = "USER2@EXAMPLE.COM",
            EmailConfirmed = true,
            SecurityStamp = string.Empty
        };

        user2.PasswordHash = hasher.HashPassword(user2, "Password123!");
        user1.PasswordHash = hasher.HashPassword(user1, "Password123!");

        builder.HasData(user1, user2);
    }
}
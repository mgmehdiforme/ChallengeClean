﻿using ChallengeClean.Domain.Entities;
using ChallengeClean.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {        
        // Default data
        // Seed, if necessary
        if (!_context.Persons.Any())
        {
            var MehdiGolzari = new Person
            {
                FullName = "Mehdi golzari"
            };
            MehdiGolzari.Addresses.Add(new Address { City = "tehran", Street = "st1", Person = MehdiGolzari });
            MehdiGolzari.Addresses.Add(new Address { City = "tabriz", Street = "st1", Person = MehdiGolzari });
            MehdiGolzari.Addresses.Add(new Address { City = "ardabil", Street = "st1", Person = MehdiGolzari });
            MehdiGolzari.Addresses.Add(new Address { City = "khalkhal", Street = "st1", Person = MehdiGolzari });

            _context.Persons.Add(MehdiGolzari);

            await _context.SaveChangesAsync();
        }
    }
}

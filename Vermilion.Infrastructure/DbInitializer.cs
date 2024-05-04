﻿using Microsoft.EntityFrameworkCore;

namespace Vermilion.Infrastructure
{
    public class DbInitializer
    {
        public static void Initialize(VermilionDbContext context)
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            context.Database.Migrate();
        }
    }
}

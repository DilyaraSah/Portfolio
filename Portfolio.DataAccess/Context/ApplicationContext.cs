﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Entity;

namespace Portfolio.DataAccess.Context;

public class ApplicationContext: DbContext
{
    public DbSet<Request> Requests { get; set; } = null!;

    public ApplicationContext(DbContextOptions options)
        :base(options) { }
}
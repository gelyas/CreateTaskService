﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GenerateGuidService.Models;

public partial class PlanningContext : DbContext
{
    public PlanningContext()
    {
    }

    public PlanningContext(DbContextOptions<PlanningContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tasks> Tasks { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Planning;Persist Security Info=True;User ID=sa;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Tasks>(entity =>
        //{
        //    entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        //    entity.Property(e => e.State).IsFixedLength();
        //});

        //OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
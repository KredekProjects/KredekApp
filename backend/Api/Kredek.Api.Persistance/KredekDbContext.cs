using Microsoft.EntityFrameworkCore;
using Kredek.Api.Persistance.Models;

namespace Kredek.Api.Persistance;

public class KredekDbContext : DbContext
{
    public DbSet<CourseModel> Courses { get; set; }
    public DbSet<CourseParticipantModel> CourseParticipants { get; set; }
    public DbSet<LessonModel> Lessons { get; set; }
    public DbSet<LessonParticipantModel> LessonParticipants { get; set; }
    public DbSet<ParticipantModel> Participants { get; set; }

    public KredekDbContext(DbContextOptions<KredekDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
            
        builder.ApplyConfigurationsFromAssembly(typeof(KredekDbContext).Assembly);
        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));
        foreach(var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;
            if(entry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }
            entity.ModifiedAt = DateTime.UtcNow;
        }
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));
        foreach(var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;
            if(entry.State == EntityState.Added)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }
            entity.ModifiedAt = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
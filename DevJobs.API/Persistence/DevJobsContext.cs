using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevJobs.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DevJobs.API.Persistence
{
    public class DevJobsContext : DbContext
    {
        public DevJobsContext(DbContextOptions<DevJobsContext> options) : base(options)
        {
            
        }
        public DbSet<JobVacancy>? JobVacancies { get; private set; }
        public DbSet<JobApplication>? JobApplications { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobVacancy>(e => {
                e.HasKey(jv => jv.Id);
                //e.ToTable("tb_JobVacancies");
                e.HasMany(jv => jv.Applications).WithOne().HasForeignKey(ja => ja.IdJobVacancy)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<JobApplication>(e => {
                e.HasKey(ja => ja.Id);
            });
        }

/*
        public override DatabaseFacade Database => base.Database;

        public override ChangeTracker ChangeTracker => base.ChangeTracker;

        public override IModel Model => base.Model;

        public override DbContextId ContextId => base.ContextId;

        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            return base.Add(entity);
        }

        public override EntityEntry Add(object entity)
        {
            return base.Add(entity);
        }

        public override ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(entity, cancellationToken);
        }

        public override ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(entity, cancellationToken);
        }

        public override void AddRange(params object[] entities)
        {
            base.AddRange(entities);
        }

        public override void AddRange(IEnumerable<object> entities)
        {
            base.AddRange(entities);
        }

        public override Task AddRangeAsync(params object[] entities)
        {
            return base.AddRangeAsync(entities);
        }

        public override Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default)
        {
            return base.AddRangeAsync(entities, cancellationToken);
        }

        public override EntityEntry<TEntity> Attach<TEntity>(TEntity entity)
        {
            return base.Attach(entity);
        }

        public override EntityEntry Attach(object entity)
        {
            return base.Attach(entity);
        }

        public override void AttachRange(params object[] entities)
        {
            base.AttachRange(entities);
        }

        public override void AttachRange(IEnumerable<object> entities)
        {
            base.AttachRange(entities);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public override ValueTask DisposeAsync()
        {
            return base.DisposeAsync();
        }

        public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        {
            return base.Entry(entity);
        }

        public override EntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override object? Find(Type entityType, params object?[]? keyValues)
        {
            return base.Find(entityType, keyValues);
        }

        public override ValueTask<object?> FindAsync(Type entityType, params object?[]? keyValues)
        {
            return base.FindAsync(entityType, keyValues);
        }

        public override ValueTask<object?> FindAsync(Type entityType, object?[]? keyValues, CancellationToken cancellationToken)
        {
            return base.FindAsync(entityType, keyValues, cancellationToken);
        }

        public override IQueryable<TResult> FromExpression<TResult>(Expression<Func<IQueryable<TResult>>> expression)
        {
            return base.FromExpression(expression);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
        {
            return base.Remove(entity);
        }

        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }

        public override void RemoveRange(params object[] entities)
        {
            base.RemoveRange(entities);
        }

        public override void RemoveRange(IEnumerable<object> entities)
        {
            base.RemoveRange(entities);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public override DbSet<TEntity> Set<TEntity>(string name)
        {
            return base.Set<TEntity>(name);
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            return base.Update(entity);
        }

        public override EntityEntry Update(object entity)
        {
            return base.Update(entity);
        }

        public override void UpdateRange(params object[] entities)
        {
            base.UpdateRange(entities);
        }

        public override void UpdateRange(IEnumerable<object> entities)
        {
            base.UpdateRange(entities);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
*/
    }
}
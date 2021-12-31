using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sripirom.BulkUpload.DataAccess.Context
{
    public class BulkUploadDbContext : DbContext
    {
        public BulkUploadDbContext(DbContextOptions<BulkUploadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IgnoreEntities(modelBuilder);

            // Implement this configure
        }

        /// <summary>
        /// This method is used occasionally to recreate migration script and improve it
        /// for example by changing the fluentapi.
        /// This will be deleted.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void IgnoreEntities(ModelBuilder modelBuilder)
        {
            // Implement this ctor when we want to ignore the entity
            // example: modelBuilder.Ignore<DebtorKey>();
        }
    }
}

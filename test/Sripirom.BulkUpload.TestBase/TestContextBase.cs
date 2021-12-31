using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Sripirom.BulkUpload.DataAccess.Context;
using System;

namespace Sripirom.BulkUpload.TestBase
{
    [SetUpFixture]
    public abstract class TestContextBase
    {
        public BulkUploadDbContext Context { get; set; }

        protected FixtureModel DataModelFixture { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Context = InMemoryContext();
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            Context?.Dispose();
        }

        public BulkUploadDbContext InMemoryContext()
        {
            var options = new DbContextOptionsBuilder<BulkUploadDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            var context = new BulkUploadDbContext(options);

            Seeding(context);

            return context;
        }

        // Initial data for whole tests.
        public void Seeding(BulkUploadDbContext context)
        {
            // Create Data Fixture
            DataModelFixture = CreateFixtureModel(1, DateTime.Today);
            BuildWithRelatedData(context, DataModelFixture);

            // Saving Seed Data.
            context.SaveChanges();
        }

        public FixtureModel CreateFixtureModel(int dataNumber, DateTime createdDate)
        {
            FixtureModel.CreateById createById = new FixtureModel.CreateById(dataNumber, createdDate);

            return new FixtureModel();
        }

        public void BuildWithRelatedData(BulkUploadDbContext context, FixtureModel fixture)
        {
            DataCreator.Building(context);
        }

        public void ClearWithRelatedData(BulkUploadDbContext context, FixtureModel fixture)
        {
            DataCreator.Building(context);
        }
    }
}

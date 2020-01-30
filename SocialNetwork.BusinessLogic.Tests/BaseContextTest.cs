using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BusinessLogic.Tests
{
    [TestClass]
    public abstract class BaseContextTest
    {
        protected SocialNetworkContext ctx;

        [TestInitialize]
        public virtual void OnSetUp()
        {
            string testDatabase = $"Server=(localdb)\\mssqllocaldb;Database=app_db_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true";
            var serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<SocialNetworkContext>();

            builder
                .EnableSensitiveDataLogging()
                .UseSqlServer(testDatabase)
                .UseInternalServiceProvider(serviceProvider);
            ctx = new SocialNetworkContext(builder.Options);
            ctx.Database.Migrate();//genera la migraci�n para la Bd mdf en memoria.
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            ctx.Database.EnsureDeletedAsync();
        }
    }
}

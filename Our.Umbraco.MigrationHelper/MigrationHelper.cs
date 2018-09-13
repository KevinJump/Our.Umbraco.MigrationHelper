using Semver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence.Migrations;

namespace Our.Umbraco.MigrationHelper
{
    public class MigrationHelper : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ProcessApplicationMigrations(applicationContext);
        }

        private void ProcessApplicationMigrations(ApplicationContext applicationContext)
        {
            var umbracoApps = TypeFinder.FindClassesOfType<IUmbracoApp>();

            foreach(var application in umbracoApps)
            {
                var appInstance = Activator.CreateInstance(application) as IUmbracoApp;
                ApplyMigration(applicationContext, appInstance.Name, appInstance.Version);
            }
        }

        private SemVersion ApplyMigration(ApplicationContext applicationContext, string productName, string targetVersion)
        {
            var currentVersion = new SemVersion(0);

            var migrations = applicationContext.Services.MigrationEntryService.GetAll(productName);
            var latest = migrations.OrderByDescending(x => x.Version)
                .FirstOrDefault();

            if (latest != null)
            {
                currentVersion = latest.Version;
            }

            using (applicationContext.ProfilingLogger.DebugDuration<MigrationHelper>("Running Migrations: " + productName, "Migrations for " + productName + " complete"))
            {
                if (targetVersion == currentVersion)
                    return currentVersion;

                var migrationRunner = new MigrationRunner(
                    applicationContext.Services.MigrationEntryService,
                    applicationContext.ProfilingLogger.Logger,
                    currentVersion,
                    targetVersion,
                    productName);

                try
                {
                    migrationRunner.Execute(applicationContext.DatabaseContext.Database);
                }
                catch (Exception ex)
                {
                    applicationContext.ProfilingLogger.Logger.Error<MigrationHelper>("Error running migration for " + productName, ex);
                }

                return currentVersion;
            }

        }
    }
}

using Our.Umbraco.MigrationHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDemo
{
    /// <summary>
    ///  by implimenting IUmbracoApp, the MigrationHelper will
    ///  trigger and run any migrations that share our AppName. 
    /// </summary>
    public class MigrationDemoApp : IUmbracoApp
    {
        // impliment IUmbracoApp
        public string Name => MigrationDemoApp.ProductName;
        public string Version => "1.0.0";


        // if we setup our product name as an internal const, we 
        // can just use this in the migrations. 
        internal const string ProductName = "MigrationDemoApp";
        internal const string SimpleTableName = "DemoPocoTable";

    }
}

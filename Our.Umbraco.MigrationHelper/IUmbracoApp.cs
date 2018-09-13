using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our.Umbraco.MigrationHelper
{
    public interface IUmbracoApp
    {
        string Name { get; }
        string Version { get; }
    }
}

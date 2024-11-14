using Atheme.Plugins;
using Atheme.Server.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPluginServer
{
    public class PluginEntry : ServerPluginEntry
    {
        public override void OnBootstrap(IPluginBootstrapContext context)
        {
            Console.WriteLine("TestPlugin OnBootstrap ran.");
        }
        public override void OnStart(IServerPluginContext context)
        {
            Console.WriteLine("TestPlugin OnStart ran.");
        }

        public override void OnStop(IServerPluginContext context)
        {
            Console.WriteLine("TestPlugin OnStop ran.");
        }
    }
}

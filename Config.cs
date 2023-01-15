using System.ComponentModel;
using Exiled.API.Interfaces;

namespace AFKMode
{
    public class Config : IConfig
    {
        [Description("Whether or not the plugin should be enabled.")]
        public bool IsEnabled { get; set; } = true;
        
        [Description("Whether or not debug logs should be shown.")]
        public bool Debug { get; set; } = false;

        [Description("Whether or not alive players will be able to use the command, remember that if an scp uses this there will be no communicate about it's death. Default: false")] 
        public bool AllowUseWhileAlive { get; set; } = false;
    }
}
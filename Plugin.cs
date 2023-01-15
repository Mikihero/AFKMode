using System;
using Exiled.API.Features;

namespace AFKMode
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override Version RequiredExiledVersion => new Version(6,0,0, 0);
        public override Version Version => new Version(1,0,0,0);
        public override string Author => "Miki_hero";

        public override void OnEnabled()
        {
            Instance = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            base.OnDisabled();
        }
    }
}
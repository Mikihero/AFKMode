using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using PlayerRoles;
using PluginAPI.Events;

namespace AFKMode.commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Overwatch : ICommand
    {
        public string Command => "overwatch";
        public string[] Aliases => new[] { "ow", "owatch" };
        public string Description => "Forceclasses you to overwatch.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player pl = Player.Get(sender);

            if (!pl.CheckPermission("am.ow"))
            {
                response = "Invalid permissions.";
                return false;
            }

            if (Round.IsLobby)
            {
                response = "You can't use this right now.";
                return false;
            }
            
            if (!Plugin.Instance.Config.AllowUseWhileAlive && pl.IsAlive)
            {
                response = "You can't use this while alive.";
                return false;
            }
            if (pl.Role.Type == RoleTypeId.Overwatch)
            {
                Log.Debug($"Player: {pl.Nickname}({pl.RawUserId}) has turned off overwatch.");
                pl.Role.Set(RoleTypeId.Spectator);
                response = "Successfully turned off overwatch.";
                return true;
            }
            Log.Debug($"Player: {pl.Nickname}({pl.RawUserId}) has turned on overwatch. They were: {pl.Role.Name}");
            pl.Role.Set(RoleTypeId.Overwatch);
            response = "Successfully turned on overwatch.";
            return true;
        }
    }
}
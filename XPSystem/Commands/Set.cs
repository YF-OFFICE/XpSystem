using CommandSystem;
using Exiled.Permissions.Extensions;
using System;

namespace XPSystem
{

    internal class Set : ICommand
    {
        public static Set Instance { get; } = new Set();
        public string Command => "set";
        public string[] Aliases => Array.Empty<string>();
        public string Description => $"设置一个玩家的等级.";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("xps.set"))
            {
                response = "没有这个权限 xps.set .";
                return false;
            }
            if (arguments.Count != 2)
            {
                response = "用法 : XPSystem set (UserId) (int amount)";
                return false;
            }
            string id = arguments.At(0);
            if (!Main.Players.TryGetValue(id, out PlayerLogSer log))
            {
                response = "无用的ID";
                return false;
            }
            if (int.TryParse(arguments.At(1), out int lvl))
            {
                log.LVL = lvl;
                response = $"{id}的等级已经变为 {log.LVL}";
                if (Main.ActivePlayers.TryGetValue(id, out PlayerLog activeLog))
                {
                    activeLog.ApplyRank();
                }
                return true;
            }
            response = $"无效的Lv : {lvl}";
            return false;
        }
    }
}

using Exiled.API.Features;
using Exiled.API.Interfaces;
using PlayerRoles;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace XPSystem
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("如果玩家DNT打开 那么展示的广播.")]
        public string DNTHint { get; set; } = "当您在游戏选项中启用DNT时，我们无法储存你的经验数据！";
        [Description("开启DNT所获得的称号.")]
        public Badge DNTBadge { get; set; } = new Badge
        {
            Name = "(DNT) anonymous man????",
            Color = "nickel"
        };

        [Description("角色1：角色2：拥有角色1的XP玩家因杀死角色2的人而获得奖励")]
        public Dictionary<RoleTypeId, Dictionary<RoleTypeId, int>> KillXP { get; set; } = new Dictionary<RoleTypeId, Dictionary<RoleTypeId, int>>()
        {
            [RoleTypeId.ClassD] = new Dictionary<RoleTypeId, int>()
            {
                [RoleTypeId.Scientist] = 200,
                [RoleTypeId.FacilityGuard] = 150,
                [RoleTypeId.NtfPrivate] = 200,
                [RoleTypeId.NtfSergeant] = 250,
                [RoleTypeId.NtfCaptain] = 300,
                [RoleTypeId.Scp049] = 500,
                [RoleTypeId.Scp0492] = 100,
                [RoleTypeId.Scp106] = 500,
                [RoleTypeId.Scp173] = 500,
                [RoleTypeId.Scp096] = 500,
                [RoleTypeId.Scp939] = 500
            },
            [RoleTypeId.Scientist] = new Dictionary<RoleTypeId, int>()
            {
                [RoleTypeId.ClassD] = 50,
                [RoleTypeId.ChaosConscript] = 200,
                [RoleTypeId.ChaosRifleman] = 200,
                [RoleTypeId.ChaosRepressor] = 250,
                [RoleTypeId.ChaosMarauder] = 300,
                [RoleTypeId.Scp049] = 500,
                [RoleTypeId.Scp0492] = 100,
                [RoleTypeId.Scp106] = 500,
                [RoleTypeId.Scp173] = 500,
                [RoleTypeId.Scp096] = 500,
                [RoleTypeId.Scp939] = 500
            }
        };
        [Description("079次助攻获得XP")]
        public int AssistXP { get; set; } = 300;

        [Description("团队胜利获得多少经验.")]
        public int TeamWinXP { get; set; } = 250;

        [Description("多少经验可以升一级.")]
        public int XPPerLevel { get; set; } = 1000;

        [Description("展示增加经验的提示")]
        public bool ShowAddedXP { get; set; } = true;

        [Description("新等级是否提示.")]
        public bool ShowAddedLVL { get; set; } = true;

        [Description("如果玩家升级，会显示什么提示。（如果ShowAddedLVL=false，则此项并没有影响）")]
        public string AddedLVLHint { get; set; } = "新等级: <color=red>%level%</color>";

        [Description("（您可以添加自己的条目）玩家逃跑可以获得多少经验值")]
        public Dictionary<RoleTypeId, int> EscapeXP { get; set; } = new Dictionary<RoleTypeId, int>()
        {
            [RoleTypeId.ClassD] = 500,
            [RoleTypeId.Scientist] = 300
        };

        [Description("对应的等级所拥有的称号")]
        public Dictionary<int, Badge> LevelsBadge { get; set; } = new Dictionary<int, Badge>()
        {
            [0] = new Badge
            {
                Name = "Visitor",
                Color = "cyan"
            },
            [1] = new Badge
            {
                Name = "Junior",
                Color = "orange"
            },
            [5] = new Badge
            {
                Name = "Senior",
                Color = "yellow"
            },
            [10] = new Badge
            {
                Name = "Veteran",
                Color = "red"
            },
            [50] = new Badge
            {
                Name = "Nerd",
                Color = "lime"
            }
        };

        [Description("游戏中显示的称号结构。变量：%lvl%-等级。%badge%在LevelsBadge中指定的时间获得徽章。%oldbadge% 游戏徽章，如配置remoteadmin中指定的徽章，或全局徽章。可以为空.")]
        public string BadgeStructure { get; set; } = "(LVL %lvl% | %badge%) %oldbadge%";
        [Description("保存路径.")]
        public string SavePath { get; set; } = Path.Combine(Paths.Configs, @"Players.json");
        [Description("是否覆盖已有称号玩家的称号")]
        public bool OverrideRAColor { get; set; } = false;
        [Description("测试用")]
        public bool Debug { get; set; } = false;
    }
}

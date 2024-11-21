using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace ProgressPlugin
{
    [ApiVersion(2, 1)]
    public class ProgressPlugin : TerrariaPlugin
    {
        public List<string> MainProgress = new ();
        public string Boss2Name="";

        public override string Author => "fireflyoo";

        public override string Description => "进度查询";

        public override string Name => "进度查询";

        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public ProgressPlugin(Main game) : base(game)
        {
        }

        public override void Initialize()
        {
            Boss2Name = WorldGen.crimson ? "克苏鲁之脑" : "世界吞噬怪";
            //主线Boss
            MainProgress = new List<string> { "史莱姆王", "克苏鲁之眼", Boss2Name, "骷髅王", "血肉墙", "毁灭者", "双子魔眼", "机械骷髅王", "世纪之花", "石巨人", "拜月教邪教徒", "月亮领主" };
            Commands.ChatCommands.Add(new Command("progress", new CommandDelegate(CMD), new string[3] { "进度查询", "查询进度", "progress" }));
        }

        private void CMD(CommandArgs args)
        {

            var BossesStatus = new Dictionary<string, bool>
            {
                { "哥布林军队", NPC.downedGoblins },
                { "史莱姆王", NPC.downedSlimeKing },
                { "克苏鲁之眼", NPC.downedBoss1 },
                { Boss2Name,NPC.downedBoss2 },
                { "鹿角怪" , NPC.downedDeerclops },
                { "蜂王" , NPC.downedQueenBee },
                { "骷髅王", NPC.downedBoss3 },
                { "血肉墙", Main.hardMode },
                { "海盗入侵", NPC.downedPirates },
                { "史莱姆皇后", NPC.downedQueenSlime },
                { "毁灭者", NPC.downedMechBoss1 },
                { "双子魔眼", NPC.downedMechBoss2 },
                { "机械骷髅王", NPC.downedMechBoss3 },
                { "猪龙鱼公爵", NPC.downedFishron },
                { "世纪之花", NPC.downedPlantBoss },
                { "常绿尖叫怪", NPC.downedChristmasTree },  // 霜月事件-小Boss
                { "圣诞坦克", NPC.downedChristmasSantank }, // 霜月事件-小Boss
                { "冰雪女王", NPC.downedChristmasIceQueen }, // 霜月事件-小Boss
                { "哀木", NPC.downedHalloweenTree }, //南瓜月事件-小Boss
                { "南瓜王", NPC.downedHalloweenKing },
                { "光之女皇", NPC.downedEmpressOfLight },
                { "石巨人", NPC.downedGolemBoss },
                { "火星暴乱", NPC.downedMartians }, //火星暴乱事件-小Boss
                { "拜月教邪教徒", NPC.downedAncientCultist },
                { "日耀柱", NPC.downedTowerSolar },
                { "星旋柱", NPC.downedTowerVortex },
                { "星云柱", NPC.downedTowerNebula },
                { "星尘柱", NPC.downedTowerStardust },
                { "月亮领主", NPC.downedMoonlord }
    
        };
            List<string> killedBossList=new();
            List<string> aliveBossList=new();
            foreach (var boss in BossesStatus)
            {
                if (boss.Value)
                {
                    killedBossList.Add(boss.Key);
                }
                else
                {
                    aliveBossList.Add(boss.Key);
                }
            }
            string text = "已击杀所有主线Boss";
            foreach (var boss in MainProgress)
            {
                if (!BossesStatus[boss]){
                    text = boss + "前";
                    break;
                }
            }

            args.Player.SendInfoMessage("目前进度: " + text);

            args.Player.SendInfoMessage("目前已击杀: " + String.Join(",", killedBossList));
            args.Player.SendInfoMessage("目前未击杀: " + String.Join(",", aliveBossList));
        }
    }
}

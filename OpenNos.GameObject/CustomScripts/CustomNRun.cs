using OpenNos.Core;
using OpenNos.DAL;
using OpenNos.Data;
using OpenNos.Domain;
using OpenNos.GameObject.Event;
using OpenNos.GameObject.Helpers;
using OpenNos.Master.Library.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenNos.GameObject.Networking;
using OpenNos.GameObject;
using System.Threading;

namespace OpenNos.GameObject
{
    public static class CustomNRun
    {
        public static object PrestigeLevel { get; private set; }

        public static void NRunHandler(ClientSession Session, NRunPacket packet)
        {
            //Evolved System by Nizar (Idea @Saber None)
            Session.Character.Level = 1; //Min Level
            Session.Character.HeroLevel = 1; //Min HeroLevel
            Session.Character.JobLevel = 1; //Min JobLvl
            Session.Character.SendGift(1, 1, 1, 1, 1, false); //Send Gift to Evolve
            Logger.Log.Debug($"Evolve: user {Session.Character.Name} id {Session.Character.CharacterId} ip {Session.IpAddress}");

            ClassType ClassType;
            switch (ClassType = Session.Character.Class)
            {
                case ClassType.Adventurer:
                    DamageHelper.Defence += 1;
                    DamageHelper.DefenceRate += 2;
                    break;
                case ClassType.Swordman:
                    DamageHelper.Defence += 1;
                    DamageHelper.DefenceRate += 2;
                    break;
                case ClassType.Archer:
                    DamageHelper.Defence += 1;
                    DamageHelper.DefenceRate += 2;
                    break;
                case ClassType.Magician:
                    DamageHelper.Defence += 1;
                    DamageHelper.DefenceRate += 2;
                    break;
            }
        }
    }
}

public static class CustomNRun //Prestige System
{
    public static void PrestigeLevel(ClientSession Session, NRunPacket packet)
    {

        if (Session.Character.Level == 99)
        {
            Session.SendPacket("msg 5 DU_HAST_DAS_NÖTIGE_LVL_NICHT");
        }
        if (Session.Character.HeroLevel == 50)
        {
            Session.SendPacket("msg 5 DU_HAST_DAS_NÖTIGE_HELDEN_LVL_NICHT");
        }
        if (Session.Character.Inventory.All(i => i.Type != InventoryType.Wear))
        {
            Session.SendPacket("msg 5 DU_HAST_NOCH_EQ");
        }
        {
            Session.Character.PrestigeLevel += 1; //Prestige Level
            Logger.Log.Debug($"Prestige: user {Session.Character.Name} id {Session.Character.CharacterId} ip {Session.IpAddress}");
            Session.SendPacket("msg 5 CONGRATULATIONS_YOU_HAVE_ONE_PRESTIGE_MORE");
        }

        {
            ClassType ClassPrestige;
            switch (ClassPrestige = Session.Character.Class)
            {
                case ClassType.Adventurer:
                    //Session.Gift for Adventurer
                    break;
                case ClassType.Swordman:
                    //Session.Gift for Swordsman
                    break;
                case ClassType.Archer:
                    //Session.Gift for Archer
                    break;
                case ClassType.Magician:
                    //Session.Gift for Magician
                    break;
            }
        }
    }
}

public static class PowerLevel //Power Level (Development)
{
    public static void CustomNRun(ClientSession Session, NRunPacket packet)
    {
        if (Session.Character.PrestigeLevel == 5)
        {
            Session.Character.GenerateNpcDialog(2); //Custom Dialog (Clientmodding)
            CharacterHelper.GoldPenalty(5, 5); //PlayerLevel -> Monster Level
            CharacterHelper.ExperiencePenalty(5, 5); //PlayerLevel -> Monster Level
            Session.Character.PowerLevel += 1; //Power Level
            Session.SendPacket("msg 5 YOUR_POWER_LEVEL_HAVE_INCREASED");
        }
        {
            Session.Character.Level = 55;
            Session.Character.JobLevel = 35;
            Session.Character.HeroLevel = 5;
        }
        {
            Logger.Log.Debug($"PowerLevel: user {Session.Character.Name} id {Session.Character.CharacterId} ip {Session.IpAddress}");
        }
    }
}


public static class MistyBox //Neues Projekt MistyBox
{
    private static readonly int rnd;

    public static void CustomNRun(ClientSession Session, NRunPacket packet)
    {

        if (500000 > Session.Character.Gold)
        {
            //Session NOT_ENOUGH_MONEY
            Session.SendPacket(Session.Character.GenerateSay(Language.Instance.GetMessageFromKey("NOT_ENOUGH_MONEY"), 11));
            return;
        }
        //NPC Dialog Fehlt
        object npc = null;
        if (npc != null)
        {
            //Session Paid Instance
            Session.Character.Gold -= 500000;
            Session.SendPacket(Session.Character.GenerateGold());
            Session.SendPacket(Session.Character.GenerateSay(Language.Instance.GetMessageFromKey("YOU_PAID_500K_GOLD"), 12));
        }

        //Session RandomGenerator
        int rnd = SessionFactory.Instance.RandomNumber(0, 99);

        if (rnd > 98)
            Session.Character.GiftAdd(11009, 1);

        if (rnd > 97)
            Session.Character.GiftAdd(11009, 1);

        return;
    }
}
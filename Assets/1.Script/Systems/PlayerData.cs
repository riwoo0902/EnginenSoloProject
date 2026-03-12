using System;
using _1.Script.EntityScript.Entities;

namespace _1.Script.Systems
{
    public static class PlayerData
    {
        public static Team PlayerTeam { get; private set; } = Team.Blue;
        
        public static float Gold = 100;

        public static bool TryBuy(float cost)
        {
            if (Gold >= cost)
            {
                Gold -= cost;
                return true;
            }
            return false;
        }
        
    }
}
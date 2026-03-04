using UnityEngine;

namespace _1.Script.EntityScript.Entities
{
    public enum Team
    {
        Red = 0,
        Blue = 1
    }

    public static class TeamCheck
    {
        public static bool IsTeam(Team team1, Team team2)
        {
            return team1 == team2;
        }
        
        public static bool IsEnemy(Team team1, Team team2)
        {
            return (int)team1 + (int)team2 == 1;
        }
    }
    
}
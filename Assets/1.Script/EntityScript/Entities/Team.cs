namespace _1.Script.EntityScript.Entities
{
    public enum Team
    {
        Red = 0,
        Blue = 1,
        Yellow = 2
        
    }

    public class TeamCheck
    {
        public bool IsTeam(Team team1, Team team2)
        {
            return team1 == team2;
        }
        
        public bool IsEnemy(Team team1, Team team2)
        {
            return (int)team1 + (int)team2 == 1;
        }
    }
    
}
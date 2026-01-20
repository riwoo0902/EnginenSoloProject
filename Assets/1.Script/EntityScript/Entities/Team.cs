namespace _1.Script.EntityScript.Entities
{
    public enum Team
    {
        Red,Blue,Yellow
    }

    public interface IHaveTeam
    {
        Team MyTeam { get; }
        bool IsTeam(Team team)
        {
            return MyTeam == team;
        }
    }
    
}
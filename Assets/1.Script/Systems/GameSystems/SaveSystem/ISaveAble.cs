using _2.So._1.Scripts;

namespace _1.Script.Systems.GameSystems.SaveSystem
{
    public interface ISaveAble
    {
        SaveIdData SaveId { get; }
        string GetSaveData();
        void RestoreData(string data);
    }
}
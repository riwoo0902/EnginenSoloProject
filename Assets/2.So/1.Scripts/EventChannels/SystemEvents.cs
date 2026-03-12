namespace _2.So._1.Scripts.EventChannels
{
    public static class SystemEvents
    {
        public static readonly SavePrefEvent SavePref = new SavePrefEvent();
        public static readonly LoadPrefEvent LoadPref = new LoadPrefEvent();
    }

    public class SavePrefEvent : GameEvent { }
    public class LoadPrefEvent : GameEvent { }
    
}
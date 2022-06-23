namespace FiveElement.Stage1
{
    public class Stage1Controller : StageManager
    {
        public delegate void CompleteElement(string color);
        public static event CompleteElement OnCompleteElement;

        public static void GetAnElement(string color)
        {
            OnCompleteElement?.Invoke(color);
        }

        public static void CheckWinCond()
        {
            OnCheckingLevelComplete();
        }
    }
}

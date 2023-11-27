using UnityEngine.Events;

public static class StaicAddedPointsWhenDestroyingAShip
{

    public static UnityAction<int> addPoint { get; set; }
    public static void AddPoint(int value)
    {
        addPoint?.Invoke(value);
    }


}

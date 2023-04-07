using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEvent
{
}

public static class Events
{
    public static PointEvent PointEvent = new PointEvent();
    public static StopMovementEvent StopMovementEvent = new StopMovementEvent();
    public static ContinueMovementEvent ContinueMovementEvent = new ContinueMovementEvent();
}

public class PointEvent : IEvent
{
    public int point;
}

public class StopMovementEvent : IEvent
{
}

public class ContinueMovementEvent : IEvent
{
}

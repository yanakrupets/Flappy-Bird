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
    public static GameOverEvent GameOverEvent = new GameOverEvent();
    public static BonusEvent BonusEvent = new BonusEvent();
    public static ReturnToPoolEvent ReturnToPoolEvent = new ReturnToPoolEvent();
    public static StartMovingBackgroundEvent StartMovingBackgroundEvent = new StartMovingBackgroundEvent();
    public static StopMovingBackgroundEvent StopMovingBackgroundEvent = new StopMovingBackgroundEvent();
}

public class PointEvent : IEvent
{
    public int point;
}

public class StopMovementEvent : IEvent { }

public class ContinueMovementEvent : IEvent { }

public class GameOverEvent : IEvent 
{
    public int currentScore;
}

public class BonusEvent : IEvent
{
    public BonusData bonusData;
}

public class ReturnToPoolEvent : IEvent { }

public class StartMovingBackgroundEvent : IEvent { }

public class StopMovingBackgroundEvent : IEvent { }

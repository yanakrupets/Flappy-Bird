using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    readonly Dictionary<Type, Action<IEvent>> s_Events = new Dictionary<Type, Action<IEvent>>();

    readonly Dictionary<Delegate, Action<IEvent>> s_EventLookups = new Dictionary<Delegate, Action<IEvent>>();

    public void AddListener<T>(Action<T> evt) where T : IEvent
    {
        if (!s_EventLookups.ContainsKey(evt))
        {
            Action<IEvent> newAction = (e) => evt((T)e);
            s_EventLookups[evt] = newAction;

            if (s_Events.TryGetValue(typeof(T), out Action<IEvent> internalAction))
                s_Events[typeof(T)] = internalAction += newAction;
            else
                s_Events[typeof(T)] = newAction;
        }
    }

    public void RemoveListener<T>(Action<T> evt) where T : IEvent
    {
        if (s_EventLookups.TryGetValue(evt, out var action))
        {
            if (s_Events.TryGetValue(typeof(T), out var tempAction))
            {
                tempAction -= action;
                if (tempAction == null)
                    s_Events.Remove(typeof(T));
                else
                    s_Events[typeof(T)] = tempAction;
            }

            s_EventLookups.Remove(evt);
        }
    }

    public void Broadcast(IEvent evt)
    {
        if (s_Events.TryGetValue(evt.GetType(), out var action))
            action.Invoke(evt);
    }

    //private Dictionary<Type, UnityEvent<IEvent>> eventDictionary = new Dictionary<Type, UnityEvent<IEvent>>();

    //public void AddListener<T>(UnityAction<T> evt) where T : IEvent
    //{
    //    if (eventDictionary.TryGetValue(typeof(T), out UnityEvent<IEvent> thisEvent))
    //    {
    //        thisEvent.AddListener(evt as UnityAction<IEvent>);
    //    }
    //    else
    //    {
    //        thisEvent = new UnityEvent<IEvent>();
    //        thisEvent.AddListener(evt as UnityAction<IEvent>);
    //        eventDictionary.Add(typeof(T), thisEvent);
    //    }
    //}

    //public void RemoveListener<T>(Action<T> evt) where T : IEvent
    //{
    //    if (eventDictionary.TryGetValue(typeof(T), out UnityEvent<IEvent> thisEvent))
    //    {
    //        thisEvent.RemoveListener(evt as UnityAction<IEvent>);
    //    }
    //}

    //public void Broadcast(IEvent evt)
    //{
    //    if (eventDictionary.TryGetValue(evt.GetType(), out var action))
    //        action.Invoke(evt);
    //}
}

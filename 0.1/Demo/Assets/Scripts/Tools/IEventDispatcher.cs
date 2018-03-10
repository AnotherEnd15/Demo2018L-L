using System;

public interface IEventDispatcher
{
    void AddListener(string eventName, Action<IEventArgs> action);
    void DispatchEvent(string eventName, IEventArgs eventArgs);
    bool HasListener(string eventName);
    void RemoveAllListener();
    void RemoveEventListener(string eventName);
    void RemoveSingleListener(string eventName, Action<IEventArgs> action);
}
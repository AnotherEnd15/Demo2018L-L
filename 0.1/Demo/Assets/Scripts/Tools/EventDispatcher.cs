using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IEventArgs{}
/// <summary>
/// 基础的单项参数，用以传递单个int、float、string、bool等等以及各种自定义类型的数据
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseArg<T>:IEventArgs
{
    public T value;
    public BaseArg(T value)
    {
        this.value = value;
    }
}
public class BaseArg<TA,TB> : IEventArgs
{
    public TA valueA;
    public TB valueB;
    public BaseArg(TA valueA,TB valueB)
    {
        this.valueA = valueA;
        this.valueB = valueB;
    }
}
public class BaseArg<TA, TB,TC> : IEventArgs
{
    public TA valueA;
    public TB valueB;
    public TC valueC;
    public BaseArg(TA valueA, TB valueB ,TC valueC)
    {
        this.valueA = valueA;
        this.valueB = valueB;
        this.valueC = valueC;
    }
}





public class EventDispatcher : IEventDispatcher
{
    public static EventDispatcher Instance
    {
        get {
            instance = instance ?? new EventDispatcher();
            return instance;
        }
    }
    private static EventDispatcher instance;
    //存储事件监听的字典
    private Dictionary<string, List<Action<IEventArgs>>> eventDic = new Dictionary<string, List<Action<IEventArgs>>>();

    #region 提供给项目开发者使用的一些方法
    /// <summary>
    /// 触发事件
    /// </summary>
    /// <param name="eventName">事件名</param>
    /// <param name="eventArgs">提供的事件输入参数</param>
    public void DispatchEvent(string eventName, IEventArgs eventArgs)
    {
        if (eventDic.ContainsKey(eventName))
        {
            if (eventDic[eventName].Count==0)
            {
                return;
            }
            else
            {
                foreach (var v in eventDic[eventName])
                {
                    v(eventArgs);
                }
            }

        }
        else
        {
            return;
        }
    }
    /// <summary>
    /// 添加监听
    /// </summary>
    /// <param name="eventName">监听的事件名</param>
    /// <param name="action">事件的一个委托</param>
    public void AddListener(string eventName, Action<IEventArgs> action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            if (eventDic[eventName].Contains(action))
            {
                return;
            }
            else
            {
                eventDic[eventName].Add(action);
            }

        }
        else
        {
            List<Action<IEventArgs>> list = new List<Action<IEventArgs>>();
            list.Add(action);
            eventDic.Add(eventName, list);
        }
    }
    /// <summary>
    /// 删除某个事件的一个委托
    /// </summary>
    /// <param name="eventName">该事件的事件名</param>
    /// <param name="action">该委托</param>
    public void RemoveSingleListener(string eventName, Action<IEventArgs> action)
    {
        if (eventDic.ContainsKey(eventName))
        {
            if (eventDic[eventName].Contains(action))
            {
                eventDic[eventName].Remove(action);
            }
            else
            {
                return;
            }

        }
        else
        {
            return;
        }
    }
    /// <summary>
    /// 删除某个事件的所有委托
    /// </summary>
    /// <param name="eventName"></param>
    public void RemoveEventListener(string eventName)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic.Remove(eventName);
        }
        else
        {
            return;
        }
    }
    /// <summary>
    /// 删除所有事件及其委托
    /// </summary>
    public void RemoveAllListener()
    {
        eventDic.Clear();
    }
    /// <summary>
    /// 判断某个事件是否已添加某个委托
    /// </summary>
    /// <param name="eventName"></param>
    /// <returns></returns>
    public bool HasListener(string eventName)
    {
        return eventDic.ContainsKey(eventName);
    }
    #endregion
    #region !public

    #endregion

}

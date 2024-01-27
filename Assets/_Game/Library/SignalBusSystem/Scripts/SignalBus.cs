using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Library.SignalBusSystem
{
    public static class SignalBus
    {
        private static readonly Dictionary<Type, IList<ListenerData>> SignalTypeByListenerDataMap = new ();

        public static void Subscribe<T>(Action listener, PriorityType priority = PriorityType.Normal) 
            where T : ISignal
        {
            if (!SignalTypeByListenerDataMap.ContainsKey(typeof(T)))
            {
                SignalTypeByListenerDataMap.Add(typeof(T), new List<ListenerData>());
            }
                
            SignalTypeByListenerDataMap[typeof(T)].Add(new ListenerData(priority, listener, listener.Target));
        }        
        
        public static void Subscribe<T>(Action<T> listener, PriorityType priority = PriorityType.Normal) 
            where T : ISignal
        {
            if (!SignalTypeByListenerDataMap.ContainsKey(typeof(T)))
            {
                SignalTypeByListenerDataMap.Add(typeof(T), new List<ListenerData>());
            }
            
            Action<ISignal> convertedListener = o => listener((T) o);
            SignalTypeByListenerDataMap[typeof(T)].Add(new ListenerData(priority, convertedListener, listener.Target));
        }

        public static void Unsubscribe<T>(Action listener) where T : ISignal
        {
            if (!SignalTypeByListenerDataMap.ContainsKey(typeof(T))) return;

            ListenerData listenerData = SignalTypeByListenerDataMap[typeof(T)]
                .FirstOrDefault(item => item.Target == listener.Target);

            if (listenerData == null) return;
            
            SignalTypeByListenerDataMap[typeof(T)].Remove(listenerData);
        }

        public static void Unsubscribe<T>(Action<T> listener) where T : ISignal
        {
            if (!SignalTypeByListenerDataMap.ContainsKey(typeof(T))) return;

            ListenerData listenerData = SignalTypeByListenerDataMap[typeof(T)]
                .FirstOrDefault(item => item.Target == listener.Target);

            if (listenerData == null) return;
            
            SignalTypeByListenerDataMap[typeof(T)].Remove(listenerData);
        }

        public static void Fire<T>(T signal) where T : ISignal
        {
            if (SignalTypeByListenerDataMap.ContainsKey(signal.GetType()))
            {
                IEnumerable<ListenerData> sortedListeners = SignalTypeByListenerDataMap[signal.GetType()]
                    .OrderBy(item => item.Priority);

                foreach (var listenerData in sortedListeners)
                {
                    listenerData.Listener?.Invoke();
                    listenerData.ListenerWithParam?.Invoke(signal);
                }
            }            
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Clear()
        {
            SignalTypeByListenerDataMap.Clear();   
        }
    }
}
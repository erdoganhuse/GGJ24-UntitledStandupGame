using System;
using System.Collections;
using System.Collections.Generic;
using Library.Utility;
using UnityEngine;

namespace Library.CoroutineSystem
{
    public class CoroutineManager : MonoSingleton<CoroutineManager>
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public static Coroutine BeginCoroutine(IEnumerator method)
        {
            return Instance.StartCoroutine(method);
        }

        public static void BeginCoroutine(string method)
        {
            Instance.StartCoroutine(method);
        }

        public static void EndCoroutine(Coroutine method)
        {
            if (method != null)
            {
                Instance.StopCoroutine(method);
            }

            method = null;
        }

        public static void EndCoroutine(string method)
        {
            Instance.StopCoroutine(method);
        }

        public static void DoAfterFixedUpdate(Action actionToInvoke)
        {
            Instance.StartCoroutine(Wait(Time.fixedDeltaTime, actionToInvoke));
        }

        public static Coroutine DoAfterGivenTime(float waitTime, Action actionToInvoke)
        {
            return Instance.StartCoroutine(Wait(waitTime, actionToInvoke));
        }

        public static Coroutine DoAfterGivenUnscaledTime(float waitTime, Action actionToInvoke)
        {
            return Instance.StartCoroutine(WaitUnscaled(waitTime, actionToInvoke));
        }

        public IEnumerator ProcessMultipleCoroutines(IEnumerable<IEnumerator> coroutineArray, Action actionToInvoke = null)
        {
            foreach (var enumerator in coroutineArray)
            {
                yield return StartCoroutine(enumerator);
            }

            actionToInvoke?.Invoke();
        }

        private static IEnumerator Wait(float time, Action actionToInvoke)
        {
            yield return new WaitForSeconds(time);
            
                actionToInvoke.Invoke();
        }        
        
        private static IEnumerator WaitUnscaled(float time, Action actionToInvoke)
        {
            yield return new WaitForSecondsRealtime(time);

            actionToInvoke.Invoke();
        }       
    }
}
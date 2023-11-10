using System;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;

namespace ValheimHack223
{
    public class MainThreadDispatcher : MonoBehaviour
    {
        private static MainThreadDispatcher _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public static void RunOnMainThread(Action action)
        {
            if (_instance != null)
            {
                _instance.StartCoroutine(_instance.RunOnMainThreadCoroutine(action));
            }
        }

        private IEnumerator RunOnMainThreadCoroutine(Action action)
        {
            yield return null;
            action.Invoke();
        }
    }
}

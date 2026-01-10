using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_IOS && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace ToastWeather.Toast {

#if UNITY_IOS && !UNITY_EDITOR
    public class IOSToastService : IToastService {

        [DllImport("__Internal")]

        private static extern void ShowNativeToast(string message);

        public void Show(string message) {

            ShowNativeToast(message);
        }
    }
#else
    // Dummy implementation so Android/Editor builds don't break
    public class IOSToastService : IToastService {

        public void Show(string message) {
            Debug.Log($"[iOS Toast] {message}");
        }
    }
#endif
}

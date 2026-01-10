using UnityEngine;

namespace ToastWeather.Toast {

    public class ToastManager : MonoBehaviour {

        private static IToastService service;

        private void Awake() {

#if UNITY_ANDROID && !UNITY_EDITOR
            service = new AndroidToastService();

#elif UNITY_IOS && !UNITY_EDITOR
            service = new IOSToastService();

#else
            service = null;
#endif
        }

        public void ShowToast(string message) {

            if(service != null) {
                service.Show(message);

            } else {
                Debug.Log($"[Toast] {message}");
            }
        }
    }
}
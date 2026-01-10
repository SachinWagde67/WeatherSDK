using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToastWeather.Toast {

    public class AndroidToastService : IToastService {

        public void Show(string message) {

            using(AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

                AndroidJavaObject toastClass = new AndroidJavaClass("android.widget.Toast");

                activity.Call("runOnUiThread", new AndroidJavaRunnable(() => {

                    AndroidJavaObject toast = toastClass.CallStatic<AndroidJavaObject>(
                            "makeText",
                            activity,
                            message,
                            toastClass.GetStatic<int>("LENGTH_SHORT"));

                    toast.Call("show");
                }));
            }
        }
    }
}

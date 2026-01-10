using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToastWeather.Toast;

namespace ToastWeather.Weather {

    public class WeatherController : MonoBehaviour {

        private WeatherService weatherService;
        private ToastManager toastManager;

        private void Awake() {
            weatherService = new WeatherService();
            toastManager = FindObjectOfType<ToastManager>();
        }

        //Called from Button
        public void OnShowLocationAndWeatherClicked() {
            StartCoroutine(HandleLocationAndWeather());
        }

        private IEnumerator HandleLocationAndWeather() {

            // Permission check
            if(!HasLocationPermission()) {
                toastManager.ShowToast("Please enable location permission");
                yield break;
            }

            // Location service enabled check
            if(!Input.location.isEnabledByUser) {
                toastManager.ShowToast("Please enable location services");
                yield break;
            }

            // Start location service
            Input.location.Start();

            float timeout = 10f;
            while(Input.location.status == LocationServiceStatus.Initializing && timeout > 0) {
                timeout -= Time.deltaTime;
                yield return null;
            }

            if(Input.location.status != LocationServiceStatus.Running) {
                toastManager.ShowToast("Unable to fetch location");
                yield break;
            }

            float latitude = Input.location.lastData.latitude;
            float longitude = Input.location.lastData.longitude;

            // Fetch weather
            yield return weatherService.GetWeather(

                latitude,
                longitude,

                temp => {

                    toastManager.ShowToast($"Current Temperature: {temp}");
                },

                error => {
                    toastManager.ShowToast("Failed to fetch weather");
                });
        }

        // Permission handling
        private bool HasLocationPermission() {

#if UNITY_ANDROID && !UNITY_EDITOR
            return UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.FineLocation);
#elif UNITY_IOS
            return true;
#else
            return true;
#endif
        }
    }
}
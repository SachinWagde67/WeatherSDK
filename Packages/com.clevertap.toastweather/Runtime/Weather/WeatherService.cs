using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace ToastWeather.Weather {

    public class WeatherService {

        private const string API =
            "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&timezone=IST&daily=temperature_2m_max";

        public IEnumerator GetWeather(float lat, float lon, Action<float> onSuccess, Action<string> onError) {

            string url = string.Format(API, lat, lon);
            UnityWebRequest request = UnityWebRequest.Get(url);

            yield return request.SendWebRequest();

            if(request.result != UnityWebRequest.Result.Success) {
                onError?.Invoke(request.error);
                yield break;
            }

            WeatherResponse response = JsonUtility.FromJson<WeatherResponse>(request.downloadHandler.text);

            float todayTemp = response.daily.temperature_2m_max[0];
            onSuccess?.Invoke(todayTemp);
        }
    }
}

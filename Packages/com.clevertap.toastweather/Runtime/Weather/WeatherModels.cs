using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ToastWeather.Weather {

    [Serializable]
    public class WeatherResponse {
        public Daily daily;
    }

    [Serializable]
    public class Daily {
        public List<string> time;
        public List<float> temperature_2m_max;
    }
}

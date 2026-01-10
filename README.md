# Toast Weather SDK (Unity)

A lightweight Unity SDK that shows current temperature in platform-specific Toast messages (Android & iOS), implemented using a clean, modular architecture.

This assignment demonstrates the design and implementation of a Unity SDK that provides:

- Platform-specific Toast functionality (Android & iOS)
- A Weather feature using API-based data fetching
- A clean, scalable architecture suitable for SDK development

The focus of this assignment is code quality, architecture, and platform-specific implementation.

## Package Information

- Package Name: com.clevertap.toastweather
- Platforms Supported: Android, iOS
- Unity version used: Unity 2022.3.62f3

## Features

- Toast Feature 
  - Displays native toast messages on Android.
  - Uses Objective-C bridge for iOS toast-like behavior.
  - Automatically selects the correct platform implementation.

- Weather Feature 
  - Fetches weather data from a weather API.
  - Uses structured models for clean data handling.
  - Separate controller and service layers.

- Modular SDK Design
  - Interface-based architecture.
  - Easy to extend or replace services.

## Architecture Overview

This SDK follows Clean Architecture principles:

 ### Abstraction Layer
  - IToastService.cs
    - Defines a common contract for toast functionality.

### Platform Implementations
  - AndroidToastService.cs
  - IOSToastService.cs
    - iOS native integration via ToastPlugin.mm

### Manager Layer
  - ToastManager.cs
    - Decides which platform service to use at runtime.

### Weather Layer
  - WeatherController.cs
    - Entry point for weather-related actions.
  - WeatherService.cs
    - Handles API communication.
  - WeatherModels.cs
    - Handles JSON parsing.
   
## How to Use

  - Import the package "com.clevertap.toastweather"
  - Create an empty gameobject in the scene and attach the ToastManager script to it.
  - Create another empty gameobject in the scene and attach the WeatherController script to it.
  - Create a button in the scene and call the WeatherController.OnShowLocationAndWeatherClicked() method on button click.




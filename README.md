# PICOCast

## Description
PICOCast is PICO's proprietary casting API. This set of interfaces allows developers to manage several aspects of the casting solution.
Note that PICOCast requires the device to be connected to a WiFi network in order to be able to cast. The PICOCast service will create a casting server in a local IP address.
## Demo requirements
- Device connected to a WiFi network
- Unity 2022.3.f1
- PICO XR SDK 2.4.0
## Dependencies (UPM)
- XR Interaction Toolkit 2.5.2 + Starter Assets
- Android Logcat

## About PICOCast interfaces
### Casting Status
- PICOCastInit: https://developer-global.pico-interactive.com/reference/unity/latest/PXR_Enterprise/#PICOCastInit
- PICOCastStopCast: https://developer-global.pico-interactive.com/reference/unity/latest/PXR_Enterprise/#PICOCastStopCast
- PICOCastGetUrl: https://developer-global.pico-interactive.com/reference/unity/latest/PXR_Enterprise/#PICOCastGetUrl
### Authorization Status
- PICOCastSetShowAuthorization: https://developer-global.pico-interactive.com/reference/unity/latest/PXR_Enterprise/#PICOCastSetShowAuthorization
- PICOCastGetShowAuthorization: https://developer-global.pico-interactive.com/reference/unity/latest/PXR_Enterprise/#PICOCastGetShowAuthorization
### Resolution/bitrate
- PICOCastSetOption: https://developer-global.pico-interactive.com/reference/unity/latest/PXR_Enterprise/#PICOCastGetShowAuthorization
- PICOCastGetOptionOrStatus: https://developer-global.pico-interactive.com/reference/unity/latest/PXR_Enterprise/#PICOCastGetOptionOrStatus

## Demo
To connect to the casting server, access the URL obtained when pressing the "Get URL" button.
![image](https://github.com/picoxr/PICOCast/assets/15983798/ae0b754c-dd32-40e4-bef6-4d64e837438e)

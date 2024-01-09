using UnityEngine;
using UnityEngine.UI;
using Unity.XR.PXR;

public class PICOCastUtils : MonoBehaviour
{
    [SerializeField] private Text connectionStatusText;
    [SerializeField] private Text castURLText;
    [SerializeField] private Text authStatusText;

    private void Awake()
    {
        PXR_Enterprise.InitEnterpriseService();
        PXR_Enterprise.BindEnterpriseService((bound) =>
        {
            Debug.Log("Bind success.");
        });
    }

    // Unbind Service
    private void OnDestroy()
    {
        PXR_Enterprise.UnBindEnterpriseService();
    }
    

    public void OnPICOCastInitButtonClicked()
    {
        int result = PXR_Enterprise.PICOCastInit( (result) => { connectionStatusText.text = "Connection status: " + (result == 1 ? "Connected" : "failure"); });

        Debug.Log("Connection status: " + result);
    }

    public void OnPICOCastStopCastButtonClicked()
    {
        int result = PXR_Enterprise.PICOCastStopCast();

        connectionStatusText.text = "Connection status: " + (result == 1 ? "Disconnected" : "failure");

        Debug.Log("Disconnection status: " + result);
    }

    private const int AUTHORIZATION_ASK_EVERY_TIME = 0;
    private const int AUTHORIZATION_ALWAYS_ALLOW = 1;
    private const int AUTHORIZATION_NOT_ACCEPTED = 2;

    public void OnPICOCastAlwaysAskButtonClicked()
    {
        int result = PXR_Enterprise.PICOCastSetShowAuthorization(AUTHORIZATION_ASK_EVERY_TIME);

        authStatusText.text = "Authorization status: " + (result == 1 ? "Always ask" : "failure");
        Debug.Log("Authorization status: " + (result == 1 ? "Always ask" : "failure"));
    }

    public void OnPICOCastAlwaysAllowButtonClicked()
    {
        int result = PXR_Enterprise.PICOCastSetShowAuthorization(AUTHORIZATION_ALWAYS_ALLOW);

        authStatusText.text = "Authorization status: " + (result == 1 ? "Always allow" : "failure");
        Debug.Log("Authorization status: " + (result == 1 ? "Always allow" : "failure"));
    }

    public void OnPICOCastNeverAllowButtonClicked()
    {
        int result = PXR_Enterprise.PICOCastSetShowAuthorization(AUTHORIZATION_NOT_ACCEPTED);

        authStatusText.text = "Authorization status: " + (result == 1 ? "Never allow" : "failure");
        Debug.Log("Authorization status: " + (result == 1 ? "Never allow" : "failure"));
    }

    public void OnPICOCastGetUrlButtonClicked()
    {
        string normalURL = PXR_Enterprise.PICOCastGetUrl(PICOCastUrlTypeEnum.NORMAL_URL);
        string noConfirmURL = PXR_Enterprise.PICOCastGetUrl(PICOCastUrlTypeEnum.NO_CONFIRM_URL);
        string rtmpURL = PXR_Enterprise.PICOCastGetUrl(PICOCastUrlTypeEnum.RTMP_URL);


        castURLText.text = ("PICOCast URL: " + normalURL + "\n noConfirmURL: " + noConfirmURL + "\n rtmpURL: " + rtmpURL);
        Debug.Log("PICOCast URL: " + normalURL);
        Debug.Log("noConfirm URL: " + noConfirmURL);
        Debug.Log("rtmp URL: " + rtmpURL);
    }
    
    public void OnPicoCastBitrateConfigChanged(TMPro.TMP_Dropdown dropdown)
    {
        PICOCastOptionValueEnum bitrate;
        switch (dropdown.value)
        {
            case 0: //Low
                bitrate = PICOCastOptionValueEnum.OPTION_VALUE_BITRATE_LOW;
                break;
            case 1: //Middle
                bitrate = PICOCastOptionValueEnum.OPTION_VALUE_BITRATE_MIDDLE;
                break;
            case 2: //High
                bitrate = PICOCastOptionValueEnum.OPTION_VALUE_BITRATE_HIGH;
                break;
            default:
                bitrate = PICOCastOptionValueEnum.OPTION_VALUE_BITRATE_MIDDLE;
                break;
        }
        PXR_Enterprise.PICOCastSetOption(PICOCastOptionOrStatusEnum.OPTION_BITRATE_LEVEL, bitrate);
        Debug.Log("Bitrate: " + bitrate.ToString());
    }

    public void OnPicoCastResolutionConfigChanged(TMPro.TMP_Dropdown dropdown)
    {
        PICOCastOptionValueEnum resolution;
        switch (dropdown.value)
        {
            case 0: //Auto
                resolution = PICOCastOptionValueEnum.OPTION_VALUE_RESOLUTION_AUTO;
                break;
            case 1: //Middle
                resolution = PICOCastOptionValueEnum.OPTION_VALUE_RESOLUTION_MIDDLE;
                break;
            case 2: //High
                resolution = PICOCastOptionValueEnum.OPTION_VALUE_RESOLUTION_HIGH;
                break;
            case 3: //High 2K
                resolution = PICOCastOptionValueEnum.OPTION_VALUE_RESOLUTION_HIGH_2K;
                break;
            case 4: //High 4K
                resolution = PICOCastOptionValueEnum.OPTION_VALUE_RESOLUTION_HIGH_4K;
                break;
            default:
                resolution = PICOCastOptionValueEnum.OPTION_VALUE_RESOLUTION_AUTO;
                break;
        }
        PXR_Enterprise.PICOCastSetOption(PICOCastOptionOrStatusEnum.OPTION_RESOLUTION_LEVEL, resolution);
        Debug.Log("Resolution: " + resolution.ToString());
    }

}

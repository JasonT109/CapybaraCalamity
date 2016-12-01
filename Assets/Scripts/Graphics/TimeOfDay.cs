using UnityEngine;
using System.Collections;
using Utils;

public class TimeOfDay : MonoBehaviour
{
    [Header("Sun setup")]
    public Light Sun;
    public Gradient SunColor;
    public Renderer SunGeoMat;
    public Light SunPointLight;
    [Range(0, 360)]
    public int SunOrientationOffset;

    [Header("Moon setup")]
    public Light Moon;
    public Gradient MoonColor;
    [Range(0, 360)]
    public int MoonOrientationOffset;

    [Header("Skybox setup")]
    public Material SkyBoxMaterial;
    public Gradient SkyBoxColor;
    public GameObject SunMoonGeoRoot;

    [Header("Nightsky setup")]
    public GameObject NightSky;
    public Gradient NightSkyColor;
    public float NightSkySpeed = 0.4f;

    [Header("Clouds setup")]
    public Renderer CloudRenderer;
    public Gradient CloudColor;

    [Header("Time setup")]
    [Range(0, 24)]
    public float TheTime;
    public float TimeSpeed = 48f;

    private Vector3 SunOrientation;
    private Vector3 MoonOrientation;
    private float NightSkyTime;

    private float NormalisedTime(float _Time)
    {
        return CapyMaths.remapValue(_Time, 0, 24, 1, 0);
    }

    private Color CurrentColor(Gradient _Grad, float _NormalisedTime)
    {
        return _Grad.Evaluate(_NormalisedTime);
    }

    private float CurrentDirection(float _NormalisedTime, float _Offset)
    {
        float Orientation = CapyMaths.remapValue(_NormalisedTime, 0, 1, 0, 360) + _Offset;

        if (Orientation > 360)
            Orientation -= 360;

        return Orientation;
    }

    void Start ()
    {
        SunOrientation = Sun.transform.eulerAngles;
        MoonOrientation = Moon.transform.eulerAngles;
        RenderSettings.skybox = SkyBoxMaterial;
    }

	void Update ()
    {
        TheTime += Time.deltaTime * TimeSpeed;
        if (TheTime > 24)
            TheTime = TheTime - (int)TheTime;

        float Ntime = NormalisedTime(TheTime);

        Sun.color = CurrentColor(SunColor, NormalisedTime(TheTime));
        Sun.transform.rotation = Quaternion.Euler(new Vector3(CurrentDirection(Ntime, SunOrientationOffset), SunOrientation.y, SunOrientation.z));
        SunGeoMat.material.SetColor("_TintColor", CurrentColor(SunColor, NormalisedTime(TheTime)));
        SunMoonGeoRoot.transform.rotation = Quaternion.Euler(new Vector3(CurrentDirection(Ntime, 0), 90, 0));
        SunPointLight.color = Sun.color;

        Moon.color = CurrentColor(MoonColor, NormalisedTime(TheTime));
        Moon.transform.rotation = Quaternion.Euler(new Vector3(CurrentDirection(Ntime, MoonOrientationOffset), MoonOrientation.y, MoonOrientation.z));

        SkyBoxMaterial.SetColor("_Tint", CurrentColor(SkyBoxColor, Ntime));

        NightSkyTime += Time.deltaTime * NightSkySpeed;
        if (NightSkyTime > 24)
            NightSkyTime = NightSkyTime - (int)NightSkyTime;

        Renderer r = NightSky.GetComponent<Renderer>();
        r.material.SetColor("_TintColor", CurrentColor(NightSkyColor, Ntime));
        NightSky.transform.rotation = Quaternion.Euler(new Vector3(CurrentDirection(NormalisedTime(NightSkyTime), 0), 90, -90));

        CloudRenderer.material.SetColor("_TintColor", CurrentColor(CloudColor, Ntime));
    }
}

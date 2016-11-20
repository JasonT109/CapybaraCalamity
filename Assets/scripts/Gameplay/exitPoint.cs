using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class exitPoint : MonoBehaviour
{
    public int NumberSaved = 0;
    public GameObject ParticleEffect;
    public Text SavedText;

    public void SpawnParticleEffect(Vector3 AgentPosition)
    {
        Instantiate(ParticleEffect, AgentPosition, Quaternion.identity);
        NumberSaved++;

        if (NumberSaved > 0)
            SavedText.gameObject.SetActive(true);
    }

    public void Reset()
    {
        NumberSaved = 0;
    }

    void Update()
    {
        SavedText.gameObject.SetActive(NumberSaved > 0);
        SavedText.text = NumberSaved.ToString();
    }
}
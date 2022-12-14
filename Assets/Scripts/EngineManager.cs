using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EngineManager : MonoBehaviour
{
    public bool AreEnginesActive { get { return m_AreEnginesOn; } }

    public bool startOn = false;
    public Material offMaterial = null;
    public Material onMaterial = null;
    public GameObject onText = null;
    public GameObject offText = null;
    public AudioClip onAudio = null;
    public AudioClip offAudio = null;

    public bool debugToggle = false;

    private bool m_AreEnginesOn = false;
    private AudioSource audio = null;
    private bool isActive;
    private MeshRenderer buttonMaterial = null;
    private bool cooldown = false;

    private void Update()
    {
        if(debugToggle)
        {
            Toggle();
            debugToggle = false;
        }
    }

    private void OnEnable()
    {
        audio = GetComponent<AudioSource>();
        buttonMaterial = GetComponentInChildren<MeshRenderer>();

        if (startOn)
        {
            buttonMaterial.material = onMaterial;
            onText.SetActive(true);
            offText.SetActive(false);
            m_AreEnginesOn = true;
            isActive = true;
        }
        else
        {
            m_AreEnginesOn = false;
            buttonMaterial.material = offMaterial;
            onText.SetActive(false);
            offText.SetActive(true);
            isActive = false;
        }

    }

    public void Toggle()
    {
        if (!cooldown)
        {

            if (isActive)
                ToggleOff();
            else
                ToggleOn();

            isActive = !isActive;
            Invoke("ResetCooldown", 1f);
            cooldown = true;
        }
    }

    private void ToggleOff()
    {
        m_AreEnginesOn = false;
        buttonMaterial.material = offMaterial;
        onText.SetActive(!isActive);
        offText.SetActive(isActive);
        audio.clip = offAudio;
        audio.Play();
    }

    private void ToggleOn()
    {
        m_AreEnginesOn = true;
        buttonMaterial.material = onMaterial;
        offText.SetActive(isActive);
        onText.SetActive(!isActive);
        audio.clip = onAudio;
        audio.Play();
    }

    void ResetCooldown()
    {
        cooldown = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    public Material offMaterial = null;
    public Material onMaterial = null;
    public GameObject onText = null;
    public GameObject offText = null;

    private AudioSource pressSound = null;
    private bool isActive = false;
    private MeshRenderer buttonMaterial = null;

    private void OnEnable()
    {
        pressSound = GetComponent<AudioSource>();
        buttonMaterial = GetComponentInChildren<MeshRenderer>();

        onText.SetActive(false);
        offText.SetActive(true);
    }

    public void Toggle()
    {
        pressSound.Play();

        if (isActive)
            ToggleOff();
        else
            ToggleOn();

        isActive = !isActive;
    }
    
    private void ToggleOff()
    {
        buttonMaterial.material = offMaterial;
        onText.SetActive(!isActive);
        offText.SetActive(isActive);
    }

    private void ToggleOn()
    {
        buttonMaterial.material = onMaterial;
        offText.SetActive(isActive);
        onText.SetActive(!isActive);
    }
}

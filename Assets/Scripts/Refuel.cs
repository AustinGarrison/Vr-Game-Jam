using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Refuel : MonoBehaviour
{
    public Material offMaterial = null;
    public Material onMaterial = null;
    public AudioClip pressSound = null;
    public FuelLevel fuelLevel = null;

    public bool debugToggle = false;

    private AudioSource audio = null;
    private bool isActive = false;
    private MeshRenderer buttonMaterial = null;
    private bool cooldown = false;

    private void OnEnable()
    {
        audio = GetComponent<AudioSource>();
        buttonMaterial = GetComponentInChildren<MeshRenderer>();
        buttonMaterial.material = onMaterial;
    }

    private void Update()
    {
        if (debugToggle)
        {
            RefuelPressed(4f);
            debugToggle = false;
        }
    }

    public void RefuelPressed(float amount)
    {
        if (!cooldown)
        {
            if (isActive)
            {

            }
            else
            {

            }

            fuelLevel.IncreaseFuelLevel(amount);

            audio.clip = pressSound;
            audio.Play();

            isActive = !isActive;

            StartCoroutine(ResetCooldown());
        }
    }

    private IEnumerator ResetCooldown()
    {
        cooldown = true;
        buttonMaterial.material = offMaterial;
        yield return new WaitForSeconds(2f);
        buttonMaterial.material = onMaterial;
        cooldown = false;
    }
}

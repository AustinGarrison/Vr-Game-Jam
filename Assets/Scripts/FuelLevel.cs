using UnityEngine;
using UnityEngine.UI;

public class FuelLevel : MonoBehaviour
{
    [SerializeField] private EngineManager engineManager;
    [SerializeField] private Image fuelLevelBar;
    [SerializeField] private float fillAmount;
    private float drainAmount;
    public ShipThrottle throttle;

    private void Start()
    {
        fuelLevelBar.fillAmount = 1.0f;

    }

    private void Update()
    {
        UpdateFuelLevel();
    }

    public void UpdateFuelLevel()
    {
        drainAmount = throttle.DrainAmount;

        if (engineManager.AreEnginesActive)
            DecreaseFuelLevel(drainAmount);
    }

    public void IncreaseFuelLevel(float refillAmount)
    {
        if (fuelLevelBar.fillAmount >= 1.0f) return;
        fuelLevelBar.fillAmount += refillAmount * Time.deltaTime;
    }

    public void DecreaseFuelLevel(float drainAmount)
    {
        if (fuelLevelBar.fillAmount <= 0.1f) return;
        fuelLevelBar.fillAmount -= drainAmount * Time.deltaTime;
    }
}

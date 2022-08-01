using UnityEngine;
using UnityEngine.UI;

public class FuelLevel : MonoBehaviour
{
    [SerializeField] private EngineManager engineManager;
    [SerializeField] private Image fuelLevelBar;
    [SerializeField] private float emptyAmount;
    [SerializeField] private float fillAmount;

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
        if(engineManager.AreEnginesActive) DecreaseFuelLevel(emptyAmount);
        else IncreaseFuelLevel(fillAmount);
    }
    
    public void IncreaseFuelLevel(float fillAmountArg)
    {
        if (fuelLevelBar.fillAmount >= 1.0f) return;
        fuelLevelBar.fillAmount += fillAmountArg * Time.deltaTime;
    }
    
    public void DecreaseFuelLevel(float emptyAmountArg)
    {
        if (fuelLevelBar.fillAmount <= 0.1f) return;
        fuelLevelBar.fillAmount -= emptyAmountArg * Time.deltaTime;
    }
}

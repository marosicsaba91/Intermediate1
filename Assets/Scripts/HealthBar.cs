using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Agent agent;
    [SerializeField] Image healthImage;

    void Awake()
    {
        agent.HealthChanged += OnHealthChanged;
    }

    void OnDestroy()
    {
        agent.HealthChanged -= OnHealthChanged;
    }

    void Update()
    {        
        transform.LookAt(Camera.main.transform);
    }

    void OnHealthChanged() => UpdateUI(agent.HealthRate);

    public void UpdateUI(float healthRate) 
    {
        healthImage.fillAmount = healthRate;
    }
}
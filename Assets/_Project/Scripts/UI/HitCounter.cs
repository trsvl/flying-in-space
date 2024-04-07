using TMPro;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    private TextMeshProUGUI hitCounterText;
    private int currentNumberHits;


    void Start()
    {
        hitCounterText = GetComponent<TextMeshProUGUI>();
        UpdateHitCounter(0);
    }

    public void UpdateHitCounter(int value)
    {
        currentNumberHits += value;
        hitCounterText.text = "Number of hits: " + currentNumberHits;
    }
}

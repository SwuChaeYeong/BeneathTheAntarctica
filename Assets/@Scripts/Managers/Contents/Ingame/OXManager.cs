using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OXManager : Manager<OXManager>
{
    [SerializeField] private Slider oxSlider;
    [SerializeField] private TextMeshProUGUI oxText;

    private int curruntOX = 100;
    private int maxOX = 100;

    void Start()
    {
        StartCoroutine(decreaseOX());
    }

    private void Update()
    {
        oxText.text = oxSlider.value.ToString() + "%";
    }

    IEnumerator decreaseOX()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            curruntOX--;

            oxSlider.maxValue = maxOX;
            oxSlider.value = curruntOX;
        }
    }

    public void DamagedOX(int damage)
    {
        curruntOX = curruntOX - damage;
        oxSlider.value = curruntOX;
    }
}

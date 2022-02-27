using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggManager : MonoBehaviour
{
    //serialized
    [SerializeField] private int startEggAmount = 10;
    [SerializeField] private int timeRateEgg = 10;
    [SerializeField] private int eggPerWave = 10;
    [SerializeField] private Text eggText;
    [SerializeField] private Text waveText;

    //private
    private int _eggAmount;
    private float _timeLeft;
    private int currentWave;

    // Start is called before the first frame update
    void Start()
    {
        _timeLeft = timeRateEgg;
        _eggAmount = startEggAmount;
        UpdateText();

        currentWave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        EggAddTimer();

    }
    public void DecreaseEgg(int amount)
    {
        _eggAmount -= amount;
        UpdateText();
    }
    public void IncreaseEgg(int amount)
    {
        _eggAmount += amount;
        UpdateText();
    }
    private void UpdateText()
    {
        eggText.text = _eggAmount.ToString();
    }
    private void EggAddTimer()
    {
        _timeLeft -= Time.deltaTime;
        if (_timeLeft < 0)
        {
            _timeLeft = timeRateEgg;
            NextWave();
            IncreaseEgg(eggPerWave*currentWave);
        }
    }
    private void NextWave()
    {
        currentWave++;
        waveText.text = currentWave.ToString();
    }
}

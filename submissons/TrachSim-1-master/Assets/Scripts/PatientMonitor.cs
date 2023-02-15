using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PatientMonitor : MonoBehaviour
{

    public TMP_Text heartRateText;          private int heartRate;
    public TMP_Text oxygenSaturationText;   private int oxygenSaturation;
    public TMP_Text respirationRateText;    private int respirationRate;
    // Fluxuations
    private int flux1; private int flux2; private int flux3;
    // Time counter
    private double timeCounter;

    // Start is called before the first frame update
    void Start()
    {
        this.timeCounter = Time.realtimeSinceStartupAsDouble;
        this.heartRate = 75;
        this.oxygenSaturation = 88;
        this.respirationRate = 100;
        this.flux1 = 0; this.flux2 = 0; this.flux3 = 0;
    }



    // Update is called once per frame
    void Update()
    {
        double timeNow = Time.realtimeSinceStartupAsDouble;
        if (timeNow - timeCounter > 3.0)
        {
            timeCounter = timeNow;
            flux1 = Random.Range(-1,2);
            flux2 = Random.Range(-1,2);
            flux3 = Random.Range(-1,2);
        }

        this.heartRateText.text = (this.heartRate + flux1).ToString();
        this.oxygenSaturationText.text = (this.oxygenSaturation + flux2).ToString();
        this.respirationRateText.text = (this.respirationRate + flux3).ToString();
    }

}

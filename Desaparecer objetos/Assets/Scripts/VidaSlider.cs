using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VidaSlider: MonoBehaviour {
    [SerializeField]
    TextMeshProUGUI mensajeVida;

    public GameObject prefabCapsule;

    [SerializeField]
    Slider sliderValue;

    float vida;
    void Start () {
        vida = Random.Range (10f, 30f);
        sliderValue.maxValue = vida;
        sliderValue.value = sliderValue.maxValue;
    }

    // Update is called once per frame
    void Update () {
        vida -= Time.deltaTime;
        sliderValue.value -= Time.deltaTime;
        mensajeVida.text = "Time left: " + sliderValue.value.ToString (".00");

        if (sliderValue.value <= 0f) {
            Instantiate (prefabCapsule, new Vector3 (Random.Range (-100f, 100f), 2f, Random.Range (-300f, 300f)));
            Destroy (gameObject);
        }

    }
}

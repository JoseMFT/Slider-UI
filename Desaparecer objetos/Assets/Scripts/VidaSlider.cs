using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VidaSlider: MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI mensajeVida;

    public GameObject prefabCapsule, prefabAppear, prefabDestroy;
    const int kPruebas = 1;
    bool destroyed = false;

    [SerializeField]
    GameObject canvasVidaObjeto;

    [SerializeField]
    Slider sliderValue;
    float vida;
    public float spawnTime;
    Vector3 spawnPoint;

    void Start () {
        Instantiate (prefabAppear, transform.position, Quaternion.identity);
        LeanTween.scale (gameObject, Vector3.one * .01f, 1f * Time.deltaTime);
        Randomizer ();
        InitialSettings ();
    }

    void Update () {
        vida -= Time.deltaTime;
        sliderValue.value -= Time.deltaTime;
        mensajeVida.text = "Time left: " + sliderValue.value.ToString (".00");

        if (sliderValue.value <= 0f) {

            if (destroyed == false) {
                destroyed = true;
                Instantiate (prefabDestroy, transform.position, Quaternion.identity);
                LeanTween.scale (gameObject, new Vector3 (.1f, .1f, .1f), .5f).setEaseInCubic ().setOnComplete (() => {
                    gameObject.GetComponent<MeshRenderer> ().enabled = false;
                });
            }
            spawnTime -= Time.deltaTime;
            canvasVidaObjeto.SetActive (false);

            if (spawnTime <= 0) {
                Instantiate (prefabCapsule, spawnPoint, Quaternion.identity);
                Destroy (gameObject);
            }
        }
    }

    public void Spawner () {

    }

    public void Randomizer () {
        spawnPoint = new Vector3 (Random.Range (-15f, 15f), 1.51f, Random.Range (-15f, 22f));
        vida = Random.Range (10f / kPruebas, 30f / kPruebas);
        spawnTime = Random.Range (2f, 4f);
        sliderValue.maxValue = vida;
        sliderValue.value = sliderValue.maxValue;
    }

    public void InitialSettings () {
        gameObject.GetComponent<MeshRenderer> ().enabled = true;
        LeanTween.scale (gameObject, Vector3.one, .5f).setEaseOutCubic ().setOnComplete (() => {
            canvasVidaObjeto.SetActive (true);
        });
    }
}
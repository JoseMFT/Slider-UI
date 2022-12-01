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
    GameObject canvasVidaObjeto;

    [SerializeField]
    Slider sliderValue;
    float vida;
    public float spawnTime;
    Vector3 spawnPoint;

    void Start () {
        Randomizer ();
    }

    void Update () {
        vida -= Time.deltaTime;
        sliderValue.value -= Time.deltaTime;
        mensajeVida.text = "Time left: " + sliderValue.value.ToString (".00");

        if (sliderValue.value <= 0f) {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            spawnTime -= Time.deltaTime;
            canvasVidaObjeto.SetActive (false);
            
            if (spawnTime <= 0) {
                gameObject.GetComponent<MeshRenderer> ().enabled = true;
                canvasVidaObjeto.SetActive (true);
                Spawner ();
                Destroy (gameObject);

            }
        }
    }

    public void Spawner () {
        Randomizer ();
        Instantiate (prefabCapsule, spawnPoint, Quaternion.identity);
        canvasVidaObjeto.SetActive (true);
        Destroy (gameObject);
    }

    public void Randomizer () {
        spawnPoint = new Vector3 (Random.Range (-15f, 15f), 1.51f, Random.Range (-15f, 22f));
        vida = Random.Range (10f, 30f);
        spawnTime = Random.Range (3f, 6f);
        sliderValue.maxValue = vida;
        sliderValue.value = sliderValue.maxValue;
    }
}
using UnityEngine;
using UnityEngine.UI;

public class RageMeter : MonoBehaviour {
    public Renderer rdr;
    public float CurrentRage { get; set; }
    public float MaxRage { get; set; }
    public Slider ragebar;

    void Start() {
        MaxRage = 1f;
        CurrentRage = ragebar.value;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            DealRage(0.1f);
        }
    }

    void DealRage(float rage) {
        ragebar.value += rage;
        if (ragebar.value >= MaxRage) {
            Debug.Log("Die");
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

public class Pictograms : MonoBehaviour {
    public GameObject pictogramPrefab;
    public GameObject[] windowPrefabs;

    void Start() {
        CreatePictograms();
    }

    private void CreatePictograms() {
        DestroyPictograms();

        foreach (GameObject windowPrefab in windowPrefabs) {
            GameObject createdPictogram = Instantiate(pictogramPrefab, transform);

            Pictogram pictogram = createdPictogram.GetComponent<Pictogram>();
            pictogram.relatedWindowPrefab = windowPrefab;
        }
    }

    private void DestroyPictograms() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

    private int storageCapacity;
    private int storageIndicator = 0;
    private GameObject[] storage = new GameObject[20];


    void Start()
    {
        storageCapacity = gameObject.GetComponent<PlayerStats>().storageCapacity;
    }
    void Update()
    {
        if (Input.GetButtonDown("Inventory")) {
            Debug.Log(gameObject.GetComponent<PlayerStats>().level);
            for (int i = 0; i < storageIndicator; i++) {
                Debug.Log("Item: " + storage[i].name);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item" && storageIndicator < storageCapacity) {
            pickItem(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void pickItem(GameObject other) {
        storage[storageIndicator] = Instantiate(other);
        storageIndicator++;
    }
   



}

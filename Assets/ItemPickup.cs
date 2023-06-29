using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPickup : Interactable
{

    public Item item;
    public TextMeshProUGUI text;
    public GameObject obj;
    public ParticleSystem anim;
    public override void Interact() {
        base.Interact();
        PickUp();
    }

    float timer = 0;
    bool timerReached = false;

    // void Update() {
    //     if (!timerReached) {
    //         timer += Time.deltaTime;
    //     }

    //     if (!timerReached && timer > 5) {
    //         text.SetText("");
    //         timerReached = true;
    //     }
    // }

    void PickUp() {
        Debug.Log("Picking up " + item.name);
        text.SetText("Picked up " + item.name);
        // Waiter();

        
        bool pickedUp = Inventory.instance.Add(item);
        if (pickedUp) {
            Destroy(gameObject);
            anim.Play();
        }
        obj.SetActive(true);
    }

    // IEnumerator Waiter() {
    //     // float time = 0;
    //     // while (time < 50) {
    //     //     Debug.Log("We've waited for: " + time);
    //     //     time += Time.deltaTime;
    //     // }
    //     Debug.Log("In waiter()");
    //     yield return new WaitForSecondsRealtime(1);
    //     Debug.Log("After yielding");
    //     text.SetText("");
    //     Debug.Log("After setting text");
    // }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedObject : MonoBehaviour
{
    
    [SerializeField] private int price;
    [SerializeField] private TextMeshPro priceText;
    [SerializeField] private GameObject lockedObject;
    [SerializeField] private GameObject unLockedObject;

    private bool isPurchased;



    // Start is called before the first frame update
    void Start()
    {
        priceText.text = price.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collideObject) {

        if(collideObject.CompareTag("Player") && !isPurchased){

            unlockUnit();

        }
        
    }

    private void unlockUnit()
    {
        if(CashManager.instance.tryToBuy(price))
        {
            Unlock();
        }

    }

    private void Unlock()
    {
        isPurchased = true;
        lockedObject.SetActive(false);
        unLockedObject.SetActive(true);
    }
}

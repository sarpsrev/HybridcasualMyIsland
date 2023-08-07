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
    [SerializeField] private int IDOfunit;

    private bool isPurchased;
    private string keyUnit = "KeyUnit";



    // Start is called before the first frame update
    void Start()
    {
        priceText.text = price.ToString();
        loadUnit();
        
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
            saveUnit();
        }

    }

    private void Unlock()
    {
        isPurchased = true;
        lockedObject.SetActive(false);
        unLockedObject.SetActive(true);
    }

    private void saveUnit()
    {
       string key = keyUnit + IDOfunit.ToString();
       PlayerPrefs.SetString(key,"saved");
    }

    private void loadUnit()
    {
        string key = keyUnit + IDOfunit.ToString();
        string status = PlayerPrefs.GetString(key);

        if(status.Equals("saved"))
        {
            Unlock();

        }

    }
}

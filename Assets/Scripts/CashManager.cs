using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    private int coins;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(instance);
        }
        
    }

    public void AddCoin(int price)
    {
        coins += price;
        displayCoinOnScreen();
    }

    public void exchangeProduct(ProductDatas productDatas)
    {
        AddCoin(productDatas.productPrice);
        Debug.Log(coins);
    }

    private void displayCoinOnScreen()
    {
     UIManager.instance.ShowCoinOnScreen(coins);
    }

    private void SpendCoin(int price)
    {
        coins -= price;
        displayCoinOnScreen();
    }

    public bool tryToBuy(int price)
    {
        if(getCoins() >= price)
        {
          SpendCoin(price);
          return true;
        }
        return false;

    }

    public int getCoins()
    {
        return coins;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

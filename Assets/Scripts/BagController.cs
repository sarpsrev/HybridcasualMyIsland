using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BagController : MonoBehaviour
{
    [SerializeField] private Transform bag;
    [SerializeField] private TextMeshPro maxText;
    public List<ProductDatas> productList;
    private Vector3 productSize;
    int maxCapacity;

    // Start is called before the first frame update
    void Start()
    {
        maxCapacity=5;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collideObject) {
        if(collideObject.CompareTag("ShopPoint"))
        {
            for (int i = productList.Count-1; i >= 0; i--)
            {
                SellProducts(productList[i]);
                Destroy(bag.transform.GetChild(i).gameObject);
                productList.RemoveAt(i);
            }

            controlBagCapacity();

        }
        
    }

    private void SellProducts(ProductDatas productDatas)
    {
        CashManager.instance.exchangeProduct(productDatas);

    }

    public void addProductToBag(ProductDatas productDatas)
    {
        if (!isEmptySpace())
        {
            return;
        }
        
        GameObject boxProduct = Instantiate(productDatas.productprefab,Vector3.zero,Quaternion.identity);
        boxProduct.transform.SetParent(bag,true);

        CalculateObjectHeigth(boxProduct);

        float yPos = calculateNewPositionOfBox();

        boxProduct.transform.localRotation = Quaternion.identity;
        boxProduct.transform.localPosition = Vector3.zero;
        boxProduct.transform.localPosition = new Vector3(0,yPos,0);
        productList.Add(productDatas);
        controlBagCapacity();
    }

    private float calculateNewPositionOfBox()
    {
        float newYpos = productSize.y * productList.Count;
        return newYpos;

    }

    private void CalculateObjectHeigth(GameObject gameObject)
    {
        if(productSize == Vector3.zero)
        {
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        productSize = renderer.bounds.size;
        }
    }

    private void controlBagCapacity()
    {
        if(productList.Count == maxCapacity)
        {
            setMaxTextON();

        } 
        else
        {
            setMaxTextOFF();
        }

    }

    private void setMaxTextON()
    {
        if(!maxText.isActiveAndEnabled)
        {
        

        maxText.gameObject.SetActive(true);

        }
    }

    private void setMaxTextOFF()
    {
        if(maxText.isActiveAndEnabled)
        {
        maxText.gameObject.SetActive(false);

        }     
    }

    public bool isEmptySpace()
    {
        if(productList.Count<maxCapacity)
        {
            return true;
        }
        else

        return false;

    }
}

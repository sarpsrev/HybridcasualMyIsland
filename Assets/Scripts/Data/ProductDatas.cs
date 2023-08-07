using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProductType{tomato,cabbage}

[CreateAssetMenu(fileName = "ProductData", menuName = "ScriptableObject/ProductData", order = 0)]
public class ProductDatas : ScriptableObject 
{
    public GameObject productprefab;
    public ProductType productTypes;
    public int productPrice;
    
    
}



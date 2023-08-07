using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableProductController : MonoBehaviour
{
    private Vector3 originalScale;
    private float scaleSpeed = 100f;
    public Vector3 targetScale = new Vector3(0.25f, 0.25f, 0.25f);
    public bool isPicked=false;
    private BagController bagController;
    [SerializeField] private ProductDatas productDatas;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collideAnObject) 
    {
        if(collideAnObject.CompareTag("Player")&&!isPicked)
        {
            bagController = collideAnObject.GetComponent<BagController>();
            if(bagController.isEmptySpace())
            {
            bagController.addProductToBag(productDatas);

            isPicked=true;   
            StartCoroutine(productPicked());
            }
           
        }
    }

    // scale down tomato product with lerping

    IEnumerator productPicked()
    {
        float duration = 1f;
        float timer =0;

        while(timer < duration){

        float t = timer/duration;
        Vector3 newScale = Vector3.Lerp(transform.localScale, targetScale,t/scaleSpeed);
        transform.localScale = newScale;
        timer += Time.deltaTime;
        yield return null;
        }
        
        yield return new WaitForSeconds(5f);

        timer=0;    

        while(timer < duration){

        float t = timer/duration;
        Vector3 newScale = Vector3.Lerp(targetScale, originalScale,t);
        transform.localScale = newScale;
        timer += Time.deltaTime;
        yield return null;
        }
        isPicked = false;    
        
        yield return null;

         

    }


}

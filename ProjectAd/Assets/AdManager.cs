using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdManager : MonoBehaviour
{
    
    private void Awake()
    {
        Monetization.Initialize("3339048", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             /*ShowAdPlacementContent ad = Monetization.GetPlacementContent("video") as ShowAdPlacementContent;
             if (ad != null)
             {
                 ad.Show();
             }*/
             

            StartCoroutine(ShowAdWhenReady());

        }
    }

    IEnumerator ShowAdWhenReady()
    {
        while (!Monetization.IsReady("video"))
        {
            yield return null;
        }

        ShowAdPlacementContent ad = Monetization.GetPlacementContent("video") as ShowAdPlacementContent;
        if (ad != null)
        {
            ad.Show();
        }

    }
}

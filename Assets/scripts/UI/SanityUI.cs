using UnityEngine;
using UnityEngine.UI;

public class SanityUI : MonoBehaviour
{
    public Image sanityBar;

    public float currentSanity = 100;
    public float maxSanity = 100;

    void Update()
    {
        sanityBar.fillAmount = currentSanity / maxSanity;
    }
}

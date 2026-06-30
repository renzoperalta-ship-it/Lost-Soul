
using System.Collections;
using UnityEngine;
public class PLayerStates : MonoBehaviour
{
    [SerializeField] private float drainAmount = 1;
    [SerializeField] private float currentSanity = 100;

    private void Start()
    {
        StartCoroutine(SanityDrainRoutine());
    }
    private IEnumerator SanityDrainRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Sanity -= drainAmount;
        }
    }
    public float Sanity
    {
        get => currentSanity;
        set
        {
            float previous = currentSanity;

            currentSanity = Mathf.Clamp(value, 0, 100);

            if (previous > 50f && currentSanity <= 50f)
                Debug.Log("1er efecto visual de cordura baja");

            if (previous > 25f && currentSanity <= 25f)
                Debug.Log("2do efecto visual de cordura baja");
        }
    }
}

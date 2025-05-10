using UnityEngine;

public class CheckPointRing : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EffectManager.AssigneEffect(EffectEnum.TimeAugmentation, 5.0f);
        }
    }
    [ContextMenu("TryAddEffect")]
    public void TryAddEffect()
    {
        EffectManager.AssigneEffect(EffectEnum.TimeReduction, 10.0f);
    }
}

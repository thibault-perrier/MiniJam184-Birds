using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GateEffect
{
    public EffectEnum EffectType;
    public float Value;
    public GateEffect(EffectEnum effectType, float value)
    {
        EffectType = effectType;
        Value = value;
    }
}

public class CheckPointRing : MonoBehaviour
{
    [Header("All Gate Effect")]
    [SerializeField] private List<GateEffect> gateEffects;

    [Header("Internal params")]
    private GateEffect choisedEffect;
    private bool isActivated = false;

    [Space(10)]
    [Header("-1 is for the choice of random effect,")]
    [Header("otherwise enter the index of the desired choice ")]
    [SerializeField] private int forcedGateEffect = -1;

    public void OnTriggerExit(Collider other)
    {
        if (isActivated) { return; }
        if (other.CompareTag("Player"))
        {
            choisedEffect = TakeRandomEffect(forcedGateEffect);
            EffectManager.AssigneEffect(choisedEffect.EffectType, choisedEffect.Value);
            GateActivated();
        }
    }
    private GateEffect TakeRandomEffect(int forcedIndex = -1)
    {
        if (forcedIndex < 0)
        {
            int randomIndex = Random.Range(0, gateEffects.Count);
            return gateEffects[randomIndex];
        }
        if (forcedIndex >= gateEffects.Count)
        {
            print("Error Index is out of range");
            return new GateEffect(EffectEnum.NULL, -1);
        }
        return gateEffects[forcedIndex];
    }
    private void GateActivated()
    {
        isActivated = true;
        //make annim or something else
    }
    public void ResetGate()
    {
        isActivated = false;
        //return to original state
    }
    #region DEBUG
    [ContextMenu("TryAddEffect")]
    public void TryAddEffect()
    {
        choisedEffect = TakeRandomEffect(forcedGateEffect);
        EffectManager.AssigneEffect(choisedEffect.EffectType, choisedEffect.Value);
    }
    #endregion

}

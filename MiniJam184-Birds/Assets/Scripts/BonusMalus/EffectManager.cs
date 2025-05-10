using System;
using UnityEngine;

[RequireComponent(typeof(TimerManager))]
public class EffectManager : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private TimerManager timerManager;
    public EffectEnum effect;
    public float value;

    public static event Action<EffectEnum, float> OnEffectAssigned;
    public static void AssigneEffect(EffectEnum Effect, float Value)
    {
        OnEffectAssigned?.Invoke(Effect, Value);
    }

    private void Awake()
    {
        timerManager = GetComponent<TimerManager>();
    }

    #region Event manage
    private void OnEnable()
    {
        OnEffectAssigned += AddEffect;
    }
    private void OnDisable()
    {
        OnEffectAssigned -= AddEffect;
    }
    #endregion


    public void AddEffect(EffectEnum Effect, float Value)
    {
        effect = Effect;
        value = Value;
        ApplyEffect();
    }

    private void ApplyEffect()
    {
        switch (effect)
        {
            case EffectEnum.TimeReduction:
                timerManager.AddTime(-value);
                break;
            case EffectEnum.TimeAugmentation:
                timerManager.AddTime(value);
                break;

            default:
                break;
        }
    }
}

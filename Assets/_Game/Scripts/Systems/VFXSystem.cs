using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace GameSystems {
    public class VFXSystem : Singleton<VFXSystem> {
        [SerializeField] private ParticleSystem _GoldSplashVFX;
        [SerializeField] private ParticleSystem _StarsSplashVFX;
        [SerializeField] private ParticleSystem _LightShineVFX;

    
        public static void PlayerVFX_GoldSplash(Vector3 position) => Destroy(Instantiate(Instance._GoldSplashVFX, position, Instance._GoldSplashVFX.transform.rotation).gameObject, 0.8f);
        public static void PlayerVFX_StarsSplash(Vector3 position) => Destroy(Instantiate(Instance._StarsSplashVFX, position, Quaternion.identity).gameObject, 0.8f);
        public static void PlayerVFX_LightShine(Vector3 position) => Destroy(Instantiate(Instance._LightShineVFX, position + Vector3.up * 0.5f, Quaternion.identity).gameObject, 1f);
         
     
    }
}
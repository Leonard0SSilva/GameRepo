using UnityEngine;
using Studio.CoreInfra;
using Studio.ModuleAds;
using Studio.ModuleIAP;

namespace Studio.Game
{
    /// <summary>
    /// Bootstrap MonoBehaviour — attach this to a GameObject in your first scene.
    /// This is where the Game project wires up all module implementations
    /// into the ServiceLocator from Core-Infra.
    /// 
    /// This script is the ONLY place that knows about concrete implementations.
    /// All other game code should only reference interfaces from Core-Infra.
    /// </summary>
    public class GameBootstrap : MonoBehaviour
    {
        [Header("Ads Configuration")]
        [SerializeField] private string adsGameId = "1234567";
        [SerializeField] private bool adsTestMode = true;

        private void Awake()
        {
            // --- Register all services ---
            // The Game project is the composition root.
            // It knows about both Core-Infra (interfaces) AND the modules (implementations).

            // 1. Register Ads
            ServiceLocator.Register<IAdsService>(new UnityAdsService(adsGameId));

            // 2. Register IAP
            ServiceLocator.Register<IIAPService>(new UnityIAPService());

            Debug.Log("[GameBootstrap] All services registered. Game is ready!");
        }
    }
}

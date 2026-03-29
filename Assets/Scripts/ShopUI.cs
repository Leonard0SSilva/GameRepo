using UnityEngine;
using Studio.CoreInfra;

namespace Studio.Game
{
    /// <summary>
    /// Example gameplay script that uses the Ads and IAP services.
    /// Notice: this script ONLY references Core-Infra interfaces.
    /// It has zero knowledge of UnityAdsService or UnityIAPService.
    /// 
    /// This is the power of the architecture:
    /// - You can swap ads providers (AdMob, IronSource) without touching game code.
    /// - You can mock services for unit testing.
    /// </summary>
    public class ShopUI : MonoBehaviour
    {
        public void OnWatchAdButtonClicked()
        {
            var ads = ServiceLocator.Get<IAdsService>();

            if (ads.IsRewardedReady("rewarded_gems"))
            {
                ads.ShowRewarded("rewarded_gems", rewarded =>
                {
                    if (rewarded)
                    {
                        Debug.Log("[ShopUI] Player earned 50 gems from watching an ad!");
                        // Add gems to player inventory...
                    }
                });
            }
            else
            {
                Debug.Log("[ShopUI] Rewarded ad not ready yet.");
            }
        }

        public void OnBuyGemsButtonClicked()
        {
            var iap = ServiceLocator.Get<IIAPService>();

            iap.Purchase("com.studio.game.gems_100", success =>
            {
                if (success)
                {
                    Debug.Log("[ShopUI] Purchase successful! Adding 100 gems.");
                }
                else
                {
                    Debug.Log("[ShopUI] Purchase failed or cancelled.");
                }
            });
        }

        public void OnRestorePurchasesClicked()
        {
            var iap = ServiceLocator.Get<IIAPService>();

            iap.RestorePurchases(success =>
            {
                Debug.Log(success
                    ? "[ShopUI] Purchases restored successfully."
                    : "[ShopUI] Failed to restore purchases.");
            });
        }
    }
}

# Game Repo

The host Unity project that composes all modules together.

## Submodule Architecture

```
GameRepo/
├── Assets/
│   └── Scripts/
│       ├── GameBootstrap.cs    ← Composition root (registers all services)
│       └── ShopUI.cs           ← Example: uses IAdsService & IIAPService
├── Packages/
│   └── manifest.json           ← Links submodule packages via local file paths
└── Submodules/
    ├── Core-Infra/             ← Git Submodule (interfaces + ServiceLocator)
    ├── Module-Ads/             ← Git Submodule (IAdsService implementation)
    └── Module-IAP/             ← Git Submodule (IIAPService implementation)
```

## Key Rules
1. **Only GameBootstrap knows about concrete implementations.** All other game code uses Core-Infra interfaces.
2. **Core-Infra is NOT a submodule inside Module-Ads/IAP.** The Game project supplies it to all modules via UPM.
3. **To add a new module:** create a new UPM package repo, add it as a submodule here, and register it in `manifest.json` and `GameBootstrap.cs`.

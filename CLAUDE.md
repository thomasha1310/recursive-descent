# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**Recursive Descent** is a deck-building roguelike game built with **Unity 6000.3.10f1** (Unity 6 LTS). Slay the Spire-style deckbuilder with CS/programming humor and duck characters. Built at MIT Blueprint 2026 (8-hour hackathon). Authors: Thomas Ha, David Wang, Camille Opher, Maya Hazarika.

## Build & Development

- **Unity Version**: 6000.3.10f1 — open via Unity Hub
- **Solution files**: `recursive-descent.slnx` (modern format), `recursive-descent.sln`
- **C# 9.0** targeting **.NET 4.7.1**
- **Main scene**: `Assets/Scenes/MainScene.unity`
- **IDE support**: JetBrains Rider (primary), Visual Studio, VSCode
- No external build scripts, CI, or tests — build through Unity Editor (File → Build Settings → Build)
- **Scene rule**: ONE person owns the Unity scene. Everyone else works in scripts only to avoid merge conflicts.

## Architecture

### Core Pattern
Singleton managers orchestrate game flow. ScriptableObjects define all game data (cards, enemies, player classes). Abstract `Entity` base class provides shared logic for `Player` and `Enemy`. **GameManager is the middleman for all interactions** — UI never talks to Player directly, Player never talks to Enemy directly.

### Key Systems

**GameManager.cs** — Central singleton. All game logic flows through here. Holds references to Player, UIManager, RoomManager (resolved via `FindFirstObjectByType` in `Awake()`), and a `List<PlayerData>` for the three classes. Tracks run statistics via `RunStats`.

**Entity.cs** (abstract) → **Player.cs** / **Enemy.cs** — Entity handles HP, overconfidence (shield/block mechanic — absorbs damage before HP, resets to 0 each turn), status effects, damage multipliers, and death (`Die()` disables the GameObject). Player adds deck management (draw/shuffle/discard piles), energy system (3/turn), and card execution via `PlayCard(card, target, manager)` which calls `card.PerformAction()`. Enemy uses weighted random action selection via `DecideNextIntent()` and executes with `TakeAction(GameManager)` (skips if Suppressed). **TimmyBoss.cs** extends Enemy with 10 boss quotes.

**RoomManager.cs** — Linear room sequence (not a node graph): Fight → Fight → Chest → Fight → Fight → Bonfire → Boss. Generates encounters via HP budget allocation from enemy pools. Still TODO.

**UIManager.cs** — Manages 9 screens via `GameObject.Find()` in `Awake()`. Wires button listeners in code (not via Inspector). `Start()` shows the main menu. Uses `System.Action` callbacks for card clicks, enemy targeting, and reward selection.

**AudioManager.cs** — Singleton for sound effects. `PlaySFX()` not yet implemented.

### UI Wiring Pattern

All UI references are resolved via `GameObject.Find()` in `UIManager.Awake()` — no Inspector drag-and-drop. Button listeners are also added in `Awake()`:

- Screen GameObjects: `MainMenu`, `SelectCharacter`, `Map`, `Battle`, `Reward`, `Bonfire`, `Chest`, `Victory`, `GameOver`
- Buttons: `Start`, `Programmer`, `Hacker`, `VibeCoder`

### Data Layer (ScriptableObjects)

**Entity data:** `EntityData.cs` (abstract: entityName, flavorText, maxHealth) → `PlayerData.cs` (startingHand, startingDeck, playerClass enum, avatar) and `EnemyData.cs` (actionPool as `Dictionary<EnemyActionData, int>` for weighted actions).

**Card data:** `Card.cs` (abstract ScriptableObject: cardName, energyCost, flavorText, icon) defines `PerformAction(Player, Entity, GameManager)`. 15 concrete card subclasses in `ScriptableObjects/Cards/`. `CardButtonUI.cs` renders cards in hand (Setup TODO).

**Enemy AI:** `EnemyActionData.cs` (abstract: actionName) defines `PerformAction(Enemy, GameManager)`. 11 concrete actions in `ScriptableObjects/EnemyActions/`.

**Design note:** Potions (Boba, Coffee, White Monster, Banana) are just 0-cost cards — no separate potion system. Classes are just config swaps via `PlayerData` ScriptableObjects.

### Cards (15 total)

| Card | Cost | Effect |
|------|------|--------|
| Debugger | 1 | 6 damage |
| Printf | 1 | 8 damage |
| Refactor | 1 | 8 damage to ALL enemies |
| StaticAnalysis | 2 | 4 damage to all + Analyzed on target |
| ChatGPT | 3 | 80%: 20 damage / 20%: AISlop on self |
| ClaudeCode | 3 | 90%: AgenticAI on enemy / 10%: AISlop on self |
| CodeProfiler | 1 | Analyzed on target enemy |
| Breakpoint | 1 | Suppressed on random enemy + 4 overconfidence |
| SnackBreak | 1 | Draw 2 cards + 5 overconfidence |
| CrashOut | 0 | Lose all overconfidence + BurntOut on self |
| Boba | 0 | Heal 50% max HP |
| Coffee | 0 | +2 energy |
| WhiteMonster | 0 | Motivated on self |
| Banana | 0 | Strengthened on self |

### Enemies

| Enemy | HP | Attacks |
|-------|-----|---------|
| Mosquito | 10–16 | 75% MissingSemicolon (6-8), 25% UnterminatedString (10-12) |
| Moth | 28–32 | 70% Typo (6), 30% MissingRegistryKey (10) |
| Spider | 36–40 | 100% OnePlusTwo (12) |
| Cockroach | 48–52 | 50% CannotAccessMemory (16-20), 50% NullPointerException (12-16 + 6 overconfidence) |
| Timmy (Boss) | 167 | Bite (12), QuackQuack (12 overconfidence + AISlop), GoosePoop (Depressed), Hate6102 (Enraged self) |

### Rooms

| Room | Type | HP Budget | Expected Enemies |
|------|------|-----------|-----------------|
| 1 | Fight | ~30 | 2× Mosquito |
| 2 | Fight | ~50 | 1× Moth + 1× Mosquito |
| 3 | Chest | — | Pick 1 of 3 cards (weighted toward rarer) |
| 4 | Fight | ~45 | 1× Spider |
| 5 | Fight | ~70 | 1× Cockroach + 1× Mosquito |
| 6 | Bonfire | — | Rest → heal to full HP |
| 7 | Boss | 167 | Timmy the Goose |

### Player Classes

| Class | HP | Flavor |
|-------|-----|--------|
| Programmer Duck | 80 | "I use Vim, btw." |
| Hacker Duck | 75 | "I use Kali, btw." |
| Vibe Coder Duck | 67 | "What's an IDE???" |

### Game Flow

```
Start() → ShowScreen("menu")
  → Click Start → ShowScreen("character")
    → Click class button → StartNewRun(PlayerClass)
      → Player.Initialize(0, PlayerData) → reset stats → ShowScreen("map")
        → RoomManager.StartRun() → LoadRoom(room0)
          → GenerateEnemies(hpBudget) → StartBattle(enemyList)
            → StartPlayerTurn(): reset energy, reset overconfidence, draw 5, tick effects
              → UI renders hand → click card → click enemy target → PlayCard(card, target)
              → EndTurn → DiscardHand → StartEnemyTurn()
                → Each enemy: TakeAction(manager) → intent.PerformAction() → DecideNextIntent()
                → CheckBattleEnd() → loop or resolve
            → OnBattleWon() → card reward (pick 1 of 3) → AdvanceToNextRoom()
            → OnPlayerDied() → game over screen with stats
```

### Damage Pipeline

Outgoing: base damage × status multipliers (BurntOut -50%, Motivated/Enraged +200%, Strengthened +50%).
Incoming: damage × defensive multipliers (Depressed/Analyzed 2x) → absorbed by overconfidence first → remainder hits HP → death at 0.

### Status Effects (Enums.cs)

| Effect | Alias | Duration | Description |
|--------|-------|----------|-------------|
| Depressed | Analyzed | 1 turn | Takes 100% more damage |
| AISlop | AgenticAI | 3 turns | Random heal 5 or damage 10 each turn |
| Suppressed | — | 1 turn | Cannot act |
| BurntOut | — | 2 turns | 50% less damage, then auto-applies Motivated |
| Motivated | Enraged | 1 turn | 200% more damage |
| Strengthened | — | 1 turn | 50% more damage |

### Implementation Status

**Implemented:**
- Entity system: HP, overconfidence, status effects, damage multipliers, death
- Player: deck management (draw/shuffle/discard), energy, card playing via `card.PerformAction()`
- Enemy: weighted random action selection (`DecideNextIntent`), suppression check in `TakeAction`
- All 15 card effects (concrete Card subclasses)
- All 11 enemy action effects (concrete EnemyActionData subclasses)
- UI screen switching, button wiring, menu → character select → map flow
- Effect ticking with BurntOut→Motivated transition
- TimmyBoss: 10 quotes via `GetRandomQuote()`

**Still TODO:**
- RoomManager: `StartRun()`, `AdvanceToNextRoom()`, `LoadRoom()`, `GenerateEnemies()`
- GameManager: `StartBattle()`, `StartPlayerTurn()`, `OnEndTurnPressed()`, `StartEnemyTurn()`, `PlayCard()`, `CheckBattleEnd()`, `OnBattleWon()`, `OnPlayerDied()`, `GetRunStats()`
- UIManager: `UpdatePlayerUI()`, `UpdateEnemyUI()`, `RefreshHand()`, `HighlightEnemies()`, battle UI wiring, reward/bonfire/end screens
- CardButtonUI: `Setup()` display logic
- AudioManager: `PlaySFX()` implementation
- TimmyBoss: override `TakeAction` to show quotes during combat

## Code Conventions

- No namespaces — all classes at root level
- `[SerializeField]` private fields for Unity Editor configuration; no public data members on MonoBehaviours
- Singleton pattern via static `Instance` property on managers
- Manager references resolved via `FindFirstObjectByType` in `GameManager.Awake()`
- UI references resolved via `GameObject.Find()` in `UIManager.Awake()`, not Inspector assignment
- Button listeners added in code via `onClick.AddListener()`, not Inspector OnClick()
- `System.Action` delegates for UI callbacks (not UnityEvents)
- `[CreateAssetMenu]` on concrete ScriptableObjects for asset creation
- No coroutines — all game flow is synchronous/turn-based
- Game balance tunable via ScriptableObject assets in `Assets/Scripts/ScriptableObjects/`
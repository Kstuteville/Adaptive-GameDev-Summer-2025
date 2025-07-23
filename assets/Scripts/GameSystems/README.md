# Game System

This folder contains standalone scripts that demonstrate key systems in the adaptive boss fight design.

## Files

- `boss_logger.cs`: Logs player/boss events to the console using JSON structure.
- `fsm_boss.cs`: Contains a basic finite state machine (FSM) for the boss handling states idle, Chase, Attack, Rage etc.
- `adaptive_hit_trigger.cs`: Monitors player hit frequency and triggers the Rage state if conditions are met.

## How to Use

1. Create a new Unity scene.
2. Add an empty GameObject and attach all three scripts (`BossLogger`, `BossFSM`, `AdaptiveHitTrigger`).
3. Wire the script references in the Inspector:
   - Drag `BossLogger` into `BossFSM` and `AdaptiveHitTrigger`.
   - Drag `BossFSM` into `AdaptiveHitTrigger`.
4. Manually call `RegisterHit(damage)` from a button press or simulated attack.

## Example Trigger

Simulate 3 hits in under 5 seconds:

```csharp
adaptiveHitTrigger.RegisterHit(10f);
adaptiveHitTrigger.RegisterHit(8f);
adaptiveHitTrigger.RegisterHit(12f);

New Features
Update 7/23 --> 
- Attack Accuracy : Tracks successful vs. total player attacks to calculate hit accuracy. Each attack will log whether it hit or missed.
Dodge frequency: Tracks total dodges and successful dodges to calculate dodge success rate. Each dodge will log whether it was successful or not.


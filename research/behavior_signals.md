# Player Behavior Signals for Boss AI

## Overview
This document outlines key behavioral signals a boss NPC can use to adapt dynamically to player actions.

## Signal–Response Mapping
| Player Behavior         | Detected Signal              | Boss Response          |
|-------------------------|------------------------------|------------------------|
| Rapid hits in short time | High DPS burst               | Enter Rage Mode        |
| Frequent dodges         | Dodge frequency threshold    | Delay or feint attack  |
| Long-range kiting       | Distance-based trigger       | Chase mode or ranged attack |
...

## Theoretical Motivation
- Emotional engagement through reactive AI
- Avoids repetition and player exploitation of patterns



### sample_playtest.json explanation

This file contains a structured log of player behavior during a playtest session.

- `player_id`: unique identifier for the player
- `session_start`: UTC ISO timestamp
- `events`: array of timestamped events that occurred during the session

Event types may include:
- `"hit_boss"`: player dealt damage to boss
- `"dodge"`: player used dodge mechanic
- `"heal"`: player initiated healing
- `"boss_state_change"`: boss entered a new FSM state (e.g. rage, defend)

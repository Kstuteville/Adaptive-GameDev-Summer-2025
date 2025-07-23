# Adaptive Game Dev Summer 2025 🌿🎮
Research & prototyping repo for exploring adaptive gameplay systems, player modeling, and AI-driven NPCs — in preparation for my MFA thesis project at NYU IDM.

---

## 🎯 Goals
- Build a series of small prototypes focused on adaptive difficulty, NPC behavior, and emotion-responsive systems
- Explore how games can dynamically change based on player skill, playstyle, and emotional decisions
- Research procedural content generation (PCG), player modeling, and machine learning applications in games
- Develop a vertical slice of an AI-driven boss fight or branching NPC interaction by Fall 2025

---

## 🗓️ Weekly Plan
| Week | Focus |
|------|-----------------------------|
| 1 | Research: Player Modeling + Adaptive NPCs |
| 2 | Unity: Core Movement + Combat |
| 3 | Prototype: Adaptive Boss Fight |
| 4 | Skill Tracking + Logging Systems |
| 5 | NPC Disposition System + Story Work |
| 6 | Player Classifier with ML |
| 7 | NPC Dialogue System |
| 8 | Cinematic Scene Design |
| 9 | Lit Review + Writing |
| 10 | Vertical Slice Polish |

---

## 📂 Folder Structure

```bash
adaptive-game-design-summer/
├── README.md                   # Project overview and setup instructions
├── docs/                       # Dev logs, changelogs, and documentation
│   ├── devlog.md
│   └── changelog.md
├── ai/                         # AI system planning and pseudocode (NOT Unity scripts)
│   ├── adaptive_fsm.md         # Notes on adaptive finite state machines
│   ├── npc_disposition_logic.md
│   └── threat_eval_diagram.drawio
├── design/                     # Game design documents and concept references
│   ├── core_game_loop.md
│   ├── environment_layout.md
│   └── exorcist_visuals_ref.png
├── research/                   # Academic readings, citations, NLP/AI sources
│   ├── annotated_bibliography.md
│   └── player_modeling_papers/
│       └── smith2020_player_types.pdf
├── Assets/
│   ├── Art/                    # Concept art, sprites, models, etc.
│   ├── Audio/                  # Sound effects and music
│   ├── Prefabs/                # Unity prefabs
│   ├── Scenes/                 # Unity scenes
│   ├── Scripts/
│   │   ├── AI/                 # Actual Unity AI behavior scripts
│   │   │   ├── BossBehaviorController.cs
│   │   │   ├── NPCBehaviorController.cs
│   │   │   └── NPCMovementController.cs
│   │   ├── GameSystems/        # Core gameplay systems
│   │   │   ├── AdaptiveHitTrigger.cs
│   │   │   ├── BossLogger.cs
│   │   │   ├── BossFSM.cs
│   │   │   └── GameController.cs
│   │   ├── Player/             # Player controls and health
│   │   │   ├── PlayerController.cs
│   │   │   └── PlayerHealthManager.cs
│   │   └── UI/                 # UI behavior scripts
│   │       ├── SkillMetricsUI.cs
│   │       ├── MainMenuUI.cs
│   │       └── PauseMenuUI.cs
│   └── Textures/               # Textures and materials
└── ProjectSettings/           # Unity project settings


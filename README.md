# OpenARPG

An open-source Action RPG built with C# and Raylib-cs.

## 🚀 Quick Start

### Prerequisites
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) (Preview)
- Git

### Building and Running

1. **Clone the repository:**
   ```bash
   git clone https://github.com/JeremySayers/open-arpg.git
   cd open-arpg
   ```

2. **Build the solution:**
   ```bash
   dotnet build
   ```

3. **Run the game:**
   ```bash
   cd src/OpenARPG
   dotnet run
   ```

## 🏗️ Current Project Structure

Our architecture follows a modular design with clear separation of concerns:

```
src/
├── OpenARPG/                    # Main executable project
│   ├── Program.cs              # Entry point
│   ├── Game.cs                 # Main game class with game loop
│   └── OpenARPG.csproj
├── OpenARPG.Core/              # Core game systems
│   ├── IGame.cs                # Interface for main game instance
│   └── States/
│       ├── IGameState.cs       # State interface
│       └── GameStateManager.cs # State management system
├── OpenARPG.States/            # Game state implementations
│   ├── MainMenuState.cs        # Main menu implementation
│   └── OpenARPG.States.csproj
└── OpenARPG.UI/                # UI components
    ├── Button.cs               # Interactive button component
    └── OpenARPG.UI.csproj
```

### Project Dependencies

```
OpenARPG (main)
├── OpenARPG.Core
├── OpenARPG.States
│   ├── OpenARPG.Core
│   └── OpenARPG.UI
└── OpenARPG.UI
```

## 🎯 Current Features

- **State Management System**: Clean state machine for handling different game screens
- **Main Menu**: Functional main menu with Play, Settings, and Exit buttons
- **Modular Architecture**: Well-organized project structure for scalability
- **Raylib Integration**: Hardware-accelerated graphics using Raylib-cs

## 🔮 Planned Architecture Expansion

As the game grows, we plan to expand the architecture with additional specialized projects:

### Planned Projects

```
src/
├── OpenARPG/                    # Main executable
├── OpenARPG.Core/              # Core systems (✅ Implemented)
├── OpenARPG.States/            # State implementations (✅ Implemented)
├── OpenARPG.UI/                # UI components (✅ Implemented)
├── OpenARPG.Rendering/         # 3D rendering systems (🔄 Planned)
│   ├── ModelRenderer.cs
│   ├── PlayerRenderer.cs
│   ├── Camera/
│   │   ├── Camera3D.cs
│   │   └── CameraController.cs
│   └── Materials/
├── OpenARPG.Entities/          # Game objects (🔄 Planned)
│   ├── Player.cs
│   ├── Entity.cs
│   ├── Enemy.cs
│   └── Components/
│       ├── Transform.cs
│       ├── Renderable.cs
│       └── Health.cs
├── OpenARPG.World/             # World/level systems (🔄 Planned)
│   ├── Zone.cs
│   ├── ZoneManager.cs
│   ├── Level/
│   │   ├── LevelGeometry.cs
│   │   └── LevelLoader.cs
│   └── Physics/
│       └── CollisionSystem.cs
├── OpenARPG.Gameplay/          # Game mechanics (🔄 Planned)
│   ├── Combat/
│   │   ├── CombatSystem.cs
│   │   └── DamageCalculator.cs
│   ├── Skills/
│   └── Inventory/
└── OpenARPG.Content/           # Assets (🔄 Planned)
    ├── Models/
    ├── Textures/
    └── Zones/
```

### Planned Features

- **3D Player Rendering**: Load and render 3D player models
- **Combat Zones**: Interactive 3D environments for gameplay
- **Combat System**: Turn-based or real-time combat mechanics
- **Inventory System**: Item management and equipment
- **Skill Trees**: Character progression system
- **Zone System**: Multiple game areas with seamless transitions

## 🏛️ Architecture Principles

### Current Implementation

1. **State Pattern**: Clean state management using `IGameState` interface
2. **Dependency Injection**: Loose coupling through interfaces (`IGame`)
3. **Separation of Concerns**: Each project has a specific responsibility
4. **Modular Design**: Easy to add new features without breaking existing code

### Design Goals

- **Testability**: Each component can be unit tested independently
- **Maintainability**: Clear organization makes code easy to find and modify
- **Scalability**: Architecture supports adding new systems without major refactoring
- **Reusability**: Core systems can be reused across different game modes

## 🛠️ Development

### Adding New Game States

1. Create a new class in `OpenARPG.States` implementing `IGameState`
2. Register the state in `Game.cs` → `RegisterStates()` method
3. Add state transition logic where needed

### Project Structure Guidelines

- **OpenARPG.Core**: Fundamental systems used by multiple projects
- **OpenARPG.States**: Game flow and screen management
- **OpenARPG.UI**: User interface components
- **OpenARPG.Rendering**: Graphics and visual systems (planned)
- **OpenARPG.Entities**: Game objects and their behavior (planned)
- **OpenARPG.World**: Level, zone, and environment systems (planned)
- **OpenARPG.Gameplay**: Game rules and mechanics (planned)

## 📦 Dependencies

- **Raylib-cs 7.0.1**: Cross-platform graphics library
- **.NET 10.0**: Modern C# runtime and framework

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Follow the established architecture patterns
4. Add tests for new functionality
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🎮 Current Status

**Version**: 0.1.0-alpha  
**Status**: Early Development  
**Playable**: Main menu functional, core architecture established
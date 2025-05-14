# LARP

LARP is a physics-based puzzle game built with Unity and C#. Players interact with a variety of objects and mechanisms to solve creative challenges in dynamic environments.

[Playable Demo](https://drive.google.com/file/d/1QScB3-Qq4W7ORnviJusRnSTldLMtKOHX/view?usp=sharing)

## Core Technologies

- Unity Engine
- C#
- Unity UI Toolkit
- Custom physics and interaction scripts

## Getting Started

### Prerequisites

- Unity Editor 2021.3 LTS or newer
- .NET Framework 4.x (installed with Unity)
- Windows 10/11 (development and play)

### Installation

1. Clone this repository:
   ```powershell
   git clone https://github.com/yourusername/LARP.git
   ```

## Components Overview

Below is a detailed summary of each component in the `src/` directory and its functionality:

- **AirBellow.cs**: Implements a mechanical air bellow that, when activated, emits a strong burst of air. This force can push or move nearby objects, and is often used in puzzles requiring indirect manipulation of items.
- **AirBellowAirZone.cs**: Defines the spatial zone affected by the air bellow. Objects within this zone experience the air force, and the script manages entry/exit detection and force application.
- **AirBellowTriggerArea.cs**: Handles detection of objects or player actions that trigger the air bellow. It ensures the bellow only activates under specific conditions, such as a button press or object placement.
- **AudioSourceSampleData.cs**: Provides real-time access to audio sample data from an AudioSource. Used for visualizations, dynamic sound effects, or gameplay elements that react to audio.
- **Balloon.cs**: Represents a balloon with realistic buoyancy, inflation/deflation, and popping mechanics. Balloons can lift objects, be popped by sharp items, or interact with wind sources.
- **BarMagnet.cs**: Simulates a bar magnet with north and south poles. It generates a magnetic field, attracting or repelling objects marked as magnetizable, and can be rotated or moved in puzzles.
- **BaseBall.cs**: Implements a baseball object with realistic physics, including spin, bounce, and collision detection. Used in levels requiring precise throwing or hitting mechanics.
- **BasicButton.cs**: A simple interactive button that can be pressed by the player or objects. Triggers events such as opening doors, activating machines, or starting sequences.
- **BasicButtonSwitchTriggerArea.cs**: Detects when objects enter the activation area of a button switch, ensuring only valid interactions trigger the button.
- **BoxingGloveRod.cs**: Controls a spring-loaded boxing glove mounted on a rod. When triggered, the glove extends rapidly to strike or push objects, often used for chain reactions.
- **Bullet.cs**: Represents a projectile fired from guns or cannons. Handles movement, collision detection, and effects such as damage or ricochet.
- **Bumper.cs**: Simulates a pinball-style bumper that bounces objects with force upon contact. Used to redirect objects or add challenge to levels.
- **Candle.cs**: Represents a candle with a flame that can be lit or extinguished. The flame can ignite flammable objects or trigger light-based puzzles.
- **CandleTriggerArea.cs**: Detects when objects interact with a candle's flame, such as lighting another object or being extinguished by water.
- **CannonTriggerArea.cs**: Defines the area where objects or player actions can trigger a cannon to fire, ensuring safe and intentional activation.
- **ConnectionPoint.cs**: Manages points where objects can be connected or assembled, such as linking rods or attaching components in construction puzzles.
- **ConveyorBeltTriggerArea.cs**: Detects objects on a conveyor belt and moves them at a set speed. Used for transporting items or timing-based challenges.
- **Dynamite.cs**: Represents a stick of dynamite with a fuse. Can be ignited, counts down, and explodes, affecting nearby objects and environment.
- **DynamiteTriggerArea.cs**: Detects when dynamite should be triggered, such as by flame, impact, or timer, and manages the explosion sequence.
- **Fan.cs**: Simulates a fan that generates a continuous wind force, moving lightweight objects or affecting balloons and other physics elements.
- **FanWindZoneTriggerArea.cs**: Defines the area affected by a fan's wind, applying force to objects within the zone and managing entry/exit events.
- **Flammable.cs**: Marks objects as flammable, allowing them to catch fire when exposed to flames. Handles burning, extinguishing, and destruction logic.
- **Flashlight.cs**: Represents a handheld flashlight with toggling, battery depletion, and light cone logic. Used for illuminating dark areas or solving light-based puzzles.
- **FlashlightRod.cs**: Controls a flashlight mounted on a rod, allowing for remote or automated lighting in specific directions.
- **Gun.cs**: Implements gun mechanics, including aiming, firing bullets, reloading, and handling recoil. Used in action or target-based puzzles.
- **IgnoreCollisions.cs**: Prevents collisions between specified objects, useful for overlapping UI elements or special gameplay mechanics.
- **Inventory.cs**: Manages the player's inventory, allowing items to be picked up, stored, and used. Handles item stacking, limits, and quick access.
- **InventoryOutOfBoundsZone.cs**: Detects when inventory items leave the playable area, triggering respawn or loss logic to prevent exploits.
- **InventorySlot.cs**: Represents a single slot in the inventory UI, managing item display, selection, and drag-and-drop operations.
- **InventoryUI.cs**: Handles the overall inventory user interface, including layout, updates, and player interactions.
- **Laser.cs**: Simulates a laser beam with real-time collision, reflection, and refraction. Used for puzzles involving mirrors, sensors, or light paths.
- **LightBulb.cs**: Represents a light bulb that can be turned on/off or broken. Used for lighting puzzles or as a destructible object.
- **Magnetizable.cs**: Marks objects as affected by magnetic fields, allowing them to be attracted or repelled by magnets.
- **MainMenuUIController.cs**: Controls the main menu interface, including navigation, settings, and starting new games.
- **MouseoverTooltip.cs**: Displays contextual tooltips when hovering over objects, providing hints or information to the player.
- **MovingPlatform.cs**: Controls platforms that move along predefined paths, supporting timed or triggered movement for platforming challenges.
- **ObjectTrajectoryTracker.cs**: Tracks and visualizes the path of moving objects, useful for debugging or gameplay features like aiming.
- **Outlet.cs**: Represents an electrical outlet that can power devices when connected, used in electrical circuit puzzles.
- **OutOfBoundsZone.cs**: Detects when objects leave the playable area, triggering respawn, loss, or failure conditions.
- **PinballFlipper.cs**: Simulates a pinball flipper, allowing the player to launch or redirect objects with precise timing.
- **PlaceableObject.cs**: Base class for all objects that can be placed in the scene, providing common placement and interaction logic.
- **PlayLevelUIController.cs**: Manages the user interface during level play, including timers, objectives, and feedback.
- **PlayZoneObjectSpawner.cs**: Spawns objects within the play zone, supporting randomization or scripted sequences.
- **Portal.cs**: Implements portals that teleport objects from one location to another, preserving momentum and orientation.
- **PortalTraveller.cs**: Handles the logic for objects traveling through portals, ensuring smooth transitions and correct physics.
- **Reflective.cs**: Marks objects as reflective, allowing them to reflect lasers or light beams for puzzle solutions.
- **RelayIn.cs**: Receives signals in relay-based logic circuits, enabling complex event chains or automation.
- **RelayOut.cs**: Sends signals in relay-based logic circuits, triggering connected devices or events.
- **RequiredObjectArea.cs**: Detects when required objects are placed in a specific area, used for completion or progression checks.
- **RequiredTrigger.cs**: Triggers events when all required conditions or objects are present, advancing puzzles or levels.
- **Rocket.cs**: Simulates a rocket with launch, flight, and explosion mechanics, used for dynamic or destructive puzzles.
- **SceneInformation.cs**: Stores metadata about the current scene, such as objectives, settings, or progress.
- **SpeechMaterial.cs**: Handles objects or materials that can play speech audio, used for narration, hints, or story elements.
- **Spinner.cs**: Controls objects that spin or rotate, either continuously or when triggered.
- **Switch.cs**: Implements a switch for toggling devices, doors, or circuits, supporting both momentary and toggle modes.
- **TextInputSimulator.cs**: Simulates text input for UI or gameplay, allowing automated or scripted entry of text.
- **Timescale.cs**: Controls the game's timescale, enabling slow-motion or speed-up effects for dramatic or puzzle moments.
- **TrajectoryRecorder.cs**: Records and replays the trajectories of objects, useful for analysis, tutorials, or undo features.
- **Transparent.cs**: Marks objects as transparent, affecting rendering, interaction, or puzzle visibility.
- **TrapDoor.cs**: Simulates a trap door that can open or close, used for secret passages or hazards.
- **UILevelButton.cs**: Represents a button in the UI for selecting levels, displaying level status and progress.
- **UIPanelMovement.cs**: Handles the movement and animation of UI panels, supporting smooth transitions and feedback.
- **UIPlayButton.cs**: Represents the play button in the UI, starting levels or gameplay sessions.
- **VictoryChecker.cs**: Checks if all victory conditions are met in a level, triggering win sequences or rewards.
- **VictoryCondition.cs**: Defines the specific conditions required to win a level, such as object placement or time limits.

## License

See [LICENCE.md](LICENCE.md) for details.

## Code of Conduct

Please read [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md) for guidelines on contributing respectfully.

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for instructions on how to contribute to this project.

## Security

For security issues, please refer to [SECURITY.md](SECURITY.md).

## Support

For help or questions, open an issue in this repository or contact the maintainers.

## Contact

- joaquintelleria@gmail.com

## Acknowledgements

- Unity Technologies for the game engine
- Open source contributors
- Playtesters and community feedback

# WEAPON SYSTEM
A modular and scalable weapon system for Unity 3D, designed with clean architecture and robust design patterns for maintainability, flexibility, and ease of integration.
---

## Features

- Custom FPS Controller
    - Designed from scratch to deliver smooth and immersive first-person movement.
    - Includes core mechanics like:
         - Jumping
         - Responsive camera controls for fluid gameplay.
- Scalable Weapon System
    - Each weapon is fully customizable, supporting the following properties:
        - Reload Time
        - Fire Rate
        - Magazine Capacity
        - Total Ammo Capacity
        - Unique Particle Effects

- Immersive Gameplay Elements
    - Weapon Sway: Adds realism by simulating movement during player actions.
    - Aiming with Crosshair: Provides precise and dynamic targeting.
    - Raycasting for Bullets: Enables instant-hit mechanics for efficient and realistic shooting.
    - Weapon Switching: Smooth transitions between multiple weapons for enhanced player experience.
- Audio-Visual Feedback
    - Sound Effects: Integrated sound for shooting, reloading, and weapon switching.
    - Particle Systems: Adds dynamic shooting effects for improved visual feedback.
---
## Patterns Used
1. MVC (Model-View-Controller)

- The game's core architecture is based on the MVC pattern:

    - Model: Manages weapon properties and player interactions.
    - View: Updates the UI and reflects the weapon's current state (e.g., crosshair position, ammo count).
    - Controller: Handles input, connects the Model and View, and coordinates player interactions.

2. Service Locator Pattern

    - Provides centralized access to essential services like PlayerService, weapon management, and sound.
    - Ensures a decoupled architecture by avoiding direct dependencies between components.

---
## SCREENSHOTS
![Screenshot (14)](https://github.com/user-attachments/assets/6d77bc3a-8b46-4c14-96b9-71f89c8a3a5b)
![Screenshot (15)](https://github.com/user-attachments/assets/1f078c32-d592-4f36-8c36-84c553550b7e)
![Screenshot (16)](https://github.com/user-attachments/assets/c2f04075-c66b-4e14-b6ec-3545c76bd7fa)

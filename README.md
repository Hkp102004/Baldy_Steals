# Baldy Steals

A 3D stealth game developed in Unity and C# where the player takes on the role of a thief attempting to steal from an auction house while avoiding guards, security cameras, and detection.

## About the Game

Baldy Steals is an ongoing 3D game development project focused on combining stealth gameplay with AI, navigation, animation, cinematics, lighting, and audio.

The player must navigate through an auction house, avoid security systems, and escape without being caught. Guards use AI-driven navigation and patrol systems to move through the environment, requiring the player to carefully plan their movement and avoid detection.

The project also focuses heavily on cinematic presentation, with multiple cutscenes, camera movements, animations, lighting, sound effects, and background music being used to create a more immersive experience.

## Gameplay

The player controls a thief attempting to steal valuable items from an auction house.

Movement is controlled through a click-to-move system. The game uses raycasting to detect where the player clicks and determine the target position for movement.

While navigating the environment, the player must:

- Avoid patrolling guards
- Avoid security cameras
- Navigate around the environment without being detected
- Reach objectives and progress through the game
- Escape after completing the objective

Getting caught by the guards or security systems can result in failure.

## AI & Navigation

One of the main focuses of the project is developing AI-driven guards.

The guards use Unity's `NavMeshAgent` system to navigate the environment and follow predefined patrol routes.

The AI system includes:

- NavMesh-based navigation
- Waypoint-based patrol paths
- Guard movement between different areas
- AI-driven navigation around the environment
- Player detection and stealth gameplay interactions

The patrol system allows guards to move through the environment while giving the player opportunities to plan their route and avoid detection.

## Player Movement

The player uses a click-to-move movement system rather than traditional keyboard movement.

When the player clicks on the environment, a raycast is used to determine the position that was clicked. The player can then move toward that location.

This system was implemented to create a more strategic movement style that fits the stealth gameplay.

## Cinematics

Baldy Steals includes multiple cinematic sequences designed to make the game feel more like a complete experience rather than simply a collection of gameplay mechanics.

The project uses:

- Unity Timeline
- Cinemachine
- Multiple camera setups
- Camera panning and movement effects
- Character animations
- Scene-based cutscenes
- Timed cinematic sequences

Timeline is used to organize and control different elements during cutscenes, while Cinemachine is used to create and manage cinematic camera shots.

## Animation

The project includes 3D character animations for both gameplay and cinematic sequences.

Animations are used to improve character presentation and make gameplay and cutscenes feel more dynamic and engaging.

## Lighting

Lighting is used throughout the environment to improve the atmosphere and visual presentation of the game.

Different lighting setups are used to support gameplay areas as well as cinematic sequences.

## Audio

The game includes:

- Sound effects
- Background music
- Audio during gameplay
- Audio used within cinematic sequences

Audio is used to make the environment and cutscenes feel more immersive and to improve the overall presentation of the game.

## Key Features

- 3D stealth gameplay
- AI-driven guards
- NavMeshAgent navigation
- Waypoint-based guard patrols
- Security cameras
- Click-to-move player controls
- Raycast-based movement
- 3D character animations
- Cinematic cutscenes
- Unity Timeline
- Cinemachine camera systems
- Camera panning effects
- Lighting and environmental atmosphere
- Sound effects and background music

## Built With

- Unity
- C#
- Unity NavMesh
- NavMeshAgent
- Unity Timeline
- Cinemachine
- Unity Physics / Raycasting
- Unity Animation System
- Unity Lighting
- Unity Audio System
- Git & GitHub

## What I Learned

Working on Baldy Steals has allowed me to gain practical experience with more advanced game development systems, including:

- Developing AI-driven gameplay
- Working with NavMeshAgent
- Creating waypoint-based patrol systems
- Implementing raycast-based player movement
- Building cinematic sequences with Timeline
- Working with Cinemachine
- Integrating 3D animations
- Designing lighting for gameplay and cinematics
- Implementing audio and background music
- Managing a larger Unity project
- Combining multiple gameplay systems into a cohesive experience

## Project Status

**In Development**

Baldy Steals is an ongoing project, and new gameplay systems, improvements, and content are still being developed.

## Author

**Harsh**

Baldy Steals is a personal game development project created as part of my journey toward becoming a Game Developer.

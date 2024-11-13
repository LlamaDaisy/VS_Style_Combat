# Vampire Survivors Style Combat

# Introduction
This Vampire Survivors-like is a 2D Combat Mini Game that focuses on player progression and dynamic combat mechanics. The core focus of this proof of concept is the modular augment system that allows players to upgrade their abilities as they advance through waves of enemies. 

# Main Features
- **Player Progression & Levelling System**
  - Players collect XP dropped by enemies, which fills a progression bar. Once filled, players can select a new augment to upgrade their projectile attacks.
- **Dynamic Augment System**
  - The augment system is designed to be highly modular, allowing flexibility for different playstyles. Augments are managed through dictionaries of “available augments” and “active augments.” This structure supports a wide range of augment options, effectively controlling which augments are applied. Each augment can modify the player's attack stats and add special effects upon impact, such as ice slowing enemies or fire causing DoT.
- **Modular Projectile Behaviour**
  - Player attacks are handled through a projectile-based system. Projectiles are managed using Object Pools, enabling them to be instantiated dynamically with active augments. This system supports multiple simultaneous augments while maintaining performance.


# Context

This project was created as an early prototype for a larger demo that will feature multiple mini-game style elements. This Vampire Survivors-like combat mini-game was specifically designed to be flexible and modular, enabling easy testing of different augments and crafting engaging, dynamic gameplay.

# [Documentation](https://docs.google.com/document/d/1wp5byKj90SKrG8_BhgHMYuFO_uBuvTmnu_3Y6dbmXUM/edit?usp=sharing)

# Overview

RDSBot is a Discord bot designed to work with Text Adventure Hub's RDS system. It will automatically roll to determine rooms, loot, monsters, etc., saving GMs a lot of hassle and de-cluttering the chat!

RDSBot is fully open-source and licensed under **GNU General Public License v3.0**.

## Download

To download RDSBot, you may navigate to the Releases page and download the latest release. Then, extract the .zip file and go into the Config folder. Enter in your token in `token.txt` and that's it! You can change your configuration in Discord.

By default, RDSBot uses the prefix `#`.

## Commands
A list of all available commands can be viewed in Discord using `commands`.
### Configuration
Currently, RDSBot supports the following configuration options. The current value can be shown with `config get [item]` and set with `config set [item] [value]`.
- `version` (read-only)
- `prefix`
### Generators
A running list of the state of generators is available at https://github.com/Shadowtail117/RDSBot/projects/1.
#### Implemented
- Room generator
  - `room`
- Loot generator
  - `loot [common/rare/cursed]`
#### Planned
- Boss generator
- Monster generator
- Altar generator
- Curse generator
- Disease generator
- Painting generator
- Deity generator
- Hex generator
- Drug generator
- Reagent generator
- Room theme generator
- Shop/trader generator
- Trap generator
- Object/miscellaneous item generator

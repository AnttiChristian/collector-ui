[Station](../../../README.md) - [docs](../../index.md) - [formats](../index.md) - [binary](./index.md) - amstrad-cpr.md

# Format: LNX Atari lYNX cartridge file format
## ".LNX" Atari Lynx file data structure


## A78 Header Fields
|Offset|Size|Description|
|---|---|---|
|0|4|magic string|
|4|2|Bank 0 page size|
|6|2|Bank 1 page size|
|8|2|Version number|
|10|32|cart name|
|42|16|manufacturer name|
|58|1|Rotation|
|59|1|AUDIN used|
|60|1|EEPROM type|
|61|3|reserved|


## Field details
### Rotation
* 0 - none
* 1 - left
* 2 - right


### EEPROM type
 * 0 = type
 * 1 = type
 * 2 = type
 * 3 = unused
 * 4 = unused
 * 5 = unused
 * 6 = real/sd save
 * 7 = 8/16 bit

EEPROM Type values - 0: no EEPROM, 1: 93C46 2: 93C56, 3: 93C66, 4: 93C76, 5: 93C86

EEPROM size is 2^(type+9) e.g. 2^(1+9) = 1024 bits for 93C46

Lynx is little-endian so bit order is reversed.

## External links
[Atari gamer](https://atarigamer.com/lynx/lnx2lyx)
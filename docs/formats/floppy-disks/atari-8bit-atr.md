[Station](../../../README.md) - [docs](../../index.md) - [formats](../index.md) - [floppy-disks](./index.md) - atari-8bit-atr.md

# Format: ATR Atari 800 floppy disk file format
## ".ATR" Atari 800 floppy disk file format
Nick Kennedy's SIO2PC Atari Disk Image format. This is the most popular disk 
image, used by APE, SIO2PC, and all Atari emulators. There are minor differences 
in the header use between these programs, but the images remain compatible 
regardless of what program they are created with.

### Header


### Data


### Remardks
SD (single denstity) disks = 1 side => 40 tracks => 18 sectors => 128 bytes (FM encoding)
ED (enhanced density) disks = 1 side => 40 tracks => 26 sectors => 128 bytes (MFM encoding)
DD (double density) disks = 1 sides => 40 tracks => 18 sectors => 256 bytes (MFM encoding)

All disks can have recorded both side so you have to flip the disk if drive does not support 
reading from both sides simultaneously.
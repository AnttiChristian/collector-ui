[Station](../../../README.md) - [docs](../../index.md) - [formats](../index.md) - [binary](./index.md) - amstrad-cpr.md

# Format: CPR CPC Plus cartridge file format
## ".CPR" CPC Plus Cartridge file data structure
The file structure used is "RIFF" (Resource Interchange File Format). 

### Outline of the basic RIFF file structure
A RIFF file is constructed of "chunks".

Every chunk has a header with the form: 

|Offset|Size|Description|
|---|---|---|
|0|4|chunk id (4 character code)|
|4|4| Length of data following chunk-header. (little-endian format)|

The file begins with a "RIFF" chunk. This chunk contains a 4-byte "form-type" which identifies 
the file sub-type, followed by the remaining chunks in the file. The RIFF chunk is a container 
for all the remaining chunks in the file, therefore the length of the RIFF chunk data is 
equivalent to the total size of the file excluding the length of the header for the RIFF chunk. 

### ".CPR" specific file structure
The .CPR file uses the "Ams!" form-type.

Each chunk in the file contains (at most) a 16k range from the total cartridge data.

In the CPC+ system, a cartridge is made of up to 32 16k blocks. In the CPR file these blocks 
are numbered 0..31.

The id of the chunk is used to identify the cartridge block that the data corresponds to. 
(e.g. "cb00" corresponds to cartridge block 0, and contains the data for the range &0000-&3FFF, 
"cb01" corresponds to cartridge block 1, and contains the data for the range &4000-&7FFF).

A block may contain less than 16k, but should not contain more than 16k. If a emulator 
encounters a block with less than 16k, it should fill the rest of the range with 0's, if a 
emulator encounters a block with more than 16k, it should stop reading at 16k and ignore the 
remaining data. 

### External links
[Page on CPCWiki](http://www.cpcwiki.eu/index.php/Format:CPR_CPC_Plus_cartridge_file_format)
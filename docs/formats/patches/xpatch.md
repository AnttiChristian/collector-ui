[Station](../../../README.md) - [docs](../../index.md) - [formats](../index.md) - index.md

# Format: XPatch file format
## ".xpatch" features
- one patch for both ways of patching (original -> patched and patched-> original)
- does not contain any part of licensed content
- hash verification of result

## Theory
both ways can be achieved by looking for the same parts and mark position in both files
including block of patch data

no licensed content should be achievable by using XOR technique which also supports 
two way patching from first feature point


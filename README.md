# Sunless Skies LP plugin

This code compiles to a [BepInEx](https://bepinex.dev) plugin, to be used with version 6 or higher.

At the time of creation this means [bleeding edge](https://docs.bepinex.dev/master/).

# What it does

Currently only one thing, it removes the blur effect from the main panel and replaces it with a half transparent version.

Color and transparency are configurable in the config file which is generated afte the first start of the game with the plugin installed.

Example:

![A comparison between the original and the new behaviour](https://github.com/3stadt/SuSkLP/blob/main/media/comparison.png?raw=true)

# How to install/use

## Download

The current version is on the [release page](github.com/3stadt/SuSkLP/releases/).

You need to install [BepInEx](https://docs.bepinex.dev/master/) version 6 or higher, then add the DLL file as a plugin.

## Compile it yourself

Install BepInEx to Sunless Skies, compile the plugin as described in the [BepInEx documentation](https://docs.bepinex.dev/master/articles/dev_guide/plugin_tutorial/2_plugin_start.html?tabs=tabid-unityil2cpp#compiling-and-testing-the-plugin).

The lib folder of this project needs these files from the `unhollowed` directory created by BepInEx:

- `Assembly-CSharp.dll`
- `Il2Cppmscorlib.dll`
- `UnityEngine.dll`
- `UnityEngine.CoreModule.dll`
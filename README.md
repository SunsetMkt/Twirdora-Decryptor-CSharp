# Twirdora-Decryptor-CSharp

<img align="right" width="450" alt="小蓝梦" src="./image/小蓝梦.png">

Encrypt or decrypt files with [Twirdora](https://www.taptap.cn/app/212893) ([QooApp](https://apps.qoo-app.com/app/19984)) encryption method.

This project is for educational purposes only. All artwork, text and music are the property of [Twirdora](https://x.com/Twirdora) developers and [Pandox Project](https://x.com/PandoxP).

This encryption method is used to encrypt `PlayerData.json` (save data) currently and `.wdnmd` files (game assets) in previous versions (`1.0.*`) of Twirdora. Since the developers no longer encrypt game assets, I think it's moral to disclose this project.

Tested on Twirdora 1.2.4.

## Quick encryption or decryption for browsers

-   [Encrypt](<https://gchq.github.io/CyberChef/#recipe=AES_Encrypt(%7B'option':'Base64','string':'p1MTzxgZM5M0/%2BNqfP6cSIzBcQfFI4aAnnH%2B3UIu3ws%3D'%7D,%7B'option':'Base64','string':'Rkb4jvUy/ye7Cd7k89QQgQ%3D%3D'%7D,'CBC','Raw','Raw',%7B'option':'Hex','string':''%7D)>)
-   [Decrypt](<https://gchq.github.io/CyberChef/#recipe=AES_Decrypt(%7B'option':'Base64','string':'p1MTzxgZM5M0/%2BNqfP6cSIzBcQfFI4aAnnH%2B3UIu3ws%3D'%7D,%7B'option':'Base64','string':'Rkb4jvUy/ye7Cd7k89QQgQ%3D%3D'%7D,'CBC','Raw','Raw',%7B'option':'Hex','string':''%7D,%7B'option':'Hex','string':''%7D)>)

## With the help of

Tools:

-   <https://github.com/Perfare/Il2CppDumper>
-   <https://hex-rays.com/ida-pro>
-   <https://github.com/Perfare/AssetStudio>

AES.cs: <https://blog.51cto.com/u_15067234/4312706>

## Build

```shell
dotnet build
```

## Publish (Portable)

```shell
dotnet publish -c Release -o publish -p:PublishReadyToRun=true -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true -p:IncludeNativeLibrariesForSelfExtract=true
```

## Usage

```shell
Twirdora-Decryptor-CSharp.exe <encrypt|decrypt> <input_file> <output_file>
```

# Twirdora-Decryptor-CSharp

Encrypt or decrypt files with [Twirdora](https://www.taptap.cn/app/212893) ([QooApp](https://apps.qoo-app.com/app/19984)) encryption method.

This project is for educational purposes only.

This encryption method is used to encrypt `PlayerData.json` (save data) and `.wdnmd` files (game assets) in earlier versions of Twirdora. Since they no longer encrypt game assets, I think it's moral to disclose this project.

## With the help of

Tools:

-   <https://github.com/Perfare/Il2CppDumper>
-   <https://hex-rays.com/ida-pro>

AES.cs: <https://blog.51cto.com/u_15067234/4312706>

## Build

```shell
dotnet build
```

## Publish

```shell
dotnet publish -c Release -o publish -p:PublishReadyToRun=true -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true -p:IncludeNativeLibrariesForSelfExtract=true
```

## Usage

```shell
Twirdora-Decryptor.exe <encrypt|decrypt> <input_file> <output_file>
Twirdora-Decryptor.exe batchdecrypt <Twirdora Android Data Directory> <Output Directory>
```

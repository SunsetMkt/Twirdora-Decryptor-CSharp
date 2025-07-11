﻿using System.Text;

namespace AESDecryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            string strPassword = "d1RyaW9kcmE=";
            // Open file for DecryptByte
            // byte[] DecryptByte = File.ReadAllBytes(path: ".\\alicemourn.wdnmd");
            // byte[] Decrypt = Utils.AES.AESDecrypt(DecryptByte, strPassword);
            // Save file
            // File.WriteAllBytes(path: ".\\alicemourn.wdnmd.bundle", bytes: Decrypt);

            // If no enough args, show help
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: " + AppDomain.CurrentDomain.FriendlyName + " <encrypt|decrypt> <input_file> <output_file>");
                // Console.WriteLine("Usage: " + AppDomain.CurrentDomain.FriendlyName + " batchdecrypt <Twirdora Android Data Directory> <Output Directory>");
                Console.WriteLine("Encrypt or decrypt files with Twirdora encryption method.");
                Console.WriteLine("Tested on Twirdora 1.2.4 with password: " + strPassword);
                Console.WriteLine("Bad command: No enough args.");
                return;
            }

            string mode = args[0];

            if (mode == "encrypt")
            {
                Console.WriteLine("Encrypting" + args[1] + " to " + args[2]);
                byte[] EncryptByte = File.ReadAllBytes(args[1]);
                byte[] Encrypt = Utils.AES.AESEncrypt(EncryptByte, strPassword);
                File.WriteAllBytes(args[2], Encrypt);
                Console.WriteLine("Done!");
            }
            else if (mode == "decrypt")
            {
                Console.WriteLine("Decrypting" + args[1] + " to " + args[2]);
                byte[] DecryptByte = File.ReadAllBytes(args[1]);
                byte[] Decrypt = Utils.AES.AESDecrypt(DecryptByte, strPassword);
                File.WriteAllBytes(args[2], Decrypt);
                Console.WriteLine("Done!");
            }
            else if (mode == "batchdecrypt")
            {
                string path = args[1];
                string outputPath = args[2];

                if (!Directory.Exists(outputPath))
                {
                    Directory.CreateDirectory(outputPath);
                }

                string[] files = Directory.GetFiles(path);

                foreach (string file in files)
                {
                    // Try to Decrypt
                    try
                    {
                        Console.WriteLine("Decrypting: " + file);
                        byte[] DecryptByte = File.ReadAllBytes(file);
                        byte[] Decrypt = Utils.AES.AESDecrypt(DecryptByte, strPassword);
                        // Save
                        File.WriteAllBytes(outputPath + "\\" + Path.GetFileName(file), Decrypt);
                        Console.WriteLine("Decrypted: " + file);
                        // Check if Decrypt starts with UnityFS header
                        bool startsWithUnityFSHeader = Decrypt.Take(7).SequenceEqual(Encoding.ASCII.GetBytes("UnityFS"));

                        if (startsWithUnityFSHeader)
                        {
                            // If the written file name ends with .wdnmd , rename to .wdnmd.bundle
                            if (Path.GetFileName(file).EndsWith(".wdnmd"))
                            {
                                File.Move(outputPath + "\\" + Path.GetFileName(file), outputPath + "\\" + Path.GetFileName(file) + ".bundle");
                            }
                        }
                        else
                        {
                            if (Path.GetFileName(file).EndsWith(".json"))
                            {
                                // Pass, don't care
                            }
                            else
                            {
                                Console.WriteLine("Warning: Not UnityFS: " + file);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Ignore
                        // If file name ends with .manifest
                        if (Path.GetFileName(file).EndsWith(".manifest"))
                        {
                            // Pass, don't care
                        }
                        else
                        {
                            Console.WriteLine("Error: Failed to decrypt: " + file);
                        }
                        // Just save the original
                        File.Copy(file, outputPath + "\\" + Path.GetFileName(file));
                    }
                }
                Console.WriteLine("Done!");
            }
            else
            {
                Console.WriteLine("Bad command: " + mode);
            }
        }
    }
}

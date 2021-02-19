# Project Name
Password Hashing Library

# Description
This is a NuGet package for creating password hash and salt using Cryptography and encryption of type SHA 256 built into .NET

# Features
1. Method for creating password hash.
2. Method for verifying password hash.

# Installation
## Visual Studio
1. Go to the NuGet Package Explorer and type in PasswordHashingLibrary.
2. Install the latest version for your project.

## Visual Studio Code
1. Go to https://www.nuget.org/packages/PasswordHashingLibrary.Helper/ and find the of the copy latest version.
2. On the .NET CLI or Command prompt
```
dotnet add package PasswordHashingLibrary.Helper
```
# How to use the NuGet package
1. Add the namespace of the package to the file
```
using PasswordHashingLibrary.Helper.PasswordHasher;
```
2. The method built into the NuGet package are static methods so are called
```
PasswordHash.CreatePasswordHash(string password, out passwordHash, out passwordsalt)

PasswordHash.VerifyPasswordHash(string password, byte storedHash, byte storedSalt)
```
4. You can check the repository to see how the password hashing and password salt works and learn how to integrate it into your application.

# Support
For more about password hashing and encryption in ASP.NET Core, see https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-5.0

# Contributors
Isaac Gabriel

# License
MIT


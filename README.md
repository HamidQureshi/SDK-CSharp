https://github.com/activeledger/SDK-Ruby/edit/master/README.md
# Activeledger .NET SDK

Add the Reference of  the ActiveLedger library in your Visual Studio project

## Initialise the SDK

```csharp
ActiveLedgerLib.SDKPreferences.setSettings("protocol", "URL", "port");
```

## Generate KeyPair

```csharp
AsymmetricCipherKeyPair keypair = ActiveLedgerLib.GenerateKeyPair.GetKeyPair(KeyType);
```

## Creating Onboard transaction

Generate Json Object for onBoaring keys

```csharp
JObject json = ActiveLedgerLib.GenerateTxJson.GetTxJsonForOnboardingKeys(PathOfPublicKeyFile, AsymmetricKeypair,TypeofKey);
```

## Send a transaction

Submit a transaction to Activeledger

```csharp
var response = ActiveLedgerLib.MakeRequest.makeRequestAsync(SDKPrefernece, jsonObjectIntheFormOfString);
```

## Key Management

### Writing KeyPair in the file in PEM Format

```csharp
ActiveLedgerLib.Helper.WritekeyPairInFile(PathOfFile, AsymmetricCipherKeyPair);
```

### Writing Only the Public Key in the file in PEM Format

```csharp
ActiveLedgerLib.Helper.WritePublicKeyInFile(PathOfFile, AsymmetricCipherKeyPair);
```

### Reading Only the Pem Format key pair from the user file and return the Asymmetric Keypair 

```csharp
AsymmetricCipherKeyPair keypair = ActiveLedgerLib.Helper.ReadAsymmetricKeyParameter(PathOfFile);
```


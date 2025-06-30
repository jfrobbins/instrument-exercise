# How to Add the NI-VISA Reference to the Instruments Exercise Project

This guide explains how to add the National Instruments VISA (NI-VISA) library reference to the `instruments-exercise` project. The NI-VISA library allows your C# program to communicate with the Rigol DP832A power supply over USB or Ethernet. Instructions are provided for both **Windows** and **macOS** users.

---

## Why Add the NI-VISA Reference?

The `VisaInstrument.cs` and `RigolDP832A.cs` files use the `NationalInstruments.Visa` library to send commands to the power supply. Adding this reference to your project ensures the code can compile and run correctly.

---

## Prerequisites

- The `instruments-exercise` repository cloned to your computer.
- A code editor:
  - **Windows**: [Visual Studio](https://visualstudio.microsoft.com/) (Community edition is free) or [Visual Studio Code](https://code.visualstudio.com/).
  - **macOS**: [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/) or [Visual Studio Code](https://code.visualstudio.com/).
- [NI-VISA driver](https://www.ni.com/en-us/support/downloads/drivers/download.ni-visa.html) installed on your computer. Download and install the full development package (not just the runtime) to include the .NET assemblies.
- The `instruments-exercise.sln` solution open in your editor.

---

## Instructions for Windows

### Steps to Add the NI-VISA Reference in Visual Studio (Windows)

1. **Open the Solution**:
   - Open `instruments-exercise.sln` in Visual Studio.

2. **Access the Reference Manager**:
   - In **Solution Explorer** (usually on the right), find the `InstrumentsExercise` project.
   - Right-click on **References** (or **Dependencies** in newer versions) and select **Add Reference**.

3. **Locate the NI-VISA Library**:
   - In the **Reference Manager** window, click **Browse**.
   - Navigate to the NI-VISA installation folder, typically:
     ```
     C:\Program Files (x86)\National Instruments\Shared\NI-VISA\
     ```
   - Find and select `NationalInstruments.Visa.dll`.
   - Click **Add**, then **OK** to close the Reference Manager.

4. **Verify the Reference**:
   - In **Solution Explorer**, expand **References** under the `InstrumentsExercise` project.
   - Confirm that `NationalInstruments.Visa` appears in the list.

5. **Check Using Statements**:
   - Open `Instruments/VisaInstrument.cs`.
   - Ensure the following line is at the top:
     ```csharp
     using NationalInstruments.Visa;
     ```
   - This line allows the code to use NI-VISA classes like `ResourceManager` and `MessageBasedSession`.

6. **Build the Project**:
   - Press `F6` or select **Build > Build Solution** in Visual Studio.
   - If there are no errors, the reference is added correctly. If you see errors about missing `NationalInstruments.Visa`, double-check the NI-VISA installation.

### Alternative: Adding the Reference in Visual Studio Code (Windows)

If you’re using Visual Studio Code with the C# extension:

1. **Edit the .csproj File**:
   - Open `InstrumentsExercise/InstrumentsExercise.csproj` in your editor.
   - Add the following inside the `<ItemGroup>` section:
     ```xml
     <Reference Include="NationalInstruments.Visa">
       <HintPath>C:\Program Files (x86)\National Instruments\Shared\NI-VISA\NationalInstruments.Visa.dll</HintPath>
     </Reference>
     ```

2. **Build the Project**:
   - Run `dotnet build` in the terminal from the `InstrumentsExercise` folder.
   - Ensure there are no errors related to the NI-VISA reference.

---

## Instructions for macOS

### Installing NI-VISA on macOS

Before adding the reference, ensure NI-VISA is installed on your macOS system:

1. Download the [NI-VISA driver for macOS](https://www.ni.com/en-us/support/downloads/drivers/download.ni-visa.html).
2. Follow the installation instructions provided by National Instruments.
3. **Important**: Install the full development package, not just the runtime, to include the necessary .NET assemblies.

### Steps to Add the NI-VISA Reference in Visual Studio for Mac

1. **Open the Solution**:
   - Open `instruments-exercise.sln` in Visual Studio for Mac.

2. **Access the Reference Manager**:
   - In the **Solution** pad (usually on the left), find the `InstrumentsExercise` project.
   - Right-click on **References** and select **Add Reference**.

3. **Locate the NI-VISA Library**:
   - In the **Reference Manager**, select **Browse**.
   - Navigate to the NI-VISA installation folder on macOS. The typical path is:
     ```
     /Library/Frameworks/NIvisa.framework/Versions/Current/Resources/dotnet/
     ```
   - Find and select `NationalInstruments.Visa.dll`.
   - Click **Add**, then **OK** to close the Reference Manager.

4. **Verify the Reference**:
   - In the **Solution** pad, expand **References** under the `InstrumentsExercise` project.
   - Confirm that `NationalInstruments.Visa` appears in the list.

5. **Check Using Statements**:
   - Open `Instruments/VisaInstrument.cs`.
   - Ensure the following line is at the top:
     ```csharp
     using NationalInstruments.Visa;
     ```

6. **Build the Project**:
   - Select **Build > Build All** from the menu.
   - If there are no errors, the reference is added correctly. If you see errors about missing `NationalInstruments.Visa`, verify the NI-VISA installation.

### Alternative: Adding the Reference in Visual Studio Code (macOS)

If you’re using Visual Studio Code with the C# extension on macOS:

1. **Edit the .csproj File**:
   - Open `InstrumentsExercise/InstrumentsExercise.csproj` in your editor.
   - Add the following inside the `<ItemGroup>` section:
     ```xml
     <Reference Include="NationalInstruments.Visa">
       <HintPath>/Library/Frameworks/NIvisa.framework/Versions/Current/Resources/dotnet/NationalInstruments.Visa.dll</HintPath>
     </Reference>
     ```

2. **Build the Project**:
   - Run `dotnet build` in the terminal from the `InstrumentsExercise` folder.
   - Ensure there are no errors related to the NI-VISA reference.

---

## Troubleshooting (Windows and macOS)

- **Missing DLL**:
  - **Windows**: If `NationalInstruments.Visa.dll` is not found, reinstall NI-VISA and ensure you installed the full development package.
  - **macOS**: Verify the installation path. If the library is not in `/Library/Frameworks/NIvisa.framework/`, check the NI-VISA documentation for the correct location.
  
- **Build Errors**:
  - If you get errors like `The type or namespace name 'NationalInstruments' could not be found`, double-check the reference path or reinstall NI-VISA.
  
- **Runtime Errors**:
  - If you see errors like `DllNotFoundException` when running the program, ensure the NI-VISA runtime is installed on the machine.

- **macOS-Specific Issues**:
  - Ensure your .NET version is compatible with NI-VISA on macOS (e.g., .NET 6.0 or later).
  - If using Mono, verify compatibility, as NI-VISA may have specific requirements.

---

## Notes

- If you prefer using Keysight IO Libraries instead of NI-VISA, you can reference `Ivi.Visa.Interop.dll` (Windows) or the equivalent for macOS, but you’ll need to modify the code in `VisaInstrument.cs` accordingly.
- The NI-VISA library is essential for assignments that involve connecting to the power supply (e.g., Assignment 5 and beyond).

---

## Next Steps

After adding the NI-VISA reference, continue with the assignments in the [README.md](README.md) to implement the power supply control functionality.

For more help, see the [NI-VISA Documentation](https://www.ni.com/en-us/support/documentation.html) or ask your instructor.
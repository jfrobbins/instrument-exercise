# Rigol DP832A Control Project

This project is designed for educational purposes to teach programming concepts through controlling a Rigol DP832A Programmable Linear DC Power Supply using C# and .NET. It’s perfect for someone new to programming who wants to learn by building a real-world application.

## Overview

In this project, you will learn how to:
- Write basic C# code and use the .NET environment.
- Use interfaces and abstract classes for organizing code.
- Communicate with hardware using the VISA standard.
- Control the Rigol DP832A power supply with specific commands.
- Handle errors and test your code with real hardware.

The repository provides a blank shell program that compiles and runs. Your task is to complete it step-by-step through the assignments below.

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) installed (version 6.0 or later recommended).
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) (Community edition is free) or [Visual Studio Code](https://code.visualstudio.com/).
- [National Instruments VISA](https://www.ni.com/en-us/support/downloads/drivers/download.ni-visa.html) installed for instrument communication.
- A Rigol DP832A power supply connected via USB or Ethernet (for the final assignment).

### Setting Up the Project
1. **Clone the Repository**: Download this repository to your computer.
2. **Open the Solution**: Open `RigolDP832AControl.sln` in your code editor.
3. **Add VISA Reference**: Ensure the National Instruments VISA library is installed. You may need to add a reference to `NationalInstruments.Visa` in the project (instructions in your editor’s documentation).
4. **Build and Run**: Build the solution and run it. You should see "Hello, World!" in the console.

## Assignments

These assignments guide you from basic programming to controlling the power supply. Complete them in order, filling in the shell code provided.

### Assignment 1: Introduction to C# and .NET
- **Task**: Modify `Program.cs` to print "Hello, World!" (already done for you) and add a line printing your name.
- **Goal**: Get comfortable with C# syntax and running a program.
- **Hint**: Use `Console.WriteLine("Your Name");`.

### Assignment 2: Understanding Interfaces
- **Task**: Add method signatures to `IInstrument.cs` (e.g., `Connect`, `Disconnect`, `Write`, `Query`) and `IDCSupply.cs` (e.g., `SetVoltage`, `GetVoltage`, `GetCurrent`).
- **Goal**: Learn what interfaces are and how they define behavior.
- **Hint**: Method signatures look like `void Connect(string address);` with no implementation.

### Assignment 3: Implementing the VisaInstrument Class
- **Task**: Add basic VISA communication to `VisaInstrument.cs` using `NationalInstruments.Visa`.
- **Goal**: Understand abstract classes and VISA basics.
- **Hint**: Declare a `MessageBasedSession` variable and use it in `Connect`.

### Assignment 4: Implementing the RigolDP832A Class
- **Task**: Start implementing `RigolDP832A.cs` with placeholders for power supply commands.
- **Goal**: Learn inheritance by extending `VisaInstrument`.
- **Hint**: Use SCPI commands like `:SOURce1:VOLTage` (see the Rigol manual).

### Assignment 5: Connecting to the Instrument
- **Task**: Implement the `Connect` method in `VisaInstrument.cs` to connect to the power supply.
- **Goal**: Establish a real connection using VISA.
- **Hint**: Use `ResourceManager.GetLocalManager().Open(address)`.

### Assignment 6: Setting and Reading Voltage
- **Task**: Implement `SetVoltage` and `GetVoltage` in `RigolDP832A.cs`.
- **Goal**: Control and query the power supply’s voltage.
- **Hint**: Use `Write` for setting and `Query` for reading.

### Assignment 7: Reading Current
- **Task**: Implement `GetCurrent` in `RigolDP832A.cs`.
- **Goal**: Add current measurement to your control code.
- **Hint**: Use the SCPI command `:MEASure1:CURRent?`.

### Assignment 8: Error Handling
- **Task**: Add try-catch blocks to handle errors in `VisaInstrument.cs` and `RigolDP832A.cs`.
- **Goal**: Make your program robust against failures.
- **Hint**: Catch `VisaException` and print an error message.

### Assignment 9: Final Demonstration
- **Task**: Update `Program.cs` to connect to the power supply, set voltages on channel 1, and read currents through a resistor ladder.
- **Goal**: Show off everything you’ve learned with a real hardware test.
- **Hardware Setup**:
  - Connect a 100Ω resistor between the positive and negative terminals of channel 1 on the Rigol DP832A.
    - Perhaps using a box like [this](https://www.amazon.com/gp/product/B0D8T5XJS9/ref=ox_sc_act_title_4?smid=A1GMZO8N77UCMQ&psc=1)
    - or [this](https://www.amazon.com/gp/product/B0002KX76M/ref=ox_sc_act_title_3?smid=ATVPDKIKX0DER&psc=1)
  - Turn on the power supply and enable channel 1.
- **Program Steps**:
  - Connect to the power supply.
  - Set channel 1 to 5V.
  - Read and print the voltage and current.
  - Check that the current is about 50mA (since `I = V / R` = `5V / 100Ω = 0.05A`).
    - `V=IR` 
- **Hint**: Call your implemented methods and use `Console.WriteLine` to display results.

## Additional Resources
- [Rigol DP832A User Manual](https://www.rigolna.com/products/dc-power-supplies/dp800/) for SCPI commands.
- [C# Beginner’s Guide](https://docs.microsoft.com/en-us/dotnet/csharp/) for language basics.
- [NI VISA Documentation](https://www.ni.com/en-us/support/documentation.html) for connection help.
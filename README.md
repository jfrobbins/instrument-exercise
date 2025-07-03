# Instruments Control Project

This project is designed for educational purposes to teach programming concepts through controlling a Rigol DP832A Programmable Linear DC Power Supply using C# and .NET. 
It’s perfect for someone new to programming who wants to learn by building a real-world application.

## Overview

In this project, you will learn how to:
- Write basic C# code and use the .NET environment.
- Use interfaces and abstract classes for organizing code.
- Communicate with hardware using the VISA standard.
- Control the Rigol DP832A power supply with specific commands.
- Handle errors and test your code with real hardware.

The repository provides a blank shell program that compiles and runs. Your task is to complete it step-by-step through the assignments below.

## Getting Started
Here's a GitHub primer that may be useful:
- [Introduction to GitHub](https://github.com/skills/introduction-to-github)
And the official GitHub documentation is quite good:
- [GitHub Education](https://education.github.com/experiences/intro_to_github)

### Repository Structure
```
instruments-exercise/
├── README.md
├── KeyConcepts.md
├── instruments-exercise.sln
├── InstrumentsExercise/
│   ├── Interfaces/
│   │   ├── IInstrument.cs
│   │   └── IDCSupply.cs
│   ├── Instruments/
│   │   ├── VisaInstrument.cs
│   │   └── RigolDP832A.cs
│   └── Program.cs
```

### Prerequisites
- [C# Coding Guidelines](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [.NET SDK](https://dotnet.microsoft.com/download) installed (version 6.0 or later recommended).
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) (Community edition is free) or [Visual Studio Code](https://code.visualstudio.com/).
- [National Instruments VISA](https://www.ni.com/en-us/support/downloads/drivers/download.ni-visa.html) installed for instrument communication.
  - This is a library that handles the bulk of communication with instruments.
  - The [NI-VISA Readme](https://www.ni.com/docs/en-US/bundle/ni-visa/page/user-manual-welcome.html) has a lot of good information, _and examples!_ Check out the "VISA Overview" section.
- A Rigol DP832A power supply connected via USB or Ethernet (for the final assignment).
- **Namespace**: The namespace is `InstrumentsExercise`, with sub-namespaces `InstrumentsExercise.Interfaces` and `InstrumentsExercise.Instruments`.

### Setting Up the Project
1. **Clone the Repository**: Download this repository to your computer.
2. **Open the Solution**: Open `instruments-exercise.sln` in your code editor.
3. **Add VISA Reference**: Ensure the National Instruments VISA library is installed. You may need to add a reference to `NationalInstruments.Visa` in the project (instructions in your editor’s documentation).
   - See [HowToAddNIVisaReference.md](./HowToAddNIVisaReference.md)
4. **Build and Run**: Build the solution and run it. You should see "Hello, World!" in the console.

## Assignments

These assignments guide you from basic programming to controlling the power supply. Complete them in order, filling in the shell code provided.

### Assignment 1: Introduction to C# and .NET
Start your programming journey by learning the basics of C# and how to run a simple program. This assignment introduces you to writing and executing code.

- **Task**: Modify `Program.cs` to print "Hello, World!" (already done for you) and add a line printing your name.
- **Goal**: Get comfortable with C# syntax and running a program.
- **Hint**: Use `Console.WriteLine("Your Name");`.

### Assignment 2: Understanding Interfaces
An interface in C# defines a contract that specifies what methods or properties a class must have to interact with other parts of a program, without defining how those methods are implemented. 
This ensures consistent communication between objects, like controlling a power supply, while allowing flexibility in how the functionality is built.

- **Task**: Add method signatures to `IInstrument.cs` (e.g., `Connect`, `Disconnect`, `Write`, `Query`) and `IDCSupply.cs` (e.g., `SetVoltage`, `GetVoltage`, `GetCurrent`).
- **Goal**: Learn what interfaces are and how they define behavior. Read more in [Key Concepts: Interfaces](./KeyConcepts.md#interfaces-in-c).
- **Hint**: Method signatures look like `void Connect(string address);` with no implementation.

### Assignment 3: Implementing the VisaInstrument Class
Dive into the world of hardware communication by implementing the foundation for talking to instruments using VISA. This assignment introduces abstract classes and the VISA standard.

- **Task**: Add basic VISA communication to `VisaInstrument.cs` using `NationalInstruments.Visa`.
- **Goal**: Understand abstract classes and VISA basics. See [Key Concepts: Abstract Classes](./KeyConcepts.md#abstract-classes) and [Key Concepts: VISA](./KeyConcepts.md#visa-virtual-instrument-software-architecture).
- **Hint**: Declare a `MessageBasedSession` variable and use it in `Connect`.

### Assignment 4: Implementing the RigolDP832A Class
Learn how to structure your code for specific instruments by implementing the RigolDP832A class. This assignment focuses on inheritance and using SCPI commands.

- **Task**: Start implementing `RigolDP832A.cs` with placeholders for power supply commands.
- **Goal**: Learn inheritance by extending `VisaInstrument`. See [Key Concepts: Abstract Classes](./KeyConcepts.md#abstract-classes).
- **Hint**: Use SCPI commands like `:SOURce1:VOLTage` (see the Rigol manual).

### Assignment 5: Connecting to the Instrument
Establish a real connection to the power supply and see your code interact with hardware for the first time. This assignment is all about making that crucial first connection.

- **Task**: Implement the `Connect` method in `VisaInstrument.cs` to connect to the power supply.
- **Goal**: Establish a real connection using VISA. Learn more in [Key Concepts: VISA](./KeyConcepts.md#visa-virtual-instrument-software-architecture).
- **Hint**: Use `ResourceManager.GetLocalManager().Open(address)`.

### Assignment 6: Setting and Reading Voltage
Take control of the power supply by setting and reading voltage levels. This assignment teaches you how to send commands and receive responses from the instrument.

- **Task**: Implement `SetVoltage` and `GetVoltage` in `RigolDP832A.cs`.
- **Goal**: Control and query the power supply’s voltage. See [Key Concepts: SCPI](./KeyConcepts.md#scpi-standard-commands-for-programmable-instruments).
- **Hint**: Use `Write` for setting and `Query` for reading.

### Assignment 7: Reading Current
Expand your control by adding the ability to measure current. This assignment builds on your knowledge of SCPI commands and instrument queries.

- **Task**: Implement `GetCurrent` in `RigolDP832A.cs`.
- **Goal**: Add current measurement to your control code. See [Key Concepts: SCPI](./KeyConcepts.md#scpi-standard-commands-for-programmable-instruments).
- **Hint**: Use the SCPI command `:MEASure1:CURRent?`.

### Assignment 8: Error Handling
Make your program more robust by handling potential errors that can occur when communicating with hardware. This assignment introduces error handling in C#.

- **Task**: Add try-catch blocks to handle errors in `VisaInstrument.cs` and `RigolDP832A.cs`.
- **Goal**: Make your program robust against failures. Learn more in [Key Concepts: Error Handling](./KeyConcepts.md#error-handling-in-hardware-communication).
- **Hint**: Catch `VisaException` and print an error message.

### Assignment 9: Final Demonstration
Bring it all together by demonstrating full control of the power supply in a real-world scenario. This final assignment tests your understanding of everything you’ve learned.

- **Task**: Update `Program.cs` to connect to the power supply, set voltages on channel 1, and read currents through a resistor ladder.
- **Goal**: Show off everything you’ve learned with a real hardware test.
- **Hardware Setup**:
  - Connect a 100Ω resistor between the positive and negative terminals of channel 1 on the Rigol DP832A.
    - Perhaps using a box like [Decade Resistance Box](https://www.amazon.com/gp/product/B0D8T5XJS9/ref=ox_sc_act_title_4?smid=A1GMZO8N77UCMQ&psc=1) or [Resistor Kit](https://www.amazon.com/gp/product/B0002KX76M/ref=ox_sc_act_title_3?smid=ATVPDKIKX0DER&psc=1).
  - Turn on the power supply and enable channel 1.
- **Program Steps**:
  - Connect to the power supply.
  - Set channel 1 to 5V.
  - Read and print the voltage and current.
  - Check that the current is about 50mA (since `I = V / R` = `5V / 100Ω = 0.05A`).
    - `V = I * R` (Ohm's Law). Learn more in [Key Concepts: Basic Electronics](./KeyConcepts.md#basic-electronics-for-testing-eg-ohms-law).
- **Hint**: Call your implemented methods and use `Console.WriteLine` to display results.

## Additional Resources
- [Rigol DP832A User Manual](https://www.rigolna.com/products/dc-power-supplies/dp800/) for SCPI commands.
- [C# Beginner’s Guide](https://docs.microsoft.com/en-us/dotnet/csharp/) for language basics.
- [NI VISA Documentation](https://www.ni.com/en-us/support/documentation.html) for connection help.
This example shows how to receive and process [Integration Events](https://github.com/teamhaven/WebAPI/wiki/Integration-Events).

To get started:

1. Load the Examples.sln into Visual Studio 2012 or 2013 (The .NET Framework 4.5 is required).  
2. In Visual Studio, right-click on "Example2" and select "Set as StartUp Project".  
3. Open `Program.cs` and change the `Username`, `Password` and `Account` constants to match your TeamHaven login credentials.  
4. Start the program running. You will probably see a list of notifications about Calls being Answerd start to scroll past. However, if a blank console window is displayed then the Integration Event Queue is empty (messages expire after 7 days).  
5. Open the TeamHaven Website, find an already completed Call, open the Call for update and then save it (it is not necessary to change any answers).  
6. You should see a message in the console window notifying you that the Call was Answered.  

using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Concrete;

CurrentAccount currentAccount = new CurrentAccount("Lionel Messi", "123-456-719", BankBranch.Stavanger); 

currentAccount.Deposit(1000.00m);
currentAccount.Deposit(2000.00m);
currentAccount.Withdraw(500.00m);

IPrinter consolePrinter = new ConsolePrinter(); // change to Twilio() to print to sms via twilio
currentAccount.PrintBankStatement(consolePrinter);
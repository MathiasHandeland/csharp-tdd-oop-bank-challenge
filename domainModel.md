# C# Bank Challenge Domain Model

## User Stories - Core Requirements

```
1.
As a customer,
So I can safely store use my money,
I want to create a current account.
```
| Classes        | Methods/Properties                          | Scenario                                  | Outputs         |
|----------------|---------------------------------------------|-------------------------------------------|-----------------|
| CurrentAccount | Inherits BankAccount                        | Create a new CurrentAccount               | Account object  |
|                | CustomerName, PhoneNumber, Branch           |                                           |                 |
|                | Deposit(amount), Withdraw(amount)           |                                           |                 |
|                | GetBalance(), GetPaymentHistory()           |                                           |                 |

```
2.
As a customer,
So I can save for a rainy day,
I want to create a savings account.
```
| Classes        | Methods/Properties                          | Scenario                                  | Outputs         |
|----------------|---------------------------------------------|-------------------------------------------|-----------------|
| SavingsAccount | Inherits BankAccount                        | Create a new SavingsAccount               | Account object  |
|                | CustomerName, PhoneNumber, Branch           |                                           |                 |
|                | Deposit(amount), Withdraw(amount)           |                                           |                 |
|                | GetBalance(), GetPaymentHistory()           |                                           |                 |

```
3.
As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
```
| Classes        | Methods/Properties                          | Scenario                                  | Outputs              |
|----------------|---------------------------------------------|-------------------------------------------|----------------------|
| BankAccount    | PrintBankStatement(IPrinter printer)        | Print statement after transactions        | Bank statement text  |
| Transaction    | Amount, Date, BalanceAfterTransaction       | Each transaction records details          |                      |

```
4.
As a customer,
So I can use my account,
I want to deposit and withdraw funds.
```
| Classes        | Methods/Properties                          | Scenario                                           | Outputs         |
|----------------|---------------------------------------------|----------------------------------------------------|-----------------|
| BankAccount    | Deposit(amount), Withdraw(amount)           | Deposit or withdraw funds                          | Updated balance |
| Transaction    | Amount, Date, BalanceAfterTransaction       | Transaction added to history. Properties updated   |                 |


## User Stories - Extensions 

```
1.
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.
```
| Classes        | Methods/Properties                          | Scenario                                  | Outputs         |
|----------------|---------------------------------------------|-------------------------------------------|-----------------|
| BankAccount    | GetBalance()                                | Balance is sum of all transaction amounts | decimal balance |


```
2.
As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.
```
| Classes        | Methods/Properties                          | Scenario                                  | Outputs         |
|----------------|---------------------------------------------|-------------------------------------------|-----------------|
| BankAccount    | Branch (BankBranch enum)                    | Account created with branch city info     | Branch property |


```
3.
As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.
```
| Classes        | Methods/Properties                          | Scenario                                                                                        | Outputs                                           |
|----------------|---------------------------------------------|-------------------------------------------------------------------------------------------------|---------------------------------------------------|
| CurrentAccount | RequestOverdraft(amount)                    | Customer requests overdraft. Should only be possible in a CurrentAccount and not SavingsAccount | Overdraft request stored for approval/denial logic|
|                | OverdraftLimit (property)                   |                                                                                                 |                                                   |


```
4.
As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.
```
| Classes        | Methods/Properties                          | Scenario                                     | Outputs                                         |
|----------------|---------------------------------------------|----------------------------------------------|-------------------------------------------------|
| CurrentAccount | ApproveOverdraft(), RejectOverdraft()       | Approves/rejects overdraft before withdrawel | OverdraftLimit set to requested amount or reset |


```
5.
As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.

NB: Not implemented - this is just an idea
```
| Classes        | Methods/Properties                          | Scenario                                                   | Outputs         |
|----------------|---------------------------------------------|------------------------------------------------------------|-----------------|
| IPrinter       | Print(string message)                       | print bank statement in either console or sms via twilio   |                 |
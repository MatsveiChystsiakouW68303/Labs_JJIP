module BankAccountSystem

open System

type BankAccount(accountNumber: string, initialBalance: decimal) =
    let mutable balance = initialBalance

    member this.AccountNumber = accountNumber
    member this.Balance = balance

    member this.Deposit(amount: decimal) =
        if amount <= 0m then
            printfn "Deposit amount must be positive."
        else
            balance <- balance + amount
            printfn "Deposited %M. New balance: %M." amount balance

    member this.Withdraw(amount: decimal) =
        if amount <= 0m then
            printfn "Withdrawal amount must be positive."
        elif amount > balance then
            printfn "Insufficient funds. Available balance: %M." balance
        else
            balance <- balance - amount
            printfn "Withdrew %M. New balance: %M." amount balance

type Bank() =
    let mutable accounts = Map.empty<string, BankAccount>

    member this.CreateAccount(accountNumber: string, initialBalance: decimal) =
        if accounts.ContainsKey(accountNumber) then
            printfn "Account with number %s already exists." accountNumber
        else
            let account = BankAccount(accountNumber, initialBalance)
            accounts <- accounts.Add(accountNumber, account)
            printfn "Account %s created with initial balance %M." accountNumber initialBalance

    member this.GetAccount(accountNumber: string) =
        match accounts.TryFind(accountNumber) with
        | Some account ->
            printfn "Account found: %s. Balance: %M." account.AccountNumber account.Balance
            Some account
        | None ->
            printfn "Account with number %s not found." accountNumber
            None

    member this.UpdateAccount(accountNumber: string, newBalance: decimal) =
        match accounts.TryFind(accountNumber) with
        | Some account ->
            accounts <- accounts.Remove(accountNumber)
            let updatedAccount = BankAccount(accountNumber, newBalance)
            accounts <- accounts.Add(accountNumber, updatedAccount)
            printfn "Account %s updated. New balance: %M." accountNumber newBalance
        | None ->
            printfn "Account with number %s not found." accountNumber

    member this.DeleteAccount(accountNumber: string) =
        if accounts.ContainsKey(accountNumber) then
            accounts <- accounts.Remove(accountNumber)
            printfn "Account %s deleted." accountNumber
        else
            printfn "Account with number %s not found." accountNumber

[<EntryPoint>]
let main argv =
    let bank = Bank()

    bank.CreateAccount("12345", 1000m)
    bank.CreateAccount("67890", 500m)

    let account1 = bank.GetAccount("12345")
    let account2 = bank.GetAccount("67890")
    let account3 = bank.GetAccount("99999") 

    match account1 with
    | Some acc -> acc.Deposit(200m)
    | None -> ()

    match account2 with
    | Some acc -> acc.Withdraw(100m)
    | None -> ()

    bank.DeleteAccount("12345")
    bank.DeleteAccount("99999") 

    0

using System;

public class cardHolder
{
    // Setting variables
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    // Passing in varibles into constructor
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        // Creating new objects
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    // -- Setting Getters -- //
    // getNum Function
    public String getNum()
    {
        return cardNum;
    }

    // getPin Function
    public int getPin()
    {
        return pin;
    }

    // getFirstName Function
    public String getFirstName()
    {
        return firstName;
    }

    // getLastName Function
    public String getLastName()
    {
        return lastName;
    }

    // getBalance Function
    public double getBalance()
    {
        return balance;
    }


    // -- Setting Setters -- //
    // setNum Function
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    // setPin Function
    public void setPin(int newPin)
    {
        pin = newPin;
    }

    // setFirstName Function
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    // setLastName Function
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    // setBalance
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }


    public static void Main(String[] args)
    {
        // Options given to the current user when using the ATM
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        // Deposit Function
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        // Withdraw Function
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw? ");
            double withdrawal = Double.Parse(Console.ReadLine());
            // Check if user has enough money
            if(currentUser.getBalance() > withdrawal)
            {
                Console.WriteLine("Insufficient balance!");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you!");
            }
        }

        // Balance Function
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1984514375449875", 1234, "John", "Giffith", 150.31));
        cardHolders.Add(new cardHolder("4984541534654547", 5678, "Alex", "Lopez", 689.23));
        cardHolders.Add(new cardHolder("7891984231548954", 4862, "Sarah", "Smith", 869.45));
        cardHolders.Add(new cardHolder("8791516833364947", 6842, "Emily", "Brock", 232.69));
        cardHolders.Add(new cardHolder("2879472519468874", 4321, "Sam", "Stamey", 548.66));

        // Prompt user
        Console.WriteLine("Welcome to SimpleATM!");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our Database
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again!"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again!"); }
        }

        Console.WriteLine("Please enter your PIN: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect PIN. Please try again!"); }
            }
            catch { Console.WriteLine("Incorrect PIN. Please try again!"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + "!");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day!");
    }
}

using System;
class Account
{
    private string holderNames;
    private string bankName;
    private string iban;
    private decimal balance;
    private string fCard;
    private string sCard;
    private string tCard;

    public string Holder { get { return this.holderNames; } set { this.holderNames = value; } }
    public string Bank { get { return this.bankName; } set { this.bankName = value; } }
    public string IBAN { get { return this.iban; } set { this.iban = value; } }
    public decimal Balance { get { return this.balance; } set { this.balance = value; } }
    public string Card_01 { get { return this.fCard; } set { this.fCard = value; } }
    public string Card_02 { get { return this.sCard; } set { this.sCard = value; } }
    public string Card_03 { get { return this.tCard; } set { this.tCard = value; } }

    public override string ToString()
    {   
        return string.Format(@"
Bank:       {0}
Holder:     {1}
IBAN:       {2}
Balance:    {3:C}
1st card:   {4}
2nd card:   {5}
3rd card:   {6}   
", this.Bank, this.Holder, this.IBAN, this.Balance, this.Card_01, this.Card_02, this.Card_03);
    }

    public void FillInfo()
    {
        Console.Write("Bank name? ");
        this.Bank = Console.ReadLine();
        Console.Write("Holder? ");
        this.Holder = Console.ReadLine();
        Console.Write("Balance? ");
        this.Balance = decimal.Parse(Console.ReadLine());
        Console.Write("IBAN? ");
        this.IBAN = Console.ReadLine();
        Console.Write("First credit card number? ");
        this.Card_01 = Console.ReadLine();
        Console.Write("Second credit card number? ");
        this.Card_02 = Console.ReadLine();
        Console.Write("Third credit card number? ");
        this.Card_03 = Console.ReadLine();
    }
}

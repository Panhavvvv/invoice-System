using System;
using System.Collections.Generic;

class Invoice
{
    public int InvoiceNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal Amount { get; set; }

    public override string ToString()
    {
        return $"Invoice Number: {InvoiceNumber}\nCustomer Name: {CustomerName}\nAmount: {Amount:C}\n";
    }
}

class InvoiceManagementSystem
{
    static List<Invoice> invoices = new List<Invoice>();
    static int nextInvoiceNumber = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Invoice Management System Menu:");
            Console.WriteLine("1. Input Invoice");
            Console.WriteLine("2. View All Invoices");
            Console.WriteLine("3. Search Invoice");
            Console.WriteLine("4. Delete Invoice");
            Console.WriteLine("5. Update Invoice");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        InputInvoice();
                        break;
                    case 2:
                        ViewAllInvoices();
                        break;
                    case 3:
                        SearchInvoice();
                        break;
                    case 4:
                        DeleteInvoice();
                        break;
                    case 5:
                        UpdateInvoice();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid menu choice.");
            }
        }
    }

    static void InputInvoice()
    {
        Console.Write("Enter Customer Name: ");
        string customerName = Console.ReadLine();
        Console.Write("Enter Invoice Amount: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Invoice invoice = new Invoice
            {
                InvoiceNumber = nextInvoiceNumber,
                CustomerName = customerName,
                Amount = amount
            };
            invoices.Add(invoice);
            Console.WriteLine("Invoice added successfully.");
            nextInvoiceNumber++;
        }
        else
        {
            Console.WriteLine("Invalid amount. Please enter a valid amount.");
        }
    }

    static void ViewAllInvoices()
    {
        if (invoices.Count == 0)
        {
            Console.WriteLine("No invoices found.");
        }
        else
        {
            Console.WriteLine("List of Invoices:");
            foreach (var invoice in invoices)
            {
                Console.WriteLine(invoice);
                Console.WriteLine("-----------");
            }
        }
    }

    static void SearchInvoice()
    {
        Console.Write("Enter Invoice Number to search: ");
        if (int.TryParse(Console.ReadLine(), out int invoiceNumber))
        {
            var invoice = invoices.Find(i => i.InvoiceNumber == invoiceNumber);
            if (invoice != null)
            {
                Console.WriteLine("Invoice Found:");
                Console.WriteLine(invoice);
            }
            else
            {
                Console.WriteLine("Invoice not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid invoice number.");
        }
    }

    static void DeleteInvoice()
    {
        Console.Write("Enter Invoice Number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int invoiceNumber))
        {
            var invoice = invoices.Find(i => i.InvoiceNumber == invoiceNumber);
            if (invoice != null)
            {
                invoices.Remove(invoice);
                Console.WriteLine("Invoice deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invoice not found for deletion.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid invoice number.");
        }
    }

    static void UpdateInvoice()
    {
        Console.Write("Enter Invoice Number to update: ");
        if (int.TryParse(Console.ReadLine(), out int invoiceNumber))
        {
            var invoice = invoices.Find(i => i.InvoiceNumber == invoiceNumber);
            if (invoice != null)
            {
                Console.Write("Enter New Customer Name: ");
                invoice.CustomerName = Console.ReadLine();
                Console.Write("Enter New Invoice Amount: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal newAmount))
                {
                    invoice.Amount = newAmount;
                    Console.WriteLine("Invoice information updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid amount. Invoice information not updated.");
                }
            }
            else
            {
                Console.WriteLine("Invoice not found for updating.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid invoice number.");
        }
    }
}

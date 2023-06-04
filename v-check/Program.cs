// See https://aka.ms/new-console-template for more information
using System.Security.Principal;
using v_check;


Auth auth = new Auth();


/*Console.Write("enter user name: ");
/* 0556803386 
string uName = Console.ReadLine();

Console.Write("enter password: ");
/* 5s3ARhRwFGeKPrY 
string pass = Console.ReadLine();

await auth.Authorization(uName, pass);*/

Checks checks = new Checks();
/*
Console.Write("enter the phone num of the reciepiant: ");
string phone = Console.ReadLine();

Console.Write("enter title: ");
string title = Console.ReadLine();


Console.Write("enter an amount: ");
string input = Console.ReadLine();
int amount = int.Parse(input);


Console.Write("enter the days you wont the payment from today: ");
string inputDay = Console.ReadLine();
int fromWhen = int.Parse(input);


Console.Write("how many payments of this amount you wont? ");
string inputPay = Console.ReadLine();
int occur = int.Parse(input);


Console.Write("choose Recurrence Pattern (1 = single 2 = daily 3 = weekly 4 = monthly): ");
string inputPat = Console.ReadLine();
int pattern = int.Parse(input);

Console.Write("enter bank num: ");
string inputBank = Console.ReadLine();
int bank = int.Parse(inputBank);


Console.Write("enter branch: ");
string branch = Console.ReadLine();


Console.Write("enter account num: ");
string account = Console.ReadLine();



await checks.CreateCheck( phone,  title,  amount,  fromWhen,  occur,  pattern,  bank,  branch,  account); */


Console.Write("enter the phone num of the reciepiant: ");
string phone = Console.ReadLine();

Console.Write("enter title: ");
string title = Console.ReadLine();


Console.Write("enter an amount: ");
string input = Console.ReadLine();
int amount = int.Parse(input);


Console.Write("enter the days you wont the payment from today: ");
string inputDay = Console.ReadLine();
int fromWhen = int.Parse(input);


Console.Write("how many payments of this amount you wont? ");
string inputPay = Console.ReadLine();
int occur = int.Parse(input);


Console.Write("choose Recurrence Pattern (1 = single 2 = daily 3 = weekly 4 = monthly): ");
string inputPat = Console.ReadLine();
int pattern = int.Parse(input);

Console.Write("enter bank num: ");
string inputBank = Console.ReadLine();
int bank = int.Parse(inputBank);


Console.Write("enter branch: ");
string branch = Console.ReadLine();


Console.Write("enter account num: ");
string account = Console.ReadLine();

Console.Write("enter request ID: ");
string reqId = Console.ReadLine();

await checks.ResToCheckReq(reqId, phone, title, amount, fromWhen, occur, pattern, bank, branch, account);

/*
Console.Write("enter start date in this format m/d/yyyy: ");
string StartDate = Console.ReadLine();

Console.Write("enter end date in this format m/d/yyyy: ");
string EndDate = Console.ReadLine();

await checks.GetChecksByDate(StartDate, EndDate);

Console.Write("Enter an ID: ");
string input = Console.ReadLine();
int checkId = int.Parse(input);

await checks.getCheckById(checkId);

Console.Write("enter start date in this format m/d/yyyy: ");
string StartDate = Console.ReadLine();

Console.Write("enter end date in this format m/d/yyyy: ");
string EndDate = Console.ReadLine();*/

CheckReq checkReq = new CheckReq();

/*await checkReq.getPaymentReqByDate(StartDate, EndDate);

Console.Write("Enter an ID: ");
string checkId = Console.ReadLine();


await checkReq.getPaymentReqById(checkId);

Console.Write("enter the phone num of the reciepiant: ");
string phone = Console.ReadLine();

Console.Write("enter an emails to get notifications (separated by comma): ");
string inputEmail = Console.ReadLine();
string[] emails = inputEmail.Split(',');

Console.Write("enter an amount: ");
string input = Console.ReadLine();
int amount = int.Parse(input);


Console.Write("enter the days you wont the payment from today: ");
string inputDay = Console.ReadLine();
int fromWhen= int.Parse(input);


Console.Write("how many payments of this amount you wont? ");
string inputPay = Console.ReadLine();
int occur = int.Parse(input);


Console.Write("choose Recurrence Pattern (1 = single 2 = daily 3 = weekly 4 = monthly): ");
string inputPat = Console.ReadLine();
int pattern = int.Parse(input);

await checkReq.CheckRequest(phone, emails, amount, fromWhen, occur, pattern);*/
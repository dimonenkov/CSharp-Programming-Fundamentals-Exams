namespace _04.Winning_Ticket
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WinningTicket
    {
        public static void Main()
        {
            var tickets = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var winningPattern = @"(\@{6,9}|\${6,9}|\#{6,9}|\^{6,9})";
            var jackpotPattern = @"(\@{10}|\${10}|\#{10}|\^{10})";

            var winningRegex = new Regex(winningPattern);
            var jackpotRegex = new Regex(jackpotPattern);

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }

                else
                {
                    var leftTicketHalf = ticket.Substring(0, 10);
                    var rightTicketHalf = ticket.Substring(10, 10);

                    var matchLeftWin = winningRegex.Match(leftTicketHalf);
                    var matchRightWin = winningRegex.Match(rightTicketHalf);

                    var jackpotMatchLeft = jackpotRegex.Match(leftTicketHalf);
                    var jackpotMatchRight = jackpotRegex.Match(rightTicketHalf);

                    if (jackpotMatchLeft.Success && jackpotMatchRight.Success)
                    {
                        var symbol = jackpotMatchRight.ToString().ToList();
                        Console.WriteLine($"ticket \"{ticket}\" - {jackpotMatchRight.Length}{symbol[0]} Jackpot!");
                    }

                    else if (matchLeftWin.Success && matchRightWin.Success)
                    {
                        var symbol = matchRightWin.ToString().ToList();
                        Console.WriteLine($"ticket \"{ticket}\" - {matchRightWin.Length}{symbol[0]}");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
            }
        }
    }
}
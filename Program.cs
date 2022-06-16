using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleBlackJack
{
    class Card
    {
        public int Value { get; set; }
        public string Sign { get; set; }
        public string SignName { get; set; }
        public string FullName { get; set; }

        public Card(int value, int sign)
        {
            Value = value;

            switch (Value)
            {
                case 11:
                case 12:
                case 13: Value = 10; break;
                case 1: Value = 11; break;
                default:
                    break;
            }

            switch (value)
            {
                case 1: FullName = "Ace"; break;
                case 11: FullName = "Jack"; break;
                case 12: FullName = "Queen"; break;
                case 13: FullName = "King"; break;
                default: FullName = Value.ToString(); break;
            }
            switch (sign)
            {
                case 1: SignName = "Heart"; Sign = "♥"; break;
                case 2: SignName = "Diamond"; Sign = "♦"; break;
                case 3: SignName = "Club"; Sign = "♣"; break;
                case 4: SignName = "Spade"; Sign = "♠"; break;
                default:
                    break;
            }
            FullName = string.Format("{0} of {1}s", FullName, SignName);
        }

        public static void ShuffleDeck(ref List<Card> deck)
        {
            var rnd = new Random();
            deck = deck.OrderBy(item => rnd.Next()).ToList();
        }

        public static int CountCardValues(List<Card> deck)
        {
            int rez = 0;

            foreach (var card in deck)
            {
                rez += card.Value;
            }

            return rez;
        }

        public static void ListCards(List<Card> deck)
        {
            foreach (var card in deck)
            {
                Console.WriteLine("{0} ({1})", card.FullName, card.Value);
            }
        }
        public static void PaintDeck(List<Card> deck)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < deck.Count; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (deck[j].Sign == "♥" || deck[j].Sign == "♦")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(Card.GetCardGraphic(deck[j])[i] + " ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }
        }
        public static List<Card> DrawCards(ref List<Card> deck, int numOfCards, ref List<Card> discard)
        {
            if (deck.Count == 0)
            {
                Console.WriteLine("The deck is empty? Lemme shuffle the discard pile into the dick real quick...");
                deck = new List<Card>(discard);
                discard = new List<Card>();
                Card.ShuffleDeck(ref deck);
                Thread.Sleep(2000);
            }
            List<Card> PlayerHand = new List<Card>();
            for (int i = 0; i < numOfCards; i++)
            {
                Card card1 = deck.First();
                deck.Remove(card1);
                PlayerHand.Add(card1);
            }
            return PlayerHand;
        }
        public static string[] GetCardGraphic(Card card)
        {
            string cardAbr = card.FullName[0].ToString() + card.FullName[1].ToString();
            string[] cardGraphic = new string[11];
            int parsedInt = 0;
            cardGraphic[0] = string.Format("*************");
            cardGraphic[1] = string.Format("*           *");
            bool isNumber = int.TryParse(cardAbr, out parsedInt);
            if (!isNumber)
            {
                cardGraphic[2] = string.Format("* {0}         *", cardAbr[0].ToString());
                cardGraphic[8] = string.Format("*         {0} *", cardAbr[0].ToString());
            }
            else
            {
                if (parsedInt == 10)
                {
                    cardGraphic[2] = string.Format("* {0}        *", parsedInt);
                    cardGraphic[8] = string.Format("*        {0} *", parsedInt);
                }
                else
                {
                    cardGraphic[2] = string.Format("* {0}         *", parsedInt);
                    cardGraphic[8] = string.Format("*         {0} *", parsedInt);
                }
            }
            cardGraphic[9] = string.Format("*           *");
            cardGraphic[10] = string.Format("*************");
            switch (cardAbr.ToUpper())
            {
                case "2 ":
                    cardGraphic[3] = string.Format("*     {0}     *", card.Sign);
                    cardGraphic[4] = string.Format("*           *", card.Sign);
                    cardGraphic[5] = string.Format("*           *", card.Sign);
                    cardGraphic[6] = string.Format("*           *", card.Sign);
                    cardGraphic[7] = string.Format("*     {0}     *", card.Sign);
                    break;
                case "3 ":
                    cardGraphic[3] = string.Format("*     {0}     *", card.Sign);
                    cardGraphic[4] = string.Format("*           *", card.Sign);
                    cardGraphic[5] = string.Format("*     {0}     *", card.Sign);
                    cardGraphic[6] = string.Format("*           *", card.Sign);
                    cardGraphic[7] = string.Format("*     {0}     *", card.Sign);
                    break;
                case "4 ":
                    cardGraphic[3] = string.Format("*   {0}   {0}   *", card.Sign);
                    cardGraphic[4] = string.Format("*           *", card.Sign);
                    cardGraphic[5] = string.Format("*           *", card.Sign);
                    cardGraphic[6] = string.Format("*           *", card.Sign);
                    cardGraphic[7] = string.Format("*   {0}   {0}   *", card.Sign);
                    break;
                case "5 ":
                    cardGraphic[3] = string.Format("*   {0}   {0}   *", card.Sign);
                    cardGraphic[4] = string.Format("*           *", card.Sign);
                    cardGraphic[5] = string.Format("*     {0}     *", card.Sign);
                    cardGraphic[6] = string.Format("*           *", card.Sign);
                    cardGraphic[7] = string.Format("*   {0}   {0}   *", card.Sign);
                    break;
                case "6 ":
                    cardGraphic[3] = string.Format("*   {0}   {0}   *", card.Sign);
                    cardGraphic[4] = string.Format("*           *", card.Sign);
                    cardGraphic[5] = string.Format("*   {0}   {0}   *", card.Sign);
                    cardGraphic[6] = string.Format("*           *", card.Sign);
                    cardGraphic[7] = string.Format("*   {0}   {0}   *", card.Sign);
                    break;
                case "7 ":
                    cardGraphic[3] = string.Format("*   {0}   {0}   *", card.Sign);
                    cardGraphic[4] = string.Format("*           *", card.Sign);
                    cardGraphic[5] = string.Format("*   {0} {0} {0}   *", card.Sign);
                    cardGraphic[6] = string.Format("*           *", card.Sign);
                    cardGraphic[7] = string.Format("*   {0}   {0}   *", card.Sign);
                    break;
                case "8 ":
                    cardGraphic[3] = string.Format("*   {0}   {0}   *", card.Sign);
                    cardGraphic[4] = string.Format("*     {0}     *", card.Sign);
                    cardGraphic[5] = string.Format("*   {0}   {0}   *", card.Sign);
                    cardGraphic[6] = string.Format("*     {0}     *", card.Sign);
                    cardGraphic[7] = string.Format("*   {0}   {0}   *", card.Sign);
                    break;
                case "9 ":
                    cardGraphic[3] = string.Format("*   {0} {0} {0}   *", card.Sign);
                    cardGraphic[4] = string.Format("*           *", card.Sign);
                    cardGraphic[5] = string.Format("*   {0} {0} {0}   *", card.Sign);
                    cardGraphic[6] = string.Format("*           *", card.Sign);
                    cardGraphic[7] = string.Format("*   {0} {0} {0}   *", card.Sign);
                    break;
                case "10":
                    cardGraphic[3] = string.Format("*    {0} {0}    *", card.Sign);
                    cardGraphic[4] = string.Format("*     {0}     *", card.Sign);
                    cardGraphic[5] = string.Format("*  {0} {0} {0} {0}  *", card.Sign);
                    cardGraphic[6] = string.Format("*     {0}     *", card.Sign);
                    cardGraphic[7] = string.Format("*    {0} {0}    *", card.Sign);
                    break;
                case "JA":
                    cardGraphic[3] = string.Format("*   {0}{0}{0}{0}    *", card.Sign);
                    cardGraphic[4] = string.Format("*      {0}    *", card.Sign);
                    cardGraphic[5] = string.Format("*      {0}    *", card.Sign);
                    cardGraphic[6] = string.Format("*   {0}  {0}    *", card.Sign);
                    cardGraphic[7] = string.Format("*    {0}{0}     *", card.Sign);
                    break;
                case "QU":
                    cardGraphic[3] = string.Format("*    {0}{0}{0}    *", card.Sign);
                    cardGraphic[4] = string.Format("*   {0}   {0}   *", card.Sign);
                    cardGraphic[5] = string.Format("*   {0}   {0}   *", card.Sign);
                    cardGraphic[6] = string.Format("*   {0}  {0}{0}   *", card.Sign);
                    cardGraphic[7] = string.Format("*    {0}{0}{0} {0}  *", card.Sign);
                    break;
                case "KI":
                    cardGraphic[3] = string.Format("*    {0}  {0}   *", card.Sign);
                    cardGraphic[4] = string.Format("*    {0} {0}    *", card.Sign);
                    cardGraphic[5] = string.Format("*    {0}{0}     *", card.Sign);
                    cardGraphic[6] = string.Format("*    {0} {0}    *", card.Sign);
                    cardGraphic[7] = string.Format("*    {0}  {0}   *", card.Sign);
                    break;
                case "AC":
                    cardGraphic[3] = string.Format("*     {0}     *", card.Sign);
                    cardGraphic[4] = string.Format("*    {0} {0}    *", card.Sign);
                    cardGraphic[5] = string.Format("*   {0}   {0}   *", card.Sign);
                    cardGraphic[6] = string.Format("*  {0} {0}{0}{0} {0}  *", card.Sign);
                    cardGraphic[7] = string.Format("* {0}       {0} *", card.Sign);
                    break;
                default:
                    break;
            }


            return cardGraphic;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int wins = 0;
                int losses = 0;
                int value = 0;
                List<Card> deck = new List<Card>();
                List<Card> discard = new List<Card>();

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 1; j <= 13; j++)
                    {
                        deck.Add(new Card(j, i + 1));
                    }
                }

                Card.ShuffleDeck(ref deck);

                /*
                for (int i = 0; i < deck.Count; i++)
                {
                    foreach (var line in Card.GetCardGraphic(deck[i]))
                    {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine();
                }//*/
                List<Card> PlayerHand;
                bool again = true;
                while (again)
                {
                    PlayerHand = Card.DrawCards(ref deck, 2, ref discard);
                    bool cont = true;
                    do
                    {
                        DrawScreen(PlayerHand, wins, losses);
                        Console.WriteLine("Will you Hit (H) or Stand (S)?");
                        switch (Console.ReadLine().ToUpper())
                        {
                            case "H":
                            case "HIT":
                                PlayerHand = PlayerHand.Concat(Card.DrawCards(ref deck, 1, ref discard)).ToList();
                                DrawScreen(PlayerHand, wins, losses);
                                break;
                            case "S":
                            case "STAND": cont = false; break;

                            default:
                                Console.WriteLine("Come again?! I didn't catch that, son.");
                                Thread.Sleep(2000);
                                break;
                        }
                    } while (Card.CountCardValues(PlayerHand) < 22 && cont);
                    List<Card> HouseHand = new List<Card>();

                    if (Card.CountCardValues(PlayerHand) > 21)
                    {
                        Console.WriteLine("BUST!");
                        losses++;
                    }
                    else
                    {
                        while (Card.CountCardValues(HouseHand) <= Card.CountCardValues(PlayerHand) && Card.CountCardValues(HouseHand) != 21)
                        {
                            HouseHand = HouseHand.Concat(Card.DrawCards(ref deck, 1, ref discard)).ToList();
                            DrawScreen(PlayerHand, wins, losses);

                            Console.WriteLine("House cards are: ");
                            Card.PaintDeck(HouseHand);
                            Console.WriteLine("Total value: " + Card.CountCardValues(HouseHand));
                            Thread.Sleep(1000);

                        }
                        bool playerWin = false;
                        if (Card.CountCardValues(HouseHand) > 21)
                        {
                            playerWin = true;
                        }
                        int playerScore = 21 - Card.CountCardValues(PlayerHand);
                        int houseScore = 21 - Card.CountCardValues(HouseHand);
                        bool drawMore = false;
                        do
                        {
                            drawMore = false;
                            if (playerScore < houseScore || playerWin)
                            {
                                Console.WriteLine("Nice job...");
                                wins++;
                            }
                            else if (playerScore > houseScore)
                            {
                                Console.WriteLine("BUST!");
                                losses++;
                            }
                            else if (houseScore == 0 && playerScore == 0)
                            {
                                Console.WriteLine("TIE?!");
                            }
                            else
                            {
                                HouseHand = HouseHand.Concat(Card.DrawCards(ref deck, 1, ref discard)).ToList();

                                DrawScreen(PlayerHand, wins, losses);

                                Console.WriteLine("House cards are: ");
                                Card.ListCards(HouseHand);
                                Console.WriteLine("Total value: " + Card.CountCardValues(HouseHand));
                                Thread.Sleep(1000);

                                drawMore = true;
                            }
                        } while (drawMore);
                    }
                    Console.WriteLine("Another round?");
                    switch (Console.ReadLine().ToUpper())
                    {
                        case "N":
                        case "NO":
                            again = false;
                            break;
                        default:
                            again = true;
                            break;
                    }
                    discard = discard.Concat(PlayerHand).Concat(HouseHand).ToList();
                }
                //*/
                Console.WriteLine("Bye bye");
                Console.ReadKey();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DrawScreen(List<Card> deck, int win, int loss)
        {
            Console.Clear();
            Console.WriteLine("Score: \nWins: {0}\nLosses: {1}\n", win, loss);
            Console.WriteLine("Your cards are: ");
            Card.PaintDeck(deck);
            Console.WriteLine("Total value: " + Card.CountCardValues(deck));
            Console.WriteLine();
        }
        
    }
}

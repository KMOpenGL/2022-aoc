using Console = Colorful.Console;

namespace AOC {

     public enum Hand {
         Rock = 0,
         Paper = 1,
         Scisors = 2   
     };

    class DayTwo : Day {

        public static Hand LoseBased(Hand p, out int score)
        {
            switch(p)
            {
                case Hand.Rock:
                    score = 3;
                    return Hand.Scisors;
                case Hand.Paper:
                    score = 1;
                    return Hand.Rock;
                case Hand.Scisors:
                    score = 2;
                    return Hand.Paper;
            }
            score = 0;
            return Hand.Rock;
        }

        public static Hand WinBased(Hand p, out int score)
        {
            switch(p)
            {
                case Hand.Rock:
                    score = 2;
                    return Hand.Paper;
                case Hand.Paper:
                    score = 3;
                    return Hand.Scisors;
                case Hand.Scisors:
                    score = 1;
                    return Hand.Rock;
            }
            score = 0;
            return Hand.Rock;
        }


        public struct Game {
            // 0 = loss
            // 1 = win
            // 2 = draw
            public int type = 0; 
            // 1 = rock
            // 2 = paper
            // 3 = scisors
            public int scoreP1 = 0;
            public int scoreP2 = 0;

            public Game(string i1, string i2)
            {

                bool draw = false;

                Hand p1 = new Hand();
                Hand p2 = new Hand();
                
                switch(i1)
                {
                    case "A":
                        scoreP1 = 1;
                        p1 = Hand.Rock;
                        break;
                    case "B":
                        scoreP1 = 2;
                        p1 = Hand.Paper;
                        break;
                    case "C":
                        scoreP1 = 3;
                        p1 = Hand.Scisors;
                        break;
                }


                switch(i2)
                {
                    case "X":
                        type = 1;
                        p2 = LoseBased(p1, out scoreP2);
                        scoreP1 += 6;
                        break;
                    case "Y":
                        type = 2;
                        p2 = p1;
                        scoreP2 = scoreP1 + 3;
                        scoreP1 += 3;
                        break;
                    case "Z":
                        type = 0;
                        p2 = WinBased(p1,  out scoreP2);
                        scoreP2 += 6;
                        break;
                }
            }
        }
        
        public Game convertToGame(string input1, string input2)
        {
            return new Game(input1, input2);
        }

        public override void run()
        {
            Console.WriteAscii("Day 2");
            Console.WriteLine("Who will win the elf Rock, Paper, Scisors tournament!");

            string[] lines = File.ReadAllLines("inputs/day2.input");

            int[] score = {0,0};

            int i = 0;

            int wins = 0, draws = 0, losses = 0;

            foreach(string l in lines)
            {
                i++;
                string[] s = l.Split(' ');
                Game game = convertToGame(s[0], s[1]);
                score[0] += game.scoreP1;
                score[1] += game.scoreP2;
                switch(game.type)
                {
                    case 0:
                        wins++;
                    break;
                    case 1:
                        losses++;
                        break;
                    case 2:
                        draws++;
                        break;
                }
            }

            Console.WriteLine($"Final score: {score[0]}-{score[1]} | Wins: {wins} | Draws: {draws} | Losses: {losses}");
            Console.Read();
        }
    }
}
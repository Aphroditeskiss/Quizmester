using Quizmester.Models;

namespace Quizmester.Services
{
    public class RankService
    {
        public Rank GetRank(int lp)
        {
            if (lp < 100)
                return CreateRank("Iron IV", lp, 0);

            if (lp < 200)
                return CreateRank("Iron III", lp, 100);

            if (lp < 300)
                return CreateRank("Iron II", lp, 200);

            if (lp < 400)
                return CreateRank("Iron I", lp, 300);

            if (lp < 500)
                return CreateRank("Bronze IV", lp, 400);

            if (lp < 600)
                return CreateRank("Bronze III", lp, 500);

            if (lp < 700)
                return CreateRank("Bronze II", lp, 600);

            if (lp < 800)
                return CreateRank("Bronze I", lp, 700);

            if (lp < 900)
                return CreateRank("Silver IV", lp, 800);

            if (lp < 1000)
                return CreateRank("Silver III", lp, 900);

            if (lp < 1100)
                return CreateRank("Silver II", lp, 1000);

            if (lp < 1200)
                return CreateRank("Silver I", lp, 1100);

            if (lp < 1300)
                return CreateRank("Gold IV", lp, 1200);

            if (lp < 1400)
                return CreateRank("Gold III", lp, 1300);

            if (lp < 1500)
                return CreateRank("Gold II", lp, 1400);

            if (lp < 1600)
                return CreateRank("Gold I", lp, 1500);

            if (lp < 2000)
                return CreateRank(
                    "Platinum",
                    lp,
                    1600
                );

            if (lp < 2400)
                return CreateRank(
                    "Diamond",
                    lp,
                    2000
                );

            return CreateRank(
                "Master",
                lp,
                2400
            );
        }

        public int CalculateLPGain(
            int correctAnswers,
            int totalQuestions)
        {
            if (totalQuestions <= 0)
            {
                return 0;
            }

            double percentage =
                (double)correctAnswers /
                totalQuestions *
                100;

            if (percentage == 100)
                return 40;

            if (percentage >= 86)
                return 30;

            if (percentage >= 71)
                return 24;

            if (percentage >= 51)
                return 18;

            if (percentage >= 26)
                return 10;

            return 5;
        }

        private Rank CreateRank(
            string name,
            int lp,
            int minimumLP)
        {
            return new Rank
            {
                Name = name,
                CurrentLP = lp,
                LPIntoRank = lp - minimumLP
            };
        }
    }
}
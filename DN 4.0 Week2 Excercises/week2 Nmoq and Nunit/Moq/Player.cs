using System;

namespace PlayersManagerLib
{
    public class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Country { get; private set; }
        public int NoOfMatches { get; private set; }

        public Player(string name, int age, string country, int noOfMatches)
        {
            Name = name;
            Age = age;
            Country = country;
            NoOfMatches = noOfMatches;
        }

        public static Player RegisterNewPlayer(string name, IPlayerMapper playerMapper = null)
        {
            if (playerMapper == null)
            {
                playerMapper = new PlayerMapper();
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Player name can’t be empty.");
            }

            if (playerMapper.IsPlayerNameExistsInDb(name))
            {
                throw new ArgumentException("Player name already exists.");
            }

            playerMapper.AddNewPlayerIntoDb(name);

            return new Player(name, 23, "India", 30);
        }
    }
}
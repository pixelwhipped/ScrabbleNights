using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Scrabble
{

    [Serializable]
    public enum Difficulty
    {
        Easy,Medium,Hard
    }

    [Serializable]
    public enum TileOrentation
    {
        Horizontal, Vertical
    }

    [Serializable]
    public enum PlayerType
    {
        Human, Computer
    }

    [Serializable]
    public struct Placement
    {
        public Point Point;
        public TileOrentation Orentation;
        public List<Tile> SelectedTiles;
    }

    [Serializable]
    public class Player
    {
        public string Name;
        public int Score;
        public PlayerType PlayerType;
        public int ConsecutivePasses;  //Needed to check for end of game.
        public List<Tile> TilePeices;
        public Placement Placement;        

        public static Player ConstructPlayer(string name, bool isHuman)
        {
            return new Player
                       {
                           Name = name,
                           Score = 0,
                           PlayerType =
                               isHuman ? PlayerType.Human : PlayerType.Computer,
                           ConsecutivePasses = 0,
                           TilePeices = new List<Tile>(),
                           Placement = new Placement
                                           {
                                               Point = new Point(0, 0),
                                               Orentation = TileOrentation.Horizontal,
                                               SelectedTiles = new List<Tile>()
                                           }
                       };
        }

        public Player Clone()
        {
            var p = new Player
                        {
                            Name = Name,
                            Score = Score,
                            PlayerType = PlayerType,
                            ConsecutivePasses = ConsecutivePasses,
                            TilePeices = new List<Tile>(TilePeices.ToArray()),
                            Placement = new Placement
                                            {
                                                Point = new Point(0, 0),
                                                Orentation = TileOrentation.Horizontal,
                                                SelectedTiles = new List<Tile>()
                                            }
                        };
            return p;
        }
    }

    [Serializable]
    public class Tile
    {
        #region Letter Points
        private static readonly List<KeyValuePair<char, int>> LetterPoints = new List<KeyValuePair<char, int>>
                                                                       {
                                                                           new KeyValuePair<char,int>(' ',0),
                                                                           new KeyValuePair<char,int>('e',1),
                                                                           new KeyValuePair<char,int>('a',1),
                                                                           new KeyValuePair<char,int>('i',1),
                                                                           new KeyValuePair<char,int>('o',1),
                                                                           new KeyValuePair<char,int>('n',1),
                                                                           new KeyValuePair<char,int>('r',1),
                                                                           new KeyValuePair<char,int>('t',1),
                                                                           new KeyValuePair<char,int>('l',1),
                                                                           new KeyValuePair<char,int>('s',1),
                                                                           new KeyValuePair<char,int>('y',1),
                                                                           new KeyValuePair<char,int>('d',2),
                                                                           new KeyValuePair<char,int>('g',2),
                                                                           new KeyValuePair<char,int>('b',3),
                                                                           new KeyValuePair<char,int>('c',3),
                                                                           new KeyValuePair<char,int>('m',3),
                                                                           new KeyValuePair<char,int>('p',3),
                                                                           new KeyValuePair<char,int>('f',4),
                                                                           new KeyValuePair<char,int>('h',4),
                                                                           new KeyValuePair<char,int>('v',4),
                                                                           new KeyValuePair<char,int>('w',4),
                                                                           new KeyValuePair<char,int>('y',4),
                                                                           new KeyValuePair<char,int>('k',5),
                                                                           new KeyValuePair<char,int>('j',8),
                                                                           new KeyValuePair<char,int>('x',8),
                                                                           new KeyValuePair<char,int>('q',10),
                                                                           new KeyValuePair<char,int>('z',10),
                                                                       };
        #endregion
        public static implicit operator char(Tile tile)
        {
            return tile.Letter;
        }
        public static implicit operator int(Tile tile)
        {
            return tile.Points;
        }
        public char Letter;
        public int Points;

        public static int PointsForTile(char letter)
        {
            var l = Char.ToLowerInvariant(letter);  //Saftey
            var p = LetterPoints.FirstOrDefault(x => x.Key == l);
            return (p.Key == default(char)) ? 0 : p.Value;
        }
    }

    [Serializable]
    public class Tiles
    {
        public List<Tile> TilePeices;

        public Tiles()
        {
            TilePeices = GenerateTiles();
        }

        public bool HasMoreTiles()
        {
            return TilePeices.Count != 0;
        }

        public Tile GetNextTile()
        {
            if (HasMoreTiles())
            {
                var i = Game.Random.Next(TilePeices.Count);
                var t = TilePeices[i];
                TilePeices.RemoveAt(i);
                return t;
            }
            return null;
        }

        public IEnumerable<Tile> GetNextTiles(int tiles)
        {
            for (var i = 0; i < Math.Min(tiles,TilePeices.Count); i++)
                yield return GetNextTile();
        }

        public static List<Tile> GenerateTiles()
        {
            var tiles = new List<Tile>();
            #region 2 blank tiles (scoring 0 points)
            tiles.AddRange(GenerateTile(' ', 0, 2));
            #endregion
            #region     1 point: E ×12, A ×9, I ×9, O ×8, N ×6, R ×6, T ×6, L ×4, S ×4, U ×4
            tiles.AddRange(GenerateTile('E', 1, 12));
            tiles.AddRange(GenerateTile('A', 1, 9));
            tiles.AddRange(GenerateTile('I', 1, 9));
            tiles.AddRange(GenerateTile('O', 1, 8));
            tiles.AddRange(GenerateTile('N', 1, 6));
            tiles.AddRange(GenerateTile('R', 1, 6));
            tiles.AddRange(GenerateTile('T', 1, 6));
            tiles.AddRange(GenerateTile('L', 1, 4));
            tiles.AddRange(GenerateTile('S', 1, 4));
            tiles.AddRange(GenerateTile('U', 1, 4));
            #endregion
            #region 2 points: D ×4, G ×3
            tiles.AddRange(GenerateTile('D', 2, 4));
            tiles.AddRange(GenerateTile('G', 2, 3));
            #endregion
            #region 3 points: B ×2, C ×2, M ×2, P ×2
            tiles.AddRange(GenerateTile('B', 3, 2));
            tiles.AddRange(GenerateTile('C', 3, 2));
            tiles.AddRange(GenerateTile('M', 3, 2));
            tiles.AddRange(GenerateTile('P', 3, 2));
            #endregion
            #region 4 points: F ×2, H ×2, V ×2, W ×2, Y ×2
            tiles.AddRange(GenerateTile('F', 4, 2));
            tiles.AddRange(GenerateTile('H', 4, 2));
            tiles.AddRange(GenerateTile('V', 4, 2));
            tiles.AddRange(GenerateTile('W', 4, 2));
            tiles.AddRange(GenerateTile('Y', 4, 2));
            #endregion
            #region 5 points: K ×1
            tiles.AddRange(GenerateTile('K', 5, 1));
            #endregion
            #region 8 points: J ×1, X ×1
            tiles.AddRange(GenerateTile('J', 8, 1));
            tiles.AddRange(GenerateTile('X', 8, 1));
            #endregion
            #region 10 points: Q ×1, Z ×1
            tiles.AddRange(GenerateTile('Q', 10, 1));
            tiles.AddRange(GenerateTile('Z', 10, 1));
            #endregion
            return tiles;

        }

        private static IEnumerable<Tile> GenerateTile(char letter, int points, int qty)
        {
            for (var i = 0; i < qty; i++)
                yield return new Tile { Letter = letter, Points = points };
        }
        
    }

    #region Board
    public enum Space
    {
        Blank,  //Blank
        FirstWord, //First Word
        DoubleLetter, //Double Letter
        TrippleLetter, //Tripple Letter
        DoubleWord, //Double Word
        TrippleWord  //Tripple Word
    } 

    public static class Board
    {
        #region Board Layout
        public static readonly Space[,] BoardLayout = new[,] { 
        { Space.TrippleWord, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.Blank, Space.TrippleWord, Space.Blank, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.TrippleWord },
        { Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank, Space.Blank, Space.TrippleLetter, Space.Blank, Space.Blank, Space.Blank, Space.TrippleLetter, Space.Blank, Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank },
        { Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank },
        { Space.DoubleLetter, Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank, Space.DoubleLetter },
        { Space.Blank, Space.Blank, Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank, Space.Blank, Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank, Space.Blank, Space.Blank },
        { Space.Blank, Space.TrippleLetter, Space.Blank, Space.Blank, Space.Blank, Space.TrippleLetter, Space.Blank, Space.Blank, Space.Blank, Space.TrippleLetter, Space.Blank, Space.Blank, Space.Blank, Space.TrippleLetter, Space.Blank },
        { Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank },
        { Space.TrippleWord, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.Blank, Space.FirstWord, Space.Blank, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.TrippleWord },
        { Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank },
        { Space.Blank, Space.TrippleLetter, Space.Blank, Space.Blank, Space.Blank, Space.TrippleLetter, Space.Blank, Space.Blank, Space.Blank, Space.TrippleLetter, Space.Blank, Space.Blank, Space.Blank, Space.TrippleLetter, Space.Blank },
        { Space.Blank, Space.Blank, Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank, Space.Blank, Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank, Space.Blank, Space.Blank },
        { Space.DoubleLetter, Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank, Space.DoubleLetter },
        { Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank },
        { Space.Blank, Space.DoubleWord, Space.Blank, Space.Blank, Space.Blank, Space.TrippleLetter, Space.Blank, Space.Blank, Space.Blank, Space.TrippleLetter, Space.Blank, Space.Blank, Space.Blank, Space.DoubleWord, Space.Blank },
        { Space.TrippleWord, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.Blank, Space.TrippleWord, Space.Blank, Space.Blank, Space.Blank, Space.DoubleLetter, Space.Blank, Space.Blank, Space.TrippleWord }
        };
        #endregion

        public static int BoardWidth { get { return BoardLayout.GetLength(0); } }
        public static int BoardHeight { get { return BoardLayout.GetLength(1); } }
       
        public static Tile[][] CreateBoard()
        {
            var board = new Tile[BoardWidth][];
            for (var i = 0; i < BoardWidth; i++)
                board[i] = new Tile[BoardWidth];
            return board;
        }

    }
    #endregion

    [Serializable]
    public class GameData
    {
        public Player[] Players;
        public int PlayerIndex;

        public Tiles Tiles;
        public int Turns;
        public Tile[][] GameBoard;
    }
    
    public enum EndOfTurn
    {
        Place,Exchange,Pass
    }

    public class Game
    {
        public delegate void Call();
        private readonly int[] _ords = new[] {7, 6, 8, 5, 9, 4, 10, 3, 11, 2, 12, 1, 13, 0, 14};
        public static readonly Random Random = new Random();
        public List<Point> LastPlaces;
        public List<Point> HintPlaces;
        public static implicit operator GameData(Game game)
        {
            return game.GameData;
        }

        public readonly Scrabble Scrabble;
        public ScrabbleWindow ScrabbleWindow { get { return Scrabble.ActiveWindow; } }

        public GameData GameData;

        public Player CurrentPlayer
        {
            get { return GameData.Players[PlayerIndex]; }
            protected set
            {
                for (var i = 0; i < Players.Count(); i++)
                {
                    if (value != Players[i]) continue;
                    PlayerIndex = i;
                    return;
                }
                PlayerIndex = -1;
            }
        }

        public Player[] Players { get { return GameData.Players; } }
        public int PlayerIndex { get { return GameData.PlayerIndex; } protected set { GameData.PlayerIndex = value; } }
        
        public Tiles Tiles { get { return GameData.Tiles; } protected set { GameData.Tiles = value; } }
        public int Turns { get { return GameData.Turns; }  set { GameData.Turns = value; } }
        public Tile[][] GameBoard { get { return GameData.GameBoard; } }


        public bool IsFirstTurn { get { return Turns == 0; } }
        public bool IsGameOver { get { return Players.All(p => p.ConsecutivePasses >= 2) || Players.Any(p => p.TilePeices.Count==0 ) || !Tiles.HasMoreTiles(); } }

        public Player Winner {get { return Players.OrderByDescending(p=>p.Score).FirstOrDefault(); }}

        public static bool IsDisposing;

        public int HintCount;

        public Game(Scrabble scrabble, params Player[] players):this(scrabble,new GameData
                                                      {
                                                         Players = players,
                                                         Tiles = new Tiles(),                                                         
                                                         GameBoard = Board.CreateBoard(),
                                                         Turns = 0
                                                      })
        {
            #region Set First Players
            var closest = 'z' + 1;
            foreach (var p in Players)
            {
                var next = Tiles.GetNextTile();
                if (next < closest || next == ' ')
                {
                    CurrentPlayer = p;
                    closest = next;
                }
                Tiles.TilePeices.Add(next);
            }
            #endregion

            #region Initialise Player
            foreach (var p in Players)
                p.TilePeices = new List<Tile>(Tiles.GetNextTiles(7));
            #endregion            
        }

        public Game(Scrabble scrabble, GameData data)
        {
            Scrabble = scrabble;
            GameData = data;
            LastPlaces = new List<Point>();
            HintPlaces = new List<Point>();
        }
     
        public bool EndTurn(EndOfTurn method)
        {
            HintCount = 0;
            if (!ScrabbleWindow.Disposing)
            {
                var valid = true;
                switch (method)
                {
                    case EndOfTurn.Place:
                        valid = PlayerPlaceTiles(CurrentPlayer); //Invalidate end on fail.
                        break;
                    case EndOfTurn.Exchange:
                        if (IsFirstTurn) Turns--;
                        PlayerExchangeTiles();
                        break;
                    case EndOfTurn.Pass:
                        if (IsFirstTurn) Turns--;
                        CurrentPlayer.ConsecutivePasses++;
                        break;
                }
                if (valid)
                {
                    Turns++;
                    if (IsGameOver)
                        EndGame();
                    else if (PlayerNext().PlayerType == PlayerType.Computer)
                    {
                        Invoke(ScrabbleWindow.DisableButtons);
                        MarsharUpdateAI();
                    }
                    else
                    {
                        Invoke(ScrabbleWindow.EnableButtons);
                        UpdateHints();
                    }
                }
                Invoke(ScrabbleWindow.RefreshComponents);
                return valid;
            }
            
            return false;
        }

        private void EndGame()
        {
            var score = 0;
            Player ender = null;
            foreach(var player in Players)
            {
                if (player.TilePeices.Count == 0) ender = player;
                foreach(var tile in player.TilePeices)
                {
                    player.Score -= tile;
                    score += tile;
                }
            }
            if (ender != null)
            {
                ender.Score += score;
            }
            Invoke(()=>Scrabble.ActiveWindow.TileCount.Text = Tiles.TilePeices.Count.ToString());
            Invoke(Scrabble.ActiveWindow.ShowEndGame);
            Invoke(Scrabble.ActiveWindow.DisableButtons);

        }       
        
        public void MarsharUpdateAI()
        {
            new Thread(UpdateAI).Start();
        }

        public void UpdateAI()
        {
            
            
            var combinations = Utilities.Combinations(CurrentPlayer.TilePeices);
            var placements = new Dictionary<int, Placement>();
          //  var locations = new Dictionary<int, List<Point>>();
            int[] usable = {0};
            var maxUsable = 3;
            switch (Scrabble.Settings.Difficulty)
            {
                case 0:
                    {
                        maxUsable = 1;
                        break;
                    }
                case 1:
                    {
                        maxUsable = 2;
                        break;
                    }
                case 3:
                    {
                        maxUsable = 3;
                        break;
                    }
            }

            foreach (var combination in combinations.TakeWhile(combination => usable[0] != maxUsable))
            {
                for (var y = 0; y < Common.BoardHeight; y++)
                {
                    if (usable[0] == maxUsable) break;
                    for (var x = 0; x < Common.BoardWidth; x++)
                    {
                        Thread.Yield();
                            
                        if (usable[0] == maxUsable) break;
                        if (GameBoard[_ords[x]][_ords[y]] != null)
                            continue;
                        List<Point> placeLocations;
                        List<List<Tile>> words;
                        int score;
                        var orentation = (Random.NextDouble() < 0.5)
                                                ? TileOrentation.Horizontal
                                                : TileOrentation.Vertical;
                        var placement = new Placement
                                            {
                                                Point = new Point(_ords[x], _ords[y]),
                                                Orentation = orentation,
                                                SelectedTiles = new List<Tile>(combination)
                                            };
                        string aword;
                        if (ValidatePlacement(placement, out placeLocations, out words))
                        {
                            if (ValidateWords(placeLocations, words, out aword, out score))
                            {
                                if (!placements.ContainsKey(score))
                                {
                                    CurrentPlayer.Placement = placement;
                                    Invoke(ScrabbleWindow.RefreshComponents);
                                    placements.Add(score, placement);
                                    //locations.Add(score, new List<Point>(placeLocations.ToArray()));
                                    usable[0]++;
                                    if (usable[0] == maxUsable) break;
                                    continue;
                                }
                            }
                        }
                        placement.Orentation = (orentation == TileOrentation.Vertical)
                                                    ? TileOrentation.Horizontal
                                                    : TileOrentation.Vertical;
                        if (ValidatePlacement(placement, out placeLocations, out words))
                        {
                            if (ValidateWords(placeLocations, words, out aword, out score))
                            {
                                if (!placements.ContainsKey(score))
                                {
                                    CurrentPlayer.Placement = placement;
                                    Invoke(ScrabbleWindow.RefreshComponents);
                                    placements.Add(score, placement);
                                    //locations.Add(score, new List<Point>(placeLocations.ToArray()));
                                    usable[0]++;
                                    if (usable[0] == maxUsable) break;
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            if (placements.Count() != 0)
            {
                switch (Scrabble.Settings.Difficulty)
                {
                    case 0:
                        {
                            var p = placements.Min(x => x.Key);
                            CurrentPlayer.Placement = placements[p];
                            if (Random.NextDouble() < 0.25)
                            {
                                PassOrExchange();
                            }
                            else
                            {
                                if (!EndTurn(EndOfTurn.Place))
                                {
                                    PassOrExchange();
                                }
                                else
                                {
                                    ScrabbleWindow.ResetLast();
                                }
                            }
                            break;
                        }
                    case 1:
                        {
                            var p = (Random.NextDouble() < 0.45) ? placements.Min(x => x.Key) : placements.Max(x => x.Key);
                            CurrentPlayer.Placement = placements[p];
                            if (Random.NextDouble() < 0.1)
                            {
                                PassOrExchange();
                            }
                            else
                            {
                                if (!EndTurn(EndOfTurn.Place))
                                {
                                    PassOrExchange();
                                }
                                else
                                {
                                    ScrabbleWindow.ResetLast();
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            var p = placements.Max(x => x.Key);
                            CurrentPlayer.Placement = placements[p];
                            if (!EndTurn(EndOfTurn.Place))
                            {
                                PassOrExchange();
                            }
                            else
                            {
                                ScrabbleWindow.ResetLast();
                            }
                            break;
                        }
                }                
            }
            else
            {
                PassOrExchange();
            }
        }

        public void UpdateHints()
        {
            HintPlaces.Clear();
            var player = CurrentPlayer.Clone();
            var combinations = Utilities.Combinations(player.TilePeices);
            var placements = new Dictionary<int, Placement>();
            int[] usable = { 0 };
            const int maxUsable = 1;


            foreach (var combination in combinations.TakeWhile(combination => usable[0] != maxUsable))
            {
                for (var y = 0; y < Common.BoardHeight; y++)
                {
                    if (usable[0] == maxUsable) break;
                    for (var x = 0; x < Common.BoardWidth; x++)
                    {
                        Thread.Yield();

                        if (usable[0] == maxUsable) break;
                        if (GameBoard[_ords[x]][_ords[y]] != null)
                            continue;
                        List<Point> placeLocations;
                        List<List<Tile>> words;
                        int score;
                        var orentation = (Random.NextDouble() < 0.5)
                                                ? TileOrentation.Horizontal
                                                : TileOrentation.Vertical;
                        var placement = new Placement
                        {
                            Point = new Point(_ords[x], _ords[y]),
                            Orentation = orentation,
                            SelectedTiles = new List<Tile>(combination)
                        };
                        string aword;
                        if (ValidatePlacement(placement, out placeLocations, out words))
                        {
                            if (ValidateWords(placeLocations, words, out aword, out score))
                            {
                                if (!placements.ContainsKey(score))
                                {
                                    foreach(var p in placeLocations)
                                    {
                                        HintPlaces.Add(p);
                                    }
                                    usable[0]++;
                                    if (usable[0] == maxUsable) break;
                                    continue;
                                }
                            }
                        }
                        placement.Orentation = (orentation == TileOrentation.Vertical)
                                                    ? TileOrentation.Horizontal
                                                    : TileOrentation.Vertical;
                        if (ValidatePlacement(placement, out placeLocations, out words))
                        {
                            if (ValidateWords(placeLocations, words, out aword, out score))
                            {
                                if (!placements.ContainsKey(score))
                                {
                                    foreach(var p in placeLocations)
                                    {
                                        HintPlaces.Add(p);
                                    }
                                    usable[0]++;
                                    if (usable[0] == maxUsable) break;
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
            if (HintPlaces.Count() == 0)
            {
                ScrabbleWindow.HintButton.Enabled = false;
            }
        }

        private void PassOrExchange()
        {
            var probPass = 1d - Math.Abs((Tiles.TilePeices.Count-0.01d)/100);
            EndTurn(Random.NextDouble() > probPass ? EndOfTurn.Pass : (Tiles.TilePeices.Count == 0) ? EndOfTurn.Pass : EndOfTurn.Exchange);
        }

        private void Invoke(Call call)            
        {
            if (ScrabbleWindow.InvokeRequired)
            {
                lock (ScrabbleWindow)
                {
                    if (!IsDisposing)
                        ScrabbleWindow.Invoke(call);
                }
                
            }
        }
        public void PlayerExchangeTiles()
        {
            if (CurrentPlayer.Placement.SelectedTiles.Count == 0)//Swap All
            {
                Tiles.TilePeices.AddRange(CurrentPlayer.TilePeices);
                CurrentPlayer.TilePeices.Clear();
                CurrentPlayer.TilePeices.AddRange(Tiles.GetNextTiles(7));
            }
            else
            {
                for (var index = 0; index < CurrentPlayer.Placement.SelectedTiles.Count; index++)
                {
                    var oldTile = CurrentPlayer.Placement.SelectedTiles[index];
                    var newtile = Tiles.GetNextTile();
                    Tiles.TilePeices.Add(oldTile);
                    CurrentPlayer.Placement.SelectedTiles[index] = newtile;
                    CurrentPlayer.TilePeices.Remove(oldTile);
                    CurrentPlayer.TilePeices.Insert(0, newtile);
                }
            }
            CurrentPlayer.Placement.SelectedTiles.Clear();
        }

        public void PlayerShuffleTiles()
        {
            for(var index = 0 ; index < CurrentPlayer.TilePeices.Count;index++)
            {
                var i = Random.Next(CurrentPlayer.TilePeices.Count);
                var temp = CurrentPlayer.TilePeices[i];
                CurrentPlayer.TilePeices.RemoveAt(i);
                CurrentPlayer.TilePeices.Add(temp);
            }
        }

        
        public bool PlayerPlaceTiles(Player player)
        {
            LastPlaces.Clear();
            List<Point> placeLocations;
            List<List<Tile>> words;
            List<Tile> tiles;
            int score;
            string aword;
            if (!ValidateBoard(player.Placement, out placeLocations, out words, out aword, out score)) return false;
            List<int> offsets;
            var loc = GetPlacementLocations(player.Placement,out offsets, out tiles);
           
            for (var index = 0; index < loc.Count; index++)
            {
                var t = player.Placement.SelectedTiles[index];

                
                var p = loc[index];
                if(!Scrabble.Settings.ReuseBlank)
                    t.Letter = aword[offsets[index]];
                GameBoard[p.X][p.Y] = t;
                LastPlaces.Add(new Point(p.X , p.Y));

            }

            player.TilePeices.RemoveAll(p => player.Placement.SelectedTiles.Contains(p));
            player.TilePeices.AddRange(Tiles.GetNextTiles(player.Placement.SelectedTiles.Count));
            player.Placement.SelectedTiles.Clear();
            player.Score += score;
            ScrabbleWindow.ResetLast();
            return true;
        }

        public bool ValidateWords(List<Point> placeLocations, List<List<Tile>> words,out string aword, out int score)
        {
            score = 0;
            var tileword = string.Empty;            
            for (var index = 0; index < words.Count; index++)
            {
                var word = words[index];
                if (index == 0) //First Word.
                {
                    var doubleWord = false;
                    var trippleWord = false;                    
                    var pIndex = 0;
                    foreach (var t in word)
                    {
                        var letterMultiplier = 1;
                        if (placeLocations.Count > pIndex)
                        {
                            var x = placeLocations[pIndex].X;
                            var y = placeLocations[pIndex].Y;
                            if(GameBoard[x][y] == null)
                            {
                            
                                if( Board.BoardLayout[x,y] == Space.DoubleWord)
                                    doubleWord = true;
                                if (Board.BoardLayout[x, y] == Space.FirstWord)
                                    doubleWord = true;
                                if (Board.BoardLayout[x, y] == Space.TrippleWord)
                                    trippleWord = true;
                                if (Board.BoardLayout[x, y] == Space.DoubleLetter)
                                    letterMultiplier = 2;
                                if (Board.BoardLayout[x, y] == Space.TrippleLetter)
                                    letterMultiplier = 3;
                                pIndex++;
                            }
                        }
                        score += t.Points * letterMultiplier;
                        tileword += t.Letter;
                    }                    
                    if (!Scrabble.Words.Contains(tileword,out aword))
                    {
                        score = 0;
                        return false;
                    }                        
                    score *= (trippleWord) ? 3 : (doubleWord) ? 2 : 1;
                }
                else
                {
                    foreach(var t in word)
                    {
                        score += t.Points;
                        tileword += t.Letter;
                    }
                    if (!Scrabble.Words.Contains(tileword, out aword))
                    {
                        score = 0;
                        return false;
                    }
                }
            }
            if (!Scrabble.Words.ContainsListedWord(new string(tileword.ToCharArray()),out aword))
            {
                score = 0;
                return false;
            }
            score += (CurrentPlayer.Placement.SelectedTiles.Count == 7) ? 100 : 0;
            return true;
        }

        public bool ValidateBoard(Placement placement, out List<Point> placeLocations, out List<List<Tile>> words,out string aword, out int score)
        {
            score = 0;
            aword = null;
            if (placement.SelectedTiles.Count() == 1)
            {
                var orentation = placement.Orentation;
                placement.Orentation = TileOrentation.Horizontal;
                if(ValidatePlacement(placement, out placeLocations, out words) &&
                       ValidateWords(placeLocations, words, out aword, out score))
                {
                    CurrentPlayer.Placement.Orentation = placement.Orentation = orentation;
                    return true;
                }
                placement.Orentation = TileOrentation.Vertical;
                if (ValidatePlacement(placement, out placeLocations, out words) &&
                    ValidateWords(placeLocations, words, out aword, out score))
                {
                    CurrentPlayer.Placement.Orentation = placement.Orentation = orentation;
                    return true;
                }
                placement.Orentation = orentation;
                return false;
            }
            return ValidatePlacement(placement, out placeLocations, out words) &&
                   ValidateWords(placeLocations, words, out aword, out score);
        }

        public bool GetMinMax(Placement placement, List<Point> placements, out Point min, out Point max)
        {
            #region Get Scanning Bounds
            if (placements.Count() != 0)
            {
                var minX = placements.Min(p => p.X);
                var minY = placements.Min(p => p.Y);

                #region scan before

                if (placement.Orentation == TileOrentation.Horizontal)
                {
                    var xm = minX;
                    if (IsWithinBounds(xm-1, minY) && GameBoard[xm-1][minY] != null)
                    {
                        while (IsWithinBounds(xm-1, minY) && GameBoard[xm-1][minY] != null)
                            xm--;
                        minX = xm;
                    }
                }
                else
                {
                    var ym = minY;
                    if (IsWithinBounds(minX, ym-1) && GameBoard[minX][ym-1] != null)
                    {
                        while (IsWithinBounds(minX, ym-1) && GameBoard[minX][ym-1] != null)
                            ym--;
                        minY = ym;
                    }
                }

                #endregion

                var maxX = placements.Max(p => p.X);
                var maxY = placements.Max(p => p.Y);

                #region scan after

                if (placement.Orentation == TileOrentation.Horizontal)
                {
                    var xm = maxX;
                    if (IsWithinBounds(xm+1, minY) && GameBoard[xm+1][minY] != null)
                    {
                        while (IsWithinBounds(xm+1, minY) && GameBoard[xm+1][minY] != null)
                            xm++;
                        maxX = xm;
                    }
                }
                else
                {
                    var ym = maxY;
                    if (IsWithinBounds(minX, ym+1) && GameBoard[minX][ym+1] != null)
                    {
                        while (IsWithinBounds(minX, ym+1) && GameBoard[minX][ym+1] != null)
                            ym++;
                        maxY = ym;
                    }
                }

                #endregion

                min = new Point(minX, minY);
                max = new Point(maxX, maxY);
                return IsWithinBounds(minX, minY) && IsWithinBounds(maxX, maxY);
            }
            min = new Point(-1, -1);
            max = new Point(-1 -1);
            
            return false;

            #endregion
        }

        public bool ValidatePlacement(Placement placement, out List<Point> placeLocations, out List<List<Tile>> words)
        {
            var points = new List<Point>();
            var foundWord = new List<List<Tile>>();
            
            List<Tile> selection;
            List<int> offsets;
            placeLocations = GetPlacementLocations(placement,out offsets, out selection);

            #region First Turn

            if (IsFirstTurn)
            {
                var d = (placement.Orentation == TileOrentation.Horizontal)
                            ? placement.Point.X
                            : placement.Point.Y;
                var a = (placement.Orentation == TileOrentation.Vertical)
                            ? placement.Point.X
                            : placement.Point.Y;
                var iC = false;
                var jC = false;
                for (var index = d; index < d + selection.Count; index++)
                {
                    if (index == 7) iC = true;
                    if (a == 7) jC = true;
                    if (!(iC && jC)) continue;
                    words = new List<List<Tile>>{selection};
                    return true;
                }
                words = new List<List<Tile>> { selection };
                return false;
            }

            #endregion

            #region Get Scanning Bounds

            Point min;
            Point max;
            List<Tile> word;
            List<Point> npoint;
            var withinbounds = GetMinMax(placement, placeLocations, out min, out max);
            var attached = ScanWord(min, max, selection, out word, out npoint, placement.Orentation);
            points.AddRange(npoint);
            foundWord.Add(new List<Tile>(word));
            //Scan connected
            for(var i = 0; i < placeLocations.Count;i++)
            {
                if (placement.Orentation == TileOrentation.Horizontal)
                {
                    if (ScanVerticleWord(placeLocations[i], selection[i], out word, out npoint))
                    {
                        foundWord.Add(new List<Tile>(word));
                        points.AddRange(npoint);
                        attached = true;
                    }
                }
                else 
                {
                    if (ScanHorizontalWord(placeLocations[i], selection[i], out word, out npoint))
                    {
                        foundWord.Add(new List<Tile>(word));
                        points.AddRange(npoint);
                        attached = true;
                    }
                }
            }
            placeLocations = points;
            words = foundWord.ToList();
            return attached && withinbounds;
        }

        private bool ScanVerticleWord(Point location, Tile tile, out List<Tile> word, out List<Point> p)
        {
            var ym = location.Y;
            if (IsWithinBounds(location.X, ym - 1) && GameBoard[location.X][ym - 1] != null)
            {
                while (IsWithinBounds(location.X , ym - 1) && GameBoard[location.X][ym - 1] != null)
                    ym--;
            }
            var min = new Point(location.X, ym);
            ym = location.Y;
            if (IsWithinBounds(location.X, ym + 1) && GameBoard[location.X][ym + 1] != null)
            {
                while (IsWithinBounds(location.X, ym + 1) && GameBoard[location.X][ym + 1] != null)
                    ym++;
            }
            var max = new Point(location.X, ym);
            return ScanWord(min, max, new List<Tile>(new[] { tile }), out word, out p, TileOrentation.Vertical);
        }

        private bool ScanHorizontalWord(Point location, Tile tile, out List<Tile> word, out List<Point> p)
        {
            var xm = location.X;
            if (IsWithinBounds(xm - 1, location.Y) && GameBoard[xm - 1][location.Y] != null)
                {
                    while (IsWithinBounds(xm - 1, location.Y) && GameBoard[xm - 1][location.Y] != null)
                        xm--;
                }
            var min = new Point(xm, location.Y);
            xm = location.X;
            if (IsWithinBounds(xm + 1, location.Y) && GameBoard[xm + 1][location.Y] != null)
            {
                while (IsWithinBounds(xm + 1, location.Y) && GameBoard[xm + 1][location.Y] != null)
                    xm++;
            }
            var max = new Point(xm, location.Y);
            
            var ret =  ScanWord(min, max, new List<Tile>(new[] { tile }), out word, out p,TileOrentation.Horizontal);
            return ret;
        }

        private bool ScanWord(Point min, Point max, List<Tile> selection, out List<Tile> w, out List<Point> p, TileOrentation orentation)
        {
            var attached = false;
            var points = new List<Point>();
            var word = new List<Tile>();
            var minX = min.X;
            var minY = min.Y;

            var maxX = max.X;
            var maxY = max.Y;

            var withinBounds = IsWithinBounds(minX, minY) && IsWithinBounds(maxX, maxY);
            #endregion
            if (!(maxX == -1 || maxY == -1 || minX == -1 || minY == -1))
            {
                if (orentation == TileOrentation.Horizontal)
                {
                    var offset = 0;
                    for (var x = minX; x <= maxX; x++)
                    {
                        if (GameBoard[x][minY] != null)
                        {
                            attached = true;
                            word.Add(GameBoard[x][minY]);
                        }
                        else
                        {
                            word.Add(selection[offset]);
                            offset++;
                        }
                        points.Add(new Point(x, minY));
                    }
                }
                else
                {
                    var offset = 0;
                    for (var y = minY; y <= maxY; y++)
                    {
                        if (GameBoard[minX][y] != null)
                        {
                            attached = true;
                            word.Add(GameBoard[minX][y]);
                        }
                        else
                        {
                            word.Add(selection[offset]);
                            offset++;
                        }
                        points.Add(new Point(minX, y));
                    }
                }
            }
            w = word;
            p = points;
            return attached && withinBounds;
        }

        public List<Point> GetPlacementLocations(Placement placement, out List<int> offsets, out List<Tile> tiles)
        {
            var offset = 0;
            var woffset = 0;
            var points = new List<Point>();
            var x = placement.Point.X;
            var y = placement.Point.Y;
            
            var tList = new List<Tile>();
            var toffsets = new List<int>();
            for (var index = 0; index < placement.SelectedTiles.Count; index++)
            {
                var xoffset = (placement.Orentation == TileOrentation.Horizontal) ? x + index + offset : x;
                var yoffset = (placement.Orentation == TileOrentation.Vertical) ? y + index + offset : y;
                if (!IsWithinBounds(xoffset, yoffset)) break;
                while (GameBoard[xoffset][yoffset] != null)
                {
                    
                    offset++;
                    woffset++;
                    xoffset = (placement.Orentation == TileOrentation.Horizontal) ? x + index + offset : x;
                    yoffset = (placement.Orentation == TileOrentation.Vertical) ? y + index + offset : y;
                    if (IsWithinBounds(xoffset, yoffset))
                        continue;
                    break;
                }
                //todo check
                toffsets.Add(index+woffset);
                if (!IsWithinBounds(xoffset, yoffset)) break;
                points.Add(new Point(xoffset, yoffset));
                tList.Add(placement.SelectedTiles[index]);
            }
            tiles = tList;
            Point min, max;
            GetMinMax(placement, points, out min, out max);
            if (placement.Orentation == TileOrentation.Horizontal)
            {
                woffset = placement.Point.X - min.X;
                
            }else
            {
                woffset = placement.Point.Y - min.Y;                
            }
            offsets = toffsets.Select(toffset => toffset + woffset).ToList();

            return points;
        }

        public static bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < Common.BoardWidth && y >= 0 && y < Common.BoardHeight;
        }

        private Player PlayerNext()
        {
            if (++PlayerIndex == Players.Length)
            {
                PlayerIndex = 0;
            }
            return CurrentPlayer;
        }

        public void StartGame()
        {
            HintCount = 0;
            while(!Scrabble.IsLoaded)
            {
                Thread.Sleep(100);
            }
            
            if (CurrentPlayer.PlayerType == PlayerType.Computer)
            {
                Invoke(ScrabbleWindow.DisableButtons);                
                MarsharUpdateAI();
            }else
            {
                UpdateHints();
                Invoke(ScrabbleWindow.EnableButtons);
            }
            Scrabble.ActiveWindow.TileCount.Text = Tiles.TilePeices.Count.ToString();

        }
    }
}

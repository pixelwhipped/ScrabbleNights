using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Scrabble.Properties;

namespace Scrabble
{
    public class Common
    {
        public static readonly string SpaceString = " ";
        public static readonly char SpaceChar = ' ';
        public static readonly string CommaString = ",";
        public static readonly char CommaChar = ',';
        public static readonly int TileSizePx = 30;
        public static readonly int BoardPaddingPx = 30;
        public static int BoardWidth { get { return Board.BoardWidth; } }
        public static int BoardHeight { get { return Board.BoardHeight; } }
        public static readonly int BoardWidthPx = TileSizePx * BoardWidth;
        public static readonly int BoardHeightPx = TileSizePx * BoardHeight;

        public static readonly Color ColorBorder = Color.Black;


        public static readonly Pen PenTileBorder = new Pen(ColorBorder, 2);
        public static readonly Pen PenBoardBorder = new Pen(ColorBorder, 4);

        public static readonly Brush BrushMouseOverHighlight = new SolidBrush(Color.FromArgb(128, 255, 255, 255));
        public static readonly Brush BrushSpecialTileOverlayColor = Brushes.AntiqueWhite;

        public static readonly Brush BrushTileBlank = Brushes.Moccasin;
        public static readonly Brush BrushTileFirstWord = Brushes.LimeGreen;
        public static readonly Brush BrushTileTripleLetter = BrushTileFirstWord;
        public static readonly Brush BrushTileDoubleLetter = Brushes.SteelBlue;
        public static readonly Brush BrushTileTripleWord = Brushes.DarkOrange;
        public static readonly Brush BrushTileDoubleWord = Brushes.Firebrick;

        public static readonly Color ColorTileLetter = Color.Khaki;
        public static readonly Brush BrushTileLetter = new SolidBrush(ColorTileLetter);
        public static readonly Brush BrushTileLetters = Brushes.Black;
        public static readonly Brush BrushTileLetterTranslucent = new SolidBrush(Color.FromArgb(128, ColorTileLetter.R, ColorTileLetter.G, ColorTileLetter.B));

        public static readonly Brush BrushTileLetterPlaceable = new SolidBrush(Color.FromArgb(128, 0, ColorTileLetter.G, 0));
        public static readonly Brush BrushTileLetterUnPlaceable = new SolidBrush(Color.FromArgb(128, ColorTileLetter.R, 0, 0));
        public static readonly Brush BrushTileLetterPlaced = new SolidBrush(Color.FromArgb(128, 0, 0, ColorTileLetter.B));


        public static readonly Font FontSpecialTile = new Font("Arial", 10);
        public static readonly Font FontTileLetter = new Font("Arial", 14);
        public static readonly Font FontTilePoints = new Font("Arial", 8);
    }

    public class Utilities
    {
        public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
        {
            value = (value.CompareTo(max) > 0) ? max : value;
            value = (value.CompareTo(min) < 0) ? min : value;
            return value;
        }
        public static Stream LoadResource(string manifest)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(manifest);
            if (stream == null)
            {
                throw new FileNotFoundException("Cannot find mappings file.", manifest);
            }
            return  stream;
        }

        public static void DrawGameFont(Graphics g, string text, Point point, int fontSize, int spacing)
        {
            for (var index = 0; index < text.ToLower().ToCharArray().Length; index++)
            {
                var c = text.ToLower().ToCharArray()[index];
                switch (c)
                {
                    case 'a':
                        {
                            g.DrawImage(Resources.a, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'b':
                        {
                            g.DrawImage(Resources.b, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'c':
                        {
                            g.DrawImage(Resources.c, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'd':
                        {
                            g.DrawImage(Resources.d, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'e':
                        {
                            g.DrawImage(Resources.e, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'f':
                        {
                            g.DrawImage(Resources.f, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'g':
                        {
                            g.DrawImage(Resources.g, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'h':
                        {
                            g.DrawImage(Resources.h, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'i':
                        {
                            g.DrawImage(Resources.i, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'j':
                        {
                            g.DrawImage(Resources.j, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'k':
                        {
                            g.DrawImage(Resources.k, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'l':
                        {
                            g.DrawImage(Resources.l, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'm':
                        {
                            g.DrawImage(Resources.m, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'n':
                        {
                            g.DrawImage(Resources.n, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'o':
                        {
                            g.DrawImage(Resources.o, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'p':
                        {
                            g.DrawImage(Resources.p, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'q':
                        {
                            g.DrawImage(Resources.q, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'r':
                        {
                            g.DrawImage(Resources.r, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 's':
                        {
                            g.DrawImage(Resources.s, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 't':
                        {
                            g.DrawImage(Resources.t, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'u':
                        {
                            g.DrawImage(Resources.u, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'v':
                        {
                            g.DrawImage(Resources.v, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'w':
                        {
                            g.DrawImage(Resources.w, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'x':
                        {
                            g.DrawImage(Resources.x, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'y':
                        {
                            g.DrawImage(Resources.y, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                    case 'z':
                        {
                            g.DrawImage(Resources.z, index * fontSize + (index * spacing), 0, fontSize, fontSize);
                            break;
                        }
                }
            }
        }

        public static void DrawPlacementTile(Graphics g, Tile tile, int x, int y, Brush overlay)
        {
            if (tile == null) return;
            var p = Common.PenTileBorder;
            //var r = new Rectangle(x * Common.TileSizePx, y * Common.TileSizePx, Common.TileSizePx, Common.TileSizePx);
            var r = new Rectangle(x, y, Common.TileSizePx, Common.TileSizePx);

            g.FillRectangle(overlay, r);
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString(tile.Letter.ToString(), Common.FontTileLetter, Common.BrushTileLetters, r, stringFormat);

            stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Far
            };
            g.DrawString(tile.Points.ToString(), Common.FontTilePoints, Common.BrushTileLetters, r, stringFormat);
            g.DrawRectangle(p, r);
        }

        /// <summary>
        /// Deserialize an object 
        /// </summary>
        public static void DeserializeObject<T>(string fileName, out T obj)
        {
            // load xml serializer
           // var serializer = new XmlSerializer(typeof(T));
            var serializer = new BinaryFormatter(); 


            // create the file stream and writer
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                obj = (T)serializer.Deserialize(fs);
            }
        }

        /// <summary>
        /// Serialize an object to a file
        /// </summary>
        public static void SerializeObject<T>(T obj, string fileName)
        {
            // create serializer
            var serializer = new BinaryFormatter();


            // create the file stream
            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, obj);
            }
        }

        /// <summary>
        /// Gets all possible combinations of values.
        /// </summary>
        /// <typeparam name="T">Generic Type.</typeparam>
        /// <param name="values">Values to combine.</param>
        /// <returns>Resulting combination list.</returns>
        public static ICollection<List<T>> Combinations<T>(List<T> values)
        {
            var combinations = new List<List<T>>();
            RecurseCombinations(values, 0, new List<T>(), new List<T>(), combinations);
            return combinations;
        }

        /// <summary>
        /// Helper for the List Combinations(T[] values) method. 
        /// </summary>
        /// <typeparam name="T">Generic Type.</typeparam>
        /// <param name="values">Objects to combine.</param>
        /// <param name="index">Current object index.</param>
        /// <param name="current">Current list of objects in combination.</param>
        /// <param name="add">List to ad to current list at this part of the recursive tree,</param>
        /// <param name="result">Resulting combination list.</param>
        private static void RecurseCombinations<T>(IList<T> values, int index, IEnumerable<T> current, List<T> add,
                                                   ICollection<List<T>> result)
        {
            var list = new List<T>(current);
            list.InsertRange(list.Count, add);
            if (index == values.Count)
            {
                result.Add(list);
                return;
            }

            // include values[index]
            add.RemoveAll(n => true);
            add.Add(values[index]);
            RecurseCombinations(values, index + 1, list, add, result);

            // exclude values[index] 
            RecurseCombinations(values, index + 1, list, new List<T>(), result);
        }
    }


}

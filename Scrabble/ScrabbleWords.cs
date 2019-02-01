using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Scrabble
{
    public class CharNode
    {
        public List<CharNode> Nodes;
        public CharNode Parent;
        public char Char;
        public string Word
        {
            get
            {
                var w = new List<char> { Char };
                var p = Parent;
                while (p != null)
                {
                    w.Insert(0, p.Char);
                    p = p.Parent;
                }
                return new string(w.ToArray());
            }
        }

        internal bool Subword;
        public bool IsWord
        {
            get { return Nodes.Count == 0 || Subword; }
        }
        public CharNode(char c, CharNode parent = null)
        {
            Parent = parent;
            Char = c;
            Nodes = new List<CharNode>();
        }
    }

    public class ScrabbleWords
    {
        private readonly List<CharNode> _nodes;
        private readonly List<string> _words;
  
        public ScrabbleWords(IEnumerable<Stream> dictionarys)
        {
            _nodes = new List<CharNode>();
            _words = new List<string>();
            foreach (var dictionary in dictionarys.Where(dictionary => dictionary != null))
            {
                using (var r = new StreamReader(dictionary))
                {
                    string word;
                    while ((word = r.ReadLine()) != null)
                    {
                        word = word.Trim().ToUpperInvariant();
                        if (word.Length > Common.BoardWidth || !new Regex("^[A-Z]+$").IsMatch(word)) continue;
                        _words.Add(word);  
                    }
                }
                foreach (var word in _words)
                {
                    var wArray = word.ToArray();
                    CharNode node = null;
                    for (var index = 0; index < wArray.Length; index++)
                    {
                        var cNode = wArray[index];
                        if (index == 0)
                        {
                            if (!_nodes.Any(x => x.Char == cNode))
                                _nodes.Add(new CharNode(cNode));
                            node = _nodes.First(x => x.Char == cNode);
                        }
                        else
                        {
                            if (node != null && !node.Nodes.Any(x => x.Char == cNode))
                                node.Nodes.Add(new CharNode(cNode, node));
                            if (node != null) node = node.Nodes.First(x => x.Char == cNode);
                        }
                    }
                    if (node != null) node.Subword = true;
                }
            }
        }

        public bool Contains(string word, out string aword, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            aword = word;
            if (word.Contains(" ")) return ContainsListedWord(word, out aword, comparison);
            var wArray = word.ToArray();
            CharNode node = null;
            for (var index = 0; index < wArray.Length; index++)
            {
                var cNode = wArray[index];

                if (index == 0)
                {
                    if (_nodes.Any(x => x.Char == cNode))
                    {
                        node = _nodes.First(x => x.Char == cNode);
                    }
                    if (node != null && (node.IsWord && word.Equals(node.Word, comparison)))
                    {
                        return true;
                    }
                    continue;
                }
                if (node != null && node.Nodes.Any(x => x.Char == cNode))
                {
                    node = node.Nodes.First(x => x.Char == cNode);
                }
                if (node != null && (node.IsWord && node.Word.Equals(word, comparison)))
                {
                    return node.IsWord && word.Equals(node.Word, comparison);
                }
            }
            return false;
        }

        public bool ContainsListedWord(string tileword, out string aword, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            aword = tileword;
            if (!tileword.Contains(" ")) return _words.Contains(tileword);
            var wl = _words.Where(p => p.Length == tileword.Length);
            foreach (var word in wl)
            {
                var w = tileword.ToCharArray();
                for (var i = 0; i < tileword.Length; i++)
                {
                    if (w[i] == ' ')
                    {
                        w[i] = word[i];
                    }
                }
                aword = new String(w);
                if (aword.Equals(word, comparison)) return true;
            }
            return false;
        }
    }
}

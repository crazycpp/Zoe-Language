using System;
using System.Collections.Generic;

namespace Zoe.Lexer {
    public class Lexer {
        private Scanner _Scanner = new Scanner();
        List<Matcher> _MatcherList = new List<Matcher>();

        public Lexer() {
        }

        public void AddMatcher(Matcher Matcher) {
            _MatcherList.Add(Matcher);
        }

        public void Init(string source, string fileName) {
            _Scanner.Init(source, fileName);
        }

        public Token Scan() {
            while(!_Scanner.IsEof(0)) {
                foreach(var matcher in _MatcherList) {
                    var token = matcher.Match(_Scanner);
                    if(token == Token.Invalid)
                        continue;

                    if(matcher.Ignore)
                        continue;

                    return token;
                }
            }
            return Token.Invalid;
        }
    }
}

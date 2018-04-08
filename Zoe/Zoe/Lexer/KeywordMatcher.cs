using System;
namespace Zoe.Lexer {
    public class KeywordMatcher : Matcher{
        public string Keyword {
            get;
            private set;
        }

        public KeywordMatcher(int id, string keyword) {
            base.ID = id;
            base.Name = "IDENT";

            for(int i = 0; i<keyword.Length; i++) {
                if(!IsKeyword(i, keyword[i])) {
                    throw new Exception( "illeagal keyword" );
                }
            }

            Keyword = keyword;
        }

        private bool IsKeyword(int index, char c) {
            var baseMatch = char.IsLetter(c)|| c == '_';

            // if c is the first char
            if(index == 0)
                return baseMatch;

            return baseMatch || char.IsDigit(c);
        }

        public override Token Match(Scanner scanner) {

            if(scanner.RemainCount < Keyword.Length) {
                return Token.Invalid;
            }

            var tokenPos = scanner.Pos;

            for(int i = 0; i<Keyword.Length; i++) {
                char c = scanner.Peek(i);

                if(c != Keyword[i]) {
                    return Token.Invalid;
                }
            }

            scanner.Consume(Keyword.Length);

            return new Token(ID, Keyword, tokenPos);
        }
    }
}

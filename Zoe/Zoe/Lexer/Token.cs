using System;
namespace Zoe.Lexer {

    public struct TokenPos {

        public static TokenPos Invalidos = new TokenPos() { Col = -1, Line = -1 };

        public int Col {
            get; set;
        }

        public int Line {
            get; set;
        }

        public string FileName{
            get;set;
        }
    }

    public class Token {

        public int ID{
            get;
            private set;
        }

        public string Value{
            get;
            private set;
        }

        public TokenPos Pos {
            get;
            private set;
        }

        public static Token Invalid = new Token(-1, "", TokenPos.Invalidos);
        
        public Token(int id, string value, TokenPos pos) {
            ID = id;
            Value = value;
            Pos = pos;
        }
    }
}

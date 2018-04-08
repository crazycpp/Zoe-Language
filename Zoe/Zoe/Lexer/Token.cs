using System;
namespace Zoe.Lexer {

    public struct TokenPos {

        public static TokenPos Invalidos = new TokenPos() { Col = -1, Line = -1 };
        public static TokenPos InitPos = new TokenPos { Col = 1, Line = 1 };

        public int Col {
            get; set;
        }

        public int Line {
            get; set;
        }

        public string FileName{
            get;set;
        }

        public bool Equals( TokenPos pos) {
            return Col == pos.Col && Line == pos.Line && FileName == pos.FileName;
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

        public bool IsInvalid {
            get {
                if(this == Token.Invalid) {
                    return false;
                }

                return true;
            }
        }

        public static Token Invalid = new Token(-1, "", TokenPos.Invalidos);
        
        public Token(int id, string value, TokenPos pos) {
            ID = id;
            Value = value;
            Pos = pos;
        }

        public new string ToString() {
            return Pos.FileName+ " " + Pos.Line + ":" +Pos.Col + " " + this.ID + " " + this.Value;
        }
    }
}

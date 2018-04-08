using System;
namespace Zoe.Lexer {
    public class SignMatcher : Matcher{

        public string Sign{
            get;
            private set;
        }

        public SignMatcher(int id, string sign) {
            ID = id;
            Name = "Sign";

            for( int i = 0; i < sign.Length;  i++){
                if (!IsSign(sign[i])){
                    throw new Exception("illegal Sign");
                }
            }

            Sign = sign;
        }

        private bool IsSign(char c){
            return !char.IsLetterOrDigit(c) && c != ' ' && c != '\n' && c != '\r';
        }

        public override Token Match( Scanner scanner ) {
            var signLentgh = Sign.Length;
            for( int i = 0; i < signLentgh;  i++){
                if( Sign[i] != scanner.Peek(i) )
                    return Token.Invalid;
            }

            TokenPos pos = scanner.Pos;
            scanner.Consume(signLentgh);

            return new Token(ID, Sign, pos);
        }
    }
}

using System;
namespace Zoe.Lexer {
    public class IdentifierMatcher : Matcher {
        
        public IdentifierMatcher(int ID) {
            base.ID = ID;
        }

        public override Token Match( Scanner scanner ) {
            if( !char.IsLetterOrDigit(scanner.Current) || scanner.Current != '_' )
                return Token.Invalid;

            TokenPos pos = scanner.Pos;
            int beginIndex = scanner.ReadedCount;
            while(true){
                char c = scanner.Current;
                if (char.IsLetterOrDigit(c) || c == '_'){
                    scanner.Consume(1);
                    continue;
                }

                break;
            }

            return new Token(ID, scanner.Source.Substring(beginIndex, scanner.ReadedCount), pos);
        }
    }
}

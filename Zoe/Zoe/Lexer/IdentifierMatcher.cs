using System;
namespace Zoe.Lexer {
    public class IdentifierMatcher : Matcher {
        
        public IdentifierMatcher(int ID) {
            base.ID = ID;
            base.Name = "IDENT";
        }

        public override Token Match( Scanner scanner ) {
            if( !char.IsLetterOrDigit(scanner.Current) && scanner.Current != '_' )
                return Token.Invalid;

            TokenPos pos = scanner.Pos;
            int beginIndex = scanner.ReadedCount;
            int identCount = 0;
            while(true){
                char c = scanner.Current;
                if (char.IsLetterOrDigit(c) || c == '_'){
                    scanner.Consume(1);
                    identCount++;
                    continue;
                }

                break;
            }

            return new Token(ID, scanner.Source.Substring(beginIndex, identCount), pos);
        }
    }
}
